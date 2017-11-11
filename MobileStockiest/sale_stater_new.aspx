<%@ Page Title="" Language="VB" MasterPageFile="~/pagesetting/MsPageMS.master" AutoEventWireup="false" CodeFile="sale_stater_new.aspx.vb" Inherits="MobileStockiest_sale_stater_new" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mpCONTENT" Runat="Server">
    <section class="content-header">
        <div style="background-color: gray"><h3 align="center"><font color="fffff" face="Arial"><strong>NEW PENDAFTARAN DISTRIBUTOR BARU</strong></font></h3></div>
    <div style="padding: 10px 30px 0px 30px">
        <div class="col-md-8">
	<div style="padding: 10px 30px 10px 30px">
	<div class="alert alert-warning text-center" role="alert"><span><span style="text-decoration: underline;"><h4 align="center"><font color="black" face="Arial"><b>ERROR MESSAGE</b></font></h4></span></span>
    </div>
	</div>
    <div style="padding: 20px 20px 20px 20px">
        <div class="col-md-3">
            <label>Tanggal Transaksi</label>
        </div>
        <div class="col-md-9">
            <input type="text" class="form-control">
        </div>
    </div>
    <div style="padding: 20px 20px 20px 20px">
        <div class="col-md-3">
            <label>Nama Calon Distributor</label>
        </div>
      <div class="col-md-6">
            <input type="text" class="form-control">
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
            <input type="text" class="form-control">
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
            <input type="text" class="form-control">
        </div>
		<div class="col-md-6">
            <input type="text" class="form-control">
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
                    <input type="text" class="form-control">
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
                    <input type="text" class="form-control">
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
                    <select class="form-control">
                        
                            <option value="" selected="">Kiri</option>
                            <option value="">Kanan</option>
                        </optgroup>
                    </select>
                </div>
            </div>
		<div style="padding: 20px 20px 20px 20px">	
                <div class="col-md-3">
                    <label>Paket Pendaftaran</label>
                </div>
                <div class="col-md-9">
                    <select class="form-control">
                        <optgroup label="This is a group">
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
                    <label>Voucher</label>
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
            <div></div>
            <div style="padding: 20px 20px 20px 20px">
                <div class="col-md-3">
                    <label> </label>
                </div>
                <div class="col-md-9">
                    <button class="btn btn-default" type="button">Check Out</button>
                </div>
            </div>
    </div>
	
        <div class="col-md-4">
			<div style="padding: 10px 30px 10px 0px">
                <div class="col-md-12">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h4 class="text-center" align="center"><font color="black" face="Arial"><strong>PERHATIAN</strong></font></h3></div>
                        <div class="panel-body">
						<ol>
                            <li>Closing Date untuk bulan ini adalah pada tanggal, jam :<br>
                            <span style="color: red"><b>s.d</b><br></span>
                            Semua transaksi yang dilakukan diantara closing period diatas, akan ditolak oleh sistem. Apabila anda membutuhkan untuk membukukan transaksi tersebut untuk keperluan top up bulanan, maka silahkan menghubungi kantor pusat atau DC induk anda.
                            <br></li>
                            <li>Semua transaksi yang sudah dibukukan tidak dapat dibatalkan. Untuk itu mohon periksa dan pastikan transaksi yang anda lakukan sudah benar ! sebelum mmprosesnya ke check out. Untuk itu pastikan anda sudah menerima formulir pendaftaran yang diisi lengkap dan sudah menerima pembayaran sesuai tipe paket pendaftaran yang dipilih sebelum anda melakukan checkout.
                            <br></li>
                            <li>Setelah anda melakukan checkout, maka proses selanjutnya adalah memasukan data calon distributor kedalam database jaringan HWI. Apabila karena suatu sebab anda terpaksa menunda pemasukan data calon distributor tersebut,
                                maka anda tidak akan dapat memasukan data dengan nomor seri pendaftaran tersebut. Mohon hubungi kantor pusat untuk merelease lock nomor seri pendaftaran anda tersebut.</label>
                            <br></li>
                            <li>Paket pendaftaran yang memiliki jumlah stok minimal 1 yang akan ditampilkan didalam pulldown paket pendaftaran anda.
                            <br></li>
                            <li>1 (nomor) invoice pembelanjaan berlaku untuk 1 (satu) calon distributor. Tanggal transaksi tidak dapat diubah dan menurut jam server (WIB).
                            <br></li>
                            <li><span style="color: red"><b>PASTIKAN</b></span> bahwa nomor id distributor yang menjadi sponsornya (direct sponsor) maupun upline penempatan sudah terdaftar (sudah menjadi distributor HWI) dengan tanda munculnya nama di kotak direct sponsor dan upline penempatan.
                                Kami tidak menerima revisi penggantian nomor distributor yang menjadi direct sponsornya dan upline penempatanya dengan alasan apapun. Mohon pastikan dan konfirmasi kepada distributor baru tersebut sebelum anda menekan tombol
                                checkout.
                        </ol>
				</div>
            </div>
        </div>
    </div>
	</div>
</div>
    </section>
</asp:Content>

