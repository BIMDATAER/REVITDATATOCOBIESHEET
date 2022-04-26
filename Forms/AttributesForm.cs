using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BIMDelivery.Forms
{
    public partial class AttributesForm : System.Windows.Forms.Form
    {

        Document document;

        public Dictionary<string, List<string>> paramskeyValuePairs;

        public AttributesForm(Document doc)
        {
            InitializeComponent();
            document = doc;
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            TreeNodeCollection treeNodeCollection = this.treeView1.Nodes;
            for (int ii = 0; ii < treeNodeCollection.Count; ii++)
            {
                treeNodeCollection[ii].Checked = true;
                TreeNodeCollection secondtreeNodes = treeNodeCollection[ii].Nodes;
                for (int i = 0; i < secondtreeNodes.Count; i++)
                {
                    secondtreeNodes[i].Checked = true;
                    TreeNodeCollection thirdtreeNodes = secondtreeNodes[i].Nodes;
                    for (int j = 0; j < thirdtreeNodes.Count; j++)
                    {
                        thirdtreeNodes[j].Checked = true;
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TreeNodeCollection treeNodeCollection = this.treeView1.Nodes;
            for (int ii = 0; ii < treeNodeCollection.Count; ii++)
            {
                treeNodeCollection[ii].Checked = false;
                TreeNodeCollection secondtreeNodes = treeNodeCollection[ii].Nodes;
                for (int i = 0; i < secondtreeNodes.Count; i++)
                {
                    secondtreeNodes[i].Checked = false;
                    TreeNodeCollection thirdtreeNodes = secondtreeNodes[i].Nodes;
                    for (int j = 0; j < thirdtreeNodes.Count; j++)
                    {
                        thirdtreeNodes[j].Checked = false;
                    }
                }
            }
        }

        private void AttributesForm_Load(object sender, EventArgs e)
        {
            Categories categories = document.Settings.Categories;
            foreach (Category category in categories)
            {
                Element element = new FilteredElementCollector(document).OfCategory((BuiltInCategory)category.Id.IntegerValue).WhereElementIsNotElementType().ToElements().FirstOrDefault();
                if (element != null)
                {
                    TreeNode FirstNode = new TreeNode();
                    FirstNode.Text = category.Name + "_" + category.Id.IntegerValue;
                    treeView1.Nodes.Add(FirstNode);

                    TreeNode SecondNode1 = new TreeNode();
                    SecondNode1.Text = "类型参数";
                    TreeNode SecondNode2 = new TreeNode();
                    SecondNode2.Text = "实例参数";
                    FirstNode.Nodes.Add(SecondNode1);
                    FirstNode.Nodes.Add(SecondNode2);

                    foreach (Parameter item in element.Parameters)
                    {
                        TreeNode ThirdNode2 = new TreeNode();
                        ThirdNode2.Text = item.Definition.Name + "_" + item.Id;
                        SecondNode2.Nodes.Add(ThirdNode2);
                    }


                    if (element is Wall)
                    {
                        Wall wall = element as Wall;
                        foreach (Parameter item in wall.WallType.Parameters)
                        {
                            TreeNode ThirdNode1 = new TreeNode();
                            ThirdNode1.Text = item.Definition.Name + "_" + item.Id;
                            SecondNode1.Nodes.Add(ThirdNode1);
                        }
                        continue;
                    }

                    else if (element is FamilyInstance)
                    {
                        FamilyInstance familyInstance = element as FamilyInstance;
                        foreach (Parameter item in familyInstance.Symbol.Parameters)
                        {
                            TreeNode ThirdNode1 = new TreeNode();
                            ThirdNode1.Text = item.Definition.Name + "_" + item.Id;
                            SecondNode1.Nodes.Add(ThirdNode1);
                        }
                        continue;
                    }

                    else
                    {
                        if (element.GetTypeId() != null && element.GetTypeId().ToString() != "-1")
                        {
                            foreach (Parameter item in document.GetElement(element.GetTypeId()).Parameters)
                            {
                                TreeNode ThirdNode1 = new TreeNode();
                                ThirdNode1.Text = item.Definition.Name + "_" + item.Id;
                                SecondNode1.Nodes.Add(ThirdNode1);
                            }
                            continue;
                        }
                        //foreach (Parameter item in element.Parameters)
                        //{
                        //    TreeNode ThirdNode1 = new TreeNode();
                        //    ThirdNode1.Text = item.Definition.Name;
                        //    SecondNode1.Nodes.Add(ThirdNode1);
                        //}
                        //continue;
                    }


                }

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            //选中的类别参数类型及相应参数名
            Dictionary<string, List<string>> categoryparams = new Dictionary<string, List<string>>();
            ;
            //选中的参数名
            //List<string> paramnames = new List<string>();


            TreeNodeCollection treeNodeCollection = this.treeView1.Nodes;
            for (int ii = 0; ii < treeNodeCollection.Count; ii++)
            {
                if (treeNodeCollection[ii].Checked == true)
                {
                    string[] splitstring = treeNodeCollection[ii].Text.Split(new char[] { '_' });
                    ElementId elementId = new ElementId(System.Convert.ToInt32(splitstring[1]));
                    Category category = Category.GetCategory(document, elementId);

                    TreeNodeCollection secondtreeNodes = treeNodeCollection[ii].Nodes;
                    for (int i = 0; i < secondtreeNodes.Count; i++)
                    {
                        if (secondtreeNodes[i].Checked == true && secondtreeNodes[i].Text == "类型参数")
                        {
                            //categories.Add(category, 0);
                            //选中的参数名
                            List<string> paramnames = new List<string>();
                            TreeNodeCollection thirdtreeNodes = secondtreeNodes[i].Nodes;
                            for (int j = 0; j < thirdtreeNodes.Count; j++)
                            {
                                if (thirdtreeNodes[j].Checked == true)
                                {
                                    string[] splitstring1 = thirdtreeNodes[j].Text.Split(new char[] { '_' });
                                    paramnames.Add(splitstring1[0]);

                                }
                            }

                            string categotyandtype = category.Id.ToString() + "_" + "0";
                            if (paramnames.Count != 0)
                            {
                                categoryparams.Add(categotyandtype, paramnames);
                            }


                        }
                        else if (secondtreeNodes[i].Checked == true && secondtreeNodes[i].Text == "实例参数")
                        {
                            //categories.Add(category, 1);
                            //选中的参数名
                            List<string> paramnames = new List<string>();
                            TreeNodeCollection thirdtreeNodes = secondtreeNodes[i].Nodes;
                            for (int j = 0; j < thirdtreeNodes.Count; j++)
                            {
                                if (thirdtreeNodes[j].Checked == true)
                                {
                                    string[] splitstring1 = thirdtreeNodes[j].Text.Split(new char[] { '_' });
                                    paramnames.Add(splitstring1[0]);
                                }
                            }

                            string categotyandinstance = category.Id.ToString() + "_" + "1";
                            if (paramnames.Count != 0)
                            {
                                categoryparams.Add(categotyandinstance, paramnames);
                            }

                        }


                    }

                }


            }


            paramskeyValuePairs = categoryparams;



            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        bool check = false;

        private void treeView1_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (check == false)
            {
                setchild(e.Node);
            }
            setparent(e.Node);

            check = false;
        }


        //设置子节点状态
        private void setchild(TreeNode treeNode)
        {
            foreach (TreeNode item in treeNode.Nodes)
            {
                item.Checked = treeNode.Checked;
            }
            check = true;
        }

        //设置父节点状态
        private void setparent(TreeNode treeNode)
        {
            if (treeNode.Parent != null)
            {
                //if (treeNode.Checked)
                //{
                //    foreach (TreeNode brother in treeNode.Parent.Nodes)
                //    {
                //        if (brother.Checked==false)
                //        {
                //            return;
                //        }
                //    }
                //}
                treeNode.Parent.Checked = treeNode.Checked;
            }
        }


    }
}
