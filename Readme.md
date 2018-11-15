<!-- default file list -->
*Files to look at*:

* [DXSampleWebService.asmx.cs](./CS/DXSampleDistributedApplication/DXSampleWebService.asmx.cs) (VB: [DXSampleWebService.asmx.vb](./VB/DXSampleDistributedApplication/DXSampleWebService.asmx.vb))
* [Global.asax.cs](./CS/DXSampleDistributedApplication/Global.asax.cs) (VB: [Global.asax.vb](./VB/DXSampleDistributedApplication/Global.asax.vb))
* [Helper.cs](./CS/DXSampleDistributedApplication/Helper.cs) (VB: [Helper.vb](./VB/DXSampleDistributedApplication/Helper.vb))
* [PersistentClasses.cs](./CS/DXSampleDistributedApplication/PersistentClasses.cs) (VB: [PersistentClasses.vb](./VB/DXSampleDistributedApplication/PersistentClasses.vb))
* [DXServiceReferenceExtensions.cs](./CS/DXServiceHelper/DXServiceReferenceExtensions.cs) (VB: [DXServiceReferenceExtensions.vb](./VB/DXServiceHelper/DXServiceReferenceExtensions.vb))
* [Helper.cs](./CS/DXServiceHelper/Helper.cs) (VB: [Helper.vb](./VB/DXServiceHelper/Helper.vb))
* [Reference.cs](./CS/DXServiceHelper/Web References/DXService/Reference.cs) (VB: [Reference.vb](./VB/DXServiceHelper/Web References/DXService/Reference.vb))
* [CategoriesProducts.aspx](./CS/SimpleWebClient/CategoriesProducts.aspx) (VB: [CategoriesProducts.aspx.vb](./VB/SimpleWebClient/CategoriesProducts.aspx.vb))
* [CategoriesProducts.aspx.cs](./CS/SimpleWebClient/CategoriesProducts.aspx.cs) (VB: [CategoriesProducts.aspx.vb](./VB/SimpleWebClient/CategoriesProducts.aspx.vb))
* [Summaries.aspx](./CS/SimpleWebClient/Summaries.aspx) (VB: [Summaries.aspx](./VB/SimpleWebClient/Summaries.aspx))
* [Summaries.aspx.cs](./CS/SimpleWebClient/Summaries.aspx.cs) (VB: [Summaries.aspx](./VB/SimpleWebClient/Summaries.aspx))
<!-- default file list end -->
# Another way to implement a Web Service using XPO and DevExpress Data Library


<p>The most efficient way to create a Web Service that allows querying and updating data using XPO is to implement the SelectData, ModifyData, UpdateSchema and GetAutoCreateOption methods in your Web Service, and delegate all queries to the corresponding methods of the connection provider connected to an appropriate database. This approach is described in detail in the <a href="https://www.devexpress.com/Support/Center/p/AK3911">How to use XPO with a Web Service</a> Knowledge Base article.</p><p>This approach allows you to utilize almost all features provided by XPO without caveats. However, sometimes the Web Service is required to provide data for different clients, and some of them might not be able to use XPO. In this situation, it will be quite difficult for them to interpret XPO specific result returned by the methods mentioned above.</p><p>A solution is to provide additional methods, allowing users to query data without XPO. This example demonstrates how to implement this by converting the XPView into the DataSet, and sending data to the client in XML format. Also, the example demonstrates how to add additional flexibility by allowing clients to query data using CriteriaOperators.</p><p>Please note that this is not a recommended way of using XPO, because most capabilities provided by XPO framework will be lost.</p>

<br/>


