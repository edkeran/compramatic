<%@ Page Title="" Language="C#" MasterPageFile="~/Presentacion/MasterSuperAdministrador.master" AutoEventWireup="true" CodeFile="~/LogicaPresentacion/Administrador/AdministrarIdiomas.aspx.cs" Inherits="Presentacion_AdministrarIdiomas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="content" class="content">
        <ol class="breadcrumb pull-right">
            <li><a href="javascript:;">Home</a></li>
            <li><a href="javascript:;" id="adm" runat="server">Administrar</a></li>
            <li class="active" id="idiom" runat="server">Idiomas</li>
        </ol>
      <h1 class="page-header" id="idiom1" runat="server">Idiomas <small id="comp_our" runat="server"> nuestro compromiso es contigo</small></h1>
        <div class="row">
            <asp:ScriptManager runat="server"></asp:ScriptManager>
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <div class="col-md-6 ui-sortable">
                        <div class="panel panel-inverse">
                            <div class="panel-heading">
                                <div class="panel-heading-btn">
                                    <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-default" data-click="panel-expand"><i class="fa fa-expand"></i></a>
                                    <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-success" data-click="panel-reload"><i class="fa fa-repeat"></i></a>
                                    <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-warning" data-click="panel-collapse"><i class="fa fa-minus"></i></a>
                                    <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-danger" data-click="panel-remove"><i class="fa fa-times"></i></a>
                                </div>
                                <h4 class="panel-title" runat="server" id="all_cont">Traducir Controles</h4>
                            </div>
                            <div class="panel-body">
                                <asp:Panel ID="Panel2" runat="server">
                                    <div class="col-md-9">
                                    <asp:Label runat="server" ID="LB_DDL1">Seleccione Un Idioma</asp:Label>
                                    <asp:DropDownList runat="server" ID="DDL_Idiomas" DataSourceID="ODS_Idioma" DataTextField="nombre_idioma" DataValueField="id_idioma"></asp:DropDownList>
                                     </div>
                                    <br /><br />
                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                        <ContentTemplate>
                                    <div class="col-md-12">
                                    <asp:Label runat="server" ID="LB_Form">Selecciona Un Formulario</asp:Label>
                                    <asp:DropDownList runat="server" ID="DLL_forms" DataSourceID="ODS_Form" DataTextField="nombre_form" DataValueField="id_form" OnSelectedIndexChanged="DLL_forms_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                    </div>
                                    <br /><br />
                                    <div class="col-md-12">
                                    <asp:Label runat="server" ID="LB_Contr">Selecciona Un Control</asp:Label>
                                    <asp:DropDownList runat="server" ID="DDL_Controles" OnSelectedIndexChanged="DDL_Controles_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                    </div>
                                    <br /><br />
                                    <div class="col-md-12">
                                    <asp:Label runat="server" ID="LB_inf">Texto Control En Español:</asp:Label>
                                    <asp:Label runat="server" ID="LB_Data"></asp:Label>
                                    </div>
                                    <br /><br />
                                    <div class="col-md-12">
                                        <asp:Label runat="server" ID="LB_TB">Ingresa La Traduccion:</asp:Label>
                                        <asp:TextBox ID="TB_Trad" runat="server" placeholder="Ingresa Una Traduccion"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ForeColor="Red" ControlToValidate="TB_Trad" runat="server" ErrorMessage="Error campo vacio" ValidationGroup="S_Idiom"></asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ForeColor="Red" ControlToValidate="TB_Trad" ErrorMessage="Error, caracteres" ToolTip="La cadena contiene caracteres no validos" ValidationExpression="^[a-zA-Z ñÑáéíóú]*$" ValidationGroup="S_Idiom"></asp:RegularExpressionValidator>
                                    </div>
                                    <br /><br />
                                    <div class="col-md-12">
                                        <asp:Button ID="Button2" runat="server" class="btn btn-sm btn-success" Text="Registrar Traduccion" ValidationGroup="S_Idiom"  OnClick="Button2_Click"/>
                                    </div>
                                    </ContentTemplate>
                                    <Triggers>
                                      <asp:AsyncPostBackTrigger ControlID="DLL_forms" EventName="selectedindexchanged" />
                                      <asp:AsyncPostBackTrigger ControlID="DDL_Controles" EventName="selectedindexchanged" />
                                    </Triggers>
                                    </asp:UpdatePanel>
                                    <asp:ObjectDataSource ID="ODS_Form" runat="server" SelectMethod="traer_formulario" TypeName="Logica.L_Idioma"></asp:ObjectDataSource>
                                    <asp:ObjectDataSource ID="ODS_Idioma" runat="server" SelectMethod="traer_idioma" TypeName="Logica.L_Idioma"></asp:ObjectDataSource>
                                </asp:Panel>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6 ui-sortable">
                        <div class="panel panel-warning">
                            <div class="panel-heading">
                                <div class="panel-heading-btn">
                                    <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-default" data-click="panel-expand"><i class="fa fa-expand"></i></a>
                                    <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-success" data-click="panel-reload"><i class="fa fa-repeat"></i></a>
                                    <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-warning" data-click="panel-collapse"><i class="fa fa-minus"></i></a>
                                    <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-danger" data-click="panel-remove"><i class="fa fa-times"></i></a>
                                </div>
                                <h4 class="panel-title" id="reg_idm" runat="server">Regitrar nuevo Idioma</h4>
                            </div>
                            <div class="panel-body bg-orange text-white">
                                <asp:Panel ID="Panel3" runat="server">
                                    <div class="form-horizontal">
                                        <div class="form-group">
                                            <asp:Label ID="Label1" class="col-md-3 control-label" runat="server" Text="Nombre Idioma."></asp:Label>
                                            <div class="col-md-9">
                                                <asp:TextBox ID="Nombre_Idioma" class="form-control" runat="server" placeHolder="Nombre Idioma" MaxLength="20"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ForeColor="Red" ControlToValidate="Nombre_Idioma" runat="server" ErrorMessage="Error campo vacio" ValidationGroup="N_Idioma"></asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ForeColor="Red" ControlToValidate="Nombre_Idioma" ErrorMessage="Error, caracteres" ToolTip="La cadena contiene caracteres no validos" ValidationExpression="^[a-zA-Z ñÑáéíóú]*$" ValidationGroup="N_Idioma"></asp:RegularExpressionValidator>
                                            </div>
                                            <asp:Label ID="Label2" class="col-md-3 control-label" runat="server" Text="Terminacion Idioma."></asp:Label>
                                            <div class="col-md-9">
                                                <asp:TextBox ID="Termin_Idioma" class="form-control" runat="server" placeHolder="Terminacion Idioma (es-co)" MaxLength="20"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ForeColor="Red" ControlToValidate="Termin_Idioma" runat="server" ErrorMessage="Error campo vacio" ValidationGroup="N_Idioma"></asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ForeColor="Red" ControlToValidate="Termin_Idioma" ErrorMessage="Error, caracteres" ToolTip="La cadena contiene caracteres no validos" ValidationExpression="^[a-zA-Z ñÑáéíóú]*$" ValidationGroup="N_Idioma"></asp:RegularExpressionValidator>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <div class="col-md-9">
                                                <asp:Button ID="Button1" runat="server" class="btn btn-sm btn-success" Text="Registrar Idioma" ValidationGroup="N_Idioma"  OnClick="Button1_Click"/>
                                            </div>
                                        </div>
                                    </div>
                                </asp:Panel>
                            </div>
                        </div>
                    </div>


                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>

