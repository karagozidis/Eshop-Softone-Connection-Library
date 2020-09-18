using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Softone;

namespace ClassLibrary4.VIEW
{
    public partial class SyncSizesForm : Form
    {
        public SyncSizesForm()
        {
            InitializeComponent();
        }

        private void SyncSizesForm_Load(object sender, EventArgs e)
        {
            String Sql =
               " SELECT TOP 1 A.* " +
               " FROM CCCCONNECTIONBRICK A                   " +
               " WHERE A.COMPANY= " + S1Custom.Model.S1Init.myXSupport.ConnectionInfo.CompanyId.ToString() +
               " AND  A.CODE = 'GS'                          " +
               " AND ACTIVE = 1                              " +
               " ORDER BY A.EXECUTIONORDER                   ";

            XTable tbl = S1Custom.Model.S1Init.myXSupport.GetSQLDataSet(Sql);


            if (tbl.Count == 1)
            {

                String Sql2 = tbl[0, "SQLCOMMAND"].ToString();
                XTable tbl2 = S1Custom.Model.S1Init.myXSupport.GetSQLDataSet(Sql2);
                for (int i = 0; i < tbl2.Count; i++)
                {
                    List<String> DatagridValue = new List<string>();
                    DatagridValue.Add(tbl2[i, "CODE"].ToString());
                    DatagridValue.Add(tbl2[i, "NAME"].ToString()); 
                    DatagridValue.Add(tbl2[i, "GENNAME"].ToString());

                    string[] DatagridRow = DatagridValue.ToArray();
                    this.DGV1.Rows.Add(DatagridRow);
                }

            }


        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            S1Custom.Model.S1Init.myXSupport.ExecuteSQL(" TRUNCATE TABLE GENSIZES ");
            String InsertSql = "";

            foreach (DataGridViewRow dr in DGV1.Rows)
            {
                InsertSql += " INSERT INTO GENSIZES(CODE,NAME,GENNAME) VALUES ('" + dr.Cells["CODE"].Value.ToString() + "','" + dr.Cells["NAME"].Value.ToString()  + "','" + dr.Cells["GENNAME"].Value.ToString() + "'); ";
            }

            S1Custom.Model.S1Init.myXSupport.ExecuteSQL(InsertSql);
        }
    }
}
