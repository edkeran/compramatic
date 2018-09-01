<%@ Page Language="C#" AutoEventWireup="true" CodeFile="~/LogicaPresentacion/RegistroEmpresa.aspx.cs" Inherits="Presentacion_RegistroEmpresa" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="http://fonts.googleapis.com/css?family=Open+Sans:300,400,600,700" rel="stylesheet" />
    <link href="../App_Themes/Assets/plugins/jquery-ui/themes/base/minified/jquery-ui.min.css" rel="stylesheet" />
    <link href="../App_Themes/Assets/plugins/bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../App_Themes/Assets/plugins/font-awesome/css/font-awesome.min.css" rel="stylesheet" />
    <link href="../App_Themes/Assets/css/animate.min.css" rel="stylesheet" />
    <link href="../App_Themes/Assets/css/style.min.css" rel="stylesheet" />
    <link href="../App_Themes/Assets/css/style-responsive.min.css" rel="stylesheet" />
    <link href="../App_Themes/Assets/css/theme/default.css" rel="stylesheet" id="theme" />
    <!-- ================== END BASE CSS STYLE ================== -->
    <!-- ================== BEGIN PAGE LEVEL STYLE ================== -->
    <link href="../App_Themes/Assets/plugins/bootstrap-wizard/css/bwizard.min.css" rel="stylesheet" />
    <link href="../App_Themes/Assets/plugins/parsley/src/parsley.css" rel="stylesheet" />
    <!-- ================== END PAGE LEVEL STYLE ================== -->
    <!-- ================== BEGIN BASE JS ================== -->
    <script src="../App_Themes/Assets/plugins/pace/pace.min.js"></script>
    <script src="../App_Themes/JS-Redireccion/Funiones.js"></script>
    <script   src='https://code.jquery.com/jquery-2.2.4.min.js'> </script>
    <script src='https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js'></script>
    <!-- ================== END BASE JS ================== -->
    <title>Compramatic | Registro Empresa</title>
</head>
<body>
    <!-- begin #page-loader -->
    <div id="page-loader" class="fade in"><span class="spinner"></span></div>
    <!-- end #page-loader -->
    <div id="page-container" class="fade page-sidebar-fixed page-header-fixed">


        <!-- begin #content -->
        <div class="col-md-12 ">
            <div id="content" class="content">
                <!-- begin row -->
                <div class="row">
                    <!-- begin col-12 -->
                    <div class="col-md-12">
                        <!-- begin panel -->
                        <div class="panel panel-inverse panel-expand">
                            <div class="panel-heading">
                                <h4 class="panel-title">Asistente de Registro</h4>
                            </div>
                            <div class="panel-body">
                                <form runat="server" name="form-wizard" id="form1" data-parsley-validate="true">
                                    <div id="wizard">
                                        <ol>
                                            <li>Identificacion  
                                            </li>
                                            <li>Contacto				    
                                            </li>
                                            <li>Inicio de Sesion
                                            </li>
                                            <li>Informacion de Pago
                                            </li>
                                            <li>Fin del Registro
                                            </li>
                                        </ol>
                                        <!-- begin wizard step-1 -->
                                        <div class="wizard-step-1">
                                            <fieldset>
                                                <legend class="pull-left width-full">Identification</legend>
                                                <!-- begin row -->
                                                <div class="row">
                                                    <!-- begin col-4 -->
                                                    <div class="col-md-4">
                                                        <div class="form-group block1">
                                                            <label>NIT Compañia</label>
                                                            <asp:TextBox placeholder="NIT" runat="server" MaxLength="15" ID="TB_Nit" CssClass="form-control" data-parsley-group="wizard-step-1" required="required"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <!-- end col-4 -->
                                                    <!-- begin col-4 -->
                                                    <div class="col-md-4">
                                                        <div class="form-group">
                                                            <label>Nombre Compañia</label>
                                                            <asp:TextBox runat="server" MaxLength="45" ID="TB_NombreCompañia" placeholder="Nombre" class="form-control" data-parsley-group="wizard-step-1" required="required" data-parsley-pattern="/^[[a-zñáéíóúA-ZÑÁÉÍÓÚ\_\-\.\s\xF1\xD1]+$/"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <!-- end col-4 -->
                                                    <!-- begin col-4 -->
                                                    <div class="col-md-4">
                                                        <div class="form-group">
                                                            <label>Foto</label>
                                                            <asp:FileUpload runat="server" ID="FU_Foto" CssClass="form-control" data-parsley-group="wizard-step-1" required="required" />
                                                        </div>
                                                    </div>
                                                    <!-- end col-4 -->
                                                </div>
                                                <!-- end row -->
                                            </fieldset>
                                        </div>
                                        <!-- end wizard step-1 -->
                                        <!-- begin wizard step-2 -->
                                        <div class="wizard-step-2">
                                            <fieldset>
                                                <legend class="pull-left width-full">Informacion de Contacto</legend>
                                                <!-- begin row 1-->
                                                <div class="row">
                                                    <!-- begin col-4 -->
                                                    <div class="col-md-4">
                                                        <div class="form-group">
                                                            <label>Teléfono</label>
                                                            <asp:TextBox ID="TB_Telefono" runat="server" placeholder="1234567890" CssClass="form-control" data-parsley-group="wizard-step-2" required="required" data-parsley-pattern="/^[0-9\-\(\)\ ]+$/"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <!-- end col-4 -->
                                                    <!-- begin col-4 -->
                                                    <div class="col-md-4">
                                                        <div class="form-group">
                                                            <label>E-mail</label>
                                                            <asp:TextBox ID="TB_Email" MaxLength="30" runat="server" placeholder="someone@example.com" CssClass="form-control" TextMode="Email" data-parsley-group="wizard-step-2" required="required"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <!-- end col-4 -->
                                                    <!-- begin col-4 -->
                                                    <div class="col-md-4">
                                                        <div class="form-group">
                                                            <label>Dirección</label>
                                                            <asp:TextBox ID="TB_Direccion" MaxLength="20" runat="server" placeholder="Dirección" data-parsley-group="wizard-step-2" required="required" CssClass="form-control"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <!-- end col-4 -->
                                                </div>
                                                <!-- end row-1-->
                                            </fieldset>
                                        </div>
                                        <!-- end wizard step-2 -->
                                        <!-- begin wizard step-3 -->
                                        <div class="wizard-step-3">
                                            <fieldset>
                                                <legend class="pull-left width-full">Inicio de Sesion</legend>
                                                <!-- begin row -->
                                                <div class="row">
                                                    <!-- begin col-6 -->
                                                    <div class="col-md-6">
                                                        <div class="form-group">
                                                            <label>Pasword</label>
                                                            <div class="controls">
                                                                <asp:TextBox ID="TB_Contraseña" runat="server" MaxLength="45" CssClass="form-control" TextMode="Password" placeholder="contraseña" 	data-parsley-equalto='#TB_Contraseña2'  data-parsley-group="wizard-step-3" required="required"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <!-- end col-6 -->
                                                    <!-- begin col-6 -->
                                                    <div class="col-md-6">
                                                        <div class="form-group">
                                                            <label>Confirmar Contraseña</label>
                                                            <div class="controls">
                                                                <asp:TextBox runat="server" ID="TB_Contraseña2" MaxLength="45" CssClass="form-control" TextMode="Password" placeholder="Confirmar Contraseña" data-parsley-equalto='#TB_Contraseña'  data-parsley-group="wizard-step-3" required="required"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <!-- end col-6 -->
                                                </div>
                                                <!-- end row -->
                                            </fieldset>
                                        </div>
                                        <!-- end wizard step-3 -->
                                        <div class="wizard-step-4">

                                            <fieldset>
                                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                    <ContentTemplate>
                                                        <legend class="pull-left width-full">Pagos</legend>
                                                        <!-- begin row-->
                                                        <div class="row">
                                                            <!-- begin col-3 -->
                                                            <div class="col-md-3">
                                                                <div class="form-group">
                                                                    <asp:ScriptManager runat="server">
                                                                    </asp:ScriptManager>
                                                                    <label>Membresia</label>
                                                                    <asp:DropDownList runat="server" ID="DDL_Memebresia" CssClass="form-control" AutoPostBack="true" DataSourceID="ODS_Membresia" DataTextField="nomMembresia" DataValueField="idTipo_membresia" OnSelectedIndexChanged="DDL_Memebresia_SelectedIndexChanged"></asp:DropDownList>
                                                                    <asp:ObjectDataSource runat="server" ID="ODS_Membresia" SelectMethod="MostrarTipos" TypeName="DAOMembresia"></asp:ObjectDataSource>
                                                                </div>
                                                            </div>
                                                            <!-- end col-3 -->
                                                            <!-- begin col-3 -->
                                                            <div class="col-md-3">
                                                                <div class="form-group">
                                                                    <label>Fecha Inicio</label>
                                                                    <asp:TextBox ID="TB_FechaInicio" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                            <!-- end col-3 -->
                                                            <!-- begin col-3 -->
                                                            <div class="col-md-3">
                                                                <div class="form-group">
                                                                    <label>Fecha Fin</label>
                                                                    <asp:TextBox ID="TB_FechaFinal" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                            <!-- end col-3 -->
                                                            <!-- begin col-3 -->
                                                            <div class="col-md-3">
                                                                <div class="form-group">
                                                                    <label>Precio</label>
                                                                    <asp:TextBox ID="TB_Precio" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                            <!-- end col-3 -->
                                                        </div>
                                                        <!-- end row -->
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </fieldset>
                                        </div>
                                        <!-- end wizard step-3 -->
                                        <!-- begin wizard step-4 -->
                                        <div>
                                            <div class="jumbotron m-b-0 text-center">
                                                <h1>Fin del Registro</h1>
                                                <p>
                                                    <asp:Button ID="BTN_Registro" CssClass="btn btn-success btn-lg" runat="server" Text="Registrar" OnClick="BTN_Registro_Click" CausesValidation="true" />
                                                </p>
                                                <p>
                                                    <asp:Button ID="BTN_Cancelar" CssClass="btn btn-success btn-lg" runat="server" Text="Cancelar" OnClick="BTN_Cancelar_Click" CausesValidation="false" />
                                                </p>

                                            </div>
                                        </div>
                                        <!-- end wizard step-4 -->

                                    </div>
                                </form>
                            </div>
                        </div>
                        <!-- end panel -->
                    </div>
                    <!-- end col-12 -->
                </div>
                <!-- end row -->
            </div>
            <!-- end #content -->
        </div>
        <!-- #modal-dialog -->
        <div class="modal fade" id="modal-dialog">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                        <h4 class="modal-title">Error</h4>
                    </div>
                    <div class="modal-body">
                        <asp:Label runat="server" ID="MensajeModal"></asp:Label>
                    </div>
                    <div class="modal-footer">
                        <a href="javascript:;" class="btn btn-sm btn-white" data-dismiss="modal">Close</a>
                    </div>
                </div>
            </div>
        </div>


        <!-- begin scroll to top btn -->
        <a href="javascript:;" class="btn btn-icon btn-circle btn-success btn-scroll-to-top fade" data-click="scroll-top"><i class="fa fa-angle-up"></i></a>
        <!-- end scroll to top btn -->
    </div>

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
    <script async="async" src="../App_Themes/Assets/plugins/parsley/dist/parsley.js"></script>
    <script src="../App_Themes/Assets/plugins/bootstrap-wizard/js/bwizard.js"></script>
    <script src="../App_Themes/Assets/js/form-wizards-validation.demo.min.js"></script>
    <script src="../App_Themes/Assets/js/apps.min.js"></script>
    <!-- ================== END PAGE LEVEL JS ================== -->
    <script>
        $(document).ready(function () {
            App.init();
            FormWizardValidation.init();
        });
    </script>
</body>
</html>

