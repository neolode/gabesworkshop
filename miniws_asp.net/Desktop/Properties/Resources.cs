namespace ScrewTurn.Wiki.Desktop.Properties
{
    using System;
    using System.CodeDom.Compiler;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Drawing;
    using System.Globalization;
    using System.Resources;
    using System.Runtime.CompilerServices;

    [DebuggerNonUserCode, CompilerGenerated, GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "2.0.0.0")]
    internal class Resources
    {
        private static CultureInfo resourceCulture;
        private static System.Resources.ResourceManager resourceMan;

        internal Resources()
        {
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        internal static CultureInfo Culture
        {
            get
            {
                return resourceCulture;
            }
            set
            {
                resourceCulture = value;
            }
        }

        internal static Bitmap Exit
        {
            get
            {
                return (Bitmap) ResourceManager.GetObject("Exit", resourceCulture);
            }
        }

        internal static Bitmap Info
        {
            get
            {
                return (Bitmap) ResourceManager.GetObject("Info", resourceCulture);
            }
        }

        internal static Bitmap Open
        {
            get
            {
                return (Bitmap) ResourceManager.GetObject("Open", resourceCulture);
            }
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        internal static System.Resources.ResourceManager ResourceManager
        {
            get
            {
                if (object.ReferenceEquals(resourceMan, null))
                {
                    System.Resources.ResourceManager manager = new System.Resources.ResourceManager("ScrewTurn.Wiki.Desktop.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = manager;
                }
                return resourceMan;
            }
        }

        internal static Bitmap ScrewTurnWiki
        {
            get
            {
                return (Bitmap) ResourceManager.GetObject("ScrewTurnWiki", resourceCulture);
            }
        }

        internal static Bitmap Settings
        {
            get
            {
                return (Bitmap) ResourceManager.GetObject("Settings", resourceCulture);
            }
        }

        internal static Bitmap Start
        {
            get
            {
                return (Bitmap) ResourceManager.GetObject("Start", resourceCulture);
            }
        }

        internal static Bitmap Stop
        {
            get
            {
                return (Bitmap) ResourceManager.GetObject("Stop", resourceCulture);
            }
        }

        internal static Bitmap WebConfig
        {
            get
            {
                return (Bitmap) ResourceManager.GetObject("WebConfig", resourceCulture);
            }
        }

        internal static Icon WikiSmall
        {
            get
            {
                return (Icon) ResourceManager.GetObject("WikiSmall", resourceCulture);
            }
        }

        internal static Icon WikiSmallGray
        {
            get
            {
                return (Icon) ResourceManager.GetObject("WikiSmallGray", resourceCulture);
            }
        }
    }
}

