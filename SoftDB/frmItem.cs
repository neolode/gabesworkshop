using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace SoftDB
{
    public partial class FrmItem : Form
    {
        private SoftItem _buff = new SoftItem();
        private DialogResult _defaultResult = DialogResult.Cancel;
        private bool _remold;
        private string _bkbmp = String.Empty;
        private const string ChExcude = "~`!@#$%^&*()+=[]{};'\\:\"|,./<>?\n\r ";
        private string _pth;// = openImage.InitialDirectory;
        public FrmItem()
        {
            _remold = false;
            InitializeComponent();
        }

        public SoftItem Item
        {
            get { return _buff; }
            set { _buff = value; }
        }

        public DialogResult Show4Item(IWin32Window parent)
        {
            picBoxart.InitialImage = null;
            picBoxart.ErrorImage = null;
            picBoxart.Image = null;

            txtTitle.Text = Item.Title;
            txtLoc.Text = Item.Location;
            txtDesc.Text = Item.Description;
            if (Item.Boxart != null)
                picBoxart.ImageLocation = Application.StartupPath + @"\images\" + Item.Boxart;
            ShowDialog(parent);
            Item.Title = txtTitle.Text;
            Item.Location = txtLoc.Text;
            Item.Description = txtDesc.Text;
            //if (picBoxart.Image != null)
            //    Item.Boxart = (Bitmap) picBoxart.Image;
            return _defaultResult;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            string img = picBoxart.ImageLocation;
            bool dob = false;
            if (img.StartsWith(Application.StartupPath + @"\images\") && File.Exists(img))
                dob = true;

            var rx = new Random();
            string path = Application.StartupPath + @"\images\";
            string filename = !dob ? GetFilename(rx, path) : img.Substring(img.LastIndexOf('\\') + 1);

            if (txtTitle.Text == string.Empty)
            {
                MessageBox.Show("No title provided");
                return;
            }
            //fuking retard made me dissable this on acount hes a lazzy fuck
            //if (txtLoc.Text == string.Empty)
            //{
            //    MessageBox.Show("No location provided");
            //    return;
            //}
            if (picBoxart.Image != null)
            {
                Image buff = picBoxart.Image;
                if (picBoxart.Image.Size.Height > FrmMain.Setings.MaxH || picBoxart.Image.Size.Width > FrmMain.Setings.MaxW)
                    buff = ResizeImage(picBoxart.Image, new Size(FrmMain.Setings.MaxW, FrmMain.Setings.MaxH));
                if (!dob)
                    buff.Save(path + filename, ImageFormat.Png);
                if (_remold)
                {
                    if (IsUnUsed(Item.Boxart))
                        File.Delete(path + Item.Boxart);
                }
                Item.Boxart = filename;
            }
            if (_bkbmp != string.Empty)
            {

                try
                {
                    var fx = new FileStream(_bkbmp, FileMode.Open);
                    Bridge.BuffImage = (Bitmap)Image.FromStream(fx);
                    Bridge.BuffImage.Save(path + filename, ImageFormat.Png);
                }
                catch (Exception x)
                {
                    MessageBox.Show("Exception:\n" + x.Message + "\n\n" +
                        "It seems the image still diden't load" +
                        "\nYou shoud try converting the image to another format");
                }
                if (_remold)
                {
                    if (IsUnUsed(Item.Boxart))
                        File.Delete(path + Item.Boxart);
                }
                Item.Boxart = filename;
            }
            _defaultResult = DialogResult.OK;
            Close();
        }
        private static Image ResizeImage(Image imgToResize, Size size)
        {
            int sourceWidth = imgToResize.Width;
            int sourceHeight = imgToResize.Height;

            // ReSharper disable RedundantAssignment
            float nPercent = 0;
            float nPercentW = 0;
            float nPercentH = 0;
            // ReSharper restore RedundantAssignment
            nPercentW = ((float)size.Width / sourceWidth);
            nPercentH = ((float)size.Height / sourceHeight);

            nPercent = nPercentH < nPercentW ? nPercentH : nPercentW;

            var destWidth = (int)(sourceWidth * nPercent);
            var destHeight = (int)(sourceHeight * nPercent);

            var b = new Bitmap(destWidth, destHeight);
            var g = Graphics.FromImage(b);
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;

            g.DrawImage(imgToResize, 0, 0, destWidth, destHeight);
            g.Dispose();

            return b;
        }
        private string GetFilename(Random rx, string path)
        {
            var f = txtTitle.Text.ToLower().Replace(' ', '_');

            foreach (var c in ChExcude)
            {
                f = f.Replace(c, '_');
            }

            f += rx.Next(1000, 9999) + ".png";
            return File.Exists(path + f) ? GetFilename(rx, path) : f;
        }

        private void picBoxart_MouseEnter(object sender, EventArgs e)
        {
        }

        private void picBoxart_MouseLeave(object sender, EventArgs e)
        {
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            bool ck1 = false;
            if (picBoxart.Image != null)
                ck1 = true;
            if (openImage.ShowDialog() != DialogResult.OK) return;
            if (openImage.FileName.StartsWith(Application.StartupPath + @"\images"))
            {
                MessageBox.Show("You can't load images from :\n"
                    + Application.StartupPath
                    + @"\images" + "\nPlease use the \":::\" option for this");
                return;
            }
            try
            {
                picBoxart.ImageLocation = openImage.FileName;
                //throw new Exception("testing");
            }
            catch (Exception x)
            {
                MessageBox.Show("Exception:\n" + x.Message + "\n\n" +
                    "The aplication has saved the image path and will try an alternative way of loading" +
                    "\nPlease note that the image might not show");
                _bkbmp = openImage.FileName;
                picBoxart.Image = null;
            }
            if (ck1) _remold = true;
        }

        private void xToolStripMenuItem_Click(object sender, EventArgs e)
        {
            picBoxart.Image = null;
            if (File.Exists(Application.StartupPath + @"\images\" + Item.Boxart))
            {
                if (IsUnUsed(Item.Boxart))
                    File.Delete(Application.StartupPath + @"\images\" + Item.Boxart);
            }

            Item.Boxart = string.Empty;
        }

        private static bool IsUnUsed(string boxart)
        {
            int usg = -1;
            foreach (var item in FrmMain.Data)
            {
                if (item.Boxart.Equals(boxart))
                {
                    usg++;
                }
                if (usg == 1)
                {
                    return false;
                }
            }
            return true;
        }

        private void FrmItem_Load(object sender, EventArgs e)
        {
            _pth = openImage.InitialDirectory;
        }

        private void previousMenuItem_Click(object sender, EventArgs e)
        {
            bool ck1 = false;
            if (picBoxart.Image != null)
                ck1 = true;
            openImage.InitialDirectory = Application.StartupPath + @"\images";
            if (openImage.ShowDialog() != DialogResult.OK) return;
            if (!openImage.FileName.StartsWith(Application.StartupPath + @"\images"))
            {
                MessageBox.Show("You can't load images outside of :\n"
                    + Application.StartupPath
                    + @"\images" + "\nPlease use the \"...\" option for this");
                return;
            }
            try
            {
                picBoxart.ImageLocation = openImage.FileName;
                //throw new Exception("testing");
            }
            catch (Exception x)
            {
                MessageBox.Show("Exception:\n" + x.Message + "\n\n" +
                    "The aplication has saved the image path and will try an alternative way of loading" +
                    "\nPlease note that the image might not show");
                _bkbmp = openImage.FileName;
                picBoxart.Image = null;
            }
            if (ck1) _remold = true;
            openImage.InitialDirectory = _pth;
        }
    }
}
