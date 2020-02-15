using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _468HW1
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void ImportImage_Click(object sender, EventArgs e)
        {

            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Title = "Select Your Image";
                dialog.Filter = "Image Files| *.jpg;*.jpeg;*.png;*.bmp;*.tiff";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    Bitmap image = new Bitmap(dialog.FileName);
                    MainImageBox.Image = image;
                    MainImageBox.Height = image.Height;
                    MainImageBox.Width = image.Width;
                }
            }
        
        }

        private void MainImageBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (MainImageBox.Image != null)
            {
                Bitmap image = new Bitmap(MainImageBox.Image);
                Color Converted = new Color();
                Color color = image.GetPixel(e.X, e.Y);
                RGBSelectedColor.BackColor = color;
                RGB_R.Text = color.R.ToString();
                RGB_G.Text = color.G.ToString();
                RGB_B.Text = color.B.ToString();
                
                Converted = image.GetPixel(e.X, e.Y); ;
                ConvertToYUV(ref Converted, 0);
                YUVSelectedColor.BackColor = Converted;
                YUV_Y.Text = Converted.R.ToString();
                YUV_U.Text = Converted.G.ToString();
                YUV_V.Text = Converted.B.ToString();

                Converted = image.GetPixel(e.X, e.Y); ;
                ConvertToYIQ(ref Converted, 0);
                YIQSelectedColor.BackColor = Converted;
                YIQ_Y.Text = Converted.R.ToString();
                YIQ_I.Text = Converted.G.ToString();
                YIQ_Q.Text = Converted.B.ToString();

                Converted = image.GetPixel(e.X, e.Y); ;
                ConvertToYCrCb(ref Converted, 0);
                YCrCbSelectedColor.BackColor = Converted;
                YCrCb_Y.Text = Converted.R.ToString();
                YCrCb_Cr.Text = Converted.G.ToString();
                YCrCb_Cb.Text = Converted.B.ToString();

                Converted = image.GetPixel(e.X, e.Y); ;
                ConvertToCMY(ref Converted, 0);
                CMYSelectedColor.BackColor = Converted;
                CMYK_C.Text = Converted.R.ToString();
                CMYK_M.Text = Converted.G.ToString();
                CMYK_Y.Text = Converted.B.ToString();

                Converted = image.GetPixel(e.X, e.Y); ;
                double K = ConvertToCMYK(ref Converted, 0);
                CMYKSelectedColor.BackColor = Converted;
                CMY_C.Text = Converted.R.ToString();
                CMY_M.Text = Converted.G.ToString();
                CMY_Y.Text = Converted.B.ToString();
                CMYK_K.Text = (Convert.ToInt32(K*100)).ToString();

            }
        }
        /// Full color spaces 
        private void RenderYUVButton_Click(object sender, EventArgs e)
        {
            if(MainImageBox.Image!=null)
                RenderNewColorSpaceWindow("YUV ColorspaceImage", 0,0);
        }

        private void RenderYIQButton_Click(object sender, EventArgs e)
        {
            if (MainImageBox.Image != null)
                RenderNewColorSpaceWindow("YIQ ColorspaceImage", 1,0);
        }

        private void RenderYCrCbButton_Click(object sender, EventArgs e)
        {
            if (MainImageBox.Image != null)
                RenderNewColorSpaceWindow("YCrCb ColorspaceImage", 2,0);
        }

        private void RenderCYMButton_Click(object sender, EventArgs e)
        {
            if (MainImageBox.Image != null)
                RenderNewColorSpaceWindow("CYMK ColorspaceImage", 3,0);
        }
        private void RenderCMYKButton_Click(object sender, EventArgs e)
        {
            if (MainImageBox.Image != null)
                RenderNewColorSpaceWindow("CYMK ColorspaceImage", 4, 0);
        }


        ///Individual color channels 
        private void RenderMany_Y_Click(object sender, EventArgs e)
        {
            if (MainImageBox.Image != null)
                RenderNewColorSpaceWindow("Many Y Color Channel", 0, 1);
        }

        private void RenderYUV_U_Click(object sender, EventArgs e)
        {
            if (MainImageBox.Image != null)
                RenderNewColorSpaceWindow("YUV U Color Channel", 0, 2);
        }

        private void RenderYUV_V_Click(object sender, EventArgs e)
        {
            if (MainImageBox.Image != null)
                RenderNewColorSpaceWindow("YUV V Color Channel", 0, 3);
        }

        private void RenderYIQ_I_Click(object sender, EventArgs e)
        {
            if (MainImageBox.Image != null)
                RenderNewColorSpaceWindow("YIQ I Color Channel", 1, 1);
        }

        private void RenderYIQ_Q_Click(object sender, EventArgs e)
        {
            if (MainImageBox.Image != null)
                RenderNewColorSpaceWindow("YIQ Q Color Channel", 1, 2);
        }

        private void RenderYCrCb_Cr_Click(object sender, EventArgs e)
        {
            if (MainImageBox.Image != null)
                RenderNewColorSpaceWindow("YCrCb Cr Color Channel", 2, 1);
        }

        private void RenderYCrCb_Cb_Click(object sender, EventArgs e)
        {
            if (MainImageBox.Image != null)
                RenderNewColorSpaceWindow("YCrCb Cb Color Channel", 2, 2);
        }

        private void RenderCMY_C_Click(object sender, EventArgs e)
        {
            if (MainImageBox.Image != null)
                RenderNewColorSpaceWindow("CMY C Color Channel", 3, 1);
        }

        private void RenderCMY_M_Click(object sender, EventArgs e)
        {
            if (MainImageBox.Image != null)
                RenderNewColorSpaceWindow("CMY M Color Channel", 3, 2);
        }

        private void RenderCMY_Y_Click(object sender, EventArgs e)
        {
            if (MainImageBox.Image != null)
                RenderNewColorSpaceWindow("CMY C Color Channel", 3, 3);
        }

        private void RenderCMYK_K_Click(object sender, EventArgs e)
        {
            if (MainImageBox.Image != null)
                RenderNewColorSpaceWindow("CMY C Color Channel", 4, 4);

        }
        private void RenderCMYK_C_Click(object sender, EventArgs e)
        {
            if (MainImageBox.Image != null)
                RenderNewColorSpaceWindow("CMYK C Color Channel", 4, 1);
        }
        private void Render_CMYK_M_Click(object sender, EventArgs e)
        {
            if (MainImageBox.Image != null)
                RenderNewColorSpaceWindow("CMYK M Color Channel", 4, 2);
        }
        private void RenderCMYK_Y_Click(object sender, EventArgs e)
        {
            if (MainImageBox.Image != null)
                RenderNewColorSpaceWindow("CMYK Y Color Channel", 4, 3);
        }


        /// Popup window renderer

        private void RenderNewColorSpaceWindow(string windowName, int colorSpace, int channel)
        {
            Form NewRender = new Form();
            NewRender.AutoSize = true;
            NewRender.Text = windowName;
            Bitmap Image = new Bitmap(MainImageBox.Image);
            for (int i = 0; i < Image.Width; i++)
            {
                for (int j = 0; j < Image.Height; j++)
                {
                    Color pixel = Image.GetPixel(i, j);
                    switch (colorSpace)
                    {
                        case 0: {
                        ConvertToYUV(ref pixel, channel);
                        break;
                        }
                        case 1: {
                        ConvertToYIQ(ref pixel, channel);
                        break;
                        }
                        case 2: {
                        ConvertToYCrCb(ref pixel, channel);
                        break;
                        }
                        case 3: {
                        ConvertToCMY(ref pixel, channel);
                        break;
                        }
                        case 4:
                        {
                        ConvertToCMYK(ref pixel, channel);
                        break;
                        }
                    }
                    Image.SetPixel(i, j, pixel);
                }
            }
            PictureBox ImageHolder = new PictureBox { Image = Image, Height = Image.Height, Width = Image.Width };

            NewRender.Controls.Add(ImageHolder);
            NewRender.Show();
        }

        //Colorspace math

        private void ConvertToYUV(ref Color pixel, int Channel)
        {
            double MinColor = 0.0;
            double RN = pixel.R / 255.0;
            double GN = pixel.G / 255.0;
            double BN = pixel.B / 255.0;
            double Conv1 = ((0.299 * RN) + (0.587 * GN) + (0.114 * BN))*255.0;
            double Conv2 = ((-0.147 * RN) + (-0.289 * GN) + (0.437 * BN))*255.0;
            double Conv3 = ((0.615 * RN) + (-0.515 * GN) + (-0.100 * BN))*255.0;
            if (Conv2 < 0 || Conv3 < 0)
            {
                MinColor = Math.Abs(Math.Min(Conv2, Conv3));
                Conv2 += MinColor;
                Conv3 += MinColor;
            }
            if (Conv1 > 255 || Conv2 > 255 || Conv3 > 255)
            {

                Conv1 = ((Conv1 / 335.58) * 255.0);
                Conv2 = ((Conv2 / 335.58) * 255.0);
                Conv3 = ((Conv3 / 335.58) * 255.0);
            }
            pixel = PixelSaver(Channel, pixel, Conv1, Conv2, Conv3);

        }

        private void ConvertToYIQ( ref Color pixel, int Channel)
        {
            double MinColor = 0.0;
            double RN = pixel.R / 255.0;
            double GN = pixel.G / 255.0;
            double BN = pixel.B / 255.0;
            double Conv1 = ((0.299 * RN) + (0.587 * GN) + (0.114 * BN)) * 255.0;
            double Conv2 = ((0.596 * RN) + (-0.275 * GN) + (-0.321 * BN)) * 255.0;
            double Conv3 = ((0.212 * RN) + (-0.523 * GN) + (0.311 * BN)) * 255.0;
            if ((Conv2 < 0 || Conv3 < 0))
            {
                MinColor = Math.Abs(Math.Min(Conv2, Conv3));
                Conv2 += MinColor;
                Conv3 += MinColor;
            }
            if (Conv1 > 255 || Conv2 > 255 || Conv3 > 255)
            {
                Conv1 = ((Conv1 / 330.735) * 255.0);
                Conv2 = ((Conv2 / 330.735) * 255.0);
                Conv3 = ((Conv3 / 330.735) * 255.0);
            }
            pixel = PixelSaver(Channel, pixel, Conv1, Conv2, Conv3);

        }

        private void ConvertToYCrCb( ref Color pixel, int Channel)
        {
            double MinColor = 0.0;
            double RN = pixel.R / 255.0;
            double GN = pixel.G / 255.0;
            double BN = pixel.B / 255.0;
            double Conv1 = ((0.299 * RN) + (0.587 * GN) + (0.114 * BN)) * 255.0;
            double Conv2 = ((0.500 * RN) + (-0.419 * GN) + (-0.081 * BN)) * 255.0;
            double Conv3 = ((-0.169 * RN) + (-0.331 * GN) + (0.500 * BN)) * 255.0;
            if (Conv2 < 0 || Conv3 < 0)
            {
                MinColor = Math.Abs(Math.Min(Conv2, Conv3));
                Conv2 += MinColor;
                Conv3 += MinColor;
            }
            if (Conv1 > 255 || Conv2 > 255 || Conv3 > 255)
            {
                Conv1 = ((Conv1  / 353.43) * 255.0);
                Conv2 = ((Conv2 / 353.43) * 255.0);
                Conv3 = ((Conv3 / 353.43) * 255.0);
            }
            pixel = PixelSaver(Channel, pixel, Conv1, Conv2, Conv3);

        }
        private void ConvertToCMY( ref Color pixel, int Channel)
        {
            double Conv1 = 255 - pixel.R;
            double Conv2 = 255 - pixel.G;
            double Conv3 = 255 - pixel.B;
            pixel = PixelSaver(Channel, pixel, Conv1, Conv2, Conv3);
        }

        private double ConvertToCMYK(ref Color pixel, int Channel)
        {
            double RN = pixel.R / 255.0;
            double GN = pixel.G / 255.0;
            double BN = pixel.B / 255.0;
            double K = 1 - Math.Max(pixel.R / 255.0, Math.Max(pixel.G / 255.0, pixel.B / 255.0));
            double Conv1 = ((1 - RN - K) / (1 - K)) * 100.0;
            double Conv2 = ((1 - GN - K) / (1 - K)) * 100.0;
            double Conv3 = ((1 - BN - K) / (1 - K)) * 100.0;
            if (Channel == 4)
                pixel = Color.FromArgb(255, (byte)K, (byte)K, (byte)K);
            else
                pixel = PixelSaver(Channel, pixel, Conv1, Conv2, Conv3);
            return K;
        }

        /// Helper function

        private Color PixelSaver(int saveType, Color pixel, double Conv1, double Conv2, double Conv3)
        {
            switch (saveType)
            {
                case 0:
                    {
                        pixel = Color.FromArgb(255, (byte)Conv1, (byte)Conv2, (byte)Conv3);
                        break;
                    }
                case 1:
                    {
                        pixel = Color.FromArgb(255, (byte)Conv1, (byte)Conv1, (byte)Conv1);
                        break;
                    }
                case 2:
                    {
                        pixel = Color.FromArgb(255, (byte)Conv2, (byte)Conv2, (byte)Conv2);
                        break;
                    }
                case 3:
                    {
                        pixel = Color.FromArgb(255, (byte)Conv3, (byte)Conv3, (byte)Conv3);
                        break;
                    }
            }
            return pixel;
        }



    }
}
  

