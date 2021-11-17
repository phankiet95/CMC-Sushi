using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CMC_Suhi
{
    public partial class FrmMain : MetroFramework.Forms.MetroForm
    {
        DataTable dataTable = new DataTable();
        string path = "";
        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            dataTable.Columns.Add("No");
            dataTable.Columns.Add("Key");
            dataTable.Columns.Add("Data");

            dataOutput.DataSource = dataTable;
            dataOutput.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataOutput.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void txtInput_TextChanged(object sender, EventArgs e)
        {
            //txtOutput.ResetText();
            //txtOutput.Text = StringHelper.getOutput(txtData1.Text, txtData2.Text, txtInput.Text);

            dataTable.Clear();
            StringHelper.getOutputList(txtData1.Text, txtData2.Text, txtInput.Text, dataTable);
            dataOutput.DataSource = dataTable;
            lblStatus.Text = path + " *";
        }

        private void txtInput_Load(object sender, EventArgs e)
        {

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "sushi files (*.sushi)|*.sushi|All files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                path = openFileDialog.FileName;
                Tuple<string, string, string> tup = JsonConvert.DeserializeObject<Tuple<string,string,string>>(File.ReadAllText(path));
                txtData1.Text = tup.Item1;
                txtData2.Text = tup.Item2;
                txtInput.Text = tup.Item3;
                txtData1.Refresh();
                txtData2.Refresh();
                txtInput.Refresh();
            }
            lblStatus.Text = path;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (path != "")
            {
                Tuple<string, string, string> tup = new Tuple<string, string, string>(txtData1.Text, txtData2.Text, txtInput.Text);
                string json = JsonConvert.SerializeObject(tup);
                File.WriteAllText(path, json, Encoding.UTF8);
                lblStatus.Text = path;

            } else
            {
                callSaveAS();
            }

        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            callSaveAS();
        }

        private void callSaveAS()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "sushi files (*.sushi)|*.sushi|All files (*.*)|*.*";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                path = saveFileDialog.FileName;
                Tuple<string, string, string> tup = new Tuple<string, string, string>(txtData1.Text, txtData2.Text, txtInput.Text);
                string json = JsonConvert.SerializeObject(tup);
                File.WriteAllText(path, json, Encoding.UTF8);
            }
            lblStatus.Text = path;
        }

        private void txtData2_TextChanged(object sender, EventArgs e)
        {
            lblStatus.Text = path + " *";
        }

        private void txtData1_TextChanged(object sender, EventArgs e)
        {
            lblStatus.Text = path + " *";
        }

        private void picIcon_Click(object sender, EventArgs e)
        {
            FrmAbout about = new FrmAbout();
            about.ShowDialog();
        }

        private void getSQLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmSQL frmSQL = new FrmSQL(StringHelper.getSQL(dataTable));
            frmSQL.Show();
        }
    }
}
