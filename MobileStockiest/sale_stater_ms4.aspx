<%@ Page Title="" Language="VB" MasterPageFile="~/pagesetting/MsPageMS.master" AutoEventWireup="false" CodeFile="sale_stater_ms4.aspx.vb" Inherits="MobileStockiest_sale_stater_ms4" %>

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
            xmlhttp.open('get', 'getdata.aspx?kode=' + kode, true);
            xmlhttp.onreadystatechange = function () {
                if ((xmlhttp.readyState == 4) && (xmlhttp.status == 200)) {
                    var r = xmlhttp.responseXML.getElementsByTagName('data');
                    document.getElementById("harga").value = r[1].firstChild.data;
                    document.getElementById("pv").value = r[2].firstChild.data;
                    document.getElementById("bv").value = r[3].firstChild.data;
                }
                return false;
            }
            xmlhttp.send(null);
        }

        function cari2(teks) {
            var kode = teks.value;
            if (!kode) return;
            xmlhttp.open('get', 'getdatadirek.aspx?kode=' + kode, true);
            xmlhttp.onreadystatechange = function () {
                if ((xmlhttp.readyState == 4) && (xmlhttp.status == 200)) {
                    var r = xmlhttp.responseXML.getElementsByTagName('data');
                    document.getElementById("namadirek").value = r[1].firstChild.data;
                    document.getElementById("telpdirek").value = r[2].firstChild.data;
                }
                return false;
            }
            xmlhttp.send(null);
        }

        function cari3(teks) {
            var kode = teks.value;
            if (!kode) return;
            xmlhttp.open('get', 'getdataupline.aspx?kode=' + kode, true);
            xmlhttp.onreadystatechange = function () {
                if ((xmlhttp.readyState == 4) && (xmlhttp.status == 200)) {
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
            if (form.nama.value == "")
            {
                alert("Mohon isikan nama calon distributor");
                return false;
            }

            if (form.noseri.value == "")
            {
                alert("Nomor seri paket pendaftaran belum anda isikan");
                return false;
            }

            if (form.noseri.value.length >= 18)
            {
                alert("Nomor seri paket pendaftaran maksimal 7 karakter");
                return false;
            }

            if (form.direk.value == "")
            {
                alert("Silahkan tulis nomor id distributor sponsor");
                return false;
            }

            if (form.namadirek.value == "NOT FOUND")
            {
                alert("Silahkan tulis nomor id distributor sponsor");
                return false;
            }

            if (form.namadirek.value == "")
            {
                alert("Silahkan tulis nomor id distributor sponsor");
                return false;
            }

            if (form.upline.value == "")
            {
                alert("Silahkan pilih upline penempatan");
                return false;
            }

            if (form.namaupline.value == "NOT FOUND")
            {
                alert("Silahkan tulis nomor id distributor upline penempatan");
                return false;
            }

            if (form.namaupline.value == "")
            {
                alert("Silahkan tulis nomor id distributor upline penempatan");
                return false;
            }

            if (form.paket.value == "")
            {
                alert("Silahkan pilih paket pendaftaran anda");
                return false;
            }

            if (form.paket.value == "--Silahkan Pilih--")
            {
                alert("Silahkan pilih paket pendaftaran anda");
                return false;
            }

            if (form.harga.value == 0)
            {
                alert("Mohon pilih paket pendaftaran anda");
                return false;
            }

            if (form.jumbayar.value == 0)
            {
                alert("Mohon isikan jumlah pembayaran");
                return false;
            }

            if (confirm("Cek sekali lagi, apakah data yang Anda isi SUDAH BENAR semuanya ? Transaksi yang sudah dibukukan tidak dapat dibatalkan, mohon periksa sekali lagi sebelum check out : \n\nNama Calon Distributor : " + form.nama.value + ".\nNomor Seri : " + form.noseri.value + "\nPaket Pendaftaran : " + form.paket.value + "\nHarga : " + form.harga.value + "\nPembayaran : " + form.jumbayar.value + "\nDirect Sponsor : " + form.direk.value + "\nNama Direct Sponsor : " + form.namadirek.value + "\nUpline Penempatan : " + form.upline.value + "\nNama Upline : " + form.namaupline.value + "\nnKaki Upline : " + form.kakiupline.value + "\n"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    </script>
    <script type='text/javascript'>
        function quadratic1(form1) {
            var tunai = eval(form1.jumbayarcash.value);
            var cc = eval(form1.jumbayarcc.value);
            var db = eval(form1.jumbayardb.value);
            var cek = eval(form1.jumbayarcek.value);
            var jto = eval(form1.harga.value);
            {
                form1.jumbayar.value = tunai + cc + db + cek;
                form1.kembalian.value = (tunai + cc + db + cek) - jto;
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mpCONTENT" Runat="Server">
</asp:Content>

