<%@ Page Title="" Language="VB" MasterPageFile="~/pagesetting/MsPageMS.master" AutoEventWireup="false" CodeFile="home.aspx.vb" Inherits="MobileStockiest_home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mpCONTENT" runat="Server">

    <section class="content-header">
        <h1>
            <small>&nbsp;</small>
        </h1>
        <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i>Home</a></li>
            <li><a href="#">Examples</a></li>
            <li class="active">Pace page</li>
        </ol>
    </section>
    <section class="content">

        <div class="modal fade" id="infodcModal" tabindex="-1" role="dialog" aria-labelledby="memberModalLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                        <h4 class="modal-title" id="memberModalLabel">INFO PAKET MS BARU</h4>
                    </div>
                    <div class="modal-body">
                        <%Response.WriteFile("../File/DistributionCenter/info_paket_baru.html")%>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-sm btn-danger" data-dismiss="modal">
                            Close
                        </button>
                    </div>
                </div>
            </div>
        </div>


        <div class="box">
            <div class="box-header with-border">
                <h3 class="box-title">Health Wealth International :: Mobile Center Web Admin</h3>
                <div class="box-tools pull-right">
                    <button type="button" class="btn btn-box-tool" data-widget="collapse" data-toggle="tooltip" title="Collapse">
                        <i class="fa fa-minus"></i>
                    </button>
                    <button type="button" class="btn btn-box-tool" data-widget="remove" data-toggle="tooltip" title="Remove">
                        <i class="fa fa-times"></i>
                    </button>
                </div>
            </div>
            <div class="box-body">
                <%Response.WriteFile("../File/DistributionCenter/distribution_center.html")%>
            </div>
            <div class="box-footer">
                Footer
            </div>
        </div>

        <div class="box">
            <div class="box-header with-border">
                <h3 class="box-title">PENGUMUMAN CLOSING PERIODE
                </h3>
                <div class="box-tools pull-right">
                    <button type="button" class="btn btn-box-tool" data-widget="collapse" data-toggle="tooltip" title="Collapse">
                        <i class="fa fa-minus"></i>
                    </button>
                    <button type="button" class="btn btn-box-tool" data-widget="remove" data-toggle="tooltip" title="Remove">
                        <i class="fa fa-times"></i>
                    </button>
                </div>
            </div>
            <div class="box-body">
                <div id="div_closing" runat="server">
                </div>
            </div>
            <div class="box-footer">
                Management HWI
            </div>
        </div>
        <div class="box">
            <div class="box-header with-border">
                <h3 class="box-title">PENGUMUMAN MAINTENANCE SERVER
                </h3>
                <div class="box-tools pull-right">
                    <button type="button" class="btn btn-box-tool" data-widget="collapse" data-toggle="tooltip" title="Collapse">
                        <i class="fa fa-minus"></i>
                    </button>
                    <button type="button" class="btn btn-box-tool" data-widget="remove" data-toggle="tooltip" title="Remove">
                        <i class="fa fa-times"></i>
                    </button>
                </div>
            </div>
            <div class="box-body">
                Akan dilakukan 
			                Maintenance Server Full pada 
			                tanggal 7 dan 8 februari 2016 
                            <br />
                untuk pembaharuan Software dan Hardware Server.
			                <br />
                <br />
                Salam sehat luar biasa !
            </div>
            <div class="box-footer">
                Management HWI
            </div>
        </div>
        <div class="box">
            <div class="box-header with-border">
                <h3 class="box-title">KETENTUAN STOCK PENDING MOBILE STOCKIEST (MS)
                </h3>
                <div class="box-tools pull-right">
                    <button type="button" class="btn btn-box-tool" data-widget="collapse" data-toggle="tooltip" title="Collapse">
                        <i class="fa fa-minus"></i>
                    </button>
                    <button type="button" class="btn btn-box-tool" data-widget="remove" data-toggle="tooltip" title="Remove">
                        <i class="fa fa-times"></i>
                    </button>
                </div>
            </div>
            <div class="box-body">
                Setiap Mobile Stockiest (MS) hanya diperbolehkan menyimpan point pending maksimal 750 PV 
		                    (diluar pv paket pendaftaran distributor baru). 
                            <br />
                <br />
                Pada setiap bulan setelah topup berakhir, pukul 00:00:01 WIB sistem akan melakukan cek stock 
		                    MS (hanya produk / invoice yang diorder pada pv bulan sebelumnya). 
                            <br />
                <br />
                <u>Contoh :</u>
                <br />
                Tanggal proses automaintenance 
		                    setelah topup berakhir, misalnya 
		                    04-11-2013, maka yang dihitung 
		                    maksimal 750PV adalah stock yang 
		                    diorder pada bulan 10 kebawah, 
		                    stock yang diorder pada bulan 11 
		                    tidak dihitung.
                            <br />
                <br />
                Semua stock MS yang diatas 750 
		                    PV akan dikenai automaintenance.
		                    <br />
                <br />
                Maksimal 200 PV akan diposting 
		                    sebagai pv pribadi pemilik MS 
		                    (productivity berlaku) pada 
		                    bulan periode berjalan (bukan 
		                    bulan topup) dan sisanya 
		                    disimpan kedalam saldo 
		                    automaintenance yang akan 
		                    diposting maksimal per 200PV 
		                    tiap bulan hingga habis.
                            <br />
                <br />
                Dengan demikian setelah proses 
		                    automaintenance selesai 
		                    dilakukan, pemilik MS yang 
		                    dikenai automaintenance atau 
		                    memiliki saldo automaintenance 
		                    yang di posting oleh sistem 
		                    otomatis sudah langsung tutup 
							point 200PV pada awal bulan.
							<br />
                <hr />
                <font size="4" color="#FF0000">
							    <b>PEMBEKUAN SEMENTARA PENJUALAN PRODUK DISTRIBUTOR PADA MASA TOPUP</b>
							</font>
                <b>
                    <font size="4" color="#FF0000">
                                        <br/>
							            <br/>
							        </font>
                </b>
                Pada setiap bulan 
								saat masa topup berlangsung, 
								penjualan produk distributor 
								(posting pv pada periode bulan 
								berjalan) sementara di bekukan. 
								DC, MC dan MS tidak dapat 
								melakukan penjualan produk 
								distributor, namun tetap dapat 
								melakukan PENJUALAN PRODUK TOPUP 
								dan PENDAFTARAN DISTRIBUTOR 
								BARU, UPGRADE FAST TRACK dan 
								RENEWAL
                                <b>
                                    <font size="4" color="#FF0000">
                                        <br/>
								    </font>
                                    <hr />
                                    <br />
                                    <b>
                                        <font size="4" color="#FF0000">
									        STOCK PENDING DISTRIBUTION CENTER
									    </font>
                                    </b>
                                    <br />
                                    <br />
                                    Per 05 Desember 2013 
									diberlakukan ketentuan maksimal 
									point pending DC sebesar 20.000 
									PV. 
                                    <br />
                                    <br />
                                    DC <u>hanya dapat melakukan order 
									ke kantor pusat bila stock 
									pending dibawah 20.000 PV</u>
                                    (diluar paket pendaftaran 
									distributor baru)
                                    <br />
                                    <br />
                                    Jumlah PV yang diorder maksimal 
									total 30.000 PV (termasuk pv 
									pending diluar paket pendaftaran 
									distributor baru).
                                    <br />
                                    <br />
                                    Rumus maksimal order =
                                    <br />
                                    30.000 - stock pending DC (stock 
									pending DC harus dibawah 20.000 
									PV untuk dapat melakukan order 
									ke kantor pusat)<br />
                                    <br />
                                    Contoh :<br />
                                    1. DC AAA memiliki PV yang belum 
									dipointkan (diluar paket 
									pendaftaran distributor baru) 
									sebesar 13.000 PV, maka DC AAA 
									hanya dapat melakukan order ke 
									kantor pusat maksimal 17.000 PV 
									(diluar paket pendaftaran 
									distributor).<br />
                                    <br />
                                    2. DC AAA memiliki PV yang belum 
									dipointkan (diluar paket 
									pendaftaran distributor baru) 
									sebesar 19.000 PV, maka DC AAA 
									hanya dapat melakukan order ke 
									kantor pusat maksimal 11.000 PV 
									(diluar paket pendaftaran 
									distributor).<br />
                                    <br />
                                    3. DC AAA memiliki PV yang belum 
									dipointkan (diluar paket 
									pendaftaran distributor baru) 
									sebesar 23.000 PV, maka DC tidak 
									dapat melakukan order ke kantor 
									pusat karena maksimal PV pending 
									diatas 20.000 PV<br />
            </div>
            <div class="box-footer">
                Management HWI
            </div>
        </div>
        <div class="box">
            <div class="box-header with-border">
                <h3 class="box-title"></h3>
                <div class="box-tools pull-right">
                    <button type="button" class="btn btn-box-tool" data-widget="collapse" data-toggle="tooltip" title="Collapse">
                        <i class="fa fa-minus"></i>
                    </button>
                    <button type="button" class="btn btn-box-tool" data-widget="remove" data-toggle="tooltip" title="Remove">
                        <i class="fa fa-times"></i>
                    </button>
                </div>
            </div>
            <div class="box-body">
                <!--tampilan tablet ilang-->
                <div class='hidden-xs hidden-sm'>
                    <a href="home.aspx?menu_id=<%=menu_id%>&kategori=" class="btn btn-info btn-sm " role="button">Berita Terbaru</a>
                    <a href="home.aspx?menu_id=<%=menu_id%>&kategori=promosi" class="btn btn-info  btn-sm " role="button">Event Promosi</a>
                    <a href="home.aspx?menu_id=<%=menu_id%>&kategori=campaign" class="btn btn-info btn-sm " role="button">Campaign</a>
                    <a href="home.aspx?menu_id=<%=menu_id%>&kategori=jadwal" class="btn btn-info btn-sm" role="button">Marketing Tools</a>
                </div>
                <!--tampilan leptop ilang-->
                <div class=' hidden-md hidden-lg'>
                    <div class='col-xs-6'>
                        <a href="home.aspx?menu_id=<%=menu_id%>&kategori=" class="btn btn-info btn-sm btn-block" role="button">Berita Terbaru</a>
                    </div>
                    <div class='col-xs-6 '>
                        <a href="home.aspx?menu_id=<%=menu_id%>&kategori=promosi" class="btn btn-info  btn-sm btn-block" role="button">Event Promosi</a>
                    </div>
                    <br />
                    <br />
                    <div class='col-xs-6'>
                        <a href="home.aspx?menu_id=<%=menu_id%>&kategori=campaign" class="btn btn-info btn-sm btn-block" role="button">Campaign</a>

                    </div>
                    <div class='col-xs-6'>
                        <a href="home.aspx?menu_id=<%=menu_id%>&kategori=jadwal" class="btn btn-info btn-sm btn-block" role="button">Marketing Tools</a>
                    </div>
                </div>
                <div id="Div_ClosingLanjutan" runat="server">
                </div>
            </div>
            <div class="box-footer">
                Management HWI
            </div>
        </div>
    </section>




    <%--	        <div class="box">
		        <div class="box-header with-border">
			        <h3 class="box-title">Distribution ID</h3>
			        <div class="box-tools pull-right">
				        <button type="button" class="btn btn-box-tool" data-widget="collapse" data-toggle="tooltip" title="Collapse">
				        <i class="fa fa-minus"></i></button>
				        <button type="button" class="btn btn-box-tool" data-widget="remove" data-toggle="tooltip" title="Remove">
				        <i class="fa fa-times"></i></button>
			        </div>
		        </div>
		        <div id="boxbody_Distribution" runat="server" class="box-body">
		        
		        </div>
		        <div class="box-footer">
     
		        </div>
	        </div>
	        <div class="box">
		        <div class="box-header with-border">
			        <h3 class="box-title">Business Center-2</h3>
			        <div class="box-tools pull-right">
				        <button type="button" class="btn btn-box-tool" data-widget="collapse" data-toggle="tooltip" title="Collapse">
				        <i class="fa fa-minus"></i></button>
				        <button type="button" class="btn btn-box-tool" data-widget="remove" data-toggle="tooltip" title="Remove">
				        <i class="fa fa-times"></i></button>
			        </div>
		        </div>
		        <div id="boxbody_BC2" runat="server"  class="box-body">
		        
		        </div>

		        <div class="box-footer">
		 
		        </div>
	        </div>
	        <div class="box">
		        <div class="box-header with-border">
			        <h3 class="box-title">Business Center-1</h3>
			        <div class="box-tools pull-right">
				        <button type="button" class="btn btn-box-tool" data-widget="collapse" data-toggle="tooltip" title="Collapse">
				        <i class="fa fa-minus"></i></button>
				        <button type="button" class="btn btn-box-tool" data-widget="remove" data-toggle="tooltip" title="Remove">
				        <i class="fa fa-times"></i></button>
			        </div>
		        </div>
		        <div id="boxbody_BC1" runat ="server"  class="box-body">
		        
		        </div>
		        <div class="box-footer">
		 
		        </div>
	        </div>
	        <div class="box">
		        <div class="box-header with-border">
			        <h3 class="box-title">Business Center-3</h3>
			        <div class="box-tools pull-right">
				        <button type="button" class="btn btn-box-tool" data-widget="collapse" data-toggle="tooltip" title="Collapse">
				        <i class="fa fa-minus"></i></button>
				        <button type="button" class="btn btn-box-tool" data-widget="remove" data-toggle="tooltip" title="Remove">
				        <i class="fa fa-times"></i></button>
			        </div>
		        </div>
		        <div id="boxbody_BC3" runat="server"  class="box-body">
		        
		        </div>
		        <div class="box-footer">
		 
		        </div>
	        </div>	--%>
    </section>

</asp:Content>

