using System.Collections.Generic;
using System.Xml.Serialization;

namespace SoftDB
{
    [XmlRoot("Lists")]
    public class SoftLists
    {
        /// <summary>
        /// Last opened .vault
        /// </summary>
        [XmlAttribute("lastOpened")]
        public string Last { get; set; }

        [XmlElement("List")]
        public List<SoftListInfo> Vaults { get; set; }

        public SoftLists()
        {
            Vaults = new List<SoftListInfo>();
        }
    }

    [XmlRoot("Software")]
    public class SoftList : List<SoftItem>
    {}

    public class SoftListInfo
    {
        [XmlAttribute("file")]
        public string Vault { get; set; }

        [XmlAttribute("name")]
        public string Title { get; set; }
    }

    public class SoftItem
    {
        public SoftItem()
        {
            Boxart = string.Empty;
            Title = string.Empty;
            Description = string.Empty;
            Location = string.Empty;
        }

        [XmlAttribute("location")]
        public string Location { get; set; }

        [XmlElement("description")]
        public string Description { get; set; }

        [XmlAttribute("title")]
        public string Title { get; set; }

        [XmlElement("boxart")]
        public string Boxart { get; set; }
    }

    public class Options
    {
        public Options()
        {
            MaxH = 512;
            MaxW = 512;
        }

        public int Order { get; set; }

        public int MaxW { get; set; }

        public int MaxH { get; set; }
    }
   //eof
}
