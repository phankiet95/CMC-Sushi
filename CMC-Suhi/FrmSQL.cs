using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CMC_Suhi
{
    public partial class FrmSQL : MetroFramework.Forms.MetroForm
    {

        string sql = "";
        
        public FrmSQL(string sql)
        {
            InitializeComponent();
            this.sql = sql;
        }

        private void FrmSQL_Load(object sender, EventArgs e)
        {
            txtText.Text = sql;
        }

        private void txtInput_Load(object sender, EventArgs e)
        {

        }

    }
}
