<%@ Page Title="" Language="C#" MasterPageFile="~/Presentacion/MasterSuperAdministrador.master" AutoEventWireup="true" CodeFile="~/LogicaPresentacion/Administrador/MostrarTablaCliente.aspx.cs" Inherits="Presentacion_MostrarTabla" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <div id="content" class="content">
        <asp:ScriptManager runat="server"></asp:ScriptManager>
        <asp:UpdatePanel runat="server">
        <ContentTemplate>
			<!-- begin breadcrumb -->
			<ol class="breadcrumb pull-right">
				<li><a href="javascript:;">Home</a></li>
				<li><a href="javascript:;" id="clien" runat="server">Cliente</a></li>
				<li class="active" id="see_all" runat="server">Ver todos</li>
			</ol>
			<!-- end breadcrumb -->
			<!-- begin page-header -->
			<h1 class="page-header" id="usr_clien" runat="server">Usuarios - Clientes <small id="our_comp" runat="server">nuestro compromiso es contigo</small></h1>
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
                            <h4 class="panel-title" id="clien2" runat="server">Clientes</h4>
                        </div>
                        <div class="alert alert-success fade in">
                            <button type="button" class="close" data-dismiss="alert">
                                <span aria-hidden="true">&times;</span>
                            </button>
                            <asp:Label runat="server" id="LB_parr" Text="Estos son los clientes registrados actualmente. "></asp:Label>
                            <br />
                            <asp:Label runat="server" id="LB_Wel" Text="Bienvenido Administrador."></asp:Label>
                        </div>
                         <!--    <div>
                          <asp:DropDownList ID="DropDownList1" runat="server" class="btn btn-default dropdown-toggle" AutoPostBack="true"  >
                          <asp:ListItem Value="0">Activos</asp:ListItem>
                          <asp:ListItem Value="1">Inactivos</asp:ListItem>
                          <asp:ListItem Selected="True" Value="2">Todos</asp:ListItem>
                          </asp:DropDownList>
		            	</div>-->
                        <div class="panel-body">
                            <asp:Panel ID="Panel1" runat="server" >
                            <asp:GridView ID="GridView1" runat="server"  class="table table-striped table-bordered nowrap data-table" DataSourceID="ObjectDataSource1" AllowSorting="True" AutoGenerateColumns="False" Width="100%" >
                                <Columns>
                                    <asp:BoundField HeaderText="NOMBRE" DataField="NomUsr" >
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ApelUsr" HeaderText="APELLIDO" />
                                    <asp:BoundField HeaderText="TELEFONO" DataField="TelUsr"/>
                                    <asp:BoundField DataField="CorreoUsr" HeaderText="CORREO" />
                                    <asp:BoundField DataField="CcUsr" HeaderText="C.C" />
                                    <asp:BoundField DataField="DirUsr" HeaderText="DIRECCION"/>
                                    <asp:TemplateField HeaderText="CALIFICACION">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Calificacion2") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <span class="badge badge-inverse">
                                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("Calificacion2") %>' ></asp:Label>
                                            </span>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Crea_Usr" HeaderText="CREACION" />
                                </Columns>
                                <RowStyle CssClass="sorting_1" />
                            </asp:GridView>
                                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="MostrarClientes" TypeName="Logica.L_Componentes">
                                   <%--<SelectParameters>
                                        <asp:ControlParameter ControlID="DropDownList1" DefaultValue="2" Name="idBusqueda" PropertyName="SelectedValue" Type="Int32" />
                                    </SelectParameters>--%>
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
		<!-- end #content -->
</asp:Content>

