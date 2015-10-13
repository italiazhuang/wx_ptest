using System;
using System.IO;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplicationXX
{
    public partial class uploadx : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //      Request.SaveAs(Server.MapPath("/foo/" + "1" + ".wav"), false);


            string audioData = HttpContext.Current.Request.Form["data"];

            if (audioData == null)
                return;



            string fileName = HttpUtility.UrlDecode(HttpContext.Current.Request.Form["fname"]);

            audioData = audioData.Substring(audioData.IndexOf(',') + 1);

            string Manme =Server.MapPath("~/" + fileName) ;// \mp3TOAMR


            System.IO.FileStream stream = new FileStream(Server.MapPath("~/" + fileName), FileMode.CreateNew);

            System.IO.BinaryWriter writer = new BinaryWriter(stream);

            writer.Write(Convert.FromBase64String(audioData), 0, Convert.FromBase64String(audioData).Length);

            writer.Close();

            /*
            string AAAA = System.IO.Path.Combine(Server.MapPath("~/"), "mp3TOAMR/ffmpeg.exe");


            string DIRX = System.IO.Path.Combine(Server.MapPath("~/"), "MP3");
            if (System.IO.Directory.Exists(DIRX) == false)
            {
                System.IO.Directory.CreateDirectory(DIRX);
            }

            string NAME = DateTime.Now.Year.ToString("D4") + DateTime.Now.Month.ToString("D2") + DateTime.Now.Day.ToString("D2") + DateTime.Now.Hour.ToString("D2") + DateTime.Now.Minute.ToString("D2") + DateTime.Now.Second.ToString("D2") + DateTime.Now.Millisecond.ToString("D4");

            string AmrName = System.IO.Path.Combine(DIRX,NAME+".amr");
            string Mp3Name = System.IO.Path.Combine(DIRX,NAME +".mp3");

            string SpxName = System.IO.Path.Combine(DIRX, NAME + ".spx");
            string WavName = System.IO.Path.Combine(DIRX, NAME + ".wav");


            string WavName2 = System.IO.Path.Combine(DIRX, NAME + "2.wav");


            //mp3 to amr
            //ffmpeg -i 1.mp3 -ac 1 -ar 8000 1.amr
            string CMD1 = "-i " + Manme + " -ac 1 -ar 8000 " + AmrName;
            var proc1 = System.Diagnostics.Process.Start(AAAA , CMD1);//( 
             proc1.WaitForExit();


             //转换amr到mp3：
             //ffmpeg -i shenhuxi.amr amr2mp3.mp3
             string CMD2 = " -i " + AmrName + " " + Mp3Name;
             var proc2 = System.Diagnostics.Process.Start(AAAA, CMD2);
             proc2.WaitForExit();


            // Mp3 - Wav
             //ffmpeg -i DING.mp3 -f wav test.wav
             string CMD3 = " -i " + Mp3Name + " -f wav " + WavName;
             var proc3 = System.Diagnostics.Process.Start(AAAA, CMD3); 
             proc3.WaitForExit();


            //Wav  spx
             string CMD4 = " -i " + WavName + " " + SpxName;
             var proc4 = System.Diagnostics.Process.Start(AAAA, CMD4); 
             proc4.WaitForExit();
 

            // spx  wav
             string CMD5 = " -i " + SpxName + " -f wav " + WavName2;
             var proc5 = System.Diagnostics.Process.Start(AAAA, CMD5); 
             proc5.WaitForExit();
 */
           

        }
    }
}