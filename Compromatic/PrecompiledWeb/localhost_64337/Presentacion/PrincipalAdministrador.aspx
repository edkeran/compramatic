<%@ page title="" language="C#" masterpagefile="~/Presentacion/MasterSuperAdministrador.master" autoeventwireup="true" inherits="Presentacion_PrincipalAdministrador, App_Web_4kwpqrqr" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!-- ================== BEGIN PAGE LEVEL CSS STYLE ================== -->
    <link href="../App_Themes/MasterPageAdmin/assetss/plugins/jquery-jvectormap/jquery-jvectormap-1.2.2.css" rel="stylesheet" />
    <link href="../App_Themes/MasterPageAdmin/assetss/plugins/bootstrap-calendar/css/bootstrap_calendar.css" rel="stylesheet" />
    <link href="../App_Themes/MasterPageAdmin/assetss/plugins/gritter/css/jquery.gritter.css" rel="stylesheet" />
    <link href="../App_Themes/MasterPageAdmin/assetss/plugins/morris/morris.css" rel="stylesheet" />
	<!-- ================== END PAGE LEVEL CSS STYLE ================== -->
    <div id="content" class="content">
        <ol class="breadcrumb pull-right">
            <li><a href="javascript:;">Home</a></li>
            <li><a href="javascript:;" id="welco" runat="server">Bienvenido</a></li>
            <li class="active">Compramatic</li>
        </ol>
        <h1 class="page-header" id="main" runat="server">PRINCIPAL <small id="comp" runat="server">nuestro compromiso es contigo</small></h1>
        <div class="row">
            <div class="col-md-3 col-sm-6">
                <div class="widget widget-stats bg-green">
                    <div class="stats-icon stats-icon-lg"><i class="fa fa-globe fa-fw"></i></div>
                    <div class="stats-title" id="ven" runat="server">VENTAS</div>
                    <div class="stats-number">
                        <asp:Label ID="L_totalVentas" runat="server" Text="220,300,400"></asp:Label>
                    </div>
                    <div class="stats-progress progress">
                        <div class="progress-bar" style="width: 100%;"></div>
                    </div>
                    <div class="stats-desc" id="ven_his" runat="server">Ventas historicas</div>
                </div>
            </div>
            <div class="col-md-3 col-sm-6">
                <div class="widget widget-stats bg-blue">
                    <div class="stats-icon stats-icon-lg"><i class="fa fa-tags fa-fw"></i></div>
                    <div class="stats-title" id="emp_reg" runat="server">EMPRESAS REGISTRADAS</div>
                    <div class="stats-number">
                        <asp:Label ID="L_Empresas" runat="server" Text="2"></asp:Label>
                    </div>
                    <div class="stats-progress progress">
                        <div class="progress-bar" style="width: 100%;"></div>
                    </div>
                    <div class="stats-desc" id="act_emp" runat="server">Numero de empresas actualmente</div>
                </div>
            </div>
            <div class="col-md-3 col-sm-6">
                <div class="widget widget-stats bg-purple">
                    <div class="stats-icon"><i class="fa fa-users"></i></div>
                    <div class="stats-title" id="client_reg" runat="server">CLIENTES REGISTRADOS</div>
                    <div class="stats-number">
                        <asp:Label ID="L_Usuarios" runat="server" Text="4"></asp:Label>
                    </div>
                    <div class="stats-progress progress">
                        <div class="progress-bar" style="width: 100%;"></div>
                    </div>
                    <div class="stats-desc" id="usr_act" runat="server">Numero de usuarios actualmente</div>
                </div>
            </div>
            <div class="col-md-3 col-sm-6">
                <div class="widget widget-stats bg-black">
                    <div class="stats-icon stats-icon-lg"><i class="fa fa-comments fa-fw"></i></div>
                    <div class="stats-title" id="pqr_se" runat="server">TOTAL PQR's ENVIADOS</div>
                    <div class="stats-number">
                        <asp:Label ID="L_Pqr" runat="server" Text=""></asp:Label>
                    </div>
                    <div class="stats-progress progress">
                        <div class="progress-bar" style="width: 100%;"></div>
                    </div>
                    <div class="stats-desc">
                        <asp:Label ID="L_texto" runat="server" Text="PQR enviados por los usuarios"></asp:Label>
                    </div>
                </div>
            </div>
        </div>
        
    </div>
    <!-- ================== BEGIN PAGE LEVEL JS ================== -->
    <script src="../App_Themes/MasterPageAdmin/assetss/plugins/morris/raphael.min.js"></script>
    <script src="../App_Themes/MasterPageAdmin/assets/plugins/morris/morris.js"></script>
    <script src="../App_Themes/MasterPageAdmin/assets/plugins/jquery-jvectormap/jquery-jvectormap-1.2.2.min.js"></script>
    <script src="../App_Themes/MasterPageAdmin/assets/plugins/jquery-jvectormap/jquery-jvectormap-world-merc-en.js"></script>
    <script src="../App_Themes/MasterPageAdmin/assets/plugins/bootstrap-calendar/js/bootstrap_calendar.min.js"></script>
    <script src="../App_Themes/MasterPageAdmin/assets/plugins/gritter/js/jquery.gritter.js"></script>
    <script src="../App_Themes/MasterPageAdmin/assets/js/dashboard-v2.min.js"></script>
    <script src="../App_Themes/MasterPageAdmin/assets/js/apps.min.js"></script>
    <!-- ================== END PAGE LEVEL JS ================== -->
    <script>
		$(document).ready(function() {
			App.init();
			DashboardV2.init();
		});
	</script>
</asp:Content>

