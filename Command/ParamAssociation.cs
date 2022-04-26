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

namespace BIMDelivery.Command
{
    [Transaction(TransactionMode.Manual)]
    class ParamAssociation : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {

            Document doc = commandData.Application.ActiveUIDocument.Document;
            Autodesk.Revit.ApplicationServices.Application app = commandData.Application.Application;
            Transaction trans = new Transaction(doc,"绑定参数");
            trans.Start();

            ParamMappings conform = new ParamMappings(doc);
            if (conform.ShowDialog()==DialogResult.OK )
            {
                //string path = @"E:\program\BIMDelivery\BIMDelivery\Resource\BIMSpreadsheet.xlsx";

                ModelParams modelParams = new ModelParams();
                List<Category> categories = new List<Category>();
                ParamMap paramMap = new ParamMap();
                //modelParams.BindShareInfo(app,doc,);
                DataGridViewRowCollection rowcollection=conform.rows;
                foreach (DataGridViewRow row in rowcollection)
                {
                    if ((string)row.Cells[2].Value=="所有")
                    {
                        categories = paramMap.GetallCategories(doc);
                        string groupname = (string)row.Cells[2].Value;
                        string definitionname=(string)row.Cells[4].Value;
                        bool instancepara = true;
                        if ((string)row.Cells[0].Value == "实例")
                        {
                            instancepara = true;
                        }
                        else 
                        {
                            instancepara = false;
                        }
                        modelParams.BindShareInfo(app, doc,categories,groupname,definitionname,instancepara);
                        continue;
                    }

                    if ((string)row.Cells[2].Value == "组件")
                    {
                        categories = paramMap.GetComponentCategories(doc);
                        string groupname = (string)row.Cells[2].Value;
                        string definitionname = (string)row.Cells[4].Value;
                        bool instancepara = true;
                        if ((string)row.Cells[0].Value == "实例")
                        {
                            instancepara = true;
                        }
                        else
                        {
                            instancepara = false;
                        }
                        modelParams.BindShareInfo(app, doc, categories, groupname, definitionname, instancepara);
                        continue;
                    }

                    if ((string)row.Cells[2].Value == "设施")
                    {
                        categories = paramMap.GetFacilityCategories(doc);
                        string groupname = (string)row.Cells[2].Value;
                        string definitionname = (string)row.Cells[4].Value;
                        bool instancepara = true;
                        if ((string)row.Cells[0].Value == "实例")
                        {
                            instancepara = true;
                        }
                        else
                        {
                            instancepara = false;
                        }
                        modelParams.BindShareInfo(app, doc, categories, groupname, definitionname, instancepara);
                        continue;
                    }

                    if ((string)row.Cells[2].Value == "楼层")
                    {
                        categories = paramMap.GetFloorCategories(doc);
                        string groupname = (string)row.Cells[2].Value;
                        string definitionname = (string)row.Cells[4].Value;
                        bool instancepara = true;
                        if ((string)row.Cells[0].Value == "实例")
                        {
                            instancepara = true;
                        }
                        else
                        {
                            instancepara = false;
                        }
                        modelParams.BindShareInfo(app, doc, categories, groupname, definitionname, instancepara);
                        continue;
                    }

                    if ((string)row.Cells[2].Value == "空间")
                    {
                        categories = paramMap.GetSpaceCategories(doc);
                        string groupname = (string)row.Cells[2].Value;
                        string definitionname = (string)row.Cells[4].Value;
                        bool instancepara = true;
                        if ((string)row.Cells[0].Value == "实例")
                        {
                            instancepara = true;
                        }
                        else
                        {
                            instancepara = false;
                        }
                        modelParams.BindShareInfo(app, doc, categories, groupname, definitionname, instancepara);
                        continue;
                    }

                    if ((string)row.Cells[2].Value == "类型")
                    {
                        categories = paramMap.GetTypeCategories(doc);
                        string groupname = (string)row.Cells[2].Value;
                        string definitionname = (string)row.Cells[4].Value;
                        bool instancepara = true;
                        if ((string)row.Cells[0].Value == "实例")
                        {
                            instancepara = true;
                        }
                        else
                        {
                            instancepara = false;
                        }
                        modelParams.BindShareInfo(app, doc, categories, groupname, definitionname, instancepara);
                        continue;
                    }

                    if ((string)row.Cells[2].Value == "系统")
                    {
                        categories = paramMap.GetSystemCategories(doc);
                        string groupname = (string)row.Cells[2].Value;
                        string definitionname = (string)row.Cells[4].Value;
                        bool instancepara = true;
                        if ((string)row.Cells[0].Value == "实例")
                        {
                            instancepara = true;
                        }
                        else
                        {
                            instancepara = false;
                        }
                        modelParams.BindShareInfo(app, doc, categories, groupname, definitionname, instancepara);
                        continue;
                    }

                }

                trans.Commit();


            }
             
            return Result.Succeeded ;
        }
    }
}
