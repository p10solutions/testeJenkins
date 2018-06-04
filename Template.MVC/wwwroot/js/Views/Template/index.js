let $tabelaTemplate;

$(function () {
    $tabelaTemplate = $("#tabelaTemplate").DataTable({
        "ajax": {
            "url": "/Cadastro/CarregarDataTableTemplate",
            "type": "POST"
        },
        "processing": true,
        "serverSide": true,
        "searching": true,
        "aLengthMenu": [[5, 10, 25, 50], [5, 10, 25, 50]],
        "oLanguage": {
            "sEmptyTable": "Nenhum registro encontrado",
            "sInfo": "Mostrando de _START_ até _END_ de _TOTAL_ registros",
            "sInfoEmpty": "Mostrando 0 até 0 de 0 registros",
            "sInfoFiltered": "(Filtrados de _MAX_ registros)",
            "sInfoPostFix": "",
            "sInfoThousands": ".",
            "sLengthMenu": "_MENU_ resultados por página",
            "sLoadingRecords": "Carregando...",
            "sProcessing": "Processando...",
            "sZeroRecords": "Nenhum registro encontrado",
            "sSearch": "Pesquise por Nome:",
            "oPaginate": {
                "sNext": "Próximo",
                "sPrevious": "Anterior",
                "sFirst": "Primeiro",
                "sLast": "Último"
            },
            "oAria": {
                "sSortAscending": ": Ordenar colunas de forma crescente",
                "sSortDescending": ": Ordenar colunas de forma decrescente"
            }
        },
        "aaSorting": [[0, "asc"]],
        "columnDefs":
            [
                { "targets": 0, "data": "nome" },
                {
                    "data": "ativo",
                    "targets": 1,
                    "render": function (row, type, full, meta) {
                        if (full.ativo)
                            return '<i class="fa fa-check"></i></span>';

                        return '<i class="fa fa-times"></i></span>';
                    }
                },
                {
                    "targets": 2,
                    "render": function (row, type, full, meta) {

                        var botaoDetalhes = '<div class="dropdown">';
                        botaoDetalhes += '<button class="btn btn-secondary dropdown-toggle" type="button" id="dropdownMenuButton" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">';
                        botaoDetalhes += 'Ações</button >';
                        botaoDetalhes += '<div class="dropdown-menu" aria-labelledby="dropdownMenuButton">'

                        botaoDetalhes += '<a class="dropdown-item" href="/cadastro/edicao/' + full.id + '"><i class="far fa-edit"></i>&nbsp;Editar</a>';
                        botaoDetalhes += '<a class="dropdown-item excluir" data-id="' + full.id + '"><i class="fa fa-times"></i>&nbspExcluir</a>';

                        botaoDetalhes += '</div>'
                        botaoDetalhes += '</div>'

                        return botaoDetalhes;
                    }
                }
            ]
        , "fnDrawCallback": function (oSettings, json) {
            $("#tabelaTemplate a.excluir").click(function () {
                var id = $(this).data().id;

                $.post("/cadastro/remocao/" + id)
                    .done(function (retorno) {
                        alerta.NotificarSucessoTemporario(null, retorno.mensagem);

                        if (retorno.sucesso)
                            $tabelaTemplate.ajax.reload();
                    })
                    .fail(function () {
                        alerta.NotificarErro(null, "Ocorreu um erro ao tentar remover o template");
                    });

            });
        }
    });

});