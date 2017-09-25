<!--#Include File=pg_turing.asp-->	
<%
manuk = Session.Contents("manuk")
%>
<script language="JavaScript">
<!--
function formCheck1(form) {
if (form.userid.value == "")
{
 alert("Mohon isikan nomor id distributor anda");
return false;}

if (form.password.value == "")
{
 alert("Mohon isikan password login anda");
return false;}

if (form.turing.value == "")
{
 alert("Mohon isikan turing number yang ada pada kolom dibawah text password login");
return false;}
}
// -->
</script>
<table border="0" cellpadding="0" cellspacing="0" width="100%"
style="
	
	background:#F00;
	-moz-border-radius:10px;
    border-radius:10px;">
	<tr>
				<td valign="top">
					<table border="0" cellpadding="0" cellspacing="0" width="100%">
							<tr>
								<td style="padding:10px;">
								<strong><font size="4" color="#FFFFFF">Distributor Login </font></strong><hr /></td>
							</tr>
						</table>
						<table border="0" cellpadding="0" cellspacing="0" width="100%">
							<tr>
								<td>


<div align="center">
  
   <table width="92%" style="
	padding: 5px;
	background:#FFC;
	-moz-border-radius:7px;
    border-radius:7px;"> 
     <tr><td>
		<table border="0" cellpadding="0" cellspacing="0" width="92%">
							<tr>
								<td valign="top">
		<form name="login" method="post" action="login.asp" onsubmit="return formCheck1(this)">											
								<table border="0" cellspacing="0" width="100%">
									<tr>
										<td width="72">Id. Distributor</td>
										<td width="10">:</td>
										<td><font color="#FFFFFF">
						<input type="text" name="userid" style="font-size: 8pt; font-family: Verdana; border: 1px solid #808080" size="9"></font></td>
									</tr>
									<tr>
										<td width="72">Password</td>
										<td width="10">:</td>
										<td><font color="#FFFFFF">
						<input type="password" name="password" style="font-size: 8pt; font-family: Verdana; border: 1px solid #808080" size="13"></font></td>
									</tr>
                                    <tr><td><table style="
	background:#000;
	-moz-border-radius:7px;
    border-radius:7px;" width="100%"><tr><td align="center">    
<b>																<font color="#FF0000">																<%=z1%></font>																<font color="#FFFF00">
<%=z2%></font>														<font color="#00FF00">										<%=z3%></font><font color="#FFFFFF">								<%=z4%></font></b><b>												<font color="#FFFF00">										<%=z5%></font></b></td></tr></table></td>
								<td width="10">:</td>
								<td><font color="#FFFFFF">
						<input type="text" name="turing" style="font-size: 8pt; font-family: Verdana; border: 1px solid #808080" size="13"></font></td></tr>
									<tr>
										<td width="72"><font size="1">*input turing</font></td>
										<td width="10">&nbsp;</td>
										<td>
										<input type="submit" name="btlogin" value="Login" style="font-size: 8pt; font-family: Verdana"></td></tr></table>
		</form>			</td>					
									</tr>
								</table>
		</td>							
	</tr>
	<tr>
		<td align="right">
								[
								<a target="_top" href="password_reminder.asp">
								Pengingat Password</a> ]
								<%if manuk <> "" then %>
								<br>
								[ <a target="_top" href="cpanel/default.asp">
								<font color="#008000">Control Panel</font></a> ]
								[ <a target="_top" href="logout.asp">
								<font color="#FF0000">Logout</font></a> ]
								<%end if%>
		</td>
	</tr>
						
</table></div>
</td></tr><tr><td>&nbsp;</td></tr></table></td></tr></table>
<br />

<table border="0" cellpadding="0" cellspacing="0" width="100%" style="
	background:#06F;
	-moz-border-radius:10px;
    border-radius:10px;">
	<tr>
		<td valign="top">
		
		<table border="0" cellpadding="0" cellspacing="0" width="100%">
			
			
			<% if session("menus") <> "konsul_prod" then%>
			<tr>
				<td>
				<table border="0" cellpadding="0" cellspacing="0" width="100%">
							<tr>
								<td style="padding:10px;">
								<strong><font size="4" color="#FFFFFF">Konsultasi Produk </font></strong><hr /></td>
							</tr>
						</table>
								
				<table border="0" cellpadding="0" cellspacing="0" width="100%">
					<tr>
						<td>
						<div align="center">
							<table style="background:#FFC;padding:5px;-moz-border-radius:7px;
    border-radius:7px;" width="92%">
								<tr>
									<td width="80" valign="top">
									<p align="center">
									<img border="1" src="images/drindra.jpg" width="70" height="92"></td>
									<td valign="top"><font color="#000000">Anda 
									memiliki pertanyaan mengenai produk-produk 
									yang dipasarkan HWI ? Silahkan konsultasikan 
									bersama </font><font color="#FF0000">product 
									specialist</font><font color="#000000"> kami 
									....<br>
									&nbsp;</font></td>
								</tr>
								<tr>
									<td width="80" valign="top">&nbsp;</td>
									<td valign="top">
									<p align="right"><font color="#000000">
									<embed style=" float:right" src="image/button.swf" width="120" height="30" wmode="transparent"> </embed></font></td>
								</tr>
							</table>
						</div>
						</td>
					</tr>
				</table>
				<table border="0" cellpadding="0" cellspacing="0" width="100%">
					
				</table>
				</td>
			</tr>
			<%end if%>
			<tr>
				<td>&nbsp;
				</td>
			</tr>
			</table>
		</td>
	</tr>
</table>
<br>	