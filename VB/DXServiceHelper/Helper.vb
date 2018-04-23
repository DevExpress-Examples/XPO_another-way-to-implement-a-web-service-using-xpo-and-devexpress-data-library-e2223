Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports DXService
Imports System.Data
Imports System.IO

Namespace DXSample.Helper
    Public Class ServiceHelper
        Private source As DXSampleWebService

        Public Sub New()
            source = New DXSampleWebService()
        End Sub

        Public Function GetView(ByVal className As String, ByVal properties() As DXService.ViewProperty, ByVal filter As String) As DataTable
            Dim result As New DataSet()
            Dim data As String = source.GetDataView(className, properties, filter)
            result.ReadXml(New StringReader(data), XmlReadMode.ReadSchema)
            Return result.Tables(0)
        End Function
    End Class
End Namespace
