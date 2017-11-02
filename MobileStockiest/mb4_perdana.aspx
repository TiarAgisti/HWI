<%@ Page Title="" Language="VB" MasterPageFile="~/pagesetting/MsPageMS.master" AutoEventWireup="false" CodeFile="mb4_perdana.aspx.vb" Inherits="MobileStockiest_mb4_perdana" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
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
            xmlhttp.open('get', 'getdataprd_faxmc.aspx?kode=' + kode, true);
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
            xmlhttp.open('get', 'getdatamc_perdana.aspx?kode=' + kode, true);
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

    <script type='text/javascript'>
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
    </script>
    <script type='text/javascript'>
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
            var jto = eval(form1.jumtote.value);

            {
                form1.jumbayar.value = tunai + cc + db + cek;
                form1.kembalian.value = (tunai + cc + db + cek) - jto;
            }
        }

    </script>
    <script type='text/javascript'>
        <!-- This script and many more are available free online at -->
        //<!-- The JavaScript Source!! http://javascript.internet.com -->

        //<!-- Begin
        var submitcount=0;

        function reset() {
            document.theform1.tglw.value = "";
            document.theform1.waktuw.value = "";
        }

        function checkFields() {                       // field validation -
            if ( (document.theform1.dc_asal.value=="")  ||   // checks if fields are blank.
                (document.theform1.kdpos.value=="") ||   // More validation scripts at
                (document.theform1.namadis.value=="") ||   // More validation scripts at     
                (document.theform1.username.value=="") ||   // More validation scripts at    
                (document.theform1.alamatdis.value=="") ||   // More validation scripts at     
                (document.theform1.kotadis.value=="") ||   // More validation scripts at     
                (document.theform1.kodeposdis.value=="") ||   // More validation scripts at  
                (document.theform1.zona.value=="") ||   // More validation scripts at       
                (document.theform1.zona.value=="--PILIH ZONA--") ||   // More validation scripts at               
                (document.theform1.propinsidis.value=="") ||   // More validation scripts at
                (document.theform1.telpdis.value=="") ||   // More validation scripts at  
                (document.theform1.faxdis.value=="") ||   // More validation scripts at          
                (document.theform1.emaildis.value=="") ||   // More validation scripts at 
                (document.theform1.jumtot.value=="") ||   // More validation scripts at       
                (document.theform1.jumbayar.value=="") ||   // More validation scripts at   
                (document.theform1.kembalian.value=="") ||   // More validation scripts at   
                (document.theform1.jumbayar.value=="NaN") ||   // More validation scripts at   
                (document.theform1.kembalian.value=="NaN") ||   // More validation scripts at      
                (document.theform1.jumtot.value==0) ||   // More validation scripts at       
                (document.theform1.jumbayar.value==0) ||   // More validation scripts at 
                (document.theform1.jumpv.value<200) ||   // More validation scripts at           
                (document.theform1.kembalian.value<0) ) // forms.javascriptsource.com                                                   
            {
                alert("Mohon lengkapi form pendaftaran mobil center baru terlebih dulu, pastikan produk yang dipointkan lebih dari 200 PV");
                return false;
            }

            else 
            {
                if (submitcount == 0)
                {
                    submitcount++;
                    return true;
                }
                else 
                {
                    alert("Form sedang diproses, silahkan tunggu hingga proses penyimpanan data selesai dilakukan. Silahkan tutup pesan ini untuk melanjutkan proses.");
                    return false;
                }
            }
        }
//  End -->

    </script>
    <script type='text/javascript'>
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mpCONTENT" Runat="Server">
</asp:Content>

