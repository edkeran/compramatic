<%@ Page Language="C#" AutoEventWireup="true" CodeFile="~/LogicaPresentacion/LoginUsr.aspx.cs" Inherits="Presentacion_LoginUsr" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <meta charset="utf-8" />
    <title runat="server" id="title">Compramatic | Login Usuario</title>
    <meta content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=no" name="viewport" />
    <meta content="" name="description" />
    <meta content="" name="author" />

    <!-- ================== BEGIN BASE CSS STYLE ================== -->
    <link href="http://fonts.googleapis.com/css?family=Open+Sans:300,400,600,700" rel="stylesheet" />
    <link href="../App_Themes/Assets/plugins/jquery-ui/themes/base/minified/jquery-ui.min.css" rel="stylesheet" />
    <link href="../App_Themes/Assets/plugins/bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../App_Themes/Assets/plugins/font-awesome/css/font-awesome.min.css" rel="stylesheet" />
    <link href="../App_Themes/Assets/css/animate.min.css" rel="stylesheet" />
    <link href="../App_Themes/Assets/css/style.min.css" rel="stylesheet" />
    <link href="../App_Themes/Assets/css/style-responsive.min.css" rel="stylesheet" />
    <link href="../App_Themes/Assets/css/theme/default.css" rel="stylesheet" id="theme" />
    <!-- ================== END BASE CSS STYLE ================== -->

    <!-- ================== BEGIN BASE JS ================== -->
    <script src="../App_Themes/Assets/plugins/pace/pace.min.js"></script>
    <script src="../App_Themes/JS-Redireccion/Funiones.js"></script>
    <!-- ================== END BASE JS ================== -->
</head>
<body class="pace-top bg-white">

    <!-- begin #page-loader -->
    <div id="page-loader" class="fade in"><span class="spinner"></span></div>
    <!-- end #page-loader -->

    <!-- begin #page-container -->
    <div id="page-container" class="fade">
        <!-- begin login -->
        <div class="login login-with-news-feed">
            <!-- begin news-feed -->
            <div class="news-feed">
                <div class="news-image">
                    <img src="../App_Themes/Assets/img/login-bg/bg-7.jpg" data-id="login-cover-image" alt="" />
                </div>
                <div class="news-caption">
                    <h4 class="caption-title">COMPRAMATIC VIRTUAL SHOP</h4>
                    <p>
                        A NEW SHOPPING WAY.
                    </p>
                </div>
            </div>
            <!-- end news-feed -->
            <!-- begin right-content -->
            <div class="right-content">
                <!-- begin login-header -->
                <div class="login-header">
                    <div class="brand">
                        COMPRAMATIC
                        <small runat="server" id="data">Ingresa tus datos</small>
                    </div>
                    <div class="icon">
                        <i class="fa fa-sign-in"></i>
                    </div>
                </div>
                <!-- end login-header -->
                <!-- begin login-content -->
                <div class="login-content">

                    <form id="form1" runat="server">

                        <div class="form-group m-b-15">
                            <asp:TextBox ID="TB_Email" runat="server" CssClass="form-control" placeholder="Dirección de correo electrónico" TextMode="Email" required="required" MaxLength="30" />

                        </div>
                        <div class="form-group m-b-15">
                            <asp:TextBox ID="TB_Pass" runat="server" CssClass="form-control" placeholder="Contraseña" TextMode="Password" Required="required" MaxLength="30"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <asp:DropDownList ID="DDL_TipoLog" runat="server" CssClass="form-control" datasize="10" data-live-search="true" data-style="btn-white">
                                <asp:ListItem Value="0">Empresa</asp:ListItem>
                                <asp:ListItem Value="1">Cliente</asp:ListItem>
                                <asp:ListItem Value="2">Administrador</asp:ListItem>
                            </asp:DropDownList>
                        </div>

                        <div class="login-buttons">
                            <asp:Button ID="Btn_Login" runat="server" class="btn btn-primary btn-block btn-lg" Text="Ingresar al sitio" OnClick="BtnLogin_Click" />

                        </div>
                        <div class="m-t-20 m-b-40 p-b-40">
                            <asp:Label ID="LB_M1" runat="server" Text="Label">Aún no eres miembro? Da click </asp:Label> <a href="../Presentacion/RegistroUsuario.aspx" class="text-success" runat="server" id="here1">aquí</a> <asp:Label ID="LB_M2" runat="server" Text="Label">para registrarte.</asp:Label><br/>
                            <asp:Label ID="LB_Contra" runat="server" Text="Haz Olvidado Tu Contraseña Da Click"></asp:Label> <a href="../Presentacion/forgotPass.aspx" class="text-success" runat="server" id="here2">aquí</a>.
                        </div>
                        <div class="m-t-20 m-b-40 p-b-40">
                            <asp:Label ID="LB_E1" runat="server" Text="Label">Eres Empresa? Quieres vender tus productos? Da click</asp:Label> <a href="../Presentacion/RegistroEmpresa.aspx" class="text-success" runat="server" id="here3">aquí</a> <asp:Label ID="LB_E2" runat="server">para registrarte.</asp:Label>
                        </div>

                        <hr />
                        <p class="text-center text-inverse">
                            &copy; COMPRAMATIC All Right Reserved 2018
                        </p>
                        <div class="modal fade" id="modal-dialog">
                            <div class="modal-dialog">
                                <div class="modal-content">
                                    <div class="modal-header">
                                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                                        <h4 class="modal-title" runat="server" id="respo">RESPUESTA</h4>
                                    </div>
                                    <div class="modal-body">
                                        <asp:Label runat="server" ID="MensajeModal"></asp:Label>
                                    </div>
                                    <div class="modal-footer">
                                        <a href="javascript:;" class="btn btn-sm btn-white" data-dismiss="modal" id="myBtn">Close</a>
                                    </div>
                                </div>
                            </div>
                        </div>

                    </form>
                </div>
                <!-- end login-content -->
            </div>
            <!-- end right-container -->
        </div>
        <!-- end login -->


    </div>
    <!-- #modal-dialog -->


    <!-- ================== BEGIN BASE JS ================== -->
    <script src="../App_Themes/Assets/plugins/jquery/jquery-1.9.1.min.js"></script>
    <script src="../App_Themes/Assets/plugins/jquery/jquery-migrate-1.1.0.min.js"></script>
    <script src="../App_Themes/Assets/plugins/jquery-ui/ui/minified/jquery-ui.min.js"></script>
    <script src="../App_Themes/Assets/plugins/bootstrap/js/bootstrap.min.js"></script>
    <!--[if lt IE 9]>
		<script src="assets/crossbrowserjs/html5shiv.js"></script>
		<script src="assets/crossbrowserjs/respond.min.js"></script>
		<script src="assets/crossbrowserjs/excanvas.min.js"></script>
	<![endif]-->
    <script src="../App_Themes/Assets/plugins/slimscroll/jquery.slimscroll.min.js"></script>
    <script src="../App_Themes/Assets/plugins/jquery-cookie/jquery.cookie.js"></script>
    <!-- ================== END BASE JS ================== -->

    <!-- ================== BEGIN PAGE LEVEL JS ================== -->
    <script src="../App_Themes/Assets/js/apps.min.js"></script>
    <!-- ================== END PAGE LEVEL JS ================== -->

    <!-- end page container -->
    <script>

        $(document).ready(function () {
            App.init();
        });
    </script>
</body>
</html>
