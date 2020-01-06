using MediaPlayer.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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
using Path = System.IO.Path;

namespace MediaPlayer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        public static void UpdateSelf(byte[] buffer)
        {
            var self = System.Reflection.Assembly.GetExecutingAssembly().Location;

            if (Environment.OSVersion.Platform == PlatformID.Unix ||
                    Environment.OSVersion.Platform == PlatformID.MacOSX)
            {
                File.WriteAllBytes(self, buffer);

                Process.Start(self);

                // Sleep for half a second to avoid an exception
                Thread.Sleep(500);
                Environment.Exit(0);
            }
            else
            {
                var selfFileName = Path.GetFileName(self);
                var selfWithoutExt = Path.Combine(Path.GetDirectoryName(self),
                                            Path.GetFileNameWithoutExtension(self));
                File.WriteAllBytes(selfWithoutExt + "Update.exe", buffer);

                using (var batFile = new StreamWriter(File.Create(selfWithoutExt + "Update.bat")))
                {
                    batFile.WriteLine("@ECHO OFF");
                    batFile.WriteLine("TIMEOUT /t 1 /nobreak > NUL");
                    batFile.WriteLine("TASKKILL /IM \"{0}\" > NUL", selfFileName);
                    batFile.WriteLine("MOVE \"{0}\" \"{1}\"", selfWithoutExt + "Update.exe", self);
                    batFile.WriteLine("DEL \"%~f0\" & START \"\" /B \"{0}\"", self);
                }

                ProcessStartInfo startInfo = new ProcessStartInfo(selfWithoutExt + "Update.bat");
                // Hide the terminal window
                startInfo.CreateNoWindow = true;
                startInfo.UseShellExecute = false;
                startInfo.WorkingDirectory = Path.GetDirectoryName(self);
                Process.Start(startInfo);

                Environment.Exit(0);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var fileName = "Update.exe";
            if (File.Exists(fileName))
            {
                Console.WriteLine("File exists...");
                var file = System.IO.File.ReadAllBytes(fileName);
                UpdateSelf(file);
            }
            else
            {
                Console.WriteLine("File not exists...");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Viewer.Content = new ImageViewer();
        }
        private void Button_Click_Video(object sender, RoutedEventArgs e)
        {
            this.Viewer.Content = new VideoViewer();
        }
    }
}
