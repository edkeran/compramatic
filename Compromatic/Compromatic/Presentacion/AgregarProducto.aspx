<%@ Page Language="C#" AutoEventWireup="true" CodeFile="~/LogicaPresentacion/AgregarProducto.aspx.cs" Inherits="Presentacion_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>Compramatic | Agregar Producto</title>
    <!-- ================== BEGIN BASE CSS STYLE ================== -->
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
    z
    <!-- ================== END PAGE LEVEL STYLE ================== -->
    <!-- ================== BEGIN PAGE LEVEL STYLE ================== -->
    <link href="../App_Themes/Assets/plugins/bootstrap-colorpicker/css/bootstrap-colorpicker.min.css" rel="stylesheet" />
    <link href="../App_Themes/Assets/plugins/bootstrap-combobox/css/bootstrap-combobox.css" rel="stylesheet" />
    <link href="../App_Themes/Assets/plugins/bootstrap-select/bootstrap-select.min.css" rel="stylesheet" />
    <link href="../App_Themes/Assets/plugins/bootstrap-tagsinput/bootstrap-tagsinput.css" rel="stylesheet" />
    <link href="../App_Themes/Assets/plugins/jquery-tag-it/css/jquery.tagit.css" rel="stylesheet" />
    <link href="../App_Themes/Assets/plugins/bootstrap-daterangepicker/daterangepicker-bs3.css" rel="stylesheet" />
    <link href="../App_Themes/Assets/plugins/select2/dist/css/select2.min.css" rel="stylesheet" />
    <link href="../App_Themes/Assets/plugins/bootstrap-eonasdan-datetimepicker/build/css/bootstrap-datetimepicker.min.css" rel="stylesheet" />
    <!-- ================== END PAGE LEVEL STYLE ================== -->

    <!-- ================== BEGIN BASE JS ================== -->
    <script src="../App_Themes/Assets/plugins/pace/pace.min.js"></script>
    <script src="../App_Themes/JS-Redireccion/Funiones.js"></script>
    <!-- ================== END BASE JS ================== -->

</head>
<body>
    <div class="row">
        <div class="col-md-12">
            <div class="panel panel-inverse">
                <div class="panel-heading">
                    <div class="panel-heading-btn">
                        <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-default" data-click="panel-expand"><i class="fa fa-expand"></i></a>
                        <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-success" data-click="panel-reload"><i class="fa fa-repeat"></i></a>
                        <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-warning" data-click="panel-collapse"><i class="fa fa-minus"></i></a>
                    </div>
                    <h4 class="panel-title">Agregar Productos</h4>
                </div>
                <div class="panel-body">
                    <form id="form1" name="form-wizard" data-parsley-validate="true" runat="server">
                        <div id="wizard">
                            <ol>
                                <li>Informacion del Producto
										    <small>Nombre y descripcion el cual verá el cliente a la hora de buscar el producto</small>
                                </li>
                                <li>Inventario del Producto
										    <small>Informacion del stock, cantidad disponible a la venta y precio unitario</small>
                                </li>
                                <li>Terminado
										    <small>Proceda a ver sus productos</small>
                                </li>
                            </ol>
                            <!-- begin wizard step-1 -->
                            <div class="wizard-step-1">
                                <fieldset>
                                    <legend class="pull-left width-full">Identification</legend>
                                    <!-- begin row -->
                                    <div class="row">
                                        <!-- begin col-5 -->
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label>Nombre</label>
                                                <asp:TextBox runat="server" MaxLength="45" placeholder="Nombre" CssClass="form-control" ID="TB_Nombre" data-parsley-group="wizard-step-1" required="required" data-parsley-pattern="/^[[a-zñáéíóúA-ZÑÁÉÍÓÚ\_\-\.\s\xF1\xD1]+$/"></asp:TextBox>
                                            </div>
                                        </div>
                                        <!-- end col-6 -->
                                        <!-- begin col-6 -->
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label>Descripcion (Maximo 150)</label>
                                                <asp:TextBox runat="server" ID="TB_Descripcion" TextMode="MultiLine" placeholder="Descripcion" CssClass="form-control" Rows="4" data-parsley-maxlength="150" data-parsley-group="wizard-step-1" required="required" data-parsley-pattern="/^[[a-zñáéíóúA-ZÑÁÉÍÓÚ\_\-\.\s\xF1\xD1]+$/"></asp:TextBox>
                                            </div>
                                        </div>
                                        <!-- end col-6 -->

                                    </div>
                                    <!-- end row -->
                                </fieldset>
                            </div>
                            <!-- end wizard step-1 -->
                            <!-- begin wizard step-2 -->
                            <div class="wizard-step-2">
                                <fieldset>
                                    <legend class="pull-left width-full">Inventario</legend>
                                    <!-- begin row -->
                                    <div class="row">
                                        <!-- begin col-4 -->
                                        <div class="col-md-4">
                                            <div class="form-group">
                                                <label>Cantidad</label>
                                                <asp:TextBox runat="server" data-parsley-group="wizard-step-2" required="required" max="1000000" data-parsley-type="number" min="1" CssClass="form-control" ID="TB_Cantidad" TextMode="Number"></asp:TextBox>
                                            </div>
                                        </div>
                                        <!-- end col-4 -->
                                        <!-- begin col-4 -->
                                        <div class="col-md-4">
                                            <div class="form-group">
                                                <label>Precio</label>
                                                <div class="input-group">
                                                    <span class="input-group-addon">$</span>
                                                    <asp:TextBox runat="server" CssClass="form-control" data-parsley-group="wizard-step-2" min="50" max="99999950" required="required" ID="TB_Precio" data-parsley-type="number" TextMode="Number"></asp:TextBox>
                                                    <span class="input-group-addon">.00</span>
                                                </div>
                                            </div>
                                        </div>
                                        <!-- end col-4 -->
                                        <!-- begin col-4 -->
                                        <div class="col-md-4">
                                            <div class="form-group">
                                                <label>Categoria</label>
                                                <asp:DropDownList runat="server" ID="DDL_Categoria" CssClass="form-control" AutoPostBack="false" DataSourceID="OBSCategoria" DataTextField="nomCategoria" DataValueField="idCategoria"></asp:DropDownList>
                                                <asp:ObjectDataSource runat="server" ID="OBSCategoria" SelectMethod="MostrarCategoria" TypeName="Logica.L_Componentes"></asp:ObjectDataSource>
                                            </div>
                                        </div>
                                        <!-- end col-4 -->
                                    </div>
                                    <!-- end row -->
                                </fieldset>
                            </div>
                            <!-- end wizard step-2 -->
                            <!-- begin wizard step-3 -->
                            <div>
                                <div class="jumbotron m-b-0 text-center">
                                    <h1>Creacion Exitosa</h1>
                                    <p>La Creacion del producto ha sido exitosa, ahora proceda a agregar las fotos con las cuales su producto será mostrado al publico. </p>
                                    <div runat="server" id="resultado"></div>
                                    <p>
                                        <asp:Button runat="server" ID="BTN_Guardar" Text="Guardar Producto" CssClass="btn btn-primary btn-lg" OnClick="AñadirProducto" />
                                    </p>
                                    <p>
                                        <asp:Button runat="server" ID="BTN_Cancelar" Text="Cancelar" CssClass="btn btn-danger btn-lg" OnClick="BTN_Cancelar_Click" CausesValidation="false" />
                                    </p>
                                </div>
                            </div>
                            <!-- end wizard step-3 -->
                        </div>
                    </form>
                </div>
            </div>
        </div>
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
    <script src="../App_Themes/Assets/plugins/bootstrap-datepicker/js/bootstrap-datepicker.js"></script>
    <script src="../App_Themes/Assets/plugins/ionRangeSlider/js/ion-rangeSlider/ion.rangeSlider.min.js"></script>
    <script src="../App_Themes/Assets/plugins/bootstrap-colorpicker/js/bootstrap-colorpicker.min.js"></script>
    <script src="../App_Themes/Assets/plugins/masked-input/masked-input.min.js"></script>
    <script src="../App_Themes/Assets/plugins/bootstrap-timepicker/js/bootstrap-timepicker.min.js"></script>
    <script src="../App_Themes/Assets/plugins/password-indicator/js/password-indicator.js"></script>
    <script src="../App_Themes/Assets/plugins/bootstrap-combobox/js/bootstrap-combobox.js"></script>
    <script src="../App_Themes/Assets/plugins/bootstrap-select/bootstrap-select.min.js"></script>
    <script src="../App_Themes/Assets/plugins/bootstrap-tagsinput/bootstrap-tagsinput.min.js"></script>
    <script src="../App_Themes/Assets/plugins/bootstrap-tagsinput/bootstrap-tagsinput-typeahead.js"></script>
    <script src="../App_Themes/Assets/plugins/jquery-tag-it/js/tag-it.min.js"></script>
    <script src="../App_Themes/Assets/plugins/bootstrap-daterangepicker/moment.js"></script>
    <script src="../App_Themes/Assets/plugins/bootstrap-daterangepicker/daterangepicker.js"></script>
    <script src="../App_Themes/Assets/plugins/select2/dist/js/select2.min.js"></script>
    <script src="../App_Themes/Assets/plugins/bootstrap-eonasdan-datetimepicker/build/js/bootstrap-datetimepicker.min.js"></script>
    <script src="../App_Themes/Assets/js/form-plugins.demo.min.js"></script>
    <script src="../App_Themes/Assets/js/apps.min.js"></script>
    <!-- ================== END PAGE LEVEL JS ================== -->

    <script>
        $(document).ready(function () {
            App.init();
            FormWizardValidation.init();
            FormPlugins.init();
        });
    </script>
</body>
</html>
