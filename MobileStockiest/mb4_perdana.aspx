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
        function Navigate(drop_down_list) {
            var number = drop_down_list.selectedIndex;
            location.href = drop_down_list.options[number].value;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mpCONTENT" Runat="Server">
    <section class="content-header" style="background-color:white;">
        <div class="panel panel-default">
            <div class="panel-heading">
                <h3 class="text-center panel-title" style="font-family:Arial;">
                    <strong>PENDAFTARAN MOBILE STOCKIEST MS400</strong>
                </h3>
            </div>
            <div class="panel-body">
                <%if sutepe = "PRD" Then %>
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h4 class="text-center panel-title" style="text-align:left;font-family:Arial;">(#1) PERATURAN</h4>
                    </div>
                    <div class="panel-body">
                        <ol>
                            <li>
                                Secara default, data-data mobile stockiest seperti alamat, 
                                nomor telepeon dan informasi lainnya sama dengan data sebagai distributor, 
                                dapat diganti dicontrol panel mobile stockiest
                            </li>
                            <li>
                                Nomor id mobile stockiest adalah : MS+"-" nomor id distrobutor, 
                                sebagai contoh 100001 menjadi mobile stockiest, 
                                maka id mobile stockiestnya adalah MS-100001 dengan login page pada alamat http://heallthwealthint.com/mobilestockiest
                            </li>
                            <li>
                                Password login ke control panel mobile stockiest secara default adalah password loginnya sebagai distributor
                                , namun dapat diganti pada control panel mobile stockiest.
                            </li>
                            <li>
                                Order perdana bagi mobile stockiest baru, medaftar dengan paket MS400
                            </li>
                            <li>Order perdana ini sekaliigus sebagai sarana untuk mengaktifkan distributor menjadi mobile stockiest</li>
                            <li>
                                <span style="color: red">
                                    Setelah anda menekan tombol "Release Order &amp; Daftarkan Mobile Stockiest", 
                                    maka sistem akan secara otomatis mengaktifkan status mobile stockiest distributor yang id nya didaftarkan 
                                    dan mengalahkan stock DC menjadi stock mobile stockiest
                                    sesuai yang diorder, Pastikan anda sudah mengisi dengan benar item barang yang diorder 
                                    dan nomor id distriibutor yang menjadi mobile stockiest. 
                                    <span style="background-color: yellow">
                                        Semua kesalahan yang membutuhkan pembatalan tidak dapat dilkakukan dan sepenuhnya menjadi tanggung
                                        jawab DC / Mobile stockiest yang bersangkutan.
                                    </span>
                                </span>
                            </li>
                        </ol>
                        <h3 style="color:red;font-family:Arial;">
                            <span style="font-weight: bold">PENTING!!!<br>
				                Untuk daftar new member MS400 harus mengisi data MS terlebih dahulu. baru dapat melanjutkan ke Pendaftaran.
                            </span>
				        </h3>
                    </div>
                </div>

                <%if mesej <> "" then %>
                <div style="padding-top: 10px">
                    <div class="alert alert-warning text-center" role="alert">
                        <span class="text-uppercase"><span style="text-decoration: underline; font-weight: bold;color:black;">ERROR MESSAGE</span></span><br />
                        <label style="color:red;"><%=mesej%></label>
                    </div>
                </div>
                <%end If%>
                <div class="panel panel-default">
                    <div class="panel-body">
                         <p class="text-center">
                            <span style="background-color: yellow; font-weight: bold">
                                SESSION BELANJAAN INI <br />AKAN AKAN EXPIRED APABILA ANDA TIDAK MEMPROSES DALAM <br>WAKTU 10 MENIT
                            </span>
                        </p>
                        <%if mypos = dcHO then %>
                        <p class="text-center">
                            <span style="color: red; font-weight: bold">
                                PERHATIAN KHUSUS KANTOR PUSAT 
                            </span><br>Khusus kantor pusat, apabila ada mobile stockiest berbelanja dikantor pusat :
                        </p>
                        <p class="text-center">
                            <span style="text-decoration: underline; color: red; font-weight: bold">DIAMBIL </span><br/>
                            Maka harga gunakan zona / area jawa (1) <br/>Silahkan pilih zona 1 pada pilihan kirim ke zona untuk men-set harga yang sesuai.
                        </p>
                        <p class="text-center">
                            <span style="text-decoration: underline; color: red; font-weight: bold">DIKIRIM </span><br/>
                            Maka harga gunakan zona / area mobile stockiest tersebut <br/>
                            Silahkan pilih zona yang sesuai zona MC pada pilihan kirim ke zona untuk men-set harga yang sesuai
                        </p>
                        <p class="text-center">Keterangan Zona <br/>
                            Zona 1: Jawa, Bali, Lampung, Bengkulu, Babel, Palembang <br/>
                            Zona 2: Mataram, Lombok, NTB, Kalimantan, Sulsel, Sulbar <br/>
                            Zona 3: Papua, Maluku, Sulawesi Tenggara, Sulut, Sulteng <br/>
                            Zona 4: NTT <br>
                            Zona 5: Sumbar, Sumut, Aceh
                        </p>
                        <%end if%>
                    </div>
                </div>
                <form name="theform" method="post" action="mb4_perdana_ck.aspx" onSubmit="return formCheck(this)">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h4 class="text-center panel-title" style="text-align:left;font-family:Arial;">(#3) CHECK OUT</h4>
                        </div>
                        <div class="panel-body">
                            <p class="text-center">
                                <span style="color: red; font-weight: bold">
                                    SEMUA ORDERAN YANG TELAH DISUBMIT DENGAN MENEKAN TOMBOL <br/>
                                <span style="text-decoration: underline; color: black">
                                    "Release Order &amp; Register mobile stockiest"
                                </span> 
                                DIBAWAH INI, <br/>
                                TIDAK DAPAT DIBATALAKAN ATAU DIREVISI ! <br/>KAMI TIDAK MELAYANI PERMINTAAN PEMBATALAN DENGAN ALASAN APAPUN
                                </span> 
                            </p>
                            <p>
                                <span style="text-decoration: underline; font-weight: bold">
                                    PERJANJIAN DAN PERSETUJUAN SEBAGAI MOBILE STOCKIEST PT. HEALTH WEALTH INTERNATIONAL
                                </span>
                            </p>
                            <textarea rows="8" name="setujuform" readonly class="form-control n-resize">
                                SYARAT DAN KETENTUAN MOBILE STOCKIEST  (MS 400)
                                a. Pemilik Mobile Stockiest (MS 400) adalah Distributor HWI.
                                b. Tidak terlibat langsung maupun tidak langsung dengan bisnis MLM lain.
                                c. Bergabung sebagai Mobile Stockiest (MS 400) dengan cara membeli paket aktivasi Mobile Stockiest (MS400)
                                d. Mobile Stockiest (MS400) setiap bulannya hanya dapat menyimpan 750 PV. Kelebihan PV diatas 750 PV ini akan secara otomatis dialokasikan sebagai auto maintenance 200PV/bulan untuk Mobile Stockiest (MS) yang bersangkutan
                                e. Apabila dalam jangka waktu 3 (tiga) bulan berturut-turut tidak pernah repeat order minimal dalam 1 (satu invoice) pada satu bulan (bukan akumulasi) sebesar minimal Rp. 2.000.000,- (dua juta rupiah) setelah diskon MS, maka Mobile Stockiest yang bersangkutan tidak dapat memperoleh potongan sebagai MS pada repeat order berikutnya. Kegiatan sebagai Mobile Stockist tetap dapat dilakukan sebagaimana biasanya, namun tidak akan mendapatkan potongan sebagai Mobile Stockist pada saat melakukan repeat order pembelian produk ke D.C
                                f. Untuk dapat memperoleh potongan sebagai Mobile Stockist lagi, maka diharuskan melakukan pembelanjaan sebesar minimal Rp 3.000.000,- (tiga juta rupiah) pembelanjaan ini tidak mendapatkan potongan sebagai sanksi, order berikutnya baru akan memperoleh potongan sebagai Mobile Stockist.

                                LINGKUP KERJASAMA

                                a. PIHAK KEDUA selaku Pengelola Mobile Stockist ( MS 400 ) resmi HWI memasarkan dan menjual produk-produk HWI kepada seluruh distributor tanpa membeda-bedakan jaringan.
                                b. Mobile Stockist ( MS 400 ) sebagai pusat informasi dan pelayanan bisnis Network Marketing HWI, dalam aktifitas operationalnya tidak terlibat atau menjual produk-produk lain dari perusahaan Multi Level lain.
                                c. Mobile Stockist ( MS 400 ) berkewajiban sepenuhnya mengikuti tata cara yang ditentukan oleh HWI dalam hal laporan dan administasi.
                                d. Apabila Mobile Stockist ( MS 400 )  melakukan tindakan-tindakan yang melanggar isi perjanjian kerja sama Mobile Stockist ( MS 400 ) dan atau aturan dan peraturan perusahaan atau mencemarkan nama baik perusahaan dan atau melakukan tindakan yang meresahkan dan atau merugikan perusahaan maka Mobile Stockist ( MS 400 ) akan diberikan sanksi dari mulai teguran, Surat peringatan, sampai dengan penutupan Mobile Stockist ( MS 400 ).

                                PENUTUP

                                Hal-hal yang belum diatur dalam perjanjian ini merupakan ketentuan-ketentuan tambahan, maka hal ini akan diatur secara tertulis dan merupakan bagian yang mengikat dan tidak terpisahkan dari perjanjian kerjasama ini.
                                Perjanjian ini dibuat 2 (dua) rangkap dan masing-masing pihak mendapat 1 (satu) rangkap. Perjanjian ini sah berlaku dan mengikat serta mempunyai kekuatan hukum setelah ditanda tangani diatas materai sesuai ketentuan yang berlaku.
		                    </textarea>
                            <div class="checkbox">
                                <label>
                                    <input type="checkbox" name="setuju" value="AGREE" required>Saya Menyatakan persetujuan dan tunduk terhadap semua yang sudah diatur didalamnya (mohon diclick)
                                </label>
                            </div>
                        </div>
                    </div>
                    <div class="panel panel-default">
                        <div class="panel-body">
                            <p><span style="text-decoration: underline; font-weight: bold">Check Out &amp; Data mobile stockiest Baru <%=AREA_ID%> - <%=nosesifaxmc_pdn%></span></p>
                            <div style="padding: 20px 20px 20px 20px">
                                <div class="col-md-3">
                                    <label>DC Asal</label>
                                </div>
                                <div class="col-md-9">
                                    <input class="form-control" type="text" readonly name="dc_asal" value="<%=ucase(mypos)%>">
                                    <%
                                        If nokode_m = "" Then
                                        Else
                                    %>
                                    &nbsp;
                                    <label style="color:#FF0000;"><b>Distributor Baru yang bernama <%=namae%> ber Id <%=nokode_m%>.</b></label>
                                    <%end if%>
                                </div>
			                </div>
			                <div style="padding: 20px 20px 20px 20px">
                                <div class="col-md-3">
                                    <label>Username </label>
                                </div>
                                <div class="col-md-9">
                                    <input class="form-control" type="text" name="nama_user" id="nama_user" value="<%=namamu%>">
                                </div>
			                </div>
			                <div style="padding: 20px 20px 20px 20px">
                                <div class="col-md-3">
                                    <label>Alamat Mobile Stockiest</label>
                                </div>
                                <div class="col-md-9">
                                    <textarea rows="3" name="alamatdis" id="alamatdis" cols="63" style="font-size: 8pt; font-family: Verdana; border: 1px solid #000000; "><%=alamatdis%></textarea>
                                </div>
			                </div>
			                <div style="padding: 20px 20px 20px 20px">
                                <div class="col-md-3">
                                    <label>Kota Alamat</label>
                                </div>
                                <div class="col-md-9">
                                    <input class="form-control" type="text" name="kotadis" id="kotadis" value="<%=kotadis%>">
                                </div>
			                </div>
			                <div style="padding: 20px 20px 20px 20px">
                                <div class="col-md-3">
                                    <label>Kode Pos</label>
                                </div>
                                <div class="col-md-9">
                                    <input class="form-control" type="text" name="kodeposdis" id="kodeposdis" value="<%=kodeposdis%>">
                                </div>
			                </div>
			                <div style="padding: 20px 20px 20px 20px">
                                <div class="col-md-3">
                                    <label>Propinsi </label>
                                </div>
                                <div class="col-md-9">
                                    <select class="form-control" name="propinsidis" id="propinsidis" onKeyDown="if(event.keyCode==13) event.keyCode=9;">
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
									    <option value="<%= mlDT.Rows(aaaeqsK)("deskripsi")%>" selected><%= mlDT.Rows(aaaeqsK)("deskripsi")%></option>
										<%else%>
										<option value="<%= mlDT.Rows(aaaeqsK)("deskripsi")%>"><%= mlDT.Rows(aaaeqsK)("deskripsi")%></option>
										<%end if%> 
                                        <%
                                                    Next
                                                End If
                                                mlDR.Close()
										%>
                                    </select>
                                </div>
			                </div>
			                <div style="padding: 20px 20px 20px 20px">
                                <div class="col-md-3">
                                    <label>No. Telp / HP</label>
                                </div>
                                <div class="col-md-9">
                                    <input class="form-control" type="text" name="telpdis" id="telpdis" value="<%=telpdis%>">
                                </div>
			                </div>
			                <div style="padding: 20px 20px 20px 20px">
                                <div class="col-md-3">
                                    <label>No. Fax</label>
                                </div>
                                <div class="col-md-9">
                                    <input class="form-control" type="text" name="faxdis" id="faxdis" value="<%=faxdis%>">
                                </div>
			                </div>
			                <div style="padding: 20px 20px 20px 20px">
                                <div class="col-md-3">
                                    <label>Alamat Email</label>
                                </div>
                                <div class="col-md-9">
                                    <input class="form-control" type="text" name="emaildis" id="emaildis" value="<%=emaildis%>">
                                </div>
			                </div>
                            <input type="hidden" name="cara">
			                <div style="padding: 20px 20px 20px 20px">
                                <div class="col-md-3">
                                    <label>Zona / Area M.S</label>
                                </div>
                                <div class="col-md-9">
                                    <select class="form-control" name="zona" onKeyDown="if(event.keyCode==13) event.keyCode=9;">
                                        <%      
                                            pp = "zno"
                                            mlQuery = "SELECT * FROM tabdesc WHERE grp like '" & pp & "' order by ket"
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
                                    </select>
                                </div>
			                </div>
                            <div style="padding: 20px 20px 20px 20px">
                                <div class="col-md-3">
                                    <label> </label>
                                </div>
                                <div class="col-md-9">
                                    <input class="btn btn-default" type="submit" name="btsbs0" value="Release Order &amp; Daftarkan Mobile Stockiest">
                                    <p><br/>
                                        <span style="background-color: yellow; color: red; font-weight: bold">
                                            PASTIKAN ANDA SUDAH MENGISI DATA DENGAN BENAR ! 
                                        </span><br/>
                                        Klik Sekali Saja dan tunggu hingga keluar invoice
                                    </p>
                                </div>
                            </div>
                        </div>
                    </div>
                </form>

                <%if error1 <> "" Then %>
                <p style="text-align:center;color:#FF0000"><%=error1%></p>
                <%End If%>

                <%else%>
                <div class="panel panel-default">
                    <div class="panel-body">
                        <b style="font-size:larger;color:#FF0000;">
	                        Ada session yang masih terbuka, silahkan di close session terlebih dulu atau batalkan terlebih dulu....
                        </b>
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

