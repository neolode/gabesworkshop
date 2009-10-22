using System.Drawing;

namespace SoftDB
{
    public static class Bridge
    {
        /// <summary>
        /// Gets the stylesheet for documents
        /// </summary>
        public static string StyleSheet
        {
            get
            {
                return @Properties.Resources.css;
            }
        }

        public static string HtmlTpl
        {
            get
            {
                return Properties.Resources.tpl;
            }
        }
        /// <summary>
        /// Gets a blank image
        /// </summary>
        public static Bitmap DefaultImage
        {
            get { return Properties.Resources.Blank; }
        }

        public static Bitmap BuffImage { get; set; }
    }
}