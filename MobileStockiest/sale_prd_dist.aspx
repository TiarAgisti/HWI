<%@ Page Title="" Language="VB" MasterPageFile="~/pagesetting/MsPageMS.master" AutoEventWireup="false" CodeFile="sale_prd_dist.aspx.vb" Inherits="MobileStockiest_sale_prd_dist" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type='text/javascript'>
        function createRequestObject() {
            var ro;
            var browser = navigator.appName;
            if (browser == "Microsoft Internet Explorer") {
                ro = new ActiveXObject("Microsoft.XMLHTTP");
            } else {
                ro = new XMLHttpRequest();
            }
            return ro;
        }
        var xmlhttp = createRequestObject();
        function cari(teks) {
            var kode = teks.value;
            if (!kode) return;
            xmlhttp.open('get', 'getdataprd.asp?kode=' + kode, true);
            xmlhttp.onreadystatechange = function () {
                if ((xmlhttp.readyState == 4) && (xmlhttp.status == 200)) {
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

        function cari2(teks) {
            var kode = teks.value;
            if (!kode) return;
            xmlhttp.open('get', 'getdatadist.asp?kode=' + kode, true);
            xmlhttp.onreadystatechange = function () {
                if ((xmlhttp.readyState == 4) && (xmlhttp.status == 200)) {
                    var r = xmlhttp.responseXML.getElementsByTagName('data');
                    document.getElementById("namadis").value = r[1].firstChild.data;
                }
                return false;
            }
            xmlhttp.send(null);
        }
    </script>


    <script type='text/javascript'>
        function formCheck(form) {
            if (form.kode.value == "") {
                alert("Anda belum mengisikan kode produk");
                return false;
            }

            if (form.harga.value == 0) {
                alert("Anda belum memilih produk");
                return false;
            }

            if (form.jumlah.value == 0) {
                alert("Anda belum memasukan jumlah produk dibeli");
                return false;
            }

            if (confirm("Cek sekali lagi, apakah data yang Anda isi SUDAH BENAR semua ?\n\nKode Produk : " + form.kode.value + "\nNama Produk : " + form.nama.value + "\nJumlah : " + form.jumlah.value + "\n")) {
                return true;
            }
            else {
                return false;
            }
        }
    </script>

    <script type='text/javascript'>
        function formCheck1(form) {
            if (form.kdpos.value == "") {
                alert("Anda belum mengisikan nomor distributor yang berbelanja");
                return false;
            }

            if (form.namadis.value == "") {
                alert("Anda belum mengisikan nomor distributor yang berbelanja");
                return false;
            }

            if (form.namadis.value == "NOT FOUND") {
                alert("Anda belum mengisikan nomor distributor yang berbelanja");
                return false;
            }

            if (form.jumtot.value == 0) {
                alert("Anda belum memasukan jumlah produk dibeli");
                return false;
            }

            if (form.jumbayar.value == 0) {
                alert("Anda belum memasukan jumlah pembayaran");
                return false;
            }

            if (form.kembalian.value < 0) {
                alert("Jumlah pembayaran anda masih kurang");
                return false;
            }

            if (confirm("Cek sekali lagi, apakah data yang Anda isikan SUDAH BENAR semua ? Semua transaksi yang sudah dibukukan (sudah checkout) tidak dapat dibatalkan dengan alasan apapun, karena proses posting PV/BV dilakukan secara realtime.\n\nNo. Id. Distributor : " + form.kdpos.value + "\nNama Distributor : " + form.namadis.value + "\nPembayaran " + form.jumbayar.value + "\n")) {
                return true;
            }
            else {
                return false;
            }
        }
    </script>

    <script type='text/javascript'>
        function quadratic1(form1) {
            var harga = eval(form1.harga.value);
            var jumlah = eval(form1.jumlah.value);
            {
                form1.subtotal.value = jumlah * harga;
            }
        }
    </script>

    <script type='text/javascript'>
        function quadratic2(form1) {
            var tunai = eval(form1.jumbayarcash.value);
            var cc = eval(form1.jumbayarcc.value);
            var db = eval(form1.jumbayardb.value);
            var cek = eval(form1.jumbayarcek.value);
            var jto = eval(form1.jumtot.value);
            {
                form1.jumbayar.value = tunai + cc + db + cek;
                form1.kembalian.value = (tunai + cc + db + cek) - jto;
            }
        }
    </script>

    <script type='text/javascript'>

        <!-- This script and many more are available free online at -->
    var submitcount = 0;

    function reset() {
        document.theform1.kdpos.value = "";
        document.theform1.namadis.value = "";
    }

    function checkFields() {                       // field validation -
        if ((document.theform1.kdpos.value == "") ||   // checks if fields are blank.
            (document.theform1.namadis.value == "") ||   // More validation scripts at
            (document.theform1.namadis.value == "NOT FOUND") ||   // More validation scripts at   
            (document.theform1.jumtot.value == "") ||   // More validation scripts at       
            (document.theform1.jumbayar.value == "") ||   // More validation scripts at   
            (document.theform1.kembalian.value == "") ||   // More validation scripts at   
            (document.theform1.jumbayar.value == "NaN") ||   // More validation scripts at   
            (document.theform1.kembalian.value == "NaN") ||   // More validation scripts at      
            (document.theform1.jumtot.value == 0) ||   // More validation scripts at       
            (document.theform1.jumbayar.value == 0) ||   // More validation scripts at           
            (document.theform1.kembalian.value < 0)) // forms.javascriptsource.com
        {
            alert("Mohon lengkapi form pembayaran terlebih dulu");
            return false;
        }
        else {
            if (submitcount == 0) {
                submitcount++;
                return true;
            }
            else {
                alert("Form sedang diproses, silahkan tunggu hingga proses posting PV selesai dilakukan dengan munculnya invoice. Silahkan tutup pesan ini untuk melanjutkan proses posting PV.");
                return false;
            }
        }
    }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mpCONTENT" runat="Server">
    <section class="content-header" style="background-color:white;">
        <div class="panel panel-default">
            <div class="panel-heading">
                <h3 class="text-center panel-title" style="text-align: center; color: black; font-family: Arial;"><strong>PENJUALAN PRODUK</strong></h3>
            </div>
            <div class="panel-body">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h4 class="text-center panel-title" style="text-align:left;color:black;font-family:Arial;">(#1) CATATAN</h4>
                    </div>
                    <div class="panel-body">
                        <ol>
                            <li>
                                Closing Date untuk bulan ini adalah pada tanggal, jam :<br>
                                <% hariakhir = Now.Date %>
                                <label style="color:#FF0000;"><%=tutup1%> s.d <%=tutup2%></label><br>
                                Semua transaksi yang dilakukan diantara closing period diatas, akan ditolak oleh sistem. Apabila anda membutuhkan untuk membukukan transaksi tersebut untuk keperluan top up bulanan, maka silahkan menghubungi kantor pusat.
                            </li>
                            <li>Penjualan produk hanya digunakan untuk penjualan produk tidak dicampur dengan penjualan paket pendaftaran.</li>
                            <li>1 (satu) nomor invoice pembelanjaan berlaku untuk 1 (satu) calon distributor. Maksimal item belanja per 1 (satu) nomor invoice sebanyak 7 item.</li>
                            <li>Tanggal transaksi tidak dapat diubah dan menurut jam server (WIB).</li>
                            <li>Semua transaksi yang sudah dibukukan tidak dapat dibatalkan. Untuk itu mohon periksa dan pastikan transaksi yang anda lakukan sudah benar ! sebelum mmprosesnya ke check out.</li>
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
                        <form name="theform" method="post" action="sale_prd_dist_add.asp" onSubmit="return formCheck(this)">
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
                                    <label>Nomor Kode Produk</label>
                                </div>
                                <div class="col-md-5">
                                    <input class="form-control" type="text" name="kode" id="kode" onChange="javascript:cari(this)" onKeyDown="if(event.keyCode==13) event.keyCode=9;" maxlength="15">
                                </div>
                                <div class="col-md-3">
                                    <label>
                                        [<a href="#">
                                            <span onClick="javascript:window.open('../MobileStockiest/daftarkode.aspx?tipe=PRD', 'HelpWindow','scrollbars=yes, resizable=yes, height=500, width=300')">Tampilkan Kode</span>
                                         </a>]
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
                                    <input class="form-control" type="text" id="pv" name="pv" readonly onKeyDown="if(event.keyCode==13) event.keyCode=9;" maxlength="7">
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
                                    <input class="form-control" type="text" name="jumlah" onchange="quadratic1(this.form);" value="0">
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
                                    <%if jumskr < 7 and lanjutkens = "T" then %>
                                    <input type="submit" name="btsub" value="Add to Basket" class="btn btn-default">
                                    <%else%>
                                    <p><br>
                                        <span style="color: red; font-weight: bold">
                                            invoice maksimal berisi 7 item barang atau penjualan ke periode bulan berjalan dibekukan sementara pada masa topup
                                        </span>
                                    </p>
                                    <%end if%>
                                </div>
                            </div>
                        </form>
                    </div>
                </div>
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h4 class="text-center panel-title" style="text-align:left;font-family:Arial;">(#2) KERANJANG BELANJAAN</h4>
                    </div>
                    <div class="panel-body">
                        <p>Dibawah ini adalah daftar belanjaan saat ini. Anda dapat menghapus / membatalkan item belanjaan dibawah ini. Pembatalan item belanjaan hanya dapat dilakukan sebelum sesi belanja ini ditutup, sesi belanja ini ditutup dengan menekan tombol check out.</p>
                        <div class="table-responsive">
                            <table class="table table-condensed table-bordered">
                                <thead>
                                    <tr style="background: #FF6699">
                                        <td style="width:6%;">
                                            <div style="text-align:center;"><strong>Kode</strong></div>
                                        </td>
                                        <td style="width:29%;">
                                            <div style="text-align:center;"><strong>Nama Produk</strong></div>
                                        </td>
                                        <td style="width:10%;">
                                            <div style="text-align:center;"><strong>PV</strong></div>
                                        </td>
                                        <td style="width:9%;">
                                            <div style="text-align:center;"><strong>BV</strong></div>
                                        </td>
                                        <td style="width:8%;">
                                            <div style="text-align:center;">Qty.</div>
                                        </td>
                                        <td style="width:13%;">
                                            <div style="text-align:center;"><strong>Harga</strong></div>
                                        </td>
                                        <td style="width:20%;">
                                            <div style="text-align:center;"><strong>Total</strong></div>
                                        </td>
                                        <td style="width:5%;">
                                            <div style="text-align:center;"><strong>Aksi</strong></div>
                                        </td>
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
                                        mlSQL = "SELECT * FROM st_sale_prd_det_tmp where nopos like '" & mypos & "' and nosesi like '" & nosesi & "' order by id"
                                        mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
                                        If Not mlREADER.HasRows Then %>
                                    <tr>
                                        <td class="text-center" colspan="8"><span style="text-decoration: underline">Sesi ini belum ada belanjaan</span></td>
                                    </tr>
                                    <% end if%>
                                    <%
                If mlREADER.HasRows Then
                    mlDATATABLE = New Data.DataTable
                    mlDATATABLE.Load(mlREADER)
                    For aaaeqSSS = 0 To mlDATATABLE.Rows.Count - 1
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
                                            <td>&nbsp;&nbsp;<%=UCase(mlDATATABLE.Rows(aaaeqSSS)("kode"))%></td>
                                            <td>&nbsp;&nbsp;<%=mlDATATABLE.Rows(aaaeqSSS)("nama")%></td>
                                            <td style="text-align:right;"><%=FormatNumber(mlDATATABLE.Rows(aaaeqSSS)("pv"), 2)%></td>
                                            <td style="text-align:right;"><%=FormatNumber(mlDATATABLE.Rows(aaaeqSSS)("bv"), 2)%></td>
                                            <td style="text-align:right;"><%=FormatNumber(mlDATATABLE.Rows(aaaeqSSS)("jumlah"), 0)%>&nbsp;</td>
                                            <td style="text-align:right;"><%=FormatNumber(mlDATATABLE.Rows(aaaeqSSS)("harga"), 0)%>&nbsp;</td>
                                            <td style="text-align:right;"><%=FormatNumber(mlDATATABLE.Rows(aaaeqSSS)("subtot"), 0)%>&nbsp;</td>
                                            <td style="text-align:center;"><a href="sale_prd_dist_remove.asp?id=<%=mlDATATABLE.Rows(aaaeqSSS)("id")%>">DEL</a></td>
                                        </tr>
                                    <%
                                            Next
                                        End If
                                        mlREADER.Close()
                                        ''''''''''''''''''''''''''''''''''''
                                        ' diskon untuk produk vcd yess
                                        ''''''''''''''''''''''''''''''''''''
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
                                        <td class="text-right"><%=formatnumber(gtot,0)%>&nbsp;</td>
                                        <td>&nbsp;</td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                        <%if gtot > 0 then %>
                         <p>
                            <span style="background-color: yellow; color: red; font-weight: bold;text-align:center;">
                                <a target="_top" href="sale_prd_dist_clear.aspx">BATALKAN SESI BELANJA INI & BIKIN SESI BARU</a>
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
                            Apabila anda sudah selesai berbelanja dan hendak melakukan pembayaran, 
                            maka lengkapilah kotak isian dibawah ini. Mohon pastikan bahwa setelah anda melakukan check out, 
                            <b style="color:#FF0000;">maka transaksi tidak dapat dibatalkan </b>
                            dengan alasan apapun, karena saat anda melakukan check out,
                            <u style="color:#FF0000;">maka posting update PV kepada seluruh upline distributor</u> yang berbelanja dilakukan secara realtime setelah anda menekan tombol check out dibawah ini.
                        </p>
                        <div class="alert alert-info text-center">
                            <p>
                                <strong style="font-family:Arial;">
			                        JUMLAH TOTAL PEMBELANJAAN <br/>
			                        <span style="color: yellow">Rp <%=formatnumber(gtot,0)%>,-</span><br/>
			                        TOTAL PV :<label style="color:white;"><%=formatnumber(totpv,2)%></label> TOTAL BV :<label style="color:white;"><%=formatnumber(totbv,2)%></label>
		                        </strong>
                            </p>
                        </div>
                        <p><span style="text-decoration: underline; font-weight: bold">Check Out</span></p>
                        <form name="theform1" method="post" action="sale_prd_dist_ck.asp" onSubmit="return checkFields()">
                            <div style="padding: 10px 5px 20px 5px">
                                <div class="col-md-3">
                                    <label>No. Invoice </label>
                                </div>
                                <div class="col-md-5">
                                    <input class="form-control" type="text" readonly name="nofax" value="<%=nofax%>">
                                </div>
                                <div class="col-md-4">
                                    <label><span style="color: red"><em>*Akan diisi oleh sistem </em></span></label>
                                </div>
                            </div>
                            <div style="padding: 20px 5px 20px 5px">
                                <div class="col-md-3">
                                    <label>PV Bulan/Tahun </label>
                                </div>
                                <div class="col-md-3">
                                    <input class="form-control" type="text" name="pvbul" readonly onKeyDown="if(event.keyCode==13) event.keyCode=9;" onchange="javascript:cari2(this)" value="<%=wulpos%>">
                                </div>
                                <div class="col-md-4">
                                    <input class="form-control" type="text" readonly name="tahunpos" value="<%=nuhun%>">
                                </div>
                            </div>
                            <div style="padding: 20px 5px 20px 5px">
                                <div class="col-md-3">
                                    <label>Distributor Id</label>
                                </div>
                                <div class="col-md-3">
                                    <input class="form-control" type="text" name="kdpos" id="kdpos" onKeyDown="if(event.keyCode==13) event.keyCode=9;" onchange="javascript:cari2(this)" value="<%=nokode%>" maxlength="8">
                                    <input type="hidden" name="tgl" value="<%=tgl%>">
                                </div>
                                <div class="col-md-4">
                                    <input class="form-control" type="text" readonly name="namadis" id="namadis" value="<%=namadis%>">
                                </div>
                                <div class="col-md-2">  
                                    <label>[<a href="carimember.asp" onClick="NewWindow(this.href,'name','650','400','yes');return false">Search</a>]</label>
                                </div>
                            </div>
                            <div style="padding: 20px 5px 20px 5px">
                                <div class="col-md-3">
                                    <label>Tipe Posting Point</label>
                                </div>
                                <div class="col-md-9">
                                    <label>
                                        <input type="radio" value="1" name="tipe_post">
                                    </label>
                                    Normal Posting (Productivity berlaku)
                                </div>
                                <div class="col-md-3"></div>
                                <div class="col-md-9">
                                    <label>
                                        <input type="radio" value="2" name="tipe_post">
                                    </label>
                                    Full Quadro Plan Point Posting (Tanpa Productivity dianggap seperti top up)
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
                                    <label>Credit Card</label>
                                </div>
                                <div class="col-md-3">
                                    <input class="form-control" type="text" name="jumbayarcc" onchange="quadratic2(this.form);" value="0" maxlength="10">
                                </div>
                            </div>
                            <div style="padding: 20px 5px 20px 5px">
                                <div class="col-md-3">
                                    <label>Debit Card</label>
                                </div>
                                <div class="col-md-3">
                                    <input class="form-control" type="text" name="jumbayardb" onchange="quadratic2(this.form);" value="0" maxlength="10">
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
                                    <input class="form-control" type="text" name="kembalian" readonly value="0" maxlength="10">
                                </div>
                            </div>
                            <div style="padding: 20px 5px 20px 5px">
                                <div class="col-md-3">
                                    <label></label>
                                </div>
                                <div class="col-md-9">
                                    <% if gtot > 0 then %>
									<input  class="btn btn-default" type="submit" name="btsbs0" value="Check Out &amp; Close Session" style="font-size: 8pt; font-family: Verdana">
									<%end if%>
                                    <p><br/>
                                        <span style="background-color: yellow; color: red; font-weight: bold">PASTIKAN ANDA SUDAH MENGISI DATA DENGAN BENAR ! </span><br/>
                                        <span class="style2">Klik Sekali Saja dan tunggu hingga keluar invoice</span>
                                    </p>
                                </div>
                            </div>
                        </form>
                    </div>
                </div>
                <%end if%>
            </div>
        </div>
        <div style="padding: 20px 20px 20px 20px">
            <div class="col-md-3">
                <label></label>
            </div>
        </div>
    </section>
</asp:Content>

