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
    public partial class SettingsForm : System.Windows.Forms.Form
    {
        Document document;

        public Dictionary<string, List<string>> paramskeyValuePairs;

        //当前选择页
        public string checkedpagename;

        //一般设置内容

        public string Lineunit;
        public string Vounit;
        public string Areaunit;
        public string Timeunit;

        public string ExtIdentifierType;



        //空间设置内容

        public string spacesplitname;
        public string param1;
        public string param2;


        //类型设置内容

        public string typesplitname;
        public string typeparam1;
        public string typeparam2;
        public string typeparam3;
        public string discription;


        //组件设置内容
        public string componentsplitname;
        public string componentparam1;
        public string componentparam2;


        //系统设置内容

        public string systemsplitname;
        public string systemparam1;
        public string systemparam2;

        //属性设置内容



        //坐标系设置内容




        public SettingsForm(Document doc)
        {
            InitializeComponent();
            document = doc;
        }

        private void tabPage6_Click(object sender, EventArgs e)
        {

        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            checkedpagename = this.tabControl1.SelectedTab.Text;

            //FilteredElementCollector filterelement = new FilteredElementCollector(document);
            //List<Element> elements = filterelement.WhereElementIsElementType().ToElements().ToList();
            //foreach (Element element in elements)
            //{

            //    TreeNode FirstNode = new TreeNode();
            //    if (element.Category !=null)
            //    {
            //        FirstNode.Text = element.Category.Name;
            //    }
            //    treeView1.Nodes.Add(FirstNode);
            //    TreeNode SecondNode1 = new TreeNode();
            //    SecondNode1.Text = "类型参数";
            //    TreeNode SecondNode2 = new TreeNode();
            //    SecondNode2.Text = "实例参数";
            //    FirstNode.Nodes.Add(SecondNode1);
            //    FirstNode.Nodes.Add(SecondNode2);
            //    foreach (Parameter item in element.Parameters)
            //    {
            //        TreeNode ThirdNode1 = new TreeNode();
            //        ThirdNode1.Text = item.Definition.Name;
            //        SecondNode1.Nodes.Add(ThirdNode1);
            //    }

            //}

            Categories categories = document.Settings.Categories;
            foreach (Category category in categories)
            {
                Element element = new FilteredElementCollector(document).OfCategory((BuiltInCategory)category.Id.IntegerValue).WhereElementIsNotElementType().ToElements().FirstOrDefault();
                if (element !=null)
                {
                    TreeNode FirstNode = new TreeNode();
                    FirstNode.Text = category.Name+"_"+category.Id.IntegerValue;
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
                        ThirdNode2.Text = item.Definition.Name+"_"+item.Id;
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
                        if (element.GetTypeId() !=null && element.GetTypeId().ToString() !="-1")
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Lineunit = this.comboBox1.SelectedItem.ToString();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Areaunit = this.comboBox2.SelectedItem.ToString();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            Vounit = this.comboBox3.SelectedItem.ToString();

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            Timeunit = this.comboBox4.SelectedItem.ToString();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioButton1.Checked)
            {
                ExtIdentifierType = "元素ID";
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioButton2.Checked)
            {
                ExtIdentifierType = "GUID";
            }
        }

        private void button1_Click(object sender, EventArgs e)
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
                    string[] splitstring = treeNodeCollection[ii].Text.Split(new char[] {'_'});
                    ElementId elementId = new ElementId(System.Convert.ToInt32(splitstring[1]));
                    Category category=Category.GetCategory(document,elementId);

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
                            if (paramnames.Count !=0)
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
                            if (paramnames.Count !=0)
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

        private void button2_Click(object sender, EventArgs e)
        {

            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {
            //spacesplitname = this.textBox1.Text;
            //param1 = this.comboBox5.Text;
            //param2 = this.comboBox6.Text;
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {
            //typesplitname = this.textBox2.Text;
            //typeparam1 = this.comboBox8.Text;
            //typeparam2 = this.comboBox7.Text;
            //typeparam3=this.comboBox9.Text;
        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {
            //if (this.radioButton3.Checked)
            //{
            //    discription = "族：类型";
            //}
            //if (this.radioButton4.Checked)
            //{
            //    discription = "元素guid";
            //}
        }

        private void groupBox6_Enter(object sender, EventArgs e)
        {
            //componentsplitname = this.textBox3.Text;
            //componentparam1 = this.comboBox11.Text;
            //componentparam2 = this.comboBox10.Text;
        }

        private void groupBox7_Enter(object sender, EventArgs e)
        {
            //systemsplitname = this.textBox4.Text;
            //systemparam1 = this.comboBox13.Text;
            //systemparam2 = this.comboBox12.Text;
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {


        }

        private void button3_Click(object sender, EventArgs e)
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

        private void button4_Click(object sender, EventArgs e)
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

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            componentsplitname = this.textBox3.Text;
        }

        private void comboBox11_SelectedIndexChanged(object sender, EventArgs e)
        {
            componentparam1 = this.comboBox11.Text;
        }

        private void comboBox10_SelectedIndexChanged(object sender, EventArgs e)
        {
            componentparam2 = this.comboBox10.Text;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            spacesplitname = this.textBox1.Text;
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            param1 = this.comboBox5.SelectedItem.ToString();
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            param2 = this.comboBox6.SelectedItem.ToString();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            typesplitname = this.textBox2.Text;
        }

        private void comboBox8_SelectedIndexChanged(object sender, EventArgs e)
        {
            typeparam1 = this.comboBox8.SelectedItem.ToString();
        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            typeparam2 = this.comboBox7.SelectedItem.ToString();
        }

        private void comboBox9_SelectedIndexChanged(object sender, EventArgs e)
        {
            typeparam3 = this.comboBox9.SelectedItem.ToString();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            systemsplitname = this.textBox4.Text;
        }

        private void comboBox13_SelectedIndexChanged(object sender, EventArgs e)
        {
            systemparam1 = this.comboBox13.SelectedItem.ToString();
        }

        private void comboBox12_SelectedIndexChanged(object sender, EventArgs e)
        {
            systemparam2 = this.comboBox12.SelectedItem.ToString();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioButton3.Checked)
            {
                discription = "族：类型";
            }
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioButton4.Checked)
            {
                discription = "元素guid";
            }
        }
    }
}
