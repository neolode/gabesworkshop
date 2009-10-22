using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace PngSplit
{
    public partial class FrmMain : Form
    {
        Bitmap _buff=null, _bmp=null, _alpha=null;
        public FrmMain()
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
                _buff = new Bitmap(openFileDialog1.FileName);
                _bmp = new Bitmap(_buff.Width, _buff.Height);
                _alpha = new Bitmap(_buff.Width, _buff.Height);
                for (int i = 0; i < _buff.Width; i++)
                {
                    for (int j = 0; j < _buff.Height; j++)
                    {
                        _bmp.SetPixel(i, j, Color.FromArgb(255, _buff.GetPixel(i, j).R, _buff.GetPixel(i, j).G, _buff.GetPixel(i, j).B));
                        _alpha.SetPixel(i, j, Color.FromArgb(255, _buff.GetPixel(i, j).A, _buff.GetPixel(i, j).A, _buff.GetPixel(i, j).A));
                    }
                }
                Application.DoEvents();
                pictureBox1.Image = _buff;
                pictureBox2.Image = _bmp;
                pictureBox3.Image = _alpha;
                label1.Hide();
            }
            else
            {
                saveFileDialog1.Filter = "Portable Network Graphics|*.png";
                saveFileDialog1.Title = "Alpha Png";
                if (_bmp == null) return;
                if (_buff == null) return;
                if (_alpha == null) return;
                if (saveFileDialog1.ShowDialog() != DialogResult.OK) return;
                _buff.Save(saveFileDialog1.FileName, ImageFormat.Png);
                
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (!joinMode.Checked)
            {
                saveFileDialog1.Filter = "Bitmap|*._bmp";
                saveFileDialog1.Title = "24 bit colorChannel";
                if (_bmp == null) return;
                if (saveFileDialog1.ShowDialog() != DialogResult.OK) return;
                _bmp.Save(saveFileDialog1.FileName, ImageFormat.Bmp);
            }
            else
            {
                openFileDialog1.Filter = "Bitmap|*._bmp";
                if (openFileDialog1.ShowDialog() != DialogResult.OK) return;
                _bmp = new Bitmap(openFileDialog1.FileName);
                pictureBox2.Image = _bmp;
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (!joinMode.Checked)
            {
                saveFileDialog1.Filter = "Bitmap|*._bmp";
                if (_alpha == null) return;
                saveFileDialog1.Title = "8 bit alphaChannel";
                if (saveFileDialog1.ShowDialog() != DialogResult.OK) return;
                _alpha.Save(saveFileDialog1.FileName, ImageFormat.Bmp);
            }
            else
            {
                openFileDialog1.Filter = "Bitmap|*._bmp";
                if (openFileDialog1.ShowDialog() != DialogResult.OK) return;
                if (_bmp == null) return;
                label1.Show();
                Application.DoEvents();
                //MessageBox.Show(openFileDialog1.FileName);
                //pictureBox1.ImageLocation = openFileDialog1.FileName;
                _buff = new Bitmap(_bmp.Width, _bmp.Height);
                _alpha = new Bitmap(openFileDialog1.FileName);
                for (int i = 0; i < _bmp.Width; i++)
                {
                    for (int j = 0; j < _bmp.Height; j++)
                    {
                        _buff.SetPixel(i, j, Color.FromArgb(_alpha.GetPixel(i, j).R, _bmp.GetPixel(i, j).R, _bmp.GetPixel(i, j).G, _bmp.GetPixel(i, j).B));
                        //_alpha.SetPixel(i, j, Color.FromArgb(255, _buff.GetPixel(i, j).A, _buff.GetPixel(i, j).A, _buff.GetPixel(i, j).A));
                    }
                }
                Application.DoEvents();
                pictureBox1.Image = _buff;
                pictureBox2.Image = _bmp;
                pictureBox3.Image = _alpha;
                label1.Hide();
            }
        }

        private void joinMode_Click(object sender, EventArgs e)
        {
            
            
        }
    }
}