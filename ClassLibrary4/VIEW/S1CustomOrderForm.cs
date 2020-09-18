using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace S1Custom
{
    public partial class S1CustomOrderForm : Form
    {
        Io.HttpWeb.OrderHttp orderHttp = new Io.HttpWeb.OrderHttp();

        public S1CustomOrderForm()
        {
            InitializeComponent();
            this.getOrders();
        }

        private void OrderForm_Load(object sender, EventArgs e)
        {

        }

        public void loadOrders() 
        {

        }


        private void Weblogin(String orderΙd)
        {
            ExternalBrowser externalBrowser = new ExternalBrowser();
            Settings settings = Settings.getInstance();

            externalBrowser.adminOpen(settings.domain + "admin/index.php?route=sale/order/info&order_id=" + orderΙd);
         }



        private void OrderDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex < 0 || e.RowIndex < 0) return;

            if (e.ColumnIndex == 6)
            { 
                   this.Weblogin(OrderDataGridView.Rows[e.RowIndex].Cells[1].Value.ToString());
            }

            else if (e.ColumnIndex == 7)
            {

                ArrayList items = new ArrayList();
                ArrayList item;
                String FINCODE = "";

                this.getOrder(OrderDataGridView.Rows[e.RowIndex].Cells[1].Value.ToString());

                Settings settings =  Settings.getInstance();
                Model.Order order = new Model.Order();
                int customer_Trdr = -1;
                double shippingPrice = 0;


                String customerCode = OrderDataGridView.Rows[e.RowIndex].Cells[2].Value.ToString();
                String WebCode = OrderDataGridView.Rows[e.RowIndex].Cells[1].Value.ToString();
                DateTime orderDate = DateTime.ParseExact(
                           OrderDataGridView.Rows[e.RowIndex].Cells[0].Value.ToString(),
                           "yyyy-MM-dd HH:mm:ss",
                           System.Globalization.CultureInfo.InvariantCulture);

                if (customerCode == "")
                {
                    MessageBox.Show("Ο πελάτης " + OrderDataGridView.Rows[e.RowIndex].Cells[3].Value.ToString() + " του Site, δεν έχει συνδεθεί με πελάτη του softone", "Λάθος αντιστοίχισης");
                    return;
                }

                customer_Trdr = order.CustomerCodeToTrdr(customerCode);
                if (customer_Trdr < 0)
                    {
                    MessageBox.Show("Ο κωδικός πελάτη " + OrderDataGridView.Rows[e.RowIndex].Cells[2].Value.ToString() + " του Site, δεν υπάρχει στο softone", "Λάθος αντιστοίχισης");
                    return;
                    }


                if (!settings.OrderWebRel.Equals(""))
                {
                    FINCODE = order.FindoCExist(WebCode);
                    if (!FINCODE.Equals("-1"))
                    {
                        MessageBox.Show("Η παραγγελία web υπάρχει ήδη, με κωδικό " + FINCODE + "");
                        OrderDataGridView.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Gray;
                        return;
                    }
                }

                shippingPrice = Convert.ToDouble(OrderDataGridView.Rows[e.RowIndex].Cells[4].Value.ToString().Replace(".", ","));

                foreach (DataGridViewRow row in ProductDataGridView.Rows)
                {
                    String itemCode = row.Cells[0].Value.ToString();
                    int item_mtrl;
                   

                    if (itemCode == "")
                    {
                        MessageBox.Show("To Προϊόν " + row.Cells[1].Value.ToString() + " του Site, δεν έχει συνδεθεί με προιόν του softone", "Λάθος αντιστοίχισης");
                        return;
                    }

                    item_mtrl = order.ItemCodeToMtrl(itemCode);
                    if (item_mtrl < 0)
                    {
                        MessageBox.Show("O Κωδικός Προϊόντος " + row.Cells[0].Value.ToString() + " του Site, δεν υπάρχει στο softone", "Λάθος αντιστοίχισης");
                        return;
                    }


                    item = new ArrayList();
                    item.Add(row.Cells[0].Value.ToString()); //  Kvdikos 
                    item.Add(row.Cells[1].Value.ToString()); //  Perigrafh
                    item.Add(row.Cells[2].Value.ToString()); //  Posothta
                    item.Add(row.Cells[3].Value.ToString()); //  Timh Monadas
                    item.Add(row.Cells[4].Value.ToString()); //  Sinoliki Timh
                    item.Add(item_mtrl);
                    

                    items.Add(item);
                }


                try
                {
                    order.InsSalDocToS1(orderDate ,Convert.ToInt32(settings.orderSeries), WebCode,
                       customer_Trdr, items, shippingPrice, Convert.ToInt32(settings.EXPN)
                        );
                    //MessageBox.Show(e.ColumnIndex + " " + e.RowIndex); // Εισαγωγή

                }
                catch (Exception ex)
                {
                    MessageBox.Show( ex.Message );
                    return;
                }

                OrderDataGridView.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightGreen;
                MessageBox.Show("Η παραγγελία καταχωρήθηκε στο softone επιτυχώς.");


            }
            else
            {
            //    OrderDataGridView.SelectedRows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                this.getOrder(OrderDataGridView.Rows[e.RowIndex].Cells[1].Value.ToString() );
              //  MessageBox.Show(e.RowIndex + " " + e.ColumnIndex); 
              //  MessageBox.Show( OrderDataGridView.Rows[e.RowIndex].Cells[1].Value.ToString()   ); // Φόρτοση προιόντων
            }




         
        }

        private void FromDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            this.getOrders();
        }

        public void getOrder(String oId)
        {
            string[] row;

            this.orderHttp = new Io.HttpWeb.OrderHttp();
            JArray jResponce =  this.orderHttp.getOrder(oId);

            this.ProductDataGridView.Rows.Clear();
            for (int i = 0; i < jResponce.Count; i++)
            {
                row = new string[] { jResponce[i]["model"].ToString(), jResponce[i]["name"].ToString(), jResponce[i]["quantity"].ToString(), jResponce[i]["price"].ToString(), jResponce[i]["total"].ToString() };
                ProductDataGridView.Rows.Add(row);
              //  MessageBox.Show(jResponce.ToString());
            }

       //    MessageBox.Show(jResponce.ToString());

        }


        public void getOrders()
        {
            string[] row ;

          //  MessageBox.Show(Model.S1Init.myXSupport.ConnectionInfo.CompanyId.ToString());

            this.orderHttp = new Io.HttpWeb.OrderHttp();
            JArray jResponce = this.orderHttp.getOrdersByDate(
                this.FromDateTimePicker.Value.Date.ToString("yyyy-MM-dd"),
                this.ToDateTimePicker.Value.Date.ToString("yyyy-MM-dd")
                );
            OrderDataGridView.Rows.Clear();

            if(jResponce != null)
            for (int i = 0; i < jResponce.Count; i++)
                {
                    row = new string[] { jResponce[i]["date_added"].ToString(), jResponce[i]["order_id"].ToString(), jResponce[i]["softone_code"].ToString(), jResponce[i]["customer"].ToString(), jResponce[i]["shipping"].ToString(), jResponce[i]["total"].ToString(), "Προβολή", "Εισαγωγή" };
                  //  row.DefaultCellStyle.BackColor = Color.Red;
                    OrderDataGridView.Rows.Add(row);
                   // OrderDataGridView.Rows[i].DefaultCellStyle.BackColor = Color.Aqua;
                } 


        }

        private void ToDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            this.getOrders();
        }

        private void WebLoginButton_Click(object sender, EventArgs e)
        {
            ExternalBrowser externalBrowser = new ExternalBrowser();
            Settings settings = Settings.getInstance();

            externalBrowser.adminOpen(settings.domain + settings.AdminPath + "/index.php?route=sale/order");
        }

        private void InsertButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < OrderDataGridView.Rows.Count; i++)
            {
                this.insertOrder(i);
            }
            MessageBox.Show("Η Διαδικασία ολοκληρώθηκε.");
        }


        private void insertOrder(int i)
        {
               ArrayList items = new ArrayList();
                ArrayList item;
                String FINCODE = "";

                this.getOrder(OrderDataGridView.Rows[i].Cells[1].Value.ToString());

                Settings settings =  Settings.getInstance();
                Model.Order order = new Model.Order();
                int customer_Trdr = -1;
                double shippingPrice = 0;


                String customerCode = OrderDataGridView.Rows[i].Cells[2].Value.ToString();
                String WebCode = OrderDataGridView.Rows[i].Cells[1].Value.ToString();

                DateTime orderDate = DateTime.ParseExact(
                            OrderDataGridView.Rows[i].Cells[0].Value.ToString(),
                            settings.WebDateFormat,
                            System.Globalization.CultureInfo.InvariantCulture);

                if (customerCode == "")
                {
                    OrderDataGridView.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                  //  MessageBox.Show("Ο πελάτης " + OrderDataGridView.Rows[i].Cells[3].Value.ToString() + " του Site, δεν έχει συνδεθεί με πελάτη του softone", "Λάθος αντιστοίχισης");
                    return;
                }

                customer_Trdr = order.CustomerCodeToTrdr(customerCode);
                if (customer_Trdr < 0)
                    {
                        OrderDataGridView.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                       // MessageBox.Show("Ο κωδικός πελάτη " + OrderDataGridView.Rows[i].Cells[2].Value.ToString() + " του Site, δεν υπάρχει στο softone", "Λάθος αντιστοίχισης");
                    return;
                    }


                if (!settings.OrderWebRel.Equals(""))
                {
                    FINCODE = order.FindoCExist(WebCode);
                    if (!FINCODE.Equals("-1"))
                    {
                       // MessageBox.Show("Η παραγγελία web υπάρχει ήδη, με κωδικό " + FINCODE + "");
                        OrderDataGridView.Rows[i].DefaultCellStyle.BackColor = Color.Gray;
                        return;
                    }
                }

                shippingPrice = Convert.ToDouble(OrderDataGridView.Rows[i].Cells[4].Value.ToString().Replace(".", ","));
               
                this.getOrder(OrderDataGridView.Rows[i].Cells[1].Value.ToString());

                foreach (DataGridViewRow row in ProductDataGridView.Rows)
                {
                    String itemCode = row.Cells[0].Value.ToString();
                    int item_mtrl;
                   

                    if (itemCode == "")
                    {
                        OrderDataGridView.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                        row.DefaultCellStyle.BackColor = Color.Red;
                       // MessageBox.Show("To Προϊόν " + row.Cells[1].Value.ToString() + " του Site, δεν έχει συνδεθεί με προιόν του softone", "Λάθος αντιστοίχισης");
                        return;
                    }

                    item_mtrl = order.ItemCodeToMtrl(itemCode);
                    if (item_mtrl < 0)
                    {
                        OrderDataGridView.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                        row.DefaultCellStyle.BackColor = Color.Red;
                      //  MessageBox.Show("O Κωδικός Προϊόντος " + row.Cells[0].Value.ToString() + " του Site, δεν υπάρχει στο softone", "Λάθος αντιστοίχισης");
                        return;
                    }


                    item = new ArrayList();
                    item.Add(row.Cells[0].Value.ToString()); //  Kvdikos 
                    item.Add(row.Cells[1].Value.ToString()); //  Perigrafh
                    item.Add(row.Cells[2].Value.ToString()); //  Posothta
                    item.Add(row.Cells[3].Value.ToString()); //  Timh Monadas
                    item.Add(row.Cells[4].Value.ToString()); //  Sinoliki Timh
                    item.Add(item_mtrl);
                    

                    items.Add(item);
                }


                try
                {
                    order.InsSalDocToS1(orderDate , Convert.ToInt32(settings.orderSeries), WebCode,
                       customer_Trdr, items, shippingPrice, Convert.ToInt32(settings.EXPN)
                        );
                    //MessageBox.Show(e.ColumnIndex + " " + e.RowIndex); // Εισαγωγή
                }
                catch (Exception ex)
                {
                    MessageBox.Show( ex.Message );
                    return;
                }

                OrderDataGridView.Rows[i].DefaultCellStyle.BackColor = Color.LightGreen;
               // MessageBox.Show("Η παραγγελία καταχωρήθηκε στο softone επιτυχώς.");
            
        
        }



    }
}
