<%@ Page Title="" Language="VB" MasterPageFile="~/pagesetting/MsPageMS.master" AutoEventWireup="false" CodeFile="ms4_perdana.aspx.vb" Inherits="MobileStockiest_ms4_perdana" %>

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
            xmlhttp.open('get', 'getdataprd_faxmc.asp?kode=' + kode, true);
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

        var xmlhttp = createRequestObject();
        function cari2(teks) {
            var kode = teks.value;
            if (!kode) return;
            xmlhttp.open('get', 'getdatamc_perdana.asp?kode=' + kode, true);
            xmlhttp.onreadystatechange = function () {
                if ((xmlhttp.readyState == 4) && (xmlhttp.status == 200)) {
                    var r = xmlhttp.responseXML.getElementsByTagName('data');
                    document.getElementById("namadis").value = r[1].firstChild.data;
                    document.getElementById("alamatdis").value = r[2].firstChild.data;
                    document.getElementById("kotadis").value = r[3].firstChild.data;
                    document.getElementById("kodeposdis").value = r[4].firstChild.data;
                    document.getElementById("propinsidis").value = r[5].firstChild.data;
                    document.getElementById("telpdis").value = r[6].firstChild.data;
                    document.getElementById("hpdis").value = r[7].firstChild.data;
                    document.getElementById("emaildis").value = r[8].firstChild.data;
                }
                return false;
            }
            xmlhttp.send(null);
        }
    </script>


    <script type="text/javascript">
<!--
        function formCheck(form) {
            if (form.kode.value == "") {
                alert("Anda belum mengisikan kode produk");
                return false;
            }

            if (form.nama.value == "NOT FOUND") {
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
// -->
    </script>


    <script type="text/javascript">
<!--
        function formCheck1(form) {

            if (form.jumpv.value < 200) {
                alert("Anda belum mempoinkan produk yang dibeli lebih dari 200 pv");
                return false;
            }

            if (form.kdpos.value == "") {
                alert("Anda belum mengisikan nomor DC yang berbelanja");
                return false;
            }

            if (form.namadis.value == "") {
                alert("Anda belum mengisikan nomor DC yang berbelanja");
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
// -->
    </script>


    <script type="text/javascript">
        function quadratic1(form1) {
            var harga = eval(form1.harga.value);
            var jumlah = eval(form1.jumlah.value);

            {
                form1.subtotal.value = jumlah * harga;
            }
        }
    </script>



    <script type="text/javascript">
        function quadratic2(form1) {
            var tunai = eval(form1.jumbayarcash.value);
            var cc = eval(form1.jumbayarcc.value);
            var db = eval(form1.jumbayardb.value);
            var cek = eval(form1.jumbayarcek.value);
            var jto = eval(form1.jumtote.value);

            {
                form1.jumbayar.value = tunai + cc + db + cek;
                form1.kembalian.value = (tunai + cc + db + cek) - jto;
            }
        }
    </script>

    <script type="text/javascript">

<!-- This script and many more are available free online at -->
<!--The JavaScript Source!! http://javascript.internet.com -->

<!--Begin
        var submitcount = 0;

        function reset() {
            document.theform1.tglw.value = "";
            document.theform1.waktuw.value = "";
        }

        function checkFields() {                       // field validation -
            if ((document.theform1.dc_asal.value == "") ||   // checks if fields are blank.
                (document.theform1.kdpos.value == "") ||   // More validation scripts at
                (document.theform1.namadis.value == "") ||   // More validation scripts at     
                (document.theform1.username.value == "") ||   // More validation scripts at    
                (document.theform1.alamatdis.value == "") ||   // More validation scripts at     
                (document.theform1.kotadis.value == "") ||   // More validation scripts at     
                (document.theform1.kodeposdis.value == "") ||   // More validation scripts at  
                (document.theform1.zona.value == "") ||   // More validation scripts at       
                (document.theform1.zona.value == "--PILIH ZONA--") ||   // More validation scripts at               
                (document.theform1.propinsidis.value == "") ||   // More validation scripts at
                (document.theform1.telpdis.value == "") ||   // More validation scripts at  
                (document.theform1.faxdis.value == "") ||   // More validation scripts at          
                (document.theform1.emaildis.value == "") ||   // More validation scripts at 
                (document.theform1.jumtot.value == "") ||   // More validation scripts at       
                (document.theform1.jumbayar.value == "") ||   // More validation scripts at   
                (document.theform1.kembalian.value == "") ||   // More validation scripts at   
                (document.theform1.jumbayar.value == "NaN") ||   // More validation scripts at   
                (document.theform1.kembalian.value == "NaN") ||   // More validation scripts at      
                (document.theform1.jumtot.value == 0) ||   // More validation scripts at       
                (document.theform1.jumbayar.value == 0) ||   // More validation scripts at 
                (document.theform1.jumpv.value < 200) ||   // More validation scripts at           
                (document.theform1.kembalian.value < 0)) // forms.javascriptsource.com                                                   
            {
                alert("Mohon lengkapi form pendaftaran mobil center baru terlebih dulu, pastikan produk yang dipointkan lebih dari 200 PV");
                return false;
            }

            else {
                if (submitcount == 0) {
                    submitcount++;
                    return true;
                }
                else {
                    alert("Form sedang diproses, silahkan tunggu hingga proses penyimpanan data selesai dilakukan. Silahkan tutup pesan ini untuk melanjutkan proses.");
                    return false;
                }
            }
        }
//  End -->
    </script>

    <script type="text/javascript">
        function Navigate(drop_down_list) {
            var number = drop_down_list.selectedIndex;
            location.href = drop_down_list.options[number].value;
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mpCONTENT" runat="Server">

    <section class="content-header">
        <div class="box">
            <div class="box-header with-border">
                <h3 class="box-title">PENDAFTARAN MOBILE STOCKIEST DARI EXISTING DISTRIBUTOR MS400</h3>
                <div class="box-tools pull-right">
                    <button type="button" class="btn btn-box-tool" data-widget="collapse" data-toggle="tooltip" title="Collapse">
                        <i class="fa fa-minus"></i>
                    </button>
                    <button type="button" class="btn btn-box-tool" data-widget="remove" data-toggle="tooltip" title="Remove">
                        <i class="fa fa-times"></i>
                    </button>
                </div>
            </div>
            <div class="box-body">
                <div class="row">
                    <div class="col-lg-12">
                        <div class="panel panel-default">
                            <div class="panel-heading">(#1) PERATURAN</div>
                            <div class="panel-body">
                                <div class="row">
                                    <div class="col-lg-12">
                                        <ol type="1">
                                            <li>Secara default, data-data mobile stockiest seperti alamat, nomor telepon dan informasi lainnya sama dengan data sebagai distributor, dapat diganti dicontrol panel mobile stockiest.
                                            </li>
                                            <li>Nomor id mobile stockiest adalah :
                                            <br />
                                                MS+"-"+nomor id distributor, sebagai contoh 100001 menjadi mobile stockiest, maka id mobile stockiestnya adalah MS-100001 dengan login page pada alamat <a href=" http://www.healthwealthint.com/mobilestockiest">http://www.healthwealthint.com/mobilestockiest</a>
                                            </li>
                                            <li>Password login ke control panel mobile stockiest secara default adalah password loginnya sebagai distributor, namun dapat diganti pada control panel mobile stockiest.
                                            </li>
                                            <li>Order perdana bagi mobile stockiest baru, 1 Paket MS (MS400U)
                                            </li>
                                            <li>Order perdana ini sekaligus sebagai sarana untuk mengaktifkan distributor menjadi mobile stockiest.
                                            </li>
                                            <li>Order perdana hanya order produk bukan order paket pendaftaran.
                                            </li>
                                            <li class="text text-danger">Setelah anda menekan tombol "Release Order & Daftarkan Mobile Stockiest", maka sistem akan secara otomatis mengaktifkan status mobile stockiest distributor yang id nya didaftarkan dan mengalihkan stock DC menjadi stock mobile stockiest sesuai yang diorder. Pastikan anda sudah mengisi dengan benar item barang yang diorder dan nomor id distributor yang menjadi mobile stockiest.
                                            <span class="alert-warning text-black">Semua kesalahan yang membutuhkan pembatalan tidak dapat dilakukan dan sepenuhnya menjadi tanggung jawab DC / mobile stockiest yang bersangkutan.
                                            </span>
                                            </li>
                                        </ol>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-lg-12">
                                        <h3>
                                            Silahkan Pilih Paket Upgrade (cukup 1 saja) :
                                        </h3>
                                        <div class="row" id="paketUpgrade" runat="server">

                                        </div>
                                        <h4 class="text-center alert-warning text-bold text-black">
                                            SESSION BELANJAAN INI AKAN EXPIRED APABILA ANDA TIDAK MEMPROSESNYA DALAM WAKTU 10 MENIT
                                        </h4>
                                    </div>
                                </div>

                            </div>
                        </div>
                    </div>
                    <div class="col-lg-12">
                        <div class="panel panel-default">
                            <div class="panel-heading">(#2) KERANJANG BELANJAAN</div>
                            <div class="panel-body">
                                <div class="row">
                                    <div class="col-lg-12">
                                        Dibawah ini adalah order yang sudah dimasukan saat ini. Anda dapat menghapus / membatalkan item order dibawah ini. Pembatalan item order hanya dapat dilakukan sebelum sesi ini ditutup, sesi ditutup dengan menekan tombol check out.
                                        <div class="table-responsive">
                                            <table class="table table-bordered" id="table1">
                                                <thead>
                                                    <tr>
                                                        <th>Kode
                                                        </th>
                                                        <th>Nama Produk
                                                        </th>
                                                        <th>PV 
                                                        </th>
                                                        <th>Qty 
                                                        </th>
                                                        <th>Harga 
                                                        </th>
                                                        <th>Sub Total 
                                                        </th>
                                                        <th>Aksi  
                                                        </th>
                                                    </tr>
                                                </thead>
                                                <tbody id="tbMsUpdgrade" runat="server">
                                                </tbody>
                                                <tfoot id="tfootMsUpgrade" runat="server">
                                                </tfoot>
                                            </table>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>

</asp:Content>

