using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using S1Custom.Model;
using Softone;

namespace ClassLibrary4.MDL
{
    class CDIM
    {

        public CDIM(int CDIM, String CODE, String NAME) 
        {
            this.CDIMID = CDIM;
            this.CODE = CODE;
            this.NAME = NAME;
            CDIMLINES = new Dictionary<int, CDIMLINE>();
          String slq =  " SELECT * " +
          "  FROM CDIMLINES A  " +
          "  WHERE A.COMPANY= " + S1Init.myXSupport.ConnectionInfo.CompanyId.ToString() +
          "  AND A.CDIM=" + this.CDIMID.ToString();

            XTable RESULTS = S1Init.myXSupport.GetSQLDataSet(slq);

            for (int i = 0; i < RESULTS.Count; i++)
            {
                CDIMLINE cdimLine = new CDIMLINE(
                    Convert.ToInt32(RESULTS[i, "CDIMLINES"].ToString()),
                    RESULTS[i, "CODE"].ToString(),
                    RESULTS[i, "NAME"].ToString()
                    );

                this.CDIMLINES.Add(Convert.ToInt32(RESULTS[i, "CDIMLINES"].ToString()), cdimLine);
            }

        }

      int CDIMID;
      String CODE;
      String NAME; 
      public Dictionary<int,CDIMLINE> CDIMLINES;
    }
}
