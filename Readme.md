# Another way to implement a Web Service using XPO and DevExpress Data Library


<p>The most efficient way to create a Web Service that allows querying and updating data using XPO is to implement the SelectData, ModifyData, UpdateSchema and GetAutoCreateOption methods in your Web Service, and delegate all queries to the corresponding methods of the connection provider connected to an appropriate database. This approach is described in detail in the <a href="https://www.devexpress.com/Support/Center/p/AK3911">How to use XPO with a Web Service</a> Knowledge Base article.</p><p>This approach allows you to utilize almost all features provided by XPO without caveats. However, sometimes the Web Service is required to provide data for different clients, and some of them might not be able to use XPO. In this situation, it will be quite difficult for them to interpret XPO specific result returned by the methods mentioned above.</p><p>A solution is to provide additional methods, allowing users to query data without XPO. This example demonstrates how to implement this by converting the XPView into the DataSet, and sending data to the client in XML format. Also, the example demonstrates how to add additional flexibility by allowing clients to query data using CriteriaOperators.</p><p>Please note that this is not a recommended way of using XPO, because most capabilities provided by XPO framework will be lost.</p>

<br/>


