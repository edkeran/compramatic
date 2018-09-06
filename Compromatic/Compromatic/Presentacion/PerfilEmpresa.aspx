﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Presentacion/DashEmpresa.master" AutoEventWireup="true" CodeFile="~/LogicaPresentacion/PerfilEmpresa.aspx.cs" Inherits="Presentacion_PerfilEmpresa" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!-- begin #content -->
    <div class="content-full-width">
        <!-- begin page-header -->
        <h1 class="page-header">Perfil
            <small>Informacion de la empresa</small>
        </h1>
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
                        <h4 class="panel-title">Informacion Empresa</h4>
                    </div>
                    <div class="panel-body">
                        <div class="form- group">
                            <h4>Contacto</h4>
                            <!-- begin row -->
                            <div class="row m-b-15">
                                <!-- begin col-6 -->
                                <div class="col-md-6">
                                    <asp:Label runat="server" CssClass="control-label">Nombre</asp:Label>
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
                                    <asp:Label runat="server" CssClass="control-label">Telefono</asp:Label>
                                    <asp:TextBox runat="server" MaxLength="15" CssClass="form-control" ID="TB_Telefono" TextMode="Phone"></asp:TextBox>
                                    <asp:RequiredFieldValidator runat="server" CssClass="alert-warning" ErrorMessage="Campo Vacio" ForeColor="Red" ControlToValidate="TB_Telefono" ValidationGroup="Info"></asp:RequiredFieldValidator>
                                </div>
                                <!-- end col-4 -->
                                <!-- begin col-4 -->
                                <div class="col-md-4">
                                    <asp:Label runat="server" CssClass="control-label">Correo</asp:Label>
                                    <asp:TextBox runat="server" MaxLength="30" CssClass="form-control" ID="TB_Correo" TextMode="Email"></asp:TextBox>
                                    <asp:RequiredFieldValidator runat="server" CssClass="alert-warning" ErrorMessage="Campo Vacio" ForeColor="Red" ControlToValidate="TB_Correo" ValidationGroup="Info"></asp:RequiredFieldValidator>
                                </div>
                                <!-- end col-4 -->
                                <!-- begin col-4 -->
                                <div class="col-md-4">
                                    <asp:Label runat="server" CssClass="control-label">Direccion</asp:Label>
                                    <asp:TextBox runat="server" CssClass="form-control" ID="TB_Direccion" MaxLength="30"></asp:TextBox>
                                    <asp:RequiredFieldValidator runat="server" CssClass="alert-warning" ErrorMessage="Campo Vacio" ForeColor="Red" ControlToValidate="TB_Direccion" ValidationGroup="Info"></asp:RequiredFieldValidator>
                                </div>
                                <!-- end col-4 -->
                            </div>
                            <!-- end row -->
                            <!-- begin row -->
                            <div class="row m-b-15" style="text-align: center;">
                                <asp:Button runat="server" CssClass="btn btn-success" Text="Modificar" OnClick="ModificarDatos" ValidationGroup="Info" />
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
                        <h4 class="panel-title">Foto</h4>
                    </div>
                    <div class="panel-body">
                        <h4>Foto de Perfil</h4>
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
                                    <button type="button" class="btn btn-default dropdown-toggle" data-toggle="dropdown" onclick="show_img();"><i class="fa fa-camera"></i>Cambiar foto de perfil <span class="caret"></span></button>
                                    <ul class="dropdown-menu" role="menu" id="image">
                                        <li class="dropdown-header">Carga aquí tu foto</li>
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
                        <h4 class="panel-title">Seguridad</h4>
                    </div>
                    <div class="panel-body col-md-offset-1">
                        <div class="form-group">
                            <!-- begin row -->
                            <h4>Cambio de Contraseña</h4>
                            <div class="row m-b-15">
                                <div class="col-md-10">
                                    <asp:Label runat="server" CssClass="control-label">Contraseña</asp:Label>
                                    <asp:TextBox runat="server" MaxLength="45" ID="TB_AntiguaContraseña" CssClass="form-control" TextMode="Password" placeholder="Contraseña"></asp:TextBox>
                                    <asp:RequiredFieldValidator runat="server" CssClass="alert-warning" ErrorMessage="Campo Vacio" ForeColor="Red" ControlToValidate="TB_AntiguaContraseña" ValidationGroup="Contraseña"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="row m-b-15">
                                <div class="col-md-10">
                                    <asp:Label runat="server" CssClass="control-label">Nueva Contraseña</asp:Label>
                                    <asp:TextBox runat="server" MaxLength="45" ID="TB_Contraseña" CssClass="form-control" TextMode="Password" placeholder="Nueva Contraseña"></asp:TextBox>
                                    <asp:RequiredFieldValidator runat="server" CssClass="alert-warning" ErrorMessage="Campo Vacio" ForeColor="Red" ControlToValidate="TB_Contraseña" ValidationGroup="Contraseña"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="row m-b-15">
                                <div class="col-md-10">
                                    <asp:Label runat="server" CssClass="control-label">Repetir Contraseña</asp:Label>
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
                                        <asp:Button runat="server" CssClass="btn btn-success m-r-6 m-b-6" Text="Cambiar Contraseña" OnClick="CambiarContraseña" ValidationGroup="Contraseña" />
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
                        <h4 class="panel-title">Archivos</h4>
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
                            <asp:GridView OnRowDeleting="GridView1_RowDeleting" ID="GridView1" runat="server" CssClass="table table-condensed" AutoGenerateColumns="False" DataKeyNames="idArchivo" DataSourceID="ODS_Archivos">
                                <Columns>
                                    <asp:BoundField HeaderText="ID" DataField="idArchivo" />
                                    <asp:BoundField HeaderText="Nombre" DataField="nombreArchivo" />
                                    <asp:TemplateField HeaderText="Borrar" ShowHeader="False">
                                        <ItemTemplate>
                                            <asp:LinkButton runat="server" Text="Delete" CommandName="Delete" CausesValidation="False" ID="LinkButton1"></asp:LinkButton>
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
                            <h4>Nota</h4>
                            <ul>
                                <li>Solo documentos PDF (<strong>.pdf</strong>) son permitidos.</li>
                                <li>Los documentos serán revisados para la aprovacion de tu compañia.</li>
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

