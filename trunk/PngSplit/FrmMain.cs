using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace PngSplit
{
    public partial class FrmMain : Form
    {
        // ReSharper disable InconsistentNaming
        private Bitmap buff, bmp, alpha;
        private readonly Bitmap blank = new Bitmap(1, 1);
        private Stream rd;
        private int i, j;
        private string fname = string.Empty;
        private bool cancel;
        // ReSharper restore InconsistentNaming

        public FrmMain()
        {
            InitializeComponent();
        }

        private void PictureBox1Click(object sender, EventArgs e)
        {
            if (!joinMode.Checked)
            {
                openFile.Filter = "Portable Network Graphics|*.png";
                openFile.FileName = string.Empty;
                openFile.Title = "Open: Png w alpha";
                if (openFile.ShowDialog() != DialogResult.OK) return;
                lblProgress.Text = string.Empty;
                modWorking.Show();
                //
                fname = openFile.FileName.Substring(openFile.FileName.LastIndexOf('\\') + 1);
                fname = fname.Remove(fname.LastIndexOf('.'));
                //MessageBox.Show(fname);
                rd = new FileStream(openFile.FileName, FileMode.Open);
                buff = new Bitmap(rd);
                bmp = new Bitmap(buff.Width, buff.Height);
                alpha = new Bitmap(buff.Width, buff.Height);
                //
                pictureBox1.Image = buff;
                //clear za boxez
                pictureBox2.Image = blank;
                pictureBox3.Image = blank;
                //unlock file
                rd.Close();
                rd.Dispose();
                //so you see stuff happenin
                wrkTime.Start();

                //work
                cancel = false;
                //
                for (i = 0; i < buff.Width; i++)
                {
                    for (j = 0; j < buff.Height; j++)
                    {
                        bmp.SetPixel(i, j,
                                     Color.FromArgb(255, buff.GetPixel(i, j).R, buff.GetPixel(i, j).G,
                                                    buff.GetPixel(i, j).B));
                        alpha.SetPixel(i, j,
                                       Color.FromArgb(255, buff.GetPixel(i, j).A, buff.GetPixel(i, j).A,
                                                      buff.GetPixel(i, j).A));
                        if (!cancel) continue;
                        wrkTime.Stop();
                        modWorking.Hide();
                        bmp.Dispose();
                        alpha.Dispose();
                        return;
                    }
                    Application.DoEvents();
                }
                Application.DoEvents();

                //results
                pictureBox2.Image = bmp;
                pictureBox3.Image = alpha;
                wrkTime.Stop();

                //
                modWorking.Hide();
            }
            else
            {
                saveFile.Filter = "Portable Network Graphics|*.png";
                saveFile.Title = "Save: Png w alpha";
                saveFile.FileName = fname;
                if (bmp == null) return;
                if (buff == null) return;
                if (alpha == null) return;
                if (saveFile.ShowDialog() != DialogResult.OK) return;
                //
                rd = new FileStream(saveFile.FileName, FileMode.Create);
                buff.Save(rd, ImageFormat.Png);
                //unlock file
                rd.Flush();
                rd.Close();
                rd.Dispose();
            }
        }


        private void PictureBox2Click(object sender, EventArgs e)
        {
            if (!joinMode.Checked)
            {
                saveFile.Filter = "Bitmap|*.bmp";
                saveFile.Title = "Open: Color channel bitmap";
                saveFile.FileName = fname + "_color";
                if (bmp == null) return;
                if (saveFile.ShowDialog() != DialogResult.OK) return;
                //
                rd = new FileStream(saveFile.FileName, FileMode.Create);
                bmp.Save(rd, ImageFormat.Bmp);
                //unlock file
                rd.Flush();
                rd.Close();
                rd.Dispose();
            }
            else
            {
                openFile.Filter = "Bitmap|*.bmp|All|*.*";
                openFile.Title = "Open: Color channel bitmap";
                openFile.FileName = string.Empty;
                if (openFile.ShowDialog() != DialogResult.OK) return;

                fname = openFile.FileName.Substring(openFile.FileName.LastIndexOf('\\') + 1);
                fname = fname.Remove(fname.LastIndexOf('.'));
                fname = fname.Replace("_color", string.Empty);
                fname = fname.Replace("_alpha", string.Empty);
                MessageBox.Show(fname);
                rd = new FileStream(openFile.FileName, FileMode.Open);
                bmp = new Bitmap(rd);
                pictureBox2.Image = bmp;
                //
                pictureBox1.Image = blank;
                pictureBox3.Image = blank;
                //unlock file
                rd.Close();
                rd.Dispose();
            }
        }

        private void PictureBox3Click(object sender, EventArgs e)
        {
            if (!joinMode.Checked)
            {
                saveFile.Filter = "Bitmap|*.bmp";
                if (alpha == null) return;
                saveFile.Title = "Save: Alpha channel bitmap";
                saveFile.FileName = fname + "_alpha";
                if (saveFile.ShowDialog() != DialogResult.OK) return;
                //
                rd = new FileStream(saveFile.FileName, FileMode.Create);
                alpha.Save(rd, ImageFormat.Bmp);
                //unlock file
                rd.Flush();
                rd.Close();
                rd.Dispose();
            }
            else
            {
                openFile.Filter = "Bitmap|*.bmp|All|*.*";
                openFile.Title = "Open: Alpha channel bitmap";
                openFile.FileName = string.Empty;
                if (openFile.ShowDialog() != DialogResult.OK) return;
                if (bmp == null) return;
                lblProgress.Text = string.Empty;
                modWorking.Show();

                buff = new Bitmap(bmp.Width, bmp.Height);
                //alpha = new Bitmap(openFile.FileName);
                rd = new FileStream(openFile.FileName, FileMode.Open);
                alpha = new Bitmap(rd);
                pictureBox3.Image = alpha;
                //unlock file
                rd.Close();
                rd.Dispose();
                //
                wrkTime.Start();
                //
                cancel = false;
                //
                for (i = 0; i < bmp.Width; i++)
                {
                    for (j = 0; j < bmp.Height; j++)
                    {
                        buff.SetPixel(i, j,
                                      Color.FromArgb(alpha.GetPixel(i, j).R, bmp.GetPixel(i, j).R, bmp.GetPixel(i, j).G,
                                                     bmp.GetPixel(i, j).B));
                        if (!cancel) continue;
                        wrkTime.Stop();
                        modWorking.Hide();
                        buff.Dispose();
                        return;
                    }
                    Application.DoEvents();
                }
                Application.DoEvents();
                pictureBox1.Image = buff;

                wrkTime.Stop();
                modWorking.Hide();
            }
        }

        private void JoinModeCheckedChanged(object sender, EventArgs e)
        {
            joinMode.Text = joinMode.Checked ? "Join Mode [x]" : "Join Mode [ ]";
            pictureBox1.Image = blank;
            pictureBox2.Image = blank;
            pictureBox3.Image = blank;
        }

        private void WrkTimeTick(object sender, EventArgs e)
        {
            lblProgress.Text = "Progress: " + (int) (((float) i/buff.Width)*100) + "%";
            Application.DoEvents();
        }

        private void ModWorkingClick(object sender, EventArgs e)
        {
            if (MessageBox.Show("Cancel operation ?", "Question", MessageBoxButtons.YesNo) != DialogResult.Yes) return;
            cancel = true;
        }
    }
}