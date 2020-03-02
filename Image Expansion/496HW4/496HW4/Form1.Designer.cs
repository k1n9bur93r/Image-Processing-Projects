namespace _496HW4
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
            this.Button_Panel = new System.Windows.Forms.Panel();
            this.ExpadImage = new System.Windows.Forms.Button();
            this.ImportButton = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.ImageHolder = new System.Windows.Forms.PictureBox();
            this.Expandby4 = new System.Windows.Forms.Button();
            this.Button_Panel.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImageHolder)).BeginInit();
            this.SuspendLayout();
            // 
            // Button_Panel
            // 
            this.Button_Panel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_Panel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.Button_Panel.Controls.Add(this.Expandby4);
            this.Button_Panel.Controls.Add(this.ExpadImage);
            this.Button_Panel.Controls.Add(this.ImportButton);
            this.Button_Panel.Location = new System.Drawing.Point(1, 0);
            this.Button_Panel.Name = "Button_Panel";
            this.Button_Panel.Size = new System.Drawing.Size(800, 87);
            this.Button_Panel.TabIndex = 0;
            // 
            // ExpadImage
            // 
            this.ExpadImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ExpadImage.Location = new System.Drawing.Point(3, 7);
            this.ExpadImage.Name = "ExpadImage";
            this.ExpadImage.Size = new System.Drawing.Size(794, 23);
            this.ExpadImage.TabIndex = 1;
            this.ExpadImage.Text = "Expand x 2";
            this.ExpadImage.UseVisualStyleBackColor = true;
            this.ExpadImage.Click += new System.EventHandler(this.ExpadImage_Click);
            // 
            // ImportButton
            // 
            this.ImportButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ImportButton.Location = new System.Drawing.Point(3, 59);
            this.ImportButton.Name = "ImportButton";
            this.ImportButton.Size = new System.Drawing.Size(794, 23);
            this.ImportButton.TabIndex = 0;
            this.ImportButton.Text = "Import";
            this.ImportButton.UseVisualStyleBackColor = true;
            this.ImportButton.Click += new System.EventHandler(this.ImportButton_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.BackColor = System.Drawing.SystemColors.Control;
            this.flowLayoutPanel1.Controls.Add(this.ImageHolder);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(1, 93);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(797, 408);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // ImageHolder
            // 
            this.ImageHolder.Location = new System.Drawing.Point(3, 3);
            this.ImageHolder.Name = "ImageHolder";
            this.ImageHolder.Size = new System.Drawing.Size(100, 50);
            this.ImageHolder.TabIndex = 0;
            this.ImageHolder.TabStop = false;
            // 
            // Expandby4
            // 
            this.Expandby4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Expandby4.Location = new System.Drawing.Point(3, 33);
            this.Expandby4.Name = "Expandby4";
            this.Expandby4.Size = new System.Drawing.Size(794, 23);
            this.Expandby4.TabIndex = 2;
            this.Expandby4.Text = "Expand x 4";
            this.Expandby4.UseVisualStyleBackColor = true;
            this.Expandby4.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 501);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.Button_Panel);
            this.Name = "Form1";
            this.Text = "Image Expansion";
            this.Button_Panel.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ImageHolder)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Button_Panel;
        private System.Windows.Forms.Button ImportButton;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.PictureBox ImageHolder;
        private System.Windows.Forms.Button ExpadImage;
        private System.Windows.Forms.Button Expandby4;
    }
}

