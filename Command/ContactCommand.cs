using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using BIMDelivery.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BIMDelivery.Common;
using BIMDelivery.Data;

namespace BIMDelivery.Command
{
    [Transaction(TransactionMode.Manual)]
    class ContactCommand : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {


            ContactForm conform = new ContactForm();
            if (conform.ShowDialog()==DialogResult.OK )
            {
                //后改为动态路径
                string path = FilePathHelper.GetResourcePath() + @"\Resource\BIMSpreadsheet.xlsx";

                //MessageBox.Show(path,"");

                ExcelOperation excelOperation = new ExcelOperation();
                ContactSheet contactSheet = new ContactSheet();


                //传值
                contactSheet.Email = conform.Email;
                contactSheet.CreatBy = conform.CreatBy;
                contactSheet.Company = conform.Company;
                contactSheet.Category = conform.Category;
                contactSheet.Phone = conform.Phone;

                //一次记录存储
                List<Dictionary<string, string>> elementkeyvaluepairs = new List<Dictionary<string, string>>();
                Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();
                keyValuePairs.Add("邮箱", contactSheet.Email);
                keyValuePairs.Add("单位", contactSheet.Company);
                keyValuePairs.Add("电话", contactSheet.Phone);
                keyValuePairs.Add("创建人", contactSheet.CreatBy);
                keyValuePairs.Add("参与方类型", contactSheet.Category);
                elementkeyvaluepairs.Add(keyValuePairs);
                //写入excel
                excelOperation.WriteBook(path, 1, elementkeyvaluepairs);




            }
             
            return Result.Succeeded ;
        }
    }
}
