<%@ Page Title="" Language="C#" MasterPageFile="~/Presentacion/MasterDashBoardUsr.master" AutoEventWireup="true" CodeFile="~/LogicaPresentacion/CambiarPassUsr.aspx.cs" Inherits="Presentacion_CambiarPassUsr" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <!-- begin #content -->
		<div id="content" class="content">
			<!-- begin breadcrumb -->
			
			<!-- end breadcrumb -->
			<!-- begin page-header -->
			<h1 class="page-header" id="usr_ch_pass" runat="server">Cambiar contraseña del perfil </h1>
            <small id="pass_usr" style="font-weight:300;font-size:120%;" runat="server">Contraseña</small>
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
                        
                        
                        <!-- end profile-image -->
                        
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
                                            <td class="field" id="ant_pass"  runat="server">Contraseña anterior:</td>
                                            <td><asp:TextBox ID="TB_Pass1" CssClass="form-control" runat="server" TextMode="Password" MaxLength="45" onkeypress="return validarn(event)"></asp:TextBox></td>
                                            <asp:RequiredFieldValidator runat="server" CssClass="alert-warning" ErrorMessage="Campo Necesario" ForeColor="Red" ControlToValidate="TB_Pass1" ValidationGroup="CambiarPass"></asp:RequiredFieldValidator>
                                        </tr>
                                        <tr>
                                            <td class="field" id="new_pass" runat="server">Contraseña nueva:</td>
                                            <td><asp:TextBox ID="TB_Pass2" CssClass="form-control" runat="server" TextMode="Password" MaxLength="45" onkeypress="return validarn(event)" ></asp:TextBox></td>
                                            <asp:RequiredFieldValidator runat="server" CssClass="alert-warning" ErrorMessage="Campo Necesario" ForeColor="Red" ControlToValidate="TB_Pass2" ValidationGroup="CambiarPass"></asp:RequiredFieldValidator>
                                        </tr>
                                        <tr>
                                            <td class="field" id="new_pass2" runat="server">Repetir contraseña:</td>
                                            <td><asp:TextBox ID="TB_Pass3" CssClass="form-control" runat="server" TextMode="Password" MaxLength="45" onkeypress="return validarn(event)" ></asp:TextBox></td>
                                            <asp:RequiredFieldValidator runat="server" CssClass="alert-warning" ErrorMessage="Campo Necesario" ForeColor="Red" ControlToValidate="TB_Pass3" ValidationGroup="CambiarPass"></asp:RequiredFieldValidator>
                                        </tr>
                                       <tr class="divider">
                                            <td colspan="2">
                                                <asp:Button ID="Btn_Modificar" runat="server" CssClass="btn btn-warning btn-block btn-sm" Text="Cambiar información" OnClick="BtnCambiarInf_Click" Height="26px" ValidationGroup="CambiarPass"/>
                                            </td>
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

