using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace MishnatYosef.BLL
{
    public class MyPicture
    {
        public static BitmapImage GetImage(string name)
        {
            if (name == null || name == " ")
                return null;
            string path = Directory.GetCurrentDirectory();
            path = Directory.GetParent(Directory.GetParent(path).FullName).FullName + @"\Picture\" + name;
            if (File.Exists(path))
            {
                return new BitmapImage(new Uri(path));
            }
            return null;
        }
        public static string LoadingImg()
        {
            string fileNme = null;
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "All Images|*.jpg;*.png;*.gif;*.bmp;*.tiff";
            Nullable<bool> result = dlg.ShowDialog();
            if (result == true)
            {
                fileNme = dlg.SafeFileName;
                string path = Directory.GetCurrentDirectory();
                path = Directory.GetParent(Directory.GetParent(path).FullName).FullName + @"\Picture\" + dlg.SafeFileName;
                if (!File.Exists(path))
                {
                    File.Copy(dlg.FileName, path);
                }
            }
            return fileNme;
        }
    }
}

