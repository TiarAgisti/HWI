<%@ Page Title="" Language="VB" MasterPageFile="~/pagesetting/MsPageMS.master" AutoEventWireup="false" CodeFile="sale_reentry.aspx.vb" Inherits="MobileStockiest_sale_reentry" %>

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
           xmlhttp.open('get', 'getdata_ft.asp?kode='+kode, true);
           xmlhttp.onreadystatechange = function() {
               if ((xmlhttp.readyState == 4) && (xmlhttp.status == 200))
               {
                    var r = xmlhttp.responseXML.getElementsByTagName('data');                         
                    document.getElementById("harga").value = r[1].firstChild.data; 
                    document.getElementById("pv").value = r[2].firstChild.data; 
                    document.getElementById("bv").value = r[3].firstChild.data;                             
               }
               return false;
           }
           xmlhttp.send(null);
        }

        function cari2(teks)
        {
           var kode = teks.value;
           if (!kode) return;
           xmlhttp.open('get', 'getdatadirek.asp?kode='+kode, true);
           xmlhttp.onreadystatechange = function() {
               if ((xmlhttp.readyState == 4) && (xmlhttp.status == 200))
               {
                    var r = xmlhttp.responseXML.getElementsByTagName('data');                         
                    document.getElementById("namadirek").value = r[1].firstChild.data;  
                    document.getElementById("telpdirek").value = r[2].firstChild.data;              
               }
               return false;
           }
           xmlhttp.send(null);
        }
        function cari3(teks)
        {
           var kode = teks.value;
           if (!kode) return;
           xmlhttp.open('get', 'getdataupline.asp?kode='+kode, true);
           xmlhttp.onreadystatechange = function() {
               if ((xmlhttp.readyState == 4) && (xmlhttp.status == 200))
               {
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
        function quadratic1(form1)
        {
            var tunai = eval(form1.jumbayarcash.value);
            var cc = eval(form1.jumbayarcc.value);
            var db = eval(form1.jumbayardb.value);
            var cek = eval(form1.jumbayarcek.value);
            var jto = eval(form1.harga.value);
            {
                form1.jumbayar.value = tunai+cc+db+cek;
                form1.kembalian.value = (tunai+cc+db+cek)-jto;
            }
        }
    </script>

   <script type='text/javascript'>

    <!-- This script and many more are available free online at -->
        var submitcount=0;

        function reset() {
            document.theform1.direk.value="";
            document.theform1.namadirek.value="";
        }

        function checkFields() {                       // field validation -
            if ( (document.theform1.direk.value=="")  ||   // checks if fields are blank.
                 (document.theform1.namadirek.value=="") ||   // More validation scripts at
                 (document.theform1.namadirek.value=="NOT FOUND") ||   // More validation scripts at   
                 (document.theform1.paket.value=="") ||   // More validation scripts at     
                 (document.theform1.paket.value=="--Silahkan Pilih--") ||   // More validation scripts at            
                 (document.theform1.harga.value=="") ||   // More validation scripts at       
                 (document.theform1.harga.value==0) ||   // More validation scripts at   
                 (document.theform1.jumbayar.value=="") ||   // More validation scripts at 
                 (document.theform1.kembalian.value=="") ||   // More validation scripts at           
                 (document.theform1.jumbayar.value=="NaN") ||   // More validation scripts at   
                 (document.theform1.kembalian.value=="NaN") ||   // More validation scripts at             
                 (document.theform1.jumbayar.value==0) ||   // More validation scripts at           
                 (document.theform1.kembalian.value<0) ) // forms.javascriptsource.com
            {
                alert("Mohon lengkapi form fast track terlebih dulu");
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
                    alert("Form sedang diproses, silahkan tunggu hingga proses posting PV selesai dilakukan dengan munculnya invoice. Silahkan tutup pesan ini untuk melanjutkan proses posting PV.");
                    return false;
                }
           }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mpCONTENT" Runat="Server">
    <section class="content-header" style="background-color:white;">
        <div style="background-color: gray">
            <h3 style="text-align:center;color:white;font-family:Arial;"><strong>PEMBELIAN PAKET RE-ENTRY FAST TRACK</strong></h3>
        </div>
        <div style="padding: 10px 25px 10px 25px">	
            <div class="col-md-12">
			    <div style="padding: 10px 30px 10px 30px">
                    <div class="col-md-12">
                        <div class="panel panel-default">
                            <div class="panel-heading">
                                <h4 class="text-center" style="text-align:center;color:black;font-family:Arial;"><strong>PERHATIAN</strong></h4>
                            </div>
                            <div class="panel-body">
						        <ol>
                                    <li>Closing Date untuk bulan ini adalah pada tanggal, jam :<br>
                                    <span style="color: red"><b>s.d</b><br></span>
                                    Semua transaksi yang dilakukan diantara closing period diatas, akan ditolak oleh sistem. Apabila anda membutuhkan untuk membukukan transaksi tersebut untuk keperluan top up bulanan, maka silahkan menghubungi kantor pusat.
                                    <br></li>
                                    <li>Semua transaksi yang sudah dibukukan tidak dapat dibatalkan. Untuk itu mohon periksa dan pastikan transaksi yang anda lakukan sudah benar ! sebelum mmprosesnya ke check out. Untuk itu pastikan anda sudah menerima formulir pembelian paket re-entry fast track dari distributor dengan benar dan sudah melakukan konfirmasi pembelian tersebut.
                                    <br></li>
                                    <li>1 (satu) nomor invoice pembelanjaan paket re-entry fast track berlaku untuk 1 (satu) distributor. <p style="color:#FF0000;">Hanya distributor bertipe <b>Regular</b> (Distributor yang bergabung dengan segala jenis paket Regular) yang dapat membeli paket re-entry fast track.
                                    Distributor yang bergabung dengan paket Premium, Platinum (sudah diupgrade ke platinum atau memperoleh auto upgrade by sistem) atau Titanium tidak perlu melakukan re-entry untuk dapat mengikuti Fast Track Plan.
                                    <br></p>
                                    Tanggal transaksi tidak dapat diubah dan menurut jam server (WIB).
                                </ol>
				            </div>
                        </div>  
                    </div>
                </div>
	        </div>
        </div>
	    <div style="padding: 10px 35px 10px 35px">
            <div class="col-md-12">
	            <div style="padding: 10px 35px 5px 35px">
	                <div class="alert alert-warning text-center" role="alert">
                        <h4 style="text-align:center;color:black;font-family:Arial;">
                            <span><span style="text-decoration: underline;"><b>ERROR MESSAGE</b></span></span>
                        </h4>               
                    </div>
	            </div>
                <%--<form name="form1"></form>--%>
                <div style="padding: 0px 20px 20px 20px">
                    <div class="col-md-3">
                        <label>Tanggal Transaksi</label>
                    </div>
                    <div class="col-md-9">
                        <input type="text" class="form-control">
                    </div>
                </div>
                <div style="padding: 20px 20px 20px 20px">
                    <div class="col-md-3">
                        <label>Nomor Id. Distributor</label>
                    </div>
                    <div class="col-md-3">
                        <input type="text" class="form-control">
                    </div>
		            <div class="col-md-6">
                        <input type="text" class="form-control">
                    </div>
                </div>
                <div style="padding: 20px 20px 75px 20px">
                    <div class="col-md-3">
                        <label>Keterangan</label>
                    </div>
                    <div class="col-md-9">
			            <textarea rows="4"  class="form-control"></textarea>
                    </div>
	            </div>
		        <div style="padding: 20px 20px 20px 20px">	
                    <div class="col-md-3">
                        <label>Paket Fast Track</label>
                    </div>
                    <div class="col-md-9">
                        <select class="form-control">
                            <optgroup label="">
                                <option value="12" selected="">--Silahkan Pilih--</option>
                                <option value="13">Item 1</option>
                                <option value="14">Item 2</option>
                            </optgroup>
                        </select>
                    </div>
                </div>
                <div style="padding: 20px 20px 20px 20px">
                    <div class="col-md-3">
                        <label>Harga</label>
                    </div>
                    <div class="col-md-9">
                        <input type="text" class="form-control">
                    </div>
                </div>
			    <div style="padding: 20px 20px 20px 20px">
                    <div class="col-md-3">
                        <label>PV</label>
                    </div>
                    <div class="col-md-3">
                        <input type="text" class="form-control">
                    </div>
                    <div class="col-md-2">
                        <label>BV</label>
                    </div>
                    <div class="col-md-4">
                        <input type="text" class="form-control">
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
                        <input type="text" class="form-control">
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
                        <input type="text" class="form-control">
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
                        <input type="text" class="form-control">
                    </div>
                </div>
                <div style="padding: 20px 20px 20px 20px">
                    <div class="col-md-3">
                        <label> </label>
                    </div>
                    <div class="col-md-3">
                        <label>BG/Cheque</label>
                    </div>
                    <div class="col-md-6">
                        <input type="text" class="form-control">
                    </div>
                </div>
                <div style="padding: 20px 20px 20px 20px">
                    <div class="col-md-3">
                        <label>Jumlah Pembayaran</label>
                    </div>
                    <div class="col-md-9">
                        <input type="text" class="form-control">
                    </div>
                </div>
                <div style="padding: 20px 20px 20px 20px">
                    <div class="col-md-3">
                        <label>Jumlah Kembalian</label>
                    </div>
                    <div class="col-md-9">
                        <input type="text" class="form-control">
                    </div>
                </div>
                <div style="padding: 20px 20px 20px 20px">
                    <div class="col-md-3">
                        <label> </label>
                    </div>
                    <div class="col-md-9">
                        <button class="btn btn-default" type="button">Check Out</button>
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
			    <div style="padding: 20px 20px 20px 20px">
                    <div class="col-md-3">
                        <label></label>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>

