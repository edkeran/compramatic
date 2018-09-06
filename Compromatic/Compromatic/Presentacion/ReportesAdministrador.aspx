<%@ Page Title="" Language="C#" MasterPageFile="~/Presentacion/MasterSuperAdministrador.master" AutoEventWireup="true" CodeFile="~/LogicaPresentacion/Administrador/ReportesAdministrador.aspx.cs" Inherits="Presentacion_ReportesAdministrador" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div id="content" class="content">
        <ol class="breadcrumb pull-right">
            <li><a href="javascript:;">Home</a></li>
            <li><a href="javascript:;">Reporte</a></li>
            <li class="active">Productos reportados</li>
        </ol>
        <h1 class="page-header">Productos reportados<small> nuevas oportunidades de negocio</small></h1>
        <asp:Panel ID="Panel1" runat="server" class="col-md-12">
            <div class="result-container">
                <asp:Label runat="server" ID="idProducto" Visible="false">0</asp:Label>
                <asp:GridView ID="GridView1" runat="server" Width="100%" DataKeyNames="idProducto" AutoGenerateColumns="False" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" BorderStyle="None" DataSourceID="ObjectDataSource1">
                    <AlternatingRowStyle BorderStyle="None" />

                    <Columns>

                        <asp:TemplateField>
                            <ItemTemplate>
                                <ul class="result-list">
                                    <li>
                                        <div class="result-image">
                                            <a href="javascript:;">
                                                <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("rutaArchivo") %>' alt="" Height="180px" Width="240px" /></a>
                                        </div>

                                        <div class="result-info">
                                            <h4 class="title"><a href="javascript:;">
                                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("nomProducto") %>'></asp:Label></a></h4>
                                            <p class="location">
                                                <asp:Label ID="Label3" runat="server" Text="Motivo : "></asp:Label><asp:Label ID="Label2" runat="server" Text='<%# Eval("desMotivo") %>'></asp:Label>
                                            </p>
                                            <p class="location">
                                                <asp:Label ID="Label4" runat="server" Text="Empresa : "></asp:Label><asp:Label ID="Label5" runat="server" Text='<%# Eval("nomEmpresa") %>'></asp:Label>
                                            </p>
                                            <p class="location">
                                                <asp:Label ID="Label7" runat="server" Text="Enviado por : "></asp:Label><asp:Label ID="Label8" runat="server" Text='<%# Eval("nomUsuario") %>'></asp:Label>
                                            </p>

                                            <p class="desc">Cada producto tendra un tope de reportes, cuando este sea excedido el producto sera bloqueado.</p>

                                            <div>
                                                <i class="fa fa-expand fa-2x pull-left fa-fw"></i>
                                                <asp:Button ID="Button1" runat="server" Text="Ver fotos del producto" class="btn btn-link m-b-5" CommandName="Select" />
                                            </div>
                                        </div>

                                        <div class="result-price">
                                            <asp:Label ID="Label6" runat="server" Text='<%# Eval("correoEmpresa") %>'></asp:Label><small>CORREO</small>
                                            <p class="desc">
                                            </p>
                                            <p class="desc">
                                            </p>
                                            <p class="desc">
                                            </p>
                                            <small>
                                                <asp:Label ID="Label9" runat="server" Text='<%# Eval("fechaReporte") %>'></asp:Label></small><small>Fecha del reporte</small>


                                        </div>
                                    </li>
                                    <li></li>
                                </ul>
                            </ItemTemplate>
                            <ControlStyle BorderColor="Silver" BorderStyle="None"></ControlStyle>

                            <FooterStyle BorderColor="Silver" BorderStyle="None"></FooterStyle>

                            <HeaderStyle BorderStyle="None" BorderColor="Silver"></HeaderStyle>

                            <ItemStyle BorderColor="Silver" BorderStyle="None"></ItemStyle>
                        </asp:TemplateField>
                    </Columns>

                    <HeaderStyle BorderStyle="None" />
                    <PagerStyle BorderStyle="None" />
                    <RowStyle BorderStyle="None" />

                </asp:GridView>

                <asp:ObjectDataSource runat="server" ID="ObjectDataSource1" SelectMethod="Reportes" TypeName="Logica.L_Componentes"></asp:ObjectDataSource>
            </div>
        </asp:Panel>

    </div>

    <!-- ================== BEGIN PAGE LEVEL JS ================== -->
    <script src="../App_Themes/MasterPageAdmin/assets/js/table-manage-colreorder.demo.min.js"></script>
    <script src="../App_Themes/MasterPageAdmin/assets/js/apps.min.js"></script>
    <!-- ================== END PAGE LEVEL JS ================== -->
    <!-- ================== BEGIN PAGE LEVEL JS ================== -->
    <script src="../App_Themes/MasterPageAdmin/assets/plugins/DataTables/media/js/jquery.dataTables.js"></script>
    <script src="../App_Themes/MasterPageAdmin/assets/plugins/DataTables/media/js/dataTables.bootstrap.min.js"></script>
    <script src="../App_Themes/MasterPageAdmin/assets/plugins/DataTables/extensions/Responsive/js/dataTables.responsive.min.js"></script>
    <script src="../App_Themes/MasterPageAdmin/assets/js/table-manage-responsive.demo.min.js"></script>
    <script src="../App_Themes/MasterPageAdmin/assets/js/apps.min.js"></script>
    <!-- ================== END PAGE LEVEL JS ================== -->
    <!-- #modal-dialog -->
    <div class="modal fade" id="modal-dialog">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                    <h4>
                        <asp:Label ID="Titulo" class="modal-title" runat="server" Text="IMAGENES"></asp:Label></h4>
                </div>
                <div class="modal-body">
                    <div id="gallery" class="gallery">
                        <asp:Repeater ID="TablaImagenes" runat="server" DataSourceID="OBS_Fotos" OnItemCommand="TablaImagenes_ItemCommand">
                            <ItemTemplate>
                                <div class="image gallery-group-1">
                                    <div class="image-inner">
                                        <a href='<%# Eval("[nomArchivo]") %>' data-lightbox="gallery-group-1">
                                            <img src='<%# Eval("[nomArchivo]") %>' alt="" />
                                        </a>

                                    </div>

                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>

                    <asp:ObjectDataSource runat="server" ID="OBS_Fotos" SelectMethod="MostrarFoto" TypeName="Logica.L_Componentes">

                        <SelectParameters>
                            <asp:ControlParameter ControlID="idProducto" PropertyName="Text" Name="idProducto" Type="Int32"></asp:ControlParameter>
                        </SelectParameters>
                    </asp:ObjectDataSource>
                </div>
                <div class="modal-footer">
                    <a href="javascript:;" class="btn btn-sm btn-white" data-dismiss="modal">Close</a>
                </div>
            </div>
        </div>
    </div>
    <!-- #modal-dialog -->
</asp:Content>

