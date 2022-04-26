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
    public partial class AssetsForm : System.Windows.Forms.Form
    {
        Document document;
        public List<Element> instanceelements;


        public AssetsForm(Document doc)
        {
            InitializeComponent();
            document = doc;
        }

        private void AssetsForm_Load(object sender, EventArgs e)
        {
            //添加模型中资产列表

            Categories categories = document.Settings.Categories;
            foreach (Category category in categories)
            {
                var element = new FilteredElementCollector(document).OfCategory((BuiltInCategory)category.Id.IntegerValue).WhereElementIsNotElementType().ToElements();
                if (element != null)
                {
                    TreeNode FirstNode = new TreeNode();
                    FirstNode.Text = category.Name;
                    treeView1.Nodes.Add(FirstNode);

                    //获取模型中实例
                    foreach (var item in element)
                    {
                        TreeNode SecondNode = new TreeNode();
                        SecondNode.Text = item.Name + "_" + item.Id;
                        FirstNode.Nodes.Add(SecondNode);
                    }
                }

            }


        }

        private void button3_Click(object sender, EventArgs e)
        {

            //添加到已选中的元素

            TreeNodeCollection treeNodeCollection = this.treeView1.Nodes;
            List<Element> elements = new List<Element>();
            for (int ii = 0; ii < treeNodeCollection.Count; ii++)
            {
                TreeNodeCollection secondtreeNodes = treeNodeCollection[ii].Nodes;
                for (int i = 0; i < secondtreeNodes.Count; i++)
                {
                    if (secondtreeNodes[i].Checked == true)
                    {
                        //获取被选中的实例
                        string[] namesplit = secondtreeNodes[i].Text.Split(new char[] { '_' });

                        //判断是否可转为数字
                        if (IsNumeric(namesplit[1]))
                        {
                            ElementId elementId = new ElementId(System.Convert.ToInt32(namesplit[1]));
                            Element instanceelement = document.GetElement(elementId);
                            elements.Add(instanceelement);
                        }

                    }
                }
            }

            instanceelements = elements;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }


        private bool IsNumeric(string number)
        {
            try
            {
                int.Parse(number);
                return true;
            }
            catch
            {

                return false;
            }
        }





        private void button4_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
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
                }
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            ////添加到已选中的元素

            //TreeNodeCollection treeNodeCollection = this.treeView1.Nodes;
            //for (int ii = 0; ii < treeNodeCollection.Count; ii++)
            //{
            //    TreeNodeCollection secondtreeNodes = treeNodeCollection[ii].Nodes;
            //    for (int i = 0; i < secondtreeNodes.Count; i++)
            //    {
            //        if (secondtreeNodes[i].Checked)
            //        {
            //            //获取被选中的实例
            //            string[] namesplit = secondtreeNodes[i].Text.Split(new char[] { ' ' });
            //            ElementId elementId = new ElementId(System.Convert.ToInt32(namesplit[1]));

            //            Element instanceelement = document.GetElement(elementId);
            //            instanceelements.Add(instanceelement);
            //        }
            //    }
            //}
        }

        bool check = false;
        private void treeView1_AfterCheck(object sender, TreeViewEventArgs e)
        {
            //一级选中，二级联动选中

            if (check==false)
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
            if (treeNode.Parent !=null)
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






        private void treeView1_BeforeCheck(object sender, TreeViewCancelEventArgs e)
        {

        }
    }
}
