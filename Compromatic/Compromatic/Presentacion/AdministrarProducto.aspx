﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Presentacion/DashEmpresa.master" AutoEventWireup="true" CodeFile="~/LogicaPresentacion/AdministrarProducto.aspx.cs" Inherits="LogicaPresentacion_AdministrarProducto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">


    <!-- begin #content -->
    <div id="content">

        <!-- begin page-header -->
        <h1 class="page-header">Administrar Productos</h1>
        <!-- end page-header -->

        <div class="row">
            <div class="col-md-12">
                <div class="panel panel-inverse">
                    <div class="panel-heading">
                        <div class="panel-heading-btn">
                            <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-default" data-click="panel-expand"><i class="fa fa-expand"></i></a>
                            <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-success" data-click="panel-reload"><i class="fa fa-repeat"></i></a>
                            <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-warning" data-click="panel-collapse"><i class="fa fa-minus"></i></a>
                        </div>
                        <h4 class="panel-title">Tabla de Productos</h4>
                    </div>
                    <div class="panel-body">
                        <div class="col-md-12">
                            <table id="data-table" class="table table-striped table-bordered data-table" width="100%">
                                <thead>
                                    <tr>
                                        <th>Nombre</th>
                                        <th>Descripcion</th>
                                        <th>Cantidad</th>
                                        <th>Precio</th>
                                        <th>Categoria</th>
                                        <th>Alerta</th>
                                        <th>Modificar</th>
                                        <th>Eliminar</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <asp:Repeater runat="server" ID="Prueba1" OnItemCommand="Prueba1_ItemCommand">
                                        <ItemTemplate>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label1" Width="50px" Style="word-wrap: normal; word-break: break-all;" runat="server"><%# Eval("[nomProducto]") %></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox runat="server" TextMode="MultiLine" Rows="3" Text='<%# Eval("[desProducto]") %>' ReadOnly="true"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label2" CssClass="form-control" runat="server"><%# Eval("[canProducto]") %></asp:Label>
                                                </td>
                                                <td>
                                                    <div class="input-group">
                                                        <span class="input-group-addon">$</span>
                                                        <asp:Label runat="server" CssClass="form-control"><%# Eval("[precioProducto]") %></asp:Label>
                                                    </div>
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label4" Width="30px" runat="server"><%# Eval("[nomCategoria]") %></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label3" Width="30px" runat="server"><%# Eval("[bajoInventario]") %></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Button runat="server" CommandName="Select" Text="Seleccionar" CssClass="btn btn-primary" />
                                                </td>
                                                <td>
                                                    <asp:Button runat="server" CommandName="Delete" Text="Eliminar" CommandArgument='<%# Eval("[idProducto]") %>' CssClass="btn btn-danger" />
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <div class="row">
                    <div class="col-md-12">
                        <div class="panel panel-inverse">
                            <div class="panel-heading">
                                <div class="panel-heading-btn">
                                    <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-default" data-click="panel-expand"><i class="fa fa-expand"></i></a>
                                    <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-success" data-click="panel-reload"><i class="fa fa-repeat"></i></a>
                                    <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-warning" data-click="panel-collapse"><i class="fa fa-minus"></i></a>
                                </div>
                                <h4 class="panel-title">Modificar Datos</h4>
                            </div>
                            <div class="panel-body">
                                <div class="row">

                                    <asp:Label runat="server" ID="idProducto" Visible="false">0</asp:Label>
                                    <div class="col-md-3">
                                        <div class="form-group">
                                            <label>Nombre</label>
                                            <asp:TextBox runat="server" MaxLength="45" ID="TB_Nombre" CssClass="form-control"></asp:TextBox>
                                            <asp:RequiredFieldValidator runat="server" ErrorMessage="Campo Necesario" ForeColor="Red" ControlToValidate="TB_Nombre" ValidationGroup="Modificar"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="col-md-3">
                                        <div class="form-group">
                                            <label>Cantidad</label>
                                            <asp:TextBox runat="server" ID="TB_Cantidad" TextMode="Number" max="1000000" min="0" CssClass="form-control"></asp:TextBox>
                                            <asp:RequiredFieldValidator runat="server" ErrorMessage="Campo Necesario" ForeColor="Red" ControlToValidate="TB_Cantidad" ValidationGroup="Modificar"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="col-md-3">
                                        <div class="form-group">
                                            <label>Precio</label>
                                            <div class="input-group">
                                                <span class="input-group-addon">$</span>
                                                <asp:TextBox runat="server" ID="TB_Precio" max="20000000" CssClass="form-control" TextMode="Number" min="1"></asp:TextBox>
                                            </div>
                                            <asp:RequiredFieldValidator runat="server" ErrorMessage="Campo Necesario" ForeColor="Red" ControlToValidate="TB_Precio" ValidationGroup="Modificar"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="col-md-3">
                                        <div class="form-group">
                                            <label>Categoria</label>
                                            <asp:DropDownList runat="server" CssClass="form-control selectpicker" data-live-search="true" data-style="btn-success" DataSourceID="OBSCategoria" DataTextField="nomCategoria" DataValueField="idCategoria" AppendDataBoundItems="true" ID="DDL_Categoria">
                                            </asp:DropDownList>
                                            <asp:ObjectDataSource runat="server" ID="OBSCategoria" SelectMethod="MostrarCategoria" TypeName="Logica.L_Componentes"></asp:ObjectDataSource>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="form-group">
                                            <label>Descripcion</label>
                                            <asp:TextBox runat="server" ID="TB_Descripcion" TextMode="MultiLine" Rows="4" CssClass="form-control" />
                                            <asp:RequiredFieldValidator runat="server" ErrorMessage="Campo Necesario" ForeColor="Red" ControlToValidate="TB_Descripcion" ValidationGroup="Modificar"></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator runat="server" ID="valInput"
                                                ValidationExpression="^[\s\S]{0,150}$"
                                                ControlToValidate="TB_Descripcion"
                                                ErrorMessage="Maximo 150 Caracteres"
                                                Display="Dynamic">*</asp:RegularExpressionValidator>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <asp:Button runat="server" CssClass="btn btn-primary" Text="Modificar" ValidationGroup="Modificar" ID="BTN_Modificar" OnClick="BTN_Modificar_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-md-7">
                <div class="row">
                    <div class="col-md-12">
                        <div class="panel panel-inverse">
                            <div class="panel-heading">
                                <div class="panel-heading-btn">
                                    <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-default" data-click="panel-expand"><i class="fa fa-expand"></i></a>
                                    <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-success" data-click="panel-reload"><i class="fa fa-repeat"></i></a>
                                    <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-warning" data-click="panel-collapse"><i class="fa fa-minus"></i></a>
                                </div>
                                <h4 class="panel-title">Imagenes</h4>
                            </div>
                            <div class="panel-body">
                                <div class="form-group">
                                    <div class="col-md-8">
                                        <asp:FileUpload runat="server" ID="FU_FotoProducto" AllowMultiple="true" CssClass="form-control" />
                                        <asp:RequiredFieldValidator runat="server" ErrorMessage="No Foto Seleccionada" ValidationGroup="Foto" ForeColor="Red" ControlToValidate="FU_FotoProducto"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-md-4">
                                        <asp:Button runat="server" ID="BTN_SubirFotos" OnClick="AgregarFotosProductos" CssClass="btn btn-primary" Text="Subir Fotos" ValidationGroup="Foto" />
                                    </div>
                                </div>
                                <div class="col-md-12">
                                    <div id="gallery" class="gallery">
                                        <asp:Repeater ID="TablaImagenes" runat="server" DataSourceID="OBS_Fotos" OnItemCommand="TablaImagenes_ItemCommand">
                                            <ItemTemplate>
                                                <div class="image gallery-group-1">
                                                    <div class="image-inner">
                                                        <a href='<%# Eval("[nomArchivo]") %>' data-lightbox="gallery-group-1">
                                                            <img src='<%# Eval("[nomArchivo]") %>' alt="" />
                                                        </a>

                                                    </div>
                                                    <div class="image-info">
                                                        <div class="desc">
                                                            <asp:Button runat="server" CssClass="btn btn-danger" CommandName="Delete" CommandArgument='<%# Eval("[idProducto]") %>' Text="Eliminar"></asp:Button>
                                                        </div>
                                                    </div>
                                                </div>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </div>

                                    <asp:ObjectDataSource runat="server" ID="OBS_Fotos" SelectMethod="MostrarFoto" TypeName="Logica.L_Componentes">
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="idProducto" PropertyName="Text" Name="idProducto" Type="Int32"></asp:ControlParameter>
                                        </SelectParameters>
                                    </asp:ObjectDataSource>
                                </div>
                            </div>

                        </div>
                    </div>
                </div>
            </div>
            <div class="col-md-5">
                <div class="row">
                    <div class="col-md-12">
                        <div class="panel panel-inverse">
                            <div class="panel-heading">
                                <div class="panel-heading-btn">
                                    <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-default" data-click="panel-expand"><i class="fa fa-expand"></i></a>
                                    <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-success" data-click="panel-reload"><i class="fa fa-repeat"></i></a>
                                    <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-warning" data-click="panel-collapse"><i class="fa fa-minus"></i></a>
                                </div>
                                <h4 class="panel-title">Palabras Clave</h4>
                            </div>
                            <div class="panel-body">
                                <!-- begin col-8 -->
                                <div class="col-md-8">
                                    <div class="form-group">
                                        <label>Tags</label>
                                        <asp:TextBox runat="server" MaxLength="15" ID="TB_Tags" CssClass="form-control"></asp:TextBox>
                                        <div class="form-group">
                                            <asp:RequiredFieldValidator runat="server" ErrorMessage="Texto Necesario" ForeColor="Red" ControlToValidate="TB_Tags" CssClass="warning" ValidationGroup="Tags"></asp:RequiredFieldValidator>
                                            <asp:DropDownList runat="server" DataTextField="palabra" DataValueField="idPalabra_clave" ID="DDL_Tags" CssClass="form-control" DataSourceID="OBS_Tags"></asp:DropDownList>
                                            <asp:ObjectDataSource runat="server" ID="OBS_Tags" SelectMethod="MostrarTags" TypeName="Logica.L_Componentes">
                                                <SelectParameters>
                                                    <asp:ControlParameter ControlID="idProducto" PropertyName="Text" Name="idProducto" Type="Int32"></asp:ControlParameter>
                                                </SelectParameters>
                                            </asp:ObjectDataSource>
                                        </div>
                                    </div>
                                </div>
                                <!-- end col-8 -->
                                <!-- begin col-4 -->
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <label>Añadir</label>
                                        <asp:Button runat="server" ID="BTN_AñadirTag" Text="+" CssClass="form-control btn-success" OnClick="BTN_AñadirTag_Click" ValidationGroup="Tags" />
                                        <asp:Button runat="server" ID="BTN_BorrarTag" Text="-" CssClass="form-control btn-danger" OnClick="BTN_BorrarTag_Click" />
                                    </div>
                                </div>
                                <!-- end col-4 -->
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-md-7">
                <div class="panel panel-inverse">
                    <div class="panel-heading">
                        <div class="panel-heading-btn">
                            <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-default" data-click="panel-expand"><i class="fa fa-expand"></i></a>
                            <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-success" data-click="panel-reload"><i class="fa fa-repeat"></i></a>
                            <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-warning" data-click="panel-collapse"><i class="fa fa-minus"></i></a>
                        </div>
                        <h4 class="panel-title">Alerta</h4>
                    </div>
                    <div class="panel-body">
                        <div class="col-md-12">
                            <div class="form-group">
                                <div class="col-md-4">
                                    <asp:TextBox runat="server" CssClass="form-control" ID="TB_AlertaActual" placeholder="Alerta Actual" ReadOnly="true"></asp:TextBox>
                                </div>
                                <div class="col-md-4">
                                    <asp:TextBox runat="server" CssClass="form-control" ID="TB_NuevaAlerta" placeholder="Nueva Alerta" min="0" max="2000000" Text="1"></asp:TextBox>
                                    <asp:RequiredFieldValidator runat="server" ErrorMessage="Texto Necesario" ForeColor="Red" ControlToValidate="TB_NuevaAlerta" CssClass="warning" ValidationGroup="Alerta"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-md-4">
                                    <asp:Button runat="server" ID="BTN_ModificarAlerta" Text="Modificar" CssClass="form-control btn-primary" OnClick="BTN_ModificarAlerta_Click" ValidationGroup="Alerta" />
                                </div>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </div>
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

