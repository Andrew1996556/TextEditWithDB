using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestTask1
{
    public partial class Main_Form : Form
    {
        string connectionString = @"Data Source =DESKTOP-2N1E70M;Initial Catalog = DATABASE;Integrated Security = True";
        Form_rename form_Rename = new Form_rename();
        Form_dataBase form_Data = new Form_dataBase();
        public Main_Form()
        {
            InitializeComponent();
        }

        private void Main_Form_Load(object sender, EventArgs e)
        {

        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (richTextBox1.Text != "")
            {
                DialogResult dialogResult = MessageBox.Show(
                 "Save current file?",
                 "Message",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Information,
                MessageBoxDefaultButton.Button1,
                MessageBoxOptions.DefaultDesktopOnly);

                if (dialogResult == DialogResult.Yes && saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    richTextBox1.SaveFile(saveFileDialog.FileName);

                }
            }
            this.richTextBox1.Clear();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.Text = File.ReadAllText(openFileDialog.FileName);
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile1 = new SaveFileDialog();

            if (saveFile1.ShowDialog() == System.Windows.Forms.DialogResult.OK && saveFile1.FileName.Length > 0)
            {
                using (StreamWriter sw = new StreamWriter(saveFile1.FileName, true))
                {
                    sw.WriteLine(richTextBox1.Text);
                    sw.Close();
                }
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }       

        private void getFileFromDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            form_Data.ShowDialog();
            richTextBox1.Clear();
            richTextBox1.Text = form_Data.content;
            Text = form_Data.name;
        }

        private void dessFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            form_Rename.ShowDialog();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = @"INSERT INTO DataBaseFiles (FileName,FileData)VALUES (@FileName, @FileData)";
                command.Parameters.AddWithValue("@FileName", form_Rename.fileName);              
                command.Parameters.AddWithValue("@FileData", richTextBox1.Text);
                
               

                command.ExecuteNonQuery();
            }
        }

        private void otherFileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        public static byte[] StringtToByteArray(string str)
        {
            BinaryFormatter bf = new BinaryFormatter();
            using (var ms = new MemoryStream())
            {
                bf.Serialize(ms, str);
                return ms.ToArray();
            }
        }
    }
}
