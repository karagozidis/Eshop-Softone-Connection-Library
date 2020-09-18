using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Timers;
using System.Windows.Forms;
using ClassLibrary4;
using ClassLibrary4.CONTROL;
using Softone;

namespace S1Custom.Model
{
    class S1Init : TXCode
    {
        private static System.Timers.Timer myTimer;
        private static bool FirstTime = true;
        public static XSupport myXSupport;

        public override void Initialize()
        {
            base.Initialize();
            myXSupport = this.XSupport;

            Settings settings = Settings.getInstance();
            
          //  OnTimerElapsed(null, null); //Run first time
            if (settings.timerInterval > 0)
            {
                myTimer = new System.Timers.Timer(); // (settings.timerInterval * 60000);
                myTimer.Elapsed += new ElapsedEventHandler(OnTimerElapsed);

                myTimer.Interval = 10 * 60000; //Πρώτη φορά εκτέλεση στα 10 Λεπτά // settings.timerInterval * 60000;
                myTimer.Enabled = true;
            }
           
        }

        private static void OnTimerElapsed(object source, EventArgs e)
        {
          //  GlobalFunctions.updateQTYS();
            try
            {
              //  GlobalFunctions.updateQTYsByMtrlsOnTransactions();
              //  GlobalFunctions.updateCharQTYSByMtrlsOnTransactions("");

                SyncExecuter.ExecuteBricks();
            }
            catch
            { }

            if (FirstTime)
            {
                FirstTime = false;
                Settings settings = Settings.getInstance();
                myTimer.Interval = settings.timerInterval * 60000;
            }
        }



    }
}
