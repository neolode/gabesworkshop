using System;
using System.Windows.Forms;
using System.IO;
using JsonExSerializer;

namespace SoftDB
{
    public partial class frmVaults : Form
    {
        private const string ChExcude = "~`!@#$%^&*()+=[]{};'\\:\"|,./<>?\n\r ";

        public frmVaults()
        {
            InitializeComponent();
            Height = 278;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            Height = 348;
            btnNew.Tag = true;
            //dissable new,edit,delete
            btnNew.Enabled = false;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Height = 348;
            //dissable new,edit,delete
            btnNew.Enabled = false;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((bool)btnNew.Tag)
            {
                FrmMain.Lists.Vaults.Add(new SoftListInfo { Title = textBox1.Text, Vault = textBox2.Text });
                Serialization(typeof(SoftList), textBox2.Text, new SoftList());
            }
            Height = 278;
            //enable edit butons
            btnNew.Enabled = true;
            btnEdit.Enabled = true;
            btnDelete.Enabled = true;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Height = 278;
            //enable edit butons
            btnNew.Enabled = true;
            btnEdit.Enabled = true;
            btnDelete.Enabled = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (File.Exists(Application.StartupPath + @"\" + textBox1.Text + ".vault"))
            {
                _dbl = 0;
                textBox2.Text = GetFilename();
            }
            else
            {
                _dbl = 0;
                textBox2.Text = GetFilename();
            }
        }

        private int _dbl;
        private string GetFilename()
        {
            var f = textBox1.Text.ToLower().Replace(' ', '_');

            foreach (var c in ChExcude)
            {
                f = f.Replace(c, '_');
            }
            f += _dbl > 0 ? _dbl + ".vault" : ".vault";
            _dbl++;
            return File.Exists(Application.StartupPath + @"\" + f) ? GetFilename() : f;
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
    }
}
