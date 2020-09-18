using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary4.MDL
{
    class CDIMLINE
    {
        public CDIMLINE(int CDIMLINEID, String CODE, String NAME)
        {
            this.CDIMLINEID = CDIMLINEID;
            this.CODE = CODE;
            this.NAME = NAME;
        }

         public int CDIMLINEID;
         public String CODE;
         public String NAME;

    }
}
