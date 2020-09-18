using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using S1Custom.Model;
using Softone;

namespace ClassLibrary4.MDL
{
    static class CDIMS
    {
        public static Dictionary<int, CDIM> CDIMSDICT = null;

        public static void readCDIMS()
        {
            if (CDIMSDICT != null) return;
            CDIMSDICT = new Dictionary<int, CDIM>();
            String slq = "SELECT * FROM CDIM WHERE COMPANY=" + S1Init.myXSupport.ConnectionInfo.CompanyId.ToString() +
                " AND MTRL IS NULL ORDER BY CDIM,COMPANY";

            XTable RESULTS = S1Init.myXSupport.GetSQLDataSet(slq);

            for (int i = 0; i < RESULTS.Count; i++)
            {
                CDIM cdim = new CDIM(
                    Convert.ToInt32(RESULTS[i, "CDIM"].ToString()) ,
                    RESULTS[i, "CODE"].ToString(),
                    RESULTS[i, "NAME"].ToString()
                    );

                CDIMSDICT.Add(Convert.ToInt32(RESULTS[i, "CDIM"].ToString()), cdim); 

            }
        }
       
    }
}
