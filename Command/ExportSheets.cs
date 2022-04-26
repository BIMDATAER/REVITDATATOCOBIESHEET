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
using System.IO;

namespace BIMDelivery.Command
{
    [Transaction(TransactionMode.Manual)]
    class ExportSheets : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Document doc = commandData.Application.ActiveUIDocument.Document;

            ExportForm exportform = new ExportForm();
            if (exportform.ShowDialog()==DialogResult.OK )
            {
                //后改为动态路径
                string path = FilePathHelper.GetResourcePath() + @"\Resource\BIMSpreadsheet.xlsx";


                //复制目标文件至修改文件夹

                string updatepath = FilePathHelper.GetResourcePath() + @"\Resource\update\BIMSpreadsheet.xlsx";
                if (!File.Exists(updatepath))
                {
                    File.Copy(path, updatepath, true);
                }
                //File.Copy(path, updatepath, true);

                ParamMappings conform = new ParamMappings(doc);
                DataGridViewRowCollection rowcollection = conform.rows;
                SheetWriting sheetWriting = new SheetWriting();
                List<string> exportsheetnames = exportform.filenames;


                //需要读取写入的字段名
                List<string> componentfieldnames = new List<string>();
                List<string> facilityfieldnames = new List<string>();
                List<string> floorfieldnames = new List<string>();
                List<string> spacefieldnames = new List<string>();
                List<string> typefieldnames = new List<string>();
                List<string> systemfieldnames = new List<string>();
                List<string> attributefieldnames = new List<string>();

                attributefieldnames.Add("名称");
                attributefieldnames.Add("行名");
                attributefieldnames.Add("值");


                foreach (DataGridViewRow row in rowcollection)
                {                   
                    if ((string)row.Cells[2].Value == "组件")
                    {
                        string fieldname = (string)row.Cells[3].Value;
                        componentfieldnames.Add(fieldname);
                        continue;
                    }

                    if ((string)row.Cells[2].Value == "设施")
                    {
                        string fieldname = (string)row.Cells[3].Value;
                        facilityfieldnames.Add(fieldname);
                        continue;
                    }

                    if ((string)row.Cells[2].Value == "楼层")
                    {
                        string fieldname = (string)row.Cells[3].Value;
                        floorfieldnames.Add(fieldname);
                        continue;

                    }

                    if ((string)row.Cells[2].Value == "空间")
                    {
                        string fieldname = (string)row.Cells[3].Value;
                        spacefieldnames.Add(fieldname);
                        continue;

                    }

                    if ((string)row.Cells[2].Value == "类型")
                    {
                        string fieldname = (string)row.Cells[3].Value;
                        typefieldnames.Add(fieldname);
                        continue;
                    }

                    if ((string)row.Cells[2].Value == "系统")
                    {
                        string fieldname = (string)row.Cells[3].Value;
                        systemfieldnames.Add(fieldname);
                        continue;
                    }


                }


                //文件写入

                foreach (string name in exportsheetnames)
                {

                    if (name=="组件")
                    {
                        sheetWriting.SetComponentFieldValue(doc, componentfieldnames);
                        continue;
                    }

                    if (name == "设施")
                    {
                        sheetWriting.SetFacilityFieldValue(doc, facilityfieldnames);
                        continue;
                    }

                    if (name == "楼层")
                    {
                        sheetWriting.SetFloorFieldValue(doc, floorfieldnames);
                        continue;
                    }

                    if (name == "空间")
                    {
                        sheetWriting.SetSpaceFieldValue(doc, spacefieldnames);
                        continue;
                    }

                    if (name == "类型")
                    {
                        sheetWriting.SetTypeFieldValue(doc, typefieldnames);
                        continue;
                    }

                    if (name == "系统")
                    {
                        sheetWriting.SetSystemFieldValue(doc, systemfieldnames);
                        continue;
                    }

                    if (name == "属性")
                    {
                        sheetWriting.SetAttributeFieldValue(doc, attributefieldnames);
                        continue;
                    }

                }


                //sheetWriting.SetComponentFieldValue(doc, componentfieldnames);
                //sheetWriting.SetFacilityFieldValue(doc, facilityfieldnames);
                //sheetWriting.SetFloorFieldValue(doc, floorfieldnames);
                //sheetWriting.SetSpaceFieldValue(doc, spacefieldnames);
                //sheetWriting.SetTypeFieldValue(doc, typefieldnames);
                //sheetWriting.SetSystemFieldValue(doc, systemfieldnames);



                //导出文件到指定路径
                File.Copy(updatepath, exportform.exportpath+ @"\" + exportform.filename+ ".xlsx", true);

            }
             
            return Result.Succeeded;
        }
    }
}
