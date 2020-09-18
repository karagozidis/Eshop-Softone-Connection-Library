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
    public partial class Form2 : Form
    {
        public XTable t;

        public Form2()
        {
            InitializeComponent();
            alist = new List<object>();
        }
        int k;
        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            k++;
        }

        List<object> alist;

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 1000000; i++)
                alist.Add(i + 1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            alist.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

      private void button4_Click(object sender, EventArgs e)
      {
        
        MessageBox.Show((string)t[0, "CODE"]);
       // MessageBox.Show("Εντάξει!");
      }
    }
}