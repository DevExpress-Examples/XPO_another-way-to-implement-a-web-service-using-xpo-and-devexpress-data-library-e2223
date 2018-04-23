<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Summaries.aspx.cs" Inherits="SimpleWebClient.Summaries" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Summaries</title>
</head>
<body>
    <a href=Default.aspx>Home</a>
    <form id="form1" runat="server">
        <table>
            <tr>
                <td>Group By:</td>
                <td>
                    <asp:DropDownList ID=groupByList runat=server AutoPostBack=true
                         OnSelectedIndexChanged=OnViewParametersChanged>
                        <asp:ListItem Value=ID.Order.OrderID Text="Order ID" />
                        <asp:ListItem Value=ID.Order.Employee.Country Text=Country />
                        <asp:ListItem Value=ID.Order.Employee.FirstName Text="First Name" />
                        <asp:ListItem Value=ID.Order.Employee.LastName Text="Last Name" />
                        <asp:ListItem Value=ID.Product.ProductName Text="Product Name" />
                        <asp:ListItem Value=ID.Product.Category.CategoryName Text="Category Name" />
                    </asp:DropDownList>
                </td>
                <td>Summary Type:</td>
                <td>
                    <asp:DropDownList ID=summaryTypeList runat=server AutoPostBack=true
                        OnSelectedIndexChanged=OnViewParametersChanged>
                        <asp:ListItem Value=Sum />
                        <asp:ListItem Value=Avg />
                        <asp:ListItem Value=Min />
                        <asp:ListItem Value=Max />
                    </asp:DropDownList>
                </td>
                <td>Filter By:</td>
                <td>
                    <asp:DropDownList ID=filterByList runat=server AutoPostBack=true
                        OnSelectedIndexChanged=OnFilterByListSelectedIndexChanged>
                        <asp:ListItem Value=ID.Order.OrderID Text="Order ID" />
                        <asp:ListItem Value=ID.Order.Employee.Country Text=Country />
                        <asp:ListItem Value=ID.Order.Employee.FirstName Text="First Name" />
                        <asp:ListItem Value=ID.Order.Employee.LastName Text="Last Name" />
                        <asp:ListItem Value=ID.Product.ProductName Text="Product Name" />
                        <asp:ListItem Value=ID.Product.Category.CategoryName Text="Category Name" />
                    </asp:DropDownList>
                </td>
                <td>=</td>
                <td>
                    <asp:DropDownList ID=filterValuesList runat=server AutoPostBack=true
                        OnSelectedIndexChanged=OnViewParametersChanged />
                </td>
            </tr>
            <tr valign=top>
                <td colspan=4>
                    <asp:DataGrid ID=summaryView runat=server AutoPostBack=true
                        OnSelectedIndexChanged=OnSummaryViewSelectedIndexChanged AllowPaging=true
                        OnItemDataBound=OnSummaryViewItemDataBound OnPageIndexChanged=OnViewPageIndexChanged
                        SelectedItemStyle-BackColor=AliceBlue>
                        <Columns>
                            <asp:ButtonColumn Text=Select CommandName=Select />
                        </Columns>
                    </asp:DataGrid>
                </td>
                <td colspan=4>
                    <asp:Datagrid ID=detailView runat=server AllowPaging=true
                        OnPageIndexChanged=OnViewPageIndexChanged AutoGenerateColumns=false>
                        <Columns>
                            <asp:BoundColumn DataField="Sales Person" />
                            <asp:BoundColumn DataField="Extended Price" DataFormatString={0:c2} />
                        </Columns>
                    </asp:Datagrid>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
