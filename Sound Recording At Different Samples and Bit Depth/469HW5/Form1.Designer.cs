namespace _469HW5
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.stopButton = new System.Windows.Forms.Button();
            this.PlayButton = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.PlaceHolderImage = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.PreviousWindowButton = new System.Windows.Forms.Button();
            this.NextWindowButton = new System.Windows.Forms.Button();
            this.waveRender = new NAudio.Gui.WaveViewer();
            this.SelectedWindowLable = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.trackBar2 = new System.Windows.Forms.TrackBar();
            this.WindowsCountLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.FixAudioButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PlaceHolderImage)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Enabled = false;
            this.button1.ForeColor = System.Drawing.Color.Green;
            this.button1.Location = new System.Drawing.Point(3, 43);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(181, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Start Recording";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Enabled = false;
            this.button2.ForeColor = System.Drawing.Color.Red;
            this.button2.Location = new System.Drawing.Point(190, 43);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(189, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Stop Recording";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.Location = new System.Drawing.Point(3, 12);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(770, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "Create/Load File";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel1.Controls.Add(this.stopButton);
            this.panel1.Controls.Add(this.PlayButton);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(776, 72);
            this.panel1.TabIndex = 3;
            // 
            // stopButton
            // 
            this.stopButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.stopButton.Enabled = false;
            this.stopButton.ForeColor = System.Drawing.Color.Black;
            this.stopButton.Location = new System.Drawing.Point(583, 43);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(190, 23);
            this.stopButton.TabIndex = 4;
            this.stopButton.Text = "Stop";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.button4_Click);
            // 
            // PlayButton
            // 
            this.PlayButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PlayButton.Enabled = false;
            this.PlayButton.ForeColor = System.Drawing.Color.Black;
            this.PlayButton.Location = new System.Drawing.Point(385, 43);
            this.PlayButton.Name = "PlayButton";
            this.PlayButton.Size = new System.Drawing.Size(192, 23);
            this.PlayButton.TabIndex = 3;
            this.PlayButton.Text = "Play";
            this.PlayButton.UseVisualStyleBackColor = true;
            this.PlayButton.Click += new System.EventHandler(this.PlayButton_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel3.Controls.Add(this.PlaceHolderImage);
            this.panel3.Controls.Add(this.groupBox2);
            this.panel3.Controls.Add(this.PreviousWindowButton);
            this.panel3.Controls.Add(this.NextWindowButton);
            this.panel3.Controls.Add(this.waveRender);
            this.panel3.Controls.Add(this.SelectedWindowLable);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.trackBar2);
            this.panel3.Controls.Add(this.WindowsCountLabel);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.FixAudioButton);
            this.panel3.Location = new System.Drawing.Point(12, 90);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(776, 260);
            this.panel3.TabIndex = 5;
            // 
            // PlaceHolderImage
            // 
            this.PlaceHolderImage.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("PlaceHolderImage.BackgroundImage")));
            this.PlaceHolderImage.InitialImage = ((System.Drawing.Image)(resources.GetObject("PlaceHolderImage.InitialImage")));
            this.PlaceHolderImage.Location = new System.Drawing.Point(8, 110);
            this.PlaceHolderImage.Name = "PlaceHolderImage";
            this.PlaceHolderImage.Size = new System.Drawing.Size(229, 143);
            this.PlaceHolderImage.TabIndex = 20;
            this.PlaceHolderImage.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button4);
            this.groupBox2.Controls.Add(this.button9);
            this.groupBox2.Controls.Add(this.button8);
            this.groupBox2.Controls.Add(this.button10);
            this.groupBox2.Location = new System.Drawing.Point(243, 139);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(529, 118);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Transforms";
            // 
            // button4
            // 
            this.button4.Enabled = false;
            this.button4.Location = new System.Drawing.Point(5, 16);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(518, 23);
            this.button4.TabIndex = 19;
            this.button4.Text = "Raw";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click_1);
            // 
            // button9
            // 
            this.button9.Enabled = false;
            this.button9.Location = new System.Drawing.Point(5, 91);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(518, 23);
            this.button9.TabIndex = 18;
            this.button9.Text = "Fourier ";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button8
            // 
            this.button8.Enabled = false;
            this.button8.Location = new System.Drawing.Point(5, 66);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(518, 23);
            this.button8.TabIndex = 17;
            this.button8.Text = "Hamming";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button10
            // 
            this.button10.Enabled = false;
            this.button10.Location = new System.Drawing.Point(5, 41);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(518, 23);
            this.button10.TabIndex = 16;
            this.button10.Text = "Denoise";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // PreviousWindowButton
            // 
            this.PreviousWindowButton.Enabled = false;
            this.PreviousWindowButton.Location = new System.Drawing.Point(243, 110);
            this.PreviousWindowButton.Name = "PreviousWindowButton";
            this.PreviousWindowButton.Size = new System.Drawing.Size(257, 23);
            this.PreviousWindowButton.TabIndex = 13;
            this.PreviousWindowButton.Text = "Previous Window";
            this.PreviousWindowButton.UseVisualStyleBackColor = true;
            this.PreviousWindowButton.Click += new System.EventHandler(this.PreviousWindowButton_Click);
            // 
            // NextWindowButton
            // 
            this.NextWindowButton.Enabled = false;
            this.NextWindowButton.Location = new System.Drawing.Point(506, 110);
            this.NextWindowButton.Name = "NextWindowButton";
            this.NextWindowButton.Size = new System.Drawing.Size(257, 23);
            this.NextWindowButton.TabIndex = 12;
            this.NextWindowButton.Text = "Next Window";
            this.NextWindowButton.UseVisualStyleBackColor = true;
            this.NextWindowButton.Click += new System.EventHandler(this.button5_Click);
            // 
            // waveRender
            // 
            this.waveRender.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.waveRender.Location = new System.Drawing.Point(14, 118);
            this.waveRender.Name = "waveRender";
            this.waveRender.SamplesPerPixel = 2;
            this.waveRender.Size = new System.Drawing.Size(231, 125);
            this.waveRender.StartPosition = ((long)(0));
            this.waveRender.TabIndex = 6;
            this.waveRender.WaveStream = null;
            this.waveRender.Scroll += new System.Windows.Forms.ScrollEventHandler(this.waveRender_Scroll);
            // 
            // SelectedWindowLable
            // 
            this.SelectedWindowLable.AutoSize = true;
            this.SelectedWindowLable.Location = new System.Drawing.Point(447, 52);
            this.SelectedWindowLable.Name = "SelectedWindowLable";
            this.SelectedWindowLable.Size = new System.Drawing.Size(27, 13);
            this.SelectedWindowLable.TabIndex = 11;
            this.SelectedWindowLable.Text = "N/A";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(350, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Selected Window";
            // 
            // trackBar2
            // 
            this.trackBar2.Enabled = false;
            this.trackBar2.Location = new System.Drawing.Point(0, 67);
            this.trackBar2.Name = "trackBar2";
            this.trackBar2.Size = new System.Drawing.Size(767, 45);
            this.trackBar2.TabIndex = 7;
            this.trackBar2.Scroll += new System.EventHandler(this.trackBar2_Scroll);
            // 
            // WindowsCountLabel
            // 
            this.WindowsCountLabel.AutoSize = true;
            this.WindowsCountLabel.Location = new System.Drawing.Point(103, 51);
            this.WindowsCountLabel.Name = "WindowsCountLabel";
            this.WindowsCountLabel.Size = new System.Drawing.Size(27, 13);
            this.WindowsCountLabel.TabIndex = 9;
            this.WindowsCountLabel.Text = "N/A";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Avaliable Windows:";
            // 
            // FixAudioButton
            // 
            this.FixAudioButton.Enabled = false;
            this.FixAudioButton.Location = new System.Drawing.Point(3, 15);
            this.FixAudioButton.Name = "FixAudioButton";
            this.FixAudioButton.Size = new System.Drawing.Size(769, 23);
            this.FixAudioButton.TabIndex = 7;
            this.FixAudioButton.Text = "Compute Spectrum";
            this.FixAudioButton.UseVisualStyleBackColor = true;
            this.FixAudioButton.Click += new System.EventHandler(this.FixAudioButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 355);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Sound Record Hamming Window Display";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PlaceHolderImage)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button PlayButton;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button FixAudioButton;
        private System.Windows.Forms.Label WindowsCountLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label SelectedWindowLable;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TrackBar trackBar2;
        private NAudio.Gui.WaveViewer waveRender;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button PreviousWindowButton;
        private System.Windows.Forms.Button NextWindowButton;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.PictureBox PlaceHolderImage;
    }
}

