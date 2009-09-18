using System;
using System.Collections;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using JsonExSerializer;

namespace SoftDB
{
    public partial class FrmMain : Form
    {
        public static SoftLists Lists;// = new SoftLists();
        public static SoftList Data;// = new SoftList();
        private static Options _setings = new Options();
        // ReSharper disable FieldCanBeMadeReadOnly.Local
        private string _welcome;
        // ReSharper restore FieldCanBeMadeReadOnly.Local
        public FrmMain()
        {
            InitializeComponent();
            Bridge.BuffImage = Properties.Resources.aboutimg;
            _welcome = Bridge.HtmlTpl.Replace("{title}", "Welcome to " + Application.ProductName);
            _welcome = _welcome.Replace("{loc}", "ver. " + Application.ProductVersion);
            _welcome = _welcome.Replace("{desc}", "Copyright ©  2009 2project");
            htmlDetails.Text = _welcome;

        }

        public static Options Setings
        {
            get { return _setings; }
        }

        private void btnBarSearch_Click(object sender, EventArgs e)
        {
            menuSearch.Show(MousePosition);
        }

        private bool _lock;
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (!_lock) DisplayList(Data);
            if (txtSearch.Text == string.Empty)
            {

                return;
            }
            _lock = true;
            var txbuff = txtSearch.Text.ToLower();
            string lstbuff;

            for (var i = 0; i < lstSoftware.Items.Count; i++)
            {
                lstbuff = lstSoftware.Items[i].Text.ToLower();
                bool conbuff = !lstbuff.Contains(txbuff);
                //MessageBox.Show(txbuff + " - " + conbuff + " - " + lstbuff);
                if (!conbuff) continue;
                lstSoftware.Items.RemoveAt(i);
                i--;
            }
            _lock = false;
            //Bridge.BuffImage = Bridge.DefaultImage;//_data.DefaultBoxArt;
            //htmlDetails.Text = Bridge.HtmlTpl.Replace("{title}", txtSearch.Text);
            //htmlDetails.Text = txtSearch.Text + "<img src=\"property:SoftDB.Bridge.BuffImage\" />";

        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            var about = new frmAbout();
            about.ShowDialog(this);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void xToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnBarSearch_Click(sender, e);
        }

        private void yToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Insert");
            var itm = new FrmItem();
            if (itm.Show4Item(this) != DialogResult.OK) return;
            Data.Add(itm.Item);
            Serialization(typeof(SoftList), @"/" + Lists.Last, Data);
            DisplayList(Data);

        }

        private void zToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Edit");
            if (lstSoftware.SelectedItems.Count <= 0) return;
            int idx = int.Parse(lstSoftware.SelectedItems[0].SubItems[2].Text);
            var itm = new FrmItem { Item = Data[idx] };
            if (itm.Show4Item(this) != DialogResult.OK) return;
            Data[idx] = itm.Item;
            Serialization(typeof(SoftList), @"/" + Lists.Last, Data);
            DisplayList(Data);
        }

        private void zzToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Delete");
            if (lstSoftware.SelectedItems.Count <= 0) return;
            foreach (ListViewItem s in lstSoftware.SelectedItems)
            {
                int idx = int.Parse(s.SubItems[2].Text);
                if (Data[idx].Boxart != string.Empty)
                {
                    if (IsUnUsed(Data[idx].Boxart))
                        File.Delete(Application.StartupPath + @"\images\" + Data[idx].Boxart);
                }
                Data.RemoveAt(idx);
            }
            Serialization(typeof(SoftList), @"/" + Lists.Last, Data);
            DisplayList(Data);
        }
        private static bool IsUnUsed(string boxart)
        {
            int usg = -1;
            foreach (var item in Data)
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
        #region XML Stuffz
        // ReSharper disable MemberCanBeMadeStatic.Local
        private void Serialization(Type type, String path, object data)
        {
            var s = new Serializer(type);
            //XmlSerializer s = new XmlSerializer(/*typeof(TypeSoftList)*/type);
            TextWriter w = new StreamWriter(Application.StartupPath + path/*@"/soft.vault"*/);
            //s.Serialize(w, data);
            //w.Close();

            //w = new StreamWriter(Application.StartupPath + path+".jsx"/*@"/soft.vault"*/);
            s.Serialize(data, w);
            w.Close();
        }
        private object DeSerialization(Type type, String path)
        {

            if (File.Exists(Application.StartupPath + path/*@"/soft.vault"*/))
            {
                var s = new Serializer(/*typeof(TypeSoftList)*/type);
                TextReader r = new StreamReader(Application.StartupPath + path/*@"/soft.vault"*/);
                var data = s.Deserialize(r);
                r.Close();
                return data;
            }
            return null;
        }
        // ReSharper restore MemberCanBeMadeStatic.Local
        #endregion

        // ReSharper disable SuggestBaseTypeForParameter
        private void DisplayList(SoftList data)
        // ReSharper restore SuggestBaseTypeForParameter
        {
            lstSoftware.Items.Clear();
            lstSoftware.OwnerDraw = true;
            lstSoftware.SuspendLayout();
            ListViewItem x;
            for (int i = 0; i < data.Count; i++)
            {
                x = new ListViewItem(data[i].Title);
                x.SubItems.Add(data[i].Location);
                x.SubItems.Add(i.ToString());
                lstSoftware.Items.Add(x);
            }
            lstSoftware.OwnerDraw = false;
            lstSoftware.ResumeLayout();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            if (!Directory.Exists(Application.StartupPath + @"\images"))
                Directory.CreateDirectory(Application.StartupPath + @"\images");
            //
            Lists = (SoftLists)DeSerialization(typeof(SoftLists), @"/soft.idx");
            if (Lists == null)
            {
                Lists = new SoftLists();
                var x = new SoftListInfo { Title = "Software", Vault = "soft.vault" };
                Lists.Vaults.Add(x);
                Lists.Last = x.Vault;

                Serialization(typeof(SoftLists), @"/soft.idx", Lists);
            }
            Data = (SoftList)DeSerialization(typeof(SoftList), @"/" + Lists.Last);
            if (Data == null)
            {
                Data = new SoftList();
                Serialization(typeof(SoftList), @"/" + Lists.Last, Data);
            }
            DisplayList(Data);

            _setings = (Options)DeSerialization(typeof(Options), @"/app.setings");
            if (Setings == null)
            {
                _setings = new Options();
            }
            Serialization(typeof(Options), @"/app.setings", Setings);
            if (Setings != null)
                lstSoftware.ListViewItemSorter = Setings.Order >= lstSoftware.Items.Count ? new ListViewItemComparer() : new ListViewItemComparer(Setings.Order);
            lstSoftware.Sort();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Serialization();
            Serialization(typeof(Options), @"/app.setings", Setings);
        }

        private void lstSoftware_SelectedIndexChanged(object sender, EventArgs e)
        {
            //htmlDetails.Text = _welcome;
            if (lstSoftware.SelectedItems.Count <= 0) return;

            int idx = int.Parse(lstSoftware.SelectedItems[0].SubItems[2].Text);

            DrawDetails(idx);
        }

        private void DrawDetails(int idx)
        {
            string buff = Bridge.HtmlTpl.Replace("{title}", Data[idx].Title);
            buff = buff.Replace("{loc}", Data[idx].Location);
            buff = buff.Replace("{desc}", Data[idx].Description);

            FileStream fx;

            if (Data[idx].Boxart != string.Empty)
            {
                fx = new FileStream(Application.StartupPath + @"\images\" + Data[idx].Boxart, FileMode.Open);
                Bridge.BuffImage = (Bitmap)Image.FromStream(fx);
                //FromFile(Application.StartupPath + @"\images\"+_data[idx].Boxart);
                fx.Close();
            }
            else
                Bridge.BuffImage = Properties.Resources.Blank;

            htmlDetails.Text = buff;
        }

        private void selectVaultToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var v = new frmVaults();
            v.ShowDialog(this);
            Data = (SoftList)DeSerialization(typeof(SoftList), @"/" + Lists.Last);
            DisplayList(Data);
        }

        private void lstSoftware_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            lstSoftware.ListViewItemSorter = new ListViewItemComparer(e.Column);
            lstSoftware.Sort();
            _setings.Order = e.Column;
        }

        private class ListViewItemComparer : IComparer
        {
            // ReSharper disable FieldCanBeMadeReadOnly.Local
            private int _col;
            // ReSharper restore FieldCanBeMadeReadOnly.Local
            public ListViewItemComparer()
            {
                _col = 0;
            }
            public ListViewItemComparer(int column)
            {
                _col = column < 0 ? 0 : column;

            }

            public int Compare(object x, object y)
            {
                // ReSharper disable RedundantAssignment
                int returnVal = -1;
                // ReSharper restore RedundantAssignment
                returnVal = String.Compare(((ListViewItem)x).SubItems[_col].Text,
                ((ListViewItem)y).SubItems[_col].Text);
                return returnVal;
            }

        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtSearch.Text = string.Empty;
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            //MessageBox.Show(e.KeyChar.ToString());
        }

        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode== Keys.Escape)
            //{
            //    txtSearch.Text = string.Empty;
            //}
        }
    }

}
