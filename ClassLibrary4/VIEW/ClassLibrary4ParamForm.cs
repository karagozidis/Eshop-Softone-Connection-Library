using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using S1Custom;
using S1Custom.Model;
using Softone;

namespace ClassLibrary4
{
    public partial class ClassLibrary4ParamForm : Form
    {
        public ClassLibrary4ParamForm()
        {
            InitializeComponent();

            Settings settings = Settings.getInstance();
            this.DomainTextBox.Text = settings.domain;
            this.UserNameTextBox.Text = settings.user;
            this.PasswordTextBox.Text = settings.password;

            //this.TimeIntervalTextBox.Text = settings.timerInterval.ToString();
            this.TimeIntervalTextBox.Text = S1Custom.Properties.SettingsPerUsr.Default["TimeInterval"].ToString();

            this.OrderSeriesTextBox.Text = settings.orderSeries.ToString();
            this.EXPNTextBox.Text = settings.EXPN.ToString();

            this.TrdrNameTextBox.Text = settings.TRDR_NAME_FIELD;
            this.TrdrLNameTextBox.Text = settings.TRDR_LNAME_FIELD;
            this.TrdrPasswordTextBox.Text = settings.TRDR_PASSWORD_FIELD;
            this.TrdrOnWebTextBox.Text = settings.TRDR_ON_WEB;
            this.ItemOnWebTextBox.Text = settings.ITEM_ON_WEB;

            this.ItemPriceTextBox.Text = settings.ITEM_PRICE;

            this.FtpDomainTextBox.Text = settings.imagesFtpDomain;
            this.FtpUserTextBox.Text = settings.imagesFtpUser;
            this.FtpPasswordTextBox.Text = settings.imagesFtpPassword;
            this.ImagesDomainTextBox.Text = settings.images_domain;
            this.AdminPathTextBox.Text = settings.AdminPath;

            this.ItemTitle1TextBox.Text = settings.ItemTitle1;
            this.ItemDescr1TextBox.Text = settings.ItemDescr1;
            this.ItemTitle2TextBox.Text = settings.ItemTitle2;
            this.ItemDescr2TextBox.Text = settings.ItemDescr2;

            this.WHouseTextBox.Text = settings.WHouse;


            if (settings.ItemUpdateTitle.Equals("1") ) this.ItemUpdateTitleCheckBox.Checked = true;
            else this.ItemUpdateTitleCheckBox.Checked = false;

            if (settings.ItemUpdateDescr.Equals("1")) this.ItemUpdateDescrCheckBox.Checked = true;
            else this.ItemUpdateDescrCheckBox.Checked = false;


            if (settings.TrdrUpdateOnPost.Equals("1")) this.TrdrUpdateOnPostCheckBox.Checked = true;
            else this.TrdrUpdateOnPostCheckBox.Checked = false;

            if (settings.ItemUpdateOnPost.Equals("1")) this.ItemUpdateOnPostCheckBox.Checked = true;
            else this.ItemUpdateOnPostCheckBox.Checked = false;

            this.WebDateFormatTextBox.Text = settings.WebDateFormat;
            this.DetaxationTextBox.Text = settings.Detaxation;

            this.ItemCategTextBox.Text = settings.ItemCateg;

            this.OrderWebRelTextBox.Text = settings.OrderWebRel;

            this.ItemExtra1TextBox.Text = settings.ItemExtra1;
            this.ItemExtra2TextBox.Text = settings.ItemExtra2;
            this.ItemExtra3TextBox.Text = settings.ItemExtra3;

            this.ItemDaysTransactionsUpDown.Text = settings.ItemDaysTransactions.ToString();

            if (settings.ItemUpdateCharacteristicsQty) this.ItemUpdateCharacteristicsQtyCheckBox.Checked = true;
            else this.ItemUpdateCharacteristicsQtyCheckBox.Checked = false;


            //  settings.updateSetting("ItemDaysTransactions", this.ItemDaysTransactionsUpDown.Text);
            // settings.ItemDaysTransactions = int.Parse(this.ItemDaysTransactionsUpDown.Text);
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            Settings settings = Settings.getInstance();
        //    MessageBox.Show(S1Init.myXSupport.ConnectionInfo.YearId.ToString());

            settings.updateSetting("domain", this.DomainTextBox.Text);
            settings.domain = this.DomainTextBox.Text;


            settings.updateSetting("user", this.UserNameTextBox.Text);
            settings.user = this.UserNameTextBox.Text;

            settings.updateSetting("password", this.PasswordTextBox.Text);
            settings.password = this.PasswordTextBox.Text;


            S1Custom.Properties.SettingsPerUsr.Default["TimeInterval"] = this.TimeIntervalTextBox.Text;
           // settings.updateSetting("timerInterval", this.TimeIntervalTextBox.Text);
            S1Custom.Properties.SettingsPerUsr.Default.Save();
            settings.timerInterval = Convert.ToInt32(this.TimeIntervalTextBox.Text);

           

            settings.updateSetting("TRDR_NAME_FIELD", this.TrdrNameTextBox.Text);
            settings.TRDR_NAME_FIELD = this.TrdrNameTextBox.Text;

            settings.updateSetting("TRDR_LNAME_FIELD", this.TrdrLNameTextBox.Text);
            settings.TRDR_LNAME_FIELD = this.TrdrLNameTextBox.Text;

            settings.updateSetting("TRDR_PASSWORD_FIELD", this.TrdrPasswordTextBox.Text);
            settings.TRDR_PASSWORD_FIELD = this.TrdrPasswordTextBox.Text;

            settings.updateSetting("TRDR_ON_WEB", this.TrdrOnWebTextBox.Text);
            settings.TRDR_ON_WEB = this.TrdrOnWebTextBox.Text;

            settings.updateSetting("ITEM_PRICE", this.ItemPriceTextBox.Text);
            settings.ITEM_PRICE = this.ItemPriceTextBox.Text;

            settings.updateSetting("ITEM_ON_WEB", this.ItemOnWebTextBox.Text);
            settings.ITEM_ON_WEB = this.ItemOnWebTextBox.Text;

            settings.updateSetting("orderSeries", this.OrderSeriesTextBox.Text);
            settings.orderSeries = this.OrderSeriesTextBox.Text;

            settings.updateSetting("EXPN", this.EXPNTextBox.Text);
            settings.EXPN = this.EXPNTextBox.Text;


            settings.updateSetting("imagesFtpDomain", this.FtpDomainTextBox.Text);
            settings.imagesFtpDomain = this.FtpDomainTextBox.Text;

            settings.updateSetting("imagesFtpUser", this.FtpUserTextBox.Text);
            settings.imagesFtpUser = this.FtpUserTextBox.Text;

            settings.updateSetting("imagesFtpPassword", this.FtpPasswordTextBox.Text);
            settings.imagesFtpPassword = this.FtpPasswordTextBox.Text;

            settings.updateSetting("images_domain", this.ImagesDomainTextBox.Text);
            settings.images_domain = this.ImagesDomainTextBox.Text;

            settings.updateSetting("AdminPath", this.AdminPathTextBox.Text);
            settings.AdminPath = this.AdminPathTextBox.Text;


            settings.updateSetting("ItemTitle1", this.ItemTitle1TextBox.Text);
            settings.ItemTitle1 = this.ItemTitle1TextBox.Text;

            settings.updateSetting("ItemDescr1", this.ItemDescr1TextBox.Text);
            settings.ItemDescr1 = this.ItemDescr1TextBox.Text;

            settings.updateSetting("ItemTitle2", this.ItemTitle2TextBox.Text);
            settings.ItemTitle2 = this.ItemTitle2TextBox.Text;

            settings.updateSetting("ItemDescr2", this.ItemDescr2TextBox.Text);
            settings.ItemDescr2 = this.ItemDescr2TextBox.Text;
            
            settings.updateSetting("WHouse", this.WHouseTextBox.Text);
            settings.WHouse = this.WHouseTextBox.Text;

            String ItemUpdateTitle = "0";
            if(this.ItemUpdateTitleCheckBox.Checked)  ItemUpdateTitle = "1";
            else  ItemUpdateTitle = "0";
            settings.updateSetting("ItemUpdateTitle",ItemUpdateTitle);
            settings.ItemUpdateTitle = ItemUpdateTitle;


            String ItemUpdateDescr = "0";
            if (this.ItemUpdateDescrCheckBox.Checked) ItemUpdateDescr = "1";
            else ItemUpdateDescr = "0";
            settings.updateSetting("ItemUpdateDescr", ItemUpdateDescr);
            settings.ItemUpdateDescr = ItemUpdateDescr;


            String TrdrUpdateOnPost = "0";
            if (this.TrdrUpdateOnPostCheckBox.Checked) TrdrUpdateOnPost = "1";
            else TrdrUpdateOnPost = "0";
            settings.updateSetting("TrdrUpdateOnPost", TrdrUpdateOnPost);
            settings.TrdrUpdateOnPost = TrdrUpdateOnPost;


            String ItemUpdateOnPost = "0";
            if (this.ItemUpdateOnPostCheckBox.Checked) ItemUpdateOnPost = "1";
            else ItemUpdateOnPost = "0";
            settings.updateSetting("ItemUpdateOnPost", ItemUpdateOnPost);
            settings.ItemUpdateOnPost = ItemUpdateOnPost;


            settings.updateSetting("OrderWebRel", this.OrderWebRelTextBox.Text);
            settings.OrderWebRel = this.OrderWebRelTextBox.Text;

            settings.updateSetting("WebDateFormat", this.WebDateFormatTextBox.Text);
            settings.WebDateFormat = this.WebDateFormatTextBox.Text;

            settings.updateSetting("Detaxation", this.DetaxationTextBox.Text);
            settings.Detaxation = this.DetaxationTextBox.Text;

            settings.updateSetting("ItemCateg", this.ItemCategTextBox.Text);
            settings.ItemCateg = this.ItemCategTextBox.Text;

            settings.updateSetting("ItemExtra1", this.ItemExtra1TextBox.Text);
            settings.ItemExtra1 = this.ItemExtra1TextBox.Text;

            settings.updateSetting("ItemExtra2", this.ItemExtra2TextBox.Text);
            settings.ItemExtra2 = this.ItemExtra2TextBox.Text;

            settings.updateSetting("ItemExtra3", this.ItemExtra3TextBox.Text);
            settings.ItemExtra3 = this.ItemExtra3TextBox.Text;


            settings.updateSetting("ItemDaysTransactions", this.ItemDaysTransactionsUpDown.Text);
            settings.ItemDaysTransactions = int.Parse(this.ItemDaysTransactionsUpDown.Text);


            if (ItemUpdateCharacteristicsQtyCheckBox.Checked) 
                {
                settings.updateSetting("ItemUpdateCharacteristicsQty", "0");
                settings.ItemUpdateCharacteristicsQty = true;
                }
            else 
                {
                settings.updateSetting("ItemUpdateCharacteristicsQty", "1");
                settings.ItemUpdateCharacteristicsQty = false;
                }
           



            MessageBox.Show("Αλλαγές Αποθηκεύτηκαν");
        }

        private void PRCCategSyncButton_Click(object sender, EventArgs e)
        {
            S1Custom.Io.HttpWeb.PRCCategoryHttp pRCCategoryHttp = new S1Custom.Io.HttpWeb.PRCCategoryHttp();


            XTable PRCCATEGORIES = S1Init.myXSupport.GetSQLDataSet("SELECT" +
                  " PRCCATEGORY " +
                  " ,CODE " +
                  " ,NAME " +
                  " ,ACNMSK " +
                  " ,ISACTIVE " +
                  " ,PRICEZONE " +
                  " ,COMPANY " +
                  " FROM PRCCATEGORY " +
                  " WHERE COMPANY = " + S1Init.myXSupport.ConnectionInfo.CompanyId.ToString());

            this.LoadingProgressBar.Maximum = PRCCATEGORIES.Count;
            this.LoadingProgressBar.Step = 1;

            for (int i = 0; i < PRCCATEGORIES.Count; i++)
            {
                pRCCategoryHttp.sync(PRCCATEGORIES[i, "CODE"].ToString(),
                    PRCCATEGORIES[i, "NAME"].ToString());

                this.LoadingProgressBar.PerformStep();
            }

            this.LoadingProgressBar.Value = 0;
            MessageBox.Show("Διαδικασία ολοκληρώθηκε.");
        }

        private void MTRGROUPSyncButton_Click(object sender, EventArgs e)
        {
            S1Custom.Io.HttpWeb.ItemHttp ITEMHttp = new S1Custom.Io.HttpWeb.ItemHttp();
            Settings settings = Settings.getInstance();

            XTable MTRGROUP = S1Init.myXSupport.GetSQLDataSet(
                      "  SELECT COMPANY " +
                      " ,SODTYPE " +
                      " , " + settings.ItemCateg + 
                      " ,CODE " +
                      " ,NAME " +
                      " ,ISACTIVE " +
                      " FROM " + settings.ItemCateg + 
                      " WHERE ISACTIVE = 1 " +
                      " AND SODTYPE=51 "+
                      " AND COMPANY = " + S1Init.myXSupport.ConnectionInfo.CompanyId.ToString());

            this.LoadingProgressBar.Maximum = MTRGROUP.Count;
            this.LoadingProgressBar.Step = 1;

            for (int i = 0; i < MTRGROUP.Count; i++)
            {
                ITEMHttp.syncMTRGROUP(MTRGROUP[i, settings.ItemCateg].ToString(),
                    MTRGROUP[i, "NAME"].ToString());

                this.LoadingProgressBar.PerformStep();
            }

            this.LoadingProgressBar.Value = 0;
            MessageBox.Show("Διαδικασία ολοκληρώθηκε.");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            S1Custom.Io.HttpWeb.CustomerHttp customerHttp = new S1Custom.Io.HttpWeb.CustomerHttp();
            Settings settings = Settings.getInstance();

            String TRDR_NAME_FIELD = "";
            String TRDR_LNAME_FIELD = "";
            String TRDR_PASSWORD_FIELD = "";
            String FILTER_CHECKBOX = "";


            if (settings.TRDR_NAME_FIELD.Contains("VARCHAR")) TRDR_NAME_FIELD = "TE." + settings.TRDR_NAME_FIELD;
            else TRDR_NAME_FIELD = settings.TRDR_NAME_FIELD;

            if (settings.TRDR_LNAME_FIELD.Contains("VARCHAR")) TRDR_LNAME_FIELD = "TE." + settings.TRDR_LNAME_FIELD;
            else TRDR_LNAME_FIELD = settings.TRDR_LNAME_FIELD;

            if (settings.TRDR_PASSWORD_FIELD.Contains("VARCHAR")) TRDR_PASSWORD_FIELD = "TE." + settings.TRDR_PASSWORD_FIELD;
            else TRDR_PASSWORD_FIELD = settings.TRDR_PASSWORD_FIELD;

            if (!settings.TRDR_ON_WEB.Equals(""))
            {
                FILTER_CHECKBOX = " AND TE." + settings.TRDR_ON_WEB + " = 1";
            }


            XTable TRDRGROUP = S1Init.myXSupport.GetSQLDataSet(
             "   SELECT  " +
             "  " + TRDR_NAME_FIELD + ", " +
             "  " + TRDR_LNAME_FIELD + ", " +
             "  " + TRDR_PASSWORD_FIELD + ", " +
             "   T.CODE, " +
             "   T.JOBTYPETRD, " +
             "   T.ADDRESS, " +
             "   T.ZIP, " +
             "   T.CITY, " +
             "   T.PHONE01, " +
             "   T.FAX, " +
             "   T.EMAIL, " +
             "   T.PRCCATEGORY " +
             "   FROM TRDR T " +
             "   LEFT OUTER JOIN TRDEXTRA TE ON TE.TRDR = T.TRDR " +
             "   WHERE T.SODTYPE = 13 " +
             "   AND ISACTIVE = 1  " +
             "   AND T.COMPANY = " + S1Init.myXSupport.ConnectionInfo.CompanyId.ToString() +
                FILTER_CHECKBOX
             );


            this.LoadingProgressBar.Maximum = TRDRGROUP.Count;
            this.LoadingProgressBar.Step = 1;

            for (int i = 0; i < TRDRGROUP.Count; i++)
            {
                customerHttp.syncCustomer(
                    TRDRGROUP[i, "CODE"].ToString(),
                    TRDRGROUP[i, settings.TRDR_NAME_FIELD].ToString(),
                    TRDRGROUP[i, settings.TRDR_LNAME_FIELD].ToString(),
                    TRDRGROUP[i, "JOBTYPETRD"].ToString(),
                    TRDRGROUP[i, "ADDRESS"].ToString(),
                    TRDRGROUP[i, "ZIP"].ToString(),
                    TRDRGROUP[i, "CITY"].ToString(),
                    TRDRGROUP[i, "PHONE01"].ToString(),
                    TRDRGROUP[i, settings.TRDR_PASSWORD_FIELD].ToString(),
                    TRDRGROUP[i, "FAX"].ToString(),
                    TRDRGROUP[i, "EMAIL"].ToString(),
                    TRDRGROUP[i, "PRCCATEGORY"].ToString()
                    );

                this.LoadingProgressBar.PerformStep();
            }

            this.LoadingProgressBar.Value = 0;
            MessageBox.Show("Διαδικασία ολοκληρώθηκε.");
        }



        private void MtrlSyncButton_Click(object sender, EventArgs e)
        {
            GlobalFunctions.syncMtrl(LoadingProgressBar,"");
            MessageBox.Show("Διαδικασία ολοκληρώθηκε.");
            this.LoadingProgressBar.Value = 0;

            /*    S1Custom.Io.HttpWeb.ItemHttp itemHttp = new S1Custom.Io.HttpWeb.ItemHttp();
                string[,] PRICERPRC = new string[12, 2];
                String CODE = "",  MTRL = "" ,NAME = "", NAME2 = "", DESCR = "", DESCR2 = "", ITEM_PRICE = "";
                String NAMEpREFIX = "", NAME2pREFIX = "", DESCRpREFIX = "", DESCR2pREFIX = "";
                String CATEG_NAME = "-1", CATEG_ID = "-1", QTY = "" ;
                Settings settings = Settings.getInstance();
                String FILTER_CHECKBOX = "";
                ImageUploader imageUp = new ImageUploader();
                String MTRMANFCTR = "";

                XTable pRCCategories = S1Init.myXSupport.GetSQLDataSet(
                "SELECT A.COMPANY,A.PRCCATEGORY,A.CODE,A.NAME,A.ACNMSK,A.ISACTIVE,A.PRICEZONE " +
                "FROM PRCCATEGORY A WHERE A.COMPANY=" + S1Init.myXSupport.ConnectionInfo.CompanyId + " ORDER BY A.PRCCATEGORY"
                 );

                if (!settings.ITEM_ON_WEB.Equals(""))
                {
                    FILTER_CHECKBOX = " AND ME." + settings.ITEM_ON_WEB + " = 1";
                }

                if (settings.ItemTitle1.Contains("VARCHAR"))  NAMEpREFIX = "ME."; 
                else NAMEpREFIX = "M.";

                if (settings.ItemDescr1.Contains("VARCHAR"))  DESCRpREFIX = "ME.";
                else DESCRpREFIX = "M.";

                if (settings.ItemTitle2.Contains("VARCHAR"))  NAME2pREFIX = "ME.";
                else NAME2pREFIX = "M.";

                if (settings.ItemDescr2.Contains("VARCHAR"))  DESCR2pREFIX = "ME.";
                else DESCR2pREFIX = "M.";

      
                XTable MTRLS = S1Init.myXSupport.GetSQLDataSet(
                 " SELECT " +
                 " M.MTRL AS MTRL, " +
                 " M.CODE , " +
                 " M." + settings.ITEM_PRICE + ", " +
                 " M." + settings.ITEM_PRICE + "01, " +
                 " M." + settings.ITEM_PRICE + "02, " +
                 " M." + settings.ITEM_PRICE + "03, " +
                 " M." + settings.ITEM_PRICE + "04, " +
                 " M." + settings.ITEM_PRICE + "05, " +
                 " M." + settings.ITEM_PRICE + "06, " +
                 " M." + settings.ITEM_PRICE + "07, " +
                 " M." + settings.ITEM_PRICE + "08, " +
                 " M." + settings.ITEM_PRICE + "09, " +
                 " M." + settings.ITEM_PRICE + "10, " +
                 " M." + settings.ITEM_PRICE + "11, " +
                 " M." + settings.ITEM_PRICE + "12, " +
                 " G.CODE ,  " +
                 " G.NAME , " +
                 settings.ItemCateg + ", " + 

                 NAMEpREFIX + settings.ItemTitle1 + " AS " + settings.ItemTitle1 + "_Lang1 ," +
                 DESCRpREFIX + settings.ItemDescr1 + " AS " + settings.ItemDescr1 + "_Desc1 ," +
                 NAME2pREFIX + settings.ItemTitle2 + " AS " + settings.ItemTitle2 + "_Lang2 ," +
                 DESCR2pREFIX + settings.ItemDescr2 + " AS " + settings.ItemDescr2 + "_Desc2 ," +
                 " B.QTY1, " +
                 " M.MTRMANFCTR  " +
                 " FROM (( MTRL M LEFT OUTER JOIN MTRGROUP G ON M.MTRGROUP = G.MTRGROUP " +
                 " AND G.SODTYPE = 51  " +
                 " AND G.COMPANY = " + S1Init.myXSupport.ConnectionInfo.CompanyId + " ) " +
                 " LEFT OUTER JOIN MTREXTRA ME ON M.MTRL = ME.MTRL ) " +
                 " LEFT OUTER JOIN MTRDATA B ON M.MTRL=B.MTRL AND B.FISCPRD= " + S1Init.myXSupport.ConnectionInfo.YearId.ToString() +
                 " WHERE M.SODTYPE = 51 " +
                 " AND M.COMPANY = " + S1Init.myXSupport.ConnectionInfo.CompanyId +
                  FILTER_CHECKBOX
                 );

              //  MessageBox.Show(S1Init.myXSupport.ConnectionInfo.YearId.ToString());

                this.LoadingProgressBar.Maximum = MTRLS.Count;
                this.LoadingProgressBar.Step = 1;

                int zone;
                PRICERPRC = new string[12, 2];
                for (int j = 0; j < pRCCategories.Count; j++)
                {
                    zone = int.Parse(pRCCategories[j, 7].ToString());
                    PRICERPRC[zone - 1, 0] = pRCCategories[j, 2].ToString();
                }

                for (int i = 0; i < MTRLS.Count; i++)
                {
                    int j = 0;
                    CATEG_NAME = "-1";
                    CATEG_ID = "-1";




                    if (!DBNull.Value.Equals(MTRLS[i, settings.ItemCateg]))
                    {
                        CATEG_ID = (String)MTRLS[i, settings.ItemCateg].ToString();
                        if (CATEG_ID.Equals("")) CATEG_ID = "-1";
                    }

                    CODE = "";
                    if (!DBNull.Value.Equals(MTRLS[i, "CODE"]))
                    {
                        CODE = (String)MTRLS[i, "CODE"];
                    }

                    MTRL = "";
                    if (!DBNull.Value.Equals(MTRLS[i, "MTRL"]))
                    {
                        MTRL = (String)MTRLS[i, "MTRL"].ToString();
                    }

                    NAME = "";
                    if (!DBNull.Value.Equals(MTRLS[i, settings.ItemTitle1 + "_Lang1"]))
                    {
                        NAME = (String)MTRLS[i, settings.ItemTitle1 + "_Lang1"];
                    }

                    DESCR = "";
                    if (!DBNull.Value.Equals(MTRLS[i, settings.ItemDescr1 + "_Desc1"]))
                    {
                        DESCR = (String)MTRLS[i, settings.ItemDescr1 + "_Desc1"];
                    }

                    NAME2 = "";
                    if (!DBNull.Value.Equals(MTRLS[i, settings.ItemTitle2 + "_Lang2"]))
                    {
                        NAME2 = (String)MTRLS[i, settings.ItemTitle2 + "_Lang2"];
                    }

                    DESCR2 = "";
                    if (!DBNull.Value.Equals(MTRLS[i, settings.ItemDescr2 + "_Desc2"]))
                    {
                        DESCR2 = (String)MTRLS[i, settings.ItemDescr2 + "_Desc2"];
                    }

                    MTRMANFCTR = "";
                    if (!DBNull.Value.Equals(MTRLS[i, "MTRMANFCTR"]))
                    {
                        try
                        {
                            MTRMANFCTR = (String)MTRLS[i, "MTRMANFCTR"].ToString();
                        }
                        catch (Exception ex) 
                        {
 
                        }
                    }

                    QTY = "0";
                    if (!DBNull.Value.Equals(MTRLS[i, "QTY1"]))
                    {
                        try
                        {
                            QTY = (String)MTRLS[i, "QTY1"].ToString();
                        }
                        catch (Exception ex)
                        {

                        }
                    }

                    ITEM_PRICE = "";
                    if (!DBNull.Value.Equals(MTRLS[i, settings.ITEM_PRICE]))
                    {
                        ITEM_PRICE = (String)MTRLS[i, settings.ITEM_PRICE].ToString();
                    }


                    if (!DBNull.Value.Equals(MTRLS[i, settings.ITEM_PRICE + "01"]))
                    {
                        PRICERPRC[j, 1] = (String)MTRLS[i, settings.ITEM_PRICE + "01"].ToString();
                        j++;
                    }
                    if (!DBNull.Value.Equals(MTRLS[i, settings.ITEM_PRICE + "02"]))
                    {
                        PRICERPRC[j, 1] = (String)MTRLS[i, settings.ITEM_PRICE + "02"].ToString();
                        j++;
                    }
                    if (!DBNull.Value.Equals(MTRLS[j, settings.ITEM_PRICE + "03"]))
                    {
                        PRICERPRC[i, 1] = (String)MTRLS[i, settings.ITEM_PRICE + "03"].ToString();
                        j++;
                    }
                    if (!DBNull.Value.Equals(MTRLS[j, settings.ITEM_PRICE + "04"]))
                    {
                        PRICERPRC[i, 1] = (String)MTRLS[i, settings.ITEM_PRICE + "04"].ToString();
                        j++;
                    }
                    if (!DBNull.Value.Equals(MTRLS[i, settings.ITEM_PRICE + "05"]))
                    {
                        PRICERPRC[j, 1] = (String)MTRLS[i, settings.ITEM_PRICE + "05"].ToString();
                        j++;
                    }
                    if (!DBNull.Value.Equals(MTRLS[i, settings.ITEM_PRICE + "06"]))
                    {
                        PRICERPRC[j, 1] = (String)MTRLS[i, settings.ITEM_PRICE + "06"].ToString();
                        j++;
                    }
                    if (!DBNull.Value.Equals(MTRLS[i, settings.ITEM_PRICE + "07"]))
                    {
                        PRICERPRC[j, 1] = (String)MTRLS[i, settings.ITEM_PRICE + "07"].ToString();
                        j++;
                    }
                    if (!DBNull.Value.Equals(MTRLS[i, settings.ITEM_PRICE + "08"]))
                    {
                        PRICERPRC[j, 1] = (String)MTRLS[i, settings.ITEM_PRICE + "08"].ToString();
                        j++;
                    }
                    if (!DBNull.Value.Equals(MTRLS[i, settings.ITEM_PRICE + "09"]))
                    {
                        PRICERPRC[j, 1] = (String)MTRLS[i, settings.ITEM_PRICE + "09"].ToString();
                        j++;
                    }
                    if (!DBNull.Value.Equals(MTRLS[i, settings.ITEM_PRICE + "10"]))
                    {
                        PRICERPRC[j, 1] = (String)MTRLS[i, settings.ITEM_PRICE + "10"].ToString();
                        j++;
                    }
                    if (!DBNull.Value.Equals(MTRLS[i, settings.ITEM_PRICE + "11"]))
                    {
                        PRICERPRC[j, 1] = (String)MTRLS[i, settings.ITEM_PRICE + "11"].ToString();
                        j++;
                    }
                    if (!DBNull.Value.Equals(MTRLS[i, settings.ITEM_PRICE + "12"]))
                    {
                        PRICERPRC[j, 1] = (String)MTRLS[i, settings.ITEM_PRICE + "12"].ToString();
                        j++;
                    }

                    itemHttp.syncMTRL(CODE, NAME, NAME2, DESCR, DESCR2, ITEM_PRICE, PRICERPRC, j, CATEG_NAME, CATEG_ID, QTY, MTRMANFCTR, "" , "" ,"");
                    GlobalFunctions.updateCharQTYS(MTRL);
                    imageUp.uploadItemImage(MTRL, CODE);
                    
                    this.LoadingProgressBar.PerformStep();
                }


                this.LoadingProgressBar.Value = 0;
                MessageBox.Show("Διαδικασία ολοκληρώθηκε."); */
        }


        private void PRCCategLoginButton_Click(object sender, EventArgs e)
        {
            ExternalBrowser externalBrowser = new ExternalBrowser();
            Settings settings = Settings.getInstance();

            externalBrowser.adminOpen(settings.domain + settings.AdminPath +"/index.php?route=sale/customer_group");
        }

        private void MTRGROUPLoginButton_Click(object sender, EventArgs e)
        {
            ExternalBrowser externalBrowser = new ExternalBrowser();
            Settings settings = Settings.getInstance();

            externalBrowser.adminOpen(settings.domain + settings.AdminPath + "/index.php?route=catalog/category");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ExternalBrowser externalBrowser = new ExternalBrowser();
            Settings settings = Settings.getInstance();

            externalBrowser.adminOpen(settings.domain + settings.AdminPath + "/index.php?route=sale/customer");
        }

        private void MtrlLoginButton_Click(object sender, EventArgs e)
        {
            ExternalBrowser externalBrowser = new ExternalBrowser();
            Settings settings = Settings.getInstance();

            externalBrowser.adminOpen(settings.domain + settings.AdminPath + "/index.php?route=catalog/product");
        }

        private void button3_Click(object sender, EventArgs e)
        {

            try
            {
                this.LoadingProgressBar.Maximum = 3;
                this.LoadingProgressBar.Step = 1;
                GlobalFunctions.updateQTYsByMtrlsOnTransactions();
                this.LoadingProgressBar.Step = 2;
                GlobalFunctions.updateCharQTYSByMtrlsOnTransactions("");
                this.LoadingProgressBar.Step = 3;
                MessageBox.Show("Διαδικασία ολοκληρώθηκε.");
                this.LoadingProgressBar.Value = 0;  
            }
            catch
            { }

            MessageBox.Show("Διαδικασία ολοκληρώθηκε.");

            /*
            this.LoadingProgressBar.Maximum = 3;
            this.LoadingProgressBar.Step = 1;
            GlobalFunctions.updateQTYS();
            this.LoadingProgressBar.Step = 2;
            GlobalFunctions.updateCharQTYS("");
            this.LoadingProgressBar.Step = 3;
            MessageBox.Show("Διαδικασία ολοκληρώθηκε.");
            this.LoadingProgressBar.Value = 0;  
             */
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ExternalBrowser externalBrowser = new ExternalBrowser();
            Settings settings = Settings.getInstance();

            externalBrowser.adminOpen(settings.domain + settings.AdminPath + "/index.php?route=catalog/product");
        }

        private void button5_Click(object sender, EventArgs e)
        {

            OptionHttp optionHttp = new OptionHttp();
            List<string[]> list ; // = new List<string[]>();

            XTable CDIMS = S1Init.myXSupport.GetSQLDataSet(
             " SELECT  "+
            // " A.COMPANY, "+
            // " A.CDIM, "+
            // " A.CODE, "+
            // " A.CDIMCATEG, "+
            // " A.NAME, "+
            // " A.ISACTIVE  "+
             " * " + 
             " FROM CDIM A  "+
             " WHERE A.COMPANY=  "+ S1Init.myXSupport.ConnectionInfo.CompanyId.ToString() +
             " AND A.ISACTIVE = 1 " +
             " AND A.MTRL IS NULL "+
             " ORDER BY A.CDIM,A.COMPANY " 
             );


            this.LoadingProgressBar.Maximum = CDIMS.Count;
            this.LoadingProgressBar.Step = 1;

            for (int i = 0; i < CDIMS.Count; i++)
            {

               /* String afdf = "  SELECT  * " +
             "  FROM CDIMLINES A   " +
             "  WHERE A.COMPANY= " + S1Init.myXSupport.ConnectionInfo.CompanyId.ToString() +
             "  AND ISACTIVE = 1 " +
             "  AND CDIM = " + CDIMS[i, "CDIM"].ToString(); */


                XTable CDIMLINES = S1Init.myXSupport.GetSQLDataSet(
             "  SELECT  * "+
             "  FROM CDIMLINES A   "+
             "  WHERE A.COMPANY=  " + S1Init.myXSupport.ConnectionInfo.CompanyId.ToString() +
			 "  AND ISACTIVE = 1 "+
             "  AND CDIM = " + CDIMS[i,"CDIM"].ToString()
             );

                list = new List<string[]>();
                for (int j = 0; j < CDIMLINES.Count; j++)
                {
                    String[] optionsPair = new String[2];
                    optionsPair[0] = CDIMLINES[j, "CDIMLINES"].ToString();
                    optionsPair[1] = CDIMLINES[j, "CODE"].ToString();
                    list.Add(optionsPair);
                }


                if (CDIMLINES.Count > 0)
                {
                    optionHttp.syncOptions(CDIMS[i, "CDIM"].ToString(),
                        CDIMS[i, "NAME"].ToString(),
                        list
                        );
                }

               // list.Clear();
                this.LoadingProgressBar.PerformStep();
            }

            this.LoadingProgressBar.Value = 0; 
            MessageBox.Show("Διαδικασία ολοκληρώθηκε.");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ExternalBrowser externalBrowser = new ExternalBrowser();
            Settings settings = Settings.getInstance();

            externalBrowser.adminOpen(settings.domain + settings.AdminPath + "/index.php?route=catalog/option");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                this.LoadingProgressBar.Maximum = 3;
                this.LoadingProgressBar.Step = 1;
                GlobalFunctions.updateQTYS("");
                this.LoadingProgressBar.Step = 2;
                GlobalFunctions.updateCharQTYS("");
                this.LoadingProgressBar.Step = 3;
                MessageBox.Show("Διαδικασία ολοκληρώθηκε.");
                this.LoadingProgressBar.Value = 0;
            }
            catch
            { }

            MessageBox.Show("Διαδικασία ολοκληρώθηκε.");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ExternalBrowser externalBrowser = new ExternalBrowser();
            Settings settings = Settings.getInstance();

            externalBrowser.adminOpen(settings.domain + settings.AdminPath + "/index.php?route=catalog/product");
        }

        private void button8_Click_1(object sender, EventArgs e)
        {

            if (this.BarcodeTextBox.Text == "") return; 

            try
            {

                String Barcode = this.BarcodeTextBox.Text;
                Barcode = Barcode.Replace("*", "%");

                XTable CODELINES = S1Init.myXSupport.GetSQLDataSet(
                    " SELECT MTRL FROM MTRL WHERE "+
                    " ( CODE2 LIKE '" + Barcode+ "' " +
                    " OR CODE LIKE '" + Barcode + "' " +
                    " OR CODE1 LIKE '" + Barcode + "' ) " +
                    " AND SODTYPE = 51  " +
                    " AND COMPANY = " + S1Init.myXSupport.ConnectionInfo.CompanyId.ToString() );

                this.LoadingProgressBar.Maximum = CODELINES.Count;
                for (int j = 0; j < CODELINES.Count; j++)
                {
                    GlobalFunctions.syncMtrl(this.LoadingProgressBar,CODELINES[j, "MTRL"].ToString()); 
                    GlobalFunctions.updateQTYS(CODELINES[j, "MTRL"].ToString()); 
                    GlobalFunctions.updateCharQTYS(CODELINES[j, "MTRL"].ToString());     
                 //   MessageBox.Show("Διαδικασία ολοκληρώθηκε.");
                    this.LoadingProgressBar.Step = this.LoadingProgressBar.Step+1 ;
                }
                this.LoadingProgressBar.Value = 0;

            }
            catch
            { }

            MessageBox.Show("Διαδικασία ολοκληρώθηκε.");


        }
    }
}
