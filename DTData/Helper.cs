using Autodesk.RevitAddIns;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace DTData
{
    class Helper
    {

        public static RevitProduct GetStartInfo() 
        {

            //获取本地安装的revit版本列表
            List<RevitProduct> revitProducts = RevitProductUtility.GetAllInstalledRevitProducts();

            List<RevitProduct> revits = new List<RevitProduct>();
            foreach (var item in revitProducts)
            {
                if (item.Name=="Revit 2018")
                {
                    revits.Add(item);
                }
            }

            if (revits.Count==0)
            {
                MessageBox.Show("本地未找到安装的revit版本","提示");
            }

            if (revits.Count == 1)
            {
                return revits[0];
            }

            RevitProduct revitProductlast = revits.Last();

            return revitProductlast;



        }


        public static bool CreatAddInFile(RevitProduct revitProduct)
        {


            DirectoryInfo directoryInfo = new DirectoryInfo(revitProduct.AllUsersAddInFolder);
            string path1 = directoryInfo.Parent.FullName;
            string number = revitProduct.Name.TrimStart("AddInsRevit".ToCharArray()).Trim();
            string path2 = Path.Combine(path1,number);
            Directory.CreateDirectory(path2);


            //创建addin文件并修改节点值
            string sourceaddinfile = System.Reflection.Assembly.GetExecutingAssembly().Location;
            sourceaddinfile = Path.GetDirectoryName(sourceaddinfile)+ @"\bin\Debug\Resource\DTData.addin";


            string destaddinfile = Path.Combine(path2, "DTData.addin");

            string binlocation = Helper.BinLocation+ @"\bin\Debug\";

            XElement xerevitaddinfile = XElement.Load(sourceaddinfile);
            XElement xerevitaddin = xerevitaddinfile.Element("AddIn");

            XElement xassembly = xerevitaddin.Element("Assembly");
            string ribbonfilename = xassembly.Value;
            xassembly.Value = Path.Combine(binlocation,ribbonfilename);

            xerevitaddinfile.Save(destaddinfile);

            return true;


        }

        private static string binLocation = string.Empty;
        private static string installLocation = string.Empty;
        public static string BinLocation 
        {
            get 
            {
                if (string.IsNullOrEmpty(binLocation))
                {
                    binLocation = System.Reflection.Assembly.GetExecutingAssembly().Location;
                    binLocation = Path.GetDirectoryName(binLocation);
                }
                return binLocation;
            }
        }

        public static string InstallLocation 
        {
            get 
            {
                if (installLocation==null)
                {
                    installLocation = Path.GetDirectoryName(BinLocation);
                }
                return installLocation;
            }
        }


        public static string DataLocation
        {
            get
            {
                return Path.Combine(InstallLocation);
                //return Path.Combine(InstallLocation, "Resource");
            }
        }



    }
}
