using Autodesk.Revit.DB;
using BIMDelivery.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BIMDelivery.Model
{
    class ElementParamValue
    {


		public string GetParamValues(Document doc,Element element,string sheetname,string fieldname) 
		{
			string paramvalues = string.Empty;


			//表格字段和revit参数对应
			string paramname = string.Empty;
			ParamMappings conform = new ParamMappings(doc);
			DataGridViewRowCollection rowcollection = conform.rows;
            foreach (DataGridViewRow item in rowcollection)
            {
                if ((string)item.Cells[2].Value == sheetname)
                {
					if ((string)item.Cells[3].Value == fieldname)
					{
						paramname = (string)item.Cells[4].Value;
						break;
					}
				}
				
            }

			//是否有该参数
            if (element.LookupParameter(paramname) !=null)
            {
				paramvalues = element.LookupParameter(paramname).AsString();
			}
			//paramvalues =element.LookupParameter(paramname).AsString();

			 
			return paramvalues;
		}


		public void SetParamValues(Document doc, Element element,string pagename ,string paramname, SettingsForm settingsForm)
		{
			//string paramvalues = string.Empty;


            //SettingsForm settingsForm = new SettingsForm(doc);

            //string pagename = settingsForm.checkedpagename;
   //         ParamMappings conform = new ParamMappings(doc);
			//DataGridViewRowCollection rowcollection = conform.rows;
			if (pagename=="一般")
            {
                if (paramname=="长度单位")
                {
					string Lineunit = settingsForm.Lineunit;
					element.LookupParameter(paramname).Set(Lineunit);
				}

				if (paramname == "体积单位")
				{
					string vounit = settingsForm.Vounit;
					element.LookupParameter(paramname).Set(vounit);
				}

				if (paramname == "面积单位")
				{
					string areaunit = settingsForm.Areaunit;
					element.LookupParameter(paramname).Set(areaunit);
				}

				//if (paramname == "寿命单位")
				//{
				//	string timeunit = settingsForm.Timeunit;
				//	//获取类型参数
    //                if (element.GetTypeId() !=null && element.GetTypeId().IntegerValue != -1 )
    //                {
				//		doc.GetElement(element.GetTypeId()).LookupParameter(paramname).Set(timeunit);
				//	}
				//	//element.LookupParameter(paramname).Set(timeunit);
				//}

				if (paramname == "识别码")
				{
					//string timeunit = settingsForm.Timeunit;
					//element.LookupParameter(paramname).Set(timeunit);
				}


			}

			if (pagename == "空间")
			{
				if (paramname == "空间名称")
				{
					string spacename = string.Empty;
					//根据选择设置规则获取参数值
					//string split = settingsForm.spacesplitname;

					//读取写入参数值功能需要，把分隔符先固定
					string split ="-";
					string param1 = string.Empty;
					string param2 = string.Empty;
                    if (settingsForm.param1== "revit类别")
                    {
						param1=element.Category.Name;
                    }

					if (settingsForm.param2 == "元素ID")
					{
						param2 = element.Id.ToString();
					}
					spacename = param1 + split + param2;
					element.LookupParameter(paramname).Set(spacename);
				}




			}

			if (pagename == "类型")
			{

				if (paramname == "类型名称")
				{
					string typename = string.Empty;
					//根据选择设置规则获取参数值
					//string split = settingsForm.typesplitname;

					//读取写入参数值功能需要，把分隔符先固定
					string split ="-";
					string param1 = string.Empty;
					string param2 = string.Empty;
					string param3 = string.Empty;
					if (settingsForm.typeparam1 == "revit类别")
					{
						param1 = element.Category.Name;
					}

					if (settingsForm.typeparam2 == "类型")
					{
						param2 = element.GetType().Name;
					}

					if (settingsForm.typeparam3 == "元素ID")
					{
						param3 = element.Id.ToString();
					}
					typename = param1 + split + param2+ split + param3;
					element.LookupParameter(paramname).Set(typename);
				}


				if (paramname == "类型描述")
				{
					string typediscription = string.Empty;
					//根据选择设置规则获取参数值
					if (settingsForm.typeparam1 == "族：类型")
					{
						typediscription = element.Category.Name;
					}

					if (settingsForm.typeparam2 == "元素guid")
					{
						typediscription = element.UniqueId;
					}

					element.LookupParameter(paramname).Set(typediscription);
				}

				if (paramname == "寿命单位")
				{
					string timeunit = settingsForm.Timeunit;
					//获取类型参数
					if (element.GetTypeId() != null && element.GetTypeId().IntegerValue != -1)
					{
						doc.GetElement(element.GetTypeId()).LookupParameter(paramname).Set(timeunit);
					}
					//element.LookupParameter(paramname).Set(timeunit);
				}

			}

			if (pagename == "组件")
			{
				if (paramname == "组件名称")
				{
					string componentname = string.Empty;
					//根据选择设置规则获取参数值
					//string split = settingsForm.componentsplitname;

					//读取写入参数值功能需要，把分隔符先固定
					string split = "-";
					string param1 = string.Empty;
					string param2 = string.Empty;
					//MessageBox.Show(settingsForm.componentparam1, "1111");
					if (settingsForm.componentparam1 == "revit类别")
					{
						param1 = element.Category.Name;
                        //MessageBox.Show(param1, "1111");
                    }

					if (settingsForm.componentparam2 == "元素ID")
					{
						param2 = element.Id.ToString();
						//MessageBox.Show(param2, "1111");
					}

					componentname = param1 + split + param2;
                    //MessageBox.Show(componentname, "1111");
                    element.LookupParameter(paramname).Set(componentname);
				}
			}

			if (pagename == "系统")
			{
				if (paramname == "系统名称")
				{
					string systemname = string.Empty;
					//根据选择设置规则获取参数值
					//string split = settingsForm.systemsplitname;

					string split = "-";
					string param1 = string.Empty;
					string param2 = string.Empty;
					if (settingsForm.systemparam1 == "revit类别")
					{
						param1 = element.Category.Name;
					}

					if (settingsForm.systemparam2 == "系统名称")
					{
                        if (element is MEPCurve)
                        {
							MEPCurve mEPCurve = element as MEPCurve;
							param2 = mEPCurve.MEPSystem.Name;
						}
						
					}

					systemname = param1 + split + param2;
					element.LookupParameter(paramname).Set(systemname);
				}
			}


			if (pagename == "属性")
			{


			}

			if (pagename == "坐标系")
			{



			}

			//foreach (DataGridViewRow item in rowcollection)
   //         {
   //             if ((string)item.Cells[3].Value == fieldname)
   //             {
   //                 paramname = (string)item.Cells[4].Value;
   //             }
   //             break;
   //         }


            //paramvalues = element.LookupParameter(paramname).AsValueString();


            //return paramvalues;
		}


		public List<Element> GetElements(Document doc, bool instanceparam, List<Category> categories)
		{

			List<Element> list2 = new List<Element>();

			if (instanceparam)
			{
				foreach (Category item2 in categories)
				{
					FilteredElementCollector val2 = new FilteredElementCollector(doc);
					list2.AddRange(new FilteredElementCollector(doc).OfCategory((BuiltInCategory)item2.Id.IntegerValue).WhereElementIsNotElementType().ToElements());
				}
			}
			else 
			{
				foreach (Category item2 in categories)
				{
					List<Element> list3 = new List<Element>();
					FilteredElementCollector val2 = new FilteredElementCollector(doc);
					list3.AddRange(new FilteredElementCollector(doc).OfCategory((BuiltInCategory)item2.Id.IntegerValue).WhereElementIsNotElementType().ToElements());

                    //获取模型实例对应的类型

                    for (int i = 0; i < list3.Count; i++)
                    {
                        Element element = list3[i];

                        if (element.GetTypeId() !=null && element.GetTypeId().IntegerValue !=-1)
                        {
							list2.Add(doc.GetElement(element.GetTypeId()));
                        }

                    }
				}

                //去除重复类型
                for (int i = 0; i < list2.Count; i++)
                {
                    for (int j = list2.Count-1; j >i; j--)
                    {
                        if (list2[i].Id==list2[j].Id)
                        {
							list2.RemoveAt(j);
                        }
                    }
                }
			}

			return list2;

		}






	}
}
