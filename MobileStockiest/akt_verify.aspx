<%@ Page Title="" Language="VB" MasterPageFile="~/pagesetting/MsPageMS.master" AutoEventWireup="false" CodeFile="akt_verify.aspx.vb" Inherits="MobileStockiest_akt_verify" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script>
        document.write(unescape("%3Cscript%20language%3DJavaScript%3E%0D%0A%3C%21--%0D%0Avar%20message%3D%22%22%3B%0D%0A///////////////////////////////////%0D%0Afunction%20clickIE%28%29%20%7Bif%20%28document.all%29%20%7B%28message%29%3Breturn%20false%3B%7D%7D%0D%0Afunction%20clickNS%28e%29%20%7Bif%20%0D%0A%28document.layers%7C%7C%28document.getElementById%26%26%21document.all%29%29%20%7B%0D%0Aif%20%28e.which%3D%3D2%7C%7Ce.which%3D%3D3%29%20%7B%28message%29%3Breturn%20false%3B%7D%7D%7D%0D%0Aif%20%28document.layers%29%20%0D%0A%7Bdocument.captureEvents%28Event.MOUSEDOWN%29%3Bdocument.onmousedown%3DclickNS%3B%7D%0D%0Aelse%7Bdocument.onmouseup%3DclickNS%3Bdocument.oncontextmenu%3DclickIE%3B%7D%0D%0A%0D%0Adocument.oncontextmenu%3Dnew%20Function%28%22return%20false%22%29%0D%0A//%20--%3E%20%0D%0A%3C/script%3E"));
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mpCONTENT" Runat="Server">
    <section class="content-header" style="background-color:white;">
        <div class="panel panel-default" style="margin: 10px 10px 10px 10px">
            <form name="theform" method="post" action="akt_aknow.asp" onSubmit="submitonce(this)">
                <div class="panel-heading">
                    <h3 class="text-center panel-title">KONFIRMASI DATA PENDAFTARAN</h3>
                </div>
                <div class="panel-body">
			        <div>
				        <div class="panel panel-default">
                            <div class="panel-heading">
                                <h3 class="panel-title">INFORMASI</h3>
                            </div>
                            <div class="panel-body">
                                <div class="col-md-12" style="padding: 5px 0px 5px 0px">
							        <span>Silahkan periksa ulang data pendaftaran distrributor baru yang telah anda masukan dibawah ini. Apabila semua sudah benar maka silahkan lanjutkan proses pendaftaran ini dengan mengkik tombol SIMPAN DATA dibawah
                                        , namun apabila ada kesalahan pengisian data atau ada perubahan pengisian data, maka silahkan klilk link <-- Kembali --> dibawah. <label style="color:#FF0000;"> <b>
                                            Segala konsekuensi yang diakibatkan oleh karena kesalahan pemasukan data sepenuhnya menjadi tanggung jawab distributor yang bersangkutan dan tidak dapat dilakukan revisi. </b></label></span>
                                </div>
                            </div>
                        </div>
			        </div>
			
                    <div>
                        <div class="panel panel-default">
                            <div class="panel-heading">
                                <h3 class="panel-title">INFORMASI PAKET PENDAFTARAN</h3>
                            </div>
                            <div class="panel-body">
                                <div class="col-md-12" style="padding: 5px 0px 5px 0px">
                                    <div class="col-md-2"><span>Nomor Distributor</span></div>
                                    <div class="col-md-8">
                                        <input type="hidden" name="noinvo" value="<%=noinvo%>">
                                        <input type="text" class="form-control" name="noseri" readonly onKeyDown="if(event.keyCode==13) event.keyCode=9;" value="<%=ncrd%>">
                                    </div>
                                    <div class="col-md-2"><%=error1%></div>
                                </div>
                                <div class="col-md-12" style="padding: 5px 0px 5px 0px">
                                    <div class="col-md-2"><span>Tipe Paket Pendaftaran</span></div>
                                    <div class="col-md-8">
                                        <input type="text" class="form-control" name="paket" readonly onKeyDown="if(event.keyCode==13) event.keyCode=9;" value="<%=paket%>">
                                    </div>
                                    <div class="col-md-2"><%=error2%></div>
                                </div>
                                <div class="col-md-12" style="padding: 5px 0px 5px 0px">
                                    <div class="col-md-2"><span>Jumlah Business Center</span></div>
                                    <div class="col-md-8">
                                        <input type="text" class="form-control" readonly name="jumbc" id="jumbc" value="<%=jumbc%>">
                                    </div>
                                    <div class="col-md-2"><%=error3%></div>
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
                                    <div class="col-md-8">
                                        <input type="text" class="form-control" readonly name="nama" onKeyDown="if(event.keyCode==13) event.keyCode=9;" value="<%=nama%>">
                                    </div>
                                    <div class="col-md-2"><%=error6%></div>
                                </div>
                                <div class="col-md-12" style="padding: 5px 0px 5px 0px">
                                    <div class="col-md-2"><span>No. Identitas (KTP/SIM)</span></div>
                                    <div class="col-md-8">
                                        <input type="text" class="form-control" readonly name="ktp" onKeyDown="if(event.keyCode==13) event.keyCode=9;" value="<%=nktp%>">
                                    </div>
                                    <div class="col-md-2"><%=error7%></div>
                                </div>
                                <div class="col-md-12" style="padding: 5px 0px 5px 0px">
                                    <div class="col-md-2"><span>Jenis Kelamin</span></div>
                                    <div class="col-md-8">
                                        <input type="text" class="form-control" readonly name="kelamin" onKeyDown="if(event.keyCode==13) event.keyCode=9;" value="<%=kelamin%>">
                                    </div>
                                    <div class="col-md-2"><%=error8%></div>
                                </div>
                                <div class="col-md-12" style="padding: 5px 0px 5px 0px">
                                    <div class="col-md-2"><span>Tanggal Lahir</span></div>
                                    <div class="col-md-2">
                                        <input type="text" class="form-control" readonly name="tgllahir" onKeyDown="if(event.keyCode==13) event.keyCode=9;" value="<%=tgllahir%>">
                                    </div>
                                    <div class="col-md-1">/</div>
                                    <div class="col-md-2">
                                        <input type="text" class="form-control" readonly name="bulanlahir" onKeyDown="if(event.keyCode==13) event.keyCode=9;" value="<%=bulanlahir%>">
                                    </div>
                                    <div class="col-md-1">/</div>
                                    <div class="col-md-2">
                                        <input type="text" class="form-control" readonly name="tahunlahir" onKeyDown="if(event.keyCode==13) event.keyCode=9;" value="<%=tahunlahir%>">
                                    </div>
                                    <div class="col-md-2"><%=error9%></div>
                                </div>
                                <div class="col-md-12" style="padding: 5px 0px 5px 0px">
                                    <div class="col-md-2"><span>Alamat Lengkap</span></div>
                                    <div class="col-md-8">
                                        <textarea readonly name="alamat" class="form-control"><%=alamat%></textarea>
                                    </div>
                                    <div class="col-md-2"><%=error10%></div>
                                </div>
                                <div class="col-md-12" style="padding: 5px 0px 5px 0px">
                                    <div class="col-md-2"><span>Kota</span></div>
                                    <div class="col-md-8">
                                        <input type="text" class="form-control" readonly name="kota" onKeyDown="if(event.keyCode==13) event.keyCode=9;" value="<%=kota%>">
                                    </div>
                                    <div class="col-md-2"><%=error11%></div>
                                </div>
                                <div class="col-md-12" style="padding: 5px 0px 5px 0px">
                                    <div class="col-md-2"><span>Propinsi</span></div>
                                    <div class="col-md-8">
                                        <input type="text" class="form-control" readonly name="propinsi" onKeyDown="if(event.keyCode==13) event.keyCode=9;" value="<%=propinsi%>">
                                    </div>
                                    <div class="col-md-2"><%=error12%></div>
                                </div>
                                <div class="col-md-12" style="padding: 5px 0px 5px 0px">
                                    <div class="col-md-2"><span>Kode pos</span></div>
                                    <div class="col-md-8">
                                        <input type="text" class="form-control" readonly name="kodepos" onKeyDown="if(event.keyCode==13) event.keyCode=9;" value="<%=kodepos%>">
                                    </div>
                                    <div class="col-md-2"><%=error13%></div>
                                </div>
                                <div class="col-md-12" style="padding: 5px 0px 5px 0px">
                                    <div class="col-md-2"><span>Alamat Surat Menyurat</span></div>
                                    <div class="col-md-8">
                                        <textarea class="form-control" readonly name="surat"><%=surat%></textarea>
                                    </div>
                                    <div class="col-md-2"><%=error14%></div>
                                </div>
                                <div class="col-md-12" style="padding: 5px 0px 5px 0px">
                                    <div class="col-md-2"><span>Kota</span></div>
                                    <div class="col-md-8">
                                        <input type="text" class="form-control" readonly name="kotasurat" onKeyDown="if(event.keyCode==13) event.keyCode=9;" value="<%=kotasurat%>">
                                    </div>
                                    <div class="col-md-2"><%=error15%></div>
                                </div>
                                <div class="col-md-12" style="padding: 5px 0px 5px 0px">
                                    <div class="col-md-2"><span>Propinsi </span></div>
                                    <div class="col-md-8">
                                        <input type="text" class="form-control" readonly name="propinsisurat" onKeyDown="if(event.keyCode==13) event.keyCode=9;" value="<%=propinsisurat%>">
                                    </div>
                                    <div class="col-md-2"><%=error16%></div>
                                </div>
                                <div class="col-md-12" style="padding: 5px 0px 5px 0px">
                                    <div class="col-md-2"><span>Kode pos</span></div>
                                    <div class="col-md-8">
                                        <input type="text" class="form-control" readonly name="kodepossurat" onKeyDown="if(event.keyCode==13) event.keyCode=9;" value="<%=kodepossurat%>">
                                    </div>
                                    <div class="col-md-2"><%=error17%></div>
                                </div>
                                <div class="col-md-12" style="padding: 5px 0px 5px 0px">
                                    <div class="col-md-2"><span>Nomor Telepon</span></div>
                                    <div class="col-md-8">
                                        <input type="text" class="form-control" readonly name="notelp" onKeyDown="if(event.keyCode==13) event.keyCode=9;" value="<%=notelp%>">
                                    </div>
                                    <div class="col-md-2"><%=error18%></div>
                                </div>
                                <div class="col-md-12" style="padding: 5px 0px 5px 0px">
                                    <div class="col-md-2"><span>Nomor HP</span></div>
                                    <div class="col-md-8">
                                        <input type="text" class="form-control" readonly name="nohape" onKeyDown="if(event.keyCode==13) event.keyCode=9;" value="<%=nohape%>">
                                    </div>
                                    <div class="col-md-2"><%=error19%></div>
                                </div>
                                <div class="col-md-12" style="padding: 5px 0px 5px 0px">
                                    <div class="col-md-2"><span>Nama Suami / Istri</span></div>
                                    <div class="col-md-8">
                                        <input type="text" class="form-control" readonly name="pasangan" onKeyDown="if(event.keyCode==13) event.keyCode=9;">
                                    </div>
                                    <div class="col-md-2"><%=error20%></div>
                                </div>
                                <div class="col-md-12" style="padding: 5px 0px 5px 0px">
                                    <div class="col-md-2"><span>Nama Ahli Waris</span></div>
                                    <div class="col-md-8">
                                        <input type="text" class="form-control" readonly name="ahliwaris" onKeyDown="if(event.keyCode==13) event.keyCode=9;" value="<%=ahliwaris%>">
                                    </div>
                                    <div class="col-md-2"><%=error21%></div>
                                </div>
                                <div class="col-md-12" style="padding: 5px 0px 5px 0px">
                                    <div class="col-md-2"><span>Hubungan </span></div>
                                    <div class="col-md-8">
                                       <input type="text" class="form-control" readonly name="hubwaris" onKeyDown="if(event.keyCode==13) event.keyCode=9;" value="<%=hubwaris%>">
                                    </div>
                                    <div class="col-md-2"><%=error22%></div>
                                </div>
						        <div class="col-md-12" style="padding: 5px 0px 5px 0px">
                                    <div class="col-md-2"><span>Alamat Email</span></div>
                                    <div class="col-md-8">
                                        <input type="email" class="form-control" name="email" readonly onKeyDown="if(event.keyCode==13) event.keyCode=9;" value="<%=emel%>">
                                    </div>
                                    <div class="col-md-2"><%=error22a%></div>
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
                                    <div class="col-md-8">
                                        <input type="text" class="form-control" readonly name="direk" id="direk" onKeyDown="if(event.keyCode==13) event.keyCode=9;" value="<%=direk%>">
                                    </div>
                                    <div class="col-md-2"><%=error23%></div>
                                </div>
                                <div class="col-md-12" style="padding: 5px 0px 5px 0px">
                                    <div class="col-md-2"><span>Nama Distributor Sponsor</span></div>
                                    <div class="col-md-8">
                                        <input type="text" class="form-control" readonly name="namadirek" id="namadirek" onKeyDown="if(event.keyCode==13) event.keyCode=9;" value="<%=namadirek%>">
                                    </div>
                                    <div class="col-md-2"><%=error24%></div>
                                </div>
						        <div class="col-md-12" style="padding: 5px 0px 5px 0px">
                                    <div class="col-md-2"><span>No Telepon.</span></div>
                                    <div class="col-md-8">
                                        <input type="text" class="form-control" readonly name="telpdirek" onKeyDown="if(event.keyCode==13) event.keyCode=9;" value="<%=telpdirek%>">
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
					            <div class="col-md-12" style="padding: 5px 0px 5px 0px">
                                    <div class="col-md-2"><span>Mode Penempatan</span></div>
                                    <div class="col-md-8">
                                        <input type="text" class="form-control" readonly name="tempat" onKeyDown="if(event.keyCode==13) event.keyCode=9;" value="<%=piye%>">
                                    </div>
                                    <div class="col-md-2"><%=error25%></div>
                                </div>
                                <div class="col-md-12" style="padding: 5px 0px 5px 0px">
                                    <div class="col-md-2"><span>No Id. Distributor Upline</span></div>
                                    <div class="col-md-4">
                                        <input type="text" class="form-control" readonly name="alo" onKeyDown="if(event.keyCode==13) event.keyCode=9;" value="<%=aloc%>">
                                    </div>
                                    <div class="col-md-4">
                                        <input type="text" class="form-control" readonly name="namaalo" onKeyDown="if(event.keyCode==13) event.keyCode=9;" value="<%=namaalo%>">
                                    </div>
                                    <div class="col-md-2"><%=error26%></div>
                                </div>
						        <div class="col-md-12" style="padding: 5px 0px 5px 0px">
                                    <div class="col-md-2"><span>Posisi Kaki</span></div>
                                    <div class="col-md-8">
                                        <input type="text" class="form-control" readonly name="pos" value="<%=pose%>">
                                    </div>
                                </div>
						        <div class="col-md-12" style="padding: 5px 0px 5px 0px">
                                     <%if error27 <> "" or error28 <>"" or error29 <>"" then %>
                                    <span><b>Ada Kesalahan pada penempatan seksi upline, silahkan perbaiki kesalahan berikut ini:</b></span><br>
                                        <%if error27 <> "" then %>
										<label style="color:#FF0000;"><%=error27%></label><br>
										<%end If
                                            If error28 <> "" Then %>
										<label style="color:#FF0000;"><%=error28%></label><br>	
										<%End If
                                            If error29 <> "" Then %>		
										<label style="color:#FF0000;"><%=error29%></label><br>		
										<%End If%>
                                    <%end if%>
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
                                    <div class="col-md-8">
                                        <input type="text" class="form-control" name="namarek" readonly onKeyDown="if(event.keyCode==13) event.keyCode=9;" value="<%=namarek%>">
                                    </div>
                                    <div class="col-md-2"><%=error30%></div>
                                </div>
                                <div class="col-md-12" style="padding: 5px 0px 5px 0px">
                                    <div class="col-md-2"><span>Nama Bank Anda</span></div>
                                    <div class="col-md-8">
                                        <input type="text" class="form-control" name="namabank" readonly onKeyDown="if(event.keyCode==13) event.keyCode=9;" value="<%=bnk%>">
                                    </div>
                                    <div class="col-md-2"><%=error31%></div>
                                </div>
						        <div class="col-md-12" style="padding: 5px 0px 5px 0px">
                                    <div class="col-md-2"><span>Nomor Rekening</span></div>
                                    <div class="col-md-8">
                                        <input type="text" class="form-control" readonly name="norek" onKeyDown="if(event.keyCode==13) event.keyCode=9;" value="<%=nrk%>">
                                    </div>
                                    <div class="col-md-2"><%=error32%></div>
                                </div>
                            </div>
                        </div>
                    </div>
			        <% 
                        If ((l1 = "Ter1") And (l2 = "Ter2") And (l3 = "Ter3") And (l4 = "Ter4") And (l5 = "Ter5") And (l6 = "Ter6") And (l7 = "Ter7") _
                            And (l8 = "Ter8") And (l9 = "Ter9") And (l10 = "Ter10") And (l11 = "Ter11") And (l12 = "Ter12") And (l13 = "Ter13") _
                            And (l14 = "Ter14") And (l15 = "Ter15") And (l16 = "Ter16") And (l17 = "Ter17") And (l18 = "Ter18") And (l19 = "Ter19") _
                            And (l20 = "Ter20") And (l21 = "Ter21") And (l22 = "Ter22") And (l22a = "Ter22a") And (l23 = "Ter23") And (l24 = "Ter24") _
                            And (l25 = "Ter25") And (l26 = "Ter26") And (l27 = "Ter27") And (l28 = "Ter28") And (l29 = "Ter29") And (l30 = "Ter30") And (l31 = "Ter31") And (l32 = "Ter32")) Then %>
                    <div>
                        <input class="btn btn-default" type="submit" name="btakt" value="Daftarkan">
				        <span>pendaftaran ini tidak bisa dibatalkan setelah anda menekan tombol 'Daftarkan'</span>
                    </div>
                    <%else%>
			        <br>
			        <div>
                        <a href="javascript:history.back( )"><-- Kembali --></a>
                    </div>
                    <%end if%>
                    <% if ((l1 = "Ter1") And (l2 = "Ter2") And (l3 = "Ter3") And (l4 = "Ter4") And (l5 = "Ter5") And (l6 = "Ter6") And (l7 = "Ter7") _
                And (l8 = "Ter8") And (l9 = "Ter9") And (l10 = "Ter10") And (l11 = "Ter11") And (l12 = "Ter12") And (l13 = "Ter13") _
                And (l14 = "Ter14") And (l15 = "Ter15") And (l16 = "Ter16") And (l17 = "Ter17") And (l18 = "Ter18") And (l19 = "Ter19") _
                And (l20 = "Ter20") And (l21 = "Ter21") And (l22 = "Ter22") And (l22a = "Ter22a") And (l23 = "Ter23") And (l24 = "Ter24") _
                And (l25 = "Ter25") And (l26 = "Ter26") And (l27 = "Ter27") And (l28 = "Ter28") And (l29 = "Ter29") And (l30 = "Ter30") And (l31 = "Ter31") And (l32 = "Ter32")) Then %>
                    <div>
                        <a href="javascript:history.back( )"><-- Kembali --></a>
                    </div>
                    <%end if%> 
			        <div class="text-center">
                        <span><label style="color:#FF0000;"><b>Jangan tutup atau keluar dari halaman ini sebelum proses pendaftaran selesai dilakukan.<br>
				        </b></label>Mengingat proses update jaringan berlangsung secara realtime, maka apabila anda mengalami permasalahan pada saat pendaftaran, 
				        <br>mohon catat nomor id distributor dan segera laporkan kepada kantor pusat.</span>
                    </div>
                </div>
            </form>
        </div>
    </section>
</asp:Content>

