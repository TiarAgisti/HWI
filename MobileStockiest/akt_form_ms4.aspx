<%@ Page Title="" Language="VB" MasterPageFile="~/pagesetting/MsPageMS.master" AutoEventWireup="false" CodeFile="akt_form_ms4.aspx.vb" Inherits="MobileStockiest_akt_form_ms4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mpCONTENT" Runat="Server">
    <section class="content-header" style="background-color: white;">
        <div class="panel panel-default" style="margin: 10px 10px 10px 10px">
            <div class="panel-heading">
                <h3 class="text-center panel-title">FORMULIR PENDAFTARAN</h3>
            </div>
            <div class="panel-body">
                <div>
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h3 class="panel-title">INFORMASI PAKET PENDAFTARAN</h3>
                        </div>
                        <div class="panel-body">
                            <div class="col-md-12" style="padding: 5px 0px 5px 0px">
                                <div class="col-md-3"><span>Nomor Distributor</span></div>
                                <div class="col-md-3">
                                    <input type="text" class="form-control">
                                </div>
						        <div class="col-md-6">
                                    <input type="text" class="form-control">
                                </div>
                            </div>
                            <div class="col-md-12" style="padding: 5px 0px 5px 0px">
                                <div class="col-md-3"><span>Tipe Paket Pendaftaran</span></div>
                                <div class="col-md-3">
                                    <input type="text" class="form-control">
                                </div>
							    <div class="col-md-6">
                                    <select class="form-control">
                                        <optgroup label="This is a group">
                                            <option value="12" selected="">This is item 1</option>
                                            <option value="13">This is item 2</option>
                                            <option value="14">This is item 3</option>
                                        </optgroup>
                                    </select>
                                </div>
                            </div>
                            <div class="col-md-12" style="padding: 5px 0px 5px 0px">
                                <div class="col-md-3"><span>Jumlah Business Center</span></div>
                                <div class="col-md-9">
                                    <input type="text" class="form-control">
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
			
                <div>
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h3 class="panel-title">INFORMASI DISTRIBUTOR</h3>
                        </div>
                        <div class="panel-body">
                            <div class="col-md-12" style="padding: 5px 0px 5px 0px">
                                <div class="col-md-3"><span>Nama Lengkap</span></div>
                                <div class="col-md-4">
                                    <input type="text" class="form-control">
                                </div>
                                <div class="col-md-5">
                                    <input type="text" class="form-control">
                                </div>
                            </div>
                            <div class="col-md-12" style="padding: 5px 0px 5px 0px">
                                <div class="col-md-3"><span>No. Identitas (KTP/SIM)</span></div>
                                <div class="col-md-9">
                                    <input type="text" class="form-control">
                                </div>
                            </div>
                            <div class="col-md-12" style="padding: 5px 0px 5px 0px">
                                <div class="col-md-3"><span>Jenis Kelamin</span></div>
                                <div class="col-md-9">
                                    <select class="form-control">
                                        <optgroup label="This is a group">
                                            <option value="12" selected="">This is item 1</option>
                                            <option value="13">This is item 2</option>
                                            <option value="14">This is item 3</option>
                                        </optgroup>
                                    </select>
                                </div>
                            </div>
                            <div class="col-md-12" style="padding: 5px 0px 5px 0px">
                                <div class="col-md-3"><span>Tanggal Lahir</span></div>
                                <div class="col-md-9">
                                    <input type="date" class="form-control">
                                </div>
                            </div>
                            <div class="col-md-12" style="padding: 5px 0px 5px 0px">
                                <div class="col-md-3"><span>Alamat Lengkap</span></div>
                                <div class="col-md-9">
                                    <input type="text" class="form-control">
                                </div>
                            </div>
                            <div class="col-md-12" style="padding: 5px 0px 5px 0px">
                                <div class="col-md-3"><span>Kota </span></div>
                                <div class="col-md-9">
                                    <input type="text" class="form-control">
                                </div>
                            </div>
                            <div class="col-md-12" style="padding: 5px 0px 5px 0px">
                                <div class="col-md-3"><span>Propinsi </span></div>
                                <div class="col-md-9">
                                    <select class="form-control">
                                        <optgroup label="This is a group">
                                            <option value="12" selected="">This is item 1</option>
                                            <option value="13">This is item 2</option>
                                            <option value="14">This is item 3</option>
                                        </optgroup>
                                    </select>
                                </div>
                            </div>
                            <div class="col-md-12" style="padding: 5px 0px 5px 0px">
                                <div class="col-md-3"><span>Kodepos </span></div>
                                <div class="col-md-9">
                                    <input type="text" class="form-control">
                                </div>
                            </div>
                            <div class="col-md-12" style="padding: 5px 0px 5px 0px">
                                <div class="col-md-3"><span>Alamat Surat Menyurat</span></div>
                                <div class="col-md-9">
                                    <input type="text" class="form-control">
                                </div>
                            </div>
                            <div class="col-md-12" style="padding: 5px 0px 5px 0px">
                                <div class="col-md-3"><span>Kota </span></div>
                                <div class="col-md-9">
                                    <input type="text" class="form-control">
                                </div>
                            </div>
                            <div class="col-md-12" style="padding: 5px 0px 5px 0px">
                                <div class="col-md-3"><span>Propinsi </span></div>
                                <div class="col-md-9">
                                    <select class="form-control">
                                        <optgroup label="This is a group">
                                            <option value="12" selected="">This is item 1</option>
                                            <option value="13">This is item 2</option>
                                            <option value="14">This is item 3</option>
                                        </optgroup>
                                    </select>
                                </div>
                            </div>
                            <div class="col-md-12" style="padding: 5px 0px 5px 0px">
                                <div class="col-md-3"><span>Kodepos </span></div>
                                <div class="col-md-9">
                                    <input type="text" class="form-control">
                                </div>
                            </div>
                            <div class="col-md-12" style="padding: 5px 0px 5px 0px">
                                <div class="col-md-3"><span>Nomor Telepon</span></div>
                                <div class="col-md-9">
                                    <input type="text" class="form-control">
                                </div>
                            </div>
                            <div class="col-md-12" style="padding: 5px 0px 5px 0px">
                                <div class="col-md-3"><span>Nomor HP</span></div>
                                <div class="col-md-9">
                                    <input type="text" class="form-control">
                                </div>
                            </div>
                            <div class="col-md-12" style="padding: 5px 0px 5px 0px">
                                <div class="col-md-3"><span>Nama Suami / Istri</span></div>
                                <div class="col-md-9">
                                    <input type="text" class="form-control">
                                </div>
                            </div>
                            <div class="col-md-12" style="padding: 5px 0px 5px 0px">
                                <div class="col-md-3"><span>Nama Ahli Waris</span></div>
                                <div class="col-md-9">
                                    <input type="text" class="form-control">
                                </div>
                            </div>
                            <div class="col-md-12" style="padding: 5px 0px 5px 0px">
                                <div class="col-md-3"><span>Hubungan </span></div>
                                <div class="col-md-9">
                                    <select class="form-control">
                                        <optgroup label="This is a group">
                                            <option value="12" selected="">This is item 1</option>
                                            <option value="13">This is item 2</option>
                                            <option value="14">This is item 3</option>
                                        </optgroup>
                                    </select>
                                </div>
                            </div>
						    <div class="col-md-12" style="padding: 5px 0px 5px 0px">
                                <div class="col-md-3"><span>Alamat Email</span></div>
                                <div class="col-md-9">
                                    <input type="text" class="form-control">
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
			
                <div>
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h3 class="panel-title">INFORMASI SPONSOR</h3>
                        </div>
                        <div class="panel-body">
                            <div class="col-md-12" style="padding: 5px 0px 5px 0px">
                                <div class="col-md-3"><span>No. Id Distributor Sponsor</span></div>
                                <div class="col-md-9">
                                    <input type="text" class="form-control">
                                </div>
                            </div>
                            <div class="col-md-12" style="padding: 5px 0px 5px 0px">
                                <div class="col-md-3"><span>Nama Distributor Sponsor</span></div>
                                <div class="col-md-9">
                                    <input type="text" class="form-control">
                                </div>
                            </div>
						    <div class="col-md-12" style="padding: 5px 0px 5px 0px">
                                <div class="col-md-3"><span>No Telepon</span></div>
                                <div class="col-md-9">
                                    <input type="text" class="form-control">
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
			
                <div>
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h3 class="panel-title">INFORMASI PENEMPATAN</h3>
                        </div>
                        <div class="panel-body">
                            <div class="col-md-12" style="padding: 5px 0px 5px 0px">
                                <div class="col-md-12">
                                    <div class="radio">
                                        <label><input type="radio">Penempatan Otomatis dibawah Sponsor</label>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-12" style="padding: 5px 0px 5px 0px">
                                <div class="col-md-3"><span>Kaki </span></div>
                                <div class="col-md-9">
                                    <input type="text" class="form-control">
                                </div>
                            </div>
                            <div class="col-md-12" style="padding: 5px 0px 5px 0px">
                                <div class="col-md-12">
                                    <div class="radio">
                                        <label><input type="radio">Penempatan dibawah upline distributor berikut</label>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-12" style="padding: 5px 0px 5px 0px">
                                <div class="col-md-3"><span>No. Id Distributor Upline</span></div>
                                <div class="col-md-9">
                                    <input type="text" class="form-control">
                                </div>
                            </div>
                            <div>
                                <div class="col-md-3"><span>No Telepon</span></div>
                                <div class="col-md-9">
                                    <input type="text" class="form-control">
                                </div>
                            </div>
						    <div class="col-md-12" style="padding: 5px 0px 5px 0px">
                                <div class="col-md-3"><span>Kaki </span></div>
                                <div class="col-md-9">
                                    <input type="text" class="form-control">
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
			
                <div>
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h3 class="panel-title">INFORMASI DATA BANK DAN NPWP</h3>
                        </div>
                        <div class="panel-body">
                            <div class="col-md-12" style="padding: 5px 0px 5px 0px">
                                <div class="col-md-3"><span>Nama Lengkap Nasabah</span></div>
                                <div class="col-md-9">
                                    <input type="text" class="form-control">
                                </div>
                            </div>
                            <div class="col-md-12" style="padding: 5px 0px 5px 0px">
                                <div class="col-md-3"><span>Nama Bank Anda</span></div>
                                <div class="col-md-9">
                                    <select class="form-control">
                                        <optgroup label="This is a group">
                                            <option value="12" selected="">This is item 1</option>
                                            <option value="13">This is item 2</option>
                                            <option value="14">This is item 3</option>
                                        </optgroup>
                                    </select>
                                </div>
                            </div>
						    <div class="col-md-12" style="padding: 5px 0px 5px 0px">
                                <div class="col-md-3"><span>Nomor Rekening</span></div>
                                <div class="col-md-9">
                                    <input type="text" class="form-control">
                                </div>
                            </div>
                            <div class="col-md-12" style="padding: 5px 0px 5px 0px">
                                <div class="col-md-3"><span>Nomor NPWP</span></div>
                                <div class="col-md-3">
                                    <input type="text" class="form-control">
                                </div>
                                <div class="col-md-6">
                                    <label>*Fax/Emailkan/kirim copy kartu NPWP ke kantor pusat</label>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
			
                <div>
                    <button class="btn btn-default" type="button">Konfirmasi Data</button>
                </div>
            </div>
        </div>
        <div style="padding: 20px 20px 20px 20px">
            <div class="col-md-6">
                <label></label>
            </div>
        </div>
    </section>
</asp:Content>

