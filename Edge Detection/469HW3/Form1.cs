using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _469HW3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
//////////////////////////////////////////////////////////////////////Shared Properties
       public Bitmap YImage;

       public bool yExists=false;

       public int progress = 0;

       public List<int[]> Maps = new List<int[]> {
          //Prewit Maps
          new int[] {-1,0,1,-1,0,1,-1,0,1}, //Vertical 0
          new int[] {-1,-1,-1,0,0,0,1,1,1}, //Horizontal 1
          new int[] {-1,-1,0,-1,0,1,0,1,1}, //Diagonal L 2
          new int[] {1,1,0,1,0,-1,0,-1,-1}, //Diagonal R 3
          //Sobel Maps
          new int[]{ 1, 0, -1, 2, 0, -2, 1, 0, -1 },//Vertical 4
           new int[] {1,2,1,0,0,0,-1,-2,-1}, //Horizontal 5
          //Robert Maps
          new int[]{1,0,0,-1 },//One 6
          new int[]{0,1,-1,0 }//Two 7
        };

 /////////////////////////////////////////////////////////////////////////////Button Listeners       

        private async void ImportImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Title = "Select Your Image";
                dialog.Filter = "Image Files| *.jpg;*.jpeg;*.png;*.bmp;*.tiff";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    yExists = false;
                    Roberts_One.Enabled = false;
                    Sobel_Vert.Enabled = false;
                    Prewitt_Diag.Enabled = false;
                    Prewitt_Vert.Enabled = false;
                    Bitmap image = new Bitmap(dialog.FileName);
                    ImageHolder.Image = image;
                    ImageHolder.Height = image.Height;
                    ImageHolder.Width = image.Width;
                    ConfigureTaskBar("Rendering Image Y channel", ImageHolder.Height * ImageHolder.Width,1);
                    yExists=await RenderYAsync(dialog.FileName);

                }
            }

        }

        private async void Prewit_Vert_Click(object sender, EventArgs e)
        {
            if (ImageHolder.Image != null && yExists)
            {
                Prewitt_Vert.Enabled = false;
                ConfigureTaskBar("Rendering Prewitt Vertical Edge", YImage.Height * YImage.Width, 3);
                Form window = await RenderEdgeWindowAsync("Prewitt Vertical Edge Detection", 3, new int[] { 0, 1 });
                window.Show();
                TaskBar_BG.CancelAsync();
                Prewitt_Vert.Enabled = true;
            }

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (ImageHolder.Image != null && yExists)
            {
                Sobel_Vert.Enabled = false;
                ConfigureTaskBar("Rendering Sobell Edge", YImage.Height * YImage.Width, 3);
                Form window = await RenderEdgeWindowAsync("Sobel Vertical Edge Detection", 3, new int[] { 4, 5 });
                window.Show();
                TaskBar_BG.CancelAsync();
                Sobel_Vert.Enabled = true;
            }
        }

        private async void Roberts_One_Click(object sender, EventArgs e)
        {
            if (ImageHolder.Image != null && yExists)
            {
                Roberts_One.Enabled = false;
                ConfigureTaskBar("Rendering Roberts Edge", YImage.Height * YImage.Width, 1);
                Form window = await RenderEdgeWindowAsync("Robert's Cross Edge Detection", 2, new int[] { 6, 7 });
                window.Show();
                TaskBar_BG.CancelAsync();
                Roberts_One.Enabled = true;
            }
        }

        private async void Prewit_Diag_Click(object sender, EventArgs e)
        {
            if (ImageHolder.Image != null && yExists)
            {
                Prewitt_Diag.Enabled = false;
                ConfigureTaskBar("Rendering Prewitt Diagonal Edge", YImage.Height * YImage.Width, 3);
                Form window = await RenderEdgeWindowAsync("Prewitt Vertical Edge Detection", 3, new int[] { 2, 3 });
                window.Show();
                TaskBar_BG.CancelAsync();
                Prewitt_Diag.Enabled = true;
            }
        }

///////////////////////////////////////////////////////////////////////////////////////////////////////////Async Wrappers 

        private async Task<bool> RenderYAsync(string FileName)
        {
            YImage = await Task.Run(() => RenderY(FileName));
            Roberts_One.Enabled = true;
            Sobel_Vert.Enabled = true;
            Prewitt_Diag.Enabled = true;
            Prewitt_Vert.Enabled = true;
            TaskBar_BG.CancelAsync();
            return true;
        }

        private async Task<Form> RenderEdgeWindowAsync(string windowName, int boxSize, int[] edgeMaps)
        {

            Form window = await Task.Run(() => RenderNewEdgeWindow(windowName, boxSize, edgeMaps));
            return window;
        }

////////////////////////////////////////////////////////////////////////////////////////////Image Processing Logic 

        private Bitmap RenderY(string FileName)
        {
            Bitmap image = new Bitmap(FileName);
            for (int y = 0; y < image.Width; y++)
            {
                for (int x = 0; x < image.Height; x++)
                {
                    Color pixel = image.GetPixel(y, x);
                    double RN = pixel.R / 255.0;
                    double GN = pixel.G / 255.0;
                    double BN = pixel.B / 255.0;
                    double Conv1 = ((0.299 * RN) + (0.587 * GN) + (0.114 * BN)) * 255.0;
                    pixel = Color.FromArgb(255, (byte)Conv1, (byte)Conv1, (byte)Conv1);
                    image.SetPixel(y, x, pixel);
                    progress++;
                }
            }
            return image;
        }

        private Form RenderNewEdgeWindow(string windowName, int boxSize,int[] edgeMaps)
        {
            Form NewRender = new Form();
            NewRender.AutoSize = true;
            NewRender.Text = windowName;
            Bitmap Image = new Bitmap(YImage);
            
            for (int i = 1; i < Image.Width-1; i++)
            {
                
                for (int j = 1; j < Image.Height-1; j++)
                {
                    int color = CheckPixel(boxSize, i, j, edgeMaps);
                    if (color < 50) color = 0;
                    Image.SetPixel(i, j, Color.FromArgb(255,(byte)color, (byte)color, (byte)color));
                    progress++;
                }
            }
            PictureBox ImageHolder = new PictureBox { Image = Image, Height = Image.Height, Width = Image.Width };

            NewRender.Controls.Add(ImageHolder);
            return NewRender;
        }
        private int CheckPixel(int boxSize,int pixX,int pixY,int[] edgeMaps)
        {
            int[] totalNeg= new int[] {0, 0};
            int[] totalPos=new int[] {0, 0};
            for (int y=0;y<boxSize;y++) {
                int currentAdjust = (boxSize - 1) / 2;
                int yAdjust = y <= currentAdjust ?(currentAdjust*-1+y):y - currentAdjust;
                int currY = pixY + yAdjust;
                for (int x=0;x<boxSize;x++) {
                    int mapPos = x + (y * boxSize);
                    int arrayCount = 0;
                    foreach (int edgeMap in edgeMaps)
                    {
                        if (Maps[edgeMap][mapPos] != 0)
                        {
                            int xAdjust = x <= currentAdjust ? (currentAdjust*-1+ x) : x - currentAdjust; ;
                            int currX = pixX + xAdjust;
                            if (Maps[edgeMap][mapPos] < 0)
                                totalNeg[arrayCount] += Maps[edgeMap][mapPos] * YImage.GetPixel(currX, currY).R;
                            else 
                                totalPos[arrayCount] += Maps[edgeMap][mapPos] * YImage.GetPixel(currX, currY).R;          
                        }
                        arrayCount++;
                    }
                }
            }          
            return Math.Abs(totalPos[0] + totalNeg[0])+ Math.Abs(totalPos[1] + totalNeg[1]) ;
        }



/////////////////////////////////////////////////////////////////////////////Progress Bar Helper Functions 

        private void ConfigureTaskBar(string LabelText, int BarProgressScale, int AsyncTime)
        {
            TaskBar_Panel.Visible = true;
            TaskBar_TaskText.Text = LabelText;
            TaskBar_Progress.Maximum = BarProgressScale;
            TaskBar_BG.RunWorkerAsync(argument: new Tuple<int, int>(BarProgressScale, AsyncTime));
        }

        private void TaskBar_BG_DoWork(object sender, DoWorkEventArgs e)
        {
            dynamic argTuple =e.Argument;
            for (int i = 0; i < argTuple.Item1; i++)
            {
                if (TaskBar_BG.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }
                System.Threading.Thread.Sleep(argTuple.Item2);
                TaskBar_BG.ReportProgress(1);
            }
            e.Result = true;
        }

        private void TaskBar_BG_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (progress > TaskBar_Progress.Maximum)
            {
                TaskBar_Progress.Value = 0;
                progress = 0;
            }
            TaskBar_Progress.Value=progress;
        }

        private void TaskBar_BG_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            TaskBar_Panel.Visible = false;
            TaskBar_Progress.Value = 0;
            progress=0;
        }
    }
}
