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

namespace S1Custom
{
    public partial class PRCCategoryForm : Form
    {
        public XTable PRCCategory;
        private Io.HttpWeb.PRCCategoryHttp pRCCategoryHttp = new Io.HttpWeb.PRCCategoryHttp();


        public PRCCategoryForm()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            ExternalBrowser externalBrowser = new ExternalBrowser();
            Settings settings = Settings.getInstance();
            String CODE = "";
            int number; 

            if (!DBNull.Value.Equals(PRCCategory.Current["CODE"]))
            {
                CODE = (String)PRCCategory.Current["CODE"].ToString();
            }
            else return;

            String result = this.pRCCategoryHttp.getId(CODE);
            result = result.Replace("\"", "");


            // MessageBox.Show(result);

            if (result.Equals("-1") || !int.TryParse(result, out number) )
            {
                MessageBox.Show("Η τιμολογιακή κατηγορία δεν υπάρχει στο Web.");
                return;
            }

            externalBrowser.adminOpen(settings.domain + "admin/index.php?route=sale/customer_group/update&customer_group_id=" + result);
        }


        private void SyncButton_Click(object sender, EventArgs e)
        {
            String result = "";
            String CODE = "", NAME = "" ;

            if (!DBNull.Value.Equals(PRCCategory.Current["CODE"]))
            {
                CODE = (String)PRCCategory.Current["CODE"].ToString();
            }
            if (!DBNull.Value.Equals(PRCCategory.Current["NAME"]))
            {
                NAME = (String)PRCCategory.Current["NAME"].ToString();
            }


            /* MessageBox.Show( "ΚΩΔΙΚΟΣ: " + CODE+
                "\n ΕΠΩΝΥΜΙΑ: " + NAME +
                "\n ΕΠΆΓΓΕΛΜΑ: " + JOBTYPETRD +
               "\n ΔΙΕΥΘΥΝΣΗ: " + ADDRESS +
                "\n ΤΚ: "+ ZIP + 
                "\n ΠΟΛΗ: "+  CITY +
                "\n ΤΗΛΕΦΩΝΟ1: "+ PHONE01 + 
                "\n ΑΦΜ: "+ AFM + 
                "\n FAX: "+ FAX + 
                "\n EMAIL: "+ EMAIL 
                );  */


            result = this.pRCCategoryHttp.sync(CODE, NAME);


            //  result = result.Replace("{", "");
            //  result = result.Replace("}", "");
            //  result = result.Replace("\"", "");
            // String[] split = result.Split(':');
            //  int resultCode = Convert.ToInt32(split[1]);
            //if()  
            //     this.textBox1.AppendText(split[1]);


            if (result.Equals("{\"actions\":\"1\"}"))
            {
                this.ResultsTextBox.SelectionColor = Color.Green;

                this.ResultsTextBox.AppendText(DateTime.Now.ToString("MM\\/dd\\/yyyy h\\:mm tt") + "   ");
                this.ResultsTextBox.AppendText("Ο συγχρονισμός πραγματοποιήθηκε.\n");
                this.ResultsTextBox.AppendText("Η τιμολογιακή κατηγορία με κωδικό " + CODE + " καταχωρήθηκε στην ιστοσελίδα.\n\n");
            }
            else if (result.Equals("{\"actions\":\"0\"}"))
            {
                this.ResultsTextBox.SelectionColor = Color.Blue;
                this.ResultsTextBox.AppendText(DateTime.Now.ToString("MM\\/dd\\/yyyy h\\:mm tt") + "   ");
                this.ResultsTextBox.AppendText("Ο συγχρονισμός πραγματοποιήθηκε.\n");
                this.ResultsTextBox.AppendText("Η τιμολογιακή κατηγορία με κωδικό " + CODE + " ενημερώθηκε στην ιστοσελίδα .\n\n");
            }
            else
            {
                this.ResultsTextBox.SelectionColor = Color.Red;
                this.ResultsTextBox.AppendText(result);
                //this.textBox1.AppendText("Πρόβλημα σύνδεσης με ιστοσελίδα.\n");
            }

            this.ResultsTextBox.SelectionStart = this.ResultsTextBox.Text.Length;
            this.ResultsTextBox.ScrollToCaret();
        }


        private void DeleteButton_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Θέλετε να την τιμολογιακή κατηγορία απο το Web;", "Διαγραφή τιμολογιακής κατηγορίας απο Web!!", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.No)
            {
                return;
            }

            String result = "";
            String CODE = "";

            if (!DBNull.Value.Equals(PRCCategory.Current["CODE"]))
            {
                CODE = (String)PRCCategory.Current["CODE"];
            }


            result = this.pRCCategoryHttp.delete(CODE);


            if (result.Equals("{\"actions\":\"1\"}"))
            {
                this.ResultsTextBox.SelectionColor = Color.Red;
                this.ResultsTextBox.AppendText(DateTime.Now.ToString("MM\\/dd\\/yyyy h\\:mm tt") + "   ");
                this.ResultsTextBox.AppendText("Η τιμολογιακή κατηγορία με κωδικό " + CODE + " έχει διαγραφέι απο την ιστοσελίδα.\n\n");
            }
            else if (result.Equals("{\"actions\":\"0\"}"))
            {
                this.ResultsTextBox.SelectionColor = Color.Gray;
                this.ResultsTextBox.AppendText(DateTime.Now.ToString("MM\\/dd\\/yyyy h\\:mm tt") + "   ");
                this.ResultsTextBox.AppendText("Η τιμολογιακή κατηγορία με κωδικό " + CODE + " δεν διαγράφηκε γιατί δεν υπάρχει στην ιστοσελίδα.\n\n");
            }
            else if (result.Equals("{\"actions\":\"2\"}"))
            {
                this.ResultsTextBox.SelectionColor = Color.Red;
                this.ResultsTextBox.AppendText(DateTime.Now.ToString("MM\\/dd\\/yyyy h\\:mm tt") + "   ");
                this.ResultsTextBox.AppendText("Η τιμολογιακή κατηγορία με κωδικό " + CODE + " δεν διαγράφηκε γιατί υπάρχουν πελάτες που τη χρησιμοποιούν.\n\n");
            }
            else
            {
                this.ResultsTextBox.SelectionColor = Color.Red;
                this.ResultsTextBox.AppendText(result);
            }
            this.ResultsTextBox.SelectionStart = this.ResultsTextBox.Text.Length;
            this.ResultsTextBox.ScrollToCaret();
        }



    }
}
