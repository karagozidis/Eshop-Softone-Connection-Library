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
using ClassLibrary4.CONTROL;

namespace S1Custom
{
    public partial class CustomerForm : Form
    {
        public XTable TRDR;
        public XTable CustExtra;
        String password = "1491205";
        private Io.HttpWeb.CustomerHttp customerHttp = new Io.HttpWeb.CustomerHttp() ;
        JArray jCustomersOnWebResponce;

        DataTable connectionBricks;


        public CustomerForm()
        {
            InitializeComponent();
        }


        public void syncOnSave()
        {
          /*  Settings settings = Settings.getInstance();

            if (settings.TrdrUpdateOnPost == "1")
            {
                if (settings.TRDR_ON_WEB.Equals(""))
                {
                    Sync();
                }
                else
                {
                    // Sync();
                    if (!DBNull.Value.Equals(CustExtra.Current[settings.TRDR_ON_WEB]))
                    {
                        if (CustExtra.Current[settings.TRDR_ON_WEB].ToString().Equals("1"))
                        {
                            Sync();
                        }
                    }

                }
            } */
        }


        private void SyncButton_Click(object sender, EventArgs e)
        {
          //  Sync();
        }

        private void Sync()
        {
          /*  Settings settings = Settings.getInstance();

            String result = "";
            String CODE = "", NAME = "", LASTNAME = "" ,JOBTYPETRD = "", ADDRESS = "", ZIP = "", CITY = "", PHONE01 = "", PASSWORD = "", FAX = "", EMAIL = "", PRCCATEGORY = "-1";


            if ( ! DBNull.Value.Equals(TRDR.Current["CODE"]) ) 
                {
                    CODE = (String) TRDR.Current["CODE"].ToString();
                }


            if (settings.TRDR_NAME_FIELD.Contains("VARCHAR"))
            {
                if (!DBNull.Value.Equals(CustExtra.Current[settings.TRDR_NAME_FIELD]))
                {
                    NAME = (String)CustExtra.Current[settings.TRDR_NAME_FIELD].ToString();
                }
            }
            else
            {
                if (!DBNull.Value.Equals(TRDR.Current[settings.TRDR_NAME_FIELD]))
                {
                    NAME = (String)TRDR.Current[settings.TRDR_NAME_FIELD].ToString();
                }
            }


            if (settings.TRDR_LNAME_FIELD.Contains("VARCHAR"))
            {
                if (!DBNull.Value.Equals(CustExtra.Current[settings.TRDR_LNAME_FIELD]))
                {
                    LASTNAME = (String)CustExtra.Current[settings.TRDR_LNAME_FIELD].ToString();
                }
            }
            else
            {
                if (!DBNull.Value.Equals(TRDR.Current[settings.TRDR_LNAME_FIELD]))
                {
                    LASTNAME = (String)TRDR.Current[settings.TRDR_LNAME_FIELD].ToString();
                }
            }


            if (settings.TRDR_PASSWORD_FIELD.Contains("VARCHAR"))
            {
                if (!DBNull.Value.Equals(CustExtra.Current[settings.TRDR_PASSWORD_FIELD]))
                {
                    PASSWORD = (String)CustExtra.Current[settings.TRDR_PASSWORD_FIELD].ToString();
                }
            }
            else
            {
            if (!DBNull.Value.Equals(TRDR.Current[settings.TRDR_PASSWORD_FIELD]))
                {
                    PASSWORD = (String)TRDR.Current[settings.TRDR_PASSWORD_FIELD].ToString();
                }
            }


            if ( ! DBNull.Value.Equals(TRDR.Current["JOBTYPETRD"]) )
                {
                    JOBTYPETRD = (String)TRDR.Current["JOBTYPETRD"].ToString();
                }
            if (!DBNull.Value.Equals(TRDR.Current["ADDRESS"])) 
                {
                    ADDRESS = (String)TRDR.Current["ADDRESS"].ToString();
                }
            if (!DBNull.Value.Equals(TRDR.Current["ZIP"])) 
                {
                    ZIP = (String)TRDR.Current["ZIP"].ToString();
                }
            if (!DBNull.Value.Equals(TRDR.Current["CITY"]))
                {
                    CITY = (String)TRDR.Current["CITY"].ToString();
                }
            if (!DBNull.Value.Equals(TRDR.Current["PHONE01"])) 
                {
                    PHONE01 = (String)TRDR.Current["PHONE01"].ToString();
                }

            if (!DBNull.Value.Equals(TRDR.Current["FAX"]))
                {
                    FAX = (String)TRDR.Current["FAX"].ToString();
                }
            if (!DBNull.Value.Equals(TRDR.Current["EMAIL"]))
                {
                    EMAIL = (String)TRDR.Current["EMAIL"].ToString();
                }
            if (!DBNull.Value.Equals(TRDR.Current["PRCCATEGORY"]))
                {
                    PRCCATEGORY = (String)TRDR.Current["PRCCATEGORY"].ToString();
                }
  
            
            //MessageBox.Show("PRCCATEGORY: " + PRCCATEGORY);

            result = customerHttp.syncCustomer(CODE, NAME, LASTNAME, JOBTYPETRD, ADDRESS, ZIP, CITY, PHONE01, PASSWORD, FAX, EMAIL, PRCCATEGORY);

      
          //  result = result.Replace("{", "");
          //  result = result.Replace("}", "");
          //  result = result.Replace("\"", "");
          // String[] split = result.Split(':');
         //  int resultCode = Convert.ToInt32(split[1]);
         //if()  
         //     this.textBox1.AppendText(split[1]);


           if (result.Equals("1"))
           {
               this.ResultsTextBox.SelectionColor = Color.Green;
  
               this.ResultsTextBox.AppendText(DateTime.Now.ToString("MM\\/dd\\/yyyy h\\:mm tt") + "   " ); 
               this.ResultsTextBox.AppendText("Ο συγχρονισμός πραγματοποιήθηκε.\n");
               this.ResultsTextBox.AppendText("O πελάτης με κωδικό "+ CODE +" καταχωρήθηκε στην ιστοσελίδα.\n\n");
           }
           else if (result.Equals("0"))
           {
               this.ResultsTextBox.SelectionColor = Color.Blue;
               this.ResultsTextBox.AppendText(DateTime.Now.ToString("MM\\/dd\\/yyyy h\\:mm tt") + "   ");
               this.ResultsTextBox.AppendText("Ο συγχρονισμός πραγματοποιήθηκε.\n");
               this.ResultsTextBox.AppendText("Τα στοιχεία του πελάτη με κωδικό "+ CODE +" ενημερώθηκαν στην ιστοσελίδα .\n\n");
           }
           else
           {
               this.ResultsTextBox.SelectionColor = Color.Red;
               this.ResultsTextBox.AppendText(result);
               //this.textBox1.AppendText("Πρόβλημα σύνδεσης με ιστοσελίδα.\n");
           }

           this.ResultsTextBox.SelectionStart = this.ResultsTextBox.Text.Length;
           this.ResultsTextBox.ScrollToCaret();
            */
        }



        private String Login(String username, String password)
        {
            /*
            Settings settings = Settings.getInstance();
            Stream newStream = null;
            String result = "";
            String strPost = "username=" + settings.user + "&password=" + settings.password;
         


            byte[] byteArray = Encoding.UTF8.GetBytes(strPost);
            HttpWebRequest objRequest = (HttpWebRequest)WebRequest.Create(settings.domain+"admin/index.php?route=common/login");
            objRequest.Method = "POST";
            objRequest.ContentLength = byteArray.Length;
            objRequest.ContentType = "application/x-www-form-urlencoded";


            try
            {
                newStream = objRequest.GetRequestStream(); //open connection
                newStream.Write(byteArray, 0, byteArray.Length); // Send the data.
                newStream.Close();

            }
            catch (Exception ex)
            {
                //return e.Message;
            }
            finally
            {
                // myWriter.Close();
                //  newStream.Close();
                newStream.Close();
            }

            HttpWebResponse objResponse = (HttpWebResponse)objRequest.GetResponse();
            using (StreamReader sr =
               new StreamReader(objResponse.GetResponseStream()))
            {
                result = sr.ReadToEnd();
                sr.Close();
            }
            return result;
            */
            return null;
        }


 /*       private void button1_Click(object sender, EventArgs e)
        {
            Settings settings = Settings.getInstance();
            String id = "2";

            String result = "";
            String strPost = "country_id=" + id + "&mspssr=" + password;
            StreamWriter myWriter = null;

            HttpWebRequest objRequest = (HttpWebRequest)WebRequest.Create(settings.domain+ "index.php?route=softone/customer/Sync");
            objRequest.Method = "POST";
            objRequest.ContentLength = strPost.Length;
            objRequest.ContentType = "application/x-www-form-urlencoded";

            try
            {
                myWriter = new StreamWriter(objRequest.GetRequestStream());
                myWriter.Write(strPost);
            }
            catch (Exception ex)
            {
                //return e.Message;
            }
            finally
            {
                myWriter.Close();
            }

            HttpWebResponse objResponse = (HttpWebResponse)objRequest.GetResponse();
            using (StreamReader sr =
               new StreamReader(objResponse.GetResponseStream()))
            {
                result = sr.ReadToEnd();
               // this.textBox1.AppendText(result);
                // Close and clean up the StreamReader
                sr.Close();
            }


        }*/

        private void DeleteButton_Click(object sender, EventArgs e)
        {
          /* DialogResult dialogResult = MessageBox.Show("Θέλετε να διαγράψετε τον πελάτη απο το Web;", "Διαγραφή πελάτη απο Web!!", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.No)
            {
                return;
            }

            String result = "";
            String CODE = "";

            if (!DBNull.Value.Equals(TRDR.Current["CODE"]))
            {
                CODE = (String)TRDR.Current["CODE"];
            }


            result = this.customerHttp.deleteCustomer(CODE);


            if (result.Equals("1"))
            {
                this.ResultsTextBox.SelectionColor = Color.Red;
                this.ResultsTextBox.AppendText(DateTime.Now.ToString("MM\\/dd\\/yyyy h\\:mm tt") + "   ");
                this.ResultsTextBox.AppendText("O πελάτης με κωδικό " + CODE + " έχει διαγραφέι απο την ιστοσελίδα.\n\n");
            }
            else if (result.Equals("0"))
            {
                this.ResultsTextBox.SelectionColor = Color.Gray;
                this.ResultsTextBox.AppendText(DateTime.Now.ToString("MM\\/dd\\/yyyy h\\:mm tt") + "   ");
                this.ResultsTextBox.AppendText("Ο πελάτης με κωδικό " + CODE + " δεν διαγράφηκε γιατί δεν υπάρχει στην ιστοσελίδα.\n\n");
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


        private void ActiveDeactiveButton_Click(object sender, EventArgs e)
        {
         //   this.checkIfActive();
        }




        public void checkIfActive()
            {
               /* String result = "";
                String CODE = "";

                if (!DBNull.Value.Equals(TRDR.Current["CODE"]))
                {
                    CODE = (String)TRDR.Current["CODE"];
                }


                result = this.customerHttp.activeCustomer(CODE);


                if (result.Equals("0"))
                {
                    this.ResultsTextBox.AppendText(DateTime.Now.ToString("MM\\/dd\\/yyyy h\\:mm tt") + "   ");
                    this.ResultsTextBox.AppendText("O πελάτης με κωδικό " + CODE + " δεν είναι ενεργός στη σελίδα.\n\n");
                }
                else if (result.Equals("1"))
                {
                    this.ResultsTextBox.SelectionColor = Color.Green;
                    this.ResultsTextBox.AppendText(DateTime.Now.ToString("MM\\/dd\\/yyyy h\\:mm tt") + "   ");
                    this.ResultsTextBox.AppendText("Ο πελάτης με κωδικό " + CODE + " είναι ενεργός στην ιστοσελίδα.\n\n");
                }
                else if (result.Equals("2"))
                {
                    this.ResultsTextBox.SelectionColor = Color.Gray;
                    this.ResultsTextBox.AppendText(DateTime.Now.ToString("MM\\/dd\\/yyyy h\\:mm tt") + "   ");
                    this.ResultsTextBox.AppendText("Ο πελάτης με κωδικό " + CODE + " δεν υπάρχει στην ιστοσελίδα.\n\n");
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



        public void connectToCustomer(String customer_id , String s1Code , String web_name)
        {
            /*
            String result = "";
            result = this.customerHttp.connectToCustomer(customer_id, s1Code);
            if (result.Equals("0"))
            {
                this.ResultsTextBox.AppendText(DateTime.Now.ToString("MM\\/dd\\/yyyy h\\:mm tt") + "   ");
                this.ResultsTextBox.AppendText("Πρόβλημα σύνδεσης.\n\n");
            }
            else if (result.Equals("1"))
            {
                this.ResultsTextBox.SelectionColor = Color.Green;
                this.ResultsTextBox.AppendText(DateTime.Now.ToString("MM\\/dd\\/yyyy h\\:mm tt") + "   ");
                this.ResultsTextBox.AppendText("O πελάτης του Site " + web_name + " έχει συνδεθεί με  τον πελάτη Softone " + s1Code + ".\n\n");
            }
            this.ResultsTextBox.SelectionStart = this.ResultsTextBox.Text.Length;
            this.ResultsTextBox.ScrollToCaret(); 
             */

        }






        private void CustomerForm_Load(object sender, EventArgs e)
        {
            String Sql = " SELECT A.* " +
               " FROM CCCCONNECTIONBRICK A WHERE A.COMPANY=  " + Model.S1Init.myXSupport.ConnectionInfo.CompanyId.ToString() +
               " AND A.RUNINSIDEOBJECT > 0 " +
               " AND  A.BRICKOBJECT = 'CUSTOMER'                                       " +
               " AND ACTIVE = 1                                                        " +
               " ORDER BY A.EXECUTIONORDER                                             ";

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

        private void CustomerForm_Shown(object sender, EventArgs e)
        {
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           // String result = this.customerHttp.getCustomers();
           // dynamic stuff = JsonConvert.DeserializeObject(result);

         //   MessageBox.Show(result);

        }

        private void PasswordButton_Click(object sender, EventArgs e)
        {
           /* String result = "";
            String CODE = "";

            if (!DBNull.Value.Equals(TRDR.Current["CODE"]))
            {
                CODE = (String)TRDR.Current["CODE"].ToString();
            }

            if (this.PasswordTextBox.Text == "")
            {
                MessageBox.Show("Κενός κωδικός");
                return; 
            }


            result = customerHttp.setPSD(this.PasswordTextBox.Text, CODE);



            if (result.Equals("{\"actions\":\"0\"}"))
            {
                this.ResultsTextBox.SelectionColor = Color.Green;

                this.ResultsTextBox.AppendText(DateTime.Now.ToString("MM\\/dd\\/yyyy h\\:mm tt") + "   ");
                this.ResultsTextBox.AppendText("Αλλαγή κωδικού πραγματοποιήθηκε.\n");
                this.ResultsTextBox.AppendText("O πελάτης με κωδικό " + CODE + " έχει κωδικό εισόδου στην ιστοσελίδα." + this.PasswordTextBox.Text + "\n\n");
            }
            else
            {
                this.ResultsTextBox.SelectionColor = Color.Red;
                this.ResultsTextBox.AppendText(result);
                //this.textBox1.AppendText("Πρόβλημα σύνδεσης με ιστοσελίδα.\n");
            }

            this.ResultsTextBox.SelectionStart = this.ResultsTextBox.Text.Length;
            this.ResultsTextBox.ScrollToCaret();
            */
        }

        public void refreshCustomerOnWeb()
        {
           // jCustomersOnWebResponce = this.customerHttp.getCustomers();
          //  this.dipslayCustomerOnWeb(this.SearchCustomersTextBox.Text);
        }

        public void dipslayCustomerOnWeb(String filter)
        {
           /* string[] row;
            this.WebCustomersGridView.Rows.Clear();

            if (jCustomersOnWebResponce != null)
                for (int i = 0; i < jCustomersOnWebResponce.Count; i++)
                {
                    if (jCustomersOnWebResponce[i]["name"].ToString().Contains(filter) || filter.Equals(""))
                    {
                        row = new string[] { jCustomersOnWebResponce[i]["customer_id"].ToString(), jCustomersOnWebResponce[i]["name"].ToString(), jCustomersOnWebResponce[i]["softone_code"].ToString() };
                        this.WebCustomersGridView.Rows.Add(row);
                    }
                } */
        }


        private void button2_Click(object sender, EventArgs e)
        {
          //  this.refreshCustomerOnWeb();
        }

        private void button3_Click(object sender, EventArgs e)
        {
           /*
            
            if (this.jCustomersOnWebResponce == null) return;
            DataGridViewRow row = WebCustomersGridView.SelectedRows[0];

            DialogResult dialogResult = MessageBox.Show("Θέλετε να αντιστοιχίσετε αυτόν τον πελάτη στο Web;", "Αντιστοίχιση πελάτη στο Web!!", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.No)
            {
                return;
            }

            String CODE = "";
        
            if ( ! DBNull.Value.Equals(TRDR.Current["CODE"]) ) 
                {
                    CODE = (String) TRDR.Current["CODE"].ToString();
                }

            this.connectToCustomer(row.Cells[0].Value.ToString(),CODE,  row.Cells[1].Value.ToString());
            this.refreshCustomerOnWeb(); 
            
            */

        }

        private void SearchCustomersTextBox_TextChanged(object sender, EventArgs e)
        {
         //   this.dipslayCustomerOnWeb(this.SearchCustomersTextBox.Text);
            //MessageBox.Show("dd");
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            ExternalBrowser externalBrowser = new ExternalBrowser();
            Settings settings = Settings.getInstance();
            String CODE = "";

            if (!DBNull.Value.Equals(TRDR.Current["CODE"]))
            {
                CODE = (String)TRDR.Current["CODE"].ToString();
            }
            else return;

            String result = this.customerHttp.getCId(CODE);
            result = result.Replace("\"", "");

            if (result.Equals("-1"))
            {
                MessageBox.Show("Ο πελάτης δεν υπάρχει στο Web.");
                return;
            }

            externalBrowser.adminOpen(settings.domain +"/"+ settings.AdminPath + "/index.php?route=customer/customer/edit&customer_id=" + result);
        }


        private void BricksDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            String SelectedCCCCONNECTIONBRICK = this.BricksDataGridView.Rows[BricksDataGridView.CurrentCell.RowIndex].Cells["CCCCONNECTIONBRICK"].Value.ToString();
           
            SyncExecuter.ExecuteBrick(
                    SelectedCCCCONNECTIONBRICK,
                    TRDR.Current["TRDR"].ToString(),
                    this.ResultsTextBox
                    );

            /* DataRow[] foundRows;

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
                         foundRows[i]["SQLCOMMAND"].ToString().Replace("##id##", TRDR.Current["TRDR"].ToString()),
                         foundRows[i]["WEBURL"].ToString(),
                         foundRows[i]["ROWSONURL"].ToString(),
                         foundRows[i]["WEBPARAMFORMAT"].ToString(),
                         this.ResultsTextBox
                         );
                }

            }*/

        }


    }
}
