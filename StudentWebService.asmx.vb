Imports System.ComponentModel
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration


' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
<System.Web.Script.Services.ScriptService()>
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")>
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.None)>
<ToolboxItem(False)> _
Public Class StudentWebService
    Inherits System.Web.Services.WebService

    <WebMethod()>
    Public Function GetStudentByID(ID As Integer) As Student
        Dim cs = ConfigurationManager.ConnectionStrings("DBCS").ConnectionString
        Dim con = New SqlConnection(cs)
        Dim cmd = New SqlCommand("spGetStudentByID", con)
        cmd.CommandType = CommandType.StoredProcedure
        Dim parameter As SqlParameter = New SqlParameter("@ID", ID)
        cmd.Parameters.Add(parameter)
        Dim student As New Student
        con.Open()
        Dim sqlReader As SqlDataReader = cmd.ExecuteReader()
        While sqlReader.Read()
            student.ID = Convert.ToInt32(sqlReader("ID"))
            student.Name = sqlReader("Name").ToString()
            student.Gender = sqlReader("Gender").ToString()
            student.TotalMarks = Convert.ToInt32(sqlReader("TotalMarks"))
        End While
        Return student
    End Function

End Class