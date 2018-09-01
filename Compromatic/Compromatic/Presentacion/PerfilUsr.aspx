<%@ Page Title="" Language="C#" MasterPageFile="~/Presentacion/MasterDashBoardUsr.master" AutoEventWireup="true" CodeFile="~/LogicaPresentacion/PerfilUsr.aspx.cs" Inherits="Presentacion_PerfilUsr" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <!-- begin #content -->
		<div id="content" class="content">
			<!-- begin breadcrumb -->
			
			<!-- end breadcrumb -->
			<!-- begin page-header -->
			<h1 class="page-header">Perfil de cliente 
                <br />
                <small>Información del perfil</small></h1>
			<!-- end page-header -->
			
		</div>
		<!-- end #content -->
		
    <!-- begin profile-container -->
            <div class="profile-container">
                <!-- begin profile-section -->
                <div class="profile-section">
                    <!-- begin profile-left -->
                    <div class="profile-left">
                        <!-- begin profile-image -->
                        
                        <div class="profile-image">
                            <asp:Image runat="server" ID="IMG_FotoPerfil"/>
                            <i class="fa fa-user hide"></i>
                        </div>
                        <!-- end profile-image 
                        <
                       begin profile-highlight -->
                        
                        <!-- end profile-highlight -->
                    </div>
                    <!-- end profile-left -->
                    <!-- begin profile-right -->
                    <div class="profile-right">
                        <!-- begin profile-info -->
                        <div class="profile-info">
                            <!-- begin table -->
                            <div class="table-responsive">
                                <table class="table table-profile">
                                   <tbody>
                                        <tr>
                                            <td class="field">Nombres:</td>
                                            <td><asp:label ID="LB_Nombre" runat="server" CssClass="control-label"></asp:label></td>
                                        </tr>
                                        <tr>
                                            <td class="field">Apellidos:</td>
                                            <td><asp:label ID="LB_Apellidos" runat="server" CssClass="control-label"></asp:label></td>
                                        </tr>
                                       <tr>
                                            <td class="field">Númerdo de identidad:</td>
                                            <td><asp:label ID="LB_Cc" runat="server" CssClass="control-label"></asp:label></td>
                                        </tr>
                                        <tr class="divider">
                                            <td colspan="2"></td>
                                        </tr>
                                        <tr>
                                            <td class="field">Número telefónico</td>
                                            <td><asp:label ID="LB_Telefono" runat="server" CssClass="control-label"></asp:label>    <i class="fa fa-phone"></i></td>
                                        </tr>
                                        <tr>
                                            <td class="field">Dirección</td>
                                            <td><asp:label ID="LB_Direccion" runat="server" CssClass="control-label"></asp:label>   <i class="fa fa-map-marker"></i></td>
                                        </tr>
                                        <tr>
                                            <td class="field">Correo electrónico</td>
                                            <td><asp:label ID="LB_Correo" runat="server" CssClass="control-label"> </asp:label> <i class="fa fa-envelope"></i></td>
                                        </tr>
                                          
                                        <tr class="divider">
                                            <td colspan="2"></td>
                                        </tr>
                                        <tr class="highlight">
                                            <td class="field">Calificación general</td>
                                            <td><asp:label ID="LB_Calificacion" runat="server" CssClass="control-label"></asp:label></td>
                                        </tr>
                                        <tr class="divider">
                                            <td colspan="2"></td>
                                        </tr>
                                        
                                    </tbody>
                                </table>
                            </div>
                            <!-- end table -->
                        </div>
                        <!-- end profile-info -->
                    </div>
                    <!-- end profile-right -->
                </div>
                <!-- end profile-section -->
                <!-- begin profile-section -->
                
                <!-- end profile-section -->
            </div>
			<!-- end profile-container -->
</asp:Content>

