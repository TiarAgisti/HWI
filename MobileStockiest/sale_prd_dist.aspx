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
        <div style="background-color: grey">
            <h3 style="text-align:center;color:white;font-family:Arial;">PENJUALAN PRODUK</h3>
        </div><br />

        <div class="col-md-12" style="padding: 10px 10px 10px 10px">
            <div style="border-style: solid">
                <div style="padding: 10px 10px 10px 10px; background-color: ">
                    <div style="background-color: orange">
                        <h4 style="text-align:center;color:white;font-family:Arial;">(#1) CATATAN</h4>
                    </div>
                    <ol>
                        <li>Closing Date untuk bulan ini adalah pada tanggal, jam :<br>
                            <label style="color:#FF0000;"> s.d </label><br>
                            Semua transaksi yang dilakukan diantara closing period diatas, akan ditolak oleh sistem. Apabila anda membutuhkan untuk membukukan transaksi tersebut untuk keperluan top up bulanan, maka silahkan menghubungi kantor pusat.</li>
                        <li>Penjualan produk hanya digunakan untuk penjualan produk tidak dicampur dengan penjualan paket pendaftaran.</li>
                        <li>1 (satu) nomor invoice pembelanjaan berlaku untuk 1 (satu) calon distributor. Maksimal item belanja per 1 (satu) nomor invoice sebanyak 7 item.</li>
                        <li>Tanggal transaksi tidak dapat diubah dan menurut jam server (WIB).</li>
                        <li>Semua transaksi yang sudah dibukukan tidak dapat dibatalkan. Untuk itu mohon periksa dan pastikan transaksi yang anda lakukan sudah benar ! sebelum mmprosesnya ke check out.</li>
                    </ol>
                </div>
            </div>

            <div style="padding-top: 10px">
                <div class="alert alert-warning text-center" role="alert">
                    <span class="text-uppercase"><span style="text-decoration: underline; font-weight: bold">ERROR MESSAGE</span></span>
                </div>
            </div>

            <div style="padding: 10px 10px 10px 10px">
                <div style="padding: 10px 5px 20px 5px">
                    <div class="col-md-4">
                        <label>Tanggal Transaksi</label>
                    </div>
                    <div class="col-md-8">
                        <input class="form-control" type="text">
                    </div>
                </div>
                <div style="padding: 20px 5px 20px 5px">
                    <div class="col-md-4">
                        <label>Kode Produk</label>
                    </div>
                    <div class="col-md-5">
                        <input class="form-control" type="text">
                    </div>
                    <div class="col-md-3">
                        <label>[<a href="https://www.w3schools.com">Tampilkan Kode]</a></label>
                    </div>
                </div>
                <div style="padding: 20px 5px 20px 5px">
                    <div class="col-md-4">
                        <label>Nama Produk</label>
                    </div>
                    <div class="col-md-8">
                        <input class="form-control" type="text">
                    </div>
                </div>
                <div style="padding: 20px 5px 20px 5px">
                    <div class="col-md-4">
                        <label>Harga </label>
                    </div>
                    <div class="col-md-8">
                        <input class="form-control" type="text">
                    </div>
                </div>
                <div style="padding: 20px 5px 20px 5px">
                    <div class="col-md-4">
                        <label>PV</label>
                    </div>
                    <div class="col-md-2">
                        <input class="form-control" type="text">
                    </div>
                    <div class="col-md-4">
                        <label>BV</label>
                    </div>
                    <div class="col-md-2">
                        <input class="form-control" type="text">
                    </div>
                </div>
                <div style="padding: 20px 5px 20px 5px">
                    <div class="col-md-4">
                        <label>Jumlah Pembelian</label>
                    </div>
                    <div class="col-md-8">
                        <input class="form-control" type="text">
                    </div>
                </div>
                <div style="padding: 20px 5px 20px 5px">
                    <div class="col-md-4">
                        <label>Sub Total</label>
                    </div>
                    <div class="col-md-8">
                        <input class="form-control" type="text">
                    </div>
                </div>
                <div style="padding: 20px 5px 20px 5px">
                    <div class="col-md-4">
                        <label></label>
                    </div>
                    <div class="col-md-8">
                        <button class="btn btn-default" type="button">Add to Basket</button>
                        <p><br>
                            <span style="color: red; font-weight: bold">
                                invoice maksimal berisi 7 item barang atau penjualan ke periode bulan berjalan dibekukan sementara pada masa topup
                            </span>
                        </p>
                    </div>
                </div>
            </div>
        </div>

        <div class="col-md-12" style="padding: 10px 10px 10px 10px">
            <div style="background-color: #0099FF">
                <h4 style="text-align:center;font-family:Arial;" class="style1">(#2) KERANJANG BELANJAAN</h4>
            </div>
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
                        <tr>
                            <td class="text-center" colspan="8"><span style="text-decoration: underline">Sesi ini belum ada belanjaan</span></td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td><a href="https://www.w3schools.com">DEL</a></td>
                        </tr>
                        <tr>
                            <td class="text-right" colspan="6"><strong>GRAND TOTAL</strong></td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                    </tbody>
                </table>
            </div>
            <p>
                <span style="background-color: yellow; color: red; font-weight: bold;text-align:center;">BATALKAN SESI BELANJA INI & BIKIN SESI BARU</span>
            </p>

            <div style="background-color: green">
                <h4 style="text-align:center;color:white;font-family:Arial;">(#3) CHECK OUT</h4>
            </div>
            <p>
                Apabila anda sudah selesai berbelanja dan hendak melakukan pembayaran, 
                maka lengkapilah kotak isian dibawah ini. Mohon pastikan bahwa setelah anda melakukan check out, 
                <b style="color:#FF0000;">maka transaksi tidak dapat dibatalkan </b>
                dengan alasan apapun, karena saat anda melakukan check out,
                <u style="color:#FF0000;">maka posting update PV kepada seluruh upline distributor</u> yang berbelanja dilakukan secara realtime setelah anda menekan tombol check out dibawah ini.
            </p>
           
            <div style="background-color: black; color: white;text-align:center;">
                <p>
                    <strong style="font-family:Arial;">
			            JUMLAH TOTAL PEMBELANJAAN <br/>
			            <span style="color: yellow">Rp ,-</span><br/>
			            TOTAL PV : - TOTAL BV :
		            </strong>
                </p>
            </div>
            <p><span style="text-decoration: underline; font-weight: bold">Check Out</span></p>
            <div style="padding: 10px 5px 20px 5px">
                <div class="col-md-3">
                    <label>No. Invoice </label>
                </div>
                <div class="col-md-5">
                    <input class="form-control" type="text">
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
                    <input class="form-control" type="text">
                </div>
                <div class="col-md-4">
                    <input class="form-control" type="text">
                </div>
            </div>
            <div style="padding: 20px 5px 20px 5px">
                <div class="col-md-3">
                    <label>Distributor Id</label>
                </div>
                <div class="col-md-3">
                    <input class="form-control" type="text">
                </div>
                <div class="col-md-4">
                    <input class="form-control" type="text">
                </div>
                <div class="col-md-2">
                    <label>[<a href="https://www.w3schools.com">Search</a>]</label>
                </div>
            </div>
            <div style="padding: 20px 5px 20px 5px">
                <div class="col-md-3">
                    <label>Tipe Posting Point</label>
                </div>
                <div class="col-md-9">
                    <label>
                        <input name="radiobutton" type="radio" value="radiobutton">
                    </label>
                    Normal Posting (Productivity berlaku)
                </div>
                <div class="col-md-3"></div>
                <div class="col-md-9">
                    <label>
                        <input name="radiobutton" type="radio" value="radiobutton">
                    </label>
                    Normal Posting (Productivity berlaku)
                </div>
            </div>
            <div style="padding: 20px 5px 20px 5px">
                <div class="col-md-3">
                    <label>Sub Total Belanja</label>
                </div>
                <div class="col-md-9">
                    <input class="form-control" type="text">
                </div>
            </div>
            <div style="padding: 20px 5px 20px 5px">
                <div class="col-md-3">
                    <label>Diskon</label>
                </div>
                <div class="col-md-9">
                    <input class="form-control" type="text">
                </div>
            </div>
            <div style="padding: 20px 5px 20px 5px">
                <div class="col-md-3">
                    <label>Total Belanja</label>
                </div>
                <div class="col-md-9">
                    <input class="form-control" type="text">
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
                    <input class="form-control" type="text">
                </div>
                <div class="col-md-3">
                    <label>Credit Card</label>
                </div>
                <div class="col-md-3">
                    <input class="form-control" type="text">
                </div>
            </div>
            <div style="padding: 20px 5px 20px 5px">
                <div class="col-md-3">
                    <label>Debit Card</label>
                </div>
                <div class="col-md-3">
                    <input class="form-control" type="text">
                </div>
                <div class="col-md-3">
                    <label>Voucher</label>
                </div>
                <div class="col-md-3">
                    <input class="form-control" type="text">
                </div>
            </div>
            <div style="padding: 20px 5px 20px 5px">
                <div class="col-md-3">
                    <label>Total Pembayaran</label>
                </div>
                <div class="col-md-9">
                    <input class="form-control" type="text">
                </div>
            </div>
            <div style="padding: 20px 5px 20px 5px">
                <div class="col-md-3">
                    <label>Kembalian</label>
                </div>
                <div class="col-md-9">
                    <input class="form-control" type="text">
                </div>
            </div>
            <div style="padding: 20px 5px 20px 5px">
                <div class="col-md-3">
                    <label></label>
                </div>
                <div class="col-md-9">
                    <button class="btn btn-default" type="button">Checkout & Close Session</button>
                    <p><br/>
                        <span style="background-color: yellow; color: red; font-weight: bold">PASTIKAN ANDA SUDAH MENGISI DATA DENGAN BENAR ! </span><br/>
                        <span class="style2">Klik Sekali Saja dan tunggu hingga keluar invoice</span>
                    </p>
                </div>
            </div>
        </div>
    </section>
</asp:Content>

