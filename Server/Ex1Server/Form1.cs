using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ex1Server
{
    public partial class Form1 : Form
    {
        NetworkManagement network;
        Task discoveryTask;
        Task TCPTask;
        Task UDPTask;
        bool listening = false;
        public Form1()
        {
            network = new NetworkManagement(this);
            AllocConsole();
            InitializeComponent();
        }


        public void UpdateTCPSingle(string data)
        {
            TCPSingle.Text = data;
        }

        public void UpdateUDPSingle(string data)
        {
            UDPSingle.Text = data;
        }

        public void UpdateTCPTotal(string data)
        {
            TCPTotalSize.Text = data;
        }

        public void UpdateUDPTotal(string data)
        {
            UDPTotalSize.Text = data;
        }

        public void UpdateTCPTime(string data)
        {
            TCPTotalTime.Text = data;
        }

        public void UpdateUDPTime(string data)
        {
            UDPTotalTime.Text = data;
        }

        public void UpdateTCPTransmission(string data)
        {
            TCPTransSpeed.Text = data;
        }

        public void UpdateUDPTransmission(string data)
        {
            UDPTransSpeed.Text = data;
        }
        public void UpdateTCPLost(string data)
        {
            TCPLostData.Text = data;
        }

        public void UpdateUDPLost(string data)
        {
            UDPLostData.Text = data;
        }

        public void UpdateTCPError(string data)
        {
            TCPError.Text = data;
        }

        public void UpdateUDPError(string data)
        {
            UDPError.Text = data;
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();

        private void button1_Click(object sender, EventArgs e)
        {
            if (listening)
            {
                network.discoveryFlag = false;
                Listen.Text = "Start listening";
                listening = false;
                network.CancelCancellationToken();
            }
            else
            {
                network.discoveryFlag = true;
                network.NewCancellationToken();
                string port = Port.Value.ToString();
                //Task clientTask = HandleClient(client, cancellationToken).ContinueWith(value => client.Dispose());
                /*
                Parallel.Invoke(
                    async () => network.MulticastDiscovery(port),
                    async () => network.UnicastTCP(port),
                    async () => network.UnicastUDP(port)
                    );
                */
                discoveryTask = Task.Run(() => network.MulticastDiscovery(port));
                TCPTask = Task.Run(() => network.UnicastTCP(port));
                UDPTask = Task.Run(() => network.UnicastUDP(port));
                Listen.Text = "Stop listening";
                listening = true;
            }

        }
    }
    public class NetworkManagement
    {
        Form1 form;
        public bool discoveryFlag = true;
        public bool busy = false;
        int kbyte = 1024;
        int mbyte = 1048576;
        Stopwatch TCPclock;
        Stopwatch UDPclock;
        public static CancellationTokenSource cancellationToken = new CancellationTokenSource();
        public NetworkManagement(Form1 input)
        {
            form = input;
        }

        public void CancelCancellationToken()
        {
            cancellationToken.Cancel();
        }

        public void NewCancellationToken()
        {
            cancellationToken = new CancellationTokenSource();
        }

        public static IEnumerable<int> PatternAt(byte[] source, byte[] pattern)
        {
            for (int i = 0; i < source.Length; i++)
            {
                if (source.Skip(i).Take(pattern.Length).SequenceEqual(pattern))
                {
                    yield return i;
                }
            }
        }

        public async Task UnicastUDP(string port)
        {
            IPEndPoint localEndPoint = new IPEndPoint(IPAddress.Any, int.Parse(port));
            UdpClient server = new UdpClient();
            try
            {
                cancellationToken.Token.Register(server.Dispose);
                while (!cancellationToken.IsCancellationRequested)
                {
                    try
                    {
                        server = new UdpClient(localEndPoint);
                        IPEndPoint sender = new IPEndPoint(IPAddress.Any, 0);
                        int bytes = 0;
                        byte[] read = new byte[1024];
                        server.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveTimeout, 0);
                        read = server.Receive(ref sender);
                        server.Connect(sender);
                        server.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveTimeout, 5000);
                        string request = Encoding.ASCII.GetString(read);
                        string[] size = request.Split(':');
                        if (size[0].Equals("SIZE"))
                        {
                            Console.WriteLine("Connection from: " + sender.ToString());
                            //server.Connect(sender);
                            form.Invoke((MethodInvoker)delegate
                            {
                                form.UpdateUDPSingle(size[1]);
                            });
                            byte[] byteRead = new byte[int.Parse(size[1])];
                            byte[] comparison = new byte[int.Parse(size[1])];
                            bool compareFlag = false;
                            UDPclock = new Stopwatch();
                            double totalSent = 0;
                            double error = 0;
                            UDPclock.Start();
                            do
                            {
                                byteRead = server.Receive(ref sender);
                                if (Encoding.ASCII.GetString(byteRead).Equals("FINE"))
                                {
                                    Console.WriteLine(Encoding.ASCII.GetString(byteRead) + " in UDP");
                                    break;
                                }
                                if (compareFlag)
                                {
                                    if(byteRead.Length > 0)
                                    {
                                        if (!comparison.SequenceEqual(byteRead))
                                        {
                                            byte[] pattern = byteRead.Take(bytes/10).ToArray();
                                            int index = PatternAt(comparison, pattern).FirstOrDefault();
                                            error = index;
                                        }
                                        if (bytes < comparison.Length)
                                        {
                                            error += comparison.Length-bytes;
                                        }
                                    }
                                }
                                else
                                {
                                    comparison = byteRead.ToArray();
                                    compareFlag = true;
                                }
                                bytes = byteRead.Length;
                                totalSent += bytes;
                                form.Invoke((MethodInvoker)delegate
                                {
                                    form.UpdateUDPTotal(Math.Round((totalSent/kbyte), 3).ToString());
                                });
                                TimeSpan elapsed = UDPclock.Elapsed;
                                form.Invoke((MethodInvoker)delegate
                                {
                                    form.UpdateUDPTime(Math.Round(elapsed.TotalSeconds, 1).ToString());
                                });
                                form.Invoke((MethodInvoker)delegate
                                {
                                    form.UpdateUDPTransmission(Math.Round((totalSent/mbyte/elapsed.TotalSeconds), 3).ToString());
                                });
                                form.Invoke((MethodInvoker)delegate
                                {
                                    form.UpdateUDPLost(Math.Round(error, 1).ToString());
                                });
                                form.Invoke((MethodInvoker)delegate
                                {
                                    form.UpdateUDPError(Math.Round(error/totalSent*100, 1).ToString()+"%");
                                });
                                await Task.Delay(10);
                            } while (!cancellationToken.IsCancellationRequested && bytes > 0);
                        }
                        server.Dispose();
                    }
                    catch (SocketException e) when (cancellationToken.IsCancellationRequested)
                    {
                        if (e.SocketErrorCode == SocketError.Interrupted)
                        {
                            //Console.WriteLine("client interrupted");
                        }
                    }
                    catch (SocketException e)
                    {
                        if (e.SocketErrorCode == SocketError.TimedOut)
                        {
                            Console.WriteLine("timed out");
                        }
                        else
                        {
                            Console.WriteLine(e + e.Message);
                        }
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e + e.Message);
            }
        }
        public async Task UnicastTCP(string port)
        {
            IPEndPoint localEndPoint = new IPEndPoint(IPAddress.Any, int.Parse(port));
            TcpListener listener = new TcpListener(localEndPoint);
            listener.Start();
            cancellationToken.Token.Register(listener.Stop);
            while (!cancellationToken.IsCancellationRequested)
            {
                try
                {
                    TcpClient client = await listener.AcceptTcpClientAsync();
                    if (!busy)
                    {
                        Task clientTask = HandleClient(client, cancellationToken).ContinueWith(value => client.Dispose());
                    }
                    else
                    {
                        Task clientTask = HandleClientBusy(client, cancellationToken).ContinueWith(value => client.Dispose());
                    }
                }
                catch(SocketException e) when (cancellationToken.IsCancellationRequested)
                {
                    if(e.SocketErrorCode == SocketError.OperationAborted)
                        Console.WriteLine("Stopping TCP listener");
                }
                catch(Exception e)
                {
                    Console.WriteLine(e + " " + e.Message);
                }
            }
            listener.Stop();
        }

        public async Task HandleClient(TcpClient client, CancellationTokenSource cancellationToken)
        {
            busy = true;
            Console.WriteLine("Handling client: " + client.Client.RemoteEndPoint.ToString());
            try
            {
                NetworkStream networkStream = client.GetStream();
                cancellationToken.Token.Register(client.Close);
                string accepted = "ACCEPTED";
                byte[] acceptedByte = Encoding.ASCII.GetBytes(accepted);
                networkStream.Write(acceptedByte, 0, acceptedByte.Length);
                int bytes = 0;
                byte[] read = new byte[1024];
                networkStream.Read(read, 0, read.Length);
                string request = Encoding.ASCII.GetString(read);
                string[] size = request.Split(':');
                if (size[0].Equals("SIZE"))
                {
                    form.Invoke((MethodInvoker)delegate
                    {
                        form.UpdateTCPSingle(size[1]);
                    });
                    byte[] byteRead = new byte[int.Parse(size[1])];
                    byte[] comparison = new byte[int.Parse(size[1])];
                    bool compareFlag = false;
                    TCPclock = new Stopwatch();
                    double totalSent = 0;
                    double error = 0;
                    TCPclock.Start();
                    do
                    {
                        bytes = networkStream.Read(byteRead, 0, byteRead.Length);
                        if (Encoding.ASCII.GetString(byteRead, 0, bytes).Equals("FINE"))
                        {
                            Console.WriteLine(Encoding.ASCII.GetString(byteRead, 0, bytes) + " in TCP");
                            break;
                        }
                        if (compareFlag)
                        {
                            //check if they are sent in separate smaller packages?
                            if (!comparison.SequenceEqual(byteRead))
                            {
                                byte[] pattern = byteRead.Take(bytes/10).ToArray();
                                int index = PatternAt(comparison, pattern).FirstOrDefault();
                                error = index;
                            }
                            if(bytes < comparison.Length)
                            {
                                error += comparison.Length-bytes;
                            }
                        }
                        else
                        {
                            comparison = byteRead.ToArray();
                            compareFlag = true;
                        }
                        totalSent += bytes;
                        form.Invoke((MethodInvoker)delegate
                        {
                            form.UpdateTCPTotal(Math.Round((totalSent/kbyte), 3).ToString());
                        });
                        TimeSpan elapsed = TCPclock.Elapsed;
                        form.Invoke((MethodInvoker)delegate
                        {
                            form.UpdateTCPTime(Math.Round(elapsed.TotalSeconds, 1).ToString());
                        });
                        form.Invoke((MethodInvoker)delegate
                        {
                            form.UpdateTCPTransmission(Math.Round(totalSent/mbyte/elapsed.TotalSeconds, 3).ToString());
                        });
                        form.Invoke((MethodInvoker)delegate
                        {
                            form.UpdateTCPLost(Math.Round(error, 1).ToString());
                        });
                        form.Invoke((MethodInvoker)delegate
                        {
                            form.UpdateTCPError(Math.Round(error/totalSent*100, 1).ToString()+"%");
                        });
                        await Task.Delay(10);
                        networkStream.Flush();
                        Array.Clear(byteRead, 0, byteRead.Length);
                    } while (!cancellationToken.IsCancellationRequested && bytes > 0);
                    TCPclock.Stop();
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e + " " + e.Message);
                busy = false;
            }
            busy = false;
        }

        public async Task HandleClientBusy(TcpClient client, CancellationTokenSource cancellationToken)
        {
            try
            {
                NetworkStream networkStream = client.GetStream();
                StreamReader reader = new StreamReader(networkStream);
                StreamWriter writer = new StreamWriter(networkStream);
                writer.AutoFlush = true;
                char[] read = new char[1024];
                int bytes = reader.Read(read, 0, read.Length);
                string request = new string(read, 0, bytes);
                string busy = "BUSY";
                byte[] busyBytes = Encoding.ASCII.GetBytes(busy);
                char[] busyChars = Encoding.ASCII.GetChars(busyBytes);
                writer.Write(busyChars, 0, busyChars.Length);
                await Task.Delay(10);
                client.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e + " " + e.Message);
            }

        }

        //flag
        public async Task MulticastDiscovery(string port)
        {
            while(discoveryFlag)
            {
                UdpClient discoveryServer = new();
                try
                {
                    Console.WriteLine("Discovering..");
                    int localPort = 7778;
                    IPAddress multicastAddress = IPAddress.Parse("239.0.0.222");
                    discoveryServer.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveTimeout, 5000);
                    discoveryServer.ExclusiveAddressUse = false;
                    IPEndPoint localEnd = new IPEndPoint(IPAddress.Any, localPort);
                    discoveryServer.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
                    discoveryServer.ExclusiveAddressUse = false;

                    discoveryServer.Client.Bind(localEnd);
                    discoveryServer.JoinMulticastGroup(multicastAddress);
                    cancellationToken.Token.Register(discoveryServer.Close);
                    Byte[] responseData = Encoding.ASCII.GetBytes("OFFER:"+port);
                    while (!cancellationToken.IsCancellationRequested)
                    {
                        //IPEndPoint clientEnd = new IPEndPoint(IPAddress.Any, 0);
                        Byte[] clientRequestData = discoveryServer.Receive(ref localEnd);
                        Console.WriteLine(Encoding.ASCII.GetString(clientRequestData));
                        Console.WriteLine(Encoding.ASCII.GetString(clientRequestData) + " from " + localEnd.ToString());
                        if (Encoding.ASCII.GetString(clientRequestData).Equals("DISCOVERY"))
                        {
                            discoveryServer.Send(responseData, responseData.Length, localEnd);
                        }
                        await Task.Delay(10);
                    }
                    discoveryServer.Close();
                }
                catch (SocketException e) when (cancellationToken.IsCancellationRequested)
                {
                    if (e.SocketErrorCode == SocketError.Interrupted)
                    {
                        //Console.WriteLine("client interrupted");
                    }
                }
                catch (SocketException e)
                {
                    if (e.SocketErrorCode == SocketError.TimedOut)
                    {
                        discoveryServer.Close();
                    }
                    else
                    {
                        Console.WriteLine(e + " " + e.Message);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e + " " + e.Message);
                }
            }
        }
    }
}
