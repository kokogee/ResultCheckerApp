<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous" />
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-MrcW6ZMFYlzcLA8Nl+NtUVF0sA7MsXsP1UyJoMp4YLEuNSfAP+JcXn/tWtIaxVXM" crossorigin="anonymous"></script>

    <style>
        .remundl{
            text-decoration:none !important;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <section class="vh-100" style="background-color: #9A616D; padding-bottom: 10px !important">
            <div class="container py-5 h-100">
                <div class="row d-flex justify-content-center align-items-center h-100">
                    <div class="col col-xl-10">
                        <div class="card" style="border-radius: 1rem;">
                            <div class="row g-0">
                                <div class="col-md-6 col-lg-5 d-none d-md-block">
                                    <img src="/images/bg.png" alt="login form" class="img-fluid" style="border-radius: 1rem 0 0 1rem" />
                                </div>
                                <div class="col-md-6 col-lg-7 d-flex align-items-center">
                                    <div class="card-body text-black">
                                        <form>
                                            <div style="text-align: center">
                                                <img class="mb-4" src="/images/logo.png" width="100" /><br />
                                                <h5 class="fw-normal mb-3 pb-3" style="letter-spacing: 1px"><b style="color:#9A616D">CARDU RESULT CHECKER</b></h5>
                                            </div>

                                            <div class="form-outline mb-2">
                                                <label>Username</label>
                                                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1" EnableClientScript="true" SetFocusOnError="true" Display="Dynamic" ControlToValidate="txtUsername" ErrorMessage="Required" ForeColor="Red"></asp:RequiredFieldValidator>
                                                <asp:TextBox runat="server" ID="txtUsername" AutoComplete="off" Placeholder="Username" class="form-control"></asp:TextBox>
                                            </div>

                                            <div class="form-outline mb-2">
                                                <label>Password</label>
                                                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator2" EnableClientScript="true" SetFocusOnError="true" Display="Dynamic" ControlToValidate="txtPassword" ErrorMessage="Required" ForeColor="Red"></asp:RequiredFieldValidator>
                                                <asp:TextBox runat="server" ID="txtPassword" AutoComplete="off" Placeholder="********" TextMode="Password" class="form-control"></asp:TextBox>
                                            </div>

                                            <div class="pt-1 mb-4">
                                                <asp:Label runat="server" ID="MessageLabel" ForeColor="Red"></asp:Label><br />
                                                <asp:Button runat="server" ID="btnLogin" OnClick="btnLogin_Click" class="btn btn-dark btn-lg btn-block" Text="Login" />
                                            </div>

                                            <%--<a class="small text-muted remundl" href="#!">Forgot password?</a>--%>
                                        </form>

                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>
    </form>
</body>
</html>
