using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestTask1
{
    public partial class Form_rename : Form
    {       
        public string fileName = string.Empty;
        public Form_rename()
        {
            InitializeComponent();
        }

        private  void Form_rename_Load(object sender, EventArgs e)
        {           
           
        }

        private  void button1_Click(object sender, EventArgs e)
        {
            fileName = textBox1.Text;
            this.Close();
        }       
    }
}
