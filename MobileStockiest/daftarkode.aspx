<%@ Page Language="VB" AutoEventWireup="false" CodeFile="daftarkode.aspx.vb" Inherits="MobileStockiest_daftarkode" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
	<title>Daftar Kode</title>
    <link rel="stylesheet" href="../assets/bootstrap/css/bootstrap.min.css" />
    <link rel="stylesheet" href="../assets/css/styles.css" />
</head>
<body>
    <div class="col-md-12">
		<div class="col-md-12">
			<div class="panel panel-default height">
				<div class="panel-heading">
					<h3 class="panel-title text-center">DAFTAR KODE</h3>
				</div>
				<div class="panel-body">
					<div><br />
						<div class="col-md-12">
							<div style="text-align:center;" class="sizefont">
								<img border="0" src="http://newoffice.healthwealthint.com/images/logohwi.png" width="135" height="72" />
							</div>
							<div>
								<table class="table">
									<thead class="table table-bordered">
										<tr class="btn-primary">
											<th style="text-align:center;width:auto;">
												Kode
											</th>
											<th style="text-align:center;width:auto;">
												Nama Barang
											</th>
										</tr>
									</thead>
									<tbody class="table table-bordered">
                                        <%
                                            if tpe = "AKT" Then
                                                mlSQL = "SELECT * FROM st_barang where (grp like '" & tpe & "' or grp like '" & tpi & "' or grp like '" & tpd & "') and kode like '%-14%' and sta like 'T' order by kode"
                                            Else
                                                if tpe = "PRD" Then
                                                    mlSQL = "SELECT * FROM st_barang where grp like '" & tpe & "' and kode like '%-14%' and kode not like 'PSA%' and sta like 'T' order by kode"
                                                Else
                                                    mlSQL = "SELECT * FROM st_barang order by id"
                                                End if
                                            end If

                                            mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
                                            If mlREADER.HasRows Then
                                                mlDATATABLE = New Data.DataTable
                                                mlDATATABLE.Load(mlREADER)
                                                For aaaeqSSS = 1 To mlDATATABLE.Rows.Count - 1
%>						
							<tr>
								<td style="text-align:left;width:auto;" class="table table-bordered">&nbsp;&nbsp;<%=mlDATATABLE.Rows(aaaeqSSS)("kode")%></td>
								<td style="text-align:left;width:auto;" class="table table-bordered">&nbsp;&nbsp;<%=mlDATATABLE.Rows(aaaeqSSS)("nama")%></td>
							</tr>
<%  
        Next
    End If
    mlREADER.Close()
%>
									</tbody>
								</table>
							</div>	  
				        </div>
			        </div>
		        </div>
	        </div>
        </div>
    </div>
</body>
</html>
