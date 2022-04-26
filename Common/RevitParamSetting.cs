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
    class RevitParamSetting
    {
        //联系人参数    ！！需确定自动赋值的参数及参数生成原则
        public void SetRevitContactParamValue(Document doc, SettingsForm settingsForm, bool instanceparam = true)
        {


        }




        //设施参数
        public void SetRevitFacilityParamValue(Document doc, SettingsForm settingsForm, bool instanceparam = true)
        {
            //string path = @"E:\program\BIMDelivery\BIMDelivery\Resource\BIMSpreadsheet.xlsx";

            ExcelOperation excelOperation = new ExcelOperation();
            //ContactSheet contactSheet = new ContactSheet();
            Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();
            ParamMap parameterMap = new ParamMap();
            List<Category> categories = new List<Category>();
            string value = string.Empty;
            ElementParamValue elementParamValue = new ElementParamValue();
            categories = parameterMap.GetFacilityCategories(doc);
            foreach (Category category in categories)
            {
                List<Element> elements = elementParamValue.GetElements(doc,instanceparam,categories);
                foreach (Element element in elements)
                {
                    elementParamValue.SetParamValues(doc, element, "一般", "长度单位", settingsForm);
                    elementParamValue.SetParamValues(doc, element, "一般", "面积单位", settingsForm);
                    elementParamValue.SetParamValues(doc, element, "一般", "体积单位", settingsForm);
                    elementParamValue.SetParamValues(doc, element, "一般", "寿命单位", settingsForm);
                }

            }


        }

        //楼层参数
        public void SetRevitFloorParamValue(Document doc, SettingsForm settingsForm, bool instanceparam = true)
        {
                      

        }


        //房间参数
        public void SetRevitSpaceParamValue(Document doc, SettingsForm settingsForm, bool instanceparam = true)
        {


            ParamMap parameterMap = new ParamMap();
            List<Category> categories = new List<Category>();
            ElementParamValue elementParamValue = new ElementParamValue();
            categories = parameterMap.GetSpaceCategories(doc);
            foreach (Category category in categories)
            {
                List<Element> elements = elementParamValue.GetElements(doc, instanceparam, categories);
                foreach (Element element in elements)
                {
                    elementParamValue.SetParamValues(doc, element, "空间", "空间名称",settingsForm);

                }

            }



        }

        //类型参数
        public void SetRevitTypeParamValue(Document doc, SettingsForm settingsForm, bool instanceparam = false)
        {

            ParamMap parameterMap = new ParamMap();
            List<Category> categories = new List<Category>();
            ElementParamValue elementParamValue = new ElementParamValue();
            categories = parameterMap.GetTypeCategories(doc);
            foreach (Category category in categories)
            {
                List<Element> elements = elementParamValue.GetElements(doc, instanceparam, categories);
                foreach (Element element in elements)
                {
                    //和系统参数名称相同，判断是否可写
                    if (element.LookupParameter("类型名称").IsReadOnly==false)
                    {
                        elementParamValue.SetParamValues(doc, element, "类型", "类型名称", settingsForm);
                    }
                    //elementParamValue.SetParamValues(doc, element, "类型", "类型名称", settingsForm);
                }
            }


        }


        //组件参数
        public void SetRevitComponentParamValue(Document doc, SettingsForm settingsForm, bool instanceparam = true)
        {

            ParamMap parameterMap = new ParamMap();
            List<Category> categories = new List<Category>();
            ElementParamValue elementParamValue = new ElementParamValue();
            categories = parameterMap.GetComponentCategories(doc);
            foreach (Category category in categories)
            {
                List<Element> elements = elementParamValue.GetElements(doc, instanceparam, categories);
                foreach (Element element in elements)
                {
                    elementParamValue.SetParamValues(doc, element, "组件", "组件名称",settingsForm);
                }
            }

        }


        //系统参数
        public void SetRevitSystemParamValue(Document doc, SettingsForm settingsForm, bool instanceparam = true)
        {

            ParamMap parameterMap = new ParamMap();
            List<Category> categories = new List<Category>();
            ElementParamValue elementParamValue = new ElementParamValue();
            categories = parameterMap.GetSystemCategories(doc);
            foreach (Category category in categories)
            {
                List<Element> elements = elementParamValue.GetElements(doc, instanceparam, categories);
                foreach (Element element in elements)
                {
                    elementParamValue.SetParamValues(doc, element, "系统", "系统名称",settingsForm);
                }
            }


        }

    }




}
