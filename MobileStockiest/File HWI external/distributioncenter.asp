<!--#Include File=pg_config.asp-->
<!--#Include File=dbcon/opendb.asp-->
<!--#Include File=dbcon/opendbALL.asp-->
<%
'***** START WARNING - REMOVAL OR MODIFICATION OF THIS CODE WILL VIOLATE THE LICENSE AGREEMENT ******
' Application: HEALTH WEALTH INTERNATIONAL WEBSITE
' Author: Peter Sindoro
' Coding : Septmber 2009
' Revised : -
'***** END WARNING - REMOVAL OR MODIFICATION OF THIS CODE WILL VIOLATE THE LICENSE AGREEMENT ******     
dim refername
dim tmpname
tmpname = Session.Contents("ReferName")
Session.Contents("ReferName")= tmpname
session("menus") = "konsul_prod"
session("asal") = "distributioncenter.asp"
%>

<html>
<head>
<meta http-equiv="Content-Language" content="en-us">
<meta http-equiv="Content-Type" content="text/html; charset=windows-1252">
   <meta name="description" content="Distribution Center PT. Health Wealth International">
   <meta name="keywords" content="distribution center,health wealth international,marketing,multilevel,network,mlm,international,health,food,supplement,hwi">
<meta name="revisit-after" content="15 days">
<meta name="robots" content="index,follow">
<meta name="language" content="en-us">
<meta name="rating" content="General">
<meta name="resource-type" content="document">
<meta name="distribution" content="Global">
<TITLE>Health Wealth International :: Distribution Center</TITLE>
<link rel="shortcut icon" href="<%=myico%>" />
<META HTTP-EQUIV="Content-Type" CONTENT="text/html; charset=windows-1252">
<style type="text/css">
<!--
td {
	font-family:Tahoma;
	font-size:11px;
	color:#4F4F4F;
}
a {
	text-decoration: none;
	color:#31509F;
}
a.1 {
	text-decoration: none;
	color:#BD1818;
}
a.2 {
	text-decoration: underline;
	color:#ffffff;
}
a.3 {
	text-decoration: underline;
	color:#FFD16F;
}
a.4 {
	text-decoration: none;
	color:#FFFFFF;
}
a.5 {
	text-decoration: underline;
	color:#BD1818;
}
.t11 {
	font-family: Tahoma;
	font-size: 11px;
	font-style: normal;
}
.t10 {
	font-family: Tahoma;
	font-size: 10px;
	font-style: normal;
}
.style1 {color: #FFFFFF}
.style2 {color: #616161}
.style3 {color: #31509F}
.style4 {color: #ffffff}

-->
</style>
<style fprolloverstyle>A:hover {font-size: 11px; color: #FF9966; font-family: Tahoma; text-decoration: underline}
</style>
<style type="text/css">
body
{
background-image:
url("<%=bgimage%>");
background-repeat:no-repeat;
background-attachment:fixed;
background-position:center;
}
</style>

</head>
<body>

<table border="0" cellpadding="0" style="border-collapse: collapse" width="100%">
	<tr>
		<td><!--#Include File=pg_header.asp--></td>
	</tr>
</table>
<table border="0" cellpadding="0" style="border-collapse: collapse" width="100%">
	<tr>
		<td width="50%">&nbsp;</td>
		<td width="953">
		<table bgcolor="#FFFFFF"  border="0" cellpadding="0" style="border:2px solid #FFF;" width="983">
        <tr><td><table>
        <tr><td valign="top" width="663" bgcolor="#FFFFFF">
        
        <table border="0" cellpadding="0" cellspacing="0" width="100%">
											<tr>
												<td valign="top">
												<!--#Include File=slide4.asp--></td>
											</tr>
											<tr>
												<td valign="top">&nbsp;</td>
											</tr>
											<tr>
												<td valign="top" style="padding:5px;">

				<table border="0" cellpadding="0" cellspacing="0" width="100%">
					<tr>
						<td valign="top">
						<table border="0" cellpadding="0" cellspacing="0" width="100%">
							<tr>
								<td valign="top">
								<table border="0" cellpadding="0" cellspacing="0" width="100%">
									<tr>
										<td width="19">
										<img border="0" src="images/b1.gif" width="19" height="14"></td>
										<td background="images/b2.gif" width="100%">
										<img border="0" src="images/b2.gif" width="18" height="14"></td>
										<td width="21">
										<img border="0" src="images/b3.gif" width="21" height="14"></td>
									</tr>
								</table>
								<table border="0" cellpadding="0" cellspacing="0" width="100%">
									<tr>
										<td valign="top" background="images/b4.gif" width="10">
										<img border="0" src="images/b4.gif" width="10" height="16"></td>
										<td valign="top" width="100%">										
										<div align="center">
										<table border="0" cellpadding="0" cellspacing="0" width="99%">
											<tr>
												<td valign="top" background="images/bg_text.gif">
												<img border="0" src="images/text_dc_list.gif" width="471" height="63"></td>
											</tr>
											<tr>
												<td valign="top">
												<table border="0" cellpadding="0" cellspacing="0" width="100%">
													<tr>
														<td width="466" valign="top">
														<table border="0" cellpadding="0" cellspacing="0" width="98%">
															<tr>
																<td valign="top">
				<table border="0" cellpadding="0" cellspacing="0" width="100%">
					<tr>
						<td valign="top">
						<table border="0" cellpadding="0" cellspacing="0" width="100%">
							<tr>
								<td valign="top">
								<table border="0" cellpadding="0" cellspacing="0" width="100%">
									<tr>
										<td width="19">
										<img border="0" src="images/b1.gif" width="19" height="14"></td>
										<td background="images/b2.gif" width="100%">
										<img border="0" src="images/b2.gif" width="18" height="14"></td>
										<td width="21">
										<img border="0" src="images/b3.gif" width="21" height="14"></td>
									</tr>
								</table>
								<table border="0" cellpadding="0" cellspacing="0" width="100%">
									<tr>
										<td valign="top" background="images/b4.gif" width="10">
										<img border="0" src="images/b4.gif" width="10" height="16"></td>
										<td valign="top" width="100%">										
										<div align="center">
										<table border="0" cellpadding="0" cellspacing="0" width="99%">
											<tr>
												<td valign="top" background="images/bg_text.gif">
												&nbsp;</td>
											</tr>
											<tr>
												<td valign="top">
												&nbsp;</td>
											</tr>
											<tr>
												<td valign="top">
												&nbsp;</td>
											</tr>
											</table>
										</div>
										</td>
										<td valign="top" background="images/b5.gif" width="9">
										<img border="0" src="images/b5.gif" width="9" height="16"></td>
									</tr>
								</table>
								<table border="0" cellpadding="0" cellspacing="0" width="100%">
									<tr>
										<td width="22">
										<img border="0" src="images/b6.gif" width="22" height="14"></td>
										<td background="images/b7.gif" width="100%">
										<img border="0" src="images/b7.gif" width="21" height="14"></td>
										<td width="18">
										<img border="0" src="images/b8.gif" width="20" height="14"></td>
									</tr>
								</table>
								</td>
							</tr>
						</table>
						</td>
					</tr>
				</table>
				<table border="0" cellpadding="0" cellspacing="0" width="100%">
					<tr>
						<td valign="top">
						&nbsp;</td>
					</tr>
					</table>
																</td>
															</tr>
															<tr>
																<td valign="top">&nbsp;</td>
															</tr>
														</table>
														<p><br>
														<br>
														<br>
														<br>
														<br>
														<br>
														<br>
														<br>
&nbsp;</td>
														<td valign="top">
														<table border="1" cellspacing="1" width="99%" style="border-collapse: collapse" bordercolor="#EFEFEF">
															<tr>
																<td>
																<table border="0" cellpadding="0" cellspacing="0" width="100%">
																	<tr>
																		<td bgcolor="#DDDDDD" height="20" valign="middle">
																		<p align="center">
																		<b>LOGIN 
																		AREA</b></td>
																	</tr>
																</table>
																<p><br>
																<br>
																<br>
																<br>
&nbsp;</td>
															</tr>
														</table>
														<p><br>
														<br>
														<br>
														<br>
&nbsp;</td>
													</tr>
												</table>
												</td>
											</tr>
											<tr>
												<td valign="top">
												&nbsp;</td>
											</tr>
											</table>
										</div>
										</td>
										<td valign="top" background="images/b5.gif" width="9">
										<img border="0" src="images/b5.gif" width="9" height="16"></td>
									</tr>
								</table>
								<table border="0" cellpadding="0" cellspacing="0" width="100%">
									<tr>
										<td width="22">
										<img border="0" src="images/b6.gif" width="22" height="14"></td>
										<td background="images/b7.gif" width="100%">
										<img border="0" src="images/b7.gif" width="21" height="14"></td>
										<td width="18">
										<img border="0" src="images/b8.gif" width="20" height="14"></td>
									</tr>
								</table>
								</td>
							</tr>
						</table>
						</td>
					</tr>
				</table>
				<table border="0" cellpadding="0" cellspacing="0" width="100%">
					<tr>
						<td valign="top">
						&nbsp;</td>
					</tr>
					</table>
				</td></tr></table>
        
</td>



<td valign="top" height="100" width="320" bgcolor="#EEEEEE">
      
<!--#Include File=calendar.asp-->

<!--#Include File=pg_testimonial.asp-->

<!--#Include File=pg_konsul.asp-->

</td>
</tr>
</table>
        </td></tr>
        <tr><td bgcolor="#191919">
        
        <!--#Include File=pg_footer.asp-->

        
        </td></tr></table>
        </td>
		<td width="50%">&nbsp;</td>
	</tr>
</table></body>

</html>