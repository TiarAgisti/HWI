<%@ Page Title="" Language="VB" MasterPageFile="~/pagesetting/MsPageMS.master" AutoEventWireup="false" CodeFile="sale_reentry_save.aspx.vb" Inherits="MobileStockiest_sale_reentry_save" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mpCONTENT" Runat="Server">
    <form name="form1">
        <div id="Div_Valid" runat ="server" >

        </div>
        <div id="Div_Responsive" runat ="server" >
        <section class='content'>
	        <div class="box">
		        <div class="box-header with-border">
			        <h3 class="box-title"></h3>
			        <div class="box-tools pull-right">
				        <button type="button" class="btn btn-box-tool" data-widget="collapse" data-toggle="tooltip" title="Collapse">
				        <i class="fa fa-minus"></i></button>
				        <button type="button" class="btn btn-box-tool" data-widget="remove" data-toggle="tooltip" title="Remove">
				        <i class="fa fa-times"></i></button>
			        </div>
		        </div>
		        <div class="box-body">
			        <p style="text-align:center;">
			        <img border="0" src="../images/health-wealthlogo.jpg" width="186" height="125">
			        <br/>
			        <br/>
			
			        <p style="text-align:center;">
				        Ada kesalahan dalam proses pendaftaran, silahkan perbaiki kesalahan seperti yang tertulis dibawah ini.<br/>
				        <!--%if error1 <> "" then %-->
					      <%--  <%=erro1%>--%>
				        <!--%end if%-->
				        <!--%if error2 <> "" then %-->
					        <%--<%=error2%>--%>
				        <!--%end if%-->
				        <!--%if error3 <> "" then %-->
					       <%-- <%=error3%>--%>
				        <!--%end if%-->	
				        <!--%if error4 <> "" then %-->
					      <%--  <%=error4%>--%>
				        <!--%end if%-->
				        <br/>				
				        &lt;-- <a href="sale_reentry.aspx?menu_id=<%=session("menu_id")%>">Kembali</a> 
				        --&gt;
		        </div>
	        </div>
        </section>
    </div>
    </form>
</asp:Content>

