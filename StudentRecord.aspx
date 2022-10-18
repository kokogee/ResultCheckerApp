<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="StudentRecord.aspx.cs" Inherits="StudentRecord" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="container" style="padding-top: 10px">
        <div class="row">
            <div class="col-md-">
                <table class="table table-bordered table-striped">
                    <tr>
                        <td>
                            <b>S/N</b>
                        </td>
                        <td>
                            <b>Student Number</b>
                        </td>
                        <td>
                            <b>Student Name</b>
                        </td>
                        <td>
                            <b>Parent Name</b>
                        </td>
                        <td>
                            <b>Parent Phone Number</b>
                        </td>

                        <td>
                            <b>Address</b>
                        </td>
                        <td>
                            <b>Gender</b>
                        </td>
                        <td>
                            <b>Date created</b>
                        </td>
                        <td>
                            <b>Operation</b>
                        </td>
                    </tr>
                    <asp:ListView runat="server" ID="lstStudentRecord" OnItemCommand="lstStudentRecord_ItemCommand">
                        <ItemTemplate>
                            <tr>
                                <td><%#Container.DataItemIndex+1%></td>
                                <td>
                                    <%#Eval("StudentNumber")%>
                                </td>
                                <td>
                                    <%#Eval("StudentName")%>

                                </td>
                                <td>
                                    <%#Eval("ParentName")%>
                                </td>
                                <td>
                                    <%#Eval("ParentPhoneNumber")%>

                                </td>
                                <td>
                                    <%#Eval("Address")%>
                                </td>
                                <td>
                                    <%#Eval("Gender")%>
                                </td>
                                <td>
                                    <%#Eval("DateCreated")%>
                                </td>
                                <td>
                                    <asp:LinkButton runat="server" ID="InkEdit" CommandArgument='<%#Eval("StudentNumber") %>' CommandName="Edt">Edit</asp:LinkButton>
                                    <asp:LinkButton runat="server" ID="LinkButton1" CommandArgument='<%#Eval("StudentNumber") %>' CommandName="Delet">Delete</asp:LinkButton>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:ListView>
                </table>
            </div>
        </div>
    </div>
</asp:Content>

