<%@ Page Title="" Language="VB" MasterPageFile="~/pagesetting/MsPageMS.master" AutoEventWireup="false" CodeFile="mc_prd_topup.aspx.vb" Inherits="MobileStockiest_mc_prd_topup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mpCONTENT" Runat="Server">
    <section class="content-header" style="background-color:white;">
        <div style="background-color: grey">
            <h3 style="text-align:center;color:white;font-family:Arial;">
                PENJUALAN PRODUK TOP UP
            </h3>
        </div>	
        <div style="padding: 0px 20px 0px 20px">
            <div style="padding: 10px 10px 10px 10px; background-color: aqua">
                <div style="background-color: orange">
                    <h4 style="text-align:center;color:white;">
                        (#1) PERATURAN TOP UP
                    </h4>
                </div>
                <ol>
                    <li>Top up hanya dapat dilakukan oleh distributor yang sudah memiliki / belanja sebesar <font color="#FF0000"><b>200 pv</b></font>. Top up bukan proses tutup point, melainkan proses atau usaha untuk meraih kualifikasi / ranking pada periode ini.</li>
                    <li>Top up tidak dikenai split point, top up tidak menghasilkan productivity bonus.</li>
                    <li>Top up dialokasikan pada jajaran downline jaringan. Apabila anda mengalokasikan top up pada jaringan anda, pastikan anda sudah benar-benar mengalokasikannya pada downline yang sesuai (tidak salah kaki / group).<</li>
                    <li>Downline yang memperoleh alokasi top up memungkinkan memperoleh bonus apabila mencapai tutup point (200 pv) dan memang berhak memperoleh bonus sesuai quadro plan (alokasi top up tidak menghasilkan productivity bonus).</li>
                    <li>Kesempatan top up dibuka mulai <label  style="color:#FF0000;">Disini Ada Koding</label><br>
					Top up ditutup mulai <label style="color:#FF0000;">Disini ada Koding</label><br>
					Sejak top up ditutup, maka kantor pusat sudah melakukan perhitungan bonus bulanan.Keterlambatan top up akan dimasukan pada pv bulan terdekat.</li>
                </ol>
            </div>
        </div>
        <div style="padding: 10px 20px 0px 20px">
            <div class="alert alert-warning text-center" role="alert"><span class="text-uppercase"><span style="text-decoration: underline; font-weight: bold">ERROR MESSAGE</span></span>
            </div>
        </div>
        <div style="padding: 10px 20px 10px 20px">
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
                    <label>[<a href="https://www.w3schools.com">Tampilkan</a>]</label>
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
                    <p><br><span style="color: red; font-weight: bold">Kesempatan Top Up Belum dibuka 1 invoice maksimal berisi 7 item barang</span></p>
                </div>
            </div>
        </div>
		<div style="padding: 0px 20px 0px 20px">
	        <div style="background-color: ">
                <h4 style="text-align:center;font-family:Arial;">(#2) KERANJANG BELANJAAN</h4>
	        </div>
		    <p>
                Dibawah ini adalah daftar belanjaan top up saat ini. Anda dapat menghapus / membatalkan item belanjaan top up dibawah ini. 
                Pembatalan item belanjaan top up hanya dapat dilakukan sebelum sesi belanja ini ditutup, sesi belanja ini ditutup dengan menekan tombol check out.
		    </p>
		        <div class="table-responsive">
			        <table class="table table-condensed table-bordered">
				        <thead>
					        <tr>
						        <td style="width:6%"><strong>Kode</strong></td>
						        <td style="width:29%;"><strong>Nama Produk</strong></td>
						        <td style="width:10%;"><strong>PV</strong></td>
						        <td style="width:9%;"><strong>BV</strong></td>
						        <td style="width:8%;"><strong>Qty.</strong></td>
						        <td style="width:13%;"><strong>Harga</strong></td>
						        <td style="width:20%;"><strong>Sub Total</strong></td>
						        <td style="width:5%;"><strong>Aksi</strong></td>
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
						        <td><a href="https://www.w3schools.com">DEL</a></td>
					        </tr>
					        <tr>
						        <td class="text-right" colspan="6"><strong>GRAND TOTAL</strong></td>
						        <td>&nbsp;</td>
						        <td>&nbsp;</td>
					        </tr>
				        </tbody>
			        </table>
		        </div>
		    </div>
		    <p>
                <span style="background-color: yellow; color: red; font-weight: bold;text-align:center;">BATALKAN SESI BELANJA INI & BIKIN SESI BARU</span>
		    </p>
            <div style="padding: 0px 20px 0px 20px">
                <div style="background-color: green">
                <h4 style="text-align:center;color:white;font-family:Arial;">(#3) CHECK OUT</h4>
            </div>
		        <p>Apabila anda sudah selesai berbelanja dan hendak melakukan pembayaran, maka lengkapilah kotak isian dibawah ini. Mohon pastikan bahwa setelah anda melakukan check out, 
                    <b style="color:#FF0000;">maka transaksi tidak dapat dibatalkan</b> dengan alasan apapun, karena saat anda melakukan check out, 
                    <u style="color:#FF0000;">maka posting update PV kepada seluruh upline distributor</u> yang berbelanja dilakukan secara realtime setelah anda menekan tombol check out dibawah ini.
		        </p>
                <!-- <p> -->
		        <div style="background-color: black; color: white;text-align:center;">
                    <strong style="font-family:Arial">
                        JUMLAH TOTAL PEMBELANJAAN <br/>
			            <span style="color: yellow">Rp ,-</span><br/>
			            TOTAL PV : - TOTAL BV :
                    </strong>
		        </div>
		        <!-- </p> -->
                <p>
                    <span style="text-decoration: underline; font-weight: bold">Check Out</span>
                </p>
                <div style="padding: 10px 5px 20px 5px">
                    <div class="col-md-3">
                        <label>Topup Bulan</label>
                    </div>
                    <div class="col-md-6">
                        <input class="form-control" type="text">
                    </div>
				    <div class="col-md-3">
                        <label><span style="color: red"><em>*Topup Periode Bulan</em></span></label>
                    </div>
			    </div>
			    <div style="padding: 20px 5px 20px 5px">
                    <div class="col-md-3">
                        <label>Topup Tahun</label>
                    </div>
                    <div class="col-md-6">
                        <input class="form-control" type="text">
                    </div>
				    <div class="col-md-3">
                        <label><span style="color: red"><em>*Topup Periode Tahun</em></span></label>
                    </div>
			    </div>
			    <div style="padding: 20px 5px 20px 5px">
                    <div class="col-md-3">
                        <label>Distributor Topup. Id</label>
                    </div>
                    <div class="col-md-3">
                        <input class="form-control" type="text">
                    </div>
				    <div class="col-md-4">
                        <input class="form-control" type="text">
                    </div>
				    <div class="col-md-2">
                        <label>[<a href="https://www.w3schools.com">Search</a>]</label>
                    </div>
			    </div>
			    <div style="padding: 20px 5px 20px 5px">
                    <div class="col-md-3">
                        <label>Distributor Id. Alokasi</label>
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
                        <button class="btn btn-default" type="button">Checkout & Close</button>
                        <p><br/><span style="background-color: yellow; color: red; font-weight: bold">PASTIKAN ANDA SUDAH MENGISI DATA DENGAN BENAR ! </span><br/>Klik Sekali Saja dan tunggu hingga keluar invoice</p>
                    </div>
                </div>
	        </div>
    </section>
</asp:Content>

