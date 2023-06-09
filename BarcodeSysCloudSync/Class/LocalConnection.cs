﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace BarcodeSysCloudSync.Class
{
    public class LocalConnection
    {
        SqlConnection conn;
        string connString;

        string server;
        string dbName;

        public bool sqlCon()
        {
            XmlDocument xdoc = new XmlDocument();
            xdoc.Load("servercon.xml");

            XmlNodeList nodes = xdoc.SelectNodes("//Servers/Server");
            foreach (XmlNode node in nodes)
            {
                XmlNode serverNode = node.SelectSingleNode("Title");
                XmlNode dbNode = node.SelectSingleNode("database");

                server = serverNode.InnerText;
                dbName = dbNode.InnerText;
            }

            connString = $"server={server};user id=sa;password=Passw0rd;database={dbName};TrustServerCertificate=True;Trusted_Connection=False;";
            conn = new SqlConnection(connString);
            try
            {
                conn.Open();
                conn.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        SqlDataAdapter sda;
        SqlCommand cmd;

        //DT
        public bool InsertDT(DataTable dtDT)
        {
            try
            {
                sqlCon();
                using (conn = new SqlConnection(connString))
                {
                    conn.Open();

                    foreach (DataRow row in dtDT.Rows)
                    {
                        string schedDate = row["schedDate"].ToString();
                        string dt = row["dt"].ToString();
                        string solomonID = row["solomonID"].ToString();
                        string uom = row["uom"].ToString();
                        string invcNbr = row["InvcNbr"].ToString();

                        if (CheckDT(dt, schedDate, solomonID, uom, invcNbr))
                        {
                            using (cmd = new SqlCommand("UPDATE barcodesys_DTInventory SET  qty = @qty, uomOg = @uomOg, qtyOg = @qtyOg , cnvFact = @cnvFact , InvcNbr = @InvcNbr WHERE schedDate = @schedDate AND " +
                                "dt = @dt AND solomonID = @solomonID AND InvcNbr = @InvcNbr", conn))
                            {
                                cmd.Parameters.AddWithValue("@schedDate", row["schedDate"].ToString());
                                cmd.Parameters.AddWithValue("@dt", dt);
                                cmd.Parameters.AddWithValue("@solomonID", solomonID);
                                cmd.Parameters.AddWithValue("@uom", uom);
                                cmd.Parameters.AddWithValue("@qty", Int32.Parse(row["qty"].ToString()));
                                cmd.Parameters.AddWithValue("@cnvFact", Int32.Parse(row["cnvFact"].ToString()));
                                cmd.Parameters.AddWithValue("@uomOg",row["uomOg"].ToString());
                                cmd.Parameters.AddWithValue("@qtyOg", Int32.Parse(row["qtyOg"].ToString()));
                                cmd.Parameters.AddWithValue("@InvcNbr", row["InvcNbr"].ToString());

                                cmd.ExecuteNonQuery();
                            }
                        }
                        else
                        {
                            using (cmd = new SqlCommand("INSERT INTO barcodesys_DTInventory (schedDate,dt,solomonID,uom,qty,CnvFact,uomOg,qtyOg,InvcNbr) VALUES (@schedDate,@dt,@solomonID,@uom," +
                            "@qty,@cnvFact,@uomOg,@qtyOg,@InvcNbr)", conn))
                            {
                                cmd.Parameters.AddWithValue("@schedDate", row["schedDate"].ToString());
                                cmd.Parameters.AddWithValue("@dt", dt);
                                cmd.Parameters.AddWithValue("@solomonID", row["solomonID"].ToString());
                                cmd.Parameters.AddWithValue("@uom", row["uom"].ToString());
                                cmd.Parameters.AddWithValue("@qty", Int32.Parse(row["qty"].ToString()));
                                cmd.Parameters.AddWithValue("@cnvFact", Int32.Parse(row["cnvFact"].ToString()));
                                cmd.Parameters.AddWithValue("@uomOg", row["uomOg"].ToString());
                                cmd.Parameters.AddWithValue("@qtyOg", Int32.Parse(row["qtyOg"].ToString()));
                                cmd.Parameters.AddWithValue("@InvcNbr", row["InvcNbr"].ToString());

                                cmd.ExecuteNonQuery();
                            }
                        }
                    }

                    conn.Close();
                    return true;                                                    
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }

        public bool CheckDT(string dt, string dtDate, string solomonID, string uom, string invcNbr)
        {
            DataTable dtCheck = new DataTable();
            try
            {
                sda = new SqlDataAdapter("SELECT solomonID FROM barcodesys_DTInventory WHERE schedDate = '" + dtDate + "' AND dt = '"+dt+"' AND solomonID = '"+solomonID+"' AND uomOg = '"+ uom+"' AND InvcNbr = '"+invcNbr+"'", conn);
                dtCheck = new DataTable();
                sda.Fill(dtCheck);

                if(dtCheck.Rows.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            } 
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }     
        }

        //VAN
        public bool CheckVan(string refNbr, string tranDate, string solomonId, string uom)
        {
            DataTable dtCheck = new DataTable();
            try
            {
                sda = new SqlDataAdapter("SELECT InvtID FROM barcodesys_VaNInventory WHERE RefNbr = '" + refNbr + "' AND TranDate = '" + tranDate + "' AND InvtID = '" + solomonId + "' AND UnitDesc = '" + uom + "'", conn);
                dtCheck = new DataTable();
                sda.Fill(dtCheck);

                if (dtCheck.Rows.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }

        public bool InsertVan(DataTable dtVan)
        {
            try
            {
                sqlCon();
                using (conn = new SqlConnection(connString))
                {
                    conn.Open();

                    foreach (DataRow row in dtVan.Rows)
                    {
                        string TranDate = row["TranDate"].ToString();
                        string RefNbr = row["RefNbr"].ToString();
                        string InvtID = row["InvtID"].ToString();
                        string UnitDesc = row["UnitDesc"].ToString();


                        if (CheckVan(RefNbr, TranDate, InvtID, UnitDesc))
                        {
                            using (cmd = new SqlCommand("UPDATE barcodesys_VaNInventory SET  Qty = @Qty, UnitDesc = @UnitDesc WHERE TranDate = @TranDate AND " +
                                "RefNbr = @RefNbr AND InvtID = @InvtID", conn))
                            {
                                cmd.Parameters.AddWithValue("@Qty", Int32.Parse(row["Qty"].ToString()));
                                cmd.Parameters.AddWithValue("@UnitDesc", UnitDesc);
                                cmd.Parameters.AddWithValue("@TranDate", TranDate);
                                cmd.Parameters.AddWithValue("@RefNbr", RefNbr);
                                cmd.Parameters.AddWithValue("@InvtID", InvtID);
                                cmd.ExecuteNonQuery();
                            }
                        }
                        else
                        {
                            using (cmd = new SqlCommand("INSERT INTO barcodesys_VaNInventory (TranDate,RefNbr,InvtID,Descr,UnitDesc,Qty,PriceClass,ToSiteID,CnvFact) VALUES (@TranDate,@RefNbr,@InvtID,@Descr," +
                            "@UnitDesc,@Qty,@PriceClass,@ToSiteID,@CnvFact)", conn))
                            {
                                cmd.Parameters.AddWithValue("@TranDate", TranDate);
                                cmd.Parameters.AddWithValue("@RefNbr", RefNbr);
                                cmd.Parameters.AddWithValue("@InvtID", InvtID);
                                cmd.Parameters.AddWithValue("@Descr", row["Descr"].ToString());
                                cmd.Parameters.AddWithValue("@UnitDesc", UnitDesc);
                                cmd.Parameters.AddWithValue("@Qty", Int32.Parse(row["Qty"].ToString()));
                                cmd.Parameters.AddWithValue("@PriceClass", row["PriceClass"].ToString());
                                cmd.Parameters.AddWithValue("@ToSiteID", row["ToSiteID"].ToString());
                                cmd.Parameters.AddWithValue("@CnvFact", Int32.Parse(row["CnvFact"].ToString()));

                                cmd.ExecuteNonQuery();
                            }
                        }
                    }

                    conn.Close();
                    return true;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }

        //OS
        public bool CheckOS(string invcNbr, string invcDate, string solomonId, string uom)
        {
            DataTable dtCheck = new DataTable();
            try
            {
                sda = new SqlDataAdapter("SELECT InvcNbr FROM barcodesys_OSInventory WHERE InvcNbr = '" + invcNbr + "' AND InvcDate = '" + invcDate + "' AND InvtID = '" + solomonId + "' AND UnitDesc = '" + uom + "'", conn);
                dtCheck = new DataTable();
                sda.Fill(dtCheck);

                if (dtCheck.Rows.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }

        public bool InsertOS(DataTable dtOs)
        {
            try
            {
                sqlCon();
                using (conn = new SqlConnection(connString))
                {
                    conn.Open();

                    foreach (DataRow row in dtOs.Rows)
                    {
                        string InvcDate = row["InvcDate"].ToString();
                        string InvcNbr = row["InvcNbr"].ToString();
                        string InvtID = row["InvtID"].ToString();
                        string UnitDesc = row["UnitDesc"].ToString();


                        if (CheckOS(InvcNbr, InvcDate, InvtID, UnitDesc))
                        {
                            using (cmd = new SqlCommand("UPDATE barcodesys_OSInventory SET  QtyShip = @QtyShip, UnitDesc = @UnitDesc WHERE InvcDate = @InvcDate AND " +
                                "InvcNbr = @InvcNbr AND InvtID = @InvtID", conn))
                            {
                                cmd.Parameters.AddWithValue("@QtyShip", Int32.Parse(row["QtyShip"].ToString()));
                                cmd.Parameters.AddWithValue("@UnitDesc", UnitDesc);
                                cmd.Parameters.AddWithValue("@InvcDate", InvcDate);
                                cmd.Parameters.AddWithValue("@InvcNbr", InvcNbr);
                                cmd.Parameters.AddWithValue("@InvtID", InvtID);
                                cmd.ExecuteNonQuery();
                            }
                        }
                        else
                        {
                            using (cmd = new SqlCommand("INSERT INTO barcodesys_OSInventory (InvcDate,InvcNbr,InvtID,Descr,UnitDesc,QtyShip,CnvFact) VALUES (@InvcDate,@InvcNbr,@InvtID,@Descr," +
                            "@UnitDesc,@QtyShip,@CnvFact)", conn))
                            {
                                cmd.Parameters.AddWithValue("@InvcDate", InvcDate);
                                cmd.Parameters.AddWithValue("@InvcNbr", InvcNbr);
                                cmd.Parameters.AddWithValue("@InvtID", InvtID);
                                cmd.Parameters.AddWithValue("@Descr", row["Descr"].ToString());
                                cmd.Parameters.AddWithValue("@UnitDesc", UnitDesc);
                                cmd.Parameters.AddWithValue("@QtyShip", Int32.Parse(row["QtyShip"].ToString()));
                                cmd.Parameters.AddWithValue("@CnvFact", Int32.Parse(row["CnvFact"].ToString()));

                                cmd.ExecuteNonQuery();
                            }
                        }
                    }

                    conn.Close();
                    return true;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }

        //ISSUE
        public bool CheckIssue(string invcNbr, string invcDate, string solomonId, string uom)
        {
            DataTable dtCheck = new DataTable();
            try
            {
                sda = new SqlDataAdapter("SELECT InvcNbr FROM barcodesys_OSInventory WHERE InvcNbr = '" + invcNbr + "' AND InvcDate = '" + invcDate + "' AND InvtID = '" + solomonId + "' AND UnitDesc = '" + uom + "'", conn);
                dtCheck = new DataTable();
                sda.Fill(dtCheck);

                if (dtCheck.Rows.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }

        public bool InsertIssue(DataTable dtOs)
        {
            try
            {
                sqlCon();
                using (conn = new SqlConnection(connString))
                {
                    conn.Open();

                    foreach (DataRow row in dtOs.Rows)
                    {
                        string TranDate = row["TranDate"].ToString();
                        string RefNbr = row["RefNbr"].ToString();
                        string InvtID = row["InvtID"].ToString();
                        string UnitDesc = row["UnitDesc"].ToString();


                        if (CheckIssue(RefNbr, TranDate, InvtID, UnitDesc))
                        {
                            using (cmd = new SqlCommand("UPDATE barcodesys_IssueInventory SET  Qty = @Qty, UnitDesc = @UnitDesc WHERE TranDate = @TranDate AND " +
                                "RefNbr = @RefNbr AND InvtID = @InvtID", conn))
                            {
                                cmd.Parameters.AddWithValue("@Qty", Int32.Parse(row["Qty"].ToString()));
                                cmd.Parameters.AddWithValue("@UnitDesc", UnitDesc);
                                cmd.Parameters.AddWithValue("@TranDate", TranDate);
                                cmd.Parameters.AddWithValue("@RefNbr", RefNbr);
                                cmd.Parameters.AddWithValue("@InvtID", InvtID);
                                cmd.ExecuteNonQuery();
                            }
                        }
                        else
                        {
                            using (cmd = new SqlCommand("INSERT INTO barcodesys_IssueInventory (TranDate,RefNbr,InvtID,Descr,UnitDesc,Qty,CnvFact) VALUES (@TranDate,@RefNbr,@InvtID,@Descr," +
                            "@UnitDesc,@Qty, @CnvFact)", conn))
                            {
                                cmd.Parameters.AddWithValue("@TranDate", TranDate);
                                cmd.Parameters.AddWithValue("@RefNbr", RefNbr);
                                cmd.Parameters.AddWithValue("@InvtID", InvtID);
                                cmd.Parameters.AddWithValue("@Descr", row["Descr"].ToString());
                                cmd.Parameters.AddWithValue("@UnitDesc", UnitDesc);
                                cmd.Parameters.AddWithValue("@Qty", Int32.Parse(row["Qty"].ToString()));
                                cmd.Parameters.AddWithValue("@CnvFact", Int32.Parse(row["CnvFact"].ToString()));

                                cmd.ExecuteNonQuery();
                            }
                        }
                    }

                    conn.Close();
                    return true;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }
    }
}
