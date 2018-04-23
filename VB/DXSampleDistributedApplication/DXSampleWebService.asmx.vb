Imports Microsoft.VisualBasic
Imports System.Web.Services
Imports System.ComponentModel
Imports DevExpress.Xpo
Imports DXSample.Service.Model
Imports DevExpress.Data.Filtering
Imports DevExpress.Xpo.Metadata
Imports System
Imports System.Collections.Generic

Namespace DXSample.Service
	<WebService(Namespace := "http://www.devexpress.com/"), WebServiceBinding(ConformsTo := WsiProfiles.BasicProfile1_1), ToolboxItem(False)> _
	Public Class DXSampleWebService
		Inherits WebService
		<WebMethod> _
		Public Function GetDataView(ByVal className As String, ByVal properties() As ViewProperty, ByVal filter As String) As String
			Using session As New Session()
				Dim classInfo As XPClassInfo = session.GetClassInfo(GetType(Category).Assembly.FullName, String.Concat(GetType(Category).Namespace, ".", className))
				Dim result As New XPView(session, classInfo, New CriteriaOperatorCollection(), CriteriaOperator.Parse(filter))
				result.Properties.AddRange(properties)
				Return New PersistentObjectToXmlConverter().ConvertViewToXml(result)
			End Using
		End Function
	End Class
End Namespace