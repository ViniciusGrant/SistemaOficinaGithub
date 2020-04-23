
//Requisição Assincrona


function requisicaoAssincrona(tipoRequisicao, caminhoMetodo, parametroJson, funcaoJsSucesso, funcaoJsErro) {
    
    $.ajax({
        type: tipoRequisicao,
        url: caminhoMetodo,
        async: true,
        data: JSON.stringify(parametroJson),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (Json) {
            funcaoJsSucesso(Json);
        },
        error: function (Json) {
            funcaoJsErro(Json);
        }
    });
};

function verificaPagina() {
    var h = $(location).attr('href');
    var indice = h.split('/').length - 1;
    var loc = h.split('/');
    var l = loc[indice];
    if (l != undefined) {
        var x = l.split('#');
        if (x.length > 1) {
            l = x[0];
        }

    }
    var ll;
    if (loc[indice] != "sicad" && loc[indice] != "") {
        ll = "/" + loc[h.split('/').length - 2] + "/" + l;
    } else {
        ll = "/";
    }

    return ll;
}

function ConfigTbl(tbl, inserirBtnTbl, orderCol) {
    tbl.DataTable({
        //"pageLength": 5,
        "bPaginate": true,
        "autoWidth": false,
        "columnDefs": [{
            "targets": 0,
        }],

        "order": orderCol,

        dom: '<"datatable-header"fBl><"datatable-scroll-wrap"t><"datatable-footer"ip>',
        buttons: {
            buttons: [
                inserirBtnTbl,
            ]
        },

        "oLanguage": {
            "sInfoEmpty": "0 Registros",
            "sInfoFiltered": "",
            "sLengthMenu": "Mostrar _MENU_",
            "sDisplayLength": 50,
            "sSearch": "Filtrar: ",
            "sSearchPlaceholder": "Digite para Filtrar",
            "sZeroRecords": "Nenhum registro correspondente ao critério informado",
            "sInfoEmtpy": "Exibindo 0 a 0 <br />Total: 0",
            "sInfo": "Exibindo de _START_ a _END_ <br />Total: _TOTAL_",
            "oPaginate": {
                "sFirst": "Primeiro",
                "sPrevious": "Anterior",
                "sNext": "Próximo",
                "sLast": "Último"
            }
        }

    });
    // Scrollable datatable
    $('.datatable-scroll-y').DataTable({
        autoWidth: true,
        scrollY: 300
    });
}


function BtnTblCtrlColunas() {
    var btnCtrlColunas = {
        extend: 'colvis',
        text: '<i class="icon-three-bars"></i> <span class="caret"></span>',
        titleAttr: 'Habilitar e Desabilitar Colunas.',
        className: 'btn bg-blue btn-icon',
        columns: ':not(.editarLinhaTbl):not(.editarColTbl):not(.excluirLinhaTbl):not(.excluirColTbl)'
    };
    return btnCtrlColunas;
};

function esconderlinhas() {
    $('#.datatable-clientes').DataTable({
        "columnDefs": [
            {
                "targets": [0],
                "visible": false,
                "searchable": false
            },
            {
                "targets": [1],
                "visible": false
            }
        ]
    });
};
