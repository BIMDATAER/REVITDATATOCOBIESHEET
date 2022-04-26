using Autodesk.Revit.UI;
using Autodesk.RevitAddIns;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.Imaging;

namespace BIMDelivery
{
    public class APPRibbon : IExternalApplication
    {
        public Result OnShutdown(UIControlledApplication application)
        {
            DeleteAddinFile();
            return Result.Succeeded;
        }

        public Result OnStartup(UIControlledApplication application)
        {
            application.CreateRibbonTab("DTData");
            RibbonPanel panel = application.CreateRibbonPanel("DTData","登录");
            RibbonPanel panel2 = application.CreateRibbonPanel("DTData", "数据处理");
            RibbonPanel panel3 = application.CreateRibbonPanel("DTData", "导出");
            RibbonPanel panel4 = application.CreateRibbonPanel("DTData", "web服务");

            string assemblypath = System.Reflection.Assembly.GetExecutingAssembly().Location;

            string classname1 = "BIMDelivery.Command.ContactCommand";
            PushButtonData pushButtonData1 = new PushButtonData("联系人","联系人",assemblypath,classname1);
            pushButtonData1.LargeImage = new BitmapImage(new Uri("pack://application:,,,/BIMDelivery;component/Image/联系人.png"));
            PushButton pushButton1 = panel.AddItem(pushButtonData1) as PushButton;

            string classname9 = "BIMDelivery.Command.AboutCommand";
            PushButtonData pushButtonData9 = new PushButtonData("关于", "关于", assemblypath, classname9);
            pushButtonData9.LargeImage = new BitmapImage(new Uri("pack://application:,,,/BIMDelivery;component/Image/关于.png"));
            PushButton pushButton9 = panel.AddItem(pushButtonData9) as PushButton;

            string classname2 = "BIMDelivery.Command.ParamAssociation";
            PushButtonData pushButtonData2 = new PushButtonData("参数绑定", "参数绑定", assemblypath, classname2);
            pushButtonData2.LargeImage = new BitmapImage(new Uri("pack://application:,,,/BIMDelivery;component/Image/参数绑定.png"));
            PushButton pushButton2 = panel2.AddItem(pushButtonData2) as PushButton;

            string classname3 = "BIMDelivery.Command.ValueSettings";
            PushButtonData pushButtonData3 = new PushButtonData("属性设置", "属性设置", assemblypath, classname3);
            pushButtonData3.LargeImage = new BitmapImage(new Uri("pack://application:,,,/BIMDelivery;component/Image/属性设置.png"));
            PushButton pushButton3 = panel2.AddItem(pushButtonData3) as PushButton;


            string classname4 = "BIMDelivery.Command.WriteParamValue";
            PushButtonData pushButtonData4 = new PushButtonData("属性载入", "属性载入", assemblypath, classname4);
            pushButtonData4.LargeImage = new BitmapImage(new Uri("pack://application:,,,/BIMDelivery;component/Image/属性载入.png"));
            PushButton pushButton4 = panel2.AddItem(pushButtonData4) as PushButton;


            string classname5 = "BIMDelivery.Command.AssetSelectingCommand";
            PushButtonData pushButtonData5 = new PushButtonData("资产选择", "资产选择", assemblypath, classname5);
            pushButtonData5.LargeImage = new BitmapImage(new Uri("pack://application:,,,/BIMDelivery;component/Image/资产选择.png"));
            PushButton pushButton5 = panel3.AddItem(pushButtonData5) as PushButton;

            string classname6 = "BIMDelivery.Command.ExportSheets";
            PushButtonData pushButtonData6 = new PushButtonData("导出excel", "导出excel", assemblypath, classname6);
            pushButtonData6.LargeImage = new BitmapImage(new Uri("pack://application:,,,/BIMDelivery;component/Image/导出excel.png"));
            PushButton pushButton6 = panel3.AddItem(pushButtonData6) as PushButton;

            string classname7 = "BIMDelivery.Command.FileUpload";
            PushButtonData pushButtonData7 = new PushButtonData("数据上传", "数据上传", assemblypath, classname7);
            pushButtonData7.LargeImage = new BitmapImage(new Uri("pack://application:,,,/BIMDelivery;component/Image/数据上传.png"));
            PushButton pushButton7 = panel4.AddItem(pushButtonData7) as PushButton;


            string classname8 = "BIMDelivery.Command.FileWebDownload";
            PushButtonData pushButtonData8 = new PushButtonData("数据下载", "数据下载", assemblypath, classname8);
            pushButtonData8.LargeImage = new BitmapImage(new Uri("pack://application:,,,/BIMDelivery;component/Image/数据下载.png"));
            PushButton pushButton8 = panel4.AddItem(pushButtonData8) as PushButton;

            DeleteAddinFile();
            return Result.Succeeded;
        }

        private bool DeleteAddinFile()
        {
            RevitProduct revitProduct=GetStartInfo();
            DirectoryInfo directoryInfo = new DirectoryInfo(revitProduct.AllUsersAddInFolder);
            string path1 = directoryInfo.Parent.FullName;
            string number = revitProduct.Name.TrimStart("AddInsRevit".ToCharArray()).Trim();
            string path2 = Path.Combine(path1, number);
            Directory.CreateDirectory(path2);
            string destaddinfile = Path.Combine(path2, "DTData.addin");

            if (File.Exists(destaddinfile))
            {
                File.Delete(destaddinfile);
            }

            return true;
        }


        public static RevitProduct GetStartInfo()
        {

            //获取本地安装的revit版本列表
            List<RevitProduct> revitProducts = RevitProductUtility.GetAllInstalledRevitProducts();

            List<RevitProduct> revits = new List<RevitProduct>();
            foreach (var item in revitProducts)
            {
                if (item.Name == "Revit 2018")
                {
                    revits.Add(item);
                }
            }

            if (revits.Count == 0)
            {
                MessageBox.Show("本地未找到安装的revit版本", "提示");
            }

            if (revits.Count == 1)
            {
                return revits[0];
            }

            RevitProduct revitProductlast = revits.Last();

            return revitProductlast;



        }


    }
}
