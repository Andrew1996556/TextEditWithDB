using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestTask1
{
    public partial class Form_dataBase : Form
    {
        public string name;
        public string content;

        public Form_dataBase()
        {
            InitializeComponent();
        }

        private void Form_dataBase_Load(object sender, EventArgs e)
        {            
            this.dataBaseFilesTableAdapter.Fill(this.dATABASEDataSet.DataBaseFiles);
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            name = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            content = dataGridView1.CurrentRow.Cells[2].Value.ToString();

            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
    }
}
