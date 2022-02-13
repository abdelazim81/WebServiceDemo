Imports System.ComponentModel
Imports System.Web.Services
Imports System.Web.Services.Protocols

' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
' <System.Web.Script.Services.ScriptService()> _
<System.Web.Services.WebService(Namespace:="http://tempuri.org/CalculatorWebService")>
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<ToolboxItem(False)> _
Public Class CalculatorWebService
    Inherits System.Web.Services.WebService

    <WebMethod(EnableSession:=True)>
    Public Function Add(Number_1 As Integer, Number_2 As Integer) As Integer
        Dim calculation As List(Of String)
        If Session("CALCULATIONS") Is Nothing Then
            calculation = New List(Of String)
        Else
            calculation = CType(Session("CALCULATIONS"), List(Of String))
        End If
        Dim str As String = Number_1.ToString() + " + " + Number_2.ToString() + " = " + (Number_1 + Number_2).ToString()
        calculation.Add(str)
        Session("CALCULATIONS") = calculation
        Return Number_1 + Number_2
    End Function

    <WebMethod(EnableSession:=True)>
    Public Function GetAllCalculation() As List(Of String)
        Dim calculations As List(Of String)
        If Session("CALCULATIONS") Is Nothing Then
            calculations = New List(Of String)()
            calculations.Add("You have not any previous calculations")
            Return calculations
        Else
            calculations = CType(Session("CALCULATIONS"), List(Of String))
            Return calculations
        End If
    End Function


End Class