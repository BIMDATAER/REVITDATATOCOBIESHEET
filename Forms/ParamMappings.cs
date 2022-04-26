using Autodesk.Revit.DB;
using BIMDelivery.Model;
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
    public partial class ParamMappings : System.Windows.Forms.Form
    {
        Document document;

        public DataGridViewRowCollection rows { get; set; }
        public ParamMappings(Document doc)
        {
            document = doc;
            InitializeComponent();

            this.dataGridView1.Rows.Add("类型", "文本", "所有", "创建人", "类型创建人");
            this.dataGridView1.Rows.Add("类型", "文本", "所有", "创建时间", "类型创建时间");
            this.dataGridView1.Rows.Add("实例", "文本", "所有", "创建人", "创建人");
            this.dataGridView1.Rows.Add("实例", "文本", "所有", "创建时间", "创建时间");



            this.dataGridView1.Rows.Add("实例", "文本", "组件", "名称", "组件名称");
            this.dataGridView1.Rows.Add("实例", "文本", "组件", "空间", "空间");
            this.dataGridView1.Rows.Add("实例", "文本", "组件", "描述", "组件描述");
            this.dataGridView1.Rows.Add("实例", "文本", "组件", "序号", "组件序号");
            this.dataGridView1.Rows.Add("实例", "文本", "组件", "安装日期", "组件安装日期");
            this.dataGridView1.Rows.Add("实例", "文本", "组件", "保修开始日期", "组件保修开始日期");
            this.dataGridView1.Rows.Add("实例", "文本", "组件", "标记号", "组件标记");
            this.dataGridView1.Rows.Add("实例", "文本", "组件", "条形码", "组件条形码");
            this.dataGridView1.Rows.Add("实例", "文本", "组件", "资产识别码", "组件资产识别码");
            this.dataGridView1.Rows.Add("实例", "文本", "组件", "面积", "组件面积");
            this.dataGridView1.Rows.Add("实例", "文本", "组件", "长度", "组件长度");



            this.dataGridView1.Rows.Add("实例", "文本", "设施", "设施名称", "设施名称");
            this.dataGridView1.Rows.Add("实例", "文本", "设施", "设施类别", "设施类别");
            this.dataGridView1.Rows.Add("实例", "文本", "设施", "项目名称", "项目名称");
            this.dataGridView1.Rows.Add("实例", "文本", "设施", "场地名称", "场地名称");
            this.dataGridView1.Rows.Add("实例", "文本", "设施", "长度单位", "长度单位");
            this.dataGridView1.Rows.Add("实例", "文本", "设施", "面积单位", "面积单位");
            this.dataGridView1.Rows.Add("实例", "文本", "设施", "体积单位", "体积单位");
            this.dataGridView1.Rows.Add("实例", "文本", "设施", "货币单位", "货币单位");
            this.dataGridView1.Rows.Add("实例", "文本", "设施", "面积测量", "测量标准");
            this.dataGridView1.Rows.Add("实例", "文本", "设施", "描述", "设施描述");
            this.dataGridView1.Rows.Add("实例", "文本", "设施", "项目描述", "项目描述");
            this.dataGridView1.Rows.Add("实例", "文本", "设施", "场地描述", "场地描述");
            this.dataGridView1.Rows.Add("实例", "文本", "设施", "阶段", "阶段");

            this.dataGridView1.Rows.Add("实例", "文本", "楼层", "名称", "楼层名称");
            this.dataGridView1.Rows.Add("实例", "文本", "楼层", "类别", "楼层类别");
            this.dataGridView1.Rows.Add("实例", "文本", "楼层", "描述", "楼层描述");
            this.dataGridView1.Rows.Add("实例", "文本", "楼层", "标高", "标高");
            this.dataGridView1.Rows.Add("实例", "文本", "楼层", "高度", "高度");




            this.dataGridView1.Rows.Add("实例", "文本", "空间", "名称", "空间名称");
            this.dataGridView1.Rows.Add("实例", "文本", "空间", "类别", "空间类别");
            this.dataGridView1.Rows.Add("实例", "文本", "空间", "描述", "空间描述");
            this.dataGridView1.Rows.Add("实例", "文本", "空间", "房间标签", "房间标签");
            this.dataGridView1.Rows.Add("实例", "文本", "空间", "可用高度", "房间可用高度");
            this.dataGridView1.Rows.Add("实例", "文本", "空间", "总面积", "房间总面积");
            this.dataGridView1.Rows.Add("实例", "文本", "空间", "网格面积", "房间网格面积");


            this.dataGridView1.Rows.Add("实例", "文本", "系统", "名称", "系统名称");
            this.dataGridView1.Rows.Add("实例", "文本", "系统", "类别", "系统类别");
            this.dataGridView1.Rows.Add("实例", "文本", "系统", "描述", "系统描述");

            this.dataGridView1.Rows.Add("类型", "文本", "类型", "名称", "类型名称");
            this.dataGridView1.Rows.Add("类型", "文本", "类型", "类别", "类型类别");
            this.dataGridView1.Rows.Add("类型", "文本", "类型", "描述", "类型描述");
            this.dataGridView1.Rows.Add("类型", "文本", "类型", "资产类型", "资产类型");
            this.dataGridView1.Rows.Add("类型", "文本", "类型", "制造商", "制造商");
            this.dataGridView1.Rows.Add("类型", "文本", "类型", "型号", "型号");
            this.dataGridView1.Rows.Add("类型", "文本", "类型", "组件质保人", "组件质保人");
            this.dataGridView1.Rows.Add("类型", "文本", "类型", "组件质保期限", "组件质保期限");
            this.dataGridView1.Rows.Add("类型", "文本", "类型", "质保人", "质保人");
            this.dataGridView1.Rows.Add("类型", "文本", "类型", "质保期限", "质保期限");
            this.dataGridView1.Rows.Add("类型", "文本", "类型", "质保期限单位", "质保期限单位");
            this.dataGridView1.Rows.Add("类型", "文本", "类型", "更换费用", "更换费用");
            this.dataGridView1.Rows.Add("类型", "文本", "类型", "预期寿命", "预期寿命");
            this.dataGridView1.Rows.Add("类型", "文本", "类型", "寿命单位", "寿命单位");
            this.dataGridView1.Rows.Add("类型", "文本", "类型", "保修描述", "保修描述");
            this.dataGridView1.Rows.Add("类型", "文本", "类型", "名义长度", "名义长度");
            this.dataGridView1.Rows.Add("类型", "文本", "类型", "名义宽度", "名义宽度");
            this.dataGridView1.Rows.Add("类型", "文本", "类型", "名义高度", "名义高度");
            this.dataGridView1.Rows.Add("类型", "文本", "类型", "模型引用", "模型引用");
            this.dataGridView1.Rows.Add("类型", "文本", "类型", "形状", "形状");
            this.dataGridView1.Rows.Add("类型", "文本", "类型", "尺寸", "尺寸");
            this.dataGridView1.Rows.Add("类型", "文本", "类型", "颜色", "颜色");
            this.dataGridView1.Rows.Add("类型", "文本", "类型", "最终态", "最终态");
            this.dataGridView1.Rows.Add("类型", "文本", "类型", "等级", "等级");
            this.dataGridView1.Rows.Add("类型", "文本", "类型", "材质", "材质");
            this.dataGridView1.Rows.Add("类型", "文本", "类型", "组成成分", "组成成分");
            this.dataGridView1.Rows.Add("类型", "文本", "类型", "特点", "特点");
            this.dataGridView1.Rows.Add("类型", "文本", "类型", "可接触性能", "可接触性能");
            this.dataGridView1.Rows.Add("类型", "文本", "类型", "编码性能", "编码性能");
            this.dataGridView1.Rows.Add("类型", "文本", "类型", "可持续性能", "可持续性能");
            this.dataGridView1.Rows.Add("类型", "文本", "类型", "面积", "类型面积");
            this.dataGridView1.Rows.Add("类型", "文本", "类型", "长度", "类型长度");



            rows = this.dataGridView1.Rows;



        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ParamMappings_Load(object sender, EventArgs e)
        {
            //this.dataGridView1.Rows.Add("类型", "文本", "所有", "创建人", "类型创建人");
            //this.dataGridView1.Rows.Add("类型", "文本", "所有", "创建时间", "类型创建时间");
            //this.dataGridView1.Rows.Add("实例", "文本", "所有", "创建人", "创建人");
            //this.dataGridView1.Rows.Add("实例", "文本", "所有", "创建时间", "创建时间");



            //this.dataGridView1.Rows.Add("实例", "文本", "组件", "名称", "组件名称");
            //this.dataGridView1.Rows.Add("实例", "文本", "组件", "空间", "空间");
            //this.dataGridView1.Rows.Add("实例", "文本", "组件", "描述", "组件描述");
            //this.dataGridView1.Rows.Add("实例", "文本", "组件", "序号", "组件序号");
            //this.dataGridView1.Rows.Add("实例", "文本", "组件", "安装日期", "组件安装日期");
            //this.dataGridView1.Rows.Add("实例", "文本", "组件", "保修开始日期", "组件保修开始日期");
            //this.dataGridView1.Rows.Add("实例", "文本", "组件", "标记号", "组件标记");
            //this.dataGridView1.Rows.Add("实例", "文本", "组件", "条形码", "组件条形码");
            //this.dataGridView1.Rows.Add("实例", "文本", "组件", "资产识别码", "组件资产识别码");
            //this.dataGridView1.Rows.Add("实例", "文本", "组件", "面积", "组件面积");
            //this.dataGridView1.Rows.Add("实例", "文本", "组件", "长度", "组件长度");



            //this.dataGridView1.Rows.Add("实例", "文本", "设施", "设施名称", "设施名称");
            //this.dataGridView1.Rows.Add("实例", "文本", "设施", "设施类别", "设施类别");
            //this.dataGridView1.Rows.Add("实例", "文本", "设施", "项目名称", "项目名称");
            //this.dataGridView1.Rows.Add("实例", "文本", "设施", "场地名称", "场地名称");
            //this.dataGridView1.Rows.Add("实例", "文本", "设施", "长度单位", "长度单位");
            //this.dataGridView1.Rows.Add("实例", "文本", "设施", "面积单位", "面积单位");
            //this.dataGridView1.Rows.Add("实例", "文本", "设施", "体积单位", "体积单位");
            //this.dataGridView1.Rows.Add("实例", "文本", "设施", "货币单位", "货币单位");
            //this.dataGridView1.Rows.Add("实例", "文本", "设施", "面积测量", "测量标准");
            //this.dataGridView1.Rows.Add("实例", "文本", "设施", "描述", "设施描述");
            //this.dataGridView1.Rows.Add("实例", "文本", "设施", "项目描述", "项目描述");
            //this.dataGridView1.Rows.Add("实例", "文本", "设施", "场地描述", "场地描述");
            //this.dataGridView1.Rows.Add("实例", "文本", "设施", "阶段", "阶段");

            //this.dataGridView1.Rows.Add("实例", "文本", "楼层", "名称", "楼层名称");
            //this.dataGridView1.Rows.Add("实例", "文本", "楼层", "类别", "楼层类别");
            //this.dataGridView1.Rows.Add("实例", "文本", "楼层", "描述", "楼层描述");
            //this.dataGridView1.Rows.Add("实例", "文本", "楼层", "标高", "标高");
            //this.dataGridView1.Rows.Add("实例", "文本", "楼层", "高度", "高度");




            //this.dataGridView1.Rows.Add("实例", "文本", "空间", "名称", "空间名称");
            //this.dataGridView1.Rows.Add("实例", "文本", "空间", "类别", "空间类别");
            //this.dataGridView1.Rows.Add("实例", "文本", "空间", "描述", "空间描述");
            //this.dataGridView1.Rows.Add("实例", "文本", "空间", "房间标签", "房间标签");
            //this.dataGridView1.Rows.Add("实例", "文本", "空间", "可用高度", "房间可用高度");
            //this.dataGridView1.Rows.Add("实例", "文本", "空间", "总面积", "房间总面积");
            //this.dataGridView1.Rows.Add("实例", "文本", "空间", "网格面积", "房间网格面积");


            //this.dataGridView1.Rows.Add("实例", "文本", "系统", "名称", "系统名称");
            //this.dataGridView1.Rows.Add("实例", "文本", "系统", "类别", "系统类别");
            //this.dataGridView1.Rows.Add("实例", "文本", "系统", "描述", "系统描述");

            //this.dataGridView1.Rows.Add("类型", "文本", "类型", "名称", "类型名称");
            //this.dataGridView1.Rows.Add("类型", "文本", "类型", "类别", "类型类别");
            //this.dataGridView1.Rows.Add("类型", "文本", "类型", "描述", "类型描述");
            //this.dataGridView1.Rows.Add("类型", "文本", "类型", "资产类型", "资产类型");
            //this.dataGridView1.Rows.Add("类型", "文本", "类型", "制造商", "制造商");
            //this.dataGridView1.Rows.Add("类型", "文本", "类型", "型号", "型号");
            //this.dataGridView1.Rows.Add("类型", "文本", "类型", "组件质保人", "组件质保人");
            //this.dataGridView1.Rows.Add("类型", "文本", "类型", "组件质保期限", "组件质保期限");
            //this.dataGridView1.Rows.Add("类型", "文本", "类型", "质保人", "质保人");
            //this.dataGridView1.Rows.Add("类型", "文本", "类型", "质保期限", "质保期限");
            //this.dataGridView1.Rows.Add("类型", "文本", "类型", "质保期限单位", "质保期限单位");
            //this.dataGridView1.Rows.Add("类型", "文本", "类型", "更换费用", "更换费用");
            //this.dataGridView1.Rows.Add("类型", "文本", "类型", "预期寿命", "预期寿命");
            //this.dataGridView1.Rows.Add("类型", "文本", "类型", "寿命单位", "寿命单位");
            //this.dataGridView1.Rows.Add("类型", "文本", "类型", "保修描述", "保修描述");
            //this.dataGridView1.Rows.Add("类型", "文本", "类型", "名义长度", "名义长度");
            //this.dataGridView1.Rows.Add("类型", "文本", "类型", "名义宽度", "名义宽度");
            //this.dataGridView1.Rows.Add("类型", "文本", "类型", "名义高度", "名义高度");
            //this.dataGridView1.Rows.Add("类型", "文本", "类型", "模型引用", "模型引用");
            //this.dataGridView1.Rows.Add("类型", "文本", "类型", "形状", "形状");
            //this.dataGridView1.Rows.Add("类型", "文本", "类型", "尺寸", "尺寸");
            //this.dataGridView1.Rows.Add("类型", "文本", "类型", "颜色", "颜色");
            //this.dataGridView1.Rows.Add("类型", "文本", "类型", "最终态", "最终态");
            //this.dataGridView1.Rows.Add("类型", "文本", "类型", "等级", "等级");
            //this.dataGridView1.Rows.Add("类型", "文本", "类型", "材质", "材质");
            //this.dataGridView1.Rows.Add("类型", "文本", "类型", "组成成分", "组成成分");
            //this.dataGridView1.Rows.Add("类型", "文本", "类型", "特点", "特点");
            //this.dataGridView1.Rows.Add("类型", "文本", "类型", "可接触性能", "可接触性能");
            //this.dataGridView1.Rows.Add("类型", "文本", "类型", "编码性能", "编码性能");
            //this.dataGridView1.Rows.Add("类型", "文本", "类型", "可持续性能", "可持续性能");
            //this.dataGridView1.Rows.Add("类型", "文本", "类型", "面积", "类型面积");
            //this.dataGridView1.Rows.Add("类型", "文本", "类型", "长度", "类型长度");



            //rows = this.dataGridView1.Rows;
        }



        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            CategorySet categorySet = new CategorySet();
            InstanceBinding instanceBinding = new InstanceBinding();
            TypeBinding typeBinding = new TypeBinding();
            List<Category> categories = new List<Category>();
            //List<string> stringname = new List<string>();
            if ((string)this.dataGridView1.CurrentRow.Cells[2].Value == "所有")
            {
                textBox2.Text = "";
                categorySet = instanceBinding.Categories;

                ParamMap paramMap = new ParamMap();
                categories = paramMap.GetallCategories(document);
                
                foreach (Category category in categories)
                {
                    textBox2.AppendText(category.Name+ "\r\n");
                }                             
            }

            if ((string)this.dataGridView1.CurrentRow.Cells[2].Value == "类型")
            {
                textBox2.Text = "";
                categorySet = instanceBinding.Categories;

                ParamMap paramMap = new ParamMap();
                categories = paramMap.GetTypeCategories(document);

                foreach (Category category in categories)
                {
                    textBox2.AppendText(category.Name + "\r\n");
                }
            }

            if ((string)this.dataGridView1.CurrentRow.Cells[2].Value == "组件")
            {
                textBox2.Text = "";
                categorySet = instanceBinding.Categories;

                ParamMap paramMap = new ParamMap();
                categories = paramMap.GetComponentCategories(document);

                foreach (Category category in categories)
                {
                    textBox2.AppendText(category.Name + "\r\n");
                }
            }

            if ((string)this.dataGridView1.CurrentRow.Cells[2].Value == "设施")
            {
                textBox2.Text = "";
                categorySet = instanceBinding.Categories;

                ParamMap paramMap = new ParamMap();
                categories = paramMap.GetFacilityCategories(document);

                foreach (Category category in categories)
                {
                    textBox2.AppendText(category.Name + "\r\n");
                }
            }


            if ((string)this.dataGridView1.CurrentRow.Cells[2].Value == "楼层")
            {
                textBox2.Text = "";
                categorySet = instanceBinding.Categories;

                ParamMap paramMap = new ParamMap();
                categories = paramMap.GetFloorCategories(document);

                foreach (Category category in categories)
                {
                    textBox2.AppendText(category.Name + "\r\n");
                }
            }

            if ((string)this.dataGridView1.CurrentRow.Cells[2].Value == "空间")
            {
                textBox2.Text = "";
                categorySet = instanceBinding.Categories;

                ParamMap paramMap = new ParamMap();
                categories = paramMap.GetSpaceCategories(document);

                foreach (Category category in categories)
                {
                    textBox2.AppendText(category.Name + "\r\n");
                }
            }

            if ((string)this.dataGridView1.CurrentRow.Cells[2].Value == "系统")
            {
                textBox2.Text = "";
                categorySet = instanceBinding.Categories;

                ParamMap paramMap = new ParamMap();
                categories = paramMap.GetSystemCategories(document);

                foreach (Category category in categories)
                {
                    textBox2.AppendText(category.Name + "\r\n");
                }
            }




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

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
