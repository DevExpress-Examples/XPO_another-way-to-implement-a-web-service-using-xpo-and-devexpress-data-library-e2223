Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic

Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports DXSample.Helper
Imports System.Diagnostics
Imports DXService

Namespace SimpleWebClient
	Partial Public Class Summaries
		Inherits System.Web.UI.Page
		Private helper As ServiceHelper

		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			helper = New ServiceHelper()
			If IsPostBack OrElse IsCallback Then
				Return
			End If
			UpdatePageData()
		End Sub

		Private Sub UpdatePageData()
			UpdateFilterValuesList()
			UpdateSummaryView(True)
			UpdateDetailView(True)
		End Sub

		Private Sub UpdateFilterValuesList()
			Dim properties As New List(Of ViewProperty)()
            properties.Add(New ViewProperty("Value", New OperandProperty(filterByList.SelectedValue), DXService.SortDirection.Ascending, True))
			filterValuesList.DataSource = helper.GetView("OrderDetails", properties.ToArray(), String.Empty)
			filterValuesList.DataValueField = "Value"
			filterValuesList.DataBind()
		End Sub

		Private Sub UpdateSummaryView(ByVal resetCurrentPage As Boolean)
			Dim properties As New List(Of ViewProperty)()
            properties.Add(New ViewProperty(groupByList.SelectedItem.Text, New OperandProperty(groupByList.SelectedValue), DXService.SortDirection.Ascending, True))
			properties.Add(New ViewProperty("Unit Price", New AggregateOperand(Nothing, Nothing, New OperandProperty("UnitPrice"), CType(System.Enum.Parse(GetType(Aggregate), summaryTypeList.SelectedValue), Aggregate))))
			properties.Add(New ViewProperty("Quantity", New AggregateOperand(Nothing, Nothing, New OperandProperty("Quantity"), CType(System.Enum.Parse(GetType(Aggregate), summaryTypeList.SelectedValue), Aggregate))))
			properties.Add(New ViewProperty("Discount", New AggregateOperand(Nothing, Nothing, New OperandProperty("Discount"), CType(System.Enum.Parse(GetType(Aggregate), summaryTypeList.SelectedValue), Aggregate))))
			Dim filter As String = If(String.IsNullOrEmpty(filterValuesList.SelectedValue), String.Empty, String.Concat(filterByList.SelectedValue.Split(";"c)(0), " = '", GetSafeFilterValue (filterValuesList.SelectedValue), "'"))
			summaryView.DataSource = helper.GetView("OrderDetails", properties.ToArray(), filter)
			If resetCurrentPage Then
				summaryView.CurrentPageIndex = 0
			End If
			summaryView.DataBind()
			If resetCurrentPage AndAlso summaryView.Items.Count > 0 Then
				summaryView.SelectedIndex = 0
			End If
		End Sub

		Private Sub UpdateDetailView(ByVal resetCurrentPage As Boolean)
			If summaryView.SelectedItem Is Nothing Then
				Return
			End If
			Dim properties As New List(Of ViewProperty)()
			'FirstName + " " + LastName
            properties.Add(New ViewProperty("Sales Person", New BinaryOperator(New OperandProperty("ID.Order.Employee.FirstName"), New BinaryOperator(New OperandValue(" "), New OperandProperty("ID.Order.Employee.LastName"), BinaryOperatorType.Plus), BinaryOperatorType.Plus), DXService.SortDirection.Ascending))
			'(UnitPrice * Quantity * (1 - Discount) / 100) * 100
			properties.Add(New ViewProperty("Extended Price", New BinaryOperator(New BinaryOperator(New OperandProperty("UnitPrice"), New BinaryOperator(New OperandProperty("Quantity"), New BinaryOperator(New BinaryOperator(New OperandValue(1), New OperandProperty("Discount"), BinaryOperatorType.Minus), New OperandValue(100), BinaryOperatorType.Divide), BinaryOperatorType.Multiply), BinaryOperatorType.Multiply), New OperandValue(100), BinaryOperatorType.Multiply)))
			Dim filter As String = String.Concat(groupByList.SelectedValue, " = '", GetSafeFilterValue(summaryView.SelectedItem.Cells(1).Text), "'")
			detailView.DataSource = helper.GetView("OrderDetails", properties.ToArray(), filter)
			If resetCurrentPage Then
				detailView.CurrentPageIndex = 0
			End If
			detailView.DataBind()
		End Sub

		Protected Sub OnViewParametersChanged(ByVal sender As Object, ByVal e As EventArgs)
			UpdateSummaryView(True)
			UpdateDetailView(True)
		End Sub

		Protected Sub OnFilterByListSelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
			UpdatePageData()
		End Sub

		Protected Sub OnSummaryViewSelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
			UpdateDetailView(True)
		End Sub

		Protected Sub OnSummaryViewItemDataBound(ByVal sender As Object, ByVal e As DataGridItemEventArgs)
			If e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = ListItemType.AlternatingItem OrElse e.Item.ItemType = ListItemType.SelectedItem Then
				e.Item.Cells(4).Text = String.Format("{0:p2}", Convert.ToDecimal(e.Item.Cells(4).Text))
			End If
		End Sub

		Protected Sub OnViewPageIndexChanged(ByVal sender As Object, ByVal e As DataGridPageChangedEventArgs)
			Dim grid As DataGrid = CType(sender, DataGrid)
			grid.CurrentPageIndex = e.NewPageIndex
			grid.SelectedIndex = 0
			UpdateSummaryView(False)
			UpdateDetailView(sender IsNot detailView)
		End Sub

		Private Function GetSafeFilterValue(ByVal value As String) As String
			Return value.Replace("'", "''")
		End Function
	End Class
End Namespace