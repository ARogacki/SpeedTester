
namespace Ex1Server
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
            this.Listen = new System.Windows.Forms.Button();
            this.Port = new System.Windows.Forms.NumericUpDown();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.UDPError = new System.Windows.Forms.TextBox();
            this.UDPLostData = new System.Windows.Forms.TextBox();
            this.UDPTransSpeed = new System.Windows.Forms.TextBox();
            this.UDPTotalTime = new System.Windows.Forms.TextBox();
            this.UDPTotalSize = new System.Windows.Forms.TextBox();
            this.UDPSingle = new System.Windows.Forms.TextBox();
            this.TCPError = new System.Windows.Forms.TextBox();
            this.TCPLostData = new System.Windows.Forms.TextBox();
            this.TCPTransSpeed = new System.Windows.Forms.TextBox();
            this.TCPTotalTime = new System.Windows.Forms.TextBox();
            this.TCPTotalSize = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TCPSingle = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.Port)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Listen
            // 
            this.Listen.Location = new System.Drawing.Point(242, 21);
            this.Listen.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Listen.Name = "Listen";
            this.Listen.Size = new System.Drawing.Size(218, 49);
            this.Listen.TabIndex = 0;
            this.Listen.Text = "Start listening";
            this.Listen.UseVisualStyleBackColor = true;
            this.Listen.Click += new System.EventHandler(this.button1_Click);
            // 
            // Port
            // 
            this.Port.Location = new System.Drawing.Point(46, 36);
            this.Port.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Port.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.Port.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.Port.Name = "Port";
            this.Port.Size = new System.Drawing.Size(131, 23);
            this.Port.TabIndex = 1;
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
            this.panel1.Controls.Add(this.Listen);
            this.panel1.Controls.Add(this.Port);
            this.panel1.Location = new System.Drawing.Point(-3, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(705, 94);
            this.panel1.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.UDPError);
            this.groupBox1.Controls.Add(this.UDPLostData);
            this.groupBox1.Controls.Add(this.UDPTransSpeed);
            this.groupBox1.Controls.Add(this.UDPTotalTime);
            this.groupBox1.Controls.Add(this.UDPTotalSize);
            this.groupBox1.Controls.Add(this.UDPSingle);
            this.groupBox1.Controls.Add(this.TCPError);
            this.groupBox1.Controls.Add(this.TCPLostData);
            this.groupBox1.Controls.Add(this.TCPTransSpeed);
            this.groupBox1.Controls.Add(this.TCPTotalTime);
            this.groupBox1.Controls.Add(this.TCPTotalSize);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.TCPSingle);
            this.groupBox1.Location = new System.Drawing.Point(10, 98);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(679, 230);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Transmission";
            // 
            // UDPError
            // 
            this.UDPError.Location = new System.Drawing.Point(494, 157);
            this.UDPError.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.UDPError.Name = "UDPError";
            this.UDPError.ReadOnly = true;
            this.UDPError.Size = new System.Drawing.Size(110, 23);
            this.UDPError.TabIndex = 22;
            // 
            // UDPLostData
            // 
            this.UDPLostData.Location = new System.Drawing.Point(494, 134);
            this.UDPLostData.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.UDPLostData.Name = "UDPLostData";
            this.UDPLostData.ReadOnly = true;
            this.UDPLostData.Size = new System.Drawing.Size(110, 23);
            this.UDPLostData.TabIndex = 21;
            // 
            // UDPTransSpeed
            // 
            this.UDPTransSpeed.Location = new System.Drawing.Point(494, 112);
            this.UDPTransSpeed.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.UDPTransSpeed.Name = "UDPTransSpeed";
            this.UDPTransSpeed.ReadOnly = true;
            this.UDPTransSpeed.Size = new System.Drawing.Size(110, 23);
            this.UDPTransSpeed.TabIndex = 20;
            // 
            // UDPTotalTime
            // 
            this.UDPTotalTime.Location = new System.Drawing.Point(494, 88);
            this.UDPTotalTime.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.UDPTotalTime.Name = "UDPTotalTime";
            this.UDPTotalTime.ReadOnly = true;
            this.UDPTotalTime.Size = new System.Drawing.Size(110, 23);
            this.UDPTotalTime.TabIndex = 18;
            // 
            // UDPTotalSize
            // 
            this.UDPTotalSize.Location = new System.Drawing.Point(494, 65);
            this.UDPTotalSize.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.UDPTotalSize.Name = "UDPTotalSize";
            this.UDPTotalSize.ReadOnly = true;
            this.UDPTotalSize.Size = new System.Drawing.Size(110, 23);
            this.UDPTotalSize.TabIndex = 17;
            // 
            // UDPSingle
            // 
            this.UDPSingle.Location = new System.Drawing.Point(494, 43);
            this.UDPSingle.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.UDPSingle.Name = "UDPSingle";
            this.UDPSingle.ReadOnly = true;
            this.UDPSingle.Size = new System.Drawing.Size(110, 23);
            this.UDPSingle.TabIndex = 16;
            // 
            // TCPError
            // 
            this.TCPError.Location = new System.Drawing.Point(329, 157);
            this.TCPError.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TCPError.Name = "TCPError";
            this.TCPError.ReadOnly = true;
            this.TCPError.Size = new System.Drawing.Size(110, 23);
            this.TCPError.TabIndex = 15;
            // 
            // TCPLostData
            // 
            this.TCPLostData.Location = new System.Drawing.Point(329, 134);
            this.TCPLostData.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TCPLostData.Name = "TCPLostData";
            this.TCPLostData.ReadOnly = true;
            this.TCPLostData.Size = new System.Drawing.Size(110, 23);
            this.TCPLostData.TabIndex = 14;
            // 
            // TCPTransSpeed
            // 
            this.TCPTransSpeed.Location = new System.Drawing.Point(329, 112);
            this.TCPTransSpeed.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TCPTransSpeed.Name = "TCPTransSpeed";
            this.TCPTransSpeed.ReadOnly = true;
            this.TCPTransSpeed.Size = new System.Drawing.Size(110, 23);
            this.TCPTransSpeed.TabIndex = 13;
            // 
            // TCPTotalTime
            // 
            this.TCPTotalTime.Location = new System.Drawing.Point(329, 88);
            this.TCPTotalTime.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TCPTotalTime.Name = "TCPTotalTime";
            this.TCPTotalTime.ReadOnly = true;
            this.TCPTotalTime.Size = new System.Drawing.Size(110, 23);
            this.TCPTotalTime.TabIndex = 11;
            // 
            // TCPTotalSize
            // 
            this.TCPTotalSize.Location = new System.Drawing.Point(329, 65);
            this.TCPTotalSize.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TCPTotalSize.Name = "TCPTotalSize";
            this.TCPTotalSize.ReadOnly = true;
            this.TCPTotalSize.Size = new System.Drawing.Size(110, 23);
            this.TCPTotalSize.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(66, 159);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(124, 15);
            this.label7.TabIndex = 9;
            this.label7.Text = "Transmission error [%]";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(66, 137);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(94, 15);
            this.label8.TabIndex = 8;
            this.label8.Text = "Lost data [bytes]";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label9.Location = new System.Drawing.Point(66, 114);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(176, 15);
            this.label9.TabIndex = 7;
            this.label9.Text = "Transmission speed [kbytes/sec]";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(66, 90);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(157, 15);
            this.label5.TabIndex = 5;
            this.label5.Text = "Total transmission time [sec]";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(66, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(199, 15);
            this.label4.TabIndex = 4;
            this.label4.Text = "Total size of transferred data [kbytes]";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(66, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "Single data size [bytes]";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(522, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "UDP";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(361, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "TCP";
            // 
            // TCPSingle
            // 
            this.TCPSingle.Location = new System.Drawing.Point(329, 43);
            this.TCPSingle.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TCPSingle.Name = "TCPSingle";
            this.TCPSingle.ReadOnly = true;
            this.TCPSingle.Size = new System.Drawing.Size(110, 23);
            this.TCPSingle.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(700, 338);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.Port)).EndInit();
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Listen;
        private System.Windows.Forms.NumericUpDown Port;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TCPSingle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox UDPError;
        private System.Windows.Forms.TextBox UDPLostData;
        private System.Windows.Forms.TextBox UDPTransSpeed;
        private System.Windows.Forms.TextBox UDPTotalTime;
        private System.Windows.Forms.TextBox UDPTotalSize;
        private System.Windows.Forms.TextBox UDPSingle;
        private System.Windows.Forms.TextBox TCPError;
        private System.Windows.Forms.TextBox TCPLostData;
        private System.Windows.Forms.TextBox TCPTransSpeed;
        private System.Windows.Forms.TextBox TCPTotalTime;
        private System.Windows.Forms.TextBox TCPTotalSize;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
    }
}

