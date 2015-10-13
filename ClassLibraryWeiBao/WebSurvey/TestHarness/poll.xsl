<?xml version="1.0" encoding="ISO-8859-1"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:output method = "html" indent = "yes"/>

  <xsl:template match = "/">
  
    <p><b><xsl:value-of select = "//SurveyResult/Question/Statement"/></b></p>
    
    <xsl:variable name = "total" select = "count(//SurveyResult/Answer)"/>
    
    <div style = "margin-left: 10px;">      
      <xsl:for-each select = "//SurveyResult/Question/Responses/Response">
      
        <xsl:variable name = "res" select = "."/>      
        <xsl:variable name = "sum" select = "count(//SurveyResult/Answer[text() = $res])"/>
        <xsl:variable name = "per" select = "$sum div $total * 100"/>
        <xsl:variable name = "len" select = "round($per * 2)"/>
      
        <xsl:value-of select = "$res"/>: <xsl:value-of select = "round($per * 10) div 10"/>%
        <div><xsl:attribute name = "style">vertical-align: middle; margin-bottom: 15px; border: solid 1px; border-color: #99ccff #99ccff #336699 #336699; background-color: #6699cc; width: <xsl:value-of select = "$len"/>px;</xsl:attribute>&#160;</div>
        
      </xsl:for-each>      
    </div>
    
    <p><b>Total votes: </b> <xsl:value-of select = "$total"/></p>
        
  </xsl:template>
	
</xsl:stylesheet>