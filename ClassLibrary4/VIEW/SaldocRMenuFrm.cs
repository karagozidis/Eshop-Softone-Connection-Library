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
    public partial class SaldocRMenuFrm : Form
    {
        XSupport xs_;
        XModule xm_;

        string[] saldocs_;
        string saldocs_serialized;
        int saldocs_number_ = 0;

        public SaldocRMenuFrm(XSupport xs, XModule xm)
        {
            InitializeComponent();
            xs_ = xs;
            xm_ = xm;
        }

        public SaldocRMenuFrm()
        {
            InitializeComponent();
        }



        private void SaldocRMenuFrm_Load(object sender, EventArgs e)
        {
            saldocs_serialized = CTools.CToolsNewSDK.CustomToolsNewSDK.GetSelRecValuesFromRightClick(xm_);
            saldocs_ = saldocs_serialized.Split(',');

            foreach (string word in saldocs_)
            {
                saldocs_number_++;
            }
        }


    }
}
