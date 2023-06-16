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
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BarcodeSysCloudSync
{
    public partial class DTFrm : Form
    {
        Class.LocalConnection con = new Class.LocalConnection();
        public DTFrm()
        {
            InitializeComponent();
        }

        private async void btnDT_Click(object sender, EventArgs e)
        {
            DateTime userDate = dtpDTDate.Value;
            string formattedDate = userDate.ToString("yyyy-MM-dd");

            //string url = "http://192.168.1.75:5000/api/v1/getDtSummaryByDate/"+formattedDate;
            //string url = "https://barcodesys.happywee.site/api/v1/getDtSummaryByDate/" + formattedDate;
            string url = "https://barcodesys.happywee.site/api/v2/getDtSummaryByDate/" + formattedDate; //v2
            using (var client = new WebClient())
            {
                string json = await client.DownloadStringTaskAsync(new Uri(url));
                dynamic data = JsonConvert.DeserializeObject(json);

                DateTime _schedDate;
                string schedDate;

                DataTable dtDT = new DataTable();

                dtDT.Columns.Add("schedDate", typeof(string));
                dtDT.Columns.Add("dt", typeof(string));
                dtDT.Columns.Add("solomonID", typeof(string));
                dtDT.Columns.Add("uom", typeof(string));
                dtDT.Columns.Add("qty", typeof(int));
                dtDT.Columns.Add("cnvFact", typeof(int));
                dtDT.Columns.Add("uomOg", typeof(string));
                dtDT.Columns.Add("qtyOg", typeof(int));
                dtDT.Columns.Add("InvcNbr", typeof(string));

                foreach (dynamic item in data)
                {
                    if (item != null)
                    {
                        _schedDate = Convert.ToDateTime(item.OrdDate);
                        schedDate = _schedDate.ToString("yyyy-MM-dd").Trim();
                        string dt = item.ShipViaID.ToString().Trim();
                        string solomonID = item.InvtID.ToString().Trim();
                        string uom = item.UnitDesc.ToString().Trim();
                        int qty = item.QtyShip;
                        int cnvFact = item.CnvFact;
                        string uomOg = item.uomOg;
                        int qtyOg = item.qtyOg;
                        string InvcNbr = item.InvcNbr;

                        dtDT.Rows.Add(schedDate,dt,solomonID,uom,qty, cnvFact, uomOg, qtyOg, InvcNbr);
                        //MessageBox.Show(schedDate + "-" + dt + "-" + solomonID);
                    } 
                    else
                    {
                        MessageBox.Show("NO Data Retrieved");
                        
                    }  
                }

                if (con.InsertDT(dtDT))
                {
                    MessageBox.Show("DT successfully Sync");
                } 
                else
                {
                    MessageBox.Show("Sync Failed");
                }
            }
        }
    }
}
