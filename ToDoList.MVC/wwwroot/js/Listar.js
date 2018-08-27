$(document).ready(function () {

    var tableAll = $("#tableAll").DataTable({
        "ajax": "Grid",
        "searching": false,
        "columns": [
            {
                "data": "status",
                "render": function (data, type, row) {
                    if (type === "display") {
                        return '<input type="checkbox" class="editor-active">';
                    }
                    return data;
                },
            },
            {
                "data": "descricao",
                "render": function (data, type, row) {

                    if (type === "display" && row.status == 1) {
                        return "<span style=text-decoration:line-through>" + row.descricao + "</span>";
                    }
                    else if (type === "display" && new Date(row.data).toDateString() == new Date().toDateString()) {
                        return "<span style=color:red>" + row.descricao + "</span>";
                    }
                    else
                        return data;
                },

            },
            {
                "data": "data",
                "render": function (data, type, row) {
                    if (type === "display") {
                        if (new Date(row.data).toDateString() == new Date().toDateString() && row.status != 1) {
                            return "<span style=color:red>" + formatarData(data) + "</span>";

                        } else {
                            return formatarData(data);
                        }
                    }
                    return data;
                },
            },
        ],
        "paging": false,
        "info": false,
        rowCallback: function (row, data) {
            $("input.editor-active", row).prop("checked", data.status == 1);
            $("input.editor-active", row).prop("disabled", data.status == 1);
            $("input.editor-active", row).prop("id", data.id);
        }
    });

    var tableDone = $("#tablePronto").DataTable({
        "ajax": "Grid?query=done",
        "searching": false,
        "columns": [
            {
                "data": "descricao",
                "render": function (data, type, row) {
                    if (type === "display" && row.status == 1) {
                        return "<span style=text-decoration:line-through>" + row.descricao + "</span>";
                    }
                    return data;
                },

            },
            {
                "data": "data",
                "render": function (data, type, row) {
                    if (type === "display") {

                        return formatarData(data);
                    }
                    return data;
                },
            },
        ],
        "paging": false,
        "info": false
    });

    var tableAfazer = $("#tableAfazer").DataTable({
        "ajax": "Grid?query=todo",
        "searching": false,
        "columns": [
            { "data": "descricao" },
            {
                "data": "data",
                "render": function (data, type, row) {
                    if (type === "display") {
                        return formatarData(data);
                    }
                    return data;
                },
            },
        ],
        "paging": false,
        "info": false
    });

    $("#tableAll").on("click", "input.editor-active", function () {
        AtualizarTarefa(this.id);
        tableAll.ajax.reload();
        tableAfazer.ajax.reload();
        tableDone.ajax.reload();
    });
});


function AtualizarTarefa(id) {
    $.ajax({
        url: "AtualizarTarefa/" + id,
        async: false
    }).done(function () {
        alert("Tarefa Concluída");

    }).fail(function () {
        alert("Falha na atualização da tarefa");

    });

    return false;
}

function formatarData(date) {
    var d = new Date(date),
        month = '' + (d.getMonth() + 1),
        day = '' + d.getDate(),
        year = d.getFullYear();

    if (month.length < 2) month = '0' + month;
    if (day.length < 2) day = '0' + day;

    return [day, month, year].join('/');
}