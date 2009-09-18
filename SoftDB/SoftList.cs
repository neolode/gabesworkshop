using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Drawing;

namespace SoftDB
{
    [XmlRoot("Lists")]
    public class SoftLists
    {
        private string _last;
        /// <summary>
        /// Last opened .vault
        /// </summary>
        [XmlAttribute("lastOpened")]
        public string Last
        {
            get { return _last; }
            set { _last = value; }
        }
        [XmlElement("List")]
        public List<SoftListInfo> Vaults
        {
            get { return _vaults; }
            set { _vaults = value; }
        }

        private List<SoftListInfo> _vaults=new List<SoftListInfo>();

    }

    [XmlRoot("Software")]
    public class SoftList : List<SoftItem>
    {}

    public class SoftListInfo
    {
        private string _vault;
        private string _title;
        [XmlAttribute("file")]
        public string Vault
        {
            get { return _vault; }
            set { _vault = value; }
        }
        [XmlAttribute("name")]
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }
    }

    public class SoftItem
    {
        private string _title = string.Empty;
        private string _description = string.Empty;
        private string _location = string.Empty;
        private string _boxart = string.Empty;

        [XmlAttribute("location")]
        public string Location
        {
            get { return _location; }
            set { _location = value; }
        }
        [XmlElement("description")]
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
        [XmlAttribute("title")]
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }
        [XmlElement("boxart")]
        public string Boxart
        {
            get { return _boxart; }
            set { _boxart = value; }
        }
    }

    public class Options
    {
        private int _maxW = 512;
        private int _maxH = 512;

        public int Order { get; set; }

        public int MaxW
        {
            get { return _maxW; }
            set { _maxW = value; }
        }

        public int MaxH
        {
            get { return _maxH; }
            set { _maxH = value; }
        }
    }
   //eof
}
