using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Softone;

namespace S1Custom
{
    public partial class DLLForm : Form
    {
        public DLLForm()
        {
            InitializeComponent();
        }

        XSupport XSupport;


        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.Show();

        }

        XTable table1;

        private void button2_Click(object sender, EventArgs e)
        {
            table1 = XSupport.GetSQLDataSet("SELECT CODE, NAME FROM TRDR");
            Grid1.VirtualMode = true;
            Grid1.RowCount = table1.Count;
        }

        private void Grid1_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            e.Value = table1[e.RowIndex, e.ColumnIndex + 1];
        }
    }
}