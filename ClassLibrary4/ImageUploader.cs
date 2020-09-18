using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using S1Custom.Model;
using Softone;

namespace ClassLibrary4
{
    class ImageUploader
    {
        S1Custom.Io.HttpWeb.ItemHttp itemHttp = new S1Custom.Io.HttpWeb.ItemHttp();

        public void uploadItemImage(String MTRLsTR, String CODE)
        {

            XTable MTRL_IMAGE = S1Init.myXSupport.GetSQLDataSet(
            " SELECT SODATA " +
            " FROM XTRDOCDATA " +
            " WHERE REFOBJID= " + MTRLsTR +
            " AND SOSOURCE=51 " +
            " AND LNUM=0 "
            );

            if (MTRL_IMAGE.Count < 1) return;

            byte[] picData = MTRL_IMAGE[0, "SODATA"] as byte[] ?? null;


            if (picData != null)
            {

                using (Image image = Image.FromStream(new MemoryStream(picData)))
                {

                    if (ImageFormat.Jpeg.Equals(image.RawFormat))
                    {
                        image.Save(System.IO.Path.GetTempPath() + CODE + "-IMG.jpg", ImageFormat.Jpeg);

                        this.itemHttp.UpLoadImage(System.IO.Path.GetTempPath() + CODE + "-IMG.jpg", CODE + "-IMG.jpg");
                        this.itemHttp.SyncImage(CODE, CODE + "-IMG.jpg");
                    }
                    else if (ImageFormat.Png.Equals(image.RawFormat) || ImageFormat.Bmp.Equals(image.RawFormat))
                    {
                        image.Save(System.IO.Path.GetTempPath() + CODE + "-IMG.png", ImageFormat.Png);

                        this.itemHttp.UpLoadImage(System.IO.Path.GetTempPath() + CODE + "-IMG.png", CODE + "-IMG.png");
                        this.itemHttp.SyncImage(CODE, CODE + "-IMG.png");
                    }

                }

            }

        } 


    }
}
