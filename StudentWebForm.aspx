<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="StudentWebForm.aspx.vb" Inherits="WebServiceDemo.StudentWebForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        function GetStudentByID() {
            var id = document.getElementById("SID").value;
            console.log(id);
            WebServiceDemo.StudentWebService.GetStudentByID(id, GetStudentByIDSuccessCallback, GetErrors);
        }
        function GetStudentByIDSuccessCallback(result) {
            document.getElementById("SName").value = result["Name"];
            document.getElementById("SGender").value = result["Gender"];
            document.getElementById("STotalMarks").value = parseInt(result["TotalMarks"]);
        }
        function GetErrors(errors) {
            alert(errors.get_message());
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
 <asp:ScriptManager ID="ScriptManager1" runat="server">
            <Services>
                <asp:ServiceReference Path="StudentWebService.asmx" />
            </Services>
        </asp:ScriptManager>
        <div>
            <table>
                <tr>
                    <td>
                        <b>ID</b>
                    </td>
                    <td>
                        <asp:TextBox ID="SID" runat="server" TextMode="Number"></asp:TextBox>
                        <input type="button" value="Get Student" id="Btn1" onclick="GetStudentByID()"/>
                    </td>
                </tr>
                <tr>
                    <td>
                        <b>Name</b>
                    </td>
                    <td>
                        <asp:TextBox ID="SName" runat="server" TextMode="SingleLine"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <b>Gender</b>
                    </td>
                    <td>
                        <asp:TextBox ID="SGender" runat="server" TextMode="SingleLine"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <b>Total Marks</b>
                    </td>
                    <td>
                        <asp:TextBox ID="STotalMarks" runat="server" TextMode ="Number"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
