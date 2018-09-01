<%@ Page Title="" Language="C#" MasterPageFile="~/Presentacion/MasterSuperAdministrador.master" AutoEventWireup="true" CodeFile="~/LogicaPresentacion/Administrador/MostrarTablaEmpresa.aspx.cs" Inherits="Presentacion_MostrarTablaEmpresa" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div id="content" class="content">
            <asp:ScriptManager runat="server"></asp:ScriptManager>
            <asp:UpdatePanel runat="server">
            <ContentTemplate>
			<!-- begin breadcrumb -->
			<ol class="breadcrumb pull-right">
				<li><a href="javascript:;">Home</a></li>
				<li><a href="javascript:;">Empresa</a></li>
				<li class="active">Ver todas</li>
			</ol>
			<!-- end breadcrumb -->
			<!-- begin page-header -->
			<h1 class="page-header">Usuarios - Empresas <small> nuestro compromiso es contigo</small></h1>
			<!-- end page-header -->
			
			<!-- begin row -->
			<div class="row" >
               
                                    
			    <!-- begin col-2 -->
			    <!-- end col-2 -->
			    <!-- begin col-10 -->
			    <div class="col-md-12" >
			        <!-- begin panel -->
                    <div class="panel panel-inverse">
                        <div class="panel-heading">
                            <div class="panel-heading-btn">
                                <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-default" data-click="panel-expand"><i class="fa fa-expand"></i></a>
                                <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-success" data-click="panel-reload"><i class="fa fa-repeat"></i></a>
                                <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-warning" data-click="panel-collapse"><i class="fa fa-minus"></i></a>
                                <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-danger" data-click="panel-remove"><i class="fa fa-times"></i></a>
                            </div>
                            <h4 class="panel-title">Empresas</h4>
                        </div>
                        <div class="alert alert-success fade in">
                            <button type="button" class="close" data-dismiss="alert">
                                <span aria-hidden="true">&times;</span>
                            </button>
                            Estas son las empresas registrados actualmente. <br />
                            Bienvenido Administrador.
                        </div>
                     <!--   <div>
                          <asp:DropDownList ID="DropDownList1" runat="server" class="btn btn-default dropdown-toggle" AutoPostBack="True" >
                          <asp:ListItem Value="0">Activas</asp:ListItem>
                          <asp:ListItem Value="1">Inactivas</asp:ListItem>
                          <asp:ListItem Selected="True" Value="2">Todas</asp:ListItem>
                          </asp:DropDownList>
                          
			            </div> -->
                        <div class="panel-body">
                            <asp:Panel ID="Panel1" runat="server" >
                            <asp:GridView ID="GridView1" runat="server" class="table table-striped table-bordered nowrap data-table" DataSourceID="ObjectDataSource1" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="nomEmpresa,calificacionEmpresa,nitEmpresa" Width="100%">
                                
                                <Columns>
                                    <asp:BoundField DataField="nomEmpresa" HeaderText="NOMBRE" />
                                    <asp:BoundField DataField="telEmpresa" HeaderText="TELEFONO" />
                                    <asp:BoundField DataField="correoEmpresa" HeaderText="CORREO" />
                                    <asp:BoundField DataField="dirEmpresa" HeaderText="DIRECCION" />
                                    <asp:BoundField DataField="nitEmpresa" HeaderText="NIT" />
                                    <asp:TemplateField HeaderText="CALIFICACION">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("calificacionEmpresa") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <span class="badge badge-primary">
                                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("calificacionEmpresa") %>'></asp:Label>
                                            </span>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="nomMembresia" HeaderText="MEMBRESIA" />
                                </Columns>
                               <RowStyle CssClass="sorting_1" />
                            </asp:GridView>
                                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="MostrarEmpresas" TypeName="DAOadministrador">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="DropDownList1" DefaultValue="2" Name="idBusqueda" PropertyName="SelectedValue" Type="Int32" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                           </asp:Panel>
                        </div>
                    </div>
                    <!-- end panel -->
                </div>
                <!-- end col-10 -->
           
           </div> <!-- end row -->
          </ContentTemplate>
         </asp:UpdatePanel>
		</div>
    
   <!-- ================== BEGIN PAGE LEVEL JS ================== -->
    <script src="http://code.jquery.com/jquery-2.2.4.min.js"   integrity="sha256-BbhdlvQf/xTY9gja0Dq3HiwQF8LaCRTXxZKRutelT44="   crossorigin="anonymous"></script>
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

