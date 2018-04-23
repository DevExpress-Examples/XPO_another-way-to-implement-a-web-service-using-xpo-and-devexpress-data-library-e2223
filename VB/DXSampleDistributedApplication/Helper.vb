Imports Microsoft.VisualBasic
Imports System.Collections.Generic
Imports System.IO
Imports System.Text
Imports System.Xml
Imports DevExpress.Xpo
Imports DevExpress.Xpo.DB
Imports DevExpress.Xpo.Metadata
Imports DevExpress.Xpo.Metadata.Helpers
Imports System.Data
Imports System.Collections
Imports System.ComponentModel

Namespace DXSample.Service.Model
	Public Class PersistentObjectToXmlConverter
		Private cache As New List(Of IXPSimpleObject)()
		Private dataSet As DataSet

		Public Function ConvertViewToXml(ByVal view As XPView) As String
			dataSet = New DataSet()
			Dim table As DataTable = dataSet.Tables.Add(view.ObjectClassInfo.TableName)
			For Each prop As PropertyDescriptor In (CType(view, ITypedList)).GetItemProperties(Nothing)
				table.Columns.Add(New DataColumn(prop.Name, prop.PropertyType))
			Next prop
			For i As Integer = 0 To view.Count - 1
				Dim data As New ArrayList()
				For Each col As DataColumn In table.Columns
					data.Add(view(i)(col.ColumnName))
				Next col
				table.Rows.Add(data.ToArray())
			Next i
			Return GetXml()
		End Function

		Private Function GetXml() As String
			Using stream As Stream = New MemoryStream()
				Try
					dataSet.WriteXml(stream, XmlWriteMode.WriteSchema)
					stream.Seek(0, SeekOrigin.Begin)
					Dim result As String = New StreamReader(stream).ReadToEnd()
					Return result
				Finally
					dataSet.Dispose()
					dataSet = Nothing
					cache.Clear()
				End Try
			End Using
		End Function
	End Class
End Namespace