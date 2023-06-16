using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BarcodeSysCloudSync
{
    public partial class MainFrm : Form
    {
        Class.LocalConnection con = new Class.LocalConnection();
        public MainFrm()
        {
            InitializeComponent();

            if (con.sqlCon())
            {
                lblStatus.ForeColor = Color.Green;
                lblStatus.Text = "Connected";
            }
            else
            {
                lblStatus.ForeColor = Color.Red;
                lblStatus.Text = "Disconnected";
            }
        }

        private void btnDT_Click(object sender, EventArgs e)
        {
            DTFrm dTFrm = new DTFrm();
            dTFrm.ShowDialog();
        }

        private void MainFrm_Load(object sender, EventArgs e)
        {

        }

        private void btnOS_Click(object sender, EventArgs e)
        {
            VanFrm vanFrm = new VanFrm();
            vanFrm.ShowDialog();
        }

        private void btnOs_Click_1(object sender, EventArgs e)
        {
            OSFrm osFrm = new OSFrm();
            osFrm.ShowDialog();
        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            IssuingFrm isueFrm = new IssuingFrm();
            isueFrm.ShowDialog();
        }
    }
}
