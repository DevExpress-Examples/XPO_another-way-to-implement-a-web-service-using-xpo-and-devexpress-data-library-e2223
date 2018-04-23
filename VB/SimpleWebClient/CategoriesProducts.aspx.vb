Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic

Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Data
Imports System.IO
Imports DXSample.Helper
Imports DXService

Namespace SimpleWebClient
	Partial Public Class CategoriesProducts
		Inherits System.Web.UI.Page
		Private helper As ServiceHelper
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			helper = New ServiceHelper()
			If Not(IsPostBack OrElse IsCallback) Then
				BindSuppliersDropdown()
			End If
			BindProductsTable()
		End Sub
		Private Sub BindSuppliersDropdown()
			Dim suppliers As DataTable = Nothing
			If IsCallback OrElse IsPostBack Then
				suppliers = TryCast(Session("Suppliers"), DataTable)
			End If
			If suppliers Is Nothing Then
				Dim properties As New List(Of ViewProperty)()
				properties.Add(New ViewProperty("Supplier ID", New OperandProperty("SupplierID")))
                properties.Add(New ViewProperty("Company Name", New OperandProperty("CompanyName"), DXService.SortDirection.Ascending))
				suppliers = helper.GetView("Supplier", properties.ToArray(), String.Empty)
				Session("Suppliers") = suppliers
			End If
			Dim items As New List(Of String)()
			For Each row As DataRow In suppliers.Rows
				items.Add(CStr(row("Company Name")))
			Next row
			supplierDropdown.DataSource = items
			supplierDropdown.DataBind()
			If Not(IsCallback OrElse IsPostBack) Then
				supplierDropdown.SelectedIndex = 0
			End If
		End Sub

		Private Sub BindProductsTable()
			Dim suppliers As DataTable = TryCast(Session("Suppliers"), DataTable)
			If suppliers Is Nothing Then
				Return
			End If
			Dim supplierId As Integer = -1
			For Each row As DataRow In suppliers.Rows
				If TryCast(row("Company Name"), String) = supplierDropdown.Text Then
					supplierId = Convert.ToInt32(row("Supplier ID"))
					Exit For
				End If
			Next row
			If supplierId < 0 Then
				Return
			End If
			Dim key As String = String.Concat("Products_", supplierId)
			If IsCallback OrElse IsPostBack Then
				productsGrid.DataSource = Session(key)
			End If
			If productsGrid.DataSource Is Nothing Then
				Dim properties As New List(Of ViewProperty)()
                properties.Add(New ViewProperty("Category Name", New OperandProperty("Category.CategoryName"), DXService.SortDirection.Ascending))
				properties.Add(New ViewProperty("Product Name", New OperandProperty("ProductName")))
				productsGrid.DataSource = helper.GetView("Product", properties.ToArray(), String.Concat("Supplier.SupplierID = ", supplierId))
				Session.Add(key, productsGrid.DataSource)
			End If
			productsGrid.DataBind()
		End Sub
	End Class
End Namespace