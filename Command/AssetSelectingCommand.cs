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
using BIMDelivery.Model;
using System.IO;

namespace BIMDelivery.Command
{
    [Transaction(TransactionMode.Manual)]
    class AssetSelectingCommand : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Document doc = commandData.Application.ActiveUIDocument.Document;

            AssetsForm assetsForm = new AssetsForm(doc);
            List<Element> instanceelements = new List<Element>();
            if (assetsForm.ShowDialog()==DialogResult.OK )
            {
                instanceelements = assetsForm.instanceelements;

                //后改为动态路径
                string path = FilePathHelper.GetResourcePath()+@"\Resource\BIMSpreadsheet.xlsx";

                string updatepath = FilePathHelper.GetResourcePath() + @"\Resource\update\BIMSpreadsheet.xlsx";
                if (!File.Exists(updatepath))
                {
                    File.Copy(path, updatepath, true);
                }
                //File.Copy(path, updatepath, true);



                ParamMappings conform = new ParamMappings(doc);
                DataGridViewRowCollection rowcollection = conform.rows;
                SheetWriting sheetWriting = new SheetWriting();


                //需要读取写入的字段名
                List<string> componentfieldnames = new List<string>();
   
                List<string> typefieldnames = new List<string>();
                //List<string> systemfieldnames = new List<string>();
                //List<string> attributefieldnames = new List<string>();

                //attributefieldnames.Add("名称");
                //attributefieldnames.Add("行名称");
                //attributefieldnames.Add("值");


                foreach (DataGridViewRow row in rowcollection)
                {
                    if ((string)row.Cells[2].Value == "组件")
                    {
                        string fieldname = (string)row.Cells[3].Value;
                        componentfieldnames.Add(fieldname);
                        continue;
                    }

                    

                    if ((string)row.Cells[2].Value == "类型")
                    {
                        string fieldname = (string)row.Cells[3].Value;
                        typefieldnames.Add(fieldname);
                        continue;
                    }

                }

                //类型和组件表导出元素根据选择类型调整


                //组件表内容写入
               

                ExcelOperation excelOperation = new ExcelOperation();
                ParamMap parameterMap = new ParamMap();
                List<Category> categories = new List<Category>();
                string value = string.Empty;
                ElementParamValue elementParamValue = new ElementParamValue();
                categories = parameterMap.GetComponentCategories(doc);
                List<Dictionary<string, string>> elementkeyvaluepairs = new List<Dictionary<string, string>>();
                foreach (Element element in instanceelements)
                {
                    Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();
                    foreach (string fieldname in componentfieldnames)
                    {

                        value = elementParamValue.GetParamValues(doc, element, "组件", fieldname);

                        //没有值的不加到键值对
                        if (value !=null && value !="")
                        {
                            keyValuePairs.Add(fieldname, value);
                        }
                        //keyValuePairs.Add(fieldname, value);
                    }
                    elementkeyvaluepairs.Add(keyValuePairs);
                    ////写入excel

                    ////判断键值对是否是空值
                    //if (keyValuePairs.Count() !=0)
                    //{
                    //    excelOperation.WriteBook(path, 7, keyValuePairs);
                    //}

                }

                //写入excel

                //判断键值对是否是空值
                if (elementkeyvaluepairs.Count() != 0)
                {
                    excelOperation.WriteBook(updatepath, 7, elementkeyvaluepairs);
                }






            }
             
            return Result.Succeeded ;
        }
    }
}
