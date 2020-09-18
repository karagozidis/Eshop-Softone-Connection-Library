using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Softone;

namespace S1Custom
{
    public partial class S1CustomForm1 : Form
    {
        public S1CustomForm1()
        {
            InitializeComponent() ;

            Settings settings = Settings.getInstance() ;
            this.DomainTextBox.Text = settings.domain ;
            this.UserNameTextBox.Text = settings.user ;
            this.PasswordTextBox.Text = settings.password ;
            this.TimeIntervalTextBox.Text = settings.timerInterval.ToString() ;
            this.OrderSeriesTextBox.Text = settings.orderSeries.ToString() ;
            this.EXPNTextBox.Text = settings.EXPN.ToString() ;

            this.TrdrNameTextBox.Text = settings.TRDR_NAME_FIELD ;
            this.TrdrLNameTextBox.Text = settings.TRDR_LNAME_FIELD ;
            this.TrdrPasswordTextBox.Text = settings.TRDR_PASSWORD_FIELD ; 
            this.TrdrOnWebTextBox.Text = settings.TRDR_ON_WEB ;
            this.ItemOnWebTextBox.Text = settings.ITEM_ON_WEB ;
             
            this.ItemPriceTextBox.Text = settings.ITEM_PRICE ;

            this.FtpDomainTextBox.Text = settings.imagesFtpDomain ;
            this.FtpUserTextBox.Text = settings.imagesFtpUser ;
            this.FtpPasswordTextBox.Text = settings.imagesFtpPassword ;
            this.ImagesDomainTextBox.Text = settings.images_domain ;

        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            Settings settings = Settings.getInstance();

            settings.updateSetting("domain", this.DomainTextBox.Text);
            settings.domain = this.DomainTextBox.Text;


            settings.updateSetting("user", this.UserNameTextBox.Text);
            settings.user = this.UserNameTextBox.Text;

            settings.updateSetting("password", this.PasswordTextBox.Text);
            settings.password = this.PasswordTextBox.Text;

            settings.updateSetting("timerInterval", this.TimeIntervalTextBox.Text);
            settings.timerInterval = Convert.ToInt32(this.TimeIntervalTextBox.Text);

            settings.updateSetting("TRDR_NAME_FIELD", this.TrdrNameTextBox.Text);
            settings.TRDR_NAME_FIELD = this.TrdrNameTextBox.Text;

            settings.updateSetting("TRDR_LNAME_FIELD", this.TrdrLNameTextBox.Text);
            settings.TRDR_LNAME_FIELD = this.TrdrLNameTextBox.Text  ;

            settings.updateSetting("TRDR_PASSWORD_FIELD", this.TrdrPasswordTextBox.Text);
            settings.TRDR_PASSWORD_FIELD = this.TrdrPasswordTextBox.Text  ;

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

            MessageBox.Show("Αλλαγές Αποθηκεύτηκαν");
        }

        private void OrderSaveButton_Click(object sender, EventArgs e)
        {
        //    Settings settings = Settings.getInstance();

       //     settings.updateSetting("orderSeries", this.OrderSeriesTextBox.Text);
       //     settings.orderSeries = this.OrderSeriesTextBox.Text;

       //     settings.updateSetting("EXPN", this.EXPNTextBox.Text);
       //     settings.EXPN = this.EXPNTextBox.Text;

       //     MessageBox.Show("Αλλαγές Αποθηκεύτηκαν");
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void OrderSaveButton_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {   
            Io.HttpWeb.PRCCategoryHttp pRCCategoryHttp = new Io.HttpWeb.PRCCategoryHttp();


            XTable PRCCATEGORIES = Model.S1Init.myXSupport.GetSQLDataSet("SELECT" +
                  " PRCCATEGORY " +
                  " ,CODE " +
                  " ,NAME " +
                  " ,ACNMSK " +
                  " ,ISACTIVE " +
                  " ,PRICEZONE " +
                  " ,COMPANY " +
                  " FROM PRCCATEGORY " +
                  " WHERE COMPANY = " + Model.S1Init.myXSupport.ConnectionInfo.CompanyId.ToString() );

            this.LoadingProgressBar.Maximum = PRCCATEGORIES.Count;
            this.LoadingProgressBar.Step = 1;

            for (int i = 0; i < PRCCATEGORIES.Count; i++)
                {
                    pRCCategoryHttp.sync(PRCCATEGORIES[0, "CODE"].ToString(),
                        PRCCATEGORIES[0, "NAME"].ToString());
                   
                    this.LoadingProgressBar.PerformStep();
                }

            this.LoadingProgressBar.Value = 0;
            MessageBox.Show("Διαδικασία ολοκληρώθηκε.");
        }

        private void PRCCategLoginButton_Click(object sender, EventArgs e)
        {
            ExternalBrowser externalBrowser = new ExternalBrowser();
            Settings settings = Settings.getInstance();

            externalBrowser.adminOpen(settings.domain + "admin/index.php?route=sale/customer_group");
        }

        private void MTRGROUPLoginButton_Click(object sender, EventArgs e)
        {
            ExternalBrowser externalBrowser = new ExternalBrowser();
            Settings settings = Settings.getInstance();

            externalBrowser.adminOpen(settings.domain + "admin/index.php?route=catalog/category");
        }

        private void MTRGROUPSyncButton_Click(object sender, EventArgs e)
        {
            Io.HttpWeb.ItemHttp ITEMHttp = new Io.HttpWeb.ItemHttp();

            XTable MTRGROUP = Model.S1Init.myXSupport.GetSQLDataSet(
                      "  SELECT COMPANY " +
                      " ,SODTYPE " +
                      " ,UTBL05 " +
                      " ,CODE " +
                      " ,NAME " +
                      " ,ISACTIVE " +
                      " FROM UTBL05 " +
                    //  " WHERE SODTYPE = 51 " +
                      " WHERE ISACTIVE = 1 " + 
                      " AND COMPANY = " + Model.S1Init.myXSupport.ConnectionInfo.CompanyId.ToString());

            this.LoadingProgressBar.Maximum = MTRGROUP.Count;
            this.LoadingProgressBar.Step = 1;

            for (int i = 0; i < MTRGROUP.Count; i++)
            {
                ITEMHttp.syncMTRGROUP(MTRGROUP[i, "UTBL05"].ToString(),
                    MTRGROUP[i, "NAME"].ToString());

                this.LoadingProgressBar.PerformStep();
            }

            this.LoadingProgressBar.Value = 0;
            MessageBox.Show("Διαδικασία ολοκληρώθηκε.");
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Io.HttpWeb.CustomerHttp customerHttp = new Io.HttpWeb.CustomerHttp() ;
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


            XTable TRDRGROUP = Model.S1Init.myXSupport.GetSQLDataSet(
             "   SELECT  "+
             "  " + TRDR_NAME_FIELD + ", " +
             "  " + TRDR_LNAME_FIELD + ", " +
             "  " + TRDR_PASSWORD_FIELD + ", " + 
             "   T.CODE, "+
             "   T.JOBTYPETRD, "+
             "   T.ADDRESS, "+
             "   T.ZIP, "+
             "   T.CITY, "+
             "   T.PHONE01, "+
             "   T.FAX, "+
             "   T.EMAIL, "+
             "   T.PRCCATEGORY "+
             "   FROM TRDR T "+
             "   LEFT OUTER JOIN TRDEXTRA TE ON TE.TRDR = T.TRDR "+
             "   WHERE T.SODTYPE = 13 "+
             "   AND ISACTIVE = 1  " +
             "   AND T.COMPANY = " + Model.S1Init.myXSupport.ConnectionInfo.CompanyId.ToString() +
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

        private void button2_Click(object sender, EventArgs e)
        {
            ExternalBrowser externalBrowser = new ExternalBrowser();
            Settings settings = Settings.getInstance();

            externalBrowser.adminOpen(settings.domain + "admin/index.php?route=sale/customer");
        }

        private void MtrlSyncButton_Click(object sender, EventArgs e)
        {
            Io.HttpWeb.ItemHttp itemHttp = new Io.HttpWeb.ItemHttp();
            string[,] PRICERPRC = new string[12, 2];
            String CODE = "", NAME = "", ITEM_PRICE = "";
            String CATEG_NAME = "-1", CATEG_ID = "-1";
            Settings settings = Settings.getInstance();
            String FILTER_CHECKBOX = "";

            XTable pRCCategories = Model.S1Init.myXSupport.GetSQLDataSet(
            "SELECT A.COMPANY,A.PRCCATEGORY,A.CODE,A.NAME,A.ACNMSK,A.ISACTIVE,A.PRICEZONE " +
            "FROM PRCCATEGORY A WHERE A.COMPANY=" + Model.S1Init.myXSupport.ConnectionInfo.CompanyId + " ORDER BY A.PRCCATEGORY"
             );

            if (!settings.ITEM_ON_WEB.Equals(""))
            {
                FILTER_CHECKBOX = " AND ME." + settings.ITEM_ON_WEB + " = 1";
            }

            XTable MTRLS = Model.S1Init.myXSupport.GetSQLDataSet(
             " SELECT "+
             " M.CODE , "+
             " M.NAME ,  "+
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
             " G.CODE ,  "+
             " G.NAME " +
             " FROM ( MTRL M LEFT OUTER JOIN MTRGROUP G ON M.MTRGROUP = G.MTRGROUP " +
             " AND G.SODTYPE = 51  " +
             " AND G.COMPANY = " + Model.S1Init.myXSupport.ConnectionInfo.CompanyId + " ) "+
             " LEFT OUTER JOIN MTREXTRA ME ON M.MTRL = ME.MTRL " +
             " WHERE M.SODTYPE = 51 " +
             " AND M.COMPANY = " + Model.S1Init.myXSupport.ConnectionInfo.CompanyId +
              FILTER_CHECKBOX
             );

            this.LoadingProgressBar.Maximum = MTRLS.Count;
            this.LoadingProgressBar.Step = 1;

            int zone;
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

                if (!DBNull.Value.Equals(MTRLS[i,"CODE"]))
                {
                    CODE = (String)MTRLS[i, "CODE"];
                }
                if (!DBNull.Value.Equals(MTRLS[i, "NAME"]))
                {
                    NAME = (String)MTRLS[i, "NAME"];
                }
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

                itemHttp.syncMTRL(CODE, NAME, ITEM_PRICE, PRICERPRC, j, CATEG_NAME, CATEG_ID);

                this.LoadingProgressBar.PerformStep();
            }


            this.LoadingProgressBar.Value = 0;
            MessageBox.Show("Διαδικασία ολοκληρώθηκε.");

        }
    }
}
