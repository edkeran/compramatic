<%@ page title="" language="C#" masterpagefile="~/Presentacion/DashEmpresa.master" autoeventwireup="true" inherits="Presentacion_AumentarMembresia, App_Web_4kwpqrqr" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!-- begin page-header -->
    <h1 class="page-header" id="H1_Mem" runat="server">Membresia</h1>
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
                    <h4 class="panel-title" id="H4_Pln_Act" runat="server">Plan Actual</h4>
                </div>
                <div class="panel-body">
                    <div class="col-md-12 form-group">
                        <div class="col-md-4">
                            <label id="LB_Act_Date" runat="server">Fecha Inicial</label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="TB_Inicial" ReadOnly="true"></asp:TextBox>
                        </div>
                        <div class="col-md-4">
                            <label runat="server" id="LB_End_Date">Fecha Final</label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="TB_Final" ReadOnly="true"></asp:TextBox>
                        </div>
                        <div class="col-md-4">
                            <label runat="server" id="LB_Esta">Estado</label>
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
                    <h4 class="panel-title" id="H4_Aum_Mem" runat="server">Aumentar Membresia</h4>
                </div>
                <div class="panel-body">
                    <div class="col-md-12 form-group">
                        <div class="col-md-3">
                            <label id="LB_Tip" runat="server">Tipos</label>
                            <asp:DropDownList runat="server" ID="DDL_Memebresia" CssClass="form-control" AutoPostBack="true" DataSourceID="ODS_Membresia" DataTextField="nomMembresia" DataValueField="idTipo_membresia" OnSelectedIndexChanged="DDL_Memebresia_SelectedIndexChanged"></asp:DropDownList>
                            <asp:ObjectDataSource runat="server" ID="ODS_Membresia" SelectMethod="MostrarTipos" TypeName="Logica.L_Componentes"></asp:ObjectDataSource>
                        </div>
                        <div class="col-md-3">
                            <label runat="server" id="LB_New_In">Nuevo Inicio</label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="TB_FechaInicio" ReadOnly="true"></asp:TextBox>
                        </div>
                        <div class="col-md-3">
                            <label id="LB_New_En" runat="server">Nuevo Final</label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="TB_FechaFinal" ReadOnly="true"></asp:TextBox>
                        </div>
                        <div class="col-md-3">
                            <label id="price" runat="server">Precio</label>
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

