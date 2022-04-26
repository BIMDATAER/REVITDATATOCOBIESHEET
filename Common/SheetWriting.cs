using Autodesk.Revit.DB;
using BIMDelivery.Data;
using BIMDelivery.Forms;
using BIMDelivery.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIMDelivery.Common
{
    class SheetWriting
    {
        //联系人
        public void SetContactFieldValue(Document doc, List<string> fieldnames, bool instanceparam=true)
        {
            string path = FilePathHelper.GetResourcePath() + @"\Resource\update\BIMSpreadsheet.xlsx";

            ExcelOperation excelOperation = new ExcelOperation();
            //ContactSheet contactSheet = new ContactSheet();
            Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();


        }

        //设施
        public void SetFacilityFieldValue(Document doc,List<string> fieldnames,bool instanceparam = true)
        {
            string path = FilePathHelper.GetResourcePath() + @"\Resource\update\BIMSpreadsheet.xlsx";

            ExcelOperation excelOperation = new ExcelOperation();
            //ContactSheet contactSheet = new ContactSheet();
            //Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();
            ParamMap parameterMap = new ParamMap();
            List<Category> categories = new List<Category>();
            string value = string.Empty;
            ElementParamValue elementParamValue = new ElementParamValue();
            categories = parameterMap.GetFacilityCategories(doc);
            List<Element> elements = elementParamValue.GetElements(doc, instanceparam, categories);
            List<Dictionary<string, string>> elementkeyvaluepairs = new List<Dictionary<string, string>>(); 
            foreach (Element element in elements)
            {
                Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();
                foreach (string fieldname in fieldnames)
                {

                    value = elementParamValue.GetParamValues(doc, element, "设施", fieldname);

                    keyValuePairs.Add(fieldname, value);
                }

                elementkeyvaluepairs.Add(keyValuePairs);

            }

            //写入excel
            excelOperation.WriteBook(path, 2, elementkeyvaluepairs);

            //foreach (Category category in categories)
            //{
            //    List<Element> elements = elementParamValue.GetElements(doc,instanceparam,categories);
            //    foreach (Element element in elements)
            //    {
            //        Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();
            //        foreach (string fieldname in fieldnames)
            //        {

            //            value = elementParamValue.GetParamValues(doc,element,"设施",fieldname);

            //            keyValuePairs.Add(fieldname, value);
            //        }

            //        //写入excel
            //        excelOperation.WriteBook(path, 2, keyValuePairs);
            //    }


            //}


        }

        //楼层
        public void SetFloorFieldValue(Document doc, List<string> fieldnames, bool instanceparam = true)
        {
            string path = FilePathHelper.GetResourcePath() + @"\Resource\update\BIMSpreadsheet.xlsx";

            ExcelOperation excelOperation = new ExcelOperation();
            //ContactSheet contactSheet = new ContactSheet();
            //Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();
            ParamMap parameterMap = new ParamMap();
            List<Category> categories = new List<Category>();
            string value = string.Empty;
            ElementParamValue elementParamValue = new ElementParamValue();
            categories = parameterMap.GetFloorCategories(doc);
            List<Element> elements = elementParamValue.GetElements(doc, instanceparam, categories);
            List<Dictionary<string, string>> elementkeyvaluepairs = new List<Dictionary<string, string>>();
            foreach (Element element in elements)
            {
                Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();
                foreach (string fieldname in fieldnames)
                {

                    value = elementParamValue.GetParamValues(doc, element, "楼层", fieldname);

                    keyValuePairs.Add(fieldname, value);
                }
                elementkeyvaluepairs.Add(keyValuePairs);

            }

            //写入excel
            excelOperation.WriteBook(path, 3, elementkeyvaluepairs);



            //foreach (Category category in categories)
            //{
            //    List<Element> elements = elementParamValue.GetElements(doc, instanceparam, categories);
            //    foreach (Element element in elements)
            //    {
            //        Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();
            //        foreach (string fieldname in fieldnames)
            //        {

            //            value = elementParamValue.GetParamValues(doc,element,"楼层" ,fieldname);

            //            keyValuePairs.Add(fieldname, value);
            //        }

            //        //写入excel
            //        excelOperation.WriteBook(path, 3, keyValuePairs);
            //    }


            //}


        }


        //房间表
        public void SetSpaceFieldValue(Document doc, List<string> fieldnames, bool instanceparam = true)
        {
            string path = FilePathHelper.GetResourcePath() + @"\Resource\update\BIMSpreadsheet.xlsx";

            ExcelOperation excelOperation = new ExcelOperation();
            //ContactSheet contactSheet = new ContactSheet();
            //Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();
            ParamMap parameterMap = new ParamMap();
            List<Category> categories = new List<Category>();
            string value = string.Empty;
            ElementParamValue elementParamValue = new ElementParamValue();
            categories = parameterMap.GetSpaceCategories(doc);
            List<Element> elements = elementParamValue.GetElements(doc, instanceparam, categories);
            List<Dictionary<string, string>> elementkeyvaluepairs = new List<Dictionary<string, string>>();
            foreach (Element element in elements)
            {
                Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();
                foreach (string fieldname in fieldnames)
                {

                    value = elementParamValue.GetParamValues(doc, element, "空间", fieldname);

                    keyValuePairs.Add(fieldname, value);
                }
                elementkeyvaluepairs.Add(keyValuePairs);
            }
            //写入excel
            excelOperation.WriteBook(path, 4, elementkeyvaluepairs);

        }

        //类型表
        public void SetTypeFieldValue(Document doc, List<string> fieldnames, bool instanceparam=false)
        {
            string path = FilePathHelper.GetResourcePath() + @"\Resource\update\BIMSpreadsheet.xlsx";

            ExcelOperation excelOperation = new ExcelOperation();
            //ContactSheet contactSheet = new ContactSheet();
            //Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();
            ParamMap parameterMap = new ParamMap();
            List<Category> categories = new List<Category>();
            string value = string.Empty;
            ElementParamValue elementParamValue = new ElementParamValue();
            categories = parameterMap.GetTypeCategories(doc);


            List<Element> elements = elementParamValue.GetElements(doc, instanceparam, categories);
            List<Dictionary<string, string>> elementkeyvaluepairs = new List<Dictionary<string, string>>();
            foreach (Element element in elements)
            {
                Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();
                foreach (string fieldname in fieldnames)
                {
                    value = elementParamValue.GetParamValues(doc, element, "类型", fieldname);

                    keyValuePairs.Add(fieldname, value);
                }
                elementkeyvaluepairs.Add(keyValuePairs);
 
            }
            //写入excel
            excelOperation.WriteBook(path, 6, elementkeyvaluepairs);

        }


        //组件表
        public void SetComponentFieldValue(Document doc, List<string> fieldnames, bool instanceparam = true)
        {
            string path = FilePathHelper.GetResourcePath() + @"\Resource\update\BIMSpreadsheet.xlsx";

            ExcelOperation excelOperation = new ExcelOperation();
            //ContactSheet contactSheet = new ContactSheet();
            //Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();
            ParamMap parameterMap = new ParamMap();
            List<Category> categories = new List<Category>();
            string value = string.Empty;
            ElementParamValue elementParamValue = new ElementParamValue();
            categories = parameterMap.GetComponentCategories(doc);
            List<Element> elements = elementParamValue.GetElements(doc, instanceparam, categories);
            List<Dictionary<string, string>> elementkeyvaluepairs = new List<Dictionary<string, string>>();
            foreach (Element element in elements)
            {
                Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();
                foreach (string fieldname in fieldnames)
                {

                    value = elementParamValue.GetParamValues(doc, element, "组件", fieldname);

                    keyValuePairs.Add(fieldname, value);
                }
                elementkeyvaluepairs.Add(keyValuePairs);

            }
            //写入excel
            excelOperation.WriteBook(path, 7, elementkeyvaluepairs);


        }


        //系统表
        public void SetSystemFieldValue(Document doc, List<string> fieldnames, bool instanceparam = true)
        {
            string path = FilePathHelper.GetResourcePath() + @"\Resource\update\BIMSpreadsheet.xlsx";

            ExcelOperation excelOperation = new ExcelOperation();
            //ContactSheet contactSheet = new ContactSheet();
            //Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();
            ParamMap parameterMap = new ParamMap();
            List<Category> categories = new List<Category>();
            string value = string.Empty;
            ElementParamValue elementParamValue = new ElementParamValue();
            categories = parameterMap.GetSystemCategories(doc);
            List<Element> elements = elementParamValue.GetElements(doc, instanceparam, categories);
            List<Dictionary<string, string>> elementkeyvaluepairs = new List<Dictionary<string, string>>();
            foreach (Element element in elements)
            {
                Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();
                foreach (string fieldname in fieldnames)
                {

                    value = elementParamValue.GetParamValues(doc, element, "系统", fieldname);

                    keyValuePairs.Add(fieldname, value);
                }

                elementkeyvaluepairs.Add(keyValuePairs);

            }
            //写入excel
            excelOperation.WriteBook(path, 8, elementkeyvaluepairs);


        }



        //属性表
        public void SetAttributeFieldValue(Document doc, List<string> fieldnames, bool instanceparam = true)
        {
            //重写，根据form表设定内容调整导出参数
            string path = FilePathHelper.GetResourcePath() + @"\Resource\update\BIMSpreadsheet.xlsx";
            List<Category> categories = new List<Category>();
            ElementParamValue elementParamValue = new ElementParamValue();
            string value = string.Empty;
            ExcelOperation excelOperation = new ExcelOperation();
            Dictionary<string, List<string>> keyValues = new Dictionary<string, List<string>>();
            AttributesForm attributesForm = new AttributesForm(doc);

            if (attributesForm.ShowDialog()==System.Windows.Forms.DialogResult.OK)
            {
                keyValues = attributesForm.paramskeyValuePairs;

                for (int i = 0; i < keyValues.Keys.Count; i++)
                {
                    string[] categorandtype = keyValues.Keys.ElementAt(i).Split(new char[] { '_'});
                    ElementId elementId = new ElementId(System.Convert.ToInt32(categorandtype[0]));
                    Category category = Category.GetCategory(doc,elementId);
                    //获取二级节点选中状态，类型参数选中，实例参数选中
                    List<Element> instanceelements = new List<Element>();
                    List<Element> typeelements = new List<Element>();

                    if (categorandtype[1] == "0")
                    {
                        //获取类型元素

                        List<Element> list3 = new List<Element>();
                        FilteredElementCollector val2 = new FilteredElementCollector(doc);
                        list3.AddRange(new FilteredElementCollector(doc).OfCategory((BuiltInCategory)category.Id.IntegerValue).WhereElementIsNotElementType().ToElements());
                        //List<Dictionary<string, string>> elementkeyvaluepairs = new List<Dictionary<string, string>>();
                        //获取模型实例对应的类型

                        for (int j = 0; j < list3.Count; j++)
                        {
                            Element element = list3[j];

                            if (element.GetTypeId() != null && element.GetTypeId().IntegerValue != -1)
                            {
                                typeelements.Add(doc.GetElement(element.GetTypeId()));
                            }
                        }

                        //类型参数写入
                        foreach (Element element in typeelements)
                        {
                            //Dictionary<string, string> keyTypeValuePairs = new Dictionary<string, string>();

                            //获取form三级节点选中的参数名
                            List<string> paramnames = keyValues.Values.ElementAt(i);
                            List<Dictionary<string, string>> elementkeyvaluepairs = new List<Dictionary<string, string>>();
                            //Dictionary<string, string> keyTypeValuePairs = new Dictionary<string, string>();
                            foreach (string item in paramnames)
                            {
                                Dictionary<string, string> keyTypeValuePairs = new Dictionary<string, string>();
                                keyTypeValuePairs.Add("名称", item);
                                keyTypeValuePairs.Add("行名", element.Name);

                                //元素是否有该参数
                                if (element.LookupParameter(item) !=null)
                                {
                                    value = element.LookupParameter(item).AsString();
                                    keyTypeValuePairs.Add("值", value);
                                }
                                elementkeyvaluepairs.Add(keyTypeValuePairs);

                            }
                            //写入excel
                            excelOperation.WriteBook(path, 16, elementkeyvaluepairs);
                        }
  
                    }
                    else if (categorandtype[1] == "1")
                    {
                        //获取实例元素

                        FilteredElementCollector val2 = new FilteredElementCollector(doc);
                        instanceelements.AddRange(new FilteredElementCollector(doc).OfCategory((BuiltInCategory)category.Id.IntegerValue).WhereElementIsNotElementType().ToElements());
                        //List<Dictionary<string, string>> elementkeyvaluepairs = new List<Dictionary<string, string>>();

                        //实例参数写入
                        foreach (Element element in instanceelements)
                        {
                            //Dictionary<string, string> keyInstanceValuePairs = new Dictionary<string, string>();
                            List<Dictionary<string, string>> elementkeyvaluepairs = new List<Dictionary<string, string>>();
                            //获取form三级节点选中的参数名
                            List<string> paramnames = keyValues.Values.ElementAt(i);
                            //Dictionary<string, string> keyInstanceValuePairs = new Dictionary<string, string>();
                            foreach (string item in paramnames)
                            {
                                Dictionary<string, string> keyInstanceValuePairs = new Dictionary<string, string>();
                                keyInstanceValuePairs.Add("名称", item);
                                keyInstanceValuePairs.Add("行名称", element.Name);


                                if (element.LookupParameter(item) !=null)
                                {
                                    value = element.LookupParameter(item).AsString();
                                    keyInstanceValuePairs.Add("值", value);
                                }
                                elementkeyvaluepairs.Add(keyInstanceValuePairs);
                            }
                            //写入excel
                            excelOperation.WriteBook(path, 16, elementkeyvaluepairs);
                        }


                    }


                }

            }

        }

    }




}
