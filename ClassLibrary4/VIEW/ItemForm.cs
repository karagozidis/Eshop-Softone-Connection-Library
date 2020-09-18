using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Softone;
using System.IO;
using System.Net;
using Newtonsoft.Json.Linq;
using System.Drawing.Imaging;
using ClassLibrary4;
using ClassLibrary4.CONTROL;

namespace S1Custom
{
    public partial class ItemForm : Form
    {
        public XTable MTRL;
        public XTable MTREXTRA;

        public int CompanyId = -1;
       // public IXSupport XSupport;
        public XTable pRCCategories;
        Io.HttpWeb.ItemHttp itemHttp = new Io.HttpWeb.ItemHttp();
        JArray jMTRLSOnWebResponce;

        DataTable connectionBricks;


        public ItemForm()
        {
            InitializeComponent();
        }

        private void ItemForm_Load(object sender, EventArgs e)
        {
         
            String Sql = " SELECT A.* " +
                   " FROM CCCCONNECTIONBRICK A WHERE A.COMPANY=  " + Model.S1Init.myXSupport.ConnectionInfo.CompanyId.ToString() +
                   " AND A.RUNINSIDEOBJECT > 0 " +
                   " AND  A.BRICKOBJECT = 'ITEM'                                       " +
                   " AND ACTIVE = 1                                                    " +
                   " ORDER BY A.EXECUTIONORDER                                     ";

            XTable tbl = Model.S1Init.myXSupport.GetSQLDataSet(Sql);
            connectionBricks = tbl.CreateDataTable(true);


            for (int i = 0; i < tbl.Count; i++)
            {
                List<String> DatagridValue = new List<string>();
                DatagridValue.Add(tbl[i, "CCCCONNECTIONBRICK"].ToString());
                DatagridValue.Add(tbl[i, "CODE"].ToString());
                DatagridValue.Add(tbl[i, "NAME"].ToString());

                string[] DatagridRow = DatagridValue.ToArray();
                BricksDataGridView.Rows.Add(DatagridRow);
            }

        }

       /* public void imageExtractFromDb()
        {
            XTable b2bParamTbl = Model.S1Init.myXSupport.GetSQLDataSet(
                         " SELECT SODATA " +
                         " FROM XTRDOCDATA " +
                         " WHERE REFOBJID=6967  "
                   );

            byte[] picData = b2bParamTbl[0, "SODATA"] as byte[] ?? null;

            if (picData != null)
            {
                using (Image image = Image.FromStream(new MemoryStream(picData)))
                {
                    image.Save("output.jpg", ImageFormat.Jpeg);  // Or Png           
                }
            }
        } */

        public void syncOnSave()
        {
            Settings settings = Settings.getInstance();

            if (settings.ItemUpdateOnPost == "1")
            {
                if (settings.ITEM_ON_WEB.Equals(""))
                {
                    Sync();
                }
                else 
                {
                  // Sync();
                    if (!DBNull.Value.Equals(MTREXTRA.Current[settings.ITEM_ON_WEB]))
                    {
                        if (MTREXTRA.Current[settings.ITEM_ON_WEB].ToString().Equals("1"))
                           {
                               Sync();
                           }
                    }

                }
            }
        }

        private void SyncButton_Click(object sender, EventArgs e)
        {
            Sync();
        }

        private void Sync()
        {

/*
            Settings settings = Settings.getInstance();
            String result = "";
            String CODE = "";
            String NAME = "";
            String NAME2 = "";
            String DESCR = "";
            String DESCR2 = "";
            String ITEM_PRICE = "";
            String QTY = "";
            String MTRLID = "";
            String CATEG_NAME = "-1", CATEG_ID = "-1"; 
            string[,] PRICERPRC = new string[12, 2];
            String MTRMANFCTR = "";
            ImageUploader imageUp = new ImageUploader();
            String CHARCODE1 = "";
            String CHARCODE2 = "";
            String CHARCODE3 = "";
            String WEIGHT = "";
 
            String ItemExtra1 = "";
            String ItemExtra2 = "";
            String ItemExtra3 = "";
            String MTRUNIT1 = "";
            String VAT = "";
            String SODISCOUNT = "";
            String RELITEM = "";
            String RELITEMMTRL = "";
            String EXPN1 = "";
            String EXPN2 = "";
            String EXPN3 = "";
            String EXPVAL1 = "";
            String EXPVAL2 = "";
            String EXPVAL3 = "";

            int i = 0;

            if (!DBNull.Value.Equals(settings.ItemCateg))
                 {
                    if(!settings.ItemCateg.Equals("")  )
                    {
                        if (!MTREXTRA.Current[settings.ItemCateg].ToString().Equals(""))
                        {
                            //  MessageBox.Show((String)MTRL.Current["MTRGROUP"].ToString());
                            XTable b2bParamTbl = Model.S1Init.myXSupport.GetSQLDataSet("SELECT TOP 1000  COMPANY " +
                                   ",SODTYPE " +
                                   " ," + settings.ItemCateg +
                                   " ,CODE " +
                                   " ,NAME " +
                                   " ,ISACTIVE " +
                                   " FROM " + settings.ItemCateg +
                                   " WHERE " + //   SODTYPE = 51 " + 
                                   "  COMPANY =" + Model.S1Init.myXSupport.ConnectionInfo.CompanyId.ToString() +
                                   " AND " + settings.ItemCateg + " =" + MTREXTRA.Current[settings.ItemCateg].ToString()
                                   );

                            if (b2bParamTbl.Count > 0)
                            {
                                CATEG_NAME = b2bParamTbl[0, "NAME"].ToString();
                                CATEG_ID = b2bParamTbl[0, settings.ItemCateg].ToString();
                            }
                         }
                      }
                 }


            if (!DBNull.Value.Equals(MTRL.Current["MTRL"]))
            {
                MTRLID = (String)MTRL.Current["MTRL"].ToString();
            }

            if (!DBNull.Value.Equals(MTRL.Current["CODE"]))
            {
                CODE = (String)MTRL.Current["CODE"];
            }

            if (!DBNull.Value.Equals(MTRL.Current["MTRMANFCTR"]))
            {
                MTRMANFCTR = (String)MTRL.Current["MTRMANFCTR"];
            }

            if (!DBNull.Value.Equals(MTRL.Current["X_CCDIM1"]))
            {
                CHARCODE1 = (String)MTRL.Current["X_CCDIM1"].ToString();
            }

            if (!DBNull.Value.Equals(MTRL.Current["X_CCDIM2"]))
            {
                CHARCODE2 = (String)MTRL.Current["X_CCDIM2"].ToString();
            }

            if (!DBNull.Value.Equals(MTRL.Current["X_CCDIM3"]))
            {
                CHARCODE3 = (String)MTRL.Current["X_CCDIM3"].ToString();
            }



            //----------------------------------------------------------------------------------
            //----------------------------------------------------------------------------------
            //----------------------------------------------------------------------------------

            if (settings.ItemTitle1 != "")
            if (settings.ItemTitle1.Contains("VARCHAR"))
            {
                if (!DBNull.Value.Equals(MTREXTRA.Current[settings.ItemTitle1]))
                {
                    NAME = (String)MTREXTRA.Current[settings.ItemTitle1].ToString();
                }
            }
            else
            {
                if (!DBNull.Value.Equals(MTRL.Current[settings.ItemTitle1]))
                {
                    NAME = (String)MTRL.Current[settings.ItemTitle1].ToString();
                }
            }

            if (settings.ItemDescr1 != "")
            if (settings.ItemDescr1.Contains("VARCHAR"))
            {
                if (!DBNull.Value.Equals(MTREXTRA.Current[settings.ItemDescr1]))
                {
                    DESCR = (String)MTREXTRA.Current[settings.ItemDescr1].ToString();
                }
            }
            else
            {
                if (!DBNull.Value.Equals(MTRL.Current[settings.ItemDescr1]))
                {
                    DESCR = (String)MTRL.Current[settings.ItemDescr1].ToString();
                }
            }


            if ( settings.ItemTitle2 != "" )
            if (settings.ItemTitle2.Contains("VARCHAR"))
            {
                if (!DBNull.Value.Equals(MTREXTRA.Current[settings.ItemTitle2]))
                {
                    NAME2 = (String)MTREXTRA.Current[settings.ItemTitle2].ToString();
                }
            }
            else
            {
                if (!DBNull.Value.Equals(MTRL.Current[settings.ItemTitle2]))
                {
                    NAME2 = (String)MTRL.Current[settings.ItemTitle2].ToString();
                }
            }

            if (settings.ItemDescr2 != "")
            if (settings.ItemDescr2.Contains("VARCHAR"))
            {
                if (!DBNull.Value.Equals(MTREXTRA.Current[settings.ItemDescr2]))
                {
                    DESCR2 = (String)MTREXTRA.Current[settings.ItemDescr2].ToString();
                }
            }
            else
            {
                if (!DBNull.Value.Equals(MTRL.Current[settings.ItemDescr2]))
                {
                    DESCR2 = (String)MTRL.Current[settings.ItemDescr2].ToString();
                }
            }


            if (settings.ItemExtra1 != "")
                if (settings.ItemExtra1.Contains("VARCHAR") || settings.ItemExtra1.Contains("NUM") || settings.ItemExtra1.Contains("BOOL"))
                {
                    if (!DBNull.Value.Equals(MTREXTRA.Current[settings.ItemExtra1]))
                    {
                        ItemExtra1 = (String)MTREXTRA.Current[settings.ItemExtra1].ToString();
                    }
                }
                else
                {
                    if (!DBNull.Value.Equals(MTRL.Current[settings.ItemExtra1]))
                    {
                        ItemExtra1 = (String)MTRL.Current[settings.ItemExtra1].ToString();
                    }
                }

            if (settings.ItemExtra2 != "")
                if (settings.ItemExtra2.Contains("VARCHAR") || settings.ItemExtra2.Contains("NUM") || settings.ItemExtra2.Contains("BOOL"))
                {
                    if (!DBNull.Value.Equals(MTREXTRA.Current[settings.ItemExtra2]))
                    {
                        ItemExtra2 = (String)MTREXTRA.Current[settings.ItemExtra2].ToString();
                    }
                }
                else
                {
                    if (!DBNull.Value.Equals(MTRL.Current[settings.ItemExtra2]))
                    {
                        ItemExtra2 = (String)MTRL.Current[settings.ItemExtra2].ToString();
                    }
                }

            if (settings.ItemExtra3 != "")
                if (settings.ItemExtra3.Contains("VARCHAR") || settings.ItemExtra3.Contains("NUM") || settings.ItemExtra3.Contains("BOOL"))
                {
                    if (!DBNull.Value.Equals(MTREXTRA.Current[settings.ItemExtra3]))
                    {
                        ItemExtra3 = (String)MTREXTRA.Current[settings.ItemExtra3].ToString();
                    }
                }
                else
                {
                    if (!DBNull.Value.Equals(MTRL.Current[settings.ItemExtra3]))
                    {
                        ItemExtra3 = (String)MTRL.Current[settings.ItemExtra3].ToString();
                    }
                }



            if (!DBNull.Value.Equals(MTRL.Current["WEIGHT"]))
            {
                WEIGHT = (String)MTRL.Current["WEIGHT"].ToString();
            }

            if (!DBNull.Value.Equals(MTRL.Current["MTRUNIT1"]))
            {
                MTRUNIT1 = (String)MTRL.Current["MTRUNIT1"].ToString();
            }

            if (!DBNull.Value.Equals(MTRL.Current["VAT"]))
            {
                VAT = (String)MTRL.Current["VAT"].ToString();
            }

            if (!DBNull.Value.Equals(MTRL.Current["SODISCOUNT"]))
            {
                SODISCOUNT = (String)MTRL.Current["SODISCOUNT"].ToString();
            }


            if (!DBNull.Value.Equals(MTRL.Current["RELITEM"]))
            {
                RELITEMMTRL = (String)MTRL.Current["RELITEM"].ToString();
                XTable RELITEMRES = Model.S1Init.myXSupport.GetSQLDataSet("SELECT CODE FROM MTRL WHERE MTRL=" + RELITEMMTRL);
                if (RELITEMRES.Count > 0)
                {
                    RELITEM = RELITEMRES[0, "CODE"].ToString();
                }

            }

            if (!DBNull.Value.Equals(MTRL.Current["EXPN1"]))
            {
                EXPN1 = (String)MTRL.Current["EXPN1"].ToString();
            }

            if (!DBNull.Value.Equals(MTRL.Current["EXPN2"]))
            {
                EXPN2 = (String)MTRL.Current["EXPN2"].ToString();
            }

            if (!DBNull.Value.Equals(MTRL.Current["EXPN3"]))
            {
                EXPN3 = (String)MTRL.Current["EXPN3"].ToString();
            }

            if (!DBNull.Value.Equals(MTRL.Current["EXPVAL1"]))
            {
                EXPVAL1 = (String)MTRL.Current["EXPVAL1"].ToString();
            }

            if (!DBNull.Value.Equals(MTRL.Current["EXPVAL2"]))
            {
                EXPVAL2 = (String)MTRL.Current["EXPVAL2"].ToString();
            }

            if (!DBNull.Value.Equals(MTRL.Current["EXPVAL3"]))
            {
                EXPVAL3 = (String)MTRL.Current["EXPVAL3"].ToString();
            }

            //----------------------------------------------------------------------------------
            //----------------------------------------------------------------------------------
            //---------------------------------------------------------------------------------



            if (!DBNull.Value.Equals(MTRL.Current[settings.ITEM_PRICE]))
            {
                ITEM_PRICE = (String)MTRL.Current[settings.ITEM_PRICE].ToString();
            }
             if (!DBNull.Value.Equals(MTRL.Current[settings.ITEM_PRICE+"01"]))
             {
                // PRICER01 = (String)MTRL.Current["PRICER01"].ToString();
                 PRICERPRC[i, 1] = (String)MTRL.Current[settings.ITEM_PRICE+"01"].ToString();
                 i++;
             }
             if (!DBNull.Value.Equals(MTRL.Current[settings.ITEM_PRICE+"02"]))
             {
                 PRICERPRC[i, 1] = (String)MTRL.Current[settings.ITEM_PRICE + "02"].ToString();
                 i++;
             }
             if (!DBNull.Value.Equals(MTRL.Current[settings.ITEM_PRICE + "03"]))
             {
                 PRICERPRC[i, 1] = (String)MTRL.Current[settings.ITEM_PRICE + "03"].ToString();
                 i++;
             }
             if (!DBNull.Value.Equals(MTRL.Current[settings.ITEM_PRICE + "04"]))
             {
                 PRICERPRC[i, 1] = (String)MTRL.Current[settings.ITEM_PRICE + "04"].ToString();
                 i++;
             }
             if (!DBNull.Value.Equals(MTRL.Current[settings.ITEM_PRICE + "05"]))
             {
                 PRICERPRC[i, 1] = (String)MTRL.Current[settings.ITEM_PRICE + "05"].ToString();
                 i++;
             }
             if (!DBNull.Value.Equals(MTRL.Current[settings.ITEM_PRICE + "06"]))
             {
                 PRICERPRC[i, 1] = (String)MTRL.Current[settings.ITEM_PRICE + "06"].ToString();
                 i++;
             }
             if (!DBNull.Value.Equals(MTRL.Current[settings.ITEM_PRICE + "07"]))
             {
                 PRICERPRC[i, 1] = (String)MTRL.Current[settings.ITEM_PRICE + "07"].ToString();
                 i++;
             }
             if (!DBNull.Value.Equals(MTRL.Current[settings.ITEM_PRICE + "08"]))
             {
                 PRICERPRC[i, 1] = (String)MTRL.Current[settings.ITEM_PRICE + "08"].ToString();
                 i++;
             }
             if (!DBNull.Value.Equals(MTRL.Current[settings.ITEM_PRICE + "09"]))
             {
                 PRICERPRC[i, 1] = (String)MTRL.Current[settings.ITEM_PRICE + "09"].ToString();
                 i++;
             }
             if (!DBNull.Value.Equals(MTRL.Current[settings.ITEM_PRICE + "10"]))
             {
                 PRICERPRC[i, 1] = (String)MTRL.Current[settings.ITEM_PRICE + "10"].ToString();
                 i++;
             }
             if (!DBNull.Value.Equals(MTRL.Current[settings.ITEM_PRICE + "11"]))
             {
                 PRICERPRC[i, 1] = (String)MTRL.Current[settings.ITEM_PRICE + "11"].ToString();
                 i++;
             }
             if (!DBNull.Value.Equals(MTRL.Current[settings.ITEM_PRICE + "12"]))
             {
                 PRICERPRC[i, 1] = (String)MTRL.Current[settings.ITEM_PRICE + "12"].ToString();
                 i++;
             }



             int zone;
             for (int j = 0; j < pRCCategories.Count; j++)
             {
                zone = int.Parse(pRCCategories[j, 7].ToString());
                PRICERPRC[zone-1, 0] = pRCCategories[j, 2].ToString();
             }

             XTable REMAINSTbl = Model.S1Init.myXSupport.GetSQLDataSet(
            " SELECT " +
            " ISNULL(B.QTY1,0) AS QTY " +
            " FROM MTRL A LEFT OUTER JOIN MTRDATA B ON A.MTRL=B.MTRL AND B.FISCPRD= " + Model.S1Init.myXSupport.ConnectionInfo.YearId.ToString() +
            " WHERE A.COMPANY= " + Model.S1Init.myXSupport.ConnectionInfo.CompanyId.ToString() +
            " AND A.SODTYPE=51  " +
            " AND A.CODE = '" + CODE + "'"
              );

             if (REMAINSTbl.Count > 0)
             {
                 QTY = REMAINSTbl[0, "QTY"].ToString(); 
             }

             result = this.itemHttp.syncMTRL(CODE, NAME, NAME2, DESCR, DESCR2, ITEM_PRICE,
                 PRICERPRC, i, CATEG_NAME, CATEG_ID, QTY, MTRMANFCTR, WEIGHT, ItemExtra1,
                 ItemExtra2, ItemExtra3, MTRUNIT1, VAT, SODISCOUNT,
                 RELITEM, EXPN1, EXPN2, EXPN3, EXPVAL1, EXPVAL2, EXPVAL3);

            
             GlobalFunctions.updateCharQTYS(MTRLID);
             imageUp.uploadItemImage(MTRLID, CODE);

             if (result.Equals("1"))
             {
                 this.ResultsTextBox.SelectionColor = Color.Green;

                 this.ResultsTextBox.AppendText(DateTime.Now.ToString("MM\\/dd\\/yyyy h\\:mm tt") + "   ");
                 this.ResultsTextBox.AppendText("Ο συγχρονισμός πραγματοποιήθηκε.\n");
                 this.ResultsTextBox.AppendText("Το προϊόν με κωδικό " + CODE + " καταχωρήθηκε στην ιστοσελίδα.\n\n");
             }
             else if (result.Equals("0"))
             {
                 this.ResultsTextBox.SelectionColor = Color.Blue;
                 this.ResultsTextBox.AppendText(DateTime.Now.ToString("MM\\/dd\\/yyyy h\\:mm tt") + "   ");
                 this.ResultsTextBox.AppendText("Ο συγχρονισμός πραγματοποιήθηκε.\n");
                 this.ResultsTextBox.AppendText("Τα στοιχεία του προϊόντος με κωδικό " + CODE + " ενημερώθηκαν στην ιστοσελίδα .\n\n");
             }
             else
             {
                 this.ResultsTextBox.SelectionColor = Color.Red;
                 this.ResultsTextBox.AppendText(result);
              
             }

             this.ResultsTextBox.SelectionStart = this.ResultsTextBox.Text.Length;
             this.ResultsTextBox.ScrollToCaret();
            */
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            /*
            DialogResult dialogResult = MessageBox.Show("Θέλετε να διαγράψετε το προϊόν απο το Web;", "Διαγραφή προϊόντος απο Web!!", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.No)
            {
                return;
            }

            String result = "";
            String CODE = "";

            if (!DBNull.Value.Equals(MTRL.Current["CODE"]))
            {
                CODE = (String)MTRL.Current["CODE"];
            }


            result = this.itemHttp.delete(CODE);


            if (result.Equals("1"))
            {
                this.ResultsTextBox.SelectionColor = Color.Red;
                this.ResultsTextBox.AppendText(DateTime.Now.ToString("MM\\/dd\\/yyyy h\\:mm tt") + "   ");
                this.ResultsTextBox.AppendText("Το προϊόν με κωδικό " + CODE + " έχει διαγραφέι απο την ιστοσελίδα.\n\n");
            }
            else if (result.Equals("0"))
            {
                this.ResultsTextBox.SelectionColor = Color.Gray;
                this.ResultsTextBox.AppendText(DateTime.Now.ToString("MM\\/dd\\/yyyy h\\:mm tt") + "   ");
                this.ResultsTextBox.AppendText("Το προϊόν με κωδικό " + CODE + " δεν διαγράφηκε γιατί δεν υπάρχει στην ιστοσελίδα.\n\n");
            }
            else
            {
                this.ResultsTextBox.SelectionColor = Color.Red;
                this.ResultsTextBox.AppendText(result);
                //sthis.textBox1.AppendText("Πρόβλημα σύνδεσης με ιστοσελίδα.\n");
            }
            this.ResultsTextBox.SelectionStart = this.ResultsTextBox.Text.Length;
            this.ResultsTextBox.ScrollToCaret();
            */
        }


  
        private void LoginButton_Click(object sender, EventArgs e)
        {

        }


        private void ActiveDeactiveButton_Click(object sender, EventArgs e)
        {
            /*
            String result = "";
            String CODE = "";

            if (!DBNull.Value.Equals(MTRL.Current["CODE"]))
            {
                CODE = (String)MTRL.Current["CODE"];
                
            }

            result = this.itemHttp.active(CODE);


            if (result.Equals("0"))
            {
                this.ResultsTextBox.AppendText(DateTime.Now.ToString("MM\\/dd\\/yyyy h\\:mm tt") + "   ");
                this.ResultsTextBox.AppendText("Το προϊόν με κωδικό " + CODE + " δεν είναι ενεργό στη σελίδα.\n\n");
            }
            else if (result.Equals("1"))
            {
                this.ResultsTextBox.SelectionColor = Color.Green;
                this.ResultsTextBox.AppendText(DateTime.Now.ToString("MM\\/dd\\/yyyy h\\:mm tt") + "   ");
                this.ResultsTextBox.AppendText("Το προϊόν με κωδικό " + CODE + " είναι ενεργό στην ιστοσελίδα.\n\n");
            }
            else if (result.Equals("2"))
            {
                this.ResultsTextBox.SelectionColor = Color.Gray;
                this.ResultsTextBox.AppendText(DateTime.Now.ToString("MM\\/dd\\/yyyy h\\:mm tt") + "   ");
                this.ResultsTextBox.AppendText("Το προϊόν με κωδικό " + CODE + " δεν υπάρχει στην ιστοσελίδα.\n\n");
            }
            else
            {
                this.ResultsTextBox.AppendText(result);
                //sthis.textBox1.AppendText("Πρόβλημα σύνδεσης με ιστοσελίδα.\n");
            }
            this.ResultsTextBox.SelectionStart = this.ResultsTextBox.Text.Length;
            this.ResultsTextBox.ScrollToCaret();

            */
        }


        public void uploadImages()
        {

        String CODE = "", MTRLsTR = "";
        Settings settings = Settings.getInstance();

        if (!DBNull.Value.Equals(MTRL.Current["CODE"]))
        {
            CODE = (String)MTRL.Current["CODE"];
        }

        if (!DBNull.Value.Equals(MTRL.Current["MTRL"]))
        {
            MTRLsTR = (String)MTRL.Current["MTRL"].ToString();
        }


        XTable MTRL_IMAGE = Model.S1Init.myXSupport.GetSQLDataSet(
        " SELECT SODATA " +
        " FROM XTRDOCDATA " +
        " WHERE REFOBJID= " + MTRLsTR + 
        " AND SOSOURCE=51 " +
        " AND LNUM=0 "
        );

        if (MTRL_IMAGE.Count < 1) return; 

        byte[] picData = MTRL_IMAGE[0, "SODATA"] as byte[] ?? null;


        if (picData != null)
         {

             using (Image image = Image.FromStream(new MemoryStream(picData)))
             {

                 if (ImageFormat.Jpeg.Equals(image.RawFormat))
                 {
                     image.Save(System.IO.Path.GetTempPath() + CODE + "-IMG.jpg", ImageFormat.Jpeg);

                     this.itemHttp.UpLoadImage(System.IO.Path.GetTempPath() + CODE + "-IMG.jpg", CODE + "-IMG.jpg");
                     this.itemHttp.SyncImage(CODE, CODE + "-IMG.jpg");
                 }
                 else if (ImageFormat.Png.Equals(image.RawFormat))
                 {
                     image.Save(System.IO.Path.GetTempPath() + CODE + "-IMG.png", ImageFormat.Png);

                     this.itemHttp.UpLoadImage(System.IO.Path.GetTempPath() + CODE + "-IMG.png", CODE + "-IMG.png");
                     this.itemHttp.SyncImage(CODE, CODE + "-IMG.png"); 
                 } 

             }

        }

        } 


        private void ItemForm_VisibleChanged(object sender, EventArgs e)
        {
         //   MessageBox.Show("hELLO");
        }


        public void test()
        {
          //  MessageBox.Show("hELLO");
        }

        private void ViewCustomersButton_Click(object sender, EventArgs e)
        {
         //   this.refreshMTRLOnWeb();
        }

        private void ConnectCustomerButton_Click(object sender, EventArgs e)
        {

        }

        private void SearchMTRLSTextBox_TextChanged(object sender, EventArgs e)
        {
        //    this.dipslayMTRLOnWeb(this.SearchMTRLSTextBox.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
         //   MessageBox.Show(MTREXTRA.Current["REMAIN"].ToString()); 
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
           // MessageBox.Show(ITEMAVAIL.Current["REMAIN"].ToString()); 
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            ExternalBrowser externalBrowser = new ExternalBrowser();
            Settings settings = Settings.getInstance();
            String CODE = "";

            if (!DBNull.Value.Equals(MTRL.Current["CODE"]))
            {
                CODE = (String)MTRL.Current["MTRL"].ToString();
            }
            else return;

            String result = this.itemHttp.getPId(CODE);
            result = result.Replace("\"", "");

            if (result.Equals("-1"))
            {
                MessageBox.Show("Το προιόν δεν υπάρχει στο Web.");
                return;
            }

            String Url = settings.domain + "/" + settings.AdminPath + "/index.php?route=catalog/product/edit&product_id=" + result;
            externalBrowser.adminOpen(Url);


        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (this.RPanel.Visible) this.RPanel.Visible = false;
            else this.RPanel.Visible = true;
        }

        private void BricksDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            String SelectedCCCCONNECTIONBRICK = this.BricksDataGridView.Rows[BricksDataGridView.CurrentCell.RowIndex].Cells["CCCCONNECTIONBRICK"].Value.ToString();
            
            SyncExecuter.ExecuteBrick(
                             SelectedCCCCONNECTIONBRICK,
                             MTRL.Current["MTRL"].ToString(),
                             this.ResultsTextBox
                             );

            /*
            DataRow[] foundRows;

            foundRows = connectionBricks.Select("CCCCONNECTIONBRICK = " + SelectedCCCCONNECTIONBRICK);

            for (int i = 0; i < foundRows.Length; i++)
            {

                Boolean execute = true;

                if (foundRows[i]["EXECQUESTION"].ToString() != "")
                {
                    DialogResult dialogResult = MessageBox.Show(foundRows[i]["EXECQUESTION"].ToString(), "Συνέχεια", MessageBoxButtons.YesNo);

                   if (dialogResult == DialogResult.No)
                        {
                            execute = false;
                        }

                }

                if (execute)
                {
                    SyncExecuter.ExecuteBrick(
                         
                         foundRows[i]["SQLCOMMAND"].ToString().Replace("##id##", MTRL.Current["MTRL"].ToString()),
                         foundRows[i]["WEBURL"].ToString(),
                         foundRows[i]["ROWSONURL"].ToString(),
                         foundRows[i]["WEBPARAMFORMAT"].ToString(),
                         this.ResultsTextBox,
                         SelectedCCCCONNECTIONBRICK
                         );
                }

            }
            */

              
    




        }

        




    }
}
