<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="DepartmentAdd.aspx.cs" Inherits="DepartmentAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <label id="msglb" runat="server" style="color: red"></label>
    <div class="container" style="padding-top: 20px">
        <div class="container" style="margin-top: 20px">
            <div class="row">
                <div class="col-md-6">
                    <div class="form-group">
                        <label>Department name</label>
                        <asp:TextBox ID="txtDepartmentName" class="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="form-group">
                        <label>Head of Department name</label>
                        <asp:DropDownList ID="ddlHeadofDeptName" class="form-control" runat="server"></asp:DropDownList>
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="form-group">
                        <label>Faculty name</label>
                        <asp:DropDownList ID="ddlFacultyName" class="form-control" runat="server"></asp:DropDownList>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-6" style="padding-top: 10px">
                    <div class="form-group">
                        <asp:Button ID="txtSubmit" runat="server" Text="Submit" OnClick="BtnSubmit_Click" CssClass="btn btn-info" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>