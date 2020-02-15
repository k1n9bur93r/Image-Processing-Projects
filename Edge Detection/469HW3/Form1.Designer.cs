namespace _469HW3
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.Roberts_One = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Sobel_Vert = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Prewitt_Diag = new System.Windows.Forms.Button();
            this.Prewitt_Vert = new System.Windows.Forms.Button();
            this.ImportImage = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.ImageHolder = new System.Windows.Forms.PictureBox();
            this.TaskBar_Panel = new System.Windows.Forms.Panel();
            this.TaskBar_OperationText = new System.Windows.Forms.Label();
            this.TaskBar_TaskText = new System.Windows.Forms.Label();
            this.TaskBar_Progress = new System.Windows.Forms.ProgressBar();
            this.TaskBar_BG = new System.ComponentModel.BackgroundWorker();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImageHolder)).BeginInit();
            this.TaskBar_Panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Controls.Add(this.ImportImage);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(801, 135);
            this.panel1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.45704F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.54296F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 259F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox3, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(795, 100);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.Roberts_One);
            this.groupBox3.Location = new System.Drawing.Point(538, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(254, 94);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Roberts";
            // 
            // Roberts_One
            // 
            this.Roberts_One.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Roberts_One.Enabled = false;
            this.Roberts_One.Location = new System.Drawing.Point(5, 17);
            this.Roberts_One.Name = "Roberts_One";
            this.Roberts_One.Size = new System.Drawing.Size(243, 23);
            this.Roberts_One.TabIndex = 2;
            this.Roberts_One.Text = "Standard Cross";
            this.Roberts_One.UseVisualStyleBackColor = true;
            this.Roberts_One.Click += new System.EventHandler(this.Roberts_One_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.Sobel_Vert);
            this.groupBox2.Location = new System.Drawing.Point(273, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(259, 94);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Sobel";
            // 
            // Sobel_Vert
            // 
            this.Sobel_Vert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Sobel_Vert.Enabled = false;
            this.Sobel_Vert.Location = new System.Drawing.Point(6, 17);
            this.Sobel_Vert.Name = "Sobel_Vert";
            this.Sobel_Vert.Size = new System.Drawing.Size(247, 23);
            this.Sobel_Vert.TabIndex = 1;
            this.Sobel_Vert.Text = "Vertical";
            this.Sobel_Vert.UseVisualStyleBackColor = true;
            this.Sobel_Vert.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.Prewitt_Diag);
            this.groupBox1.Controls.Add(this.Prewitt_Vert);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(264, 94);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Prewitt";
            // 
            // Prewitt_Diag
            // 
            this.Prewitt_Diag.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Prewitt_Diag.Enabled = false;
            this.Prewitt_Diag.Location = new System.Drawing.Point(6, 43);
            this.Prewitt_Diag.Name = "Prewitt_Diag";
            this.Prewitt_Diag.Size = new System.Drawing.Size(252, 23);
            this.Prewitt_Diag.TabIndex = 1;
            this.Prewitt_Diag.Text = "Diagonal";
            this.Prewitt_Diag.UseVisualStyleBackColor = true;
            this.Prewitt_Diag.Click += new System.EventHandler(this.Prewit_Diag_Click);
            // 
            // Prewitt_Vert
            // 
            this.Prewitt_Vert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Prewitt_Vert.Enabled = false;
            this.Prewitt_Vert.Location = new System.Drawing.Point(6, 17);
            this.Prewitt_Vert.Name = "Prewitt_Vert";
            this.Prewitt_Vert.Size = new System.Drawing.Size(252, 23);
            this.Prewitt_Vert.TabIndex = 0;
            this.Prewitt_Vert.Text = "Vertical/ Horizontal";
            this.Prewitt_Vert.UseVisualStyleBackColor = true;
            this.Prewitt_Vert.Click += new System.EventHandler(this.Prewit_Vert_Click);
            // 
            // ImportImage
            // 
            this.ImportImage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ImportImage.Location = new System.Drawing.Point(3, 106);
            this.ImportImage.Name = "ImportImage";
            this.ImportImage.Size = new System.Drawing.Size(795, 23);
            this.ImportImage.TabIndex = 0;
            this.ImportImage.Text = "Import";
            this.ImportImage.UseVisualStyleBackColor = true;
            this.ImportImage.Click += new System.EventHandler(this.ImportImage_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Controls.Add(this.ImageHolder);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 138);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(798, 479);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // ImageHolder
            // 
            this.ImageHolder.Location = new System.Drawing.Point(3, 3);
            this.ImageHolder.Name = "ImageHolder";
            this.ImageHolder.Size = new System.Drawing.Size(100, 50);
            this.ImageHolder.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.ImageHolder.TabIndex = 0;
            this.ImageHolder.TabStop = false;
            // 
            // TaskBar_Panel
            // 
            this.TaskBar_Panel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TaskBar_Panel.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.TaskBar_Panel.Controls.Add(this.TaskBar_OperationText);
            this.TaskBar_Panel.Controls.Add(this.TaskBar_TaskText);
            this.TaskBar_Panel.Controls.Add(this.TaskBar_Progress);
            this.TaskBar_Panel.Location = new System.Drawing.Point(1, 623);
            this.TaskBar_Panel.Name = "TaskBar_Panel";
            this.TaskBar_Panel.Size = new System.Drawing.Size(798, 40);
            this.TaskBar_Panel.TabIndex = 2;
            this.TaskBar_Panel.Visible = false;
            // 
            // TaskBar_OperationText
            // 
            this.TaskBar_OperationText.AutoSize = true;
            this.TaskBar_OperationText.Location = new System.Drawing.Point(288, 14);
            this.TaskBar_OperationText.Name = "TaskBar_OperationText";
            this.TaskBar_OperationText.Size = new System.Drawing.Size(0, 13);
            this.TaskBar_OperationText.TabIndex = 3;
            // 
            // TaskBar_TaskText
            // 
            this.TaskBar_TaskText.AutoSize = true;
            this.TaskBar_TaskText.Location = new System.Drawing.Point(11, 14);
            this.TaskBar_TaskText.Name = "TaskBar_TaskText";
            this.TaskBar_TaskText.Size = new System.Drawing.Size(53, 13);
            this.TaskBar_TaskText.TabIndex = 2;
            this.TaskBar_TaskText.Text = "TaskBar: ";
            // 
            // TaskBar_Progress
            // 
            this.TaskBar_Progress.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TaskBar_Progress.Location = new System.Drawing.Point(509, 7);
            this.TaskBar_Progress.Name = "TaskBar_Progress";
            this.TaskBar_Progress.Size = new System.Drawing.Size(285, 25);
            this.TaskBar_Progress.TabIndex = 1;
            // 
            // TaskBar_BG
            // 
            this.TaskBar_BG.WorkerReportsProgress = true;
            this.TaskBar_BG.WorkerSupportsCancellation = true;
            this.TaskBar_BG.DoWork += new System.ComponentModel.DoWorkEventHandler(this.TaskBar_BG_DoWork);
            this.TaskBar_BG.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.TaskBar_BG_ProgressChanged);
            this.TaskBar_BG.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.TaskBar_BG_RunWorkerCompleted);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 664);
            this.Controls.Add(this.TaskBar_Panel);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImageHolder)).EndInit();
            this.TaskBar_Panel.ResumeLayout(false);
            this.TaskBar_Panel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button Sobel_Vert;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button Prewitt_Diag;
        private System.Windows.Forms.Button Prewitt_Vert;
        private System.Windows.Forms.Button ImportImage;
        private System.Windows.Forms.Button Roberts_One;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.PictureBox ImageHolder;
        private System.Windows.Forms.Panel TaskBar_Panel;
        private System.Windows.Forms.Label TaskBar_OperationText;
        private System.Windows.Forms.Label TaskBar_TaskText;
        private System.Windows.Forms.ProgressBar TaskBar_Progress;
        private System.ComponentModel.BackgroundWorker TaskBar_BG;
    }
}

