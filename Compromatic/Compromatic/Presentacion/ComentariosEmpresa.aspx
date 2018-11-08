<%@ Page Title="Comentarios Empresa" Language="C#" MasterPageFile="~/Presentacion/DashEmpresa.master" AutoEventWireup="true" CodeFile="~/LogicaPresentacion/ComentariosEmpresa.aspx.cs" Inherits="Presentacion_ComentariosEmpresa" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
     <!-- begin #content -->
    <div id="content">
        <!-- begin page-header -->
        <h1 class="page-header" id="comm" runat="server">Comentarios</h1>
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
                        <h4 class="panel-title" id="ComEm" runat="server">Comentarios De Los Usuarios</h4>
                    </div>
                    <div class="panel-body">
                        <div class="col-md-12">
                            <table id="data-table" class="table table-striped table-bordered data-table" width="100%">
                                <thead>
                                    <tr>
                                        <th id="nom" runat="server">Nombre Usuario</th>
                                        <th id="comUsr" runat="server">Comentario</th>
                                        <th id="crrUsr" runat="server">Correo Usuario</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <asp:Repeater runat="server" ID="Productos" DataSourceID="OBS_Comentarios">
                                        <ItemTemplate>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label1" Width="150px" Style="word-wrap: normal; word-break: break-all;" runat="server"><%# Eval("NomUser") %></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox runat="server" TextMode="MultiLine" Rows="3" Text='<%# Eval("Comentario") %>' ReadOnly="true"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="TB_Comment" CssClass="form-control" runat="server" Text='<%# Eval("CorreoUser") %>' ReadOnly="true"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                    <asp:ObjectDataSource runat="server" ID="OBS_Comentarios" SelectMethod="get_coment" TypeName="Logica.L_Componentes">
                                        <SelectParameters>
                                            <asp:SessionParameter SessionField="IdEmpresa" Name="idEmpresa" Type="Int32"></asp:SessionParameter>
                                        </SelectParameters>
                                    </asp:ObjectDataSource>
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- end #content -->

</asp:Content>

