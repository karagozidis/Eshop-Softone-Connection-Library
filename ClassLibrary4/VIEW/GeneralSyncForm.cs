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
    public partial class GeneralSyncForm : Form
    {

        XSupport XSupport;
        DataTable connectionBricks;

        public GeneralSyncForm()
        {
            InitializeComponent();
        }
       
        private void GeneralSyncForm_Load(object sender, EventArgs e)
        {


            String Sql = " SELECT A.* " +
                   " FROM CCCCONNECTIONBRICK A WHERE A.COMPANY=  " + XSupport.ConnectionInfo.CompanyId.ToString() +
                   " AND A.ONGENERALSYNC > 0 " +
                 //  " AND  A.BRICKOBJECT = 'ITEM'                                       " +
                   " AND ACTIVE = 1                                                    " +
                   " ORDER BY A.EXECUTIONORDER                                     ";

            XTable tbl = XSupport.GetSQLDataSet(Sql);
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
                 "",
                 ResultsTextBox
                 ); 
        }
    }
}
