using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BIMDelivery.Data;

namespace BIMDelivery.Forms
{
    public partial class ContactForm : Form
    {

        public ContactForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ContactForm_Load(object sender, EventArgs e)
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


        public string Email
        {
            get { return this.DialogResult == DialogResult.OK ? textBox2.Text : ""; }
        }


        public string CreatBy
        {
            get { return this.DialogResult == DialogResult.OK ? textBox1.Text : ""; }
        }



        public string Company
        {
            get { return this.DialogResult == DialogResult.OK ? textBox3.Text : ""; }
        }

        public string Category
        {
            get { return this.DialogResult == DialogResult.OK ? textBox5.Text : ""; }
        }


        public string Phone
        {
            get { return this.DialogResult == DialogResult.OK ? textBox4.Text : ""; }
        }

    }
}
