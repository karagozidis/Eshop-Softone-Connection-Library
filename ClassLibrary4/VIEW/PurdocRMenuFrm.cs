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
    public partial class PurdocRMenuFrm : Form
    {


        XSupport xs_;
        XModule xm_;

        string[] purdocs_;
        string purdocs_serialized;
        int purdocs_number_ = 0;

        public PurdocRMenuFrm(XSupport xs, XModule xm)
        {
            InitializeComponent();
            xs_ = xs;
            xm_ = xm;
        }

        public PurdocRMenuFrm()
        {
            InitializeComponent();
        }

        private void PurdocRMenuFrm_Load(object sender, EventArgs e)
        {
            purdocs_serialized = CTools.CToolsNewSDK.CustomToolsNewSDK.GetSelRecValuesFromRightClick(xm_);
            purdocs_ = purdocs_serialized.Split(',');

            foreach (string word in purdocs_)
            {
                purdocs_number_++;
            }
        }



    }
}
