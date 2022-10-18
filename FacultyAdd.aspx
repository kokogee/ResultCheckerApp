<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="FacultyAdd.aspx.cs" Inherits="FacultyAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <label id="msglb" runat="server" style="color: red"></label>
    <div class="container" style="padding-top: 20px">
        <div class="container" style="margin-top: 20px">
            <div class="row">
                <div class="col-md-6">
                    <div class="form-group">
                        <label>Faculty Name</label>
                    <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator2" ForeColor="Red" ControlToValidate="txtFacultyName" EnableClientScript="true" SetFocusOnError="true" ErrorMessage="Required" Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:TextBox ID="txtFacultyName" class="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>
                 <div class="col-md-6">
                    <div class="form-group">
                        <label>Faculty Dean</label>                 
                    <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1" ForeColor="Red" ControlToValidate="ddlDeanOfFaculty" EnableClientScript="true" SetFocusOnError="true" ErrorMessage="Required" Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:DropDownList ID="ddlDeanOfFaculty" class="form-control" runat="server"></asp:DropDownList>
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
    </div>
</asp:Content>

