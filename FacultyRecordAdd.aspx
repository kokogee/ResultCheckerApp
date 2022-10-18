<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="FacultyRecordAdd.aspx.cs" Inherits="FacultyRecordAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="container">
        <div class="row">
            <div class="col-md-12">
                <table class="table table-bordered table-striped">
                    <tr>
                        <td>
                            <b>S/N</b>
                        </td>
                        <td>
                            <b>Faculty Dean</b>
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
                    <asp:ListView runat="server" ID="lstFaculrtRecordAdd" OnItemCommand="lstFaculrtRecordAdd_ItemCommand">
                        <ItemTemplate>
                            <tr>
                                <td><%#Container.DataItemIndex+1%></td>
                                <td>
                                    <%#Eval("FacultyDean")%>
                                </td>
                                <td>
                                    <%#Eval("FacultyName")%>
                                </td>
                                <td>
                                    <%#Eval("DateCreated")%>
                                </td>
                                <td>
                                    <asp:LinkButton runat="server" ID="InkEdit" CommandArgument='<%#Eval("FacultyID") %>' CommandName="Edt">Edit</asp:LinkButton>
                                    <asp:LinkButton runat="server" ID="LinkButton1" CommandArgument='<%#Eval("FacultyID") %>' CommandName="Del">Delete</asp:LinkButton>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:ListView>
                </table>
            </div>
        </div>
    </div>
</asp:Content>

