using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _468HW2
{
    public partial class MainForm : Form
    {

        public MainForm()
        {
            InitializeComponent();
            
        }

        private void ImportImageButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Title = "Select Your Image";
                dialog.Filter = "Image Files| *.jpg;*.jpeg;*.png;*.bmp;*.tiff";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    Bitmap image = new Bitmap(dialog.FileName);
                    ImageHolder.Image = image;
                    ImageHolder.Height = image.Height;
                    ImageHolder.Width = image.Width;
                    ImageHolder.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;


                    
                }
            }
        }

        private void RenderSurroundingEight(Bitmap image, int X, int Y)
        {
            int PixelPanelDems = 30;
            int PixelMargin = 5;

            int PixelPanelContainerDems = (PixelPanelDems * 9) + PixelMargin * 4;

            int MainPanelMargin = 10;
            int MainPanelWidth = (PixelPanelContainerDems * 3) + MainPanelMargin * 3;
            int MainPanelHeight = PixelPanelContainerDems + (MainPanelMargin * 4);



            Form NewRender = new Form { Width = MainPanelWidth, Height = MainPanelHeight, Text = "Local Pixel RGB Grids" };
            FlowLayoutPanel MainWrapper = new FlowLayoutPanel { Width = NewRender.Width, Height = NewRender.Height };
            FlowLayoutPanel RPixels = new FlowLayoutPanel { Width = PixelPanelContainerDems, Height = PixelPanelContainerDems ,BackColor=Color.Pink};
            FlowLayoutPanel GPixels = new FlowLayoutPanel { Width = PixelPanelContainerDems, Height = PixelPanelContainerDems ,BackColor=Color.LightGreen};
            FlowLayoutPanel BPixels = new FlowLayoutPanel { Width = PixelPanelContainerDems, Height = PixelPanelContainerDems, BackColor = Color.PowderBlue };

            MainWrapper.Controls.Add(RPixels);
            MainWrapper.Controls.Add(GPixels);
            MainWrapper.Controls.Add(BPixels);
            NewRender.Controls.Add(MainWrapper);
            for (int y=0;y<8; y++) {
                int yAdjust = y <= 3 ? -3 + y : y - 4;
                for (int x = 0; x < 8; x++)
                {
                    int xAdjust = x <= 3 ? -3 + x : x - 4;
                    int newX = X + xAdjust;
                    int newY = Y + yAdjust;
                    bool truePixel = false;
                    if ((newX >= 0 && newX < ImageHolder.Width) && (newY >= 0 && newY < ImageHolder.Height)) truePixel = true;

                    renderVisualPixel(ref RPixels, newX,newY,0, PixelPanelDems, PixelMargin, truePixel);
                    renderVisualPixel(ref GPixels, newX,newY,1, PixelPanelDems, PixelMargin, truePixel);
                    renderVisualPixel(ref BPixels, newX, newY,2, PixelPanelDems, PixelMargin, truePixel);
                }
            }
            NewRender.Show();
        }

        private void renderVisualPixel(ref FlowLayoutPanel panel,int X, int Y,int channel ,int panelSize,int panelMargin, bool goodPixel)
        {
            Bitmap Image = new Bitmap(ImageHolder.Image);
            string text=String.Empty;
            int value = -1;
            switch (channel)
            {
                case 0: { text = goodPixel ? "R " +Image.GetPixel(X, Y).R.ToString() : "-1";  value = Image.GetPixel(X, Y).R; break; }
                case 1: { text = goodPixel ? "G " + Image.GetPixel(X, Y).G.ToString() : "-1"; value = Image.GetPixel(X, Y).G; break; }
                case 2: { text = goodPixel ? "B " + Image.GetPixel(X, Y).B.ToString() : "-1"; value = Image.GetPixel(X, Y).B; break; }
            }
            Panel pixel = new Panel { Height = panelSize, Width = panelSize, BackColor = goodPixel?Color.FromArgb(255, value, value, value):Color.DarkRed };

            Label pixelText = new Label { Text=goodPixel? text : "X",Margin=new Padding(1),TextAlign=ContentAlignment.MiddleCenter, AutoSize=false,Dock=DockStyle.Fill,Font=new Font(Label.DefaultFont,FontStyle.Bold),ForeColor= value>75?Color.Black:Color.LightGray};
            pixel.Controls.Add(pixelText);
            panel.Controls.Add(pixel);

        }

        private void ImageHolder_MouseHover(object sender, EventArgs e)
        {
            Bitmap image = new Bitmap(ImageHolder.Image);
            Point mouse = MainForm.MousePosition;
        }

        private void ImageHolder_MouseUp(object sender, MouseEventArgs e)
        {
            if (ImageHolder.Image != null)
            {
                RenderSurroundingEight(new Bitmap(ImageHolder.Image), e.X, e.Y);
            }
        }
    }

}
