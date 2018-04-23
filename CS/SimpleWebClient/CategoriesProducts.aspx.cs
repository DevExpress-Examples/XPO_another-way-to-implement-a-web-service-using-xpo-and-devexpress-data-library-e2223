using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using DXSample.Helper;
using DXServiceHelper.DXService;

namespace SimpleWebClient {
    public partial class CategoriesProducts :System.Web.UI.Page {
        ServiceHelper helper;
        protected void Page_Load (object sender, EventArgs e) {
            helper = new ServiceHelper();
            if (!(IsPostBack || IsCallback)) BindSuppliersDropdown();
            BindProductsTable();
        }
        private void BindSuppliersDropdown () {
            DataTable suppliers = null;
            if (IsCallback || IsPostBack) suppliers = Session["Suppliers"] as DataTable;
            if (suppliers == null) {
                List<ViewProperty> properties = new List<ViewProperty>();
                properties.Add(new ViewProperty("Supplier ID", new OperandProperty("SupplierID")));
                properties.Add(new ViewProperty("Company Name", new OperandProperty("CompanyName"),
                    DXServiceHelper.DXService.SortDirection.Ascending));
                suppliers = helper.GetView("Supplier", properties.ToArray(), string.Empty);
                Session["Suppliers"] = suppliers;
            }
            List<string> items = new List<string>();
            foreach (DataRow row in suppliers.Rows) items.Add((string)row["Company Name"]);
            supplierDropdown.DataSource = items;
            supplierDropdown.DataBind();
            if (!(IsCallback || IsPostBack)) supplierDropdown.SelectedIndex = 0;
        }

        private void BindProductsTable () {
            DataTable suppliers = Session["Suppliers"] as DataTable;
            if (suppliers == null) return;
            int supplierId = -1;
            foreach (DataRow row in suppliers.Rows)
                if (row["Company Name"] as string == supplierDropdown.Text) {
                    supplierId = Convert.ToInt32(row["Supplier ID"]);
                    break;
                }
            if (supplierId < 0) return;
            string key = string.Concat("Products_", supplierId);
            if (IsCallback || IsPostBack) productsGrid.DataSource = Session[key];
            if (productsGrid.DataSource == null) {
                List<ViewProperty> properties = new List<ViewProperty>();
                properties.Add(new ViewProperty("Category Name", new OperandProperty("Category.CategoryName"),
                    DXServiceHelper.DXService.SortDirection.Ascending));
                properties.Add(new ViewProperty("Product Name", new OperandProperty("ProductName")));
                productsGrid.DataSource = helper.GetView("Product", properties.ToArray(),
                    string.Concat("Supplier.SupplierID = ", supplierId));
                Session.Add(key, productsGrid.DataSource);
            }
            productsGrid.DataBind();
        }
    }
}