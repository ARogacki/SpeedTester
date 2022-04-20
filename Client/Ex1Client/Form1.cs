using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ex1Client
{
    public partial class Form1 : Form
    {
        Random rnd = new Random();
        NetworkManagement network;
        bool transmissionFlag = true;

        public Form1()
        {
            network = new NetworkManagement(this);
            AllocConsole();
            InitializeComponent();
            TCPEstablished(false);
            UDPEstablished(false);
        }

        public void TCPEstablished(bool success)
        {
            if (success)
            {
                TCPThread.ForeColor = Color.Green;
            }
            else
            {
                TCPThread.ForeColor = Color.Red;
            }
        }

        public void UDPEstablished(bool success)
        {
            if (success)
            {
                UDPThread.ForeColor = Color.Green;
            }
            else
            {
                UDPThread.ForeColor = Color.Red;
            }
        }

        public void AddAddress(string address)
        {
            AddressList.Items.Add(address);
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();
        private void button1_Click(object sender, EventArgs e)
        {
            AddressList.Items.Clear();
            Thread discoveryThread = new Thread(new ThreadStart(network.MulticastDiscovery));
            discoveryThread.Start();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click_1(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void AddToList_Click(object sender, EventArgs e)
        {
            try
            {
                IPAddress tempIP;
                bool validate = IPAddress.TryParse(Address.Text, out tempIP);
                if (validate)
                    AddAddress(Address.Text + ":" + Port.Value.ToString());
                else
                    Console.WriteLine("Not a proper IP address.");
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        private void Send_Click(object sender, EventArgs e)
        {
            try
            {
                if (transmissionFlag)
                {
                    if (AddressList.Text.Length > 0)
                    {
                        int amount = Slider.Value;
                        byte[] buffer = new byte[amount];
                        rnd.NextBytes(buffer);
                        Console.WriteLine(AddressList.Text);
                        IPEndPoint address = IPEndPoint.Parse(AddressList.Text);
                        if(address.Port == network.discoveryPort)
                        {
                            Console.WriteLine("Cannot use port that's used for discovery.");
                        }
                        else
                        {
                            network.TCPFlag = true;
                            network.UDPFlag = true;
                            Thread TCPThread = new Thread(() => network.UnicastTCP(address, buffer, NagleAlgorithm.Checked));
                            Thread UDPThread = new Thread(() => network.UnicastUDP(address, buffer));
                            TCPThread.Start();
                            UDPThread.Start();
                            Send.Text = "Stop Bytes";
                            transmissionFlag = false;
                        }
                    }
                }
                else
                {
                    network.TCPFlag = false;
                    network.UDPFlag = false;
                    Send.Text = "Send Bytes";
                    transmissionFlag = true;
                }
            }
            catch(Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            SliderValue.Text = Slider.Value.ToString() + " bytes";
        }
    }
    public class NetworkManagement
    {
        Form1 form;
        public bool TCPFlag = true;
        public bool UDPFlag = true;
        public int discoveryPort = 7778;
        public NetworkManagement(Form1 input)
        {
            form = input;
        }

        //check if busy
        public void UnicastTCP(IPEndPoint server, byte[] buffer, bool nagleAlgorithm)
        {
            IPEndPoint localEndPoint = new IPEndPoint(IPAddress.Any, server.Port);
            TcpClient client = new TcpClient();
            try
            {
                if (nagleAlgorithm)
                {
                    client.NoDelay = true;
                }
                else
                {
                    client.NoDelay = false;
                }
                client.Connect(server);
                /*
                if (!client.ConnectAsync(server.Address, server.Port).Wait(1000))
                {
                    Console.WriteLine("Failed to connect");
                }
                */
                byte[] read = new Byte[1024];
                NetworkStream stream = client.GetStream();
                byte[] size = Encoding.ASCII.GetBytes("SIZE:" + buffer.Length);
                stream.Write(size, 0, size.Length);
                int bytes = stream.Read(read, 0, read.Length);
                Console.WriteLine("Message: " + Encoding.ASCII.GetString(read, 0, bytes));
                if (!Encoding.ASCII.GetString(read).Equals("BUSY"))
                {
                    form.Invoke((MethodInvoker)delegate
                    {
                        form.TCPEstablished(true);
                    });
                    while (TCPFlag)
                    {
                        //Console.WriteLine(buffer.Length);
                        stream.Write(buffer, 0, buffer.Length);
                        //Console.WriteLine(length);
                        Thread.Sleep(10);
                    }
                    byte[] fineMessage = Encoding.ASCII.GetBytes("FINE");
                    stream.Write(fineMessage, 0, fineMessage.Length);
                }
                client.Close();
            }
            catch(Exception e)
            {
                client.Close();
                Console.WriteLine(e.Message);
            }
            form.Invoke((MethodInvoker)delegate
            {
                form.TCPEstablished(false);
            });
        }

        public void UnicastUDP(IPEndPoint server, byte[] buffer)
        {
            UdpClient client = new UdpClient();
            try
            {
                client.Connect(server);
                //client.Client.Bind(server);
                Byte[] size = Encoding.ASCII.GetBytes("SIZE:" + buffer.Length);
                client.Send(size, size.Length);
                form.Invoke((MethodInvoker)delegate
                {
                    form.UDPEstablished(true);
                });
                while (UDPFlag)
                {
                    client.Send(buffer, buffer.Length);
                    Thread.Sleep(10);
                }
                Byte[] fineMessage = Encoding.ASCII.GetBytes("FINE");
                client.Send(fineMessage, fineMessage.Length);
                client.Close();
            }
            catch (Exception e)
            {
                client.Close();
                Console.WriteLine(e.Message);
            }
            form.Invoke((MethodInvoker)delegate
            {
                form.UDPEstablished(false);
            });
        }

        public void MulticastDiscovery()
        {
            UdpClient client = new UdpClient();
            try
            {
                int localPort = discoveryPort;
                byte[] requestData = Encoding.ASCII.GetBytes("DISCOVERY");
                IPAddress multicastAddress = IPAddress.Parse("239.0.0.222");
                client.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveTimeout, 1000);
                IPEndPoint serverEnd = new IPEndPoint(multicastAddress, localPort);
                client.JoinMulticastGroup(multicastAddress);
                client.Send(requestData, requestData.Length, serverEnd);
                Thread.Sleep(10);
                do
                {
                    byte[] recBuffer = client.Receive(ref serverEnd);
                    string request = Encoding.ASCII.GetString(recBuffer);
                    string[] offer = request.Split(':');
                    if (offer[0].Equals("OFFER"))
                    {
                        form.Invoke((MethodInvoker)delegate
                        {
                            form.AddAddress(serverEnd.Address.ToString() + ":" + offer[1]);
                        });
                    }
                }
                while (true);
            }
            catch (SocketException e)
            {
                if (e.SocketErrorCode == SocketError.TimedOut)
                    client.Close();
                else
                {
                    Console.WriteLine(e + e.Message);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e + e.Message);
            }
        }
    }
}
