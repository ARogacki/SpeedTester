
namespace Ex1Client
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Discovery = new System.Windows.Forms.Button();
            this.AddressList = new System.Windows.Forms.ComboBox();
            this.Address = new System.Windows.Forms.TextBox();
            this.AddToList = new System.Windows.Forms.Button();
            this.Port = new System.Windows.Forms.NumericUpDown();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.NagleAlgorithm = new System.Windows.Forms.CheckBox();
            this.Slider = new System.Windows.Forms.TrackBar();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Send = new System.Windows.Forms.Button();
            this.SliderValue = new System.Windows.Forms.Label();
            this.TCPThread = new System.Windows.Forms.Label();
            this.UDPThread = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Port)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Slider)).BeginInit();
            this.SuspendLayout();
            // 
            // Discovery
            // 
            this.Discovery.Location = new System.Drawing.Point(629, 34);
            this.Discovery.Name = "Discovery";
            this.Discovery.Size = new System.Drawing.Size(118, 57);
            this.Discovery.TabIndex = 0;
            this.Discovery.Text = "Discover";
            this.Discovery.UseVisualStyleBackColor = true;
            this.Discovery.Click += new System.EventHandler(this.button1_Click);
            // 
            // AddressList
            // 
            this.AddressList.FormattingEnabled = true;
            this.AddressList.Location = new System.Drawing.Point(411, 37);
            this.AddressList.Name = "AddressList";
            this.AddressList.Size = new System.Drawing.Size(212, 23);
            this.AddressList.TabIndex = 1;
            this.AddressList.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // Address
            // 
            this.Address.Location = new System.Drawing.Point(12, 34);
            this.Address.Name = "Address";
            this.Address.PlaceholderText = "Address";
            this.Address.Size = new System.Drawing.Size(212, 23);
            this.Address.TabIndex = 2;
            this.Address.Text = "127.0.0.1";
            // 
            // AddToList
            // 
            this.AddToList.Location = new System.Drawing.Point(230, 34);
            this.AddToList.Name = "AddToList";
            this.AddToList.Size = new System.Drawing.Size(118, 57);
            this.AddToList.TabIndex = 3;
            this.AddToList.Text = "Add to list";
            this.AddToList.UseVisualStyleBackColor = true;
            this.AddToList.Click += new System.EventHandler(this.AddToList_Click);
            // 
            // Port
            // 
            this.Port.Location = new System.Drawing.Point(104, 68);
            this.Port.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.Port.Name = "Port";
            this.Port.Size = new System.Drawing.Size(120, 23);
            this.Port.TabIndex = 4;
            this.Port.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Port.Value = new decimal(new int[] {
            7777,
            0,
            0,
            0});
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.NagleAlgorithm);
            this.panel1.Controls.Add(this.Port);
            this.panel1.Controls.Add(this.Address);
            this.panel1.Controls.Add(this.AddressList);
            this.panel1.Controls.Add(this.Discovery);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(812, 225);
            this.panel1.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(411, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 25);
            this.label2.TabIndex = 503;
            this.label2.Text = "Address list";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 25);
            this.label1.TabIndex = 502;
            this.label1.Text = "Input address";
            // 
            // NagleAlgorithm
            // 
            this.NagleAlgorithm.AutoSize = true;
            this.NagleAlgorithm.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.NagleAlgorithm.Location = new System.Drawing.Point(298, 140);
            this.NagleAlgorithm.Name = "NagleAlgorithm";
            this.NagleAlgorithm.Size = new System.Drawing.Size(178, 29);
            this.NagleAlgorithm.TabIndex = 501;
            this.NagleAlgorithm.Text = "Nagle Algorithm";
            this.NagleAlgorithm.UseVisualStyleBackColor = true;
            this.NagleAlgorithm.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // Slider
            // 
            this.Slider.LargeChange = 100;
            this.Slider.Location = new System.Drawing.Point(12, 275);
            this.Slider.Maximum = 65000;
            this.Slider.Minimum = 100;
            this.Slider.Name = "Slider";
            this.Slider.Size = new System.Drawing.Size(387, 45);
            this.Slider.SmallChange = 100;
            this.Slider.TabIndex = 500;
            this.Slider.TickFrequency = 10000;
            this.Slider.Value = 100;
            this.Slider.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(12, 238);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 25);
            this.label3.TabIndex = 504;
            this.label3.Text = "Bytes to send";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(448, 238);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 25);
            this.label4.TabIndex = 505;
            this.label4.Text = "Output";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // Send
            // 
            this.Send.Location = new System.Drawing.Point(12, 326);
            this.Send.Name = "Send";
            this.Send.Size = new System.Drawing.Size(118, 57);
            this.Send.TabIndex = 506;
            this.Send.Text = "Send Bytes";
            this.Send.UseVisualStyleBackColor = true;
            this.Send.Click += new System.EventHandler(this.Send_Click);
            // 
            // SliderValue
            // 
            this.SliderValue.AutoSize = true;
            this.SliderValue.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.SliderValue.Location = new System.Drawing.Point(345, 243);
            this.SliderValue.Name = "SliderValue";
            this.SliderValue.Size = new System.Drawing.Size(70, 19);
            this.SliderValue.TabIndex = 507;
            this.SliderValue.Text = "100 bytes";
            this.SliderValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.SliderValue.Click += new System.EventHandler(this.label5_Click);
            // 
            // TCPThread
            // 
            this.TCPThread.AutoSize = true;
            this.TCPThread.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.TCPThread.Location = new System.Drawing.Point(565, 305);
            this.TCPThread.Name = "TCPThread";
            this.TCPThread.Size = new System.Drawing.Size(109, 25);
            this.TCPThread.TabIndex = 508;
            this.TCPThread.Text = "TCP thread";
            this.TCPThread.Click += new System.EventHandler(this.label5_Click_1);
            // 
            // UDPThread
            // 
            this.UDPThread.AutoSize = true;
            this.UDPThread.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.UDPThread.Location = new System.Drawing.Point(565, 383);
            this.UDPThread.Name = "UDPThread";
            this.UDPThread.Size = new System.Drawing.Size(115, 25);
            this.UDPThread.TabIndex = 509;
            this.UDPThread.Text = "UDP thread";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(811, 502);
            this.Controls.Add(this.UDPThread);
            this.Controls.Add(this.TCPThread);
            this.Controls.Add(this.SliderValue);
            this.Controls.Add(this.Send);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.AddToList);
            this.Controls.Add(this.Slider);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Port)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Slider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Discovery;
        private System.Windows.Forms.ComboBox AddressList;
        private System.Windows.Forms.TextBox Address;
        private System.Windows.Forms.Button AddToList;
        private System.Windows.Forms.NumericUpDown Port;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TrackBar Slider;
        private System.Windows.Forms.CheckBox NagleAlgorithm;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button Send;
        private System.Windows.Forms.Label SliderValue;
        private System.Windows.Forms.Label TCPThread;
        private System.Windows.Forms.Label UDPThread;
    }
}

