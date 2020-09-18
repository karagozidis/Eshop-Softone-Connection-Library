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
    public partial class ItemRMenuFrm : Form
    {
     
        XSupport xs_;
        XModule xm_;

        string[] items_;
        string items_serialized;
        int items_number_ = 0;
        DataTable connectionBricks;

        public ItemRMenuFrm(XSupport xs, XModule xm)
        {
            InitializeComponent();
            xs_ = xs;
            xm_ = xm;
        }

        public ItemRMenuFrm()
        {
            InitializeComponent();
        }



        private void ItemRMenuFrm_Load(object sender, EventArgs e)
        {
            items_serialized = CTools.CToolsNewSDK.CustomToolsNewSDK.GetSelRecValuesFromRightClick(xm_);
            items_serialized = items_serialized.Replace("?", ",");
            items_ = items_serialized.Split(',');

            foreach (string word in items_)
            {
                items_number_++;
            }


            String Sql = " SELECT A.* " +
                   " FROM CCCCONNECTIONBRICK A WHERE A.COMPANY=  " + xs_.ConnectionInfo.CompanyId.ToString() +
                   " AND A.RUNONMENU > 0 " +
                   " AND  A.BRICKOBJECT = 'ITEM'                                       " +
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
           String SelectedCCCCONNECTIONBRICK =  this.BricksDataGridView.Rows[BricksDataGridView.CurrentCell.RowIndex].Cells["CCCCONNECTIONBRICK"].Value.ToString();
           
            SyncExecuter.ExecuteBrick(
                 SelectedCCCCONNECTIONBRICK,
                 items_serialized,
                 ResultsTextBox
                 ); 

            /*
            DataRow[] foundRows;

            foundRows = connectionBricks.Select("CCCCONNECTIONBRICK = " + SelectedCCCCONNECTIONBRICK);

            for (int i = 0; i < foundRows.Length; i++)
            {

               SyncExecuter.ExecuteBrick(
                    foundRows[i]["SQLCOMMAND"].ToString().Replace("##id##", items_serialized),
                    foundRows[i]["WEBURL"].ToString(), 
                    foundRows[i]["ROWSONURL"].ToString(), 
                    foundRows[i]["WEBPARAMFORMAT"].ToString(),
                    ResultsTextBox
                    );

            }   
            */

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if(this.RPanel.Visible) this.RPanel.Visible = false;
            else this.RPanel.Visible = true;
           
        }


    }
}
