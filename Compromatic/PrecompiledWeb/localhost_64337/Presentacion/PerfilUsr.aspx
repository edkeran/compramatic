<%@ page title="" language="C#" masterpagefile="~/Presentacion/MasterDashBoardUsr.master" autoeventwireup="true" inherits="Presentacion_PerfilUsr, App_Web_4kwpqrqr" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <!-- begin #content -->
		<div id="content" class="content">
			<!-- begin breadcrumb -->
			
			<!-- end breadcrumb -->
			<!-- begin page-header -->
			<h1 class="page-header" id="perf_client" runat="server">Perfil de cliente</h1>
  			<!-- end page-header -->
            <small id="inf_client" runat="server" style="font-weight:300;font-size:120%;">Información del perfil</small>
			
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
                                            <td class="field" id="nomb_usr" runat="server">Nombres:</td>
                                            <td><asp:label ID="LB_Nombre" runat="server" CssClass="control-label"></asp:label></td>
                                        </tr>
                                        <tr>
                                            <td class="field" id="apell_usr" runat="server">Apellidos:</td>
                                            <td><asp:label ID="LB_Apellidos" runat="server" CssClass="control-label"></asp:label></td>
                                        </tr>
                                       <tr>
                                            <td class="field" id="num_id" runat="server">Númerdo de identidad:</td>
                                            <td><asp:label ID="LB_Cc" runat="server" CssClass="control-label"></asp:label></td>
                                        </tr>
                                        <tr class="divider">
                                            <td colspan="2"></td>
                                        </tr>
                                        <tr>
                                            <td class="field" id="num_tel" runat="server">Número telefónico</td>
                                            <td><asp:label ID="LB_Telefono" runat="server" CssClass="control-label"></asp:label>    <i class="fa fa-phone"></i></td>
                                        </tr>
                                        <tr>
                                            <td class="field" id="dir_usr" runat="server">Dirección</td>
                                            <td><asp:label ID="LB_Direccion" runat="server" CssClass="control-label"></asp:label>   <i class="fa fa-map-marker"></i></td>
                                        </tr>
                                        <tr>
                                            <td class="field" id="email_usr" runat="server">Correo electrónico</td>
                                            <td><asp:label ID="LB_Correo" runat="server" CssClass="control-label"> </asp:label> <i class="fa fa-envelope"></i></td>
                                        </tr>
                                          
                                        <tr class="divider">
                                            <td colspan="2"></td>
                                        </tr>
                                        <tr class="highlight">
                                            <td class="field" id="cal_usr"  runat="server">Calificación general</td>
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

