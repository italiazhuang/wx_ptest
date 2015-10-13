<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<%@ Register TagPrefix = "sstchur" Namespace = "sstchur.web.survey" Assembly = "sstchur.web.survey" %>
<%@ Page Language = "C#" %>

<html>
	<head>
		<title>Steve's WebSurvey Control | Live Demos | Example Survey</title>
		
		<link rel = "stylesheet" type = "text/css" href = "./css/pageattribs.css" />		
		<link rel = "stylesheet" type = "text/css" href = "./css/websurvey.css" />

    <script runat = "server">
    
		public void Page_Init(Object sender, EventArgs e)
		{
			// programatically set the .SurveyFile and/or .AnswersFile here (if desired)
			//ws.SurveyFile = "colors.xml";
			//ws.AnswersFile = "colors_answers.xml";
		}
		
		public void Page_PreRender(Object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (ws.PreviouslyCompleted)
					pnlSurveyPreviouslyCompleted.Visible = true;
				else
					pnlSurvey.Visible = true;
			}
		}
    </script>
		
	</head>
	
	<body>	

		<div id = "page-content">

				<p><b>Also check out the <a href = "colors.aspx">Colors Poll</a></b></p>
				
				<asp:Panel id = "pnlSurveyPreviouslyCompleted" Visible = "false" runat = "server">
					<p><b>Survey Completed Successfully</b></p>
					
					Thank you for completing the sample survey.  If you decide to use this control on your web site, I would love to
					see it in action.  Please send me a quick email: <a href = "mailto:sstchur@yahoo.com">sstchur@yahoo.com</a>.</p>
					
					<p>You may also email me if you have comments, questions, suggestions, or enhancement requests.</p>
					
					<p>If you'd like to view the demo survey again, simply clear you browser cookies and refresh this page.</p>
					
					<p>WebSurvey Control Author,<br />
					Stephen Stchur</p>					
				</asp:Panel>        
				
				<asp:Panel id = "pnlSurvey" Visible = "false" runat = "server">
					<br/>
					<h3>Example Survey</h3>
					
					<p>This is a very simple, example survey using the WebSurvey Control.  If you click "Finish" without first
					answering the survey, you'll notice that it won't let you continue because certain fields are required.</p>
					
					<p>Also, if you complete this survey, and then try to take it agian, you'll simply see a message saying
					"Thank you for raking our survey" becuase I've set this survey up to disallow repeats.  The control makes
					use of a simple cookie, so you could get around this easily by just clearing your cookies.</p>     
					
					<form runat = "server">
						<sstchur:WebSurvey id = "ws" SurveyFile = "survey.xml" AnswersFile = "answers.xml" runat = "server" />
					</form>
				</asp:Panel>
		</div>
			
	</body>
</html>