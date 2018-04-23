Imports Microsoft.VisualBasic
Imports System
Imports System.Web
Imports DevExpress.Xpo
Imports DevExpress.Xpo.DB
Imports DevExpress.Xpo.Metadata
Imports DXSample.Service.Model

Namespace DXSample.Service
	Public Class [Global]
		Inherits HttpApplication

		Protected Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
			Dim conn As String = AccessConnectionProvider.GetConnectionString(Server.MapPath("~\App_Data\nwind.mdb"))
			Dim dict As XPDictionary = New ReflectionDictionary()
			dict.GetDataStoreSchema(GetType(Category))
			XpoDefault.Session = Nothing
			Dim prov As IDataStore = XpoDefault.GetConnectionProvider(conn, AutoCreateOption.SchemaAlreadyExists)
			XpoDefault.DataLayer = New ThreadSafeDataLayer(dict, prov)
		End Sub

		Protected Sub Session_Start(ByVal sender As Object, ByVal e As EventArgs)

		End Sub

		Protected Sub Application_BeginRequest(ByVal sender As Object, ByVal e As EventArgs)

		End Sub

		Protected Sub Application_AuthenticateRequest(ByVal sender As Object, ByVal e As EventArgs)

		End Sub

		Protected Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)

		End Sub

		Protected Sub Session_End(ByVal sender As Object, ByVal e As EventArgs)

		End Sub

		Protected Sub Application_End(ByVal sender As Object, ByVal e As EventArgs)

		End Sub
	End Class
End Namespace