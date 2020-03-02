using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _496HW4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ExpadImage.Enabled = false;
            Expandby4.Enabled = false;

        }
        bool flip = false;
        int imageDepth;
        int mWidth;
        int mHeight;
        int tWidth;
        Bitmap bigImage;
        Bitmap mainImage;
        byte[] bBigImage;
        byte[] bmainImage;
        private void ImportButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Title = "Select Your Image";
                dialog.Filter = "Image Files| *.jpg;*.jpeg;*.png;*.bmp;*.tiff";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                  Bitmap temp = new Bitmap(dialog.FileName);
                    imageDepth = temp.PixelFormat == PixelFormat.Format24bppRgb ? 3 : 4;
                    mWidth = temp.Width;
                    mHeight = temp.Height;
                    bmainImage = ConvToByteArray(temp);
                    flip = false;
                    if (mWidth % 4 != 0)
                    {
                        flip = true;
                        Rectangle rect = new Rectangle(0, 0, mWidth, mHeight);
                        System.Drawing.Imaging.BitmapData mInfo = temp.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite, temp.PixelFormat);
                        for (int y = 0; y < mHeight; ++y)
                        {
                            IntPtr mem = (IntPtr)((long)mInfo.Scan0 + y * mInfo.Stride);
                            Marshal.Copy(mem, bmainImage, y * mWidth * 3, mWidth * 3);
                        }

                    }
                    mainImage = new Bitmap(dialog.FileName);
                    ImageHolder.Image = mainImage;
                    ImageHolder.Height = mainImage.Height;
                    ImageHolder.Width = mainImage.Width;
                    ExpadImage.Enabled = true;
                    Expandby4.Enabled = true;
                }
            }
        }

        private  async void ExpadImage_Click(object sender, EventArgs e)
        {
            Form window = await RenderExpansionWindowAsync(2);
            window.Show();
        }


        private async void button1_Click(object sender, EventArgs e)
        {
            Form window = await RenderExpansionWindowAsync(4);
            window.Show();
        }

        private async Task<Form> RenderNewExpansion(int scale) {
           // var tasks = new List<Task<bool>>();
            int imageArea = mWidth*mHeight;
            //int groupsize = imageArea / 2; //Environment.ProcessorCount;
            //int leftovers = imageArea % 2;//Environment.ProcessorCount;
            Form window = new Form();
            tWidth = mWidth;
            if (scale == 2)
            {
                if ((mWidth * scale) % 4 != 0)
                {
                    int tempMod = mWidth % 4;
                    mWidth -= tempMod;
                }
            }
            PixelFormat format = imageDepth == 3 ? PixelFormat.Format24bppRgb : PixelFormat.Format32bppArgb;
            bigImage = new Bitmap(mWidth*scale,mHeight*scale, format);
            bBigImage = ConvToByteArray(bigImage);
            PictureBox newImageHolder = new PictureBox {  Height = bigImage.Height, Width = bigImage.Width };
            window.Height = bigImage.Height<100?bigImage.Height:1000;
            window.Width = bigImage.Width;
            window.AutoScroll = true;
           // for (int a = 0; a < 2; a++)
           // {
           //     if (a != 1 - 2)
           //         tasks.Add(Task.Run(() => ProcessImageChunk((a * groupsize), (groupsize - 1) + (a * groupsize), a, scale)));
           //     else
           //         tasks.Add(Task.Run(() => ProcessImageChunk((a * groupsize), groupsize + (a * groupsize) + leftovers, a, scale)));
           // }
           //// Task.WaitAll(tasks.ToArray());
           ProcessImageChunk(0, imageArea, 0,scale);
           
            var ms = new MemoryStream(bBigImage);
            Image image = Image.FromStream(ms);
            if (mWidth*scale % 4 != 0)
            {
                Bitmap temp = new Bitmap(image);
               Rectangle rect = new Rectangle(0, 0, mWidth, mHeight);
                System.Drawing.Imaging.BitmapData mInfo = temp.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite, temp.PixelFormat);
                for (int y = 0; y < mHeight; ++y)
                {
                    IntPtr mem = (IntPtr)((long)mInfo.Scan0 + y * mInfo.Stride);
                    Marshal.Copy(mem, bBigImage, y * mWidth * 3, mWidth * 3);
                }

            }
            mWidth = tWidth;
            ms = new MemoryStream(bBigImage);
            image = Image.FromStream(ms);
            if (flip)
            image.RotateFlip(RotateFlipType.Rotate180FlipX);
            newImageHolder.Image = image;
            
            window.Controls.Add(newImageHolder);
            return window; 

        }

        public static byte[] ConvToByteArray(Bitmap image)
        {
            using (var stream = new MemoryStream())
            {
                image.Save(stream, System.Drawing.Imaging.ImageFormat.Bmp);
                return stream.ToArray();
            }
        }

        private bool ProcessImageChunk(int start, int end, int i,int scale)
        {
            int width = mWidth;
            int startingColumnPosition=start%width;
            int startingRow=start/width;
            int endColumnPosition=end%width;
            int endingRow=end/width;
            bool startMidRow = startingColumnPosition == 0 ? false : true;
            for (int b = startingRow; b <= endingRow; b++)
            {
                width = b == endingRow ? endColumnPosition : width;
                int a = startMidRow ? startingColumnPosition : 0;
                for ( a = 0; a < width; a++)
                {
                    ProcessPixels(a,b,i,scale);
                }

                startMidRow = false;
            }
            return true;
        }

        private void ProcessPixels(int x, int y, int id,int scale)
        {
            int newR = 0;
            int newG = 0;
            int newB = 0;
            int P = ((y * mWidth) + (x)) * imageDepth;
            P += 54;
            Color pixel = Color.FromArgb(255, bmainImage[P + 2], bmainImage[P + 1], bmainImage[P]);
            if (x - 3 < 0 || x - 2 < 0 || x - 1 < 0)
            {
                newR = bmainImage[P + 2];
                newG = bmainImage[P + 1];
                newB = bmainImage[P];
            }
            else if (x + 3 >= mWidth || x + 2 >= mWidth || x + 1 >= mWidth)
            {
                newR = bmainImage[P + 2];
                newG = bmainImage[P + 1];
                newB = bmainImage[P];
            }
            else
            {
                newR = ((-10 * (bmainImage[(P + 2) - (3 * imageDepth)]) + 14 * (bmainImage[(P + 2) - (2 * imageDepth)]) - 23 * (bmainImage[(P + 2) - imageDepth]) + 69 * (bmainImage[P + 2]) + 69 * (bmainImage[imageDepth + (P + 2)]) - 23 * (bmainImage[imageDepth + (P + 2)]) + 14 * (bmainImage[2 * imageDepth + (P + 2)]) - 10 * (bmainImage[3 * imageDepth + (P + 2)])) + 50) / 100;
                newG = ((-10 * (bmainImage[(P + 1) - (3 * imageDepth)]) + 14 * (bmainImage[(P + 1) - (2 * imageDepth)]) - 23 * (bmainImage[(P + 1) - imageDepth]) + 69 * (bmainImage[P + 1]) + 69 * (bmainImage[imageDepth + (P + 1)]) - 23 * (bmainImage[imageDepth + (P + 1)]) + 14 * (bmainImage[2 * imageDepth + (P + 1)]) - 10 * (bmainImage[3 * imageDepth + (P + 1)])) + 50) / 100;
                newB = ((-10 * (bmainImage[(P)     - (3 * imageDepth)]) + 14 * (bmainImage[(P)     - (2 * imageDepth)]) - 23 * (bmainImage[(P)     - imageDepth]) + 69 * (bmainImage[P])     + 69 * (bmainImage[imageDepth + (P)])     - 23 * (bmainImage[imageDepth + (P)])     + 14 * (bmainImage[2 * imageDepth + (P)])     - 10 * (bmainImage[3 * imageDepth + (P)]))     + 50) / 100;

                if (newR < 0 || newG < 0 || newB < 0|| newR > 255 || newG > 255 || newB > 255)
                {
                    newR = newR < 0 ? pixel.R : newR;
                    newG = newG < 0 ? pixel.G : newG;
                    newB = newB < 0 ? pixel.B : newB;
                    newR = newR > 255 ? pixel.R : newR;
                    newG = newG > 255 ? pixel.G : newG;
                    newB = newB > 255 ? pixel.B : newB;
                }

            }

            PlacePixels(x, y, (byte)newR, (byte)newG, (byte)newB, pixel, id,scale);
        }

        private void PlacePixels(int x2, int y2, byte R, byte G, byte B, Color pixel, int id,int scale)
        {
            int totalpos = (((y2 * scale) * mWidth * scale) + (x2 * scale)) * imageDepth;
            totalpos += 54;
            int scaler = tWidth * scale - mWidth * scale;
            if (totalpos >= bBigImage.Length) return;
            int temppos = totalpos;
            int loops = scale;
            bool firstLoop = true;
            for (int a = 0; a < loops; a++)
            {
                for (int b = 0; b < loops; b++)
                {
                    //ROW
                    if (firstLoop)
                    {
                        //OG PIXEL
                        bBigImage[temppos] = pixel.B;  //b
                        bBigImage[temppos + 1] = pixel.G;//g
                        bBigImage[temppos + 2] = pixel.R;//r
                        firstLoop = false;
                        temppos += (1 * imageDepth);
                    }
                    else
                    {
                        
                        bBigImage[temppos] = B;  //b
                        bBigImage[temppos + 1] = G;//g
                        bBigImage[temppos + 2] = R;//r
                        temppos += (1 * imageDepth);
                    }
                }
                //ADJUST COLUMN
                temppos = totalpos;
                totalpos += ((mWidth) * scale) * imageDepth;
                temppos = totalpos;
            }
        }

        private async Task<Form> RenderExpansionWindowAsync(int scale)
        {
            Form window = null; ;
            if (mainImage != null)
            {
                 window = await Task.Run(() => RenderNewExpansion(scale));
            }
            return window;


        }

    }
}
