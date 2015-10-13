<?xml version="1.0" encoding="ISO-8859-1"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:output method = "html" indent = "yes"/>

  <xsl:template match = "/">  
    <xsl:for-each select = "//SurveyResult/Question">

      <xsl:variable name = "type" select = "@type"/>
      <xsl:if test = "$type = 'mcss'">

        <xsl:variable name = "qid" select = "@id"/>      

        <p><b><xsl:value-of select = "//SurveyResult/Question[@id = $qid]/Statement"/></b></p>

        <xsl:variable name = "null" />
        <xsl:variable name = "total" select = "count(//SurveyResult/Answer[text() != $null and @questionId = $qid])"/>

        <div style = "margin-left: 15px;">  
          <xsl:for-each select = "//SurveyResult/Question[@id = $qid]/Responses/Response">
            <xsl:variable name = "res" select = "."/>
            <xsl:variable name = "sum" select = "count(//SurveyResult/Answer[text() = $res and @questionId = $qid])"/>
            <xsl:variable name = "per" select = "$sum div $total * 100"/>
            <xsl:variable name = "len" select = "round($per * 4)"/>

            <xsl:value-of select = "$res"/>: <xsl:value-of select = "(round($per * 100)) div 100"/>%
            <div><xsl:attribute name = "style">vertical-align: middle; margin-bottom: 15px; border: solid 1px; border-color: #99ccff #99ccff #336699 #336699; background-color: #6699cc; width: <xsl:value-of select = "$len"/>px;</xsl:attribute> </div>
          </xsl:for-each>    
        </div>

        <b>Total Votes: </b><xsl:value-of select = "$total"/>
        <hr/>

      </xsl:if>
    </xsl:for-each>
    
  </xsl:template>  
</xsl:stylesheet>
