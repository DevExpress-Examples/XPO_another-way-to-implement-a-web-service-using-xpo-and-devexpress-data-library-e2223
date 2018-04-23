using DevExpress.Xpo;
using System.Drawing;
using System;

namespace DXSample.Service.Model {
    [Persistent("Categories")]
    public class Category :XPLiteObject {
        public Category (Session session) : base(session) { }

        private int fCategoryID;
        [Key(true)]
        public int CategoryID {
            get { return fCategoryID; }
            set { SetPropertyValue<int>("CategoryID", ref fCategoryID, value); }
        }

        private string fCategoryName;
        public string CategoryName {
            get { return fCategoryName; }
            set { SetPropertyValue<string>("CategoryName", ref fCategoryName, value); }
        }

        private string fDescription;
        public string Description {
            get { return fDescription; }
            set { SetPropertyValue<string>("Description", ref fDescription, value); }
        }

        [Delayed]
        private Image Picture {
            get { return GetDelayedPropertyValue<Image>("Picture"); }
            set { SetDelayedPropertyValue<Image>("Picture", value); }
        }

        [Association("Category-Products", typeof(Product))]
        public XPCollection<Product> Products { get { return GetCollection<Product>("Products"); } }
    }

    [Persistent("Products")]
    public class Product :XPLiteObject {
        public Product (Session session) : base(session) { }

        private int fProductID;
        [Key(true)]
        public int ProductID {
            get { return fProductID; }
            set { SetPropertyValue<int>("ProductID", ref fProductID, value); }
        }

        private string fProductName;
        public string ProductName {
            get { return fProductName; }
            set { SetPropertyValue<string>("ProductName", ref fProductName, value); }
        }

        private Supplier fSupplier;
        [Association("Supplier-Products"), Persistent("SupplierID")]
        public Supplier Supplier {
            get { return fSupplier; }
            set { SetPropertyValue<Supplier>("SupplierID", ref fSupplier, value); }
        }

        private Category fCategory;
        [Association("Category-Products"), Persistent("CategoryID")]
        public Category Category {
            get { return fCategory; }
            set { SetPropertyValue<Category>("Category", ref fCategory, value); }
        }

        [Association("Product-OrderDetails", typeof(OrderDetails))]
        public XPCollection<OrderDetails> OrderDetails { get { return GetCollection<OrderDetails>("OrderDetails"); } }
    }

    [Persistent("Suppliers")]
    public class Supplier :XPLiteObject {
        public Supplier (Session session) : base(session) { }

        private int fSupplierID;
        [Key(true)]
        public int SupplierID {
            get { return fSupplierID; }
            set { SetPropertyValue<int>("SupplierID", ref fSupplierID, value); }
        }

        private string fCompanyName;
        public string CompanyName {
            get { return fCompanyName; }
            set { SetPropertyValue<string>("CompanyName", ref fCompanyName, value); }
        }

        [Association("Supplier-Products")]
        public XPCollection<Product> Products { get { return GetCollection<Product>("Products"); } }
    }

    [Persistent("Orders")]
    public class Order :XPLiteObject {
        public Order (Session session) : base(session) { }

        private int fOrderId;
        [Key(true)]
        public int OrderID {
            get { return fOrderId; }
            set { SetPropertyValue<int>("OrderID", ref fOrderId, value); }
        }

        private DateTime fOrderDate;
        public DateTime OrderDate {
            get { return fOrderDate; }
            set { SetPropertyValue<DateTime>("OrderDate", ref fOrderDate, value); }
        }

        private Employee fEmployee;
        [Association("Employee-Orders"), Persistent("EmployeeID")]
        public Employee Employee {
            get { return fEmployee; }
            set { SetPropertyValue<Employee>("Employee", ref fEmployee, value); }
        }

        [Association("Order-OrderDetails", typeof(OrderDetails))]
        public XPCollection<OrderDetails> Details { get { return GetCollection<OrderDetails>("Details"); } }
    }

    [Persistent("Employees")]
    public class Employee :XPLiteObject {
        public Employee (Session session) : base(session) { }

        private int fEmployeeId;
        [Key(true)]
        public int EmployeeID {
            get { return fEmployeeId; }
            set { SetPropertyValue<int>("EmployeeID", ref fEmployeeId, value); }
        }

        private string fCountry;
        public string Country {
            get { return fCountry; }
            set { SetPropertyValue<string>("Country", ref fCountry, value); }
        }

        private string fFirstName;
        public string FirstName {
            get { return fFirstName; }
            set { SetPropertyValue<string>("FirstName", ref fFirstName, value); }
        }

        private string fLastName;
        public string LastName {
            get { return fLastName; }
            set { SetPropertyValue<string>("LastName", ref fLastName, value); }
        }

        [Association("Employee-Orders", typeof(Order))]
        public XPCollection<Order> Employees { get { return GetCollection<Order>("Employees"); } }
    }

    public struct OrderdetailsKey {
        [Association("Order-OrderDetails"), Persistent("OrderID")]
        public Order Order;
        [Association("Product-OrderDetails"), Persistent("ProductID")]
        public Product Product;
    }

    [Persistent("Order Details")]
    public class OrderDetails :XPLiteObject {
        private OrderdetailsKey fId;
        [Key, Persistent]
        public OrderdetailsKey ID {
            get { return fId; }
            set { SetPropertyValue<OrderdetailsKey>("ID", ref fId, value); }
        }

        private decimal fUnitPrice;
        public decimal UnitPrice {
            get { return fUnitPrice; }
            set { SetPropertyValue<decimal>("UnitPrice", ref fUnitPrice, value); }
        }

        private int fQuantity;
        public int Quantity {
            get { return fQuantity; }
            set { SetPropertyValue<int>("Quantity", ref fQuantity, value); }
        }

        private double fDiscount;
        public double Discount {
            get { return fDiscount; }
            set { SetPropertyValue<double>("Discount", ref fDiscount, value); }
        }
    }
} 