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
    <section class="content-header" style="background-color:white;">
        <div class="panel panel-default">
            <div class="panel-heading">
                <h3 class="text-center panel-title" style="font-family:Arial;">
                    <strong>PENDAFTARAN MOBILE STOCKIEST DARI EXISTING DISTRIBUTOR MS400</strong>
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
                                Secara default, data-data mobile stockiest seperti alamat, nomor telepeon dan informasi lainnya sama dengan data sebagai distributor, dapat diganti dicontrol panel mobile stockiest
                            </li>
                            <li>
                                Nomor id mobile stockiest adalah : MS+"-" nomor id distrobutor, sebagai contoh 100001 menjadi mobile stockiest, maka id mobile stockiestnya adalah MS-100001 dengan login page pada alamat http://heallthwealthint.com/mobilestockiest
                            </li>
                            <li>
                                Password login ke control panel mobile stockiest secara default adalah password loginnya sebagai distributor, namun dapat diganti pada control panel mobile stockiest.
                            </li>
                            <li>
                                Order perdana bagi mobile stockiest baru, medaftar dengan paket MS400
                            </li>
                            <li>
                                Order perdana ini sekaliigus sebagai sarana untuk mengaktifkan distributor menjadi mobile stockiest
                            </li>
                            <li>
                                <span style="color: red">
                                    Setelah anda menekan tombol "Release Order &amp; Daftarkan Mobile Stockiest"
                                    , maka sistem akan secara otomatis mengaktifkan status mobile stockiest distributor yang id nya didaftarkan dan mengalahkan stock DC menjadi stock mobile stockiest sesuai yang diorder
                                    , Pastikan anda sudah mengisi dengan benar item barang yang diorder dan nomor id distriibutor yang menjadi mobile stockiest. 
                                    <span style="background-color: yellow">
                                        Semua kesalahan yang membutuhkan pembatalan tidak dapat dilkakukan dan sepenuhnya menjadi tanggung jawab DC / Mobile stockiest yang bersangkutan.
                                    </span>
                                </span>
                            </li>
                        </ol>
                    </div>
                </div>
                
                <%if mesej <> "" then %>
                <div style="padding-top: 10px">
                    <div class="alert alert-warning text-center" role="alert">
                        <span class="text-uppercase">
                            <span style="text-decoration: underline; font-weight: bold;color:black;">ERROR MESSAGE</span>
                            <label style="color:red;"><%=mesej%></label>
                        </span>
                    </div>
                </div>
                <%end If%>

                <div class="panel panel-default">
                    <div class="panel-body">
                         <div style="padding: 10px 30px 10px 30px; background-color: white;">
		                    <p class="text-center"><span style="font-weight: bold">Silahkan pilih Paket Upgrade (cukup 1 saja) :</span><br>
                                <% 
                                    mlQuery = "SELECT kode,nama FROM st_barang_ms WHERE nopos like '" & mypos & "' and jumlah > 0" & vbCrLf
                                    mlQuery += "And ( kode like 'ms400u-14' or kode like 'ms200u-14' or kode like 'ms200au-14' or kode like 'ms200vus-14'" & vbCrLf
                                    mlQuery += "or kode like 'ms200vu-14' or kode like 'ms200bu-14' or kode like 'ms200hu-14' or kode like 'ms200tg272u-14'" & vbCrLf
                                    mlQuery += "Or kode like 'ms100tg248u-14' or kode like 'ms200mu-14' or kode like 'ms200ku-14')"

                                    mlDR = mlOBJGS.DbRecordset(mlQuery, mpMODULEID, mlCOMPANYID)
                                    If mlDR.HasRows Then
                                        mlDT = New Data.DataTable
                                        mlDT.Load(mlDR)
                                        For aaaeqsK = 1 To mlDT.Rows.Count - 1
                                %>
                                    <a href="ms4_perdana_add.aspx?kode=<%=UCase(mlDT.Rows(aaaeqsK)("kode"))%>&jumlah=1">
                                        <label>- Upgrade Paket <%=UCase(mlDT.Rows(aaaeqsK)("kode"))%> </label>
								    </a>
                                <%
                            Next
                        End If
                        mlDR.Close()
                                %>
		                    </p>
                            <p class="text-center"><span style="background-color: yellow; font-weight: bold">SESSION BELANJAAN INI</span><br>AKAN AKAN EXPIRED APABILA ANDA TIDAK MEMPROSES DALAM <br>WAKTU 10 MENIT</p>
                            <%if mypos = dcHO then %>
                            <p class="text-center"><span style="color: red; font-weight: bold">PERHATIAN KHUSUS KANTOR PUSAT </span><br>Khusus kantor pusat, apabila ada mobile stockiest berbelanja dikantor pusat :</p>
                            <p class="text-center"><span style="text-decoration: underline; color: red; font-weight: bold">DIAMBIL </span><br>Maka harga gunakan zona / area jawa (1) <br>Silahkan pilih zona 1 pada pilihan kirim ke zona untuk men-set harga yang sesuai.</p>
                            <p class="text-center"><span style="text-decoration: underline; color: red; font-weight: bold">DIKIRIM </span><br>Maka harga gunakan zona / area mobile stockiest tersebut <br>Silahkan pilih zona yang sesuai zona MC pada pilihan kirim ke zona untuk men-set harga yang sesuai</p>
                            <p class="text-center">Keterangan Zona <br />Zona 1: Jawa, Bali, Lampung, Bengkulu, Babel, Palembang <br />Zona 2: Mataram, Lombok, NTB, Kalimantan, Sulsel, Sulbar <br />Zona 3: Papua, Maluku, Sulawesi Tenggara, Sulut, Sulteng <br />Zona 4: NTT <br />Zona 5: Sumbar, Sumut, Aceh</p>
                            <%end if%>
                        </div>
                    </div>
                </div>

                <form name="theform1" method="post" action="ms4_perdana_ck.aspx" onSubmit="return checkFields()">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h4 class="text-center panel-title" style="text-align:left;font-family:Arial;">(#2) KERANJANG BELANJAAN</h4>
                        </div>
                        <div class="panel-body">
                            <p>
                                Dibawah ini adalah daftar belanjaan top up saat ini. Anda dapat menghapus / membatalkan item belanjaan top up dibawah ini. Pembatalan item belanjaan top up hanya dapat dilakukan sebelum sesi belanja ini ditutup
                                , sesi belanja ini ditutup dengan menekan tombol check out.
                            </p>
		                    <div class="table-responsive">
			                    <table class="table table-condensed table-bordered">
				                    <thead>
					                    <tr>
						                    <td style="width:6%;"><strong>Kode</strong></td>
						                    <td style="width:29%;"><strong>Nama Produk</strong></td>
						                    <td style="width:10%;"><strong>PV</strong></td>
						                    <td style="width:8%;"><strong>Qty.</strong></td>
						                    <td style="width:13%;"><strong>Harga</strong></td>
						                    <td style="width:20%;"><strong>Sub Total</strong></td>
						                    <td style="width:5%;"><strong>Aksi</strong></td>
					                        </tr>
				                    </thead>
				                    <tbody>
                                        <%      totpv = 0
                                                totbv = 0
                                                gtot = 0
                                                pot = 0
                                                neto = 0
                                                newsubtot = 0
                                                newtotpv = 0
                                                gtotnet = 0
                                                jumdisk = 0
                                                jumtotdis = 0
                                                brapadis = 0
                                                disk_mcla = disk_mc
                                                disk_mclama = 0
                                                pvmin = 0
                                                mlQuery = "SELECT * FROM fx_order_mc_det where nopos like '" & mypos & "' and nosesi like '" & nosesifaxmc_pdn & "' and status like '" & sds & "' and kat like '" & kti & "' order by id"
                                                mlDR = mlOBJGS.DbRecordset(mlQuery, mpMODULEID, mlCOMPANYID)
                                                If Not mlDR.HasRows Then
                                        %>
                                        <tr>
						                    <td class="text-center" colspan="8"><span style="text-decoration: underline">Sesi ini belum ada belanjaan</span></td>
					                    </tr>
                                        <%
                                                End If
                                                If mlDR.HasRows Then
                                                    mlDT = New Data.DataTable
                                                    mlDT.Load(mlDR)
                                                    For aaaeqSSS = 1 To mlDT.Rows.Count - 1
                                                        kode = mlDT.Rows(aaaeqSSS)("kode")
                                                        jums = mlDT.Rows(aaaeqSSS)("jumlah")
                                                        mlQuery2 = "SELECT * FROM st_barang where kode like '" & kode & "'"
                                                        mlDR2 = mlOBJGS.DbRecordset(mlQuery2, mpMODULEID, mlCOMPANYID)
                                                        mlDR2.Read()
                                                        If mlDR2.HasRows Then
                                                            harga1 = mlDR2("hd1")
                                                            kusus1 = mlDR2("khususmc1")
                                                            harga2 = mlDR2("hd2")
                                                            kusus2 = mlDR2("khususmc2")
                                                            harga3 = mlDR2("hd3")
                                                            kusus3 = mlDR2("khususmc3")
                                                            harga4 = mlDR2("hd4")
                                                            kusus4 = mlDR2("khususmc4")
                                                            harga5 = mlDR2("hd5")
                                                            kusus5 = mlDR2("khususmc5")
                                                            PV = mlDR2("pv")
                                                            bv = mlDR2("bv")
                                                            nama = mlDR2("nama")
                                                            If area_id = 1 Then
                                                                If kusus1 <> 0 Then
                                                                    harga = harga1
                                                                    disk_mc = 0
                                                                Else
                                                                    harga = harga1
                                                                    disk_mc = disk_mc
                                                                End If
                                                            Else
                                                                If area_id = 2 Then
                                                                    If kusus2 <> 0 Then
                                                                        harga = harga2
                                                                        disk_mc = 0
                                                                    Else
                                                                        harga = harga2
                                                                        disk_mc = disk_mc
                                                                    End If
                                                                Else
                                                                    If area_id = 3 Then
                                                                        If kusus3 <> 0 Then
                                                                            harga = harga3
                                                                            disk_mc = 0
                                                                        Else
                                                                            harga = harga3
                                                                            disk_mc = disk_mc
                                                                        End If
                                                                    Else
                                                                        If area_id = 4 Then
                                                                            If kusus4 <> 0 Then
                                                                                harga = harga4
                                                                                disk_mc = 0
                                                                            Else
                                                                                harga = harga4
                                                                                disk_mc = disk_mc
                                                                            End If
                                                                        Else
                                                                            If area_id = 5 Then
                                                                                If kusus5 <> 0 Then
                                                                                    harga = harga5
                                                                                    disk_mc = 0
                                                                                Else
                                                                                    harga = harga5
                                                                                    disk_mc = disk_mc
                                                                                End If
                                                                            End If
                                                                        End If
                                                                    End If
                                                                End If
                                                            End If
                                                            If disk_mc > 0 Then
                                                                disk_mclama = disk_mcla
                                                            End If
                                                        End If
                                                        mlDR2.Close()

                                                        mlQuery2 = "update st_barang set harga = '" & harga & "',subtot = " & harga * jums & " where kode like '" & kode & "'"
                                                        mlOBJGS.ExecuteQuery(mlQuery2, mpMODULEID, mlCOMPANYID)

                                                        newsubtot = newsubtot + mlDT.Rows(aaaeqSSS)("subtot")
                                                        newtotpv = newtotpv + (mlDT.Rows(aaaeqSSS)("pv") * mlDT.Rows(aaaeqSSS)("jumlah"))

                                                        Session.LCID = 2057 ' setting desimal & local setting untuk indonesia 2057 = uk
                                                        'intLocale = SetLocale(2057) ' setting desimal & local setting untuk indonesia

                                                        disk_mc = disk_mclama
                                                        mlQuery2 = "UPDATE fax_order_mc_head SET totpv = '" & newtotpv & "', subtot = '" & newsubtot & "', potongan = 0, gtot = 0, diskon = '" & disk_mc & "'" & vbCrLf
                                                        mlQuery2 += "WHERE nopos Like '" & mypos & "' and nosesi like '" & nosesifaxmc_pdn & "' and dcinduk like '" & indukdc & "'"
                                                        mlOBJGS.ExecuteQuery(mlQuery2, mpMODULEID, mlCOMPANYID)

                                                        Session.LCID = 1057 ' setting desimal & local setting untuk indonesia 2057 = uk
                                                        'intLocale = SetLocale(1057) ' setting desimal & local setting untuk indonesia

                                                        If area_id <> 0 Then
                                                            gtot = gtot + mlDT.Rows(aaaeqSSS)("subtot")
                                                            totpv = totpv + (mlDT.Rows(aaaeqSSS)("pv") * mlDT.Rows(aaaeqSSS)("jumlah"))
                                                            totbv = 0
                                                        Else
                                                            gtot = 0
                                                            totpv = totpv + (mlDT.Rows(aaaeqSSS)("pv") * mlDT.Rows(aaaeqSSS)("jumlah"))
                                                            totbv = 0
                                                        End If

                                                        'baru sampe sini 30 september 2017
                                                        ''''''''''''''''''''''''''''''''''''
                                                        ' diskon untuk produk vcd yess
                                                        ''''''''''''''''''''''''''''''''''''
                                                        If Left(UCase(mlDT.Rows(aaaeqSSS)("kode")), 4) = "YVCD" Then
                                                            jumtotdis = jumtotdis + mlDT.Rows(aaaeqSSS)("jumlah")
                                                        Else
                                                            jumtotdis = jumtotdis
                                                        End If

                                                        If UCase(mlDT.Rows(aaaeqSSS)("kode")) = "YBKBPRO" Then
                                                            If mlDT.Rows(aaaeqSSS)("jumlah") >= 25 Then
                                                                kurangi = harga - 6500
                                                                jumdis = kurangi * mlDT.Rows(aaaeqSSS)("jumlah")
                                                            Else
                                                                kurangi = 0
                                                                jumdis = 0
                                                            End If
                                                        End If
                                        %>
                                         <tr>
						                    <td style="width:10%;">&nbsp;&nbsp;<%=UCase(mlDT.Rows(aaaeqSSS)("kode"))%></td>
                                            <td style="width:36%;">&nbsp;&nbsp;<%=mlDT.Rows(aaaeqSSS)("nama")%></td>
                                            <td style="width:11%;text-align:right;"><%=FormatNumber(mlDT.Rows(aaaeqSSS)("pv"), 2)%></td>
                                            <td style="width:8%;text-align:right;"><%=FormatNumber(mlDT.Rows(aaaeqSSS)("jumlah"), 0)%>&nbsp;</td>
                                            <td style="width:12%;text-align:right;"><%=FormatNumber(mlDT.Rows(aaaeqSSS)("harga"), 0)%>&nbsp;</td>
                                            <td style="width:16%;text-align:right;"><%=FormatNumber(mlDT.Rows(aaaeqSSS)("subtot"), 0)%>&nbsp;</td>
                                            <td style="width:7%;"><p style="text-align:center;"><a href="ms4_perdana_clear.aspx?grp=PRD">DEL</a></td>
					                    </tr>
                                        <%
                                                    Next
                                                End If
                                                mlDR.Close()

                                                If area_id <> 0 Then
                                                    pot = (((totpv * disk_mc) / 100) * 2000)
                                                    'neto = gtot-pot
                                                Else
                                                    pot = 0
                                                    neto = 0
                                                End If

                                                ''''''''''''''''''''''''''''''''''''
                                                ' diskon untuk produk vcd yess
                                                ''''''''''''''''''''''''''''''''''''
                                                jumdisk = 0
                                                If jumtotdis > 0 Then
                                                    brapadis = jumtotdis \ 2
                                                    jumdivc = brapadis * 3000
                                                    jumdisk = jumdis + jumdivc
                                                Else
                                                    jumdivc = 0
                                                    jumdisk = jumdis + jumdivc
                                                End If

                                                neto = gtot - jumdisk

                                                'if jumdisk > 0 then
                                                mlQuery = "SELECT * FROM fax_order_mc_head where nosesi like '" & nosesifaxmc_pdn & "' and nopos like '" & mypos & "' and dcinduk like '" & indukdc & "'"
                                                mlDR = mlOBJGS.DbRecordset(mlQuery, mpMODULEID, mlCOMPANYID)
                                                mlDR.Read()
                                                If mlDR.HasRows Then
                                                    sbt = mlDR("subtot")

                                                    mlQuery2 = "update fax_order_mc_head set diskonamt = '" & jumdisk & "',totbruto = '" & sbt & "' where nosesi like '" & nosesifaxmc_pdn & "' and nopos like '" & mypos & "' and dcinduk like '" & indukdc & "'"
                                                    mlOBJGS.ExecuteQuery(mlQuery2, mpMODULEID, mlCOMPANYID)
                                                End If
                                                mlDR.Close()
										%>
					                    <tr>
						                    <td class="text-right" colspan="6"><strong>GRAND TOTAL&nbsp;&nbsp;</strong></td>
						                    <td><p style="text-align:right;"><%=FormatNumber(neto, 0)%>&nbsp;</td>
						                    <td>&nbsp;</td>
					                    </tr>
				                    </tbody>
			                    </table>
		                    </div>
                            <%if gtot > 0 then %>
	                        <p style="text-align:center;"><span style="background-color: yellow; color: red; font-weight: bold">BATALKAN SESI BELANJA INI & BIKIN SESI BARU</span></p>
                            <%else%>
                            <p>&nbsp;</p>
                            <%end if%>
                        </div>
                    </div>

                    <%if jumskr > 0 and nosesifaxmc_pdn <> "" then %>
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h4 class="text-center panel-title" style="text-align:left;font-family:Arial;">(#3) CHECK OUT</h4>
                        </div>
                        <div class="panel-body">
                            <p class="text-center">
                                <span style="color: red; font-weight: bold">SEMUA ORDERAN YANG TELAH DISUBMIT DENGAN MENEKAN TOMBOL<br/>
                                <span style="text-decoration: underline; color: black">"Release Order &amp; Register mobile stockiest"</span> DIBAWAH INI, <br/>
                                TIDAK DAPAT DIBATALAKAN ATAU DIREVISI ! <br>KAMI TIDAK MELAYANI PERMINTAAN PEMBATALAN DENGAN ALASAN APAPUN </span>
                            </p>

                            <div style="padding-top: 10px">
                                <div class="alert alert-info text-center">
                                    <p style="text-align:center;">
									    <b style="color:white;font-size:larger;">
										    JUMLAH TOTAL PEMBELANJAAN
									    </b>
								    </p>
                                    <p style="text-align:center;">
							            <b style="font-size:large;color:yellow">
								            Rp <%=FormatNumber(neto, 0)%>,-
							            </b>
						            </p>
                                    <p style="text-align:center;">
							            <b>
								            <label style="color:white;font-size:large;">TOTAL PV : </label>
								            <label style="color:white;font-size:large;"><%=FormatNumber(totpv, 2)%></label>
							            </b>
						            </p>
                                </div>
                            </div>
                            <p><span style="text-decoration: underline; font-weight: bold">PERJANJIAN DAN PERSETUJUAN SEBAGAI MOBILE STOCKIEST PT. HEALTH WEALTH INTERNATIONAL</span></p>
                            <textarea rows="8" readonly class="form-control n-resize" name="setujuform">SYARAT DAN KETENTUAN MOBILE STOCKIEST  (MS 400)
		
a. Pemilik Mobile Stockiest (MS 400) adalah Distributor HWI.
b. Tidak terlibat langsung maupun tidak langsung dengan bisnis MLM lain.
c. Bergabung sebagai Mobile Stockiest (MS 400) dengan cara membeli paket aktivasi Mobile Stockiest (MS400)
d. Mobile Stockiest (MS400) setiap bulannya hanya dapat menyimpan 750 PV. Kelebihan PV diatas 
750 PV ini akan secara otomatis dialokasikan sebagai auto maintenance 200PV/bulan untuk Mobile 
Stockiest (MS) yang bersangkutan
e. Apabila dalam jangka waktu 3 (tiga) bulan berturut-turut tidak pernah repeat order 
minimal dalam 1 (satu invoice) pada satu bulan (bukan akumulasi) sebesar minimal Rp. 2.000.000,-
(dua juta rupiah) setelah diskon MS, maka Mobile Stockiest yang bersangkutan tidak dapat
memeperoleh potongan sebagai MS pada repeat order berikutnya. Kegiatan sebagai Mobile Stockist tetap dapat dilakukan sebagaimana biasanya, namun tidak akan mendapatkan potongan sebagai Mobile Stockist pada saat melakukan repeat order pembelian produk ke D.C
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
                                    <input type="checkbox" required name="setuju" value="AGREE">Saya Menyatakan persetujuan dan tunduk terhadap semua yang sudah diatur didalamnya (mohon diclick)
                                </label>
                            </div>
                            <p><span style="text-decoration: underline; font-weight: bold">Check Out &amp; Data mobile stockiest Baru <%=AREA_ID%> - <%=nosesifaxmc_pdn%></span></p>
                            <div style="padding: 20px 20px 20px 20px">
                                <div class="col-md-3">
                                    <label>DC Asal</label>
                                </div>
                                <div class="col-md-9">
                                    <input class="form-control" type="text" readonly name="dc_asal" value="<%=ucase(mypos)%>">
                                </div>
		                    </div>
                            <div style="padding: 20px 20px 20px 20px">
                                <div class="col-md-3">
                                    <label>Mobile Stockies Id.</label>
                                </div>
                                <div class="col-md-3">
                                    <input class="form-control" type="text" name="kdpos" id="kdpos" onKeyDown="if(event.keyCode==13) event.keyCode=9;"  onchange="javascript:cari2(this)" value="<%=nokode_mc%>">
                                    <input type="hidden" name="tgl" value="<%=tgl%>">
                                </div>
			                    <div class="col-md-6">
                                    <input class="form-control" type="text" readonly name="namadis" id="namadis" value="<%=namadis_mc%>">
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
		                    <div style="padding: 20px 20px 20px 20px">
                                <%if mypos = dcHO Then %>
                                <div class="col-md-3">
                                    <label>Kirim Ke Zona</label>
                                </div>
                                <div class="col-md-5">
                                    <select class="form-control" name="cara" onChange="Navigate(cara)" onKeyDown="if(event.keyCode==13) event.keyCode=9;">
                                        <option value="ms4_perdana.aspx?menu_id=<%=menu_id%>&zona_id=&area=" selected="selected">--PILIH ZONA--</option>
                                        <%  pp = "zno"
                                            mlQuery = "SELECT * FROM tabdesc WHERE grp like '" & pp & "' order by ket"
                                            mlDR = mlOBJGS.DbRecordset(mlQuery, mpMODULEID, mlCOMPANYID)
                                            If mlDR.HasRows Then
                                                mlDT = New Data.DataTable
                                                mlDT.Load(mlDR)
                                                For aaaeqsK = 1 To mlDT.Rows.Count - 1
                                        %>
                                        
									            <%if zona_id = mlDT.Rows(aaaeqsK)("deskripsi") Then %>
										    <option value="ms4_perdana.aspx?menu_id=<%=menu_id%>&zona_id=<%=mlDT.Rows(aaaeqsK)("deskripsi")%>&area=<%=mlDT.Rows(aaaeqsK)("ket")%>" selected><%=mlDT.Rows(aaaeqsK)("deskripsi")%></option>
               						            <%Else%>
               							    <option value="ms4_perdana.aspx?menu_id=<%=menu_id%>&zona_id=<%=mlDT.Rows(aaaeqsK)("deskripsi")%>&area=<%=mlDT.Rows(aaaeqsK)("ket")%>"><%=mlDT.Rows(aaaeqsK)("deskripsi")%></option>
               						            <%End If%>   
                                        <%
                                                    Next
                                                End If
                                                mlDR.Close()
										%>		                                        
                                    </select>
                                </div>
			                    <div class="col-md-4">
                                    <label><span style="color: red"><em>*Pilih Zona Pengiriman untuk menentukan harga</em></span></label>
                                </div>
                                <%else%>
								<input type="hidden" name="cara">																								
								<%end if%>
		                    </div>
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
										%>	
                                    </select>
                                </div>
		                    </div>
		                    <div style="padding: 20px 20px 20px 20px">
                                <div class="col-md-3">
                                    <label>Total Belanja</label>
                                </div>
                                <div class="col-md-9">
                                    <input class="form-control" type="text" name="total" readonly value="<%=FormatNumber(neto, 0)%>">
                                    <input type="hidden" name="jumtote" value="<%=neto%>">
									<input type="hidden" name="jumtot" value="<%=gtot%>">
                                </div>
		                    </div>
		                    <div style="padding: 20px 20px 20px 20px">
                                <div class="col-md-12">
                                    <label><u><strong>Pembayaran :</strong></u></label>
                                </div>
		                    </div>
                            <div style="padding: 20px 20px 20px 20px">
                                <div class="col-md-3">
                                    <label>Tunai</label>
                                </div>
                                <div class="col-md-3">
                                    <input class="form-control" type="text" name="jumbayarcash" onchange="quadratic2(this.form);" value="0">
                                </div>
	                            <div class="col-md-3">
                                    <label>Debit Card</label>
                                </div>
                                <div class="col-md-3">
                                    <input class="form-control" type="text" name="jumbayardb" onchange="quadratic2(this.form);" value="0">
                                </div>
                            </div>
		                    <div style="padding: 20px 20px 20px 20px">
                                <div class="col-md-3">
                                    <label>Credit Card</label>
                                </div>
                                <div class="col-md-3">
                                    <input class="form-control" type="text" name="jumbayarcc" onchange="quadratic2(this.form);" value="0">
                                </div>
			                    <div class="col-md-3">
                                    <label>Voucher</label>
                                </div>
                                <div class="col-md-3">
                                    <input class="form-control" type="text" name="jumbayarcek" onchange="quadratic2(this.form);" value="0">
                                </div>
		                    </div>
		                    <div style="padding: 20px 20px 20px 20px">
                                <div class="col-md-3">
                                    <label>Total Pembayaran</label>
                                </div>
                                <div class="col-md-9">
                                    <input class="form-control" type="text" name="jumbayar" readonly value="0">
                                </div>
		                    </div>
		                    <div style="padding: 20px 20px 20px 20px">
                                <div class="col-md-3">
                                    <label>Kembalian</label>
                                </div>
                                <div class="col-md-9">
                                    <input class="form-control" type="text" name="kembalian" readonly value="0">
                                </div>
		                    </div>
                            <div style="padding: 20px 20px 20px 20px">
                                <div class="col-md-3">
                                    <label> </label>
                                </div>
                                <div class="col-md-9">
                                    <% if totpv >= 100 then %>
									    <%
                                            mlQuery = "SELECT * FROM fx_order_mc_det where nopos like '" & mypos & "' and nosesi like '" & nosesifaxmc_pdn & "' and status like '" & sds & "' and kat like '" & kti & "'" & vbCrLf
                                            mlQuery += "And ( kode Like 'ms400u-14' or kode like 'ms100%' or kode like 'ms200%') order by id"
                                            mlDR = mlOBJGS.DbRecordset(mlQuery, mpMODULEID, mlCOMPANYID)
                                            mlDR.Read()
                                            If Not mlDR.HasRows Then %>
										        <b>Silahkan Pilih Paket MS...</b>
										    <%else%>
                                            <input class="btn btn-default" type="submit" name="btsbs0" value="Release Order &amp; Daftarkan Mobile Stockiest">
                                            <%end If
                                                mlDR.Close()
                                            %>
									<%else%>
									<b><i>ORDER PERDANA PAKET MS</i></b>
									<%end if%>
                                    <p><br/><span style="background-color: yellow; color: red; font-weight: bold">PASTIKAN ANDA SUDAH MENGISI DATA DENGAN BENAR ! </span><br/>Klik Sekali Saja dan tunggu hingga keluar invoice</p>
                                </div>
                            </div>
                        </div>
                    </div>
                    <%end if%>  
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

