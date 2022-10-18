<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="CourseRecord.aspx.cs" Inherits="CourseRecord" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <style>
        td{
            text-align:left !important;
        }
    </style>
     <div class="col-sm-12">
         <table class="table table-bordered table-striped">
                <tr>
                    <td>
                        <b>Course Name</b>
                    </td>
                    <td>
                        <b>Course Code</b>
                    </td>
                     <td>
                            <b>Operations</b>
                        </td>
                </tr>
             <asp:ListView runat="server" ID ="lstCourse" OnItemCommand="lstCourse_ItemCommand">
                  <ItemTemplate>
                        <tr>
                            <td>
                                <%# Eval("CourseName")%>
                            </td>
                            >
                            <td>
                                <%# Eval("CourseCode")%>
                            </td>
                                <td>
                                    <asp:LinkButton runat="server" ID="InkEdit" CommandArgument='<%#Eval("CourseCode") %>' CommandName="Eit">Edit</asp:LinkButton>
                                     <asp:LinkButton runat="server" ID="LinkButton1" CommandArgument='<%#Eval("CourseCode") %>' CommandName="Delet">Delete</asp:LinkButton>
                                </td>
                        </tr>
                    </ItemTemplate>
             </asp:ListView>
         </table>
     </div>
</asp:Content>