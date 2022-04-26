using Autodesk.RevitAddIns;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DTData
{
    public partial class MainForm : Form
    {

        RevitProduct revitProduct = null;


        public MainForm()
        {
            InitializeComponent();
            revitProduct = Helper.GetStartInfo();
            this.CenterToScreen();

            this.comboBox1.Items.Add(Helper.GetStartInfo().Name);
        }




        private bool StartRevit()
        {
            //增加判断是否安装revit对应版本


            string revitexefilename=Path.Combine(revitProduct.InstallLocation,@"Program\Revit.exe");
            if (!File.Exists(revitexefilename))
            {
                revitexefilename = Path.Combine(revitProduct.InstallLocation, @"Revit.exe");
            }

            Helper.CreatAddInFile(revitProduct);

            Process.Start(revitexefilename);



            return true;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //this.CenterToScreen();

            //this.comboBox1.Items.Add(Helper.GetStartInfo().Name);
        }

        private void comboBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (StartRevit())
            {
                this.Close();
            }
        }
    }
}
