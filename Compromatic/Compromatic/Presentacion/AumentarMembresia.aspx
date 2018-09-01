<%@ Page Title="" Language="C#" MasterPageFile="~/Presentacion/DashEmpresa.master" AutoEventWireup="true" CodeFile="~/LogicaPresentacion/AumentarMembresia.aspx.cs" Inherits="Presentacion_AumentarMembresia" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!-- begin page-header -->
    <h1 class="page-header">Membresia</h1>
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
                    <h4 class="panel-title">Plan Actual</h4>
                </div>
                <div class="panel-body">
                    <div class="col-md-12 form-group">
                        <div class="col-md-4">
                            <label>Fecha Inicial</label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="TB_Inicial" ReadOnly="true"></asp:TextBox>
                        </div>
                        <div class="col-md-4">
                            <label>Fecha Final</label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="TB_Final" ReadOnly="true"></asp:TextBox>
                        </div>
                        <div class="col-md-4">
                            <label>Estado</label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="TB_Plan" ReadOnly="true"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
            <div class="panel panel-inverse">
                <div class="panel-heading">
                    <div class="panel-heading-btn">
                        <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-default" data-click="panel-expand"><i class="fa fa-expand"></i></a>
                        <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-success" data-click="panel-reload"><i class="fa fa-repeat"></i></a>
                        <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-warning" data-click="panel-collapse"><i class="fa fa-minus"></i></a>
                    </div>
                    <h4 class="panel-title">Aumentar Membresia</h4>
                </div>
                <div class="panel-body">
                    <div class="col-md-12 form-group">
                        <div class="col-md-3">
                            <label>Tipos</label>
                            <asp:DropDownList runat="server" ID="DDL_Memebresia" CssClass="form-control" AutoPostBack="true" DataSourceID="ODS_Membresia" DataTextField="nomMembresia" DataValueField="idTipo_membresia" OnSelectedIndexChanged="DDL_Memebresia_SelectedIndexChanged"></asp:DropDownList>
                            <asp:ObjectDataSource runat="server" ID="ODS_Membresia" SelectMethod="MostrarTipos" TypeName="DAOMembresia"></asp:ObjectDataSource>
                        </div>
                        <div class="col-md-3">
                            <label>Nuevo Inicio</label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="TB_FechaInicio" ReadOnly="true"></asp:TextBox>
                        </div>
                        <div class="col-md-3">
                            <label>Nuevo Final</label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="TB_FechaFinal" ReadOnly="true"></asp:TextBox>
                        </div>
                        <div class="col-md-3">
                            <label>Precio</label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="TB_Precio" ReadOnly="true"></asp:TextBox>
                        </div>
                    </div>
                    <div class="btn-group col-md-12 btn-group-justified">
                        <div class="col-md-3">
                            <asp:Button runat="server" CssClass="btn btn-primary btn-group-justified form-control" Text="Comprar" ID="BTN_Comprar" OnClick="BTN_Comprar_Click"></asp:Button>
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
    <!-- end #content -->
</asp:Content>

