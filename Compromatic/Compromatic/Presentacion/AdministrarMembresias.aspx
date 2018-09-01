<%@ Page Title="" Language="C#" MasterPageFile="~/Presentacion/MasterSuperAdministrador.master" AutoEventWireup="true" CodeFile="~/LogicaPresentacion/Administrador/AdministrarMembresias.aspx.cs" Inherits="Presentacion_AdministrarMembresias" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="content" class="content">
        <ol class="breadcrumb pull-right">
            <li><a href="javascript:;">Home</a></li>
            <li><a href="javascript:;">Administrar</a></li>
            <li class="active">Memebresias</li>
        </ol>
        <h1 class="page-header">Membresias <small>nuestro compromiso es contigo</small></h1>
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
                                <h4 class="panel-title">Todas las Membresias</h4>
                            </div>
                            <div class="panel-body">
                                <asp:Panel ID="Panel2" runat="server">
                                    <asp:GridView ID="GridView2" runat="server" BorderStyle="None" class="table table-hover" DataKeyNames="nomMembresia" OnSelectedIndexChanged="GridView2_SelectedIndexChanged" AutoGenerateColumns="False" Width="100%" DataSourceID="ObjectDataSource1">
                                        <Columns>
                                            <asp:BoundField DataField="nomMembresia" HeaderText="NOMBRE "></asp:BoundField>
                                            <asp:BoundField DataField="tiempo" HeaderText="DURACION"></asp:BoundField>
                                            <asp:BoundField DataField="valor" HeaderText="COSTO"></asp:BoundField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:Button ID="Select" runat="server" class="btn btn-danger btn-xs" Text="modificar" CommandName="Select" />
                                                </ItemTemplate>
                                                <HeaderStyle BorderColor="White" BorderWidth="0px" BorderStyle="None"></HeaderStyle>

                                                <ItemStyle BorderColor="White" BorderWidth="0px" BorderStyle="None"></ItemStyle>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                    <asp:ObjectDataSource runat="server" ID="ObjectDataSource1" SelectMethod="Membresia" TypeName="DAOadministrador"></asp:ObjectDataSource>
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
                                <h4 class="panel-title">Regitrar nueva Membresia</h4>
                            </div>
                            <div class="panel-body bg-orange text-white">
                                <asp:Panel ID="Panel3" runat="server">
                                    <div class="form-horizontal">
                                        <div class="form-group">
                                            <asp:Label ID="Label1" class="col-md-3 control-label" runat="server" Text="Nombre Membresia"></asp:Label>
                                            <div class="col-md-9">
                                                <asp:TextBox ID="NombreMembresia" class="form-control" runat="server" placeHolder="Nombre Categoria" MaxLength="20"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ForeColor="Red" ControlToValidate="NombreMembresia" runat="server" ErrorMessage="Error campo vacio" ValidationGroup="Membresia"></asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ForeColor="Red" ControlToValidate="NombreMembresia" ErrorMessage="Error, caracteres" ToolTip="La cadena contiene caracteres no validos" ValidationExpression="^[a-zA-Z ñÑáéíóú]*$" ValidationGroup="Membresia"></asp:RegularExpressionValidator>
                                                <asp:CustomValidator ID="CustomValidator2" runat="server" ControlToValidate="NombreMembresia" ForeColor="Red" ErrorMessage="Ya existe" ToolTip="El nombre de la Membresia ya existe" OnServerValidate="CustomValidator2_ServerValidate" ValidationGroup="Membresia"></asp:CustomValidator>
                                                <asp:CustomValidator ID="CustomValidator1" runat="server" ControlToValidate="NombreMembresia" ForeColor="Red" ErrorMessage="Ya existe" ToolTip="El nombre de la Membresia ya existe" OnServerValidate="CustomValidator1_ServerValidate" ValidationGroup="Modificar"></asp:CustomValidator>

                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <asp:Label ID="Label2" class="col-md-3 control-label" runat="server" Text="Duracion"></asp:Label>
                                            <div class="col-md-9">
                                                <asp:TextBox runat="server" ID="TB_Tiempo" TextMode="Number" placeHolder="Meses de la suscripcion" max="24" min="0" CssClass="form-control"></asp:TextBox>
                                                <asp:RequiredFieldValidator runat="server" ErrorMessage="Campo Necesario" ForeColor="Red" ControlToValidate="TB_Tiempo" ValidationGroup="Membresia"></asp:RequiredFieldValidator>
                                                <asp:RequiredFieldValidator runat="server" ErrorMessage="Campo Necesario" ForeColor="Red" ControlToValidate="TB_Tiempo" ValidationGroup="Modificar"></asp:RequiredFieldValidator>

                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <asp:Label ID="Label3" class="col-md-3 control-label" runat="server" Text="Valor"></asp:Label>
                                            <div class="col-md-9">
                                                <asp:TextBox runat="server" ID="TB_Valor" TextMode="Number" max="9999999" min="0" placeHolder="Valor de la suscripcion" CssClass="form-control"></asp:TextBox>
                                                <asp:RequiredFieldValidator runat="server" ErrorMessage="Campo Necesario" ForeColor="Red" ControlToValidate="TB_Valor" ValidationGroup="Membresia"></asp:RequiredFieldValidator>
                                                <asp:RequiredFieldValidator runat="server" ErrorMessage="Campo Necesario" ForeColor="Red" ControlToValidate="TB_Valor" ValidationGroup="Modificar"></asp:RequiredFieldValidator>

                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <div class="col-md-9">
                                                <asp:Button ID="Button1" runat="server" Visible="true" class="btn btn-sm btn-success" Text="Registrar Membresia" OnClick="Button1_Click" ValidationGroup="Membresia" />
                                                <asp:Button ID="Button2" runat="server" Visible="false" class="btn btn-sm btn-success" Text="Modificar Membresia" OnClick="Button2_Click" ValidationGroup="Modificar" />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ForeColor="Red" ControlToValidate="NombreMembresia" runat="server" ErrorMessage="Error nombre vacio" ValidationGroup="Modificar"></asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ForeColor="Red" ControlToValidate="NombreMembresia" ErrorMessage="Error, caracteres" ToolTip="La cadena contiene caracteres no validos" ValidationExpression="^[a-zA-Z ñÑáéíóú]*$" ValidationGroup="Modificar"></asp:RegularExpressionValidator>

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

