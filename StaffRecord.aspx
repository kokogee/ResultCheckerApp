<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="StaffRecord.aspx.cs" Inherits="StaffRecord" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <div class="container" style="padding-top:10px">
        <div class="row">
            <div class="col-md-6">
                <table class="table table-bordered table-striped">
                    <tr>
                       <td>
                           <b>S/N</b>
                       </td>
                        <td>
                            <b>User Number </b>
                        </td>
                        <td>
                            <b>Name </b>
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
                            <b>Operations</b>
                        </td>
                    </tr>
                    <asp:ListView runat="server" ID="lstStaffRecord" OnItemCommand="lstStaffRecord_ItemCommand">
                        <ItemTemplate>
                            <tr>
                                <td><%#Container.DataItemIndex+1%></td>
                                <td>
                                    <%#Eval("StaffNumber")%>
                                </td>
                                <td>
                                    <%#Eval("Name")%>
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
                                    <asp:LinkButton runat="server" ID="InkEdit" CommandArgument='<%#Eval("StaffNumber") %>' CommandName="Edt">Edit</asp:LinkButton>
                                     <asp:LinkButton runat="server" ID="LinkButton1" CommandArgument='<%#Eval("StaffNumber") %>' CommandName="Delet">Delete</asp:LinkButton>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:ListView>
                </table>
            </div>
        </div>
    </div>
</asp:Content>

