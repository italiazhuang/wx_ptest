<%@ Register TagPrefix = "sstchur" Namespace = "sstchur.web.survey" Assembly = "sstchur.web.survey" %>
<%@ Page Language = "C#" Debug = "true"%>
<script runat="server">
private void Page_PreRender(object sender, EventArgs e)
{
  // This code assumes our WebSurvey control was assigned an id = "ws"	
  if (!ws.PreviouslyCompleted)
    pnlSurvey.Visible = true;
  else
		pnlThankYou.Visible = true;    
}
</script>

<html>
  <head>
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
								<center>
									<h2>WebSurvey Demo</h2>
								</center>
	
    <asp:Panel id = "pnlSurvey" Visible = "false" runat = "server">
      <form runat = "server">
        <sstchur:WebSurvey id = "ws"
                              SurveyFile = "survey.xml"
                              AnswersFile = "answers.xml"
                              runat = "server" />
      </form>
    </asp:Panel>

    <asp:Panel id = "pnlThankYou" Visible = "false" runat = "server">
      <p>Thank you for taking our survey!</p>
    </asp:Panel>


              </td>
            </tr>
          </table>            
        </td>
      </tr>
    </table>
  </body>
</html>

