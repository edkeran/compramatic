<%@ Page Title="" Language="C#" MasterPageFile="~/Presentacion/DashEmpresa.master" AutoEventWireup="true" CodeFile="~/LogicaPresentacion/PerfilEmpresa.aspx.cs" Inherits="Presentacion_PerfilEmpresa" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!-- begin #content -->
    <div class="content-full-width">
        <!-- begin page-header -->
        <h1 class="page-header" id="perfil" runat="server">Perfil</h1>
         <small id="info_empr" style="font-weight:300;font-size:120%;" runat="server">Informacion de la empresa</small>
        <!-- end page-header -->
        <!-- begin row -->
        <div class="row">
            <!-- begin col-12 -->
            <div class="col-md-12 ui-sortable">
                <!-- begin panel -->
                <div class="panel panel-inverse" data-sortable-id="1">
                    <div class="panel-heading">
                        <div class="panel-heading-btn">
                            <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-default" data-click="panel-expand"><i class="fa fa-expand"></i></a>
                            <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-success" data-click="panel-reload"><i class="fa fa-repeat"></i></a>
                            <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-warning" data-click="panel-collapse"><i class="fa fa-minus"></i></a>
                        </div>
                        <h4 class="panel-title" id="inf_emp" runat="server">Informacion Empresa</h4>
                    </div>
                    <div class="panel-body">
                        <div class="form- group">
                            <h4 id="contact" runat="server">Contacto</h4>
                            <!-- begin row -->
                            <div class="row m-b-15">
                                <!-- begin col-6 -->
                                <div class="col-md-6">
                                    <asp:Label runat="server" CssClass="control-label" ID="LB_nombre">Nombre</asp:Label>
                                    <asp:TextBox runat="server" MaxLength="45" CssClass="form-control" ID="TB_Nombre"></asp:TextBox>
                                    <asp:RequiredFieldValidator runat="server" CssClass="alert-warning" ErrorMessage="Campo Vacio" ForeColor="Red" ControlToValidate="TB_Nombre" ValidationGroup="Info"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ForeColor="Red" ControlToValidate="TB_Nombre" ErrorMessage="Error, caracteres" ToolTip="La cadena contiene caracteres no validos" ValidationExpression="^[a-zA-Z ñÑ]*$"></asp:RegularExpressionValidator>
                                </div>
                                <!-- end col-6 -->
                                <!-- begin col-6 -->
                                <div class="col-md-6">
                                    <asp:Label runat="server" CssClass="control-label">Nit</asp:Label>
                                    <asp:TextBox runat="server" MaxLength="15" CssClass="form-control" ID="TB_Nit" ReadOnly="true"></asp:TextBox>
                                    <asp:RequiredFieldValidator runat="server" CssClass="alert-warning" ErrorMessage="Campo Vacio" ForeColor="Red" ControlToValidate="TB_Nit" ValidationGroup="Info"></asp:RequiredFieldValidator>
                                </div>
                                <!-- end col-6 -->
                            </div>
                            <!-- end row -->
                            <!-- begin row -->
                            <div class="row m-b-15">
                                <!-- begin col-4 -->
                                <div class="col-md-4">
                                    <asp:Label runat="server" CssClass="control-label" ID="LB_Telef">Telefono</asp:Label>
                                    <asp:TextBox runat="server" MaxLength="15" CssClass="form-control" ID="TB_Telefono" TextMode="Phone"></asp:TextBox>
                                    <asp:RequiredFieldValidator runat="server" CssClass="alert-warning" ErrorMessage="Campo Vacio" ForeColor="Red" ControlToValidate="TB_Telefono" ValidationGroup="Info"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ForeColor="Red" ControlToValidate="TB_Telefono" ErrorMessage="Error, caracteres" ToolTip="La cadena contiene caracteres no validos" ValidationExpression="^[0-9]*$" ValidationGroup="Info"></asp:RegularExpressionValidator>
                                </div>
                                <!-- end col-4 -->
                                <!-- begin col-4 -->
                                <div class="col-md-4">
                                    <asp:Label runat="server" CssClass="control-label" ID="LB_correo">Correo</asp:Label>
                                    <asp:TextBox runat="server" MaxLength="30" CssClass="form-control" ID="TB_Correo" TextMode="Email"></asp:TextBox>
                                    <asp:RequiredFieldValidator runat="server" CssClass="alert-warning" ErrorMessage="Campo Vacio" ForeColor="Red" ControlToValidate="TB_Correo" ValidationGroup="Info"></asp:RequiredFieldValidator>
                                </div>
                                <!-- end col-4 -->
                                <!-- begin col-4 -->
                                <div class="col-md-4">
                                    <asp:Label runat="server" CssClass="control-label" ID="LB_Dire">Direccion</asp:Label>
                                    <asp:TextBox runat="server" CssClass="form-control" ID="TB_Direccion" MaxLength="30"></asp:TextBox>
                                    <asp:RequiredFieldValidator runat="server" CssClass="alert-warning" ErrorMessage="Campo Vacio" ForeColor="Red" ControlToValidate="TB_Direccion" ValidationGroup="Info"></asp:RequiredFieldValidator>
                                </div>
                                <!-- end col-4 -->
                            </div>
                            <!-- end row -->
                            <!-- begin row -->
                            <div class="row m-b-15" style="text-align: center;">
                                <asp:Button runat="server" CssClass="btn btn-success" Text="Modificar" OnClick="ModificarDatos" ValidationGroup="Info" ID="BTN_Modif" />
                            </div>
                            <!-- end row -->
                        </div>
                    </div>
                </div>
                <!-- end panel -->
            </div>
            <!-- end col-12 -->
        </div>
        <!-- end row -->
        <!-- begin row -->
        <div class="row">
            <!-- begin col-5 -->
            <div class="col-md-5 ui-sortable">
                <!-- begin panel -->
                <div class="panel panel-inverse" data-sortable-id="1">
                    <div class="panel-heading">
                        <div class="panel-heading-btn">
                            <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-success" data-click="panel-reload"><i class="fa fa-repeat"></i></a>
                            <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-warning" data-click="panel-collapse"><i class="fa fa-minus"></i></a>
                        </div>
                        <h4 class="panel-title" id="photo" runat="server">Foto</h4>
                    </div>
                    <div class="panel-body">
                        <h4 id="profile_pic" runat="server">Foto de Perfil</h4>
                        <!-- begin row -->
                        <div class="row m-t-20">
                            <!-- begin col-5 -->
                            <div class="col-md-5">
                                <!-- begin profile-image -->
                                <div class="profile-image">
                                    <asp:Image runat="server" ID="IMG_Foto" />
                                    <i class="fa fa-user hide"></i>
                                </div>
                                <!-- end profile-image -->
                            </div>
                            <!-- end col-5 -->
                            <!-- begin col-7 -->
                            <div class="col-md-7">
                                <div class="btn-group">
                                    <button type="button" class="btn btn-default dropdown-toggle" data-toggle="dropdown" onclick="show_img();" id="img_btn" runat="server"></button>
                                    <ul class="dropdown-menu" role="menu" id="image">
                                        <li class="dropdown-header" id="load_pictu" runat="server">Carga aquí tu foto</li>
                                        <li>
                                            <asp:FileUpload ID="FU_CambiarFoto" runat="server" CssClass="document-file" /></li>
                                            <asp:RequiredFieldValidator runat="server" CssClass="alert-warning" ErrorMessage="Archivo Necesario" ForeColor="Red" ControlToValidate="FU_CambiarFoto" ValidationGroup="CambiarFoto"></asp:RequiredFieldValidator>
                                        <li>
                                            <br />
                                        </li>
                                        <li>
                                            <asp:Button ID="BTN_CambiarFoto" runat="server" CssClass="btn btn-warning btn-block btn-sm" Text="Cambiar Foto" OnClick="BTN_CambiarFoto_Click" ValidationGroup="CambiarFoto" /></li>
                                    </ul>
                                </div>
                            </div>
                            <!-- end col-7 -->
                        </div>
                        <!-- end row -->
                    </div>
                </div>
                <!-- end panel -->
            </div>
            <!-- end col-5 -->
            <!-- begin col-7 -->
            <div class="col-md-7 ui-sortable">
                <!-- begin panel -->
                <div class="panel panel-inverse" data-sortable-id="1">
                    <div class="panel-heading">
                        <div class="panel-heading-btn">
                            <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-default" data-click="panel-expand"><i class="fa fa-expand"></i></a>
                            <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-success" data-click="panel-reload"><i class="fa fa-repeat"></i></a>
                            <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-warning" data-click="panel-collapse"><i class="fa fa-minus"></i></a>
                        </div>
                        <h4 class="panel-title" id="security" runat="server">Seguridad</h4>
                    </div>
                    <div class="panel-body col-md-offset-1">
                        <div class="form-group">
                            <!-- begin row -->
                            <h4 id="change_pass" runat="server">Cambio de Contraseña</h4>
                            <div class="row m-b-15">
                                <div class="col-md-10">
                                    <asp:Label runat="server" CssClass="control-label" ID="LB_PASS">Contraseña</asp:Label>
                                    <asp:TextBox runat="server" MaxLength="45" ID="TB_AntiguaContraseña" CssClass="form-control" TextMode="Password" placeholder="Contraseña"></asp:TextBox>
                                    <asp:RequiredFieldValidator runat="server" CssClass="alert-warning" ErrorMessage="Campo Vacio" ForeColor="Red" ControlToValidate="TB_AntiguaContraseña" ValidationGroup="Contraseña"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="row m-b-15">
                                <div class="col-md-10">
                                    <asp:Label runat="server" CssClass="control-label" ID="LB_New_Pass">Nueva Contraseña</asp:Label>
                                    <asp:TextBox runat="server" MaxLength="45" ID="TB_Contraseña" CssClass="form-control" TextMode="Password" placeholder="Nueva Contraseña"></asp:TextBox>
                                    <asp:RequiredFieldValidator runat="server" CssClass="alert-warning" ErrorMessage="Campo Vacio" ForeColor="Red" ControlToValidate="TB_Contraseña" ValidationGroup="Contraseña"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="row m-b-15">
                                <div class="col-md-10">
                                    <asp:Label runat="server" CssClass="control-label" ID="LB_rep_pass">Repetir Contraseña</asp:Label>
                                    <asp:TextBox runat="server" MaxLength="45" ID="TB_Contraseña2" CssClass="form-control" TextMode="Password" placeholder="De Nuevo"></asp:TextBox>
                                    <asp:RequiredFieldValidator runat="server" CssClass="alert-warning" ErrorMessage="Campo Vacio" ForeColor="Red" ControlToValidate="TB_Contraseña2" ValidationGroup="Contraseña"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                        <!-- end row -->
                        <!-- begin row -->
                        <div class="row">
                            <!-- begin co+l-12 -->
                            <div class="col-md-12">
                                <div class="form-group">
                                    <div>
                                        <asp:Button runat="server" CssClass="btn btn-success m-r-6 m-b-6" Text="Cambiar Contraseña" OnClick="CambiarContraseña" ValidationGroup="Contraseña" runat="server" id="btn_change_pass"/>
                                    </div>
                                </div>
                            </div>
                            <!-- end col-12 -->
                        </div>
                        <!-- end row -->
                    </div>
                </div>
                <!-- end panel -->
            </div>
            <!-- end col-7 -->
        </div>
        <!-- end row -->
        <!-- begin row -->
        <div class="row">
            <!-- being col-7 -->
            <div class="col-md-7 ui-sortable">
                <!-- begin panel -->
                <div class="panel panel-inverse" data-sortable-id="1">
                    <div class="panel-heading">
                        <div class="panel-heading-btn">
                            <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-default" data-click="panel-expand"><i class="fa fa-expand"></i></a>
                            <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-success" data-click="panel-reload"><i class="fa fa-repeat"></i></a>
                            <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-warning" data-click="panel-collapse"><i class="fa fa-minus"></i></a>
                        </div>
                        <h4 class="panel-title" id="files" runat="server">Archivos</h4>
                    </div>
                    <div class="panel-body">
                        <div class="form-group">
                            <div class="row">
                                <div class="col-md-8">
                                    <asp:FileUpload runat="server" CssClass="btn btn-white form-control" ID="FU_Archivos" />
                                    <asp:RequiredFieldValidator runat="server" CssClass="alert-warning" ErrorMessage="Archivo Necesario" ForeColor="Red" ControlToValidate="FU_Archivos" ValidationGroup="Archivo"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-md-4">
                                    <asp:Button runat="server" Text="Subir" ID="BTN_SubirArchivo" CssClass="btn btn-success form-control" OnClick="BTN_SubirArchivo_Click" ValidationGroup="Archivo" />
                                </div>
                            </div>
                        </div>
                        <div class="row m-b-15">
                            <asp:GridView OnRowCommand="GridView1_RowCommand" ID="GridView1" runat="server" CssClass="table table-condensed" AutoGenerateColumns="False" DataKeyNames="idArchivo" DataSourceID="ODS_Archivos">
                                <Columns>
                                    <asp:BoundField HeaderText="ID" DataField="idArchivo" />
                                    <asp:BoundField HeaderText="Nombre" DataField="nombreArchivo" />
                                    <asp:TemplateField HeaderText="Borrar" ShowHeader="False">
                                        <ItemTemplate>
                                            <asp:LinkButton runat="server" Text="Delete"  CommandArgument='<%# Eval("[idArchivo]") %>' CausesValidation="False" ID="LinkButton1" CommandName='<%# Eval("[nombreArchivo]") %>'></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                            <asp:ObjectDataSource runat="server" ID="ODS_Archivos" SelectMethod="MostrarArchivos" TypeName="Logica.L_Componentes">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="TB_Nit" Name="nit" PropertyName="Text" Type="String" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                        </div>
                        <div class="note note-info">
                            <h4 id="note" runat="server">Nota</h4>
                            <ul>
                                <li id="onlyPDF" runat="server">Solo documentos PDF (<strong>.pdf</strong>) son permitidos.</li>
                                <li id="docs" runat="server">Los documentos serán revisados para la aprovacion de tu compañia.</li>
                            </ul>
                        </div>
                    </div>
                </div>
            </div>
            <!-- end col-7 -->
        </div>
        <!-- end row -->
        <!-- #modal-dialog -->
        <div class="modal fade" id="modal-dialog">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                        <h4 class="modal-title">Mensaje</h4>
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
    </div>
    <!-- end #content -->
</asp:Content>

