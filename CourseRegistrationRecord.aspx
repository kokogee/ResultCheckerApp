<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="CourseRegistrationRecord.aspx.cs" Inherits="CourseRegistrationRecord" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <style>
        td {
            text-align: left !important;
        }
    </style>

    <div class="row" style="margin-top: 10px">
        <div class="col-sm-12">
            <table class="table table-bordered table-striped">
                <tr>
                    <td>
                        <b>Student Name</b>
                    </td>
                    <td>
                        <b>Course Name</b>
                    </td>
                    <td>
                        <b>Level Name</b>
                    </td>
                     <td>
                            <b>Operations</b>
                        </td>
                </tr>

                <asp:ListView ID="lstCourseRegistration" runat="server" OnItemCommand="lstCourseRegistration_ItemCommand">
                    <ItemTemplate>
                        <tr>
                            <td>
                                <%# Eval("StudentName")%>
                            </td>
                            <td>
                                <%# Eval("CourseName")%>
                            </td>
                            <td>
                                <%# Eval("LevelName")%>
                            </td>
                              <td>
                                    <asp:LinkButton runat="server" ID="InkEdit" CommandArgument='<%#Eval("CourseRegistrationID") %>' CommandName="Eit">Edit</asp:LinkButton>
                                     <asp:LinkButton runat="server" ID="LinkButton1" CommandArgument='<%#Eval("CourseRegistrationID") %>' CommandName="Delet">Delete</asp:LinkButton>
                                </td>
                        </tr>
                    </ItemTemplate>
                </asp:ListView>
            </table>
        </div>
    </div>

</asp:Content>
