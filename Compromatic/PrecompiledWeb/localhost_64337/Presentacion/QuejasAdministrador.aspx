<%@ page title="" language="C#" masterpagefile="~/Presentacion/MasterSuperAdministrador.master" autoeventwireup="true" inherits="Presentacion_QuejasAdministrador, App_Web_4kwpqrqr" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="content" class="content">
        <ol class="breadcrumb pull-right">
            <li><a href="javascript:;">Home</a></li>
            <li><a href="javascript:;">PQR</a></li>
            <li class="active" runat="server" id="quej">Quejas</li>
        </ol>
        <h1 class="page-header">PQR <small runat="server" id="comprom">nuestro compromiso es contigo</small></h1>
        <div class="row">
            <div class="col-md-10 ui-sortable">
                <ul class="nav nav-tabs nav-tabs-inverse nav-justified nav-justified-mobile" data-sortable-id="index-2">
                    <li class="active"><a href="#latest-post" data-toggle="tab"><i class="fa fa-envelope m-r-5"></i><span class="hidden-xs" id="adm_pqr" runat="server">PQR Administrador</span></a></li>
                    <li class=""><a href="#purchase" data-toggle="tab"><i class="fa fa-envelope m-r-5"></i><span class="hidden-xs" id="emp_pqr" runat="server">PQR Empresa</span></a></li>
                    <li class=""><a href="#email" data-toggle="tab"><i class="fa fa-envelope m-r-5"></i><span class="hidden-xs" id="clien_pqr" runat="server">PQR Cliente</span></a></li>
                </ul>
                <div class="tab-content" data-sortable-id="index-3">
                    <div class="tab-pane fade active in" id="latest-post">
                        <asp:GridView ID="GridView1" runat="server" DataSourceID="ObjectDataSource1" BorderStyle="None" AutoGenerateColumns="False" AllowPaging="true" OnRowCreated="GridView1_RowCreated">
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <div class="tab-pane fade active in" id="PQRAdministrador">
                                            <div class="height-xs" data-scrollbar="true">
                                                <ul class="media-list media-list-with-divider">
                                                    <li class="media media-sm">
                                                        <a href="javascript:;" class="pull-left">
                                                            <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("foto") %>' class="media-object rounded-corner" />
                                                        </a>
                                                        <div class="media-body">
                                                            <a href="javascript:;">
                                                                <h4 class="media-heading">
                                                                    <asp:Label ID="Label4" runat="server" Text='<%# Eval("nomQueja") %>'></asp:Label></h4>
                                                            </a>
                                                            <p class="m-b-5">
                                                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("desQueja") %>'></asp:Label>
                                                            </p>
                                                            <i class="text-muted">
                                                                <asp:Label ID="LB_send_by" runat="server" Text="Enviada por"></asp:Label>
                                                                <asp:Label ID="Label2" runat="server" Text='<%# Eval("Emisor") %>'></asp:Label>
                                                            </i>
                                                            <p>
                                                                <i class="text-muted">
                                                                <asp:Label ID="LB_date" runat="server" Text="Fecha"></asp:Label>
                                                                <asp:Label ID="Label3" runat="server" Text='<%# Eval("fechaQueja") %>'></asp:Label>
                                                            </i>
                                                            </p>
                                                        </div>
                                                    </li>
                                                    
                                                </ul>
                                             </div>
                                        </div>

                                    </ItemTemplate>
                                    <ControlStyle BorderColor="Silver" BorderStyle="None"></ControlStyle>

                                    <FooterStyle BorderColor="Silver" BorderStyle="None"></FooterStyle>

                                    <HeaderStyle BorderStyle="None" BorderColor="Silver"></HeaderStyle>

                                    <ItemStyle BorderColor="Silver" BorderStyle="None"></ItemStyle>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        <asp:ObjectDataSource runat="server" ID="ObjectDataSource1" SelectMethod="MostrarPQRAdministrador" TypeName="Logica.L_Componentes"></asp:ObjectDataSource>
                    </div>
                    <div class="tab-pane fade" id="purchase">
                        <asp:GridView ID="GridView2" runat="server" BorderStyle="None" DataSourceID="ObjectDataSource2" AutoGenerateColumns="False" OnRowCreated="GridView2_RowCreated">
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <div class="tab-pane fade active in" id="PQREmpresa">
                                            <div class="height-xs" data-scrollbar="true">
                                                <ul class="media-list media-list-with-divider">
                                                    <li class="media media-sm">
                                                        <a href="javascript:;" class="pull-left">
                                                            <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("foto") %>' class="media-object rounded-corner" />
                                                        </a>
                                                        <div class="media-body">
                                                            <a href="javascript:;">
                                                                <h4 class="media-heading">
                                                                    <asp:Label ID="Label4" runat="server" Text='<%# Eval("nomQueja") %>'></asp:Label></h4>
                                                            </a>
                                                            <p class="m-b-5">
                                                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("desQueja") %>'></asp:Label>
                                                            </p>
                                                            <i class="text-muted">
                                                                <asp:Label ID="LB_send_by2" runat="server" Text="Enviada por"></asp:Label>
                                                                <asp:Label ID="Label2" runat="server" Text='<%# Eval("Emisor") %>'></asp:Label>

                                                            </i>
                                                            <p>
                                                                <i class="text-muted">
                                                                    <asp:Label ID="LB_date2" runat="server" Text="Fecha"></asp:Label>  
                                                                <asp:Label ID="Label3" runat="server" Text='<%# Eval("fechaQueja") %>'></asp:Label>
                                                                </i>
                                                            </p>
                                                        </div>
                                                    </li>

                                                </ul>
                                            </div>
                                        </div>
                                    </ItemTemplate>
                                    <ControlStyle BorderColor="Silver" BorderStyle="None"></ControlStyle>

                                    <FooterStyle BorderColor="Silver" BorderStyle="None"></FooterStyle>

                                    <HeaderStyle BorderStyle="None" BorderColor="Silver"></HeaderStyle>

                                    <ItemStyle BorderColor="Silver" BorderStyle="None"></ItemStyle>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        <asp:ObjectDataSource runat="server" ID="ObjectDataSource2" SelectMethod="MostrarPQRAempresa" TypeName="Logica.L_Componentes"></asp:ObjectDataSource>
                    </div>
                    <div class="tab-pane fade" id="email">
                        <asp:GridView ID="GridView3" runat="server" BorderStyle="None" AutoGenerateColumns="False" DataSourceID="ObjectDataSource3" OnRowCreated="GridView3_RowCreated">
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <div class="tab-pane fade active in" id="PQREmpresa">
                                            <div class="height-xs" data-scrollbar="true">
                                                <ul class="media-list media-list-with-divider">
                                                    <li class="media media-sm">
                                                        <a href="javascript:;" class="pull-left">
                                                            <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("foto") %>' class="media-object rounded-corner" />
                                                        </a>
                                                        <div class="media-body">
                                                            <a href="javascript:;">
                                                                <h4 class="media-heading">
                                                                    <asp:Label ID="Label4" runat="server" Text='<%# Eval("nomQueja") %>'></asp:Label></h4>
                                                            </a>
                                                            <p class="m-b-5">
                                                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("desQueja") %>'></asp:Label>
                                                            </p>
                                                            <i class="text-muted">
                                                                <asp:Label ID="LB_send_by3" runat="server" Text="Enviada por"></asp:Label>
                                                                <asp:Label ID="Label2" runat="server" Text='<%# Eval("Emisor") %>'></asp:Label>

                                                            </i>
                                                            <p>
                                                                <i class="text-muted">
                                                                    <asp:Label ID="LB_date3" runat="server" Text="Fecha"></asp:Label>   
                                                                <asp:Label ID="Label3" runat="server" Text='<%# Eval("fechaQueja") %>'></asp:Label>
                                                                </i>
                                                            </p>
                                                        </div>
                                                    </li>

                                                </ul>
                                            </div>
                                        </div>
                                    </ItemTemplate>
                                    <ControlStyle BorderColor="Silver" BorderStyle="None"></ControlStyle>

                                    <FooterStyle BorderColor="Silver" BorderStyle="None"></FooterStyle>

                                    <HeaderStyle BorderStyle="None" BorderColor="Silver"></HeaderStyle>

                                    <ItemStyle BorderColor="Silver" BorderStyle="None"></ItemStyle>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        <asp:ObjectDataSource runat="server" ID="ObjectDataSource3" SelectMethod="MostrarPQRCliente" TypeName="Logica.L_Componentes"></asp:ObjectDataSource>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- ================== BEGIN PAGE LEVEL STYLE ================== -->
    <link href="assets/plugins/jquery-jvectormap/jquery-jvectormap-1.2.2.css" rel="stylesheet" />
    <link href="assets/plugins/bootstrap-datepicker/css/datepicker.css" rel="stylesheet" />
    <link href="assets/plugins/bootstrap-datepicker/css/datepicker3.css" rel="stylesheet" />
    <link href="assets/plugins/gritter/css/jquery.gritter.css" rel="stylesheet" />
    <!-- ================== END PAGE LEVEL STYLE ================== -->
    <!-- ================== BEGIN PAGE LEVEL JS ================== -->
    <script src="assets/plugins/gritter/js/jquery.gritter.js"></script>
    <script src="assets/plugins/flot/jquery.flot.min.js"></script>
    <script src="assets/plugins/flot/jquery.flot.time.min.js"></script>
    <script src="assets/plugins/flot/jquery.flot.resize.min.js"></script>
    <script src="assets/plugins/flot/jquery.flot.pie.min.js"></script>
    <script src="assets/plugins/sparkline/jquery.sparkline.js"></script>
    <script src="assets/plugins/jquery-jvectormap/jquery-jvectormap-1.2.2.min.js"></script>
    <script src="assets/plugins/jquery-jvectormap/jquery-jvectormap-world-mill-en.js"></script>
    <script src="assets/plugins/bootstrap-datepicker/js/bootstrap-datepicker.js"></script>
    <script src="assets/js/dashboard.min.js"></script>
    <script src="assets/js/apps.min.js"></script>
    <!-- ================== END PAGE LEVEL JS ================== -->
</asp:Content>

