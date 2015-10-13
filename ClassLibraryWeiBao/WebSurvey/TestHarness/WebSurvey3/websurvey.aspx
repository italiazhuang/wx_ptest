<%@ Register TagPrefix = "sstchur" Namespace = "sstchur.web.survey" Assembly = "sstchur.web.survey" %>
<%@ Page Language = "C#" %>

<html>
  <head>
    <script runat = "server">
      public void Page_Load(object server, EventArgs e)
      {
        if (ws.PreviouslyCompleted) {
          pnlPreviouslyCompleted.Visible = true;
          pnlSurvey.Visible = false;
        } else {
          pnlSurvey.Visible = true;
          pnlPreviouslyCompleted.Visible = false;
        }
      }
    </script>
    
    <style type = "text/css">
      body, table, td
      {
        font-family: arial;
        font-size: 12px;
        color: #336699;
      }
    </style>
  </head>
  
  <body bgcolor = "#ffffff">
    
    <table border = 0 cellpadding = 0 cellspacing = 0 width = 100% height = 100%>
      <tr valign = "top" align = "center">
        <td width = 100% height = 100%>
  
          <table border = 0 cellpadding = 10 cellspacing = 0 width = 500 style = "border: solid 1px #000000;">
            <tr valign = "top" align = "left">
              <td>
                <br/>
                <p align = "center"><h3>WebSurvey Demo</h3></p>
          
                <asp:Panel id = "pnlSurvey" Visible = "false" runat = "server">
                  <form runat = "server">
                    <sstchur:WebSurvey id = "ws"
                                       SurveyFile = "survey.xml"
                                       AnswersFile = "answers.xml"
                                       runat = "server"/>
                  </form>                    
                </asp:Panel>
                
                <asp:Panel id = "pnlPreviouslyCompleted" Visible = "false" runat = "server">
                  Thank you for taking our survey.
                </asp:Panel>
              </td>
            </tr>
          </table>
            
        </td>
      </tr>
    </table>
  </body>
</html>