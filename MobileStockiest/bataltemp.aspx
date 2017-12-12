<%@ Page Title="" Language="VB" MasterPageFile="~/pagesetting/MsPageMS.master" AutoEventWireup="false" CodeFile="bataltemp.aspx.vb" Inherits="MobileStockiest_bataltemp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mpCONTENT" Runat="Server">
    <section class="content-header">
        <div style="padding: 20px 20px 20px 20px">
    <div class="panel panel-default">
        <div class="panel-heading">
            <h3 class="text-center panel-title" style="font-family:Arial;"><strong>PEMBATALAN TEMPORARY ACCOUNT</strong></h3>
        </div>
        <div class="panel-body">
            <div style="padding: 20px 20px 20px 20px" class="col-md-3">
                <label>Nomor Seri / Distributor</label>
            </div>
            <div style="padding: 20px 20px 20px 20px" class="col-md-5">
                <input type="hidden" name="menu_id" value="<%=session("menu_id")%>">
                <input class="form-control" type="text" id="txtnoseri" runat="server">
            </div>
            <div style="padding: 20px 20px 20px 20px" class="col-md-4">
                <button class="btn btn-default" type="button" id="btntampil" runat="server" onserverclick="btntampil_ServerClick">Tampilkan</button>
            </div>
			
            <div id="div_pencarian" runat="server">
            <%if lanjut = "T" Then%>
                <div class="col-md-12">
				    <h4><span style="text-decoration: underline">Hasil Pencarian Pada Table Temporary</span></h4>
			    </div>
                <div style="padding: 10px 20px 10px 20px" class="col-md-3">
                    <label>Nomor Seri / Distributor :</label>
                </div>
			    <div style="padding: 10px 20px 10px 20px" class="col-md-9">
				    <label><%=noseri%></label>
			    </div>
			    <div style="padding: 10px 20px 10px 20px" class="col-md-3">
                    <label>Nama :</label>
                </div>
			    <div style="padding: 10px 20px 10px 20px" class="col-md-9">
				    <label><%=nama%></label>
			    </div>
			    <div style="padding: 10px 20px 10px 20px" class="col-md-3">
                    <label>Tipe Pendaftaran :</label>
                </div>
			    <div style="padding: 10px 20px 10px 20px" class="col-md-9">
				    <label><%=paket%></label>
			    </div>
			    <div style="padding: 10px 20px 10px 20px" class="col-md-3">
                    <label>Tanggal :</label>
                </div>
			    <div style="padding: 10px 20px 10px 20px" class="col-md-9">
				    <label><%=tgl%></label>
			    </div>
			    <div style="padding: 10px 20px 10px 20px" class="col-md-3">
                    <label>DC Register :</label>
                </div>
			    <div style="padding: 10px 20px 10px 20px" class="col-md-9">
				    <label><%=nopos%></label>
			    </div>
			    <div style="padding: 10px 20px 10px 20px" class="col-md-3">
                    <label>Entry User :</label>
                </div>
			    <div style="padding: 10px 20px 10px 20px" class="col-md-9">
				    <label><%=kasir%></label>
			    </div>

			    <div style="padding: 10px 20px 10px 20px" class="col-md-3">
                    <label>Status Proses :</label>
                </div>
			    <div style="padding: 10px 20px 10px 20px" class="col-md-9">
				    <label>
                        <% if ada = "T" Then %>
                        <span style="color: green">ACTIVE REGISTERED</span>
                        <% else %>
                        <span style="color: red">UNSUCCESSFULL</span>
                        <% End If %>
				    </label>
			    </div>

			    <div style="padding: 10px 20px 10px 20px" class="col-md-3">
                    <label><strong>RESULT :</strong></label>
                </div>
			    <div style="padding: 10px 20px 10px 20px" class="col-md-9">
				    <label><%=hasil%></label>
			    </div>
                    <%if ada = "F" Then %>
                <input type="hidden" name="menu_id" value="<%=Session("menu_id")%>">		
				<input type="hidden" name="noseri" value="<%=noid%>">
			    <div style="padding: 10px 20px 10px 20px" class="col-md-3">
                    <label> </label>
                </div>
			    <div style="padding: 10px 20px 10px 20px" class="col-md-9">
				    <label><button class="btn btn-default" type="button" id="btnbatal" runat="server" onserverclick="btnbatal_ServerClick">Batalkan</button></label>
			    </div>
                    <%end If%>
            <%end if%>
            </div>
            <p style="text-align:center;color:#FF0000;">&nbsp;<%=piye%></p>
			
            <%--<form>
                
            </form>--%>
        </div>
    </div>
</div>
    </section>
</asp:Content>

