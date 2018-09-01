//Funcion General Para Redireccionar A La URL Segun El Valor Retornado Por El Servidor
function redireccionar(data) {
    if (data != "0") {
        window.location = data;
    }
};

//Funcion De Redireccionamiento Para La Master De Home 
function redireccionar_Home(url) {
    if (url == "") {
        //Ejecuto Modal
        $('#modal-dialog').modal('show');
    } else {
        window.location = url;
    }
};

//FUNCION DE REDIRECCION DEL REGISTER SEGUN SEA EL CASO
function Redir_Reg_Usr(info) {
    alert(info);
    if (info == "Tu registro se ha sido realizado satisfactoriamente.") {
        window.location = "LoginUsr.aspx";
    }
};

//FUNCION PARA LAS VALIDACIONES AL REGISTRAR UNA EMPRESA
function Redir_Reg_Emp(data,valido) {
    if (valido != 'True') {
        alert(data);
        window.location = "RegistroEmpresa.aspx";
    } else {
        window.location = "LoginUsr.aspx";
    } 
};
//FUNCION PARA REDIRECCIONAR CUANDO EL CORREO EXISTE
function Redir_Reg_Cor_Emp(data) {
    if (data == true) {
        window.location = "RegistroEmpresa.aspx";
    } else {
        window.location = "LoginUsr.aspx";
    }
};
//FUNCION PARA MOSTRAR EL LOG OUT DE LA EMPRESA
function log_out() {
    if (document.getElementById("barra").style.display == "none") {
        document.getElementById("barra").style.display = "block";
    } else {
        document.getElementById("barra").style.display = "none";
    }
    var res;
    res = document.getElementById("barra");
    console.log(res);
}

//FUNCION PARA MOSTRAR El UPDATE IMG DE LA EMPRESA
function show_img() {
    if (document.getElementById("image").style.display == "none") {
        document.getElementById("image").style.display = "block";
    } else {
        document.getElementById("image").style.display = "none";
    }
    var res;
    res = document.getElementById("image");
    console.log(res);
}
