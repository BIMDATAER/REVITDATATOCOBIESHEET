using Autodesk.Revit.DB;
using BIMDelivery.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BIMDelivery.Forms
{
    public partial class RevitParamUpdateForm : System.Windows.Forms.Form
    {
        Document document;
        DataGridViewComboBoxColumn cmbox;
        public DataGridViewRowCollection rows { get; set; }
        public RevitParamUpdateForm(Document doc)
        {
            document = doc;
            InitializeComponent();

            //DataGridViewComboBoxColumn cmbox=this.dataGridView1.Columns["更新类别"] as DataGridViewComboBoxColumn;
            //cmbox.Items.AddRange();
            bool exportornot = false;
            this.dataGridView1.Rows.Add(exportornot, "类型", "保修描述", "类型", "保修描述");
            this.dataGridView1.Rows.Add(exportornot, "类型", "类别", "类型", "类型类别");
            this.dataGridView1.Rows.Add(exportornot, "类型", "描述", "类型", "类型描述");
            this.dataGridView1.Rows.Add(exportornot, "类型", "资产类型", "类型", "资产类型");
            this.dataGridView1.Rows.Add(exportornot, "类型", "制造商", "类型", "制造商");
            this.dataGridView1.Rows.Add(exportornot, "类型", "型号", "类型", "型号");
            this.dataGridView1.Rows.Add(exportornot, "类型", "质保人", "类型", "质保人");
            this.dataGridView1.Rows.Add(exportornot, "类型", "更换费用", "类型", "更换费用");
            this.dataGridView1.Rows.Add(exportornot, "类型", "质保期限", "类型", "质保期限");
            this.dataGridView1.Rows.Add(exportornot, "类型", "材质", "类型", "材质");

            this.dataGridView1.Rows.Add(exportornot, "组件", "安装日期", "实例", "组件安装日期");
            this.dataGridView1.Rows.Add(exportornot, "组件", "描述", "实例", "组件描述");
            this.dataGridView1.Rows.Add(exportornot, "组件", "资产识别码", "实例", "组件资产识别码");
            this.dataGridView1.Rows.Add(exportornot, "组件", "标记号", "实例", "组件标记");
            this.dataGridView1.Rows.Add(exportornot, "组件", "条形码", "实例", "组件条形码");
            this.dataGridView1.Rows.Add(exportornot, "组件", "序号", "实例", "组件序号");
            this.dataGridView1.Rows.Add(exportornot, "组件", "空间", "实例", "空间");

            //this.dataGridView1.Rows.Add(exportornot, "楼层", "描述", "实例", "楼层描述");

            //this.dataGridView1.Rows.Add(exportornot, "设施", "描述", "实例", "项目描述");
            //this.dataGridView1.Rows.Add(exportornot, "设施", "阶段", "实例", "阶段");

            rows = this.dataGridView1.Rows;

        }

        private void RevitParamUpdateForm_Load(object sender, EventArgs e)
        {

            cmbox = new DataGridViewComboBoxColumn();

            cmbox.HeaderText = "更新类别";
            this.dataGridView1.Columns.Add(cmbox);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            CategorySet categorySet = new CategorySet();
            InstanceBinding instanceBinding = new InstanceBinding();
            TypeBinding typeBinding = new TypeBinding();
            List<Category> categories = new List<Category>();
            List<string> stringname = new List<string>();

            if ((string)this.dataGridView1.CurrentRow.Cells[1].Value == "所有")
            {
                categorySet = instanceBinding.Categories;

                ParamMap paramMap = new ParamMap();
                categories = paramMap.GetallCategories(document);

                foreach (Category category in categories)
                {
                    stringname.Add(category.Name);
                }
                cmbox.DataSource = stringname;

            }

            if ((string)this.dataGridView1.CurrentRow.Cells[1].Value == "类型")
            {
                categorySet = instanceBinding.Categories;
                ParamMap paramMap = new ParamMap();
                categories = paramMap.GetTypeCategories(document);

                foreach (Category category in categories)
                {
                    //stringname.Add(category.Name + "\r\n");

                    stringname.Add(category.Name );
                }
                cmbox.DataSource = stringname;
            }

            if ((string)this.dataGridView1.CurrentRow.Cells[1].Value == "组件")
            {
                categorySet = instanceBinding.Categories;

                ParamMap paramMap = new ParamMap();
                categories = paramMap.GetComponentCategories(document);

                foreach (Category category in categories)
                {
                    stringname.Add(category.Name);
                }
                cmbox.DataSource = stringname;
            }

            if ((string)this.dataGridView1.CurrentRow.Cells[1].Value == "设施")
            {
                categorySet = instanceBinding.Categories;

                ParamMap paramMap = new ParamMap();
                categories = paramMap.GetFacilityCategories(document);

                foreach (Category category in categories)
                {
                    stringname.Add(category.Name);
                }
                cmbox.DataSource = stringname;
            }


            if ((string)this.dataGridView1.CurrentRow.Cells[1].Value == "楼层")
            {
                categorySet = instanceBinding.Categories;

                ParamMap paramMap = new ParamMap();
                categories = paramMap.GetFloorCategories(document);

                foreach (Category category in categories)
                {
                    stringname.Add(category.Name);
                }
                cmbox.DataSource = stringname;
            }

            if ((string)this.dataGridView1.CurrentRow.Cells[1].Value == "空间")
            {
                categorySet = instanceBinding.Categories;

                ParamMap paramMap = new ParamMap();
                categories = paramMap.GetSpaceCategories(document);

                foreach (Category category in categories)
                {
                    stringname.Add(category.Name );
                }
                cmbox.DataSource = stringname;
            }

            if ((string)this.dataGridView1.CurrentRow.Cells[1].Value == "系统")
            {
                categorySet = instanceBinding.Categories;

                ParamMap paramMap = new ParamMap();
                categories = paramMap.GetSystemCategories(document);

                foreach (Category category in categories)
                {
                    stringname.Add(category.Name);
                }
                cmbox.DataSource = stringname;
            }





        }

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {



        }

        public void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

             
        }

        public void combox_Leave(object sender, EventArgs e)
        {
           

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
