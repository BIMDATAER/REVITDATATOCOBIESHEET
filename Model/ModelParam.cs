using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using BIMDelivery.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Application = Autodesk.Revit.ApplicationServices.Application;

namespace BIMDelivery.Model
{
    [Transaction(TransactionMode.Manual)]
    class ModelParams 
    {
        /// <summary>
        /// 创建共享参数
        /// </summary>
        /// <param name="app"></param>
        /// <param name="doc"></param>
        /// <param name="shareparamfilepath"></param>
        /// <param name="groupname"></param>
        /// <param name="definitionname"></param>
        /// <param name="parameterType"></param>
        /// <param name="instanceparam"></param>
        public void CreatShareInfo(Application app,Document doc,string shareparamfilepath,string groupname,string definitionname, ParameterType parameterType)
        {
            ////获取实例参数和类型参数类别

            //CategorySet categorySet = new CategorySet();

            //Category elecategory = doc.Settings.Categories.get_Item(BuiltInCategory.OST_Walls);

            //categorySet.Insert(elecategory);

            //BuiltInParameterGroup builtInParameterGroup = BuiltInParameterGroup.PG_DATA;


            if (!File.Exists(shareparamfilepath))
            {
                StreamWriter sw = File.CreateText(shareparamfilepath);
                sw.Close();
            }

            app.SharedParametersFilename = shareparamfilepath;
            DefinitionFile definitionFile = app.OpenSharedParameterFile();
            if (definitionFile==null)
            {
                MessageBox.Show("共享参数文件未打开","提示");
            }
            DefinitionGroups groups = definitionFile.Groups;
            DefinitionGroup group = groups.get_Item(groupname);

            if (group==null)
            {
                group = groups.Create(groupname);
            }

            Definition definition = group.Definitions.get_Item(definitionname);
            if (definition == null)
            {
                definition = group.Definitions.Create(new ExternalDefinitionCreationOptions(definitionname,parameterType));
            }

            ////绑定实例或类型

            //ElementBinding binding = null;
            //if (instanceparam)
            //{
            //    binding = app.Create.NewInstanceBinding(categorySet);
            //}
            //else
            //{
            //    binding = app.Create.NewTypeBinding(categorySet);
            //}
            //bool insertparam = doc.ParameterBindings.Insert(definition,binding,builtInParameterGroup);




        }




        /// <summary>
        /// 读取共享参数
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>

        public string GetShareInfo(Application app) 
        {
            StringBuilder str = new StringBuilder();

            DefinitionFile definitionFile = app.OpenSharedParameterFile();
            DefinitionGroups groups = definitionFile.Groups;

            foreach (DefinitionGroup group in groups)
            {
                foreach (Definition definition in group.Definitions)
                {
                    string name = definition.Name;
                    ParameterType type = definition.ParameterType;
                    str.AppendLine(string.Format("{0}--{1}",name,type.ToString()));
                }

            }

            return str.ToString();
        }


        public bool BindShareInfo(Application app,Document doc,List<Category> categories ,string groupname,string definitionname, bool instanceparam) 
        {

            //CategorySet categorySet = new CategorySet();
            //InstanceBinding instanceBinding = new InstanceBinding();
            //TypeBinding typeBinding = new TypeBinding();
            //if (instanceparam)
            //{
            //    categorySet = instanceBinding.Categories;
            //}
            //else 
            //{
            //    categorySet = typeBinding.Categories;            
            //}

            //获取实例参数和类型参数类别,需要改动，改成对应参数所有类别！！！

            CategorySet categorySet = new CategorySet();

            foreach (Category category in categories)
            {
                categorySet.Insert(category);

            }

            //Category elecategory = doc.Settings.Categories.get_Item(BuiltInCategory.OST_Walls);

            //categorySet.Insert(elecategory);

            BuiltInParameterGroup builtInParameterGroup = BuiltInParameterGroup.PG_DATA;

            StringBuilder str = new StringBuilder();

            app.SharedParametersFilename = FilePathHelper.GetResourcePath() + @"\Resource\Extension Shared Parameters.txt";

            DefinitionFile definitionFile = app.OpenSharedParameterFile();
            DefinitionGroups groups = definitionFile.Groups;
            DefinitionGroup group = groups.get_Item(groupname);
            Definition definition = group.Definitions.get_Item(definitionname);

            //绑定实例或类型

            ElementBinding binding = null;
            if (instanceparam)
            {
                binding = app.Create.NewInstanceBinding(categorySet);
            }
            else
            {
                binding = app.Create.NewTypeBinding(categorySet);
            }
            bool insertparam = doc.ParameterBindings.Insert(definition, binding, builtInParameterGroup);          

            return insertparam;

        }

    }
}
