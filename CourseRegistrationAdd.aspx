<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="CourseRegistrationAdd.aspx.cs" Inherits="CourseRegistrationAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="container" style="padding-top: 10px">
    <div style="text-align: center">
            <asp:Label runat="server" ID="lbl2" ForeColor="Red"></asp:Label>
        </div>
        <div class="row" style="margin-top: 10px">
            <div class="col-sm-6">
                <div class="form-group">
                    <label>CourseTitle </label>
                    <asp:DropDownList runat="server" ID="ddlCourstitle" class="form-control" placeholder="Course Title">
                    </asp:DropDownList>
                </div>
            </div>
            <div class="col-sm-6">
                <div class="form-group">
                    <label>StudentName</label>
                    <asp:DropDownList runat="server" ID="ddlStudentnumber" class="form-control" placeholder="Student Number"></asp:DropDownList>
                </div>
            </div>
            <div class="col-sm-6">
                <div class="form-group">
                    <label>Level </label>
                    <asp:DropDownList runat="server" ID="ddlLevelid" class="form-control" placeholder="Level"></asp:DropDownList>
                </div>
            </div>
        </div>
        <div class="row" style="padding-top: 20px">
            <div class="col-sm-6">
                <div class="form-group">
                    <asp:Button ID="Button2" runat="server" Text="Submit" OnClick="Button1_Click" CssClass="btn btn-info" />
                </div>
            </div>
      </div>
            </div>
</asp:Content>
