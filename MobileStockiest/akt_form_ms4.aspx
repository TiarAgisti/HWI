<%@ Page Title="" Language="VB" MasterPageFile="~/pagesetting/MsPageMS.master" AutoEventWireup="false" CodeFile="akt_form_ms4.aspx.vb" Inherits="MobileStockiest_akt_form_ms4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
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
    </style>
    <style>
        A:hover {font-size: 11px; color: #FF9966; font-family: Tahoma; text-decoration: underline}
    </style>

    <script type='text/javascript'>
        function createRequestObject() {
           var ro;
           var browser = navigator.appName;
           if(browser == "Microsoft Internet Explorer"){
               ro = new ActiveXObject("Microsoft.XMLHTTP");
           }else{
               ro = new XMLHttpRequest();
           }
           return ro;
        }
        var xmlhttp = createRequestObject();
        function cari(teks)
        {
           var kode = teks.value;
           if (!kode) return;
           xmlhttp.open('get', 'getdataakt1.asp?kode='+kode, true);
           xmlhttp.onreadystatechange = function() {
               if ((xmlhttp.readyState == 4) && (xmlhttp.status == 200))
               {
                    var r = xmlhttp.responseXML.getElementsByTagName('data');                         
                    document.getElementById("jumbc").value = r[1].firstChild.data; 
                    document.getElementById("kop").value = r[2].firstChild.data;  
                    document.getElementById("namapaket").value = r[3].firstChild.data;                         
               }
               return false;
           }
           xmlhttp.send(null);
        }

        function cari2(teks)
        {
           var kode = teks.value;
           if (!kode) return;
           xmlhttp.open('get', 'getdatadirek.asp?kode='+kode, true);
           xmlhttp.onreadystatechange = function() {
               if ((xmlhttp.readyState == 4) && (xmlhttp.status == 200))
               {
                    var r = xmlhttp.responseXML.getElementsByTagName('data');                         
                    document.getElementById("namadirek").value = r[1].firstChild.data;  
                    document.getElementById("telpdirek").value = r[2].firstChild.data;              
               }
               return false;
           }
           xmlhttp.send(null);
        }

        function cari3(teks)
        {
           var kode = teks.value;
           if (!kode) return;
           xmlhttp.open('get', 'getdataupline.asp?kode='+kode, true);
           xmlhttp.onreadystatechange = function() {
               if ((xmlhttp.readyState == 4) && (xmlhttp.status == 200))
               {
                    var r = xmlhttp.responseXML.getElementsByTagName('data');                         
                    document.getElementById("namaupline").value = r[1].firstChild.data;  
                    document.getElementById("telpupline").value = r[2].firstChild.data;              
               }
               return false;
           }
           xmlhttp.send(null);
        }
    </script>

    <script type='text/javascript'>
        function formCheck(form) {
            if (form.noseri.value == "")
            {
                alert("Mohon isikan nomor distributor");
                return false;
            }

            if (form.paket.value == "")
            {
                alert("Mohon pilih paket pendaftarannya");
                return false;
            }

            if (form.paket.value == "--Silahkan Pilih--")
            {
                alert("Silahkan pilih paket pendaftarannya");
                return false;
            }

            if (form.jumbc.value == 0)
            {
                alert("Silahkan pilih paket pendaftarannya");
                return false;
            }

            if (form.direk.value == "")
            {
                alert("Silahkan tulis nomor id distributor sponsor");
                return false;
            }

            if (form.direk.value == "NOT FOUND")
            {
                alert("Silahkan tulis nomor id distributor sponsor");
                return false;
            }

            if (confirm("Cek sekali lagi, apakah data yang Anda isi SUDAH BENAR semuanya ? \n\nPaket Pendaftaran : "+ form.paket.value+"\nSponsor : "+ form.direk.value+"\nUpline : "+ form.upline.value+"\n")) {
                return true;
            }
            else {
                return false;
            }
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mpCONTENT" Runat="Server">
    <section class="content-header" style="background-color: white;">
        <div class="panel panel-default" style="margin: 10px 10px 10px 10px">
            <div class="panel-heading">
                <h3 class="text-center panel-title">FORMULIR PENDAFTARAN</h3>
            </div>
            <div class="panel-body">
                <form name="theform" method="post" action="akt_verify_ms4.aspx" onSubmit="return formCheck(this)">
                    <div>
                        <div class="panel panel-default">
                            <div class="panel-heading">
                                <h3 class="panel-title">INFORMASI PAKET PENDAFTARAN</h3>
                            </div>
                            <div class="panel-body">
                                <div class="col-md-12" style="padding: 5px 0px 5px 0px">
                                    <div class="col-md-2"><span>Nomor Distributor</span></div>
                                    <div class="col-md-1"><span>:</span></div>
						            <div class="col-md-7">
                                        <input type="hidden" name="noinvo" value="<%=noinvo%>">
                                        <%if noser <> "" then %>
										<input type="text" name="noseri" readonly onKeyDown="if(event.keyCode==13) event.keyCode=9;" value="<%=noser%>">
										<%else%>					
										<input type="text" name="noseri" onKeyDown="if(event.keyCode==13) event.keyCode=9;">
										<%end if%>
                                    </div>
                                    <div class="col-md-2"><span><%=error1%></span></div>
                                </div>
                                <div class="col-md-12" style="padding: 5px 0px 5px 0px">
                                    <div class="col-md-2"><span>Tipe Paket Pendaftaran</span></div>
                                    <div class="col-md-1"><span>:</span></div>
							        <div class="col-md-7">
                                         <%if noser <> "" Then%>
                                        <input type="text" class="form-control" name="paket" readonly onKeyDown="if(event.keyCode==13) event.keyCode=9;" value="<%=paket%>">
                                        <%else%>
                                        <select class="form-control" name="paket" id="paket" onKeyDown="if(event.keyCode==13) event.keyCode=9;">
                                            <optgroup label="Paket Pendaftaran">
                                                 <%
                                                     pp = "PRG"
                                                     minimal = 0
                                                     mlQuery = "SELECT kode,nama FROM st_barang WHERE kode like '" & pp & "'"
                                                     mlDR = mlOBJGS.DbRecordset(mlQuery, mpMODULEID, mlCOMPANYID)
                                                     If mlDR.HasRows Then
                                                         mlDT = New Data.DataTable
                                                         mlDT.Load(mlDR)
                                                         For aaaeqsK = 1 To mlDT.Rows.Count - 1
                                                %>
                                                        <option value="<%=mlDT.Rows(aaaeqsK)("kode")%>"><%=mlDT.Rows(aaaeqsK)("nama")%></option> 
                                                <%
                                                        Next
                                                    End If
                                                    mlDR.Close()
                                                %>	
                                            </optgroup>
                                        </select>
									    <%end if%>
                                    </div>
                                    <div class="col-md-2"><span><%=error2%></span></div>
                                </div>
                                <div class="col-md-12" style="padding: 5px 0px 5px 0px">
                                    <div class="col-md-2"><span>Jumlah Business Center</span></div>
                                    <div class="col-md-1"><span>:</span></div>
                                    <div class="col-md-9">
                                        <input type="text" class="form-control" name="jumbc" id="jumbc" value="<%=jumbc%>">
                                    </div>
                                    <div class="col-md-2"><span><%=error3%></span></div>
                                    <input type="hidden" id="kop" name="kop">
                                    <input type="hidden" id="namapaket" name="namapaket">
                                </div>
                            </div>
                        </div>
                    </div>
			
                    <div>
                        <div class="panel panel-default">
                            <div class="panel-heading">
                                <h3 class="panel-title">INFORMASI DISTRIBUTOR</h3>
                            </div>
                            <div class="panel-body">
                                <div class="col-md-12" style="padding: 5px 0px 5px 0px">
                                    <div class="col-md-2"><span>Nama Lengkap</span></div>
							        <div class="col-md-1"><span>:</span></div>
                                    <div class="col-md-7">
                                        <%if noser <> "" then %>
                                        <input type="text" class="form-control" name="nama" readonly onKeyDown="if(event.keyCode==13) event.keyCode=9;" value="<%=nama%>">
                                        <%else%>
                                        <input type="text" class="form-control" name="nama" onKeyDown="if(event.keyCode==13) event.keyCode=9;">
                                        <%end if%>
                                    </div>
                                    <div class="col-md-2">
                                        <span><%=error6%></span>
                                    </div>
                                </div>
                                <div class="col-md-12" style="padding: 5px 0px 5px 0px">
                                    <div class="col-md-2"><span>No. Identitas (KTP/SIM)</span></div>
							        <div class="col-md-1"><span>:</span></div>
                                    <div class="col-md-7">
                                        <input type="text" class="form-control" name="ktp" onKeyDown="if(event.keyCode==13) event.keyCode=9;" value="00000">
                                    </div>
                                    <div class="col-md-2"><span><%=error7%></span></div>
                                </div>
                                <div class="col-md-12" style="padding: 5px 0px 5px 0px">
                                    <div class="col-md-2"><span>Jenis Kelamin</span></div>
							        <div class="col-md-1"><span>:</span></div>
                                    <div class="col-md-7">
                                        <select class="form-control" name="kelamin" onKeyDown="if(event.keyCode==13) event.keyCode=9;">
                                            <optgroup label="Jenis Kelamin">
                                                <%
                                                    pp = "kel"
                                                    mlQuery = "SELECT * FROM tabdesc WHERE grp like '" & pp & "' order by deskripsi"
                                                    mlDR = mlOBJGS.DbRecordset(mlQuery, mpMODULEID, mlCOMPANYID)
                                                    If mlDR.HasRows Then
                                                        mlDT = New Data.DataTable
                                                        mlDT.Load(mlDR)
                                                        For aaaeqsK = 1 To mlDT.Rows.Count - 1
                                                %>
                                                        <option value="<%=mlDT.Rows(aaaeqsK)("deskripsi")%>"><%=mlDT.Rows(aaaeqsK)("deskripsi")%></option> 
                                                <%
                                                        Next
                                                    End If
                                                    mlDR.Close()

                                                %>	
                                            </optgroup>
                                        </select>
                                    </div>
                                    <div class="col-md-2"><span><%=error8%></span></div>
                                </div>
                                <div class="col-md-12" style="padding: 5px 0px 5px 0px">
                                    <div class="col-md-2"><span>Tanggal Lahir</span></div>
							        <div class="col-md-1"><span>:</span></div>
                                    <div class="col-md-1">
                                        <select class="form-control" name="tgllahir" onKeyDown="if(event.keyCode==13) event.keyCode=9;">
                                            <optgroup label="TANGGAL">
                                                <%
                                                    kl = 0
                                                    For aax = 1 To 62
                                                        kl = kl + 1
                                                %>														
													    <%if blnskr = kl Then %>
														<option value="<%=kl%>" selected><%=kl%></option>
														<%else%>
														<option value="<%=kl%>"><%=kl%></option>
														<%end If%>
                                                <%
                                                        If aax > 62 Then
                                                            Exit For
                                                        End If
                                                        aax = aax + 1
                                                    Next
                                                %>	
                                            </optgroup>
                                        </select>
                                    </div>
                                    <div class="col-md-1">
                                         <label class="text-center">/</label>
                                    </div>
                                    <div class="col-md-1">
                                        <select class="form-control" name="bulanlahir" onKeyDown="if(event.keyCode==13) event.keyCode=9;">
                                            <optgroup label="BULAN">
                                                <%
                                                    kl = 0
                                                    For aax = 1 to 24
                                                        kl = kl + 1
                                                %>														
														<%if blnskr = kl then %>
														<option value="<%=kl%>" selected><%=kl%></option>
														<%else%>
														<option value="<%=kl%>"><%=kl%></option>
														<%end if%>
                                                <%
                                                        If aax > 24 Then
                                                            Exit For
                                                        End If
                                                        aax = aax + 1
                                                    Next
                                                %>	
                                            </optgroup>
                                        </select>
                                    </div>
                                    <div class="col-md-1">
                                         <label class="text-center">/</label>
                                    </div>
                                    <div class="col-md-1">
                                        <select class="form-control" name="tahunlahir">
                                            <optgroup label="TAHUN">
                                                <%
                                                    kl = 1930
                                                    For aax = 1 to 150
                                                        kl = kl + 1
                                                %>														
																	<%if thnskr = kl Then %>
																	<option value="<%=kl%>" selected><%=kl%></option>
																	<%else%>
																	<option value="<%=kl%>"><%=kl%></option>
																	<%end If%>
                                                <%
                                                        if aax > 150 Then
                                                            Exit For
                                                        End If
                                                        aax = aax+1
                                                    Next
                                                %>	
                                            </optgroup>
                                        </select>
                                    </div>
                                    <div class="col-md-4">
                                        <span><%=error9%></span>
                                    </div>
                                </div>
                                <div class="col-md-12" style="padding: 5px 0px 5px 0px">
                                   <div class="col-md-2"><span>Alamat Lengkap</span></div>
							        <div class="col-md-1"><span>:</span></div>
                                     <div class="col-md-7">
                                        <textarea class="form-control" name="alamat"></textarea>
                                    </div>
                                    <div class="col-md-2">
                                        <span><%=error10%></span>
                                    </div>
                                </div>
                                <div class="col-md-12" style="padding: 5px 0px 5px 0px">
                                    <div class="col-md-2"><span>Kota</span></div>
							        <div class="col-md-1"><span>:</span></div>
                                    <div class="col-md-7">
                                        <input type="text" class="form-control" name="kota" onKeyDown="if(event.keyCode==13) event.keyCode=9;" >
                                    </div>
                                    <div class="col-md-2">
                                        <span><%=error11%></span>
                                    </div>
                                </div>
                                <div class="col-md-12" style="padding: 5px 0px 5px 0px">
                                    <div class="col-md-2"><span>Propinsi </span></div>
							        <div class="col-md-1"><span>:</span></div>
                                    <div class="col-md-7">
                                        <select class="form-control" name="propinsi" onKeyDown="if(event.keyCode==13) event.keyCode=9;">
                                            <optgroup label="Propinsi 1">
                                                <%
                                                    pp = "prp"
                                                    mlQuery = "SELECT * FROM tabdesc WHERE grp like '" & pp & "' order by deskripsi"
                                                    mlDR = mlOBJGS.DbRecordset(mlQuery, mpMODULEID, mlCOMPANYID)
                                                    If mlDR.HasRows Then
                                                        mlDT = New Data.DataTable
                                                        mlDT.Load(mlDR)
                                                        For aaaeqsK = 1 To mlDT.Rows.Count - 1
                                                 %>
                                                            <%if prop_dc = mlDT.Rows(aaaeqsK)("deskripsi") Then %>
                                                            <option value="<%=mlDT.Rows(aaaeqsK)("deskripsi")%>" selected><%=mlDT.Rows(aaaeqsK)("deskripsi")%></option>
                                                            <%Else%>
                                                            <option value="<%=mlDT.Rows(aaaeqsK)("deskripsi")%>"><%=mlDT.Rows(aaaeqsK)("deskripsi")%></option>
                                                            <%End If%> 
                                                 <%
                                                         Next
                                                     End If
                                                     mlDR.Close()
                                                %>		
                                            </optgroup>
                                        </select>
                                    </div>
                                    <div class="col-md-2">
                                        <span><%=error12%></span>
                                    </div>
                                </div>
                                <div class="col-md-12" style="padding: 5px 0px 5px 0px">
                                    <div class="col-md-2"><span>Kode Pos </span></div>
							        <div class="col-md-1"><span>:</span></div>
                                    <div class="col-md-7">
                                        <input type="text" class="form-control" name="kodepos" onKeyDown="if(event.keyCode==13) event.keyCode=9;">
                                    </div>
                                    <div class="col-md-2">
                                        <span><%=error13%></span>
                                    </div>
                                </div>
                                <div class="col-md-12" style="padding: 5px 0px 5px 0px">
                                    <div class="col-md-2"><span>Alamat Surat Menyurat</span></div>
							        <div class="col-md-1"><span>:</span></div>
                                     <div class="col-md-7">
                                        <textarea class="form-control" name="surat"></textarea>
                                    </div>
                                    <div class="col-md-2">
                                        <span><%=error14%></span>
                                    </div>
                                </div>
                                <div class="col-md-12" style="padding: 5px 0px 5px 0px">
                                    <div class="col-md-2"><span>Kota</span></div>
							        <div class="col-md-1"><span>:</span></div>
                                    <div class="col-md-7">
                                        <input type="text" class="form-control" name="kotasurat" onKeyDown="if(event.keyCode==13) event.keyCode=9;">
                                    </div>
                                    <div class="col-md-2">
                                        <span><%=error15%></span>
                                    </div>
                                </div>
                                <div class="col-md-12" style="padding: 5px 0px 5px 0px">
                                     <div class="col-md-2"><span>Propinsi</span></div>
							        <div class="col-md-1"><span>:</span></div>
                                    <div class="col-md-7">
                                        <select class="form-control" name="propinsisurat" onKeyDown="if(event.keyCode==13) event.keyCode=9;">
                                            <optgroup label="propinsi surat">
                                               <%
                                                   pp = "prp"
                                                   mlQuery = "SELECT * FROM tabdesc WHERE grp like '" & pp & "' order by deskripsi"
                                                   mlDR = mlOBJGS.DbRecordset(mlQuery, mpMODULEID, mlCOMPANYID)
                                                   If mlDR.HasRows Then
                                                       mlDT = New Data.DataTable
                                                       mlDT.Load(mlDR)
                                                       For aaaeqsK = 1 To mlDT.Rows.Count - 1
                                                 %>
                                                            <%if prop_dc = mlDT.Rows(aaaeqsK)("deskripsi") Then %>
                                                            <option value="<%=mlDT.Rows(aaaeqsK)("deskripsi")%>" selected><%=mlDT.Rows(aaaeqsK)("deskripsi")%></option>
                                                            <%Else%>
                                                            <option value="<%=mlDT.Rows(aaaeqsK)("deskripsi")%>"><%=mlDT.Rows(aaaeqsK)("deskripsi")%></option>
                                                            <%End If%> 
                                                 <%
                                                         Next
                                                     End If
                                                     mlDR.Close()
                                                %>		
                                            </optgroup>
                                        </select>
                                    </div>
                                     <div class="col-md-2">
                                        <span><%=error16%></span>
                                    </div>
                                </div>
                                <div class="col-md-12" style="padding: 5px 0px 5px 0px">
                                    <div class="col-md-2"><span>Kode Pos </span></div>
							        <div class="col-md-1"><span>:</span></div>
                                    <div class="col-md-7">
                                        <input type="text" class="form-control" name="kodepossurat" onKeyDown="if(event.keyCode==13) event.keyCode=9;">
                                    </div>
                                    <div class="col-md-2">
                                        <span><%=error17%></span>
                                    </div>
                                </div>
                                <div class="col-md-12" style="padding: 5px 0px 5px 0px">
                                    <div class="col-md-2"><span>Nomor Telepon</span></div>
							        <div class="col-md-1"><span>:</span></div>
                                    <div class="col-md-7">
                                        <input type="text" class="form-control" name="notelp" onKeyDown="if(event.keyCode==13) event.keyCode=9;">
                                    </div>
                                    <div class="col-md-2">
                                        <span><%=error18%></span>
                                    </div>
                                </div>
                                <div class="col-md-12" style="padding: 5px 0px 5px 0px">
                                    <div class="col-md-2"><span>No. Handphone</span></div>
							        <div class="col-md-1"><span>:</span></div>
                                    <div class="col-md-7">
                                        <input type="text" class="form-control" name="nohape" onKeyDown="if(event.keyCode==13) event.keyCode=9;">
                                    </div>
                                    <div class="col-md-2">
                                        <span><%=error19%></span>
                                    </div>
                                </div>
                                <div class="col-md-12" style="padding: 5px 0px 5px 0px">
                                    <div class="col-md-2"><span>Nama Suami / Istri</span></div>
							        <div class="col-md-1"><span>:</span></div>
                                    <div class="col-md-7">
                                        <input type="text" class="form-control" name="pasangan" onKeyDown="if(event.keyCode==13) event.keyCode=9;">
                                    </div>
                                    <div class="col-md-2">
                                        <span><%=error20%></span>
                                    </div>
                                </div>
                                <div class="col-md-12" style="padding: 5px 0px 5px 0px">
                                    <div class="col-md-2"><span>Nama Ahli Waris</span></div>
							        <div class="col-md-1"><span>:</span></div>
                                    <div class="col-md-7">
                                        <input type="text" class="form-control" name="ahliwaris" onKeyDown="if(event.keyCode==13) event.keyCode=9;">
                                        <input type="hidden" name="menu_id" value="<%=session("menu_id")%>">
                                    </div>
                                    <div class="col-md-2">
                                        <span><%=error21%></span>
                                    </div>
                                </div>
                                <div class="col-md-12" style="padding: 5px 0px 5px 0px">
                                    <div class="col-md-2"><span>Hubungan</span></div>
							        <div class="col-md-1"><span>:</span></div>
                                    <div class="col-md-7">
                                        <select class="form-control" name="hubwaris" onKeyDown="if(event.keyCode==13) event.keyCode=9;">
                                            <optgroup label="hubungan waris">
                                                <%
                                                    pp = "wrs"
                                                    mlQuery = "SELECT * FROM tabdesc WHERE grp like '" & pp & "' order by deskripsi"
                                                    mlDR = mlOBJGS.DbRecordset(mlQuery, mpMODULEID, mlCOMPANYID)
                                                    If mlDR.HasRows Then
                                                        mlDT = New Data.DataTable
                                                        mlDT.Load(mlDR)
                                                        For aaaeqsK = 1 To mlDT.Rows.Count - 1
                                                 %>
                                                           <option value="<%=mlDT.Rows(aaaeqsK)("deskripsi")%>"><%=mlDT.Rows(aaaeqsK)("deskripsi")%></option> 
                                                 <%
                                                         Next
                                                     End If
                                                     mlDR.Close()
                                                %>		
                                            </optgroup>
                                        </select>
                                    </div>
                                    <div class="col-md-2">
                                        <span><%=error22%></span>
                                    </div>
                                </div>
						        <div class="col-md-12" style="padding: 5px 0px 5px 0px">
                                    <div class="col-md-2"><span>Alamat Email</span></div>
                                    <div class="col-md-1"><span>:</span></div>
                                    <div class="col-md-7">
                                        <input type="text" class="form-control" name="email" onKeyDown="if(event.keyCode==13) event.keyCode=9;" >
                                    </div>
                                    <div class="col-md-2">
                                        <span><%=error20%></span>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
			
                    <div>
                        <div class="panel panel-default">
                            <div class="panel-heading">
                                <h3 class="panel-title">INFORMASI SPONSOR</h3>
                            </div>
                            <div class="panel-body">
                                <div class="col-md-12" style="padding: 5px 0px 5px 0px">
                                    <div class="col-md-2"><span>No. Id Distributor Sponsor</span></div>
							        <div class="col-md-1"><span>:</span></div>
                                    <div class="col-md-7">
                                        <input type="text" class="form-control" readonly name="direk" id="direk" onChange="javascript:cari2(this)" onKeyDown="if(event.keyCode==13) event.keyCode=9;" value="<%=direk%>">
                                    </div>
                                    <div class="col-md-2">
                                        <span><%=error23%></span>
                                    </div>
                                </div>
                                <div class="col-md-12" style="padding: 5px 0px 5px 0px">
                                    <div class="col-md-2"><span>Nama Distributor Sponsor</span></div>
							        <div class="col-md-1"><span>:</span></div>
                                    <div class="col-md-7">
                                        <input type="text" class="form-control" readonly name="namadirek" id="namadirek" onKeyDown="if(event.keyCode==13) event.keyCode=9;" value="<%=namadirek%>">
                                    </div>
                                    <div class="col-md-2">
                                        <span><%=error24%></span>
                                    </div>
                                </div>
						        <div class="col-md-12" style="padding: 5px 0px 5px 0px">
                                    <div class="col-md-2"><span>No. Telepon</span></div>
							        <div class="col-md-1"><span>:</span></div>
                                    <div class="col-md-7">
                                        <input type="text" class="form-control" readonly name="telpdirek" id="notelp" onKeyDown="if(event.keyCode==13) event.keyCode=9;" value="<%=telpdirek%>">
                                    </div>
                                    <div class="col-md-2">
                                        <span><%=error25%></span>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
			
                    <div>
                        <div class="panel panel-default">
                            <div class="panel-heading">
                                <h3 class="panel-title">INFORMASI PENEMPATAN</h3>
                            </div>
                            <div class="panel-body">
                                <%if direk = alok then %>
                                <div class="col-md-12" style="padding: 5px 0px 5px 0px">
                                    <div class="col-md-12">
                                        <div class="radio">
                                            <label>
                                                <input type="radio">Penempatan Otomatis dibawah Sponsor
                                            </label>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-12" style="padding: 5px 0px 5px 0px">
                                    <div class="col-md-2"><span>Kaki</span></div>
							        <div class="col-md-1"><span>:</span></div>
                                    <div class="col-md-9">
                                        <input type="text" class="form-control" readonly name="kakidireke" value="<%=kaki%>">
                                        <input type="hidden" name="kakidirek" value="<%=kakiku%>">
                                    </div>
                                </div>
                                <%end if%>
                                <%if direk <> alok Then %>
                                <div class="col-md-12" style="padding: 5px 0px 5px 0px">
                                    <div class="col-md-12">
                                        <div class="radio">
                                            <label><input type="radio" value="upline" name="tempat" CHECKED>Penempatan dibawah upline distributor berikut</label>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-12" style="padding: 5px 0px 5px 0px">
                                    <div class="col-md-2"><span>No. Id Distributor Upline</span></div>
							        <div class="col-md-1"><span>:</span></div>
                                    <div class="col-md-7">
                                        <input type="text" class="form-control" readonly name="upline" id="upline" onchange="javascript:cari3(this)" onKeyDown="if(event.keyCode==13) event.keyCode=9;" value="<%=aloc%>">
                                    </div>
                                    <div class="col-md-2">
                                        <span><%=error26%></span>
                                    </div>
                                </div>
						        <div class="col-md-12" style="padding: 5px 0px 5px 0px">
                                    <div class="col-md-2"><span>Nama Distributor Upline</span></div>
							        <div class="col-md-1"><span>:</span></div>
                                    <div class="col-md-7">
                                        <input type="text" class="form-control" name="namaupline" id="namaupline" readonly onKeyDown="if(event.keyCode==13) event.keyCode=9;" value="<%=namaalo%>">
                                    </div>
                                    <div class="col-md-2">
                                        <span><%=error27%></span>
                                    </div>
                                </div>
                                <div class="col-md-12" style="padding: 5px 0px 5px 0px">
                                    <div class="col-md-2"><span>No. Telepon</span></div>
							        <div class="col-md-1"><span>:</span></div>
                                    <div class="col-md-7">
                                        <input type="text" class="form-control" name="telpupline" id="telpupline" readonly onKeyDown="if(event.keyCode==13) event.keyCode=9;" value="<%=notelpalo%>">
                                    </div>
                                    <div class="col-md-2">
                                        <span><%=error28%></span>
                                    </div>
                                </div>
						        <div class="col-md-12" style="padding: 5px 0px 5px 0px">
                                    <div class="col-md-2"><span>Kaki</span></div>
							        <div class="col-md-1"><span>:</span></div>
                                    <div class="col-md-7">
                                        <input type="text" class="form-control"  readonly name="kakiuplinee" value="<%=kaki%>">
                                        <input type="hidden" name="kakiupline" value="<%=kakiku%>">
                                    </div>
                                </div>
                                <%End IF%>
                                <div class="col-md-12" style="padding: 5px 0px 5px 0px">
                                    <%if error29 <> "" then %>
                                    <span><%=error29%></span>
                                    <%end If%>
                                </div>
                            </div>
                        </div>
                    </div>
			
                    <div>
                        <div class="panel panel-default">
                            <div class="panel-heading">
                                <h3 class="panel-title">INFORMASI DATA BANK DAN NPWP</h3>
                            </div>
                            <div class="panel-body">
                                <div class="col-md-12" style="padding: 5px 0px 5px 0px">
                                    <div class="col-md-2"><span>Nama Lengkap Nasabah</span></div>
							        <div class="col-md-1"><span>:</span></div>
                                    <div class="col-md-7">
                                        <input type="text" class="form-control" name="namarek"  onKeyDown="if(event.keyCode==13) event.keyCode=9;">
                                    </div>
                                    <div class="col-md-2">
                                        <span><%=error30%></span>
                                    </div>
                                </div>
                                <div class="col-md-12" style="padding: 5px 0px 5px 0px">
                                    <div class="col-md-2"><span>Nama Bank Anda</span></div>
							        <div class="col-md-1"><span>:</span></div>
                                    <div class="col-md-7">
                                        <select class="form-control">
                                            <optgroup label="">
                                                <%
                                                    pp = "bnk"
                                                    mlQuery = "SELECT * FROM tabdesc WHERE grp like '" & pp & "' order by deskripsi"
                                                    mlDR = mlOBJGS.DbRecordset(mlQuery, mpMODULEID, mlCOMPANYID)
                                                    If mlDR.HasRows Then
                                                        mlDT = New Data.DataTable
                                                        mlDT.Load(mlDR)
                                                        For aaaeqsK = 1 To mlDT.Rows.Count - 1
                                                 %>
                                                            <%if mlDT.Rows(aaaeqsK)("deskripsi") = "BCA" Then %>
                                                            <option value="<%=mlDT.Rows(aaaeqsK)("deskripsi")%>" selected><%=mlDT.Rows(aaaeqsK)("deskripsi")%></option> 
                                                            <% Else%>
                                                            <option value="<%=mlDT.Rows(aaaeqsK)("deskripsi")%>"><%=mlDT.Rows(aaaeqsK)("deskripsi")%></option> 
                                                            <%End If%> 
                                                 <%
                                                         Next
                                                     End If
                                                     mlDR.Close()
                                                %>		
                                            </optgroup>
                                        </select>
                                    </div>
                                    <div class="col-md-2">
                                        <span><%=error31%></span>
                                    </div>
                                </div>
						        <div class="col-md-12" style="padding: 5px 0px 5px 0px">
                                    <div class="col-md-2"><span>Nomor Rekening</span></div>
							        <div class="col-md-1"><span>:</span></div>
                                    <div class="col-md-7">
                                        <input type="text" class="form-control" name="norek" onKeyDown="if(event.keyCode==13) event.keyCode=9;">
                                    </div>
                                    <div class="col-md-2">
                                        <span><%=error32%></span>
                                    </div>
                                </div>
                                <div class="col-md-12" style="padding: 5px 0px 5px 0px">
                                    <div class="col-md-2"><span>Nomor NPWP</span></div>
                                    <div class="col-md-1">
                                        <input type="text" name="npwp" class="form-control" onKeyDown="if(event.keyCode==13) event.keyCode=9;" maxlength=15 value="-">
                                    </div>
                                    <div class="col-md-6">
                                        <label>isi dengan 15 angka</label>
                                        <label>*Fax/Emailkan/kirim copy kartu NPWP ke kantor pusat</label>
                                    </div>
                                    <div class="col-md-2">
                                        <span><%=error33%></span>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
			
                    <div>
                        <input class="btn btn-default" type="submit" name="btsb" value="Konfirmasi Data">
                    </div>
                </form>
            </div>
        </div>
        <div style="padding: 20px 20px 20px 20px">
            <div class="col-md-6">
                <label></label>
            </div>
        </div>
    </section>
</asp:Content>

