/* IVT
 * @Project : hisnguonmo
 * Copyright (C) 2017 INVENTEC
 *  
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *  
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
 * GNU General Public License for more details.
 *  
 * You should have received a copy of the GNU General Public License
 * along with this program. If not, see <http://www.gnu.org/licenses/>.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIS.Desktop.Plugins.ImportRegisterByXml.XML
{
    class XLSDefault
    {
        public static string xlsFormat = "<!--\r\n |\r\n | XSLT REC Compliant Version of IE5 Default Stylesheet\r\n |\r\n | Original version by Jonathan Marsh (jmarsh@xxxxxxxxxxxxx)\r\n | http://msdn.microsoft.com/xml/samples/defaultss/defaultss.xsl\r\n |\r\n | Conversion to XSLT 1.0 REC Syntax by Steve Muench (smuench@xxxxxxxxxx)\r\n |\r\n +-->\r\n<xsl:stylesheet version=\"1.0\" xmlns:xsl=\"http://www.w3.org/1999/XSL/Transform\">\r\n  <!-- Add doctype attributes to keep IE happy -->\r\n  <xsl:output indent=\"no\"\r\n                method=\"html\"\r\n                doctype-public=\"-//W3C//DTD XHTML 1.0 Transitional//EN\"\r\n                doctype-system=\"http://www.w3.org/tr/xhtml1/DTD/xhtml1-transitional.dtd\" />\r\n  <xsl:template match=\"/\">\r\n    <HTML>\r\n      <HEAD>\r\n        <SCRIPT>\r\n          <xsl:comment>\r\n            <![CDATA[\r\n                  function f(e){\r\n                     if (e.className==\"ci\") {\r\n                       if (e.children(0).innerText.indexOf(\"\\n\")>0) fix(e,\"cb\");\r\n                     }\r\n                     if (e.className==\"di\") {\r\n                       if (e.children(0).innerText.indexOf(\"\\n\")>0) fix(e,\"db\");\r\n                     } e.id=\"\";\r\n                  }\r\n                  function fix(e,cl){\r\n                    e.className=cl;\r\n                    e.style.display=\"block\";\r\n                    j=e.parentElement.children(0);\r\n                    j.className=\"c\";\r\n                    k=j.children(0);\r\n                    k.style.visibility=\"visible\";\r\n                    k.href=\"#\";\r\n                  }\r\n                  function ch(e) {\r\n                    mark=e.children(0).children(0);\r\n                    if (mark.innerText==\"+\") {\r\n                      mark.innerText=\"-\";\r\n                      for (var i=1;i<e.children.length;i++) {\r\n                        e.children(i).style.display=\"block\";\r\n                      }\r\n                    }\r\n                    else if (mark.innerText==\"-\") {\r\n                      mark.innerText=\"+\";\r\n                      for (var i=1;i<e.children.length;i++) {\r\n                        e.children(i).style.display=\"none\";\r\n                      }\r\n                    }\r\n                  }\r\n                  function ch2(e) {\r\n                    mark=e.children(0).children(0);\r\n                    contents=e.children(1);\r\n                    if (mark.innerText==\"+\") {\r\n                      mark.innerText=\"-\";\r\n                      if (contents.className==\"db\"||contents.className==\"cb\") {\r\n                        contents.style.display=\"block\";\r\n                      }\r\n                      else {\r\n                        contents.style.display=\"inline\";\r\n                      }\r\n                    }\r\n                    else if (mark.innerText==\"-\") {\r\n                      mark.innerText=\"+\";\r\n                      contents.style.display=\"none\";\r\n                    }\r\n                  }\r\n                  function cl() {\r\n                    e=window.event.srcElement;\r\n                    if (e.className!=\"c\") {\r\n                      e=e.parentElement;\r\n                      if (e.className!=\"c\") {\r\n                        return;\r\n                      }\r\n                    }\r\n                    e=e.parentElement;\r\n                    if (e.className==\"e\") {\r\n                      ch(e);\r\n                    }\r\n                    if (e.className==\"k\") {\r\n                      ch2(e);\r\n                    }\r\n                  }\r\n                  function ex(){}\r\n                  function h(){window.status=\" \";}\r\n\r\n                  document.onclick=cl;\r\n              ]]>\r\n          </xsl:comment>\r\n        </SCRIPT>\r\n        <STYLE>\r\n          BODY {font:small 'Verdana'; margin-right:1.5em; margin-top: 44px;}\r\n          .c  {cursor:hand}\r\n          .b  {color:red; font-family:'Courier New'; font-weight:bold;\r\n          text-decoration:none}\r\n          .e  {margin-left:1em; text-indent:-1em; margin-right:1em}\r\n          .k  {margin-left:1em; text-indent:-1em; margin-right:1em}\r\n          .t  {color:#990000}\r\n          .xt {color:#990099}\r\n          .ns {color:red}\r\n          .dt {color:green}\r\n          .m  {color:blue}\r\n          .tx {font-weight:bold}\r\n          .db {text-indent:0px; margin-left:1em; margin-top:0px;\r\n          margin-bottom:0px;padding-left:.3em;\r\n          border-left:1px solid #CCCCCC; font:x-small Courier}\r\n          .di {font:x-small Courier}\r\n          .d  {color:blue}\r\n          .pi {color:blue}\r\n          .cb {text-indent:0px; margin-left:1em; margin-top:0px;\r\n          margin-bottom:0px;padding-left:.3em; font:x-small Courier;\r\n          color:#888888}\r\n          .ci {font:x-small Courier; color:#888888}\r\n          PRE {margin:0px; display:inline}\r\n\r\n          .label {padding-left:20px; vertical-align: middle}\r\n          .validation {color: white; padding: 3px; margin: 5px 5px 5px 5px; text-indent: 0}\r\n          .summary {position: fixed; top: 0; left: 0; margin: 0px; padding-top: 10px; width: 100%; height: 32px; font-size: 12pt; vertical-align: middle;border-bottom: 2px solid black}\r\n          .nav {float: right; padding-right:20px;}\r\n          .failure {background: red;}\r\n          .success {background: green;}\r\n          .warning {background: yellow; color: black}\r\n          .selected {font-weight: bold; text-indent: 1em}\r\n        </STYLE>\r\n      </HEAD>\r\n      <BODY class=\"st\">\r\n        <xsl:apply-templates/>\r\n      </BODY>\r\n    </HTML>\r\n  </xsl:template>\r\n\r\n  <!-- Render the schema summary\r\n         Include jquery from CDN and render a title bar across top -->\r\n  <xsl:template match=\"processing-instruction('schemaSummary')\">\r\n    <script src=\"http://code.jquery.com/jquery-1.9.1.min.js\"></script>\r\n    <div id=\"schemaSummary\" class=\"validation summary\">\r\n      <span class=\"label\">\r\n        <xsl:value-of select=\".\" />\r\n      </span>\r\n      <span class=\"nav\">\r\n        <button id=\"prev\">&lt;&lt;</button>\r\n        <button id=\"next\">>></button>\r\n      </span>\r\n    </div>\r\n  </xsl:template>\r\n\r\n  <!-- Handle the schemaValid processing instruction \r\n         This sets up a document.ready routine that \r\n         colour codes a visual queue i.e. a green title bar.\r\n    -->\r\n  <xsl:template match=\"processing-instruction('schemaValid')\">\r\n    <script>\r\n      $(document).ready(function() {\r\n      $(\"#schemaSummary\").addClass(\"success\")\r\n      $(\"button\").css(\"display\", \"none\");\r\n      });\r\n    </script>\r\n  </xsl:template>\r\n\r\n  <!-- Handle the schemaInvalid processing instruction\r\n         Renders a red title bar with navigation controls to\r\n         step through the errors.    \r\n     -->\r\n  <xsl:template match=\"processing-instruction('schemaInvalid')\">\r\n    <script>\r\n      <![CDATA[\r\n            var index = -1;\r\n            var errors = $(\"div.failure\");\r\n            var offsetFromTop = $(\"#schemaSummary\").outerHeight();\r\n            function nextError(){\r\n                if(index > -1) \r\n                    $(errors).eq(index).removeClass(\"selected\");\r\n                index ++;\r\n                if(index >= $(errors).size())\r\n                    index = 0;\r\n\r\n                $(errors).eq(index).addClass(\"selected\");                                       \r\n                scrollTo($(errors).eq(index), offsetFromTop);\r\n            }\r\n            function prevError(){\r\n                $(errors).eq(index).removeClass(\"selected\");\r\n                index --;\r\n                if(index < 0)\r\n                    index = $(errors).size() - 1;\r\n\r\n                $(errors).eq(index).addClass(\"selected\");                                       \r\n                scrollTo($(errors).eq(index), offsetFromTop);               \r\n            }\r\n            function scrollTo(element, offsetFromTop) {\r\n                $('html,body').animate({scrollTop: $(element).offset().top - offsetFromTop},'fast');\r\n            }\r\n\r\n            $(document).ready(function() {\r\n                $(\"#schemaSummary\").addClass(\"warning\");\r\n                $(\"#next\").click(function() {\r\n                    nextError();\r\n                });\r\n                $(\"#prev\").click(function() {\r\n                    prevError();\r\n                });\r\n            });\r\n            ]]>\r\n    </script>\r\n  </xsl:template>\r\n\r\n  <!-- Add a colour coded bar in situ i.e. where the validation\r\n         error has occured -->\r\n  <xsl:template match=\"processing-instruction('error')\">\r\n    <div class=\"validation failure\">\r\n      <xsl:value-of select=\".\"></xsl:value-of>\r\n    </div>\r\n  </xsl:template>\r\n\r\n  <xsl:template match=\"processing-instruction()\">\r\n    <DIV class=\"e\">\r\n      <SPAN class=\"b\">\r\n        <xsl:call-template name=\"entity-ref\">\r\n          <xsl:with-param name=\"name\">nbsp</xsl:with-param>\r\n        </xsl:call-template>\r\n      </SPAN>\r\n      <SPAN class=\"m\">\r\n        <xsl:call-template name=\"entity-ref\">\r\n          <xsl:with-param name=\"name\">lt</xsl:with-param>\r\n        </xsl:call-template>?\r\n      </SPAN>\r\n      <SPAN class=\"pi\">\r\n        <xsl:value-of select=\"name(.)\"/>\r\n      </SPAN>\r\n      <SPAN>\r\n        <xsl:call-template name=\"entity-ref\">\r\n          <xsl:with-param name=\"name\">nbsp</xsl:with-param>\r\n        </xsl:call-template>\r\n        <xsl:value-of select=\".\"/>\r\n      </SPAN>\r\n      <SPAN class=\"m\">\r\n        <xsl:text>?></xsl:text>\r\n      </SPAN>\r\n    </DIV>\r\n  </xsl:template>\r\n  <xsl:template match=\"processing-instruction('xml')\">\r\n    <DIV class=\"e\">\r\n      <SPAN class=\"b\">\r\n        <xsl:call-template name=\"entity-ref\">\r\n          <xsl:with-param name=\"name\">nbsp</xsl:with-param>\r\n        </xsl:call-template>\r\n      </SPAN>\r\n      <SPAN class=\"m\">\r\n        <xsl:call-template name=\"entity-ref\">\r\n          <xsl:with-param name=\"name\">lt</xsl:with-param>\r\n        </xsl:call-template>?\r\n      </SPAN>\r\n      <SPAN class=\"pi\">\r\n        <xsl:text>xml </xsl:text>\r\n        <xsl:for-each select=\"@*\">\r\n          <xsl:value-of select=\"name(.)\"/>\r\n          <xsl:text>=\"</xsl:text>\r\n          <xsl:value-of select=\".\"/>\r\n          <xsl:text>\" </xsl:text>\r\n        </xsl:for-each>\r\n      </SPAN>\r\n      <SPAN class=\"m\">\r\n        <xsl:text>?></xsl:text>\r\n      </SPAN>\r\n    </DIV>\r\n  </xsl:template>\r\n  <xsl:template match=\"@*\">\r\n    <SPAN>\r\n      <xsl:attribute name=\"class\">\r\n        <xsl:if test=\"xsl:*/@*\">\r\n          <xsl:text>x</xsl:text>\r\n        </xsl:if>\r\n        <xsl:text>t</xsl:text>\r\n      </xsl:attribute>\r\n      <xsl:value-of select=\"name(.)\"/>\r\n    </SPAN>\r\n    <SPAN class=\"m\">=\"</SPAN>\r\n    <B>\r\n      <xsl:value-of select=\".\"/>\r\n    </B>\r\n    <SPAN class=\"m\">\"</SPAN>\r\n  </xsl:template>\r\n  <xsl:template match=\"text()\">\r\n    <DIV class=\"e\">\r\n      <SPAN class=\"b\"> </SPAN>\r\n      <SPAN class=\"tx\">\r\n        <xsl:value-of select=\".\"/>\r\n      </SPAN>\r\n    </DIV>\r\n  </xsl:template>\r\n  <xsl:template match=\"comment()\">\r\n    <DIV class=\"k\">\r\n      <SPAN>\r\n        <A STYLE=\"visibility:hidden\" class=\"b\" onclick=\"return false\" onfocus=\"h()\">-</A>\r\n        <SPAN class=\"m\">\r\n          <xsl:call-template name=\"entity-ref\">\r\n            <xsl:with-param name=\"name\">lt</xsl:with-param>\r\n          </xsl:call-template>!--\r\n        </SPAN>\r\n      </SPAN>\r\n      <SPAN class=\"ci\" id=\"clean\">\r\n        <PRE>\r\n          <xsl:value-of select=\".\"/>\r\n        </PRE>\r\n      </SPAN>\r\n      <SPAN class=\"b\">\r\n        <xsl:call-template name=\"entity-ref\">\r\n          <xsl:with-param name=\"name\">nbsp</xsl:with-param>\r\n        </xsl:call-template>\r\n      </SPAN>\r\n      <SPAN class=\"m\">\r\n        <xsl:text>--></xsl:text>\r\n      </SPAN>\r\n      <SCRIPT>f(clean);</SCRIPT>\r\n    </DIV>\r\n  </xsl:template>\r\n  <xsl:template match=\"*\">\r\n    <DIV class=\"e\">\r\n      <DIV STYLE=\"margin-left:1em;text-indent:-2em\">\r\n        <SPAN class=\"b\">\r\n          <xsl:call-template name=\"entity-ref\">\r\n            <xsl:with-param name=\"name\">nbsp</xsl:with-param>\r\n          </xsl:call-template>\r\n        </SPAN>\r\n        <SPAN class=\"m\">\r\n          <xsl:call-template name=\"entity-ref\">\r\n            <xsl:with-param name=\"name\">lt</xsl:with-param>\r\n          </xsl:call-template>\r\n        </SPAN>\r\n        <SPAN>\r\n          <xsl:attribute name=\"class\">\r\n            <xsl:if test=\"xsl:*\">\r\n              <xsl:text>x</xsl:text>\r\n            </xsl:if>\r\n            <xsl:text>t</xsl:text>\r\n          </xsl:attribute>\r\n          <xsl:value-of select=\"name(.)\"/>\r\n          <xsl:if test=\"@*\">\r\n            <xsl:text> </xsl:text>\r\n          </xsl:if>\r\n        </SPAN>\r\n        <xsl:apply-templates select=\"@*\"/>\r\n        <SPAN class=\"m\">\r\n          <xsl:text>/></xsl:text>\r\n        </SPAN>\r\n      </DIV>\r\n    </DIV>\r\n  </xsl:template>\r\n  <xsl:template match=\"*[node()]\">\r\n    <DIV class=\"e\">\r\n      <DIV class=\"c\">\r\n        <A class=\"b\" href=\"#\" onclick=\"return false\" onfocus=\"h()\">-</A>\r\n        <SPAN class=\"m\">\r\n          <xsl:call-template name=\"entity-ref\">\r\n            <xsl:with-param name=\"name\">lt</xsl:with-param>\r\n          </xsl:call-template>\r\n        </SPAN>\r\n        <SPAN>\r\n          <xsl:attribute name=\"class\">\r\n            <xsl:if test=\"xsl:*\">\r\n              <xsl:text>x</xsl:text>\r\n            </xsl:if>\r\n            <xsl:text>t</xsl:text>\r\n          </xsl:attribute>\r\n          <xsl:value-of select=\"name(.)\"/>\r\n          <xsl:if test=\"@*\">\r\n            <xsl:text> </xsl:text>\r\n          </xsl:if>\r\n        </SPAN>\r\n        <xsl:apply-templates select=\"@*\"/>\r\n        <SPAN class=\"m\">\r\n          <xsl:text>></xsl:text>\r\n        </SPAN>\r\n      </DIV>\r\n      <DIV>\r\n        <xsl:apply-templates/>\r\n        <DIV>\r\n          <SPAN class=\"b\">\r\n            <xsl:call-template name=\"entity-ref\">\r\n              <xsl:with-param name=\"name\">nbsp</xsl:with-param>\r\n            </xsl:call-template>\r\n          </SPAN>\r\n          <SPAN class=\"m\">\r\n            <xsl:call-template name=\"entity-ref\">\r\n              <xsl:with-param name=\"name\">lt</xsl:with-param>\r\n            </xsl:call-template>?/\r\n          </SPAN>\r\n          <SPAN>\r\n            <xsl:attribute name=\"class\">\r\n              <xsl:if test=\"xsl:*\">\r\n                <xsl:text>x</xsl:text>\r\n              </xsl:if>\r\n              <xsl:text>t</xsl:text>\r\n            </xsl:attribute>\r\n            <xsl:value-of select=\"name(.)\"/>\r\n          </SPAN>\r\n          <SPAN class=\"m\">\r\n            <xsl:text>></xsl:text>\r\n          </SPAN>\r\n        </DIV>\r\n      </DIV>\r\n    </DIV>\r\n  </xsl:template>\r\n  <xsl:template match=\"*[text() and not (comment() or processing-instruction())]\">\r\n    <DIV class=\"e\">\r\n      <DIV STYLE=\"margin-left:1em;text-indent:-2em\">\r\n        <SPAN class=\"b\">\r\n          <xsl:call-template name=\"entity-ref\">\r\n            <xsl:with-param name=\"name\">nbsp</xsl:with-param>\r\n          </xsl:call-template>\r\n        </SPAN>\r\n        <SPAN class=\"m\">\r\n          <xsl:call-template name=\"entity-ref\">\r\n            <xsl:with-param name=\"name\">lt</xsl:with-param>\r\n          </xsl:call-template>\r\n        </SPAN>\r\n        <SPAN>\r\n          <xsl:attribute name=\"class\">\r\n            <xsl:if test=\"xsl:*\">\r\n              <xsl:text>x</xsl:text>\r\n            </xsl:if>\r\n            <xsl:text>t</xsl:text>\r\n          </xsl:attribute>\r\n          <xsl:value-of select=\"name(.)\"/>\r\n          <xsl:if test=\"@*\">\r\n            <xsl:text> </xsl:text>\r\n          </xsl:if>\r\n        </SPAN>\r\n        <xsl:apply-templates select=\"@*\"/>\r\n        <SPAN class=\"m\">\r\n          <xsl:text>></xsl:text>\r\n        </SPAN>\r\n        <SPAN class=\"tx\">\r\n          <xsl:value-of select=\".\"/>\r\n        </SPAN>\r\n        <SPAN class=\"m\">\r\n          <xsl:call-template name=\"entity-ref\">\r\n            <xsl:with-param name=\"name\">lt</xsl:with-param>\r\n          </xsl:call-template>/\r\n        </SPAN>\r\n        <SPAN>\r\n          <xsl:attribute name=\"class\">\r\n            <xsl:if test=\"xsl:*\">\r\n              <xsl:text>x</xsl:text>\r\n            </xsl:if>\r\n            <xsl:text>t</xsl:text>\r\n          </xsl:attribute>\r\n          <xsl:value-of select=\"name(.)\"/>\r\n        </SPAN>\r\n        <SPAN class=\"m\">\r\n          <xsl:text>></xsl:text>\r\n        </SPAN>\r\n      </DIV>\r\n    </DIV>\r\n  </xsl:template>\r\n  <xsl:template match=\"*[*]\" priority=\"20\">\r\n    <DIV class=\"e\">\r\n      <DIV STYLE=\"margin-left:1em;text-indent:-2em\" class=\"c\">\r\n        <A class=\"b\" href=\"#\" onclick=\"return false\" onfocus=\"h()\">-</A>\r\n        <SPAN class=\"m\">\r\n          <xsl:call-template name=\"entity-ref\">\r\n            <xsl:with-param name=\"name\">lt</xsl:with-param>\r\n          </xsl:call-template>\r\n        </SPAN>\r\n        <SPAN>\r\n          <xsl:attribute name=\"class\">\r\n            <xsl:if test=\"xsl:*\">\r\n              <xsl:text>x</xsl:text>\r\n            </xsl:if>\r\n            <xsl:text>t</xsl:text>\r\n          </xsl:attribute>\r\n          <xsl:value-of select=\"name(.)\"/>\r\n          <xsl:if test=\"@*\">\r\n            <xsl:text> </xsl:text>\r\n          </xsl:if>\r\n        </SPAN>\r\n        <xsl:apply-templates select=\"@*\"/>\r\n        <SPAN class=\"m\">\r\n          <xsl:text>></xsl:text>\r\n        </SPAN>\r\n      </DIV>\r\n      <DIV>\r\n        <xsl:apply-templates/>\r\n        <DIV>\r\n          <SPAN class=\"b\">\r\n            <xsl:call-template name=\"entity-ref\">\r\n              <xsl:with-param name=\"name\">nbsp</xsl:with-param>\r\n            </xsl:call-template>\r\n          </SPAN>\r\n          <SPAN class=\"m\">\r\n            <xsl:call-template name=\"entity-ref\">\r\n              <xsl:with-param name=\"name\">lt</xsl:with-param>\r\n            </xsl:call-template>/\r\n          </SPAN>\r\n          <SPAN>\r\n            <xsl:attribute name=\"class\">\r\n              <xsl:if test=\"xsl:*\">\r\n                <xsl:text>x</xsl:text>\r\n              </xsl:if>\r\n              <xsl:text>t</xsl:text>\r\n            </xsl:attribute>\r\n            <xsl:value-of select=\"name(.)\"/>\r\n          </SPAN>\r\n          <SPAN class=\"m\">\r\n            <xsl:text>></xsl:text>\r\n          </SPAN>\r\n        </DIV>\r\n      </DIV>\r\n    </DIV>\r\n  </xsl:template>\r\n\r\n  <xsl:template name=\"entity-ref\">\r\n    <xsl:param name=\"name\"/>\r\n    <xsl:text disable-output-escaping=\"yes\">&amp;</xsl:text>\r\n    <xsl:value-of select=\"$name\"/>\r\n    <xsl:text>;</xsl:text>\r\n  </xsl:template>\r\n</xsl:stylesheet>";
    }
}
