using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary4.CONTROL;
using Softone;

namespace ClassLibrary4.VIEW
{
    public partial class CustomerRMenuFrm : Form
    {
        XSupport xs_;
        XModule xm_;

        string[] customers_;
        string customers_serialized;
        int customers_number_ = 0;

        DataTable connectionBricks;

        public CustomerRMenuFrm(XSupport xs, XModule xm)
        {
            InitializeComponent();
            xs_ = xs;
            xm_ = xm;
        }

        public CustomerRMenuFrm()
        {
            InitializeComponent();
        }


        private void CustomerRMenuFrm_Load(object sender, EventArgs e)
        {
            customers_serialized = CTools.CToolsNewSDK.CustomToolsNewSDK.GetSelRecValuesFromRightClick(xm_);
            customers_ = customers_serialized.Split(',');

            foreach (string word in customers_)
            {
                customers_number_++;
            }

            String Sql = " SELECT A.* " +
                   " FROM CCCCONNECTIONBRICK A WHERE A.COMPANY=  " + xs_.ConnectionInfo.CompanyId.ToString() +
                   " AND A.RUNONMENU > 0 " +
                   " AND  A.BRICKOBJECT = 'CUSTOMER'                                   " +
                   " AND ACTIVE = 1                                                    " +
                   " ORDER BY A.EXECUTIONORDER                                     ";

            XTable tbl = xs_.GetSQLDataSet(Sql);
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

        private void BricksDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            String SelectedCCCCONNECTIONBRICK = this.BricksDataGridView.Rows[BricksDataGridView.CurrentCell.RowIndex].Cells["CCCCONNECTIONBRICK"].Value.ToString();
           

            SyncExecuter.ExecuteBrick(
                    SelectedCCCCONNECTIONBRICK,
                    customers_serialized,
                    this.ResultsTextBox
                    );

        }

    }
}
