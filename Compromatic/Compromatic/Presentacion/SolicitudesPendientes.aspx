﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Presentacion/MasterSuperAdministrador.master" AutoEventWireup="true" CodeFile="~/LogicaPresentacion/Administrador/SolicitudesPendientes.aspx.cs" Inherits="Presentacion_SolicitudesPendientes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   
    <div id="content" class="content">
            <ol class="breadcrumb pull-right">
				<li><a href="javascript:;">Home</a></li>
				<li><a href="javascript:;" id="soli" runat="server">Solicitudes</a></li>
				<li class="active" id="pend" runat="server">Pendientes</li>
			</ol>
            <h1 class="page-header" id="sol_pen" runat="server">Solicitudes pendientes<small id="new_opt" runat="server"> nuevas oportunidades de negocio</small></h1>
            <asp:Panel ID="Panel1" runat="server" class="col-md-12">
               <div class="result-container">
                   <asp:GridView ID="GridView1" runat="server" Width="100%" DataKeyNames="idSolicitud_registro" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" onrowcommand="GridView1_RowCommand" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1" BorderStyle="None" OnRowCreated="GridView1_RowCreated">
                       <AlternatingRowStyle BorderStyle="None" />
                       
                      <Columns >
                        
                        <asp:TemplateField>
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                               <ul class="result-list">
                                <li>
                                <div class="result-image">
                                   <a href="javascript:;"><asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("rutaArchivo") %>' alt="" Height="180px" Width="240px" /></a>
                                </div>
                                
                                    <div class="result-info">
                                              <h4 class="title"><a href="javascript:;"><asp:Label ID="Label1" runat="server" Text='<%# Eval("nomEmpresa") %>'></asp:Label></a></h4>
                                              <p class="location"><asp:Label ID="Label3" runat="server" Text="NIT : "></asp:Label><asp:Label ID="Label2" runat="server" Text='<%# Eval("nitEmpresa") %>'></asp:Label></p>
                                              <p class="location"><asp:Label ID="Label4" runat="server" Text="Telefono : "></asp:Label><asp:Label ID="Label5" runat="server" Text='<%# Eval("telEmpresa") %>'></asp:Label></p>
                                              <p class="location"><asp:Label ID="Label7" runat="server" Text="Direccion : "></asp:Label><asp:Label ID="Label8" runat="server" Text='<%# Eval("dirEmpresa") %>'></asp:Label></p>
                                              <p class="desc">
                                                  <asp:Label ID="LB_Parr" runat="server" Text="El administrador debe verificar el origen de los documentos enviados, ademas debe investigar la legalidad e historial que precede a susodicha empresa solicitante."></asp:Label></p>
                                              <div>
                                                  <i class="fa fa-expand fa-2x pull-left fa-fw"></i>
                                                  <asp:Button ID="Button1" runat="server" Text="Descargar" class="btn btn-link m-b-5" CommandName="Select"/>
                                              </div>
                                          </div>
                                
                                    <div class="result-price">
                                              <asp:Label ID="Label6" runat="server" Text='<%# Eval("correoEmpresa") %>'></asp:Label><small><asp:Label ID="corre" runat="server" Text="CORREO"></asp:Label></small>
                                              <a href="javascript:;"><asp:Button ID="BT_Aceptar" runat="server" commandname="aceptar" class="btn btn-inverse m-r-5 m-b-5" Text="Aceptar" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" /> </a>
                                              <a href="javascript:;"><asp:Button ID="BT_Rechazar" runat="server" commandname="rechazar" class="btn btn-danger m-r-5 m-b-5" Text="Rechazar" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" /> </a>
                                    </div>
                                  </li>
                                <li>
                                    
                                </li>
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
              <asp:ObjectDataSource runat="server" ID="ObjectDataSource1" SelectMethod="SolicitudesPendientes" TypeName="Logica.L_Componentes"></asp:ObjectDataSource>
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
							<div class="modal fade" id="modal-dialog" >
								<div class="modal-dialog">
									<div class="modal-content">
										<div class="modal-header">
											<button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
											<h4> <asp:Label ID="Titulo" class="modal-title" runat="server" Text="DOCUMENTOS"></asp:Label></h4>
										</div>
										<div class="modal-body">
                                            <asp:HyperLink ID="HyperLink1" runat="server" class="btn btn-link m-b-5">Documento 1</asp:HyperLink>
                                            <asp:HyperLink ID="HyperLink2" runat="server" class="btn btn-link m-b-5">Documento 2</asp:HyperLink>
                                            <asp:HyperLink ID="HyperLink3" runat="server" class="btn btn-link m-b-5">Documento 3</asp:HyperLink>
										</div>
										<div class="modal-footer">
											<a href="javascript:;" class="btn btn-sm btn-white" data-dismiss="modal">Close</a>
										</div>
									</div>
								</div>
							</div>
    <!-- #modal-dialog -->
	
</asp:Content>

