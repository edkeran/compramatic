//CREACION DEL TIMER
window.setInterval("reportar_session()", 10000);

function reportar_session() {
    //REPORTAR SESSION DEL USER
    $.ajax({
        type: "POST",
        url: "Home.aspx/get_idSession",
        data: {},
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: true,
        success: VerifySessionState,
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            console.log(textStatus + ": " + XMLHttpRequest.responseText);
        }
    });
    console.log("REPORTE");
}


function VerifySessionState(result) {
    console.log(result);
}