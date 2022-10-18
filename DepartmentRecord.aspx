<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="DepartmentRecord.aspx.cs" Inherits="DepartmentRecord" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">

    <div class="container">
        <div class="row">
            <div class="col-md-12">
                <table class="table table-bordered table-striped">
                    <tr>
                       <td>
                           <b>S/N</b>
                       </td>
                        <td>
                            <b>Department Name</b>
                        </td>
                        <td>
                            <b>Head of Department </b>
                        </td>
                        <td>
                            <b>Faculty Name</b>
                        </td>
                         <td>
                            <b>Date Created</b>
                        </td>
                         <td>
                            <b>Operation</b>
                        </td>
                    </tr>
                    <asp:ListView runat="server" ID="lstDepartmentRecord" OnItemCommand="lstDepartmentRecord_ItemCommand1">
                        <ItemTemplate>
                            <tr>
                                <td><%#Container.DataItemIndex+1%></td>                            
                                <td>
                                    <%#Eval("DepartmentName")%>
                                </td>
                                <td>
                                    <%#Eval("HeadofDeptID")%>
                                </td>
                                <td>
                                    <%#Eval("FacultyID")%>
                                </td>
                                <td>
                                    <%#Eval("DateCreated")%>
                                </td>
                                <td>
                                    <asp:LinkButton runat="server" ID="InkEdit" CommandArgument='<%#Eval("DepartmentID") %>' CommandName="Edt">Edit</asp:LinkButton>
                                     <asp:LinkButton runat="server" ID="LinkButton1" CommandArgument='<%#Eval("DepartmentID") %>' CommandName="Del">Delete</asp:LinkButton>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:ListView>
                </table>
            </div>
        </div>
        </div>
</asp:Content>

