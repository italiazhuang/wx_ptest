<%@ Register TagPrefix = "sstchur" Namespace = "sstchur.web.survey" Assembly = "sstchur.web.survey" %>
<%@ Page Language = "C#" %>
 <script runat = "server">
   
private void Page_PreRender(object sender, EventArgs e)
{
    if (Page.IsPostBack)
    {
        // This code assumes our WebSurvey control was assigned an id = "ws"
        if (!ws.PreviouslyCompleted)
            pnlSurvey.Visible = true;
        else
            pnlThankYou.Visible = true;

    }
    else
    {
        

        if (ws.PreviouslyCompleted)
            pnlSurvey.Visible = true;
        else
            pnlThankYou.Visible = true;


    }
}

protected void ws_Init(object sender, EventArgs e)
{

}
</script>

<html>
  <body>
    <asp:Panel id = "pnlSurvey" Visible = "false" runat = "server">
      <form id="Form1" runat = "server">
        <sstchur:WebSurvey id = "ws"
                              SurveyFile = "survey.xml"
                              AnswersFile = "answers.xml"
                              runat = "server" oninit="ws_Init"/>
      </form>
    </asp:Panel>

    <asp:Panel id = "pnlThankYou" Visible = "false" runat = "server">
      <p>Thank you for taking our survey!</p>
    </asp:Panel>
  </body>
</html>