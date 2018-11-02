<%@ Page Title="" Language="C#" MasterPageFile="~/Presentacion/DashEmpresa.master" AutoEventWireup="true" CodeFile="~/LogicaPresentacion/AdministrarProducto.aspx.cs" Inherits="LogicaPresentacion_AdministrarProducto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">


    <!-- begin #content -->
    <div id="content">

        <!-- begin page-header -->
        <h1 class="page-header" id="header" runat="server">Administrar Productos</h1>
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
                        <h4 class="panel-title" id="tbl_produ" runat="server">Tabla de Productos</h4>
                    </div>
                    <div class="panel-body">
                        <div class="col-md-12">
                            <table id="data-table" class="table table-striped table-bordered data-table" width="100%">
                                <thead>
                                    <tr>
                                        <th id="nom" runat="server">Nombre</th>
                                        <th id="desc" runat="server">Descripcion</th>
                                        <th id="cant" runat="server">Cantidad</th>
                                        <th id="perc" runat="server">Precio</th>
                                        <th id="cate" runat="server">Categoria</th>
                                        <th id="alert" runat="server">Alerta</th>
                                        <th id="modif" runat="server">Modificar</th>
                                        <th id="delete" runat="server">Eliminar</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <asp:Repeater runat="server" ID="Prueba1" OnItemCommand="Prueba1_ItemCommand" OnItemDataBound="RptDos_ItemDataBound">
                                        <ItemTemplate>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label1" Width="50px" Style="word-wrap: normal; word-break: break-all;" runat="server"><%# Eval("Nombre") %></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox runat="server" TextMode="MultiLine" Rows="3" Text='<%# Eval("Descripcion") %>' ReadOnly="true"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label2" CssClass="form-control" runat="server"><%# Eval("Cantidad") %></asp:Label>
                                                </td>
                                                <td>
                                                    <div class="input-group">
                                                        <span class="input-group-addon">$</span>
                                                        <asp:Label runat="server" CssClass="form-control"><%# Eval("Precio") %></asp:Label>
                                                    </div>
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label4" Width="30px" runat="server"><%# Eval("NomCategoria") %></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label3" Width="30px" runat="server"><%# Eval("BajoInventario") %></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Button id="BTN_select" runat="server" CommandName="Select" Text="Seleccionar" CssClass="btn btn-primary" />
                                                </td>
                                                <td>
                                                    <asp:Button id="BTN_del" runat="server" CommandName="Delete" Text="Eliminar" CommandArgument='<%# Eval("Id") %>' CssClass="btn btn-danger" />
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
                                <h4 class="panel-title" id="mod_data" runat="server">Modificar Datos</h4>
                            </div>
                            <div class="panel-body">
                                <div class="row">

                                    <asp:Label runat="server" ID="idProducto" Visible="false">0</asp:Label>
                                    <div class="col-md-3">
                                        <div class="form-group">
                                            <label id="nombr" runat="server">Nombre</label>
                                            <asp:TextBox runat="server" MaxLength="45" ID="TB_Nombre" CssClass="form-control"></asp:TextBox>
                                            <asp:RequiredFieldValidator runat="server" ErrorMessage="Campo Necesario" ForeColor="Red" ControlToValidate="TB_Nombre" ValidationGroup="Modificar"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="col-md-3">
                                        <div class="form-group">
                                            <label id="quant" runat="server">Cantidad</label>
                                            <asp:TextBox runat="server" ID="TB_Cantidad" TextMode="Number" max="1000000" min="0" CssClass="form-control"></asp:TextBox>
                                            <asp:RequiredFieldValidator runat="server" ErrorMessage="Campo Necesario" ForeColor="Red" ControlToValidate="TB_Cantidad" ValidationGroup="Modificar"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="col-md-3">
                                        <div class="form-group">
                                            <label id="price" runat="server">Precio</label>
                                            <div class="input-group">
                                                <span class="input-group-addon">$</span>
                                                <asp:TextBox runat="server" ID="TB_Precio" max="20000000" CssClass="form-control" TextMode="Number" min="1"></asp:TextBox>
                                            </div>
                                            <asp:RequiredFieldValidator runat="server" ErrorMessage="Campo Necesario" ForeColor="Red" ControlToValidate="TB_Precio" ValidationGroup="Modificar"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="col-md-3">
                                        <div class="form-group">
                                            <label id="cat" runat="server">Categoria</label>
                                            <asp:DropDownList runat="server" CssClass="form-control selectpicker" data-live-search="true" data-style="btn-success" DataSourceID="OBSCategoria" DataTextField="nomCategoria" DataValueField="Id_cate" AppendDataBoundItems="true" ID="DDL_Categoria">
                                            </asp:DropDownList>
                                            <asp:ObjectDataSource runat="server" ID="OBSCategoria" SelectMethod="MostrarCategoria" TypeName="Logica.L_Componentes"></asp:ObjectDataSource>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="form-group">
                                            <label id="descri" runat="server">Descripcion</label>
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
                                <h4 class="panel-title" id="img" runat="server">Imagenes</h4>
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
                                        <asp:Repeater ID="TablaImagenes" runat="server" DataSourceID="OBS_Fotos" OnItemCommand="TablaImagenes_ItemCommand" OnItemDataBound="RptUno_ItemDataBound">
                                            <ItemTemplate>
                                                <div class="image gallery-group-1">
                                                    <div class="image-inner">
                                                        <a href='<%# Eval("[RutaArchi]") %>' data-lightbox="gallery-group-1">
                                                            <img src='<%# Eval("[RutaArchi]") %>' alt="" />
                                                        </a>

                                                    </div>
                                                    <div class="image-info">
                                                        <div class="desc">
                                                            <asp:Button id="BTN_delete_img" runat="server" CssClass="btn btn-danger" CommandName="Delete" CommandArgument='<%# Eval("[Id_foto]") %>' Text="Eliminar"></asp:Button>
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
                                <h4 class="panel-title" id="key_words" runat="server">Palabras Clave</h4>
                            </div>
                            <div class="panel-body">
                                <!-- begin col-8 -->
                                <div class="col-md-8">
                                    <div class="form-group">
                                        <label>Tags</label>
                                        <asp:TextBox runat="server" MaxLength="15" ID="TB_Tags" CssClass="form-control"></asp:TextBox>
                                        <div class="form-group">
                                            <asp:RequiredFieldValidator runat="server" ErrorMessage="Texto Necesario" ForeColor="Red" ControlToValidate="TB_Tags" CssClass="warning" ValidationGroup="Tags"></asp:RequiredFieldValidator>
                                            <asp:DropDownList runat="server" DataTextField="Palabra" DataValueField="IdTag" ID="DDL_Tags" CssClass="form-control" DataSourceID="OBS_Tags"></asp:DropDownList>
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
                                        <label id="add" runat="server">Añadir</label>
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
                        <h4 class="panel-title" id="alr" runat="server">Alerta</h4>
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
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Solo Un Valor Numerico" ForeColor="Red" ControlToValidate="TB_NuevaAlerta" ValidationGroup="Alerta" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
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

