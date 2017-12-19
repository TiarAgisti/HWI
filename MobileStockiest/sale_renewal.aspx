<%@ Page Title="" Language="VB" MasterPageFile="~/pagesetting/MsPageMS.master" AutoEventWireup="false" CodeFile="sale_renewal.aspx.vb" Inherits="MobileStockiest_sale_renewal" %>

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
            xmlhttp.open('get', 'getdata_ren.asp?kode=' + kode, true);
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
            xmlhttp.open('get', 'getdataup.asp?kode=' + kode, true);
            xmlhttp.onreadystatechange = function () {
                if ((xmlhttp.readyState == 4) && (xmlhttp.status == 200)) {
                    var r = xmlhttp.responseXML.getElementsByTagName('data');
                    document.getElementById("namadirek").value = r[1].firstChild.data;
                    document.getElementById("upme").value = r[2].firstChild.data;
                    document.getElementById("tipene").value = r[3].firstChild.data;
                }
                return false;
            }
            xmlhttp.send(null);
        }

    </script>


    <script type='text/javascript'>
<!--
    function formCheck(form) {
        if (form.direk.value == "") {
            alert("Silahkan tulis nomor id distributor yang akan direnewal");
            return false;
        }
        if (form.namadirek.value == "NOT FOUND") {
            alert("Silahkan tulis nomor id distributor yang akan direnewal");
            return false;
        }
        if (form.namadirek.value == "") {
            alert("Silahkan tulis nomor id distributor yang akan direnewal");
            return false;
        }
        if (form.paket.value == "") {
            alert("Silahkan pilih paket renewal anda");
            return false;
        }
        if (form.paket.value == "--Silahkan Pilih--") {
            alert("Silahkan pilih paket renewal anda");
            return false;
        }
        if (form.harga.value == 0) {
            alert("Mohon pilih paket renewal anda");
            return false;
        }
        if (form.jumbayar.value == 0) {
            alert("Mohon isikan jumlah pembayaran");
            return false;
        }
        if (confirm("Cek sekali lagi, apakah data yang Anda isi SUDAH BENAR semuanya ? Transaksi yang sudah dibukukan tidak dapat dibatalkan, mohon periksa sekali lagi sebelum check out : \n\nNomor Id. Distributor : " + form.direk.value + ".\nNama Distributor : " + form.namadirek.value + "\nPaket Renewal : " + form.paket.value + "\nHarga : " + form.harga.value + "\nPembayaran : " + form.jumbayar.value + "\n")) {
            return true;
        }
        else {
            return false;
        }
    }
    // -->
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


    <script type='text/javascript'>

    var submitcount = 0;

    function reset() {
        document.theform1.direk.value = "";
        document.theform1.namadirek.value = "";
    }

    function checkFields() {                       // field validation -
        if ((document.theform1.direk.value == "") ||   // checks if fields are blank.
             (document.theform1.namadirek.value == "") ||   // More validation scripts at
             (document.theform1.namadirek.value == "NOT FOUND") ||   // More validation scripts at   
             (document.theform1.paket.value == "") ||   // More validation scripts at     
             (document.theform1.paket.value == "--Silahkan Pilih--") ||   // More validation scripts at            
             (document.theform1.harga.value == "") ||   // More validation scripts at       
             (document.theform1.harga.value == 0) ||   // More validation scripts at   
             (document.theform1.jumbayar.value == "") ||   // More validation scripts at 
             (document.theform1.kembalian.value == "") ||   // More validation scripts at           
             (document.theform1.jumbayar.value == "NaN") ||   // More validation scripts at   
             (document.theform1.kembalian.value == "NaN") ||   // More validation scripts at             
             (document.theform1.jumbayar.value == 0) ||   // More validation scripts at           
             (document.theform1.kembalian.value < 0)) // forms.javascriptsource.com
        {
            alert("Mohon lengkapi form renewal terlebih dulu");
            return false;
        }
        else {
            if (submitcount == 0) {
                submitcount++;
                return true;
            }
            else {
                alert("Form sedang diproses, silahkan tunggu hingga proses posting renewal selesai dilakukan dengan munculnya invoice. Silahkan tutup pesan ini untuk melanjutkan proses renewal.");
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
                <h4 style="text-align: center; color: black; font-family: Arial;"><strong>PEMBELIAN PAKET RENEWAL</strong></h4>
            </div>
            <div class="panel-body">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h4 class="text-center" style="text-align:center;color:black;font-family:Arial;"><strong>PERHATIAN</strong></h4>
                    </div>
                    <div class="panel-body">
                        <ol>
                            <li>Paket renewal hanya dapat digunakan oleh distributor yang memasuki masa tenggang, yaitu masa dimana seseorang distributor sudah expired hingga 30 hari kedepan.<br>
                                Sebagai contoh :<br>
                                Si A expired pada tanggal 01 Oktober 2010, maka si A memiliki masa tenggang, yaitu masa dimana si A berkesempatan untuk melakukan renewal hingga maksimal 01 November 2010</li>
                            <li>Apabila si A melewatkan masa tenggang dan tidak melakukan renewal, maka si A akan di suspend permanen secara otomatis oleh sistem.</li>

                            <li>Paket renewal ini memberikan bonus kepada upline 6 level.</li>
                            <li>Paket renewal tidak ber PV.&nbsp;</li>
                        </ol>
                    </div>
                </div>

              <%if mesej <> "" Then %>
                <div class="alert alert-warning text-center" role="alert">
                    <h4 style="text-align:center;color:black;font-family:Arial;">
                        <span>
                            <span style="text-decoration: underline;"><b>ERROR MESSAGE</b></span><br />
                            <%=mesej%>
                        </span>
                    </h4>               
                </div>
            <%end If%>
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h4 class="text-center" style="text-align:center;color:black;font-family:Arial;"><strong></strong></h4>
                    </div>
                    <div class="panel-body">
                        <form name="theform1" method="post" action="sale_renewal_save.asp" onSubmit="return checkFields()">
                            <input type="hidden" name="menu_id" value="<%=Session("menu_id")%>">
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
                                    <label>Nomor Id. Distributor</label>
                                </div>
                                <div class="col-md-3">
                                    <input type="text" class="form-control" name="direk" id="direk" onChange="javascript:cari2(this);" onKeyDown="if(event.keyCode==13) event.keyCode=9;" maxlength="8">
                                </div>
		                        <div class="col-md-6">
                                    <input type="text" class="form-control" readonly name="namadirek" id="namadirek" onKeyDown="if(event.keyCode==13) event.keyCode=9;">
                                    <input type="hidden" name="upme" id="upme">
                                    <input type="hidden" name="tipene" id="tipene">
                                </div>
                            </div>
                            <div style="padding: 20px 20px 75px 20px">
                                <div class="col-md-3">
                                    <label>Keterangan</label>
                                </div>
                                <div class="col-md-9">
			                        <textarea rows="4"  class="form-control"  name="keterangan" readonly></textarea>
                                </div>
	                        </div>
		                    <div style="padding: 20px 20px 20px 20px">	
                                <div class="col-md-3">
                                    <label>Paket Upgrade</label>
                                </div>
                                <div class="col-md-9">
                                    <select class="form-control"  name="paket" id="paket" onChange="javascript:cari(this)" onKeyDown="if(event.keyCode==13) event.keyCode=9;">
                                        <optgroup label="">
                                            <option value="12" selected="">--Silahkan Pilih--</option>
                                            <%
                pp = "REN"
                If mypos <> dcpusate Then
                    If LCase(loguser) = "kris" Then
                        mlSQL = "SELECT kode,nama FROM " & namatabel & " WHERE nopos like '" & mypos & "' and grp like '" & pp & "' and jumlah >= '" & minimal & "'"
                    Else
                        mlSQL = "SELECT kode,nama FROM " & namatabel & " WHERE nopos like '" & mypos & "' and grp like '" & pp & "' and jumlah >= '" & minimal & "'"
                    End If
                Else
                    If LCase(loguser) = "kris" Then
                        mlSQL = "SELECT kode,nama FROM " & namatabel & " WHERE nopos like '" & mypos & "' and grp like '" & pp & "'"
                    Else
                        mlSQL = "SELECT kode,nama FROM " & namatabel & " WHERE nopos like '" & mypos & "' and grp like '" & pp & "'"
                    End If
                End If

                mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
                If mlREADER.HasRows = True Then
                    mlDATATABLE = New Data.DataTable()
                    mlDATATABLE.Load(mlREADER)
                    For aaaeqSSS = 1 To mlDATATABLE.Rows.Count - 1
                                             %>
                                                      <option value="<%=mlDATATABLE.Rows(aaaeqSSS)("kode")%>"><%=mlDATATABLE.Rows(aaaeqSSS)("nama")%></Option>
                                            <%
                    Next
                End If
                mlREADER.Close()
                                            %>
                                        </optgroup>
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
                            </div>
			                <div style="padding: 20px 20px 20px 20px">
                                <div class="col-md-3">
                                    <label>Tunai</label>
                                </div>
                                <div class="col-md-6">
                                    <input type="text" class="form-control" name="jumbayarcash" onchange="quadratic1(this.form);" value="0" maxlength="7">
                                </div>
                            </div>
                            <div style="padding: 20px 20px 20px 20px">
                                <div class="col-md-3">
                                    <label>Debit Card</label>
                                </div>
                                <div class="col-md-6">
                                    <input type="text" class="form-control" name="jumbayardb" onchange="quadratic1(this.form);" value="0" maxlength="7">
                                </div>
                            </div>
                            <div style="padding: 20px 20px 20px 20px">
                                <div class="col-md-3">
                                    <label>Credit Card</label>
                                </div>
                                <div class="col-md-6">
                                    <input type="text" class="form-control" name="jumbayarcc" onchange="quadratic1(this.form);" value="0" maxlength="7">
                                </div>
                            </div>
                            <div style="padding: 20px 20px 20px 20px">
                                <div class="col-md-3">
                                    <label>BG/Cheque</label>
                                </div>
                                <div class="col-md-6">
                                    <input type="text" class="form-control" name="jumbayarcek"  onchange="quadratic1(this.form);" value="0" maxlength="7" disabled>
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
                            <div style="padding: 20px 20px 20px 20px">
                                <div class="col-md-3">
                                    <label> </label>
                                </div>
                                <div class="col-md-9">
                                    <input class="btn btn-default" type="submit" name="btsub" value="Check Out">
                                </div>
                            </div>
		                    <div style="padding: 20px 20px 20px 20px">
                                <div class="col-md-3">
                                    <label></label>
                                </div>
				                <div class="col-md-9">
                                    <label style="color:#FF0000;">Klik sekali saja dan tunggu hingga keluar invoice</label>
                                </div>
                            </div>
                        </form>
                    </div>
                </div>
            </div>
        </div>
         <div style="padding: 20px 20px 20px 20px">
            <div class="col-md-3">
                <label></label>
            </div>
        </div>
    </section>
</asp:Content>

