<%@ Page Title="" Language="VB" MasterPageFile="~/pagesetting/MsPageMS.master" AutoEventWireup="false" CodeFile="mc_prd_topup.aspx.vb" Inherits="MobileStockiest_mc_prd_topup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
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
           xmlhttp.open('get', 'getdataprd.aspx?kode='+kode, true);
           xmlhttp.onreadystatechange = function() {
               if ((xmlhttp.readyState == 4) && (xmlhttp.status == 200))
               {
                    var r = xmlhttp.responseXML.getElementsByTagName('data');
                    document.getElementById("nama").value = r[1].firstChild.data;                             
                    document.getElementById("harga").value = r[2].firstChild.data;             
                    document.getElementById("pv").value = r[3].firstChild.data; 
                    document.getElementById("bv").value = r[4].firstChild.data;                             
               }
               return false;
           }
           xmlhttp.send(null);
        }

        function cari2(teks)
        {
           var kode = teks.value;
           if (!kode) return;
           xmlhttp.open('get', 'getdatadist.aspx?kode='+kode, true);
           xmlhttp.onreadystatechange = function() {
               if ((xmlhttp.readyState == 4) && (xmlhttp.status == 200))
               {
                    var r = xmlhttp.responseXML.getElementsByTagName('data');                         
                    document.getElementById("namadis").value = r[1].firstChild.data;     
               }
               return false;
           }
           xmlhttp.send(null);
        }
        function cari3(teks)
        {
           var kode = teks.value;
           if (!kode) return;
           xmlhttp.open('get', 'getdatadist_topup.aspx?kode='+kode, true);
           xmlhttp.onreadystatechange = function() {
               if ((xmlhttp.readyState == 4) && (xmlhttp.status == 200))
               {
                    var r = xmlhttp.responseXML.getElementsByTagName('data');                         
                    document.getElementById("namadistopup").value = r[1].firstChild.data;     
               }
               return false;
           }
           xmlhttp.send(null);
        }
    </script>


    <script type='text/javascript'>
        function formCheck(form) {
            if (form.kode.value == "")
            {
                alert("Anda belum mengisikan kode produk");
                return false;
            }

            if (form.harga.value == 0)
            {
                alert("Anda belum memilih produk");
                return false;
            }

            if (form.jumlah.value == 0)
            {
                alert("Anda belum memasukan jumlah produk dibeli");
                return false;
            }

            if (confirm("Cek sekali lagi, apakah data yang Anda isi SUDAH BENAR semua ?\n\nKode Produk : "+ form.kode.value+"\nNama Produk : "+ form.nama.value+"\nJumlah : "+ form.jumlah.value+"\n")) {
                return true;
            }
            else {
                return false;
            }
        }
    </script>

    <script type='text/javascript'>
        function formCheck1(form) {
            if (form.kdpos.value == "")
            {
                alert("Anda belum mengisikan nomor distributor yang berbelanja");
                return false;
            }

            if (form.namadis.value == "")
            {
                alert("Anda belum mengisikan nomor distributor yang berbelanja");
                return false;
            }

            if (form.namadis.value == "NOT FOUND")
            {
                alert("Anda belum mengisikan nomor distributor yang berbelanja");
                return false;
            }

            if (form.jumtot.value == 0)
            {
                alert("Anda belum memasukan jumlah produk dibeli");
                return false;
            }

            if (form.jumbayar.value == 0)
            {
                alert("Anda belum memasukan jumlah pembayaran");
                return false;
            }

            if (form.kembalian.value < 0)
            {
                alert("Jumlah pembayaran anda masih kurang");
                return false;
            }

            if (confirm("Cek sekali lagi, apakah data yang Anda isikan SUDAH BENAR semua ? Semua transaksi yang sudah dibukukan (sudah checkout) tidak dapat dibatalkan dengan alasan apapun, karena proses posting PV/BV dilakukan secara realtime.\n\nNo. Id. Distributor : "+ form.kdpos.value+"\nNama Distributor : "+ form.namadis.value+"\nPembayaran "+ form.jumbayar.value+"\n")) {
                return true;
            }
            else {
                return false;
            }
        }
    </script>

    <script type='text/javascript'>
        function quadratic1(form1)
        {
            var harga = eval(form1.harga.value);
            var jumlah = eval(form1.jumlah.value);
            {
                form1.subtotal.value = jumlah*harga;
            }
        }
    </script>

    <script type='text/javascript'>
        function quadratic2(form1)
        {
            var tunai = eval(form1.jumbayarcash.value);
            var cc = eval(form1.jumbayarcc.value);
            var db = eval(form1.jumbayardb.value);
            var cek = eval(form1.jumbayarcek.value);
            var jto = eval(form1.jumtot.value);
            {
                form1.jumbayar.value = tunai+cc+db+cek;
                form1.kembalian.value = (tunai+cc+db+cek)-jto;
            }
        }
    </script>


    <SCRIPT type='text/javascript'>

<!-- This script and many more are available free online at -->
        var submitcount=0;

        function reset() {
            document.theform1.kdpos.value="";
            document.theform1.kdtopup.value="";
            document.theform1.namadis.value="";
            document.theform1.namadistopup.value="";
        }

        function checkFields() {                       // field validation -
            if ( (document.theform1.kdpos.value=="")  ||   // checks if fields are blank.
                 (document.theform1.namadis.value=="") ||   // More validation scripts at
                 (document.theform1.namadis.value=="NOT FOUND") ||   // More validation scripts at
                 (document.theform1.kdtopup.value=="") ||   // More validation scripts at   
                 (document.theform1.namadistopup.value=="") ||   // More validation scripts at
                 (document.theform1.namadistopup.value=="NOT FOUND") ||   // More validation scripts at         
                 (document.theform1.jumtot.value=="") ||   // More validation scripts at       
                 (document.theform1.jumbayar.value=="") ||   // More validation scripts at   
                 (document.theform1.kembalian.value=="") ||   // More validation scripts at   
                 (document.theform1.jumbayar.value=="NaN") ||   // More validation scripts at   
                 (document.theform1.kembalian.value=="NaN") ||   // More validation scripts at      
                 (document.theform1.jumtot.value==0) ||   // More validation scripts at       
                 (document.theform1.jumbayar.value==0) ||   // More validation scripts at           
                 (document.theform1.kembalian.value<0) ) // forms.javascriptsource.com
               {
                    alert("Mohon lengkapi form pembayaran terlebih dulu");
                    return false;
               }
            else{
                if (submitcount == 0)
                {
                  submitcount++;
                  return true;
                }
                else 
                {
                    alert("Form sedang diproses, silahkan tunggu hingga proses posting PV selesai dilakukan dengan munculnya invoice. Silahkan tutup pesan ini untuk melanjutkan proses posting PV.");
                    return false;
                }
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mpCONTENT" Runat="Server">
    <section class="content-header" style="background-color:white;">
        <div class="panel panel-default">
            <div class="panel-heading">
                <h3 class="text-center panel-title" style="text-align: center; color: black; font-family: Arial;"><strong>PENJUALAN PRODUK TOP UP</strong></h3>
            </div>
            <div class="panel-body">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h4 class="text-center panel-title" style="text-align:left;color:black;font-family:Arial;">(#1) PERHATIAN DAN PERATURAN TOP UP</h4>
                    </div>
                     <div class="panel-body">
                         <ol>
                            <li>Top up hanya dapat dilakukan oleh distributor yang sudah memiliki / belanja sebesar <b style="color:#FF0000;">200 pv</b>. Top up bukan proses tutup point, melainkan proses atau usaha untuk meraih kualifikasi / ranking pada periode ini.</li>
                            <li>Top up tidak dikenai split point, top up tidak menghasilkan productivity bonus.</li>
                            <li>Top up dialokasikan pada jajaran downline jaringan. Apabila anda mengalokasikan top up pada jaringan anda, pastikan anda sudah benar-benar mengalokasikannya pada downline yang sesuai (tidak salah kaki / group).<</li>
                            <li>Downline yang memperoleh alokasi top up memungkinkan memperoleh bonus apabila mencapai tutup point (200 pv) dan memang berhak memperoleh bonus sesuai quadro plan (alokasi top up tidak menghasilkan productivity bonus).</li>
                            <li>
                                Kesempatan top up dibuka mulai <label  style="color:#FF0000;"><%=tupoawal%></label><br>
					            Top up ditutup mulai <label style="color:#FF0000;"><%=tupoakhir%></label><br>
					            Sejak top up ditutup, maka kantor pusat sudah melakukan perhitungan bonus bulanan.Keterlambatan top up akan dimasukan pada pv bulan terdekat.
                            </li>
                        </ol>
                     </div>
                </div>
                <div class="panel panel-default">
                    <div class="panel-body">
                        <%if mesej <> "" Then %>
                        <div class="alert alert-warning text-center" role="alert">
                            <h4 style="text-align:center;color:black;font-family:Arial;">
                                <span>
                                    <span style="text-decoration: underline;"><b>ERROR MESSAGE</b></span><br />
                                    <label style="color:#FF0000;"><%=mesej%></label>
                                </span>
                            </h4>               
                        </div>
                        <%end if%>
                        <form name="theform" method="post" action="mc_prd_topup_add.asp" onSubmit="return formCheck(this)">
                            <div style="padding: 10px 5px 20px 5px">
                                <div class="col-md-4">
                                    <label>Tanggal Transaksi</label>
                                </div>
                                <div class="col-md-8">
                                    <input class="form-control" type="text" name="tgl" readonly onKeyDown="if(event.keyCode==13) event.keyCode=9;" value="<%=tgl%>">
                                </div>
			                </div>
                            <div style="padding: 20px 5px 20px 5px">
                                <div class="col-md-4">
                                    <label>Kode Produk</label>
                                </div>
                                <div class="col-md-5">
                                    <input class="form-control" type="text" name="kode" id="kode" onChange="javascript:cari(this)" onKeyDown="if(event.keyCode==13) event.keyCode=9;" maxlength="15">
                                </div>
				                <div class="col-md-3">
                                    <label>
                                        [<span onClick="javascript:window.open('../MobileStockiest/daftarkode.aspx?tipe=PRD', 'HelpWindow','scrollbars=yes, resizable=yes, height=500, width=300')">Tampilkan Kode</span>]
                                    </label>
                                </div>
			                </div>
                            <div style="padding: 20px 5px 20px 5px">
                                <div class="col-md-4">
                                    <label>Nama Produk</label>
                                </div>
                                <div class="col-md-8">
                                    <input class="form-control" type="text" name="nama" id="nama" readonly onKeyDown="if(event.keyCode==13) event.keyCode=9;">
                                </div>
			                </div>
                            <div style="padding: 20px 5px 20px 5px">
                                <div class="col-md-4">
                                    <label>Harga</label>
                                </div>
                                <div class="col-md-8">
                                    <input class="form-control" type="text" id="harga" name="harga" readonly onKeyDown="if(event.keyCode==13) event.keyCode=9;">
                                </div>
			                </div>
                            <div style="padding: 20px 5px 20px 5px">
                                <div class="col-md-4">
                                    <label>PV</label>
                                </div>
                                <div class="col-md-2">
                                    <input class="form-control" type="text" id="pv" name="pv" readonly onKeyDown="if(event.keyCode==13) event.keyCode=9;">
                                </div>

				                <div class="col-md-4">
                                    <label>BV</label>
                                </div>
                                <div class="col-md-2">
                                    <input class="form-control" type="text" id="bv" name="bv" readonly onKeyDown="if(event.keyCode==13) event.keyCode=9;">
                                </div>
			                </div>
                            <div style="padding: 20px 5px 20px 5px">
                                <div class="col-md-4">
                                    <label>Jumlah Pembelian</label>
                                </div>
                                <div class="col-md-8">
                                    <input class="form-control" type="text" name="jumlah" onchange="quadratic1(this.form);" value="0" maxlength="6">
                                </div>
			                </div>
                            <div style="padding: 20px 5px 20px 5px">
                                <div class="col-md-4">
                                    <label>Sub Total</label>
                                </div>
                                <div class="col-md-8">
                                    <input class="form-control" type="text" name="subtotal" readonly value="0">
                                </div>
			                </div>
                             <div style="padding: 20px 5px 20px 5px">
                                <div class="col-md-4">
                                    <label></label>
                                </div>
                                <div class="col-md-8">
                                    <%if jumskr < 7 and lanjutken = "T" then %>
                                    <input class="btn btn-default"  type="submit"  name="btsub" value="Add to Basket">
                                    <%else%>
                                        <%if jumskr < 7 and lanjutken = "F" then %>
                                    <p><br><span style="color: red; font-weight: bold">Kesempatan Top Up Belum dibuka 1 invoice maksimal berisi 7 item barang</span></p>
                                        <%end if%>
									<%end if%>
                                </div>
                            </div>
                        </form>
                     </div>
                 </div>
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h4 class="text-center panel-title" style="text-align:left;color:black;font-family:Arial;">(#2) KERANJANG BELANJAAN</h4>
                    </div>
                    <div class="panel-body">
                        <p>
                            Dibawah ini adalah daftar belanjaan top up saat ini. Anda dapat menghapus / membatalkan item belanjaan top up dibawah ini. 
                            Pembatalan item belanjaan top up hanya dapat dilakukan sebelum sesi belanja ini ditutup, sesi belanja ini ditutup dengan menekan tombol check out.
		                </p>
                        <div class="table-responsive">
			                <table class="table table-condensed table-bordered">
				                <thead>
					                <tr>
						                <td style="width:6%"><strong>Kode</strong></td>
						                <td style="width:29%;"><strong>Nama Produk</strong></td>
						                <td style="width:10%;"><strong>PV</strong></td>
						                <td style="width:9%;"><strong>BV</strong></td>
						                <td style="width:8%;"><strong>Qty.</strong></td>
						                <td style="width:13%;"><strong>Harga</strong></td>
						                <td style="width:20%;"><strong>Sub Total</strong></td>
						                <td style="width:5%;"><strong>Aksi</strong></td>
					                 </tr>
				                </thead>
				                <tbody>
                                    <%
                                        totpv = 0
                                        totbv = 0
                                        gtot = 0
                                        gtotnet = 0
                                        jumdisk = 0
                                        jumtotdis = 0
                                        brapadis = 0
                                        mlSQLFrontEnd = "SELECT * FROM st_sale_prd_det_tmp where nopos like '" & mypos & "' and nosesi like '" & nosesi & "' order by id"
                                        mlREADERFrontEnd = mlOBJGS.DbRecordset(mlSQLFrontEnd, mpMODULEID, mlCOMPANYID)
                                        If Not mlREADERFrontEnd.HasRows Then %>
					                <tr>
						                <td class="text-center" colspan="8"><span style="text-decoration: underline">Sesi ini belum ada belanjaan</span></td>
					                </tr>
                                    <% end if %>
                                    <%
                                        If mlREADERFrontEnd.HasRows Then
                                            mlDATATABLE = New Data.DataTable
                                            mlDATATABLE.Load(mlREADERFrontEnd)
                                            For aaaeqSSS = 1 To mlDATATABLE.Rows.Count - 1
                                                gtotnet = gtotnet + mlDATATABLE.Rows(aaaeqSSS)("subtot")
                                                totpv = totpv + (mlDATATABLE.Rows(aaaeqSSS)("pv") * mlDATATABLE.Rows(aaaeqSSS)("jumlah"))
                                                totbv = totbv + (mlDATATABLE.Rows(aaaeqSSS)("bv") * mlDATATABLE.Rows(aaaeqSSS)("jumlah"))
                                                ''''''''''''''''''''''''''''''''''''
                                                ' diskon untuk produk vcd yess
                                                ''''''''''''''''''''''''''''''''''''
                                                If Left(UCase(mlDATATABLE.Rows(aaaeqSSS)("kode")), 4) = "YVCD" Then
                                                    jumtotdis = jumtotdis + mlDATATABLE.Rows(aaaeqSSS)("jumlah")
                                                Else
                                                    jumtotdis = jumtotdis
                                                End If

                                                If UCase(mlDATATABLE.Rows(aaaeqSSS)("kode")) = "YBKBPRO" Then
                                                    If mlDATATABLE.Rows(aaaeqSSS)("jumlah") >= 25 Then
                                                        kurangi = mlDATATABLE.Rows(aaaeqSSS)("harga") - 6500
                                                        jumdis = kurangi * mlDATATABLE.Rows(aaaeqSSS)("jumlah")
                                                    Else
                                                        kurangi = 0
                                                        jumdis = 0
                                                    End If
                                                End If
                                     %>
                                    <tr>
						                <td style="width:10%;">&nbsp;&nbsp;<%=UCase(mlDATATABLE.Rows(aaaeqSSS)("kode"))%></td>
										<td style="width:20%;">&nbsp;&nbsp;<%=mlDATATABLE.Rows(aaaeqSSS)("nama")%></td>
										<td style="width:11%;text-align:right;"><%=FormatNumber(mlDATATABLE.Rows(aaaeqSSS)("pv"), 2)%></td>
										<td style="width:16%;text-align:right;"><%=FormatNumber(mlDATATABLE.Rows(aaaeqSSS)("bv"), 2)%></td>																									
										<td style="width:8%;text-align:right;"><%=FormatNumber(mlDATATABLE.Rows(aaaeqSSS)("jumlah"), 0)%>&nbsp;</td>
										<td style="width:12%;text-align:right;"><%=FormatNumber(mlDATATABLE.Rows(aaaeqSSS)("harga"), 0)%>&nbsp;</td>
										<td style="width:16%;text-align:right;"><%=FormatNumber(mlDATATABLE.Rows(aaaeqSSS)("subtot"), 0)%>&nbsp;</td>
										<td style="width:7%;"><p style="text-align:center;"><a href="mc_prd_topup_remove.asp?id=<%=mlDATATABLE.Rows(aaaeqSSS)("id")%>">DEL</a></td>
					                </tr> 
                                     <%
                                             Next
                                         End If
                                         mlREADERFrontEnd.Close()
                                         If jumtotdis > 0 Then
                                             brapadis = jumtotdis \ 2
                                             jumdivc = brapadis * 1500
                                             jumdisk = jumdis + jumdivc
                                         Else
                                             jumdivc = 0
                                             jumdisk = jumdis + jumdivc
                                         End If

                                         gtot = gtotnet - jumdisk
                                    %>
					                
					                <tr>
						                <td class="text-right" colspan="6"><strong>GRAND TOTAL</strong></td>
						                <td style="text-align:center;"><%=formatnumber(gtot,0)%>&nbsp;</td>
						                <td>&nbsp;</td>
					                </tr>
				                </tbody>
			                </table>
		                </div>
                        <%if gtot > 0 then %>
                         <p>
                            <span style="background-color: yellow; color: red; font-weight: bold;text-align:center;">
                                <a target="_top" href="mc_prd_topup_clear.aspx">BATALKAN SESI BELANJA INI & BIKIN SESI BARU</a>
                            </span>
                        </p>
                        <%else%>
                        <p></p>
                        <%end if%>	
                    </div>
                </div> 
                <%if jumskr > 0 and nosesi <> "" then %>
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h4 class="text-center panel-title" style="text-align:left;color:black;font-family:Arial;">(#3) CHECK OUT</h4>
                    </div>
                    <div class="panel-body">
                        <p>
                            Apabila anda sudah selesai berbelanja dan hendak melakukan pembayaran, maka lengkapilah kotak isian dibawah ini. Mohon pastikan bahwa setelah anda melakukan check out, 
                            <b style="color:#FF0000;">maka transaksi tidak dapat dibatalkan</b> dengan alasan apapun, karena saat anda melakukan check out, 
                            <u style="color:#FF0000;">maka posting update PV kepada seluruh upline distributor</u> yang berbelanja dilakukan secara realtime setelah anda menekan tombol check out dibawah ini.
		                </p>
                         <div class="alert alert-info text-center">
                            <strong style="font-family:Arial">
                                JUMLAH TOTAL PEMBELANJAAN <br/>
			                    <span style="color: yellow">Rp <%=formatnumber(gtot,0)%>,-</span><br/>
			                    TOTAL PV : <label style="color:#00FF00;"><%=formatnumber(totpv,2)%></label> TOTAL BV : <label style="color:#00FF00;"><%=formatnumber(totbv,2)%></label>
                            </strong>
		                </div>
                        <p><span style="text-decoration: underline; font-weight: bold">Check Out</span></p>
                        <form name="theform1" method="post" action="mc_prd_topup_ck.asp"  onSubmit="return checkFields()">
                            <div style="padding: 10px 5px 20px 5px">
                                <div class="col-md-3">
                                    <label>Topup Bulan</label>
                                </div>
                                <div class="col-md-6">
                                    <input class="form-control" type="text" name="tupobulan" readonly value="<%=wulane%>">
                                </div>
				                <div class="col-md-3">
                                    <label><span style="color: red"><em>*Topup Periode Bulan</em></span></label>
                                </div>
			                </div>
                            <div style="padding: 20px 5px 20px 5px">
                                <div class="col-md-3">
                                    <label>Topup Tahun</label>
                                </div>
                                <div class="col-md-6">
                                    <input class="form-control" type="text" name="tupotahun" readonly value="<%=nahune%>">
                                </div>
				                <div class="col-md-3">
                                    <label><span style="color: red"><em>*Topup Periode Tahun</em></span></label>
                                </div>
			                </div>
                            <div style="padding: 20px 5px 20px 5px">
                                <div class="col-md-3">
                                    <label>Distributor Topup. Id</label>
                                </div>
                                <div class="col-md-3">
                                    <input class="form-control" type="text" name="kdtopup" id="kdtopup" onKeyDown="if(event.keyCode==13) event.keyCode=9;" onchange="javascript:cari3(this)" value="<%=nokode%>" maxlength="8">
                                </div>
				                <div class="col-md-4">
                                    <input class="form-control" type="text" readonly name="namadistopup" id="namadistopup" value="<%=namadistopup%>">
                                </div>
				                <div class="col-md-2">
                                    <label>[<a href="carimember.aspx">Search</a>]</label>
                                </div>
			                </div>
                            <div style="padding: 20px 5px 20px 5px">
                                <div class="col-md-3">
                                    <label>Distributor Id. Alokasi</label>
                                </div>
                                <div class="col-md-3">
                                    <input class="form-control" type="text" name="kdpos" id="kdpos" onKeyDown="if(event.keyCode==13) event.keyCode=9;" onchange="javascript:cari2(this)" value="<%=nokode%>" maxlength="8">
                                    <input type="hidden" name="tgl" value="<%=tgl%>">
                                </div>
				                <div class="col-md-4">
                                    <input class="form-control" type="text" readonly name="namadis" id="namadis" value="<%=namadis%>">
                                </div>
				                <div class="col-md-2">
                                    <label>[<a href="carimember.aspx">Search</a>]</label>
                                </div>
			                </div>
                            <div style="padding: 20px 5px 20px 5px">
                                <div class="col-md-3">
                                    <label>Sub Total Belanja</label>
                                </div>
                                <div class="col-md-9">
                                    <input class="form-control" type="text" name="totalnet" readonly value="<%=formatnumber(gtotnet,0)%>">
                                    <input type="hidden" name="jumtotnet" value="<%=gtotnet%>">
                                </div>
			                </div>
                            <div style="padding: 20px 5px 20px 5px">
                                <div class="col-md-3">
                                    <label>Diskon</label>
                                </div>
                                <div class="col-md-9">
                                    <input class="form-control" type="text" name="diskon" readonly value="<%=formatnumber(jumdisk,0)%>">
                                    <input type="hidden" name="jumdisk" value="<%=jumdisk%>">
                                </div>
			                </div>
                            <div style="padding: 20px 5px 20px 5px">
                                <div class="col-md-3">
                                    <label>Total Belanja</label>
                                </div>
                                <div class="col-md-9">
                                    <input class="form-control" type="text" name="total" readonly value="<%=formatnumber(gtot,0)%>">
                                    <input type="hidden" name="jumtot" value="<%=gtot%>">
                                </div>
			                </div>
                            <div style="padding: 20px 5px 20px 5px">
                                <div class="col-md-12">
                                    <label><strong>Pembayaran :</strong></label>
                                </div>
			                </div>
                            <div style="padding: 20px 5px 20px 5px">
                                <div class="col-md-3">
                                    <label>Tunai</label>
                                </div>
                                <div class="col-md-3">
                                    <input class="form-control" type="text" name="jumbayarcash" onchange="quadratic2(this.form);" value="0" maxlength="10">
                                </div>
				                <div class="col-md-3">
                                    <label>Debit Card</label>
                                </div>
                                <div class="col-md-3">
                                    <input class="form-control" type="text" name="jumbayardb" onchange="quadratic2(this.form);" value="0" maxlength="10">
                                </div>
			                </div>
                            <div style="padding: 20px 5px 20px 5px">
                                <div class="col-md-3">
                                    <label>Credit Card</label>
                                </div>
                                <div class="col-md-3">
                                    <input class="form-control" type="text" name="jumbayarcc" onchange="quadratic2(this.form);" value="0" maxlength="10">
                                </div>
				                <div class="col-md-3">
                                    <label>Voucher</label>
                                </div>
                                <div class="col-md-3">
                                    <input class="form-control" type="text" name="jumbayarcek" onchange="quadratic2(this.form);" value="0" maxlength="10">
                                </div>
			                </div>
                            <div style="padding: 20px 5px 20px 5px">
                                <div class="col-md-3">
                                    <label>Total Pembayaran</label>
                                </div>
                                <div class="col-md-9">
                                    <input class="form-control" type="text" name="jumbayar" readonly value="0" maxlength="10">
                                </div>
			                </div>
                            <div style="padding: 20px 5px 20px 5px">
                                <div class="col-md-3">
                                    <label>Kembalian</label>
                                </div>
                                <div class="col-md-9">
                                    <input class="form-control" type="text" name="kembalian" readonly value="0">
                                </div>
			                </div>
                            <div style="padding: 20px 5px 20px 5px">
                                <div class="col-md-3">
                                    <label> </label>
                                </div>
                                <div class="col-md-9">
                                    <% if gtot > 0 and lanjutken = "T" Then %>
                                    <input class="btn btn-default" type="submit" name="btsbs0" value="Check Out &amp; Close Session" />
                                    <%end if%>
                                    <p><br/><span style="background-color: yellow; color: red; font-weight: bold">PASTIKAN ANDA SUDAH MENGISI DATA DENGAN BENAR ! </span><br/>Klik Sekali Saja dan tunggu hingga keluar invoice</p>
                                </div>
                            </div>
                        </form>
                    </div>
                </div>
                <%end if%>
            </div>
        </div>
    </section>
</asp:Content>

