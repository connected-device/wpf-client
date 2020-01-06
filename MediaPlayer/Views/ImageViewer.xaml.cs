using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
//using System.Windows.Shapes;

namespace MediaPlayer.Views
{
    /// <summary>
    /// Interaction logic for ImageViewer.xaml
    /// </summary>
    public partial class ImageViewer : UserControl
    {
        public ImageViewer()
        {
            InitializeComponent();
            //ImageViewerControl.Source = new BitmapImage(new Uri(String.Format("file:///{0}/contents/a1.jpg", System.AppDomain.CurrentDomain.BaseDirectory)));
            ImageViewerControl.Source = new BitmapImage(new Uri(String.Format("file:///{0}/contents/a1.jpg", System.AppDomain.CurrentDomain.BaseDirectory)));
        }
    }
}
