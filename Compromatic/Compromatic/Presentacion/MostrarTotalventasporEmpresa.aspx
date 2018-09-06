<%@ Page Title="" Language="C#" MasterPageFile="~/Presentacion/MasterSuperAdministrador.master" AutoEventWireup="true" CodeFile="~/LogicaPresentacion/Administrador/MostrarTotalventasporEmpresa.aspx.cs" Inherits="Presentacion_MostrarTotalventasporEmpresa" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <div id="content" class="content">
            <asp:ScriptManager runat="server"></asp:ScriptManager>
            <asp:UpdatePanel runat="server">
            <ContentTemplate>
			<!-- begin breadcrumb -->
			<ol class="breadcrumb pull-right">
				<li><a href="javascript:;">Home</a></li>
				<li><a href="javascript:;">Empresa</a></li>
				<li class="active">Total Ventas</li>
			</ol>
			<!-- end breadcrumb -->
			<!-- begin page-header -->
			<h1 class="page-header">Ventas totales por empresa <small> nuestro compromiso es contigo</small></h1>
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
                            <h4 class="panel-title">Ventas</h4>
                        </div>
                        <div class="alert alert-success fade in">
                            <button type="button" class="close" data-dismiss="alert">
                                <span aria-hidden="true">&times;</span>
                            </button>
                            Estas son las ventas totales de cada empresa registrada<br />
                            Bienvenido Administrador.
                        </div>
                        <div class="panel-body">
                            <asp:Panel ID="Panel1" runat="server" >
                            <asp:GridView ID="GridView1" runat="server" class="table table-striped table-bordered nowrap data-table" DataSourceID="ObjectDataSource1" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="nomEmpresa,calificacionEmpresa,nitEmpresa" Width="100%" >

                                <Columns>
                                    <asp:TemplateField>
                                        <EditItemTemplate>
                                            <asp:TextBox runat="server" ID="TextBox2"></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                           
					                          	<a  class="dropdown navbar-user">
                                                  	<asp:Image ID="FotoPerfil" runat="server" class="media-object" ImageUrl='<%# Eval("rutaArchivo") %>' Width="45px" Height="35px" /> 
						                        </a>
                                            
                                        </ItemTemplate>
                                        <ControlStyle BorderColor="White" BorderStyle="None" BackColor="White" BorderWidth="0px"></ControlStyle>

                                        <FooterStyle BorderColor="White" BackColor="White" BorderStyle="None" BorderWidth="0px"></FooterStyle>

                                        <HeaderStyle BorderColor="White" BackColor="White" BorderStyle="None" BorderWidth="0px"></HeaderStyle>
                                        <ItemStyle BorderColor="White" BorderStyle="None" BackColor="White" BorderWidth="0px"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="nitEmpresa" HeaderText="NIT"></asp:BoundField>
                                    <asp:BoundField DataField="nomEmpresa" HeaderText="NOMBRE"></asp:BoundField>
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
                                    <asp:BoundField DataField="valor" HeaderText="VALOR VENTAS"></asp:BoundField>
                                    <asp:BoundField DataField="ventas" HeaderText="TOTAL VENTAS"></asp:BoundField>
                                </Columns>

                                <RowStyle CssClass="sorting_1" />
                            </asp:GridView>

                                <asp:ObjectDataSource runat="server" ID="ObjectDataSource1" SelectMethod="MostrarVentasPorEmpresa" TypeName="Logica.L_Componentes"></asp:ObjectDataSource>
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

