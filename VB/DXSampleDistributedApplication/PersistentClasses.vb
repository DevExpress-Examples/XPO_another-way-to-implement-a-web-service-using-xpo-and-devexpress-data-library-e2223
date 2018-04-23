Imports Microsoft.VisualBasic
Imports DevExpress.Xpo
Imports System.Drawing
Imports System

Namespace DXSample.Service.Model
	<Persistent("Categories")> _
	Public Class Category
		Inherits XPLiteObject
		Public Sub New(ByVal session As Session)
			MyBase.New(session)
		End Sub

		Private fCategoryID As Integer
		<Key(True)> _
		Public Property CategoryID() As Integer
			Get
				Return fCategoryID
			End Get
			Set(ByVal value As Integer)
				SetPropertyValue(Of Integer)("CategoryID", fCategoryID, value)
			End Set
		End Property

		Private fCategoryName As String
		Public Property CategoryName() As String
			Get
				Return fCategoryName
			End Get
			Set(ByVal value As String)
				SetPropertyValue(Of String)("CategoryName", fCategoryName, value)
			End Set
		End Property

		Private fDescription As String
		Public Property Description() As String
			Get
				Return fDescription
			End Get
			Set(ByVal value As String)
				SetPropertyValue(Of String)("Description", fDescription, value)
			End Set
		End Property

		<Delayed> _
		Private Property Picture() As Image
			Get
				Return GetDelayedPropertyValue(Of Image)("Picture")
			End Get
			Set(ByVal value As Image)
				SetDelayedPropertyValue(Of Image)("Picture", value)
			End Set
		End Property

		<Association("Category-Products", GetType(Product))> _
		Public ReadOnly Property Products() As XPCollection(Of Product)
			Get
				Return GetCollection(Of Product)("Products")
			End Get
		End Property
	End Class

	<Persistent("Products")> _
	Public Class Product
		Inherits XPLiteObject
		Public Sub New(ByVal session As Session)
			MyBase.New(session)
		End Sub

		Private fProductID As Integer
		<Key(True)> _
		Public Property ProductID() As Integer
			Get
				Return fProductID
			End Get
			Set(ByVal value As Integer)
				SetPropertyValue(Of Integer)("ProductID", fProductID, value)
			End Set
		End Property

		Private fProductName As String
		Public Property ProductName() As String
			Get
				Return fProductName
			End Get
			Set(ByVal value As String)
				SetPropertyValue(Of String)("ProductName", fProductName, value)
			End Set
		End Property

		Private fSupplier As Supplier
		<Association("Supplier-Products"), Persistent("SupplierID")> _
		Public Property Supplier() As Supplier
			Get
				Return fSupplier
			End Get
			Set(ByVal value As Supplier)
				SetPropertyValue(Of Supplier)("SupplierID", fSupplier, value)
			End Set
		End Property

		Private fCategory As Category
		<Association("Category-Products"), Persistent("CategoryID")> _
		Public Property Category() As Category
			Get
				Return fCategory
			End Get
			Set(ByVal value As Category)
				SetPropertyValue(Of Category)("Category", fCategory, value)
			End Set
		End Property

		<Association("Product-OrderDetails", GetType(OrderDetails))> _
		Public ReadOnly Property OrderDetails() As XPCollection(Of OrderDetails)
			Get
				Return GetCollection(Of OrderDetails)("OrderDetails")
			End Get
		End Property
	End Class

	<Persistent("Suppliers")> _
	Public Class Supplier
		Inherits XPLiteObject
		Public Sub New(ByVal session As Session)
			MyBase.New(session)
		End Sub

		Private fSupplierID As Integer
		<Key(True)> _
		Public Property SupplierID() As Integer
			Get
				Return fSupplierID
			End Get
			Set(ByVal value As Integer)
				SetPropertyValue(Of Integer)("SupplierID", fSupplierID, value)
			End Set
		End Property

		Private fCompanyName As String
		Public Property CompanyName() As String
			Get
				Return fCompanyName
			End Get
			Set(ByVal value As String)
				SetPropertyValue(Of String)("CompanyName", fCompanyName, value)
			End Set
		End Property

		<Association("Supplier-Products")> _
		Public ReadOnly Property Products() As XPCollection(Of Product)
			Get
				Return GetCollection(Of Product)("Products")
			End Get
		End Property
	End Class

	<Persistent("Orders")> _
	Public Class Order
		Inherits XPLiteObject
		Public Sub New(ByVal session As Session)
			MyBase.New(session)
		End Sub

		Private fOrderId As Integer
		<Key(True)> _
		Public Property OrderID() As Integer
			Get
				Return fOrderId
			End Get
			Set(ByVal value As Integer)
				SetPropertyValue(Of Integer)("OrderID", fOrderId, value)
			End Set
		End Property

		Private fOrderDate As DateTime
		Public Property OrderDate() As DateTime
			Get
				Return fOrderDate
			End Get
			Set(ByVal value As DateTime)
				SetPropertyValue(Of DateTime)("OrderDate", fOrderDate, value)
			End Set
		End Property

		Private fEmployee As Employee
		<Association("Employee-Orders"), Persistent("EmployeeID")> _
		Public Property Employee() As Employee
			Get
				Return fEmployee
			End Get
			Set(ByVal value As Employee)
				SetPropertyValue(Of Employee)("Employee", fEmployee, value)
			End Set
		End Property

		<Association("Order-OrderDetails", GetType(OrderDetails))> _
		Public ReadOnly Property Details() As XPCollection(Of OrderDetails)
			Get
				Return GetCollection(Of OrderDetails)("Details")
			End Get
		End Property
	End Class

	<Persistent("Employees")> _
	Public Class Employee
		Inherits XPLiteObject
		Public Sub New(ByVal session As Session)
			MyBase.New(session)
		End Sub

		Private fEmployeeId As Integer
		<Key(True)> _
		Public Property EmployeeID() As Integer
			Get
				Return fEmployeeId
			End Get
			Set(ByVal value As Integer)
				SetPropertyValue(Of Integer)("EmployeeID", fEmployeeId, value)
			End Set
		End Property

		Private fCountry As String
		Public Property Country() As String
			Get
				Return fCountry
			End Get
			Set(ByVal value As String)
				SetPropertyValue(Of String)("Country", fCountry, value)
			End Set
		End Property

		Private fFirstName As String
		Public Property FirstName() As String
			Get
				Return fFirstName
			End Get
			Set(ByVal value As String)
				SetPropertyValue(Of String)("FirstName", fFirstName, value)
			End Set
		End Property

		Private fLastName As String
		Public Property LastName() As String
			Get
				Return fLastName
			End Get
			Set(ByVal value As String)
				SetPropertyValue(Of String)("LastName", fLastName, value)
			End Set
		End Property

		<Association("Employee-Orders", GetType(Order))> _
		Public ReadOnly Property Employees() As XPCollection(Of Order)
			Get
				Return GetCollection(Of Order)("Employees")
			End Get
		End Property
	End Class

	Public Structure OrderdetailsKey
		<Association("Order-OrderDetails"), Persistent("OrderID")> _
		Public Order As Order
		<Association("Product-OrderDetails"), Persistent("ProductID")> _
		Public Product As Product
	End Structure

	<Persistent("Order Details")> _
	Public Class OrderDetails
		Inherits XPLiteObject
		Private fId As OrderdetailsKey
		<Key, Persistent> _
		Public Property ID() As OrderdetailsKey
			Get
				Return fId
			End Get
			Set(ByVal value As OrderdetailsKey)
				SetPropertyValue(Of OrderdetailsKey)("ID", fId, value)
			End Set
		End Property

		Private fUnitPrice As Decimal
		Public Property UnitPrice() As Decimal
			Get
				Return fUnitPrice
			End Get
			Set(ByVal value As Decimal)
				SetPropertyValue(Of Decimal)("UnitPrice", fUnitPrice, value)
			End Set
		End Property

		Private fQuantity As Integer
		Public Property Quantity() As Integer
			Get
				Return fQuantity
			End Get
			Set(ByVal value As Integer)
				SetPropertyValue(Of Integer)("Quantity", fQuantity, value)
			End Set
		End Property

		Private fDiscount As Double
		Public Property Discount() As Double
			Get
				Return fDiscount
			End Get
			Set(ByVal value As Double)
				SetPropertyValue(Of Double)("Discount", fDiscount, value)
			End Set
		End Property
	End Class
End Namespace