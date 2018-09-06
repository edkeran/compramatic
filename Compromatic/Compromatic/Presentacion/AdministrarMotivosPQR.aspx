<%@ Page Title="" Language="C#" MasterPageFile="~/Presentacion/MasterSuperAdministrador.master" AutoEventWireup="true" CodeFile="~/LogicaPresentacion/Administrador/AdministrarMotivosPQR.aspx.cs" Inherits="Presentacion_AdministrarMotivosPQR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="content" class="content">
        <ol class="breadcrumb pull-right">
            <li><a href="javascript:;">Home</a></li>
            <li><a href="javascript:;">Administrar</a></li>
            <li class="active">Motivos</li>
        </ol>
        <h1 class="page-header">Motivos PQR <small>nuestro compromiso es contigo</small></h1>
        <div class="row">
            <asp:ScriptManager runat="server"></asp:ScriptManager>
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <div class="col-md-6 ui-sortable">
                        <div class="panel panel-danger">
                            <div class="panel-heading">
                                <div class="panel-heading-btn">
                                    <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-default" data-click="panel-expand"><i class="fa fa-expand"></i></a>
                                    <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-success" data-click="panel-reload"><i class="fa fa-repeat"></i></a>
                                    <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-warning" data-click="panel-collapse"><i class="fa fa-minus"></i></a>
                                    <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-danger" data-click="panel-remove"><i class="fa fa-times"></i></a>
                                </div>
                                <h4 class="panel-title">Regitrar nuevo motivo para queja</h4>
                            </div>
                            <div class="panel-body bg-red text-white">
                                <asp:Panel ID="Panel3" runat="server">
                                    <div class="form-horizontal">
                                        <div class="form-group">
                                            <asp:Label ID="Label1" class="col-md-3 control-label" runat="server" Text="Nombre Queja"></asp:Label>
                                            <div class="col-md-9">
                                                <asp:TextBox ID="NombreQueja" class="form-control" runat="server" placeHolder="Nombre del motivo" MaxLength="20"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ForeColor="Yellow" ControlToValidate="NombreQueja" runat="server" ErrorMessage="Error campo vacio" ValidationGroup="Queja"></asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ForeColor="Yellow" ControlToValidate="NombreQueja" ErrorMessage="Error, caracteres" ToolTip="La cadena contiene caracteres no validos" ValidationExpression="^[a-zA-Z ñÑáéíóú]*$" ValidationGroup="Queja"></asp:RegularExpressionValidator>
                                                <asp:CustomValidator ID="CustomValidator2" runat="server" ControlToValidate="NombreQueja" ForeColor="Yellow" ErrorMessage="Ya existe" ToolTip="El nombre de la Membresia ya existe" OnServerValidate="CustomValidator2_ServerValidate" ValidationGroup="Queja"></asp:CustomValidator>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <div class="col-md-9">
                                                <asp:Button ID="B_RegistrarMQueja" runat="server" class="btn btn-sm btn-success" Text="Registrar Motivo" OnClick="B_RegistrarMQueja_Click" ValidationGroup="Queja" />
                                                <asp:Button ID="Button2" runat="server" Visible="false" class="btn btn-sm btn-success" Text="Modificar Motivo" OnClick="Button2_Click" ValidationGroup="Queja" />
                                                <asp:Label ID="NomQueja" runat="server" Visible="false"></asp:Label>

                                            </div>
                                        </div>
                                    </div>

                                </asp:Panel>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6 ui-sortable">
                        <div class="panel panel-inverse">
                            <div class="panel-heading">
                                <div class="panel-heading-btn">
                                    <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-default" data-click="panel-expand"><i class="fa fa-expand"></i></a>
                                    <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-success" data-click="panel-reload"><i class="fa fa-repeat"></i></a>
                                    <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-warning" data-click="panel-collapse"><i class="fa fa-minus"></i></a>
                                    <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-danger" data-click="panel-remove"><i class="fa fa-times"></i></a>
                                </div>
                                <h4 class="panel-title">Regitrar nuevo motivo para reporte</h4>
                            </div>
                            <div class="panel-body bg-black text-white">
                                <asp:Panel ID="Panel4" runat="server">
                                    <div class="form-horizontal">
                                        <div class="form-group">
                                            <asp:Label ID="Label2" class="col-md-3 control-label" runat="server" Text="Nombre Reporte"></asp:Label>
                                            <div class="col-md-9">
                                                <asp:TextBox ID="NombreReporte" class="form-control" runat="server" placeHolder="Nombre del motivo" MaxLength="20"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ForeColor="Yellow" ControlToValidate="NombreReporte" runat="server" ErrorMessage="Error campo vacio" ValidationGroup="Reporte"></asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ForeColor="Yellow" ControlToValidate="NombreReporte" ErrorMessage="Error, caracteres" ToolTip="La cadena contiene caracteres no validos" ValidationExpression="^[a-zA-Z ñÑáéíóú]*$" ValidationGroup="Reporte"></asp:RegularExpressionValidator>
                                                <asp:CustomValidator ID="CustomValidator1" runat="server" ControlToValidate="NombreReporte" ForeColor="Yellow" ErrorMessage="Ya existe" ToolTip="El nombre de la Membresia ya existe" OnServerValidate="CustomValidator1_ServerValidate" ValidationGroup="Reporte"></asp:CustomValidator>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <div class="col-md-9">
                                                <asp:Button ID="B_RegistrarMReporte" runat="server" class="btn btn-sm btn-success" Text="Registrar Motivo" OnClick="B_RegistrarMReporte_Click" ValidationGroup="Reporte" />
                                                <asp:Button ID="Button1" runat="server" Visible="false" class="btn btn-sm btn-success" Text="Modificar Motivo" OnClick="Button1_Click" ValidationGroup="Reporte" />

                                                <asp:Label ID="nomReporte" runat="server" Visible="false"></asp:Label>

                                            </div>
                                        </div>
                                    </div>

                                </asp:Panel>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6 ui-sortable">
                        <div class="panel panel-danger">
                            <div class="panel-heading">
                                <div class="panel-heading-btn">
                                    <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-default" data-click="panel-expand"><i class="fa fa-expand"></i></a>
                                    <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-success" data-click="panel-reload"><i class="fa fa-repeat"></i></a>
                                    <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-warning" data-click="panel-collapse"><i class="fa fa-minus"></i></a>
                                    <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-danger" data-click="panel-remove"><i class="fa fa-times"></i></a>
                                </div>
                                <h4 class="panel-title">Motivos para quejas</h4>
                            </div>
                            <div class="panel-body">
                                <asp:Panel ID="Panel2" runat="server">
                                    <asp:GridView ID="GridView2" runat="server" BorderStyle="None" DataKeyNames="idMotivo_queja" OnSelectedIndexChanged="GridView2_SelectedIndexChanged" class="table table-hover" AutoGenerateColumns="False" Width="100%" DataSourceID="ObjectDataSource1">
                                        <Columns>
                                            <asp:BoundField DataField="idMotivo_queja" HeaderText="ID"></asp:BoundField>
                                            <asp:BoundField DataField="nomQueja" HeaderText="NOMBRE"></asp:BoundField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:Button ID="Select" runat="server" class="btn btn-danger btn-xs" Text="modificar" CommandName="Select" />
                                                </ItemTemplate>
                                                <HeaderStyle BorderColor="White" BorderWidth="0px" BorderStyle="None"></HeaderStyle>

                                                <ItemStyle BorderColor="White" BorderWidth="0px" BorderStyle="None"></ItemStyle>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                    <asp:ObjectDataSource runat="server" ID="ObjectDataSource1" SelectMethod="MostrarMotivos" TypeName="Logica.L_Componentes"></asp:ObjectDataSource>
                                </asp:Panel>
                            </div>
                        </div>
                    </div>

                    <div class="col-md-6 ui-sortable">
                        <div class="panel panel-inverse">
                            <div class="panel-heading">
                                <div class="panel-heading-btn">
                                    <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-default" data-click="panel-expand"><i class="fa fa-expand"></i></a>
                                    <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-success" data-click="panel-reload"><i class="fa fa-repeat"></i></a>
                                    <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-warning" data-click="panel-collapse"><i class="fa fa-minus"></i></a>
                                    <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-danger" data-click="panel-remove"><i class="fa fa-times"></i></a>
                                </div>
                                <h4 class="panel-title">Motivos para reporte</h4>
                            </div>
                            <div class="panel-body">
                                <asp:Panel ID="Panel1" runat="server">
                                    <asp:GridView ID="GridView1" runat="server" BorderStyle="None" DataKeyNames="idMotivoR" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" class="table table-hover" AutoGenerateColumns="False" Width="100%" DataSourceID="ObjectDataSource2">
                                        <Columns>
                                            <asp:BoundField DataField="idMotivoR" HeaderText="ID"></asp:BoundField>
                                            <asp:BoundField DataField="desMotivo" HeaderText="NOMBRE"></asp:BoundField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:Button ID="Select" runat="server" class="btn btn-danger btn-xs" Text="modificar" CommandName="Select" />
                                                </ItemTemplate>
                                                <HeaderStyle BorderColor="White" BorderWidth="0px" BorderStyle="None"></HeaderStyle>

                                                <ItemStyle BorderColor="White" BorderWidth="0px" BorderStyle="None"></ItemStyle>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                    <asp:ObjectDataSource runat="server" ID="ObjectDataSource2" SelectMethod="MostrarMotivosReporte" TypeName="Logica.L_Componentes"></asp:ObjectDataSource>
                                </asp:Panel>
                            </div>
                        </div>
                    </div>


                </ContentTemplate>
            </asp:UpdatePanel>
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

