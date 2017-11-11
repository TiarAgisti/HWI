<%@ Page Title="" Language="VB" MasterPageFile="~/pagesetting/MsPageMS.master" AutoEventWireup="false" CodeFile="sale_prd_dist.aspx.vb" Inherits="MobileStockiest_sale_prd_dist" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mpCONTENT" Runat="Server">
    <section class="content-header">
        <div style="background-color: grey"><h3 align="center"><font color="white" face="Arial">PENJUALAN PRODUK</font></h3></div>
	
	<div class="col-md-5">
    <div style="border-style:solid">
        <div style="padding: 10px 10px 10px 10px; background-color: ">
            <div style="background-color: orange"><h4 align="center"><font color="white" face="Arial">(#1) CATATAN</font></h4></div>
            <ol>
                <li>Closing Date untuk bulan ini adalah pada tanggal, jam :
				<br><font color="#FF0000"> s.d </font>
                <br>Semua transaksi yang dilakukan diantara closing period diatas, akan ditolak oleh sistem. Apabila anda membutuhkan untuk membukukan transaksi tersebut untuk keperluan top up bulanan, maka silahkan menghubungi kantor pusat.</li>
                <li>Penjualan produk hanya digunakan untuk penjualan produk tidak dicampur dengan penjualan paket pendaftaran.</li>
                <li>1 (satu) nomor invoice pembelanjaan berlaku untuk 1 (satu) calon distributor. Maksimal item belanja per 1 (satu) nomor invoice sebanyak 7 item.</li>
                <li>Tanggal transaksi tidak dapat diubah dan menurut jam server (WIB).</li>
				<li>Semua transaksi yang sudah dibukukan tidak dapat dibatalkan</font>. Untuk itu mohon periksa dan pastikan transaksi yang anda lakukan sudah benar ! sebelum mmprosesnya ke check out.</li>
            </ol>
        </div>
    </div>
    
    <div style="padding-top: 10px">
        <div class="alert alert-warning text-center" role="alert"><span class="text-uppercase"><span style="text-decoration: underline; font-weight: bold">ERROR MESSAGE</span></span>
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
                    <label>[<a href="">Tampilkan Kode </a>]</label>
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
                    <label> </label>
                </div>
                <div class="col-md-8">
                    <button class="btn btn-default" type="button">Add to Basket</button>
                    <p></br><span style="color: red; font-weight: bold">invoice maksimal berisi 
														7 item barang atau 
														penjualan ke periode 
														bulan berjalan dibekukan 
														sementara pada masa 
														topup</span> </p>
                </div>
            </div>
    </div>
	</div>
	
	<div class="col-md-7" style="padding: 10px 10px 10px 10px">
		<div style="background-color:#0099FF"><h4 align="center" class="style1"><font face="Arial">(#2) KERANJANG BELANJAAN </font></h4>
		</div>
		<p>Dibawah ini adalah daftar belanjaan saat ini. Anda dapat menghapus / membatalkan item belanjaan dibawah ini. Pembatalan item belanjaan hanya dapat dilakukan sebelum sesi belanja ini ditutup, sesi belanja ini ditutup dengan menekan tombol check out.</p>
		<div class="table-responsive">
			<table class="table table-condensed table-bordered">
				<thead>
					<tr style="background:#FF6699">
						<td width="6%"><strong>
					    <div align="center">Kode</div></td>
						<td width="29%"><strong>
					    <div align="center">Nama Produk</div></td>
						<td width="10%"><strong>
					    <div align="center">PV</div></td>
						<td width="9%"><strong>
					    <div align="center">BV</div></td>
						<td width="8%"><strong>
					    <div align="center">Qty.</div></td>
						<td width="13%"><strong>
					    <div align="center">Harga</div></td>
						<td width="20%"><strong>
					    <div align="center">Sub Total</div></td>
						<td width="5%"><strong>
					    <div align="center">Aksi</div></td>
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
						<td><a href="">DEL<a></td>
					</tr>
					<tr>
						<td class="text-right" colspan="6"><strong>GRAND TOTAL</td>
						<td>&nbsp;</td>
						<td>&nbsp;</td>
					</tr>
				</tbody>
			</table>
		</div>
		<p><center><span style="background-color: yellow; color: red; font-weight: bold">BATALKAN SESI BELANJA INI & BIKIN SESI BARU</span></center></p>
		
        <div style="background-color: green"><h4 align="center"><font color="white" face="Arial">(#3) CHECK OUT </font></h4></div>
		</p>Apabila anda sudah selesai berbelanja dan hendak melakukan pembayaran, maka lengkapilah kotak isian dibawah ini. Mohon pastikan bahwa setelah anda melakukan check out, <b><font color="#FF0000">maka transaksi tidak dapat dibatalkan</font></b> dengan alasan apapun, karena saat anda melakukan check out, <font color="#FF0000"><u>maka posting update PV kepada seluruh upline distributor</u></font> yang berbelanja dilakukan secara realtime setelah anda menekan tombol check out dibawah ini.</p>
        <p>
		<div style="background-color: black; color: white"><center><strong><font face="Arial">
			JUMLAH TOTAL PEMBELANJAAN </br>
			<span style="color: yellow">Rp ,-</span></br>
			TOTAL PV : - TOTAL BV :
		</font></strong></center></div>
		</p>
		<form method="post" action="">
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
                    <label>[<a href="">Search</a>]</label>
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
                Normal Posting (Productivity berlaku)</div>
				 <div class="col-md-3">
                    
                </div>
				<div class="col-md-9">
                    <label>
                    <input name="radiobutton" type="radio" value="radiobutton">
                  </label>
                Normal Posting (Productivity berlaku)</div>
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
                    <label> </label>
                </div>
                <div class="col-md-9">
                    <button class="btn btn-default" type="button">Checkout & Close Session</button>
                    <p></br><span style="background-color: yellow; color: red; font-weight: bold">PASTIKAN ANDA SUDAH MENGISI DATA DENGAN BENAR ! </span></br>
                    <span class="style2">Klik Sekali Saja dan tunggu hingga keluar invoice</span></p>
                </div>
            </div>
        </form>
    </div>
    </section>
</asp:Content>

