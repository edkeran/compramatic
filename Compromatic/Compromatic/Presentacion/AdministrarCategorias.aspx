<%@ Page Title="" Language="C#" MasterPageFile="~/Presentacion/MasterSuperAdministrador.master" AutoEventWireup="true" CodeFile="~/LogicaPresentacion/Administrador/AdministrarCategorias.aspx.cs" Inherits="Presentacion_AdministrarCategorias" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="content" class="content">

        <ol class="breadcrumb pull-right">
            <li><a href="javascript:;">Home</a></li>
            <li><a href="javascript:;">Administrar</a></li>
            <li class="active">Categorias</li>
        </ol>
        <h1 class="page-header">Categorias <small>nuestro compromiso es contigo</small></h1>
        <div class="row">
            <asp:ScriptManager runat="server"></asp:ScriptManager>
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <div class="col-md-6 ui-sortable">
                        <div class="panel panel-inverse">
                            <div class="panel-heading">
                                <div class="panel-heading-btn">
                                    <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-default" data-click="panel-expand"><i class="fa fa-expand"></i></a>
                                    <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-success" data-click="panel-reload"><i class="fa fa-repeat"></i></a>
                                    <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-warning" data-click="panel-collapse"><i class="fa fa-minus"></i></a>
                                    <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-danger" data-click="panel-remove"><i class="fa fa-times"></i></a>
                                </div>
                                <h4 class="panel-title">Todas las categorias</h4>
                            </div>
                            <div class="panel-body">
                                <asp:Panel ID="Panel2" runat="server">
                                    <asp:GridView ID="GridView2" runat="server" DataKeyNames="nomCategoria" OnSelectedIndexChanged="GridView2_SelectedIndexChanged" class="table table-hover" AutoGenerateColumns="False" Width="100%" BorderStyle="None" DataSourceID="ObjectDataSource2">
                                        <Columns>
                                            <asp:BoundField DataField="idCategoria" HeaderText="ID"></asp:BoundField>
                                            <asp:BoundField DataField="nomCategoria" HeaderText="NOMBRE "></asp:BoundField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:Button ID="Select" runat="server" class="btn btn-danger btn-xs" Text="modificar" CommandName="Select" />
                                                </ItemTemplate>
                                                <HeaderStyle BorderColor="White" BorderWidth="0px" BorderStyle="None"></HeaderStyle>

                                                <ItemStyle BorderColor="White" BorderWidth="0px" BorderStyle="None"></ItemStyle>
                                            </asp:TemplateField>

                                        </Columns>
                                    </asp:GridView>
                                    <asp:ObjectDataSource runat="server" ID="ObjectDataSource2" SelectMethod="MostrarCategorias" TypeName="DAOadministrador"></asp:ObjectDataSource>
                                </asp:Panel>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6 ui-sortable">
                        <div class="panel panel-warning">
                            <div class="panel-heading">
                                <div class="panel-heading-btn">
                                    <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-default" data-click="panel-expand"><i class="fa fa-expand"></i></a>
                                    <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-success" data-click="panel-reload"><i class="fa fa-repeat"></i></a>
                                    <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-warning" data-click="panel-collapse"><i class="fa fa-minus"></i></a>
                                    <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-danger" data-click="panel-remove"><i class="fa fa-times"></i></a>
                                </div>
                                <h4 class="panel-title">Regitrar nueva categoria</h4>
                            </div>
                            <div class="panel-body bg-orange text-white">
                                <asp:Panel ID="Panel3" runat="server">
                                    <div class="form-horizontal">
                                        <div class="form-group">
                                            <asp:Label ID="Label1" class="col-md-3 control-label" runat="server" Text="Nombre Categ."></asp:Label>
                                            <div class="col-md-9">
                                                <asp:TextBox ID="NombreCategoria" class="form-control" runat="server" placeHolder="Nombre Categoria" MaxLength="20"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ForeColor="Red" ControlToValidate="NombreCategoria" runat="server" ErrorMessage="Error campo vacio" ValidationGroup="Categoria"></asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ForeColor="Red" ControlToValidate="NombreCategoria" ErrorMessage="Error, caracteres" ToolTip="La cadena contiene caracteres no validos" ValidationExpression="^[a-zA-Z ñÑáéíóú]*$" ValidationGroup="Categoria"></asp:RegularExpressionValidator>
                                                <asp:CustomValidator ID="CustomValidator1" runat="server" ControlToValidate="NombreCategoria" ForeColor="Red" ErrorMessage="Error, tamaño" ToolTip="Cadena fuera del rango de 20 caracteres" OnServerValidate="CustomValidator1_ServerValidate" ValidationGroup="Categoria"></asp:CustomValidator>
                                                <asp:CustomValidator ID="CustomValidator2" runat="server" ControlToValidate="NombreCategoria" ForeColor="Red" ErrorMessage="Ya existe" ToolTip="El nombre de la categoria ya existe" OnServerValidate="CustomValidator2_ServerValidate" ValidationGroup="Categoria"></asp:CustomValidator>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <div class="col-md-9">
                                                <asp:Button ID="Button1" runat="server" class="btn btn-sm btn-success" Text="Registrar categoria" OnClick="Button1_Click" ValidationGroup="Categoria" />
                                                <asp:Button ID="Button2" runat="server" Visible="false"  class="btn btn-sm btn-success" Text="Modificar categoria" OnClick="Button2_Click" ValidationGroup="Categoria" />
                                                <asp:Label ID="Label5" runat="server" Visible="false"></asp:Label>
                                            </div>
                                        </div>
                                    </div>

                                </asp:Panel>
                            </div>
                        </div>
                    </div>


                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <div class="row">
            <div class="col-md-12">
                <div class="panel panel-inverse">
                    <div class="panel-heading">
                        <div class="panel-heading-btn">
                            <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-default" data-click="panel-expand"><i class="fa fa-expand"></i></a>
                            <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-success" data-click="panel-reload"><i class="fa fa-repeat"></i></a>
                            <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-warning" data-click="panel-collapse"><i class="fa fa-minus"></i></a>
                            <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-danger" data-click="panel-remove"><i class="fa fa-times"></i></a>
                        </div>
                        <h4 class="panel-title">Ventas por categoria</h4>
                    </div>
                    <div class="panel-body">
                        <asp:Panel ID="Panel1" runat="server">
                            <asp:GridView ID="GridView1" runat="server" class="table table-striped table-bordered nowrap data-table" DataSourceID="ObjectDataSource1" AutoGenerateColumns="False" Width="100%">
                                <Columns>
                                    <asp:BoundField DataField="nomCategoria" HeaderText="NOMBRE"></asp:BoundField>
                                    <asp:TemplateField HeaderText="N. EMPRESAS">
                                        <ItemTemplate>
                                            <span class="badge badge-primary">
                                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("empresas") %>'></asp:Label>
                                            </span>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="N. VENTAS">
                                        <ItemTemplate>
                                            <span class="badge badge-info">
                                                <asp:Label ID="Label3" runat="server" Text='<%# Bind("ventas") %>'></asp:Label>
                                            </span>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="TOTAL VENDIDO">
                                        <ItemTemplate>
                                            <span class="badge badge-inverse  m-b-10">
                                                <asp:Label ID="Label4" runat="server" Text='<%# Bind("valor") %>'></asp:Label>
                                            </span>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                </Columns>
                            </asp:GridView>
                            <asp:ObjectDataSource runat="server" ID="ObjectDataSource1" SelectMethod="MostrarVentasPorCategoria" TypeName="DAOadministrador"></asp:ObjectDataSource>
                        </asp:Panel>
                    </div>
                </div>
            </div>
        </div>

    </div>
    <!-- ================== BEGIN PAGE LEVEL JS ================== -->
    <script src="http://code.jquery.com/jquery-2.2.4.min.js" integrity="sha256-BbhdlvQf/xTY9gja0Dq3HiwQF8LaCRTXxZKRutelT44=" crossorigin="anonymous"></script>
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

    <script>
        $(document).ready(function () {
            var table = $('.data-table').DataTable({
                responsive: true,
            });
        });
    </script>

</asp:Content>

