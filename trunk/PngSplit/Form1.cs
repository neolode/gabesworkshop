using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace PngSplit
{
    public partial class frmMain : Form
    {
        Bitmap buff=null, bmp=null, alpha=null;
        public frmMain()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (!joinMode.Checked)
            {
                openFileDialog1.Filter = "Portable Network Graphics|*.png";
                if (openFileDialog1.ShowDialog() != DialogResult.OK) return;
                label1.Show();
                Application.DoEvents();
                //MessageBox.Show(openFileDialog1.FileName);
                //pictureBox1.ImageLocation = openFileDialog1.FileName;
                buff = new Bitmap(openFileDialog1.FileName);
                bmp = new Bitmap(buff.Width, buff.Height);
                alpha = new Bitmap(buff.Width, buff.Height);
                for (int i = 0; i < buff.Width; i++)
                {
                    for (int j = 0; j < buff.Height; j++)
                    {
                        bmp.SetPixel(i, j, Color.FromArgb(255, buff.GetPixel(i, j).R, buff.GetPixel(i, j).G, buff.GetPixel(i, j).B));
                        alpha.SetPixel(i, j, Color.FromArgb(255, buff.GetPixel(i, j).A, buff.GetPixel(i, j).A, buff.GetPixel(i, j).A));
                    }
                }
                Application.DoEvents();
                pictureBox1.Image = buff;
                pictureBox2.Image = bmp;
                pictureBox3.Image = alpha;
                label1.Hide();
            }
            else
            {
                saveFileDialog1.Filter = "Portable Network Graphics|*.png";
                saveFileDialog1.Title = "Alpha Png";
                if (bmp == null) return;
                if (buff == null) return;
                if (alpha == null) return;
                if (saveFileDialog1.ShowDialog() != DialogResult.OK) return;
                buff.Save(saveFileDialog1.FileName, ImageFormat.Png);
                
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (!joinMode.Checked)
            {
                saveFileDialog1.Filter = "Bitmap|*.bmp";
                saveFileDialog1.Title = "24 bit colorChannel";
                if (bmp == null) return;
                if (saveFileDialog1.ShowDialog() != DialogResult.OK) return;
                bmp.Save(saveFileDialog1.FileName, ImageFormat.Bmp);
            }
            else
            {
                openFileDialog1.Filter = "Bitmap|*.bmp";
                if (openFileDialog1.ShowDialog() != DialogResult.OK) return;
                bmp = new Bitmap(openFileDialog1.FileName);
                pictureBox2.Image = bmp;
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (!joinMode.Checked)
            {
                saveFileDialog1.Filter = "Bitmap|*.bmp";
                if (alpha == null) return;
                saveFileDialog1.Title = "8 bit alphaChannel";
                if (saveFileDialog1.ShowDialog() != DialogResult.OK) return;
                alpha.Save(saveFileDialog1.FileName, ImageFormat.Bmp);
            }
            else
            {
                openFileDialog1.Filter = "Bitmap|*.bmp";
                if (openFileDialog1.ShowDialog() != DialogResult.OK) return;
                if (bmp == null) return;
                label1.Show();
                Application.DoEvents();
                //MessageBox.Show(openFileDialog1.FileName);
                //pictureBox1.ImageLocation = openFileDialog1.FileName;
                buff = new Bitmap(bmp.Width, bmp.Height);
                alpha = new Bitmap(openFileDialog1.FileName);
                for (int i = 0; i < bmp.Width; i++)
                {
                    for (int j = 0; j < bmp.Height; j++)
                    {
                        buff.SetPixel(i, j, Color.FromArgb(alpha.GetPixel(i, j).R, bmp.GetPixel(i, j).R, bmp.GetPixel(i, j).G, bmp.GetPixel(i, j).B));
                        //alpha.SetPixel(i, j, Color.FromArgb(255, buff.GetPixel(i, j).A, buff.GetPixel(i, j).A, buff.GetPixel(i, j).A));
                    }
                }
                Application.DoEvents();
                pictureBox1.Image = buff;
                pictureBox2.Image = bmp;
                pictureBox3.Image = alpha;
                label1.Hide();
            }
        }

        private void joinMode_Click(object sender, EventArgs e)
        {
            
            
        }
    }
}