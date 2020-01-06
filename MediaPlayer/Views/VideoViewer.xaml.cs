using System;
using System.Collections.Generic;
using System.Linq;
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
using System.Windows.Shapes;

namespace MediaPlayer.Views
{
    /// <summary>
    /// Interaction logic for VideoViewer.xaml
    /// </summary>
    public partial class VideoViewer : UserControl
    {
        public VideoViewer()
        {
            InitializeComponent();

            MediaElementViewer.LoadedBehavior = MediaState.Manual;
            MediaElementViewer.Source = new Uri(String.Format("file:///{0}/contents/a3.mp4", System.AppDomain.CurrentDomain.BaseDirectory));
            //@ means that the string behind is a path so / won't be 
            //treated like a special character
            MediaElementViewer.Play();
        }
    }
}
