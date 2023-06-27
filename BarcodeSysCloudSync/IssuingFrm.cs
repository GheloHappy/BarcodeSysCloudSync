using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BarcodeSysCloudSync
{
    public partial class IssuingFrm : Form
    {
        Class.LocalConnection con = new Class.LocalConnection();
        public IssuingFrm()
        {
            InitializeComponent();
        }

        private void IssuingFrm_Load(object sender, EventArgs e)
        {

        }

        private async void btnIssue_Click(object sender, EventArgs e)
        {
            DateTime userDate = dtpDTDate.Value;
            string formattedDate = userDate.ToString("yyyy-MM-dd");
            string url = "https://barcodesys.happywee.site/api/v2/getIssueByDate/" + formattedDate;
            using (var client = new WebClient())
            {

                string json = await client.DownloadStringTaskAsync(new Uri(url));
                dynamic data = JsonConvert.DeserializeObject(json);

                DateTime _tranDate;
                string tranDate;

                DataTable dtIssue = new DataTable();

                dtIssue.Columns.Add("TranDate", typeof(string));
                dtIssue.Columns.Add("RefNbr", typeof(string));
                dtIssue.Columns.Add("InvtID", typeof(string));
                dtIssue.Columns.Add("Descr", typeof(string));
                dtIssue.Columns.Add("UnitDesc", typeof(string));
                dtIssue.Columns.Add("Qty", typeof(int));
                dtIssue.Columns.Add("CnvFact", typeof(int));

                foreach (dynamic item in data)
                {
                    if (item != null)
                    {
                        _tranDate = Convert.ToDateTime(item.TranDate);
                        tranDate = _tranDate.ToString("yyyy-MM-dd").Trim();
                        string RefNbr = item.RefNbr.ToString().Trim();
                        string InvtID = item.InvtID.ToString().Trim();
                        string Descr = item.Descr.ToString().Trim();
                        string UnitDesc = item.UnitDesc.ToString().Trim();
                        int Qty = item.Qty;
                        int CnvFact = item.CnvFact;

                        dtIssue.Rows.Add(tranDate, RefNbr, InvtID, Descr, UnitDesc, Qty, CnvFact);
                    }
                    else
                    {
                        MessageBox.Show("NO Data Retrieved");
                    }
                }

                if (con.InsertIssue(dtIssue))
                {
                    MessageBox.Show("ISSUING successfully Sync");
                }
                else
                {
                    MessageBox.Show("Sync Failed");
                }
            }
        }
    }
}
