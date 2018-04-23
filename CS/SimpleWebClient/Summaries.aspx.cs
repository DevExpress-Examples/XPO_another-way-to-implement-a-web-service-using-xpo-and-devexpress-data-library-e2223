using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DXSample.Helper;
using System.Diagnostics;
using DXServiceHelper.DXService;

namespace SimpleWebClient {
    public partial class Summaries :System.Web.UI.Page {
        private ServiceHelper helper;

        protected void Page_Load (object sender, EventArgs e) {
            helper = new ServiceHelper();
            if (IsPostBack || IsCallback) return;
            UpdatePageData();
        }

        private void UpdatePageData () {
            UpdateFilterValuesList();
            UpdateSummaryView(true);
            UpdateDetailView(true);
        }

        private void UpdateFilterValuesList () {
            List<ViewProperty> properties = new List<ViewProperty>();
            properties.Add(new ViewProperty("Value", new OperandProperty(filterByList.SelectedValue),
                DXServiceHelper.DXService.SortDirection.Ascending, true));
            filterValuesList.DataSource = helper.GetView("OrderDetails", properties.ToArray(), string.Empty);
            filterValuesList.DataValueField = "Value";
            filterValuesList.DataBind();
        }

        private void UpdateSummaryView (bool resetCurrentPage) {
            List<ViewProperty> properties = new List<ViewProperty>();
            properties.Add(new ViewProperty(groupByList.SelectedItem.Text, 
                new OperandProperty(groupByList.SelectedValue), DXServiceHelper.DXService.SortDirection.Ascending,
                true));
            properties.Add(new ViewProperty("Unit Price", 
                new AggregateOperand(null, null, new OperandProperty("UnitPrice"), 
                (Aggregate)Enum.Parse(typeof(Aggregate), summaryTypeList.SelectedValue))));
            properties.Add(new ViewProperty("Quantity",
                new AggregateOperand(null, null, new OperandProperty("Quantity"),
                (Aggregate)Enum.Parse(typeof(Aggregate), summaryTypeList.SelectedValue))));
            properties.Add(new ViewProperty("Discount",
                new AggregateOperand(null, null, new OperandProperty("Discount"),
                (Aggregate)Enum.Parse(typeof(Aggregate), summaryTypeList.SelectedValue))));
            string filter = string.IsNullOrEmpty(filterValuesList.SelectedValue) ? string.Empty :
                string.Concat(filterByList.SelectedValue.Split(';')[0], " = '", 
                GetSafeFilterValue (filterValuesList.SelectedValue), "'");
            summaryView.DataSource = helper.GetView("OrderDetails", properties.ToArray(), filter);
            if (resetCurrentPage) summaryView.CurrentPageIndex = 0;
            summaryView.DataBind();
            if (resetCurrentPage && summaryView.Items.Count > 0) summaryView.SelectedIndex = 0;
        }

        private void UpdateDetailView (bool resetCurrentPage) {
            if (summaryView.SelectedItem == null) return;
            List<ViewProperty> properties = new List<ViewProperty>();
            //FirstName + " " + LastName
            properties.Add(new ViewProperty("Sales Person", 
                new BinaryOperator(new OperandProperty("ID.Order.Employee.FirstName"), 
                new BinaryOperator(new OperandValue(" "), new OperandProperty("ID.Order.Employee.LastName"),
                BinaryOperatorType.Plus), BinaryOperatorType.Plus),
                DXServiceHelper.DXService.SortDirection.Ascending));
            //(UnitPrice * Quantity * (1 - Discount) / 100) * 100
            properties.Add(new ViewProperty("Extended Price", 
                new BinaryOperator(new BinaryOperator(new OperandProperty("UnitPrice"), 
                new BinaryOperator(new OperandProperty("Quantity"), 
                new BinaryOperator(new BinaryOperator(new OperandValue(1), new OperandProperty("Discount"),
                BinaryOperatorType.Minus), new OperandValue(100), BinaryOperatorType.Divide),
                BinaryOperatorType.Multiply), BinaryOperatorType.Multiply), new OperandValue(100),
                BinaryOperatorType.Multiply)));
            string filter = string.Concat(groupByList.SelectedValue, " = '", 
                GetSafeFilterValue(summaryView.SelectedItem.Cells[1].Text), "'");
            detailView.DataSource = 
                helper.GetView("OrderDetails", properties.ToArray(), filter);
            if (resetCurrentPage) detailView.CurrentPageIndex = 0;
            detailView.DataBind();
        }

        protected void OnViewParametersChanged (object sender, EventArgs e) {
            UpdateSummaryView(true);
            UpdateDetailView(true);
        }

        protected void OnFilterByListSelectedIndexChanged (object sender, EventArgs e) {
            UpdatePageData();
        }

        protected void OnSummaryViewSelectedIndexChanged (object sender, EventArgs e) {
            UpdateDetailView(true);
        }

        protected void OnSummaryViewItemDataBound (object sender, DataGridItemEventArgs e) {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem || 
                e.Item.ItemType == ListItemType.SelectedItem)
                e.Item.Cells[4].Text = string.Format("{0:p2}", Convert.ToDecimal(e.Item.Cells[4].Text));
        }

        protected void OnViewPageIndexChanged (object sender, DataGridPageChangedEventArgs e) {
            DataGrid grid = (DataGrid)sender;
            grid.CurrentPageIndex = e.NewPageIndex;
            grid.SelectedIndex = 0;
            UpdateSummaryView(false);
            UpdateDetailView(sender != detailView);
        }

        private string GetSafeFilterValue (string value) {
            return value.Replace("'", "''");
        }
    }
}