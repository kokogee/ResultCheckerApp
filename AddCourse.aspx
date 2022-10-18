<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="AddCourse.aspx.cs" Inherits="AddCourse" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="container" style="padding-top: 20px">
        <div style="text-align: center">
            <asp:Label runat="server" ID="lbl1" ForeColor="Red"></asp:Label>
        </div>
        <div class="row" style="margin-top: 20px">
            <div class="col-sm-6">
                <div class="form-group">
                    <label>CourseTitle </label>
                    <asp:TextBox runat="server" ID="txtCoursetitle" class="form-control" placeholder="Course Title"></asp:TextBox>
                </div>
            </div>
            <div class="col-sm-6">
                <div class="form-group">
                    <label>CourseCode </label>
                    <asp:TextBox runat="server" ID="txtCoursecode" class="form-control" placeholder="Course Code"> </asp:TextBox>
                </div>
            </div>
        </div>
        <div class="row" style="padding-top: 20px">
            <div class="col-sm-6">
                <div class="form-group">
                    <asp:Button ID="Button1" runat="server" Text="Submit" CssClass="btn btn-info" OnClick="Button1_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
