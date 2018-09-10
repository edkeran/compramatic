<%@ Page Language="C#" AutoEventWireup="true" CodeFile="forgotPass.aspx.cs" Inherits="Presentacion_forgotPass" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>

    <meta charset="utf-8" />
    <title>Compromatic</title>
    <meta content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=no" name="viewport" />
    <meta content="" name="description" />
    <meta content="" name="author" />
    <!-- ================== BEGIN BASE CSS STYLE ================== -->
    <link href="http://fonts.googleapis.com/css?family=Open+Sans:300,400,600,700" rel="stylesheet" />
    <link href="../App_themes/Home/assets/plugins/bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../App_themes/Home/assets/plugins/font-awesome/css/font-awesome.min.css" rel="stylesheet" />
    <link href="../App_themes/Home/assets/css/style.min.css" rel="stylesheet" />
    <link href="../App_themes/Home/assets/css/style-responsive.min.css" rel="stylesheet" />
    <link href="../App_themes/Home/assets/css/theme/default.css" id="theme" rel="stylesheet" />
    <link href="../App_themes/Home/assets/css/animate.min.css" rel="stylesheet" />
    <!-- ================== END BASE CSS STYLE ================== -->
    <link href="../App_Themes/Assets/font-awesome-4.1.0/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <link href="../App_Themes/Assets/assets/plugins/bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../App_Themes/Assets/assets/plugins/font-awesome/css/font-awesome.min.css" rel="stylesheet" />
    <link href="../App_Themes/Assets/assets/css/style.min.css" rel="stylesheet" />
    <link href="../App_Themes/Assets/assets/css/style-responsive.min.css" rel="stylesheet" />
    <link href="../App_Themes/Assets/assets/css/animate.min.css" rel="stylesheet" />
    <!-- ================== BEGIN BASE JS ================== -->
    <script src="../App_Themes/Assets/assets/plugins/pace/pace.min.js"></script>
    <script src='https://code.jquery.com/jquery-2.2.4.min.js'> </script>
    <script src='https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js'></script>
    <script src="../App_Themes/JS-Redireccion/Funiones.js"></script>
    <!-- ================== END BASE JS ================== -->
    <style type="text/css">
        .auto-style1 {
            text-align: center;
        }
        .auto-style2 {
            width: 100%;
        }
        .auto-style3 {
            display: block;
            width: 100%;
            height: 34px;
            font-size: 14px;
            line-height: 1.42857143;
            color: #555;
            border-radius: 4px;
            -webkit-box-shadow: none;
            box-shadow: none;
            -webkit-transition: border-color ease-in-out .15s, -webkit-box-shadow ease-in-out .15s;
            -o-transition: border-color ease-in-out .15s, box-shadow ease-in-out .15s;
            transition: border-color ease-in-out .15s, box-shadow ease-in-out .15s;
            border: 1px solid #ccd0d4;
            margin-left: 0;
            padding: 6px 12px;
            background-color: #fff;
            background-image: none;
        }
        .auto-style4 {
            width: 50%;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="auto-style1">
            <h2>Bienvenido a la pagina de recuperacion de contraseña</h2>
            <br />
            <table class="auto-style2">
                <tr>
                    <td class="auto-style4">
                        <h4 class="auto-style2">Ingrese Su Correo Electronico</h4>
                    </td>
                    <td>
                        <asp:TextBox ID="TB_Correo" runat="server" CssClass="auto-style3"></asp:TextBox>
                    </td>
                </tr>
            </table>
            <br />
            <asp:Button ID="Button1" runat="server" Text="Aceptar" class="btn btn-primary btn-block btn-lg" OnClick="Button1_Click"/>
             <br />
            <asp:HyperLink ID="HL_Index" runat="server" NavigateUrl="~/Presentacion/Home.aspx">Volver a la pagina principal</asp:HyperLink>
        </div>
    </form>
</body>
</html>
