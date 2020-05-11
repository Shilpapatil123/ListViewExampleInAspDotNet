<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddEmployeeData.aspx.cs" Inherits="AssignmentUsingListViewCrudOperation.AddEmployeeData" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
   
        <fieldset style="width: 300px"><legend>ListView Example</legend>  
        <asp:Table runat="server" Width="229px" >  
            <asp:TableRow>  
                <asp:TableCell>Name</asp:TableCell><asp:TableCell>
                    <asp:TextBox runat="server" ID="txtName"></asp:TextBox></asp:TableCell>  
            </asp:TableRow>  
    
              <asp:TableRow>  
                <asp:TableCell>City</asp:TableCell>
                  <asp:TableCell>
                                      <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True"   
DataTextField="city" DataValueField="city" BackColor="#FFCCCC" Height="32px"   
style="text-align: center" Width="145px">  
                            <asp:ListItem Value="0">-- Select your City--</asp:ListItem>  
                            <asp:ListItem>Rajkot</asp:ListItem>  
                            <asp:ListItem>Ahmedabad</asp:ListItem>  
                            <asp:ListItem>Bhuj</asp:ListItem>  
                            <asp:ListItem>Surat</asp:ListItem>  
                            <asp:ListItem>Delhi</asp:ListItem>  
                        </asp:DropDownList>  
               </asp:TableCell>  
            </asp:TableRow>  
            <asp:TableRow>  
                <asp:TableCell>
                       Gender  <asp:RadioButtonList ID="RadioButtonList1" runat="server" DataTextField="ans"   
                    DataValueField="ans">  
                    <asp:ListItem>Male</asp:ListItem>   <asp:ListItem>Female</asp:ListItem>  
                </asp:RadioButtonList>  
               </asp:TableCell>  
            </asp:TableRow>  
           <asp:TableRow>  
               <asp:TableCell></asp:TableCell>  
               <asp:TableCell>   
                   <asp:Button runat="server" ID="btnSave" Text="Save" OnClick="btnSave_Click" />  
                   <asp:Button runat="server" ID="btnUpdate" Text="Update" OnClick="btnUpdate_Click" />  
               </asp:TableCell>  
       </asp:TableRow>  
      </asp:Table>  
       </fieldset>  
      
  
       <asp:HiddenField ID="hfRecord" runat="server" />  
  
  <h3>Employee Information</h3>  
  
        <asp:ListView ID="ListEmployee" runat="server" OnItemCommand="ListEmployee_ItemCommand" DataKeyNames="EmpID" >  
        <itemtemplate>  
       <table >  
           <tr>  
                        <td style =" width : 100px">  
                            <b>No. :</b>  
                            <%#Eval("EmpID") %>  
                        </td>  
                        <td style =" width : 200px">  
                            <b>Name :</b>  
                            <%#Eval("EmpName") %>  
                        </td>  
                        <td style =" width : 200px">  
                            <b>City :</b>  
                            <%#Eval("City") %>  
                        </td >  
                        <td style =" width : 250px">  
                            <b>Gender :</b>  
                            <%#Eval("Gender") %>  
                        </td>  
                    <td>  
                        <asp:Button ID="btndel" runat="server" Text="Delete" tooltip="Delete a record" onclientclick="javascript:return confirm('Are you sure to delete record?')" CommandName="EmpDelete" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "EmpID") %>' />  
                        <asp:Button ID="btnupdt" runat="server" Text="Edit" tooltip="Update a record" CommandName="EmpEdit" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "EmpID") %>' />  
                    </td>  
            </tr>  
       </table>  
       </itemtemplate>  
    </asp:ListView>
    </form>

</body>
</html>
