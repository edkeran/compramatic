<%@ Page Language="C#" AutoEventWireup="true" CodeFile="~/LogicaPresentacion/RegistroUsuario.aspx.cs" Inherits="Presentacion_RegistroEmpresa" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<meta charset="utf-8" />
	<title id="title" runat="server">Registro</title>
	<meta content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=no" name="viewport" />
	<meta content="" name="description" />
	<meta content="" name="author" />
	
	<!-- ================== BEGIN BASE CSS STYLE ================== -->
    <link href="../App_Themes/Assets/css/Main_Ajax.css" rel="stylesheet" />
	<link href="http://fonts.googleapis.com/css?family=Open+Sans:300,400,600,700" rel="stylesheet"/>
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
	    <!-- begin register -->
        <div class="register register-with-news-feed">
            <!-- begin news-feed -->
            <div class="news-feed">
                <div class="news-image">
                    <img src="../App_Themes/Assets/img/login-bg/bg-8.jpg" alt="" />
                </div>
                <div class="news-caption">
                    <h4 class="caption-title">COMPROMATIC</h4>
                    <asp:HyperLink ID="HL_Index" runat="server" ForeColor="#CCCC00" NavigateUrl="~/Presentacion/Home.aspx" ValidateRequestMode="Disabled">Volver A La Pagina De Inicio</asp:HyperLink><br />
                    <p id="desc1" runat="server">
                        Registrate en este espacio para poder realizar tus compras de todos los productos que te interesan, explora nuestro sitio y sorprendete con él.                   </p>
                </div>
            </div>
            <!-- end news-feed -->
            <!-- begin right-content -->
            <div class="right-content">
                <!-- begin register-header -->
                <h1 class="register-header" id="reg" runat="server">
                    REGISTRO
                    <small id="desc_reg" runat="server">Crea tu cuenta cliente. Esto es gratis y siempre lo será!.</small>
                </h1>
                <!-- end register-header -->
                <!-- begin register-content -->
                <div class="register-content">
                    <form id="form1" runat="server">
                        <asp:label runat="server" class="control-label" ID="LB_Nmbr">Nombre completo</asp:label>
                        <div class="row row-space-15">
                            <div class="col-md-6 m-b-15">
                                <asp:TextBox ID="TB_FirstName" CssClass="form-control" placeholder="Nombres" runat="server" Required="Required" MaxLength="20"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ForeColor="Red" ControlToValidate="TB_FirstName" ErrorMessage="Error, caracteres no permitidos" ToolTip="La cadena contiene caracteres no validos" ValidationExpression="^[a-zA-Z ñÑ]*$"></asp:RegularExpressionValidator>
                            </div>
                            <div class="col-md-6 m-b-15">
                                <asp:TextBox ID="TB_LastName" CssClass="form-control" placeholder="Apellidos" runat="server" Required="Required" MaxLength="20"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ForeColor="Red" ControlToValidate="TB_LastName" ErrorMessage="Error, caracteres no permitidos" ToolTip="La cadena contiene caracteres no validos" ValidationExpression="^[a-zA-Z ñÑ]*$"></asp:RegularExpressionValidator>
                            </div>
                        </div>

                        <asp:label runat="server" class="control-label" ID="LB_ID">Número de identificación y número telefónico</asp:label>
                        
                        <div class="row m-b-15">      
                       
                            <div class="col-md-6 m-b-15">
                                <asp:TextBox ID="TB_cc" CssClass="form-control" placeholder="Número de identificación" runat="server" TextMode="Number" Required="Required" max="9999999999" MaxLength="10"></asp:TextBox>
                            </div>
                            
                            <div class="col-md-6 m-b-15">
                                <asp:TextBox ID="TB_Telefono" CssClass="form-control" placeholder="Número móvil o linea fija" runat="server" TextMode="Number" Required="Required" max="9999999999" MaxLength="10"></asp:TextBox>
                            </div>
                        </div>

                        <asp:label runat="server" class="control-label" ID="LB_Dir">Dirección</asp:label>
                        <div class="row m-b-15">
                            <div class="col-md-15">
                                <asp:TextBox ID="TB_Direccion" CssClass="form-control" placeholder="Direccion de domicilio" runat="server" Required="Required" MaxLength="50"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ForeColor="Red" ControlToValidate="TB_Direccion" ErrorMessage="Error, caracteres no permitidos" ToolTip="La cadena contiene caracteres no validos" ValidationExpression="^[a-zA-Z ñÑ0-9-]*$"></asp:RegularExpressionValidator>
                            </div>
                        </div>

                        <asp:label runat="server" class="control-label" ID="LB_Email">Correo</asp:label>
                        <div class="row m-b-15">
                            <div class="col-md-15">
                                <asp:TextBox ID="TB_Email" CssClass="form-control" placeholder="Direccion de correo electrónico" runat="server" TextMode="Email" Required="Required" MaxLength="30"></asp:TextBox>
                            </div>
                        </div>
                        
                        <asp:label runat="server" CssClass="control-label" ID="LB_Pass">Contraseña</asp:label>
                        <div class="row m-b-15">
                           <div class="col-md-6 m-b-15">
                                <asp:TextBox ID="TB_Pass1" CssClass="form-control" placeholder="Contraseña" runat="server" TextMode="Password" Required="Required" MaxLength="20"></asp:TextBox>
                               <ajaxToolkit:PasswordStrength ID="PS" runat="server"
                                    TargetControlID="TB_Pass1"
                                    DisplayPosition="BelowLeft"
                                    StrengthIndicatorType="Text"
                                    PreferredPasswordLength="10"
                                    PrefixText="Seguridad: "
                                    StrengthStyles="TextIndicator_TextBox1"
                                    MinimumNumericCharacters="0"
                                    MinimumSymbolCharacters="0"
                                    RequiresUpperAndLowerCaseCharacters="false"
                                    TextStrengthDescriptions="Muy Debil;Debil;Aceptable;Fuerte;Excelente"
                                    TextStrengthDescriptionStyles="cssClass1;cssClass2;cssClass3;cssClass4;cssClass5"
                                    CalculationWeightings="50;15;15;20" />
                            </div>
                            <div class="col-md-6 m-b-15">
                                <asp:TextBox ID="TB_Pass2" CssClass="form-control" placeholder="Confima tu contraseña" runat="server" TextMode="Password" Required="Required" MaxLength="20"></asp:TextBox>
                            </div>
                        </div>
                        
                        
                        <div class="checkbox m-b-30">
                            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                            <asp:CheckBox id="CB_Terminos" runat="server" Text="Confirma tu registro, recuerda que todos los campos son obligatorios."/>
                            <ajaxToolkit:ToggleButtonExtender ID="ToggleEx" runat="server"
                                TargetControlID="CB_Terminos" 
                                ImageWidth="19" 
                                ImageHeight="19"
                                CheckedImageAlternateText="Acepto"
                                UncheckedImageAlternateText="No Acepto"
                                UncheckedImageUrl="~/Archivos/Img_Checkbox/rechazo.png" 
                                CheckedImageUrl="~/Archivos/Img_Checkbox/accept.png" />
                        </div>
                        <div class="register-buttons">
                             
                            <asp:Button ID="BtnRegistrar" runat="server" class="btn btn-primary btn-block btn-lg" Text="REGISTRATE" OnClick="BtnRegistrar_Click" />
                           
                        </div>
                        <div class="m-t-20 m-b-40 p-b-40" id="div_alr" runat="server">
                            Ya eres miembro? Presiona <a href="../Presentacion/LoginUsr.aspx" id="here">aquí</a> para ingresar.
                        </div>
                        <hr />
                        <p class="text-center text-inverse">
                            &copy; COMPROMATIC 2018.
                        </p>
                    </form>
                </div>
                <!-- end register-content -->
            </div>
            <!-- end right-content -->
        </div>
        <!-- end register -->
        
    	</div>
	<!-- end page container -->
	
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

	<script>
	    $(document).ready(function () {
	        App.init();
	    });
	</script>
</body>
</html>
