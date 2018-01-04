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
    <section class="content-header" style="background-color:white;">
        <div class="panel panel-default">
             <div class="panel-heading">
                <h3 class="text-center panel-title" style="font-family:Arial;">
                    <strong>PENDAFTARAN DISTRIBUTOR BARU UNTUK MENJADI MOBILE STOCKIEST 400</strong>
                </h3>
            </div>
            <form name="theform" method="post" action="sale_stater_save_ms4.aspx" onSubmit="return formCheck(this)">
                <div class="panel-body">
                    <div class="panel panel-default">
                         <div class="panel-heading">
                             <div class="panel-heading">
                                <h4 class="text-center panel-title" style="text-align:left;font-family:Arial;">PERHATIAN</h4>
                            </div>
                         </div>
                        <div class="panel-body">
                            <ol>
                                <li>
                                    Closing Date untuk bulan ini adalah pada tanggal, jam : <% hariakhir = Now.Date()%><br>
                                    <span style="color: red"><b><%=tutup1%> s.d <%=tutup2%></b><br></span>
                                    Semua transaksi yang dilakukan diantara closing period diatas, akan ditolak oleh sistem.<br>
                                </li>
                                <li>
                                    Semua transaksi yang sudah dibukukan tidak dapat dibatalkan, Untuk itu mohon periksa dan pastikan transaksi yang anda lakukan sudah benar ! 
                                    Sebelum memprosesnya ke checkout. Untuk itu pastikan anda sudah menerima formulir pendaftaran yang diisi lengkap 
                                    dan sudah menerima pembayaran sesuai tipe paket pendaftaran yang dipilih sebelum anda melakukan checkout.<br>
                                </li>
                                <li>
                                    Setelah anda melakukan checkout, maka proses selanjutnya adalah memasukan data calon distributor kedalam database jaringan HWI. 
                                    Apabila karena suatu sebab anda terpaksa menunda pemasukan data calon distributor tersebut,
                                    maka anda tidak akan dapat memasukan data dengan nomor seri pendaftaran tersebut. 
                                    Mohon hubungi kantor pusat untuk merelease lock nomor seri pendaftaran anda tersebut.<br />
                                </li>
                                <li>
                                    Paket pendaftaran yang memiliki jumlah stok minimal 1 yang akan ditampilkan didalam pulldown paket pendaftaran anda.<br>
                                </li>
                                <li>
                                    1 (nomor) invoice pembelanjaan berlaku untuk 1 (satu) calon distributor. Tanggal transaksi tidak dapat diubah dan menurut jam server (WIB).<br>
                                </li>
                                <li>
                                    <span style="color: red"><b>PASTIKAN</b></span> bahwa nomor id distributor yang menjadi sponsornya (direct sponsor) maupun upline penempatan sudah terdaftar 
                                    (sudah menjadi distributor HWI) dengan tanda munculnya nama di kotak direct sponsor dan upline penempatan.
                                    Kami tidak menerima revisi penggantian nomor distributor yang menjadi direct sponsornya dan upline penempatanya dengan alasan apapun. 
                                    Mohon pastikan dan konfirmasi kepada distributor baru tersebut sebelum anda menekan tombol checkout.<br>
                                </li>
                                <li style="background-color: yellow">
                                    <span style="color: red"><b>Setiap checkout harus segera dilanjutkan ke proses pendaftaran distributor.</b></span> 
                                    Pembelian paket pendaftaran yang tidak dilanjutkan ke proses pendaftaran akan expired setelah anda menutup sesi ini.<br />
                                </li>
                                <li style="background-color: yellow">
                                    <span style="color: red"><b>Pendaftaran ini digunakan untuk langsung mengaktifkan member menjadi mobile stockiest.</b></span> 
                                    Setelah member terdaftar, harus membeli produk hingga mencapai 500 PV, apabila tidak maka member hanya akan menjadi member biasa saja.
                                    <span style="color: red"><b>Apabila member sudah terdaftar sebagai Pendaftaran MS500, maka anda bisa langsung ke menu pembelian produk senilai 500 PV</b></span> 
                                    <span><b> 500 PV.</b></span>
                                </li>
                            </ol>
                        </div>

                    </div>

                    <%if mesej <> "" Then %>
                    <div style="padding-top: 10px">
                        <div class="alert alert-warning text-center" role="alert">
                            <span class="text-uppercase"><span style="text-decoration: underline; font-weight: bold;color:black;">ERROR MESSAGE</span></span><br />
                            <label style="color:red;"><%=mesej%></label>
                        </div>
                    </div>
                    <%end If%>

                    <div class="panel panel-default">
                        <div class="panel-body">
                            <div style="padding: 0px 20px 20px 20px">
                                <div class="col-md-3">
                                    <label>Tanggal Transaksi</label>
                                </div>
                                <div class="col-md-9">
                                    <input type="text" class="form-control" name="tgl" readonly onKeyDown="if(event.keyCode==13) event.keyCode=9;" value="<%=tgl%>">
                                </div>
                            </div>
                            <div style="padding: 20px 20px 20px 20px">
                                <div class="col-md-3">
                                    <label>Nama Calon Distributor</label>
                                </div>
                                <div class="col-md-6">
                                    <input type="text" class="form-control" name="nama" onKeyDown="if(event.keyCode==13) event.keyCode=9;" maxlength="50">
                                </div>
	                            <div class="col-md-3">
                                    <label><i>*maksimal 50 karakter</i></label>
                                </div>
                            </div>
                            <div style="padding: 20px 20px 20px 20px">
                                <div class="col-md-3">
                                    <label>Nomer Seri Pendaftaran</label>
                                </div>
                                <div class="col-md-6">
                                    <input type="text" class="form-control" name="noseri" readonly onKeyDown="if(event.keyCode==13) event.keyCode=9;" maxlength="17" value="-- auto --">
                                </div>
		                        <div class="col-md-3">
                                    <label><i>*akan digenerate sistem</i></label>
                                </div>
                            </div>
                            <div style="padding: 20px 20px 20px 20px">
                                <div class="col-md-3">
                                    <label>No. Id Direct Sponsor</label>
                                </div>
                                <div class="col-md-3">
                                    <input type="text" class="form-control" name="direk" id="direk" onChange="javascript:cari2(this)" onKeyDown="if(event.keyCode==13) event.keyCode=9;" maxlength="8">
                                </div>
		                        <div class="col-md-6">
                                    <input type="text" class="form-control" readonly name="namadirek" id="namadirek" onKeyDown="if(event.keyCode==13) event.keyCode=9;">
                                </div>
                            </div>    
                            <div style="padding: 20px 20px 20px 20px">
                                <div class="col-md-3">
                                    <label>Upline Penempatan</label>
                                </div>
                                <div class="col-md-9">
                                    <label>Tuliskan nomor id distributor yang menjad upline penempatan, Masukan id distributor direct sponsor apabila penempatan otomatis dibawah sponsor atau silahkan masukan nomor id distributor lainya.</label>
                                </div>
	                        </div>
                            <div style="padding: 20px 20px 20px 20px">
                                <div class="col-md-3">
                                    <label> </label>
                                </div>
                                <div class="col-md-3">
                                    <label>No. Id Upline</label>
                                </div>
                                <div class="col-md-6">
                                    <input type="text" class="form-control" name="upline" id="upline" onChange="javascript:cari3(this)" onKeyDown="if(event.keyCode==13) event.keyCode=9;" value="<%=aloc%>" maxlength="8">
                                </div>
                            </div>
                            <div style="padding: 25px 20px 20px 20px">
                                <div class="col-md-3">
                                    <label> </label>
                                </div>
                                <div class="col-md-3">
                                    <label>Nama Upline</label>
                                </div>
                                <div class="col-md-6">
                                    <input type="text" class="form-control" name="namaupline" id="namaupline" readonly onKeyDown="if(event.keyCode==13) event.keyCode=9;">
                                </div>
                            </div>
                            <div style="padding: 20px 20px 20px 20px">
                                <div class="col-md-3">
                                    <label> </label>
                                </div>
                                <div class="col-md-3">
                                    <label>Kaki</label>
                                </div>
                                <div class="col-md-6">
                                    <select class="form-control" name="kakiupline" onKeyDown="if(event.keyCode==13) event.keyCode=9;">
                                        <option value="L" selected="">Kiri</option>
                                        <option value="R">Kanan</option>
                                    </select>
                                </div>
                            </div>
		                    <div style="padding: 20px 20px 20px 20px">	
                                <div class="col-md-3">
                                    <label>Paket Pendaftaran</label>
                                </div>
                                <div class="col-md-9">
                                    <select class="form-control" name="paket" id="paket" onChange="javascript:cari(this);">
                                        <option value="--Silahkan Pilih--" selected="">--Silahkan Pilih--</option>
                                        <%
                                            pp = "AKT"
                                            ste = "T"
                                            minimal = 1
                                            if mypos <> dcpusate then
                                                if lcase(loguser) = "kris" Then
                                                    mlSQL = "SELECT kode,nama FROM " & namatabel & " WHERE nopos like '" & mypos & "' and grp like '" & pp & "' and jumlah >= '" & minimal & "' and ( kode like 'ms400-14' or kode like 'ms200-14' or kode like 'ms200%')"
                                                Else
                                                    mlSQL = "SELECT kode,nama FROM " & namatabel & " WHERE nopos like '" & mypos & "' and grp like '" & pp & "' and jumlah >= '" & minimal & "' and ( kode like 'ms400-14' or kode like 'ms200-14' or kode like 'ms200%')"
                                                End if
                                            else
                                                if lcase(loguser) = "kris" Then
                                                    mlSQL = "SELECT kode,nama FROM " & namatabel & " WHERE nopos like '" & mypos & "' and grp like '" & pp & "' and ( kode like 'ms400-14' or kode like 'ms200-14' or kode like 'ms200%')"
                                                Else
                                                    mlSQL = "SELECT kode,nama FROM " & namatabel & " WHERE nopos like '" & mypos & "' and grp like '" & pp & "' and sta like '" & ste & "' and ( kode like 'ms400-14' or kode like 'ms200-14' or kode like 'ms200%')"
                                                End if
                                            end If

                                            mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
                                            If mlREADER.HasRows Then
                                                mlDATATABLE = New Data.DataTable
                                                mlDATATABLE.Load(mlREADER)
                                                For aaaeqsK = 1 To mlDATATABLE.Rows.Count - 1
                                        %>
                                        <option value="<%=UCase(mlDATATABLE.Rows(aaaeqsK)("kode"))%>"><%=mlDATATABLE.Rows(aaaeqsK)("kode")%></option>
                                        <%
                                                Next
                                            End If
                                            mlREADER.Close()
                                        %>		
                                    </select>
                                </div>
                            </div>
                            <div style="padding: 20px 20px 20px 20px">
                                <div class="col-md-3">
                                    <label>Harga</label>
                                </div>
                                <div class="col-md-9">
                                    <input type="text" class="form-control" id="harga" name="harga" readonly onKeyDown="if(event.keyCode==13) event.keyCode=9;">
                                </div>
                            </div>
			                <div style="padding: 20px 20px 20px 20px">
                                <div class="col-md-3">
                                    <label>PV</label>
                                </div>
                                <div class="col-md-3">
                                    <input type="text" class="form-control" id="pv" name="pv" readonly onKeyDown="if(event.keyCode==13) event.keyCode=9;">
                                </div>
                                <div class="col-md-2">
                                    <label>BV</label>
                                </div>
                                <div class="col-md-4">
                                    <input type="text" class="form-control" id="bv" name="bv" readonly onKeyDown="if(event.keyCode==13) event.keyCode=9;">
                                </div>
                            </div>
			                <div style="padding: 20px 20px 20px 20px">
                                <div class="col-md-3">
                                    <label>Cara Pembayaran</label>
                                </div>
                                <div class="col-md-3">
                                    <label>Tunai</label>
                                </div>
                                <div class="col-md-6">
                                    <input type="text" class="form-control" name="jumbayarcash" onchange="quadratic1(this.form);" value="0" maxlength="8">
                                </div>
                            </div>
                            <div style="padding: 20px 20px 20px 20px">
                                <div class="col-md-3">
                                    <label> </label>
                                </div>
                                <div class="col-md-3">
                                    <label>Debit Card</label>
                                </div>
                                <div class="col-md-6">
                                    <input type="text" class="form-control" name="jumbayardb" onchange="quadratic1(this.form);" value="0" maxlength="8">
                                </div>
                            </div>
                            <div style="padding: 20px 20px 20px 20px">
                                <div class="col-md-3">
                                    <label> </label>
                                </div>
                                <div class="col-md-3">
                                    <label>Credit Card</label>
                                </div>
                                <div class="col-md-6">
                                    <input type="text" class="form-control" name="jumbayarcc" onchange="quadratic1(this.form);" value="0" maxlength="8">
                                </div>
                            </div>
                            <div style="padding: 20px 20px 20px 20px">
                                <div class="col-md-3">
                                    <label> </label>
                                </div>
                                <div class="col-md-3">
                                    <label>Voucher</label>
                                </div>
                                <div class="col-md-6">
                                    <input type="text" class="form-control" name="jumbayarcek" onchange="quadratic1(this.form);" value="0" maxlength="8">
                                </div>
                            </div>
                            <div style="padding: 20px 20px 20px 20px">
                                <div class="col-md-3">
                                    <label>Jumlah Pembayaran</label>
                                </div>
                                <div class="col-md-9">
                                    <input type="text" class="form-control" name="jumbayar" readonly value="0">
                                </div>
                            </div>
                            <div style="padding: 20px 20px 20px 20px">
                                <div class="col-md-3">
                                    <label>Jumlah Kembalian</label>
                                </div>
                                <div class="col-md-9">
                                    <input type="text" class="form-control" name="kembalian" readonly value="0">
                                </div>
                            </div>
                            <div></div>
                            <div style="padding: 20px 20px 20px 20px">
                                <div class="col-md-3">
                                    <label> </label>
                                </div>
                                <div class="col-md-9">
                                    <input class="btn btn-default" type="submit" name="btsub" value="Check Out">
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </form>
        </div>
    </section>
</asp:Content>

