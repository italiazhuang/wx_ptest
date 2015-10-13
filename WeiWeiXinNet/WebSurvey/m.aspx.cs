using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WeiWeiXinNet.WebSurvey
{
    public partial class m : System.Web.UI.Page
    {
        
        public string IM ="微数据";

    



        /// <summary>
        /// 用户 OPENID
        /// </summary>
        public string RID = "";

     


        public void Page_Load(object server, EventArgs e)
        {

            if (ws.PreviouslyCompleted)
            {
                pnlPreviouslyCompleted.Visible = true;
                pnlSurvey.Visible = false;
            }
            else
            {
                pnlSurvey.Visible = true;
                pnlPreviouslyCompleted.Visible = false;
            }

            ws.SurveyFile = HiddenField1.Value;   // survey_xml;//"survey.xml";//
            ws.AnswersFile = HiddenField2.Value;//"answers.xml";// 


            if (Page.IsPostBack)
            {
                return;
            }

                /// <summary>
        /// 
        /// </summary>
         string  survey_xml="";//"survey.xml";

        /// <summary>
        /// 数据记录文件
        /// </summary>
          string answers_xml ="";// "answers.xml";


            string table1 = Request.QueryString["t"];
           
            string answersPath = "";

            if (table1 != null)
            {
                string table2 = "";
                table2 = table1.ToLower().Replace("table\\table1\\", "table\\talbe2\\").Replace("table/table1/", "table/table2/");

                table2 = table1.ToLower().Replace("\\table\\table1", "\\table\\talbe2").Replace("/table/table1", "/table/table2");

                table2 = table2.Remove(table2.LastIndexOf("."));

                string AB = Server.MapPath("~");

                table2 = System.IO.Path.Combine(AB, table2.Replace("/", "\\").Replace("\\user_dir\\","user_dir\\"));
                table1 = System.IO.Path.Combine(AB, table1.Replace("/", "\\").Replace("\\user_dir\\", "user_dir\\"));

                if (System.IO.Directory.Exists(table2) == false)
                {
                    System.IO.Directory.CreateDirectory(table2);
                }

                //得到表单
                survey_xml =  table1;

                //读取 
                HttpCookie cookie2 = Request.Cookies["weiweixing08"];

                if (cookie2 == null)
                {

                }
                else
                {
                    string UserIDTime = cookie2.Values["UserIDTime"];
                    if (UserIDTime == null)
                    {

                    }
                    else
                    {
                        //正确读取

                        RID = ClassLibraryWeiBao.ClassTimeEncryptionAlgorithm.GetID(Server.MapPath("~"), UserIDTime);

                        if (RID == "")
                        {
                         //   Response.Redirect("help.aspx");
                            RID = "NONAME";
                        }
                    }
                }

                answersPath = System.IO.Path.Combine(table2, RID + ".dll");

            }
            else
            {

            }



            
       

            survey_xml = survey_xml.Replace("/","\\");
            answersPath = answersPath.Replace("/", "\\");

            ws.SurveyFile =  survey_xml;//"survey.xml";//

            ws.AnswersFile =  answersPath;//"answers.xml";// 

         HiddenField1.Value  =  ws.SurveyFile ;   // survey_xml;//"survey.xml";//
         HiddenField2.Value  =   ws.AnswersFile;//"answers.xml";// 


        }



    }
}