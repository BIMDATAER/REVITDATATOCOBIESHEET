using BIMDelivery.Common;
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
    public partial class ExportForm : Form
    {
        public string filename;
        public string exportpath;
        public List<string> filenames;

        List<string> files = new List<string>();

        public ExportForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            filenames = files;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void ExportForm_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            filename = textBox1.Text;

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            exportpath = textBox2.Text;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FilePathHelper filePathHelper = new FilePathHelper();
            textBox2.Text=filePathHelper.SelectPath();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                files.Add("楼层");
                
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked)
            {
                files.Add("类型");
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                files.Add("空间");
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                files.Add("设施");
            }
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked)
            {
                files.Add("系统");
            }
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox6.Checked)
            {
                files.Add("组件");
            }
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox7.Checked)
            {
                files.Add("属性");
            }
        }
    }
}
