using System;
using System.Windows.Forms;
using System.IO;

namespace CapturePicture
{
    static class Program
    {
        
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            string directoryOfPictures = "Pics";
            string directoryOfProgram = Application.StartupPath;
            string directoryOfPicturesAbsoluate = directoryOfProgram + "\\" + directoryOfPictures + "\\";
            string pictureName = DateTime.Now.ToString("yyyy_MM_dd__hh_mm_ss") + ".bmp";
            string picturePathAbsoluate = directoryOfPicturesAbsoluate + pictureName;

            if (!Directory.Exists(directoryOfPicturesAbsoluate)) Directory.CreateDirectory(directoryOfPicturesAbsoluate);
            Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true).SetValue(Application.ProductName, Application.ExecutablePath);

            new Emgu.CV.Capture().QueryFrame().Save(picturePathAbsoluate);
        }
    }
}
