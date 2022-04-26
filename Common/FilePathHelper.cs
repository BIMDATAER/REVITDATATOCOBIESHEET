using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIMDelivery.Common
{
    class FilePathHelper
    {
        public string SaveFilePathName(string filename,string filter=null,string title=null ) 
        {
            string path = string.Empty;
            System.Windows.Forms.SaveFileDialog saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            if (!string.IsNullOrEmpty(filename))
            {
                saveFileDialog.FileName = filename;
            }
            if (!string.IsNullOrEmpty(filter))
            {
                saveFileDialog.Filter = filter;
            }
            if (!string.IsNullOrEmpty(title))
            {
                saveFileDialog.Title = title;
            }
            if (saveFileDialog.ShowDialog()==System.Windows.Forms.DialogResult.OK)
            {
                path = saveFileDialog.FileName;
            }

            return path;


        }

        public string SelectPath() 
        {
            string path = string.Empty;
            System.Windows.Forms.FolderBrowserDialog folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog()==System.Windows.Forms.DialogResult.OK)
            {
                path = folderBrowserDialog.SelectedPath;
            }
            return path;
        }


        public static string GetResourcePath()
        {
            string resourcepath = string.Empty;
            resourcepath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            resourcepath = Path.GetDirectoryName(resourcepath);
            return resourcepath;
        }


    }
}
