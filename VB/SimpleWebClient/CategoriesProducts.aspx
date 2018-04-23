<%@ Page Language="vb" AutoEventWireup="true" CodeBehind="CategoriesProducts.aspx.vb" Inherits="SimpleWebClient.CategoriesProducts" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title>"Simple Web Client - Categories Products"</title>
</head>
<body>
	<form id="form1" runat="server">
	<div>
		<a href=Default.aspx>Home</a>
		<table>
			<tr>
				<td><asp:Label ID="supplierLabel" runat="server" Text="Supplier:" /></td>
				<td>
					<asp:DropDownList ID="supplierDropdown" runat="server" AutoPostBack="true" />
				 </td>
			</tr>
			<tr>
				<td colspan="2">
					<asp:DataGrid ID="productsGrid" runat="server" AutoGenerateColumns="false">
						<Columns>
							<asp:BoundColumn DataField="Category Name" HeaderText="Category Name" />
							<asp:BoundColumn DataField="Product Name" HeaderText="Product Name" />
						</Columns>
					</asp:DataGrid>
				</td>
			</tr>
		</table>
	</div>
	</form>
</body>
</html>