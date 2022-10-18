<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="StaffAdd.aspx.cs" Inherits="StaffAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <div class="container " style="padding-top: 10px">
    <label id="msglb" runat="server" style="color: red"></label>
        <div class="row">
            <div class="col-md-6">
                <div class="form-group">
                    <label>Role</label>
                    <asp:DropDownList ID="txtRoleId" class="form-control" runat="server"></asp:DropDownList>
                </div>
            </div>
            <%--<div class="col-md-6">
                <div class="form-group">
                    <label>User Category</label>
                    <asp:DropDownList ID="txtUserCategory" class="form-control" runat="server"></asp:DropDownList>
                </div>
            </div>--%>
            <div class="col-md-6">
                <div class="form-group">
                    <label>Staff Number</label>
                    <asp:TextBox ReadOnly="True" BackColor="White" ID="txtStaffNumber" class="form-control" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="col-md-6">
                <div class="form-group">
                    <label>First Name</label>
                    <asp:TextBox ID="txtFirstName" class="form-control" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="col-md-6">
                <div class="form-group">
                    <label>Last Name</label>
                    <asp:TextBox ID="txtLastName" class="form-control" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="col-md-6">
                <div class="form-group">
                    <label>Other Name</label>
                    <asp:TextBox ID="txtOtherName" class="form-control" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="col-md-6">
                <div class="form-group">
                    <label>Gender</label>
                    <asp:RadioButtonList RepeatDirection="Horizontal" ID="txtGender" class="form-control" runat="server">
                        <asp:ListItem Value="Female">&nbsp;&nbsp;Female&nbsp;&nbsp;</asp:ListItem>
                        <asp:ListItem Value="Male">&nbsp;&nbsp;Male&nbsp;&nbsp;</asp:ListItem>
                    </asp:RadioButtonList>
                </div>
            </div>
            <%--<div class="col-md-6">
                <div class="form-group">
                    <label>EmaillAddress</label>
                    <asp:TextBox ID="txtEmailAddress" class="form-control" runat="server"></asp:TextBox>
                </div>
            </div>--%>
            <div class="col-md-6">
                <div class="form-group">
                    <label>Phone number</label>
                    <asp:TextBox ID="txtPhoneNumber" class="form-control" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="col-md-6">
                <div class="form-group">
                    <label>Date of birth</label>
                    <asp:TextBox ID="txtDateofBirth" TextMode="Date" class="form-control" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="col-md-6">
                <div class="form-group">
                    <label>Password</label>
                    <asp:TextBox ID="txtPassword" runat="server" class="form-control"></asp:TextBox>

                </div>
            </div>
            <div class="col-md-6">
                <div class="form-group">
                    <label>Status</label>
                    <asp:RadioButtonList RepeatDirection="Horizontal" ID="txtStatus" class="form-control" runat="server">
                        <asp:ListItem Value="Active">&nbsp;&nbsp;Active&nbsp;&nbsp;</asp:ListItem>
                        <asp:ListItem Value="Inactive">&nbsp;&nbsp;Inactive&nbsp;&nbsp;</asp:ListItem>
                    </asp:RadioButtonList>
                </div>
            </div>
            <div class="col-md-6">
                <div class="form-group">
                    <label>Address</label>
                    <asp:TextBox ID="txtAddress" class="form-control" runat="server"></asp:TextBox>
                </div>
            </div>
             <div class="col-md-6">
                <div class="form-group">
                    <label>Passport Photo</label>
                    <asp:FileUpload ID="txtPassportPhoto" class="form-control" runat="server" />                   
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-md-6" style="padding-top: 10px">
                <div class="form-group">
                    <asp:Button ID="txtSubmit" runat="server" Text="Submit" OnClick="txtSubmit_Click" CssClass="btn btn-info" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>

