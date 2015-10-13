<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<%@ Register TagPrefix = "sstchur" Namespace = "sstchur.web.survey" Assembly = "sstchur.web.survey" %>
<%@ Page Language = "C#" validateRequest = "false" %>

<html>
	<head>
		<title>Steve's WebSurvey Control | Live Demos | Colors Poll</title>
		
		<link rel = "stylesheet" type = "text/css" href = "./css/pageattribs.css" />
		<link rel = "stylesheet" type = "text/css" href = "./css/websurvey.css" />
		
		<script runat = "server">
	    
			public void Page_Init(Object sender, EventArgs e)
			{
				// programatically set the .SurveyFile and/or .AnswersFile of the SurveyResult here (if desired)
				//results.SurveyFile = "colors.xml";
				//results.AnswersFile = "colors_answers.xml";
			}
			
		</script>		
		
	</head>
	
	<body>	
		<div id = "page-content">

			<form runat = "server">
				<sstchur:WebSurvey id = "poll" SurveyFile = "colors.xml" AnswersFile = "colors_answers.xml" runat = "server" />
			</form>
			
			<h3>Results:</h3>
			<sstchur:SurveyResult
				id = "results"                                    
				SurveyFile = "colors.xml"
				AnswersFile = "colors_answers.xml"
				Stylesheet = "poll.xsl"
				XQuery1 = "//WebSurvey/Group/Question"
				XQuery2 = "//Answers/AnswerSet/Answer"
				runat = "server" />

		</div>
	</body>
</html>