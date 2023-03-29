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
    public partial class VanFrm : Form
    {
        Class.LocalConnection con = new Class.LocalConnection();
        public VanFrm()
        {
            InitializeComponent();
        }

        private async void btnVan_Click(object sender, EventArgs e)
        {
            DateTime userDate = dtpDTDate.Value;
            string formattedDate = userDate.ToString("yyyy-MM-dd");
            string url = "https://barcodesys.happywee.site/api/v2/getVanByDate/" + formattedDate;
            using (var client = new WebClient()) {

                string json = await client.DownloadStringTaskAsync(new Uri(url));
                dynamic data = JsonConvert.DeserializeObject(json);

                DateTime _tranDate;
                string tranDate;

                DataTable dtVan = new DataTable();

                dtVan.Columns.Add("TranDate", typeof(string));
                dtVan.Columns.Add("RefNbr", typeof(string));
                dtVan.Columns.Add("InvtID", typeof(string));
                dtVan.Columns.Add("Descr", typeof(string));
                dtVan.Columns.Add("UnitDesc", typeof(string));
                dtVan.Columns.Add("Qty", typeof(int));
                dtVan.Columns.Add("PriceClass", typeof(string));
                dtVan.Columns.Add("ToSiteID", typeof(string));

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
                        string PriceClass = item.PriceClass.ToString().Trim();
                        string ToSiteID = item.ToSiteID.ToString().Trim();

                        dtVan.Rows.Add(tranDate, RefNbr, InvtID, Descr, UnitDesc, Qty, PriceClass, ToSiteID);
                    }
                    else
                    {
                        MessageBox.Show("NO Data Retrieved");
                    } 
                }

                if (con.InsertVan(dtVan))
                {
                    MessageBox.Show("Van successfully Sync");
                }
                else
                {
                    MessageBox.Show("Sync Failed");
                }
            }
        }
    }
}
