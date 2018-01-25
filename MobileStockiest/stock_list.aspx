<%@ Page Title="" Language="VB" MasterPageFile="~/pagesetting/MsPageMS.master" AutoEventWireup="false" CodeFile="stock_list.aspx.vb" Inherits="MobileStockiest_stock_list" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
   <%-- <script type="text/javascript" src="../assets/js/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../assets/bootstrap/js/bootstrap.min.js"></script>--%>
    <style>
        .height {
            min-height: 200px;
        }

        .icon {
            font-size: 47px;
            color: #5CB85C;
        }

        .table > tfoot > tr > .emptyrow {
            border-top: none;
        }

        .table > tbody > tr > .emptyrow {
            border-top: none;
        }

        .table > thead > tr > .emptyrow {
            border-bottom: none;
        }

        .table > tfoot > tr > .highrow {
            border-top: 3px solid;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mpCONTENT" runat="Server">
    <section class="content-header" style="background-color: white;">
        <div class="panel panel-default">
            <div class="panel-heading">
                <h3 class="text-center panel-title"><strong>DAFTAR STOCK PRODUK</strong></h3>
            </div>
            <div class="panel-body">
                <div class="panel panel-default">
                    <div class="panel-body">
                        <form name="acts" method="post" action="stock_list.aspx">
                            <input type="hidden" name="menu_id" value="<%=session("menu_id")%>">
							<input type="hidden" name="pgview" value="<%=bg%>">	
							<input type="hidden" name="page" value="<%=pg+1%>">
                            <table>
		                        <tr>
			                        <td><label style="width:120px;">Urut</label></td>
			                        <td><label>&nbsp;:&nbsp;</label></td>
			                        <td>
				                        <select class="form-control" name="sort" style="width:250px;">
										    <%if sort = "nama" then %>	
											<option value="nama" selected>Nama</option>																																												
											<option value="kode">Kode</option>
											<option value="jumlah">Jumlah</option>	
											<option value="hk">Harga Konnsumen</option>
											<option value="hd">Harga Distributor</option>		
											<option value="PV">PV</option>																																														
											<option value="BV">BV</option>	
											<%else%>
											    <%if sort = "kode" then %>
												<option value="nama">Nama</option>																																												
												<option value="kode" selected>Kode</option>
												<option value="jumlah">Jumlah</option>	
												<option value="hk">Harga Konnsumen</option>
												<option value="hd">Harga Distributor</option>		
												<option value="PV">PV</option>																																														
												<option value="BV">BV</option>																
												<%else%>
												    <%if sort = "jumlah" then %>
													<option value="nama">Nama</option>																																												
													<option value="kode">Kode</option>			
													<option value="jumlah" selected>Jumlah</option>	
													<option value="hk">Harga Konnsumen</option>
													<option value="hd">Harga Distributor</option>		
													<option value="PV">PV</option>																																														
													<option value="BV">BV</option>																
													<%else%>
													    <%if sort = "hk" then %>
														<option value="nama">Nama</option>																																												
														<option value="kode">Kode</option>			
														<option value="jumlah">Jumlah</option>	
														<option value="hk" selected>Harga Konnsumen</option>
														<option value="hd">Harga Distributor</option>		
														<option value="PV">PV</option>																																														
														<option value="BV">BV</option>
														<%else%>
														    <%if sort = "hd" then %>
															<option value="nama">Nama</option>																																												
															<option value="kode">Kode</option>			
															<option value="jumlah">Jumlah</option>	
															<option value="hk">Harga Konnsumen</option>
															<option value="hd" selected>Harga Distributor</option>		
															<option value="PV">PV</option>																																														
															<option value="BV">BV</option>
															<%else%>
															    <%if sort = "PV" then %>
															    <option value="nama">Nama</option>																																												
															    <option value="kode">Kode</option>			
															    <option value="jumlah">Jumlah</option>	
															    <option value="hk">Harga Konnsumen</option>
															    <option value="hd">Harga Distributor</option>		
															    <option value="PV" selected>PV</option>																																														
															    <option value="BV">BV</option>
															    <%else%>
															        <%if sort = "BV" then %>
															        <option value="nama">Nama</option>																																												
															        <option value="kode">Kode</option>			
															        <option value="jumlah">Jumlah</option>	
															        <option value="hk">Harga Konnsumen</option>
															        <option value="hd">Harga Distributor</option>		
															        <option value="PV">PV</option>																																														
															        <option value="BV" selected>BV</option>
															        <%else%>
															        <option value="nama" selected>Nama</option>																																												
															        <option value="kode">Kode</option>		
															        <option value="jumlah">Jumlah</option>	
															        <option value="hk">Harga Konnsumen</option>
															        <option value="hd">Harga Distributor</option>		
															        <option value="PV">PV</option>																																														
															        <option value="BV">BV</option>																
															        <%end if%>																																										
															    <%end if%>
															<%end if%>
														<%end if%>																																										
													<%end if%>
												<%end if%>
											<%end if%>					
				                        </select>
			                        </td>
			                        <td>&nbsp;</td>
			                        <td><input type="submit" name="btsb2" value="Ok" class="btn"></td>
		                        </tr>	
	                        </table>
                        </form>
                    </div>
                </div>
                <div class="panel panel-default">
                    <div class="panel-body">
                        <p style="text-align:left;">
                            <b style="color:#FF0000">Ditemukan <b><%=FormatNumber(x, 0)%></b> item produk&nbsp;&nbsp;&nbsp;</b>
                        </p>
                        <form name="view" method="post" action="stock_list.aspx">
                            <input type="hidden" name="menu_id" value="<%=session("menu_id")%>">
							<input type="hidden" name="sort" value="<%=sort%>">	
							<input type="hidden" name="pgview" value="<%=bg%>">
                            <table>
		                        <tr>
			                        <td><label style="width:120px;">Tampilkan Halaman</label></td>
			                        <td><label>&nbsp;:&nbsp;</label></td>
			                        <td>
				                        <select class="form-control" name="page" style="width:250px;">
					                       <%
                                               aax = 1
                                               kl = 0
                                               For aax = 1 To pgct * 2
                                                   kl = kl + 1
                                            %>			
															<% if kl = pg+1 then %>												
															<option value="<%=kl%>" selected><%=kl%></option>
															<%else%>
															<option value="<%=kl%>"><%=kl%></option>
															<%end if%>																																													
                                            <%
                                                    If aax > pgct * 2 Then
                                                        Exit For
                                                    End If
                                                    aax = aax + 1
                                                Next
                                            %>		
				                        </select>
			                        </td>
			                        <td>&nbsp;</td>
			                        <td><input type="submit" name="btsb1" value="Tampilkan" class="btn"></td>
		                        </tr>	
	                        </table>
                        </form>
                    </div>
                </div>
                <div class="col-md-12 col-md-offset-0">
                    <p></p>
                </div>
                <div class="col-lg-offset-8 col-md-2">
                    <label>&nbsp;</label>
                    <label>&nbsp;</label>
                </div>
                <div class="col-lg-offset-0 col-md-2">
                    <img src="../pos/images/print_version.gif">
                    <label>
                        &nbsp;&nbsp;
                        <a href="#">
                            <span onClick="javascript:window.open('stock_cetak.aspx?sort=<%=sort%>&menu_id=<%=session("menu_id")%>&page=<%=pg+1%>&pgview=<%=bg%>'
                                , 'HelpWindow','scrollbars=yes, resizable=yes, height=600, width=900')" style="text-decoration: none">
                                Print Report
                            </span>
                        </a>
                    </label>
                </div>
                <div class="col-md-12">
	                <div>
	                    <div class="row">
                            <div class="col-md-12">
			                    <div class="table-responsive">
				                    <table class="table table-condensed">
					                    <thead class="table table-bordered">
						                    <tr style="background-color:#CCC">
						                        <td style="width:5%;" class="table-bordered text-center"><strong>KODE</strong></td>
						                        <td class="table-bordered text-center" ><strong>NAMA PRODUK</strong></td>
						                        <td class="table-bordered text-center" >ON HAND STOCK</td>
						                        <td style="width:15%;" class="table-bordered text-center"><strong>PV</strong></td>
						                        <td style="width:15%;" class="table-bordered text-center"><p>TOTAL PV</p></td>
						                        <td style="width:15%;" class="table-bordered text-center">HARGA KONSUMEN</td>
						                        <td style="width:15%;" class="table-bordered text-center">HARGA DISTRIBUTOR</td>
						                    </tr>
				                        </thead>
					                    <tbody class="table table-bordered">
                                            <%
                                                totpv = 0
                                                If sort = "nama" Then
                                                    mlQuery = "SELECT * FROM " & namatabel & " where nopos like '" & mypos & "' and jumlah <> 0 order by nama"
                                                Else
                                                    If sort = "kode" Then
                                                        mlQuery = "SELECT * FROM " & namatabel & " where nopos like '" & mypos & "' and jumlah <> 0 order by kode"
                                                    Else
                                                        If sort = "jumlah" Then
                                                            mlQuery = "SELECT * FROM " & namatabel & " where nopos like '" & mypos & "' and jumlah <> 0 order by jumlah DESC"
                                                        Else
                                                            If sort = "hd" Then
                                                                mlQuery = "SELECT * FROM " & namatabel & " where nopos like '" & mypos & "' and jumlah <> 0 order by hd1 desc, hd2 desc, hd3 desc"
                                                            Else
                                                                If sort = "hk" Then
                                                                    mlQuery = "SELECT * FROM " & namatabel & " where nopos like '" & mypos & "' and jumlah <> 0 order by hk1 desc, hk2 desc, hk3 desc"
                                                                Else
                                                                    If sort = "PV" Then
                                                                        mlQuery = "SELECT * FROM " & namatabel & " where nopos like '" & mypos & "' and jumlah <> 0 order by pv desc"
                                                                    Else
                                                                        If sort = "BV" Then
                                                                            mlQuery = "SELECT * FROM " & namatabel & " where nopos like '" & mypos & "' and jumlah <> 0 order by bv desc"
                                                                        Else
                                                                            mlQuery = "SELECT * FROM " & namatabel & " where nopos like '" & mypos & "' and jumlah <> 0 order by kode"
                                                                        End If
                                                                    End If
                                                                End If
                                                            End If
                                                        End If
                                                    End If
                                                End If

                                                mlDR = mlOBJGS.DbRecordset(mlQuery, mpMODULEID, mlCOMPANYID)
                                                If Not mlDR.HasRows Then
                                                %>
                                                <tr>
							                        <td colspan="8" class="table-bordered text-center">
                                                        <u style="color:#000000;">Anda belum memiliki stock produk</u>
							                        </td>
						                        </tr>
                                                <%
                                                    End If
                                                    If mlDR.HasRows Then
                                                        mlDT = New Data.DataTable
                                                        mlDT.Load(mlDR)
                                                        For aaaeqSSS = 1 To lumpat
                                                            PV = mlDT.Rows(aaaeqSSS)("pv")
                                                            bv = mlDT.Rows(aaaeqSSS)("bv")
                                                            jumlah = mlDT.Rows(aaaeqSSS)("jumlah")
                                                            kode = mlDT.Rows(aaaeqSSS)("kode")
                                                            gg = mlDT.Rows(aaaeqSSS)("grp")

                                                            If mlDT.Rows(aaaeqSSS)("jumlah") = 0 Or mlDT.Rows(aaaeqSSS)("jumlah") <= 0 Then
                                                                bgcolor = "#EFDEDE"
                                                            Else
                                                                bgcolor = "#FFFFFF"
                                                            End If

                                                            If gg = "PRD" Then
                                                                '''''''''''''''''''''''''''''''''''''''''''''''''''''''
                                                                ' POTONG STOCK YANG DIALOKASIKAN UNTUK STARTER KIT
                                                                '''''''''''''''''''''''''''''''''''''''''''''''''''''''
                                                                ggg = "AKT"
                                                                ggg1 = "UPG"
                                                                ggg2 = "REN"
                                                                jumlahalokakt = 0
                                                                mlQuery2 = "SELECT kode,jumlah FROM " & namatabel & " where nopos like '" & mypos & "' and (grp like '" & ggg & "' or grp like '" & ggg1 & "' or grp like '" & ggg2 & "')"
                                                                mlDR2 = mlOBJGS.DbRecordset(mlQuery2, mpMODULEID, mlCOMPANYID)
                                                                If mlDR2.HasRows Then
                                                                    mlDT2 = New Data.DataTable
                                                                    mlDT2.Load(mlDR2)
                                                                    For aaaeqSSSK = 1 To mlDT2.Rows.Count - 1
                                                                        kode1 = mlDT2.Rows(aaaeqSSSK)("kode")
                                                                        jumlah1 = mlDT2.Rows(aaaeqSSSK)("jumlah")

                                                                        mlQuery3 = "SELECT * FROM st_tipe_paket_jumlah where paket like '" & kode1 & "' and kode like '" & kode & "'"
                                                                        mlDR3 = mlOBJGS.DbRecordset(mlQuery3, mpMODULEID, mlCOMPANYID)
                                                                        mlDR3.Read()
                                                                        If Not mlDR3.HasRows Then
                                                                            jumakt = 0
                                                                        Else
                                                                            jumakt = mlDR3("jumlah")
                                                                        End If
                                                                        mlDR3.Close()

                                                                        jumpaket = (jumlah1 * jumakt)

                                                                        jumlahalokakt = jumlahalokakt + jumpaket
                                                                    Next
                                                                End If
                                                                mlDR2.Close()
                                                                jumbutuhakt = jumlahalokakt
                                                            Else
                                                                jumbutuhakt = 0
                                                            End If


                                                            kd1 = ""
                                                            jm1 = "0"
                                                            kd2 = ""
                                                            jm2 = "0"
                                                            kd3 = ""
                                                            jm3 = "0"
                                                            kd4 = ""
                                                            jm4 = "0"
                                                            kd5 = ""
                                                            jm5 = "0"
                                                            kd6 = ""
                                                            jm6 = "0"
                                                            kd7 = ""
                                                            jm7 = "0"
                                                            kd8 = ""
                                                            jm8 = "0"
                                                            kd9 = ""
                                                            jm9 = "0"
                                                            kd10 = ""
                                                            jm10 = "0"
                                                            kd11 = ""
                                                            jm11 = "0"
                                                            kd12 = ""
                                                            jm12 = "0"
                                                            jumreal = jumlah - jumbutuhakt

                                                            If gg = "AKT" Or gg = "UPG" Or gg = "REN" Then
                                                                jumreal = jumlah - jumbutuhakt
                                                                ggg = "AKT"
                                                                kebrapa = 0
                                                                mlQuery2 = "SELECT kode,jumlah FROM st_tipe_paket_jumlah where paket like '" & kode & "'"
                                                                mlDR2 = mlOBJGS.DbRecordset(mlQuery2, mpMODULEID, mlCOMPANYID)
                                                                If mlDR2.HasRows Then
                                                                    mlDT2 = New Data.DataTable
                                                                    mlDT2.Load(mlDR2)
                                                                    For aaaeqSSSK = 1 To mlDT2.Rows.Count - 1
                                                                        If kebrapa = 0 Then
                                                                            kd1 = mlDT2.Rows(aaaeqSSSK)("kode")
                                                                            jm1 = mlDT2.Rows(aaaeqSSSK)("jumlah") * jumreal
                                                                            kd2 = ""
                                                                            jm2 = "0"
                                                                            kd3 = ""
                                                                            jm3 = "0"
                                                                            kd4 = ""
                                                                            jm4 = "0"
                                                                            kd5 = ""
                                                                            jm5 = "0"
                                                                            kd6 = ""
                                                                            jm6 = "0"
                                                                            kd7 = ""
                                                                            jm7 = "0"
                                                                            kd8 = ""
                                                                            jm8 = "0"
                                                                            kd9 = ""
                                                                            jm9 = "0"
                                                                            kd10 = ""
                                                                            jm10 = "0"
                                                                            kd11 = ""
                                                                            jm11 = "0"
                                                                            kd12 = ""
                                                                            jm12 = "0"
                                                                        Else
                                                                            If kebrapa = 1 Then
                                                                                kd2 = mlDT2.Rows(aaaeqSSSK)("kode")
                                                                                jm2 = mlDT2.Rows(aaaeqSSSK)("jumlah") * jumreal
                                                                                kd3 = ""
                                                                                jm3 = "0"
                                                                                kd4 = ""
                                                                                jm4 = "0"
                                                                                kd5 = ""
                                                                                jm5 = "0"
                                                                                kd6 = ""
                                                                                jm6 = "0"
                                                                                kd7 = ""
                                                                                jm7 = "0"
                                                                                kd8 = ""
                                                                                jm8 = "0"
                                                                                kd9 = ""
                                                                                jm9 = "0"
                                                                                kd10 = ""
                                                                                jm10 = "0"
                                                                                kd11 = ""
                                                                                jm11 = "0"
                                                                                kd12 = ""
                                                                                jm12 = "0"
                                                                            Else
                                                                                If kebrapa = 2 Then
                                                                                    kd3 = mlDT2.Rows(aaaeqSSSK)("kode")
                                                                                    jm3 = mlDT2.Rows(aaaeqSSSK)("jumlah") * jumreal
                                                                                    kd4 = ""
                                                                                    jm4 = "0"
                                                                                    kd5 = ""
                                                                                    jm5 = "0"
                                                                                    kd6 = ""
                                                                                    jm6 = "0"
                                                                                    kd7 = ""
                                                                                    jm7 = "0"
                                                                                    kd8 = ""
                                                                                    jm8 = "0"
                                                                                    kd9 = ""
                                                                                    jm9 = "0"
                                                                                    kd10 = ""
                                                                                    jm10 = "0"
                                                                                    kd11 = ""
                                                                                    jm11 = "0"
                                                                                    kd12 = ""
                                                                                    jm12 = "0"
                                                                                Else
                                                                                    If kebrapa = 3 Then
                                                                                        kd4 = mlDT2.Rows(aaaeqSSSK)("kode")
                                                                                        jm4 = mlDT2.Rows(aaaeqSSSK)("jumlah") * jumreal
                                                                                        kd5 = ""
                                                                                        jm5 = "0"
                                                                                        kd6 = ""
                                                                                        jm6 = "0"
                                                                                        kd7 = ""
                                                                                        jm7 = "0"
                                                                                        kd8 = ""
                                                                                        jm8 = "0"
                                                                                        kd9 = ""
                                                                                        jm9 = "0"
                                                                                        kd10 = ""
                                                                                        jm10 = "0"
                                                                                        kd11 = ""
                                                                                        jm11 = "0"
                                                                                        kd12 = ""
                                                                                        jm12 = "0"
                                                                                    Else
                                                                                        If kebrapa = 4 Then
                                                                                            kd5 = mlDT2.Rows(aaaeqSSSK)("kode")
                                                                                            jm5 = mlDT2.Rows(aaaeqSSSK)("jumlah") * jumreal
                                                                                            kd6 = ""
                                                                                            jm6 = "0"
                                                                                            kd7 = ""
                                                                                            jm7 = "0"
                                                                                            kd8 = ""
                                                                                            jm8 = "0"
                                                                                            kd9 = ""
                                                                                            jm9 = "0"
                                                                                            kd10 = ""
                                                                                            jm10 = "0"
                                                                                            kd11 = ""
                                                                                            jm11 = "0"
                                                                                            kd12 = ""
                                                                                            jm12 = "0"
                                                                                        Else
                                                                                            If kebrapa = 5 Then
                                                                                                kd6 = mlDT2.Rows(aaaeqSSSK)("kode")
                                                                                                jm6 = mlDT2.Rows(aaaeqSSSK)("jumlah") * jumreal
                                                                                                kd7 = ""
                                                                                                jm7 = "0"
                                                                                                kd8 = ""
                                                                                                jm8 = "0"
                                                                                                kd9 = ""
                                                                                                jm9 = "0"
                                                                                                kd10 = ""
                                                                                                jm10 = "0"
                                                                                                kd11 = ""
                                                                                                jm11 = "0"
                                                                                                kd12 = ""
                                                                                                jm12 = "0"
                                                                                            Else
                                                                                                If kebrapa = 6 Then
                                                                                                    kd7 = mlDT2.Rows(aaaeqSSSK)("kode")
                                                                                                    jm7 = mlDT2.Rows(aaaeqSSSK)("jumlah") * jumreal
                                                                                                    kd8 = ""
                                                                                                    jm8 = "0"
                                                                                                    kd9 = ""
                                                                                                    jm9 = "0"
                                                                                                    kd10 = ""
                                                                                                    jm10 = "0"
                                                                                                    kd11 = ""
                                                                                                    jm11 = "0"
                                                                                                    kd12 = ""
                                                                                                    jm12 = "0"
                                                                                                Else
                                                                                                    If kebrapa = 7 Then
                                                                                                        kd8 = mlDT2.Rows(aaaeqSSSK)("kode")
                                                                                                        jm8 = mlDT2.Rows(aaaeqSSSK)("jumlah") * jumreal
                                                                                                        kd9 = ""
                                                                                                        jm9 = "0"
                                                                                                        kd10 = ""
                                                                                                        jm10 = "0"
                                                                                                        kd11 = ""
                                                                                                        jm11 = "0"
                                                                                                        kd12 = ""
                                                                                                        jm12 = "0"
                                                                                                    Else
                                                                                                        If kebrapa = 8 Then
                                                                                                            kd9 = mlDT2.Rows(aaaeqSSSK)("kode")
                                                                                                            jm9 = mlDT2.Rows(aaaeqSSSK)("jumlah") * jumreal
                                                                                                            kd10 = ""
                                                                                                            jm10 = "0"
                                                                                                            kd11 = ""
                                                                                                            jm11 = "0"
                                                                                                            kd12 = ""
                                                                                                            jm12 = "0"
                                                                                                        Else
                                                                                                            If kebrapa = 9 Then
                                                                                                                kd10 = mlDT2.Rows(aaaeqSSSK)("kode")
                                                                                                                jm10 = mlDT2.Rows(aaaeqSSSK)("jumlah") * jumreal
                                                                                                                kd11 = ""
                                                                                                                jm11 = "0"
                                                                                                                kd12 = ""
                                                                                                                jm12 = "0"
                                                                                                            Else
                                                                                                                If kebrapa = 10 Then
                                                                                                                    kd11 = mlDT2.Rows(aaaeqSSSK)("kode")
                                                                                                                    jm11 = mlDT2.Rows(aaaeqSSSK)("jumlah") * jumreal
                                                                                                                    kd12 = ""
                                                                                                                    jm12 = "0"
                                                                                                                Else
                                                                                                                    If kebrapa = 11 Then
                                                                                                                        kd12 = mlDT2.Rows(aaaeqSSSK)("kode")
                                                                                                                        jm12 = mlDT2.Rows(aaaeqSSSK)("jumlah") * jumreal
                                                                                                                    End If
                                                                                                                End If
                                                                                                            End If
                                                                                                        End If
                                                                                                    End If
                                                                                                End If
                                                                                            End If
                                                                                        End If
                                                                                    End If
                                                                                End If
                                                                            End If
                                                                        End If
                                                                        kebrapa = kebrapa + 1
                                                                    Next
                                                                End If
                                                                mlDR2.Close()
                                                            End If

                                                            If pos_area = "1" Then
                                                                hd = mlDT.Rows(aaaeqSSS)("hd1")
                                                                hk = mlDT.Rows(aaaeqSSS)("hk1")
                                                                kusus1 = mlDT.Rows(aaaeqSSS)("khususmc1")
                                                                hppku = 0
                                                                hpp = 0
                                                                If UCase(kelasdc) = "M" And kusus1 <> 0 Then
                                                                    hppku = kusus1
                                                                Else
                                                                    pot = ((PV * disk_mc) / 100) * kurs
                                                                    hpp = hd - pot
                                                                End If
                                                            End If

                                                            If pos_area = "2" Then
                                                                hd = mlDT.Rows(aaaeqSSS)("hd2")
                                                                hk = mlDT.Rows(aaaeqSSS)("hk2")
                                                                kusus2 = mlDT.Rows(aaaeqSSS)("khususmc2")
                                                                hppku = 0
                                                                hpp = 0
                                                                If UCase(kelasdc) = "M" And kusus2 <> 0 Then
                                                                    hppku = kusus2
                                                                Else
                                                                    pot = ((PV * disk_mc) / 100) * kurs
                                                                    hpp = hd - pot
                                                                End If
                                                            End If

                                                            If pos_area = "3" Then
                                                                hd = mlDT.Rows(aaaeqSSS)("hd3")
                                                                hk = mlDT.Rows(aaaeqSSS)("hk3")
                                                                kusus3 = mlDT.Rows(aaaeqSSS)("khususmc3")
                                                                hppku = 0
                                                                hpp = 0
                                                                If UCase(kelasdc) = "M" And kusus3 <> 0 Then
                                                                    hppku = kusus3
                                                                Else
                                                                    pot = ((PV * disk_mc) / 100) * kurs
                                                                    hpp = hd - pot
                                                                End If
                                                            End If

                                                            If pos_area = "4" Then
                                                                hd = mlDT.Rows(aaaeqSSS)("hd4")
                                                                hk = mlDT.Rows(aaaeqSSS)("hk4")
                                                                kusus4 = mlDT.Rows(aaaeqSSS)("khususmc4")
                                                                hppku = 0
                                                                hpp = 0
                                                                If UCase(kelasdc) = "M" And kusus4 <> 0 Then
                                                                    hppku = kusus4
                                                                Else
                                                                    pot = ((PV * disk_mc) / 100) * kurs
                                                                    hpp = hd - pot
                                                                End If
                                                            End If

                                                            If pos_area = "5" Then
                                                                hd = mlDT.Rows(aaaeqSSS)("hd5")
                                                                hk = mlDT.Rows(aaaeqSSS)("hk5")
                                                                kusus5 = mlDT.Rows(aaaeqSSS)("khususmc5")
                                                                hppku = 0
                                                                hpp = 0
                                                                If UCase(kelasdc) = "M" And kusus5 <> 0 Then
                                                                    hppku = kusus5
                                                                Else
                                                                    pot = ((PV * disk_mc) / 100) * kurs
                                                                    hpp = hd - pot
                                                                End If
                                                            End If

                                                            totpv = totpv + (PV * jumreal)
                                                %>
                                                <tr>
							                        <td class="table-bordered text-left">
                                                        &nbsp;&nbsp;<a href="<%=mlDT.Rows(aaaeqSSS)("adv_page")%>" onClick="NewWindow(this.href,'name','700','600','yes');return false"><%=mlDT.Rows(aaaeqSSS)("kode")%></a>
							                        </td>
							                        <td class="table-bordered text-left">
                                                        &nbsp;&nbsp;
                                                        <a href="<%=mlDT.Rows(aaaeqSSS)("adv_page")%>" onClick="NewWindow(this.href,'name','700','600','yes');return false"><%=mlDT.Rows(aaaeqSSS)("nama")%></a>
														<% If kd1 <> "" Then%>
														<br>&nbsp;&nbsp;Terdiri dari : <br>
															&nbsp;&nbsp;<%=kd1%> = <%=FormatNumber(jm1, 0)%>
														<%End If%>

                                                        <%If kd2 <> "" Then %>
															<br>&nbsp;&nbsp;<%=kd2%> = <%=FormatNumber(jm2, 0)%>
														<%End If%>
                                                        <%If kd3 <> "" Then %>																
															<br>&nbsp;&nbsp;<%=kd3%> = <%=FormatNumber(jm3, 0)%>
														<%End If%>
                                                        <%If kd4 <> "" Then %>																
															<br>&nbsp;&nbsp;<%=kd4%> = <%=FormatNumber(jm4, 0)%>
														<%End If%>
                                                        <%If kd5 <> "" Then %>																
															<br>&nbsp;&nbsp;<%=kd5%> = <%=FormatNumber(jm5, 0)%>
														<%End If%>
                                                        <%If kd6 <> "" Then %>																
															<br>&nbsp;&nbsp;<%=kd6%> = <%=FormatNumber(jm6, 0)%>
														<%End If%>
                                                        <%If kd7 <> "" Then %>																
															<br>&nbsp;&nbsp;<%=kd7%> = <%=FormatNumber(jm7, 0)%>
														<%End If%>
                                                        <%If kd8 <> "" Then %>																
															<br>&nbsp;&nbsp;<%=kd8%> = <%=FormatNumber(jm8, 0)%>
														<%End If%>
                                                        <%If kd9 <> "" Then %>																
															<br>&nbsp;&nbsp;<%=kd9%> = <%=FormatNumber(jm9, 0)%>
														<%End If%>
                                                        <%If kd10 <> "" Then %>																
															<br>&nbsp;&nbsp;<%=kd10%> = <%=FormatNumber(jm10, 0)%>
														<%End If%>
                                                        <%If kd11 <> "" Then %>																
															<br>&nbsp;&nbsp;<%=kd11%> = <%=FormatNumber(jm11, 0)%>
														<%End If%>
                                                        <%If kd12 <> "" Then %>																
															<br>&nbsp;&nbsp;<%=kd12%> = <%=FormatNumber(jm12, 0)%>
														<%End If%>						
							                        </td>
							                        <td class="table-bordered text-right">
                                                        <%if gg = "PRD" then %>
														<a href="kartustock.aspx?id=<%=mlDT.Rows(aaaeqSSS)("kode")%>&menu_id=<%=session("menu_id")%>"><%=FormatNumber(jumlah - jumbutuhakt, 0)%></a>&nbsp;&nbsp;
														<%else%>
														<a href="kartustock.aspx?id=<%=mlDT.Rows(aaaeqSSS)("kode")%>&menu_id=<%=session("menu_id")%>"><%=jumlah%></a>&nbsp;&nbsp;
														<%end if%>
							                        </td>
							                        <td class="table-bordered text-right"><%=FormatNumber(PV, 2)%>&nbsp;&nbsp;</td>
							                        <td class="table-bordered text-right">
                                                        <%if gg = "PRD" then %>
                                                            <%=FormatNumber(PV * (jumlah - jumbutuhakt), 2)%>&nbsp;&nbsp;
                                                        <%else%>
                                                            <%=FormatNumber(PV * jumlah, 2)%>&nbsp;&nbsp;
                                                        <%end if%>																
							                        </td>
							                        <td class="table-bordered text-right">Rp <%=FormatNumber(hk, 0)%>,-&nbsp;&nbsp;</td>
							                        <td class="table-bordered text-right">Rp <%=FormatNumber(hd, 0)%>,-&nbsp;&nbsp;</td>
							                    </tr>
                                                <%
                                                        Next
                                                    End If
                                                    mlDR.Close()
                                                %>
						                        <tr>
						                            <td colspan="4" class="table-bordered text-right"><b>Total PV&nbsp;&nbsp;&nbsp; </b></td>
						                            <td class="table-bordered text-right"><b><%=FormatNumber(totpv, 2)%></b></td>
						                            <td colspan="3" class="table-bordered text-right">&nbsp;</td>
					                            </tr>
					                    </tbody>
				  				    </table>
			                    </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div style="padding: 20px 20px 20px 20px">
            <div class="col-md-6">
                <label></label>
            </div>
        </div>
        <div style="padding: 20px 20px 20px 20px">
            <div class="col-md-6">
                <label></label>
            </div>
        </div>
    </section>
</asp:Content>

