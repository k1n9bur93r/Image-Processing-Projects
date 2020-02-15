namespace _468HW2
{
    partial class MainForm
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
            this.ToolBoxPanel = new System.Windows.Forms.Panel();
            this.ImportImageButton = new System.Windows.Forms.Button();
            this.ImageHolder = new System.Windows.Forms.PictureBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.ToolBoxPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImageHolder)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ToolBoxPanel
            // 
            this.ToolBoxPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ToolBoxPanel.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.ToolBoxPanel.Controls.Add(this.ImportImageButton);
            this.ToolBoxPanel.Location = new System.Drawing.Point(12, 12);
            this.ToolBoxPanel.Name = "ToolBoxPanel";
            this.ToolBoxPanel.Size = new System.Drawing.Size(776, 35);
            this.ToolBoxPanel.TabIndex = 0;
            // 
            // ImportImageButton
            // 
            this.ImportImageButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ImportImageButton.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ImportImageButton.FlatAppearance.BorderColor = System.Drawing.Color.Fuchsia;
            this.ImportImageButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ImportImageButton.Location = new System.Drawing.Point(3, 6);
            this.ImportImageButton.Name = "ImportImageButton";
            this.ImportImageButton.Size = new System.Drawing.Size(770, 23);
            this.ImportImageButton.TabIndex = 0;
            this.ImportImageButton.Text = "Import Image";
            this.ImportImageButton.UseVisualStyleBackColor = false;
            this.ImportImageButton.Click += new System.EventHandler(this.ImportImageButton_Click);
            // 
            // ImageHolder
            // 
            this.ImageHolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ImageHolder.Cursor = System.Windows.Forms.Cursors.Cross;
            this.ImageHolder.Location = new System.Drawing.Point(3, 3);
            this.ImageHolder.Name = "ImageHolder";
            this.ImageHolder.Size = new System.Drawing.Size(447, 207);
            this.ImageHolder.TabIndex = 2;
            this.ImageHolder.TabStop = false;
            this.ImageHolder.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ImageHolder_MouseUp);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Controls.Add(this.ImageHolder);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 53);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(776, 440);
            this.flowLayoutPanel1.TabIndex = 3;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 505);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.ToolBoxPanel);
            this.Name = "MainForm";
            this.Text = "RGB Grid Selector";
            this.ToolBoxPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ImageHolder)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel ToolBoxPanel;
        private System.Windows.Forms.Button ImportImageButton;
        private System.Windows.Forms.PictureBox ImageHolder;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}

