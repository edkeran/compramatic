<%@ Page Title="" Language="C#" MasterPageFile="~/Presentacion/MasterDashBoardUsr.master" AutoEventWireup="true" CodeFile="~/LogicaPresentacion/ModificarPerfilUsr.aspx.cs" Inherits="Presentacion_ModificarPerfilUsr" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <!-- begin #content -->
		<div id="content" class="content">
			<!-- begin breadcrumb -->
			
			<!-- end breadcrumb -->
			<!-- begin page-header -->
			<h1 class="page-header" id="perf_client" runat="server">Perfil de cliente
               </h1>
             <small id="mod_client"  runat="server" style="font-weight:300;font-size:120%;">Modificar perfil</small>
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
                        <!-- end profile-image -->
                        <div class="m-b-10">
                            <div class="btn-group">
                                    <button type="button" class="btn btn-default dropdown-toggle" data-toggle="dropdown" id="btn_photo" runat="server"></button>
                                    <ul class="dropdown-menu" role="menu">
                                        <li class="dropdown-header" id="load_img"  runat="server">Carga aquí tu foto</li>
                                        <li>
                                            <asp:FileUpload ID="FU_CambiarFoto" runat="server" CssClass="document-file" /></li>
                                        <asp:RequiredFieldValidator runat="server" CssClass="alert-warning" ErrorMessage="Archivo Necesario" ForeColor="Red" ControlToValidate="FU_CambiarFoto" ValidationGroup="CambiarFoto"></asp:RequiredFieldValidator>
                                        <li>
                                            <br />
                                        </li>
                                        <li>
                                        <tr>
                                            <asp:Button ID="BTN_CambiarFoto" runat="server" CssClass="btn btn-warning btn-block btn-sm" Text="Cambiar Foto" OnClick="BTN_CambiarFoto_Click" ValidationGroup="CambiarFoto" />
                                        </tr>
                                        <li>
                                            <br />
                                        </li>
                                        <tr>
                                            <asp:Button ID="BTN_QuitarFoto" runat="server" CssClass="btn btn-warning btn-block btn-sm" Text="Quitar Foto" OnClick="BTN_QuitarFoto_Click" />
                                        </tr>
                                        </li>
                                    </ul>
                             </div>
                        </div>
                        
                        <!-- begin profile-highlight -->
                        
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
                                            <td class="field" id="names_usr"  runat="server">Nombres:</td>
                                            <td><asp:TextBox ID="TB_Nombre" runat="server" CssClass="form-control" MaxLength="20"/></td>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ForeColor="Red" ControlToValidate="TB_Nombre" ErrorMessage="Error, caracteres" ToolTip="La cadena contiene caracteres no validos" ValidationExpression="^[a-zA-Z ñÑ]*$"></asp:RegularExpressionValidator>
                                            <td><asp:label ID="LB_Nombre" runat="server" CssClass="control-label"></asp:label></td>
                                        </tr>
                                        <tr>
                                            <td class="field" id="apell_usr" runat="server">Apellidos:</td>
                                            <td><asp:TextBox ID="TB_Apellido" runat="server" CssClass="form-control" MaxLength="20"/> </td>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ForeColor="Red" ControlToValidate="TB_Apellido" ErrorMessage="Error, caracteres" ToolTip="La cadena contiene caracteres no validos" ValidationExpression="^[a-zA-Z ñÑ]*$"></asp:RegularExpressionValidator>
                                            <td><asp:label ID="LB_Apellido" runat="server" CssClass="control-label"></asp:label></td>
                                        </tr>
                                       <tr>
                                            <td class="field" id="cc_usr" runat="server">Númerdo de identidad:</td>
                                            <td><asp:TextBox ID="TB_Cc" runat="server" CssClass="form-control" TextMode="Number" max="9999999999" /></td>
                                            
                                            <td><asp:label ID="LB_Cc" runat="server" CssClass="control-label"></asp:label></td>
                                        </tr>
                                        <tr class="divider">
                                            <td colspan="2"></td>
                                        </tr>
                                        <tr>
                                            <td class="field" id="tel_usr" runat="server">Número telefónico</td>
                                            <td><asp:TextBox ID="TB_Telefono" runat="server" CssClass="form-control" TextMode="Number" max="9999999999"/> </td>
                                            <td><asp:label ID="LB_Telefono" runat="server" CssClass="control-label"></asp:label>    <i class="fa fa-phone"></i></td>
                                        </tr>
                                        <tr>
                                            <td class="field" id="dir_usr" runat="server">Dirección</td>
                                            <td><asp:TextBox ID="TB_Direccion" runat="server" CssClass="form-control" MaxLength="50" /></td>
                                            <td><asp:label ID="LB_Direccion" runat="server" CssClass="control-label"></asp:label>   <i class="fa fa-map-marker"></i></td>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ForeColor="Red" ControlToValidate="TB_Direccion" ErrorMessage="Error, caracteres" ToolTip="La cadena contiene caracteres no validos" ValidationExpression="^[a-zA-Z ñÑ]*$"></asp:RegularExpressionValidator>
                                        </tr>
                                        <tr>
                                            <td class="field" id="email_usr" runat="server">Correo electrónico</td>
                                            <td><asp:TextBox ID="TB_Correo" runat="server" CssClass="form-control" TextMode="Email" MaxLength="30"/></td>
                                            <td><asp:label ID="LB_Correo" runat="server" CssClass="control-label"> </asp:label> <i class="fa fa-envelope"></i></td>
                                        </tr>
                                       <tr>
                                            <td><asp:Button ID="BTN_CambiarInf" runat="server" CssClass="btn btn-warning" Text="Cambiar información" OnClick="CambiarInf_Click"/></td>
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
     <!-- #modal-dialog -->
        <div class="modal fade" id="modal-dialog">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                        <h4 class="modal-title">Error</h4>
                    </div>
                    <div class="modal-body">
                        <asp:Label runat="server" ID="MensajeModal"></asp:Label>
                    </div>
                    <div class="modal-footer">
                        <a href="javascript:;" class="btn btn-sm btn-white" data-dismiss="modal">Close</a>
                    </div>
                </div>
            </div>
        </div>
    
</asp:Content>

