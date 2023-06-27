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
using Newtonsoft.Json;

namespace BarcodeSysCloudSync
{
    public partial class OSFrm : Form
    {
        Class.LocalConnection con = new Class.LocalConnection();
        public OSFrm()
        {
            InitializeComponent();
        }

        private async void btnOS_Click(object sender, EventArgs e)
        {
            DateTime userDate = dtpDTDate.Value;
            string formattedDate = userDate.ToString("yyyy-MM-dd");
            string url = "https://barcodesys.happywee.site/api/v2/getOSByDate/" + formattedDate;
            using (var client = new WebClient())
            {

                string json = await client.DownloadStringTaskAsync(new Uri(url));
                dynamic data = JsonConvert.DeserializeObject(json);

                DateTime _invcDate;
                string invcDate;

                DataTable dtOS = new DataTable();

                dtOS.Columns.Add("InvcDate", typeof(string));
                dtOS.Columns.Add("InvcNbr", typeof(string));
                dtOS.Columns.Add("InvtID", typeof(string));
                dtOS.Columns.Add("Descr", typeof(string));
                dtOS.Columns.Add("UnitDesc", typeof(string));
                dtOS.Columns.Add("QtyShip", typeof(int));
                dtOS.Columns.Add("CnvFact", typeof(int));

                foreach (dynamic item in data)
                {
                    if (item != null)
                    {
                        _invcDate = Convert.ToDateTime(item.User9);
                        invcDate = _invcDate.ToString("yyyy-MM-dd").Trim();
                        string RefNbr = item.InvcNbr.ToString().Trim();
                        string InvtID = item.InvtID.ToString().Trim();
                        string Descr = item.Descr.ToString().Trim();
                        string UnitDesc = item.UnitDesc.ToString().Trim();
                        int Qty = item.QtyShip;
                        int CnvFact = item.CnvFact;

                        dtOS.Rows.Add(invcDate, RefNbr, InvtID, Descr, UnitDesc, Qty, CnvFact);
                    }
                    else
                    {
                        MessageBox.Show("NO Data Retrieved");
                    }
                }

                if (con.InsertOS(dtOS))
                {
                    MessageBox.Show("OS successfully Sync");
                }
                else
                {
                    MessageBox.Show("Sync Failed");
                }
            }
        }

        private void dtpDTDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void OSFrm_Load(object sender, EventArgs e)
        {

        }
    }
}
