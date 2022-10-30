var _Estacion = {
    Id: 0,
    Cantidad: 0,
    Total: 0
}
$(function () {
    var focus = false;
    var listPart = '';
    var listStation = '';
   
    ListDMC(); 
    Reloj()
    window.onkeydown = function (event, index) {
        if (event.keyCode == '32') {
            console.log('Hola kj');
        }
    }
    $("#_Parts").on("click", "input", function (e) {
        var id = this.id
        id = id.substring(1, id.length)
        $.get("/ControlShipping/UpdatePart", { ID: id, Val: this.checked });
    }); 
    _getProjects();
    $("#SelProject").change(function () {
        _getStation();
    });
    $("#SelStation").change(function () {
        _getParts();
        
    });
    document.getElementById("EnterDMC").onkeyup = function (event) {    
    }
    $('#ModalConfig').modal('show')
    
});
function Reloj() {
    if (focus == true) {
        setInterval('focusinput()', 1000);
    }
}
function focusinput() { 
        $('#EnterDMC').focus();
        document.getElementById("EnterDMC").focus();
}
function EntradaDMC() {
    let DMC = $('#EnterDMC').val();
    $('#_ViewDMC').text(DMC);
    $('#EnterDMC').val(''); 
}
function _getProjects() {
    $.get("/ControlShipping/GetProjects", { ID: 1 }, function (data) {
        $("#SelProject").empty();  //se limpia Select
        $.each(data, function (index, row) {
            $("#SelProject").append("<option value='" + row.Id + "'>" + row.Proyecto + "</option>");
        });
        _getStation();
    });
}
function _getStation() {
    $.get("/ControlShipping/GetEstation", { ID: $("#SelProject").val() }, function (data) {
        $("#SelStation").empty();  //se limpia Select
        $.each(data, function (index, row) {
            $("#SelStation").append("<option value='" + row.Id + "'>" + row.Nombre + "</option>");
        });
        _getParts();
    }); 
    _Estacion.Id = $("#SelStation option:selected").val();
}
function _getParts() {
    $.get("/ControlShipping/GetParts", { ID: $("#SelStation").val() }, function (data) {
        $("#_Parts").empty();  //se limpia Select
        $.each(data, function (index, row) { 
            $("#_Parts").append( '<div class="col-4 input-group mb-3">'
                + '<div class="input-group-text">'
                + '<input class="chk" type="checkbox" id="c' + row.Id + '"></div>'
                + '<label _chkPart() class="form-control" for="c' + row.Id + '">'
                + row.Parte + '</label></div>'
            );
            $("#c"+row.Id).prop('checked', row.Estatus);
        });//se llena Select 
    });
    _Estacion.Id = $("#SelStation option:selected").val();
    _Estacion.Nombre = $("#SelStation option:selected").text();
}
function BtnParts() {
    $.get("/ControlShipping/btnPart", { ID: $("#SelStation").val() }, function (data) {
        $("#btnparts").empty();  //se limpia contenedor
        $.each(data, function (index, row) {
            $("#btnparts").append(
                '<div class="col-6 p-1">'
                + '<button onclick="GetList(' + row.Id + ')" class="btn btn-lg btn-outline-dark btn-block m-1">' + row.CMS + ' <i class="fa fa-list"></i></button>'
                +'</div>' 
            ); 
        });//se agregando objetos
    }); 
}
function SettingStation() {
    $('#idestacion').text(_Estacion.Id);
    BtnParts();
    var title = $("#SelProject option:selected").text() + ' - ' + $("#SelStation option:selected").text(); 
    $('#_title').text(title);
    $('#ModalConfig').modal('hide')
    focus = true;
    
}
//--------------------------------------------------------------------------------------------------------
function ListDMC() {
    var Pallet = {
        Estacion: 'LT-HD1',
        Parte: '3V0A-ZZ',
        Cantidad: 15,
        DMC: ''
    }
    $.ajax({
        url: "/ControlShipping/GetListDMC/",
        type: "POST",
        contentType: "application/json;charset=utf-8",
        data: JSON.stringify(Pallet),
        dataType: "json",
        success: function (result) {
            var table = '';
            var inc = 1
            $.each(result, function (key, item) {
                table += '<tr>';
                table += '<td >' + inc + '</td>';
                table += '<td >' + item.DMC + '</td>'; 
                table += '</tr>';
                inc++;
            });
            $('tbody').html(table); 
        },
        error: function (errormessage) {
        }
    });
}
function GetList(Id) {
    $.get("/ControlShipping/GetListDMC", { Id: Id});
    //$("#btnparts").on("click", "button", function (e) {
    //    var id = this.id
    //});
}

function EvaluaDMC() {
    var Pallet = {
        Estacion: 'LT-HD1',
        Parte: '3V0A-ZZ',
        Cantidad: 15,
        DMC: ''
    }
    $.ajax({
        url: "/ControlShipping/EvaluaPallet/",
        type: "POST",
        contentType: "application/json;charset=utf-8",
        data: JSON.stringify(Pallet),
        dataType: "json",
        success: function (result) {
            if (result.Tipo == '0') {
                OK();
            } else {
                $('#Estatus').text('Esta pieza ya esta en sistema');
            }
        },
        error: function (errormessage) {
        }
    });
} 
