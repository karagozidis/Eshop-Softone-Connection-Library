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
    public partial class SyncColorsForm : Form
    {
        public SyncColorsForm()
        {
            InitializeComponent();
        }

        private void SyncColorsForm_Load(object sender, EventArgs e)
        {


          String Sql = 
             " SELECT TOP 1 A.* " +
             " FROM CCCCONNECTIONBRICK A                   "+
             " WHERE A.COMPANY= " + S1Custom.Model.S1Init.myXSupport.ConnectionInfo.CompanyId.ToString() +
             " AND  A.CODE = 'GC'                          " +
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
                    DatagridValue.Add(tbl2[i, "HEX1"].ToString());
                    DatagridValue.Add(tbl2[i, "GENNAME"].ToString());

                    string[] DatagridRow = DatagridValue.ToArray();
                    this.DGV1.Rows.Add(DatagridRow);
                }


            //    List<String> DatagridValue = new List<string>();
            //    DatagridValue.Add(tbl[i, "SQLCOMMAND"].ToString());
            //    DatagridValue.Add(tbl[i, "CODE"].ToString());
            //    DatagridValue.Add(tbl[i, "NAME"].ToString());

            //    string[] DatagridRow = DatagridValue.ToArray();
            //    BricksDataGridView.Rows.Add(DatagridRow);
            }


        }

        private void DGV1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != System.Windows.Forms.MouseButtons.Right) { return; }

            int rowIndex = DGV1.HitTest(e.X, e.Y).RowIndex;
            int colIndex = DGV1.HitTest(e.X, e.Y).ColumnIndex;

            if (rowIndex >= 0 && colIndex == 2)
            {

                try
                {

                    try
                    {
                        Color color = Color.Green;
                        if (DGV1.Rows[rowIndex].Cells[colIndex].Value.ToString() != "") color = (Color)System.Drawing.ColorTranslator.FromHtml(DGV1.Rows[rowIndex].Cells[colIndex].Value.ToString());
                        colorDialog1.Color = color;
                    }
                    catch (Exception ex) { }

                    DialogResult result = colorDialog1.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        DGV1.Rows[rowIndex].Cells[colIndex].Value = "#" + ColorToHexString(colorDialog1.Color);
                    }



                }
                catch (Exception ex) { }

            }

        }


        #region -- Data Members --
        static char[] hexDigits = {
         '0', '1', '2', '3', '4', '5', '6', '7',
         '8', '9', 'A', 'B', 'C', 'D', 'E', 'F'};
        #endregion
        public static string ColorToHexString(Color color)
        {
            byte[] bytes = new byte[3];
            bytes[0] = color.R;
            bytes[1] = color.G;
            bytes[2] = color.B;
            char[] chars = new char[bytes.Length * 2];
            for (int i = 0; i < bytes.Length; i++)
            {
                int b = bytes[i];
                chars[i * 2] = hexDigits[b >> 4];
                chars[i * 2 + 1] = hexDigits[b & 0xF];
            }
            return new string(chars);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            S1Custom.Model.S1Init.myXSupport.ExecuteSQL(" TRUNCATE TABLE GENCOLORS ");
            String InsertSql = "";

            foreach (DataGridViewRow dr in DGV1.Rows)
            {
                InsertSql += " INSERT INTO GENCOLORS(CODE,NAME,HEX,GENNAME) VALUES ('" + dr.Cells["CODE"].Value.ToString() + "','" + dr.Cells["NAME"].Value.ToString() + "','" + dr.Cells["ΗΕΧ"].Value.ToString() + "','" + dr.Cells["GENNAME"].Value.ToString() + "'); ";
            }

            S1Custom.Model.S1Init.myXSupport.ExecuteSQL(InsertSql);
        }



    }
}
