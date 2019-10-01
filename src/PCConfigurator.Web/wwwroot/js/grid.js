var grid = (function () {
    'use strict';

    var columns = [
        { data: "id", title: "Id" },
        { data: "name", title: "Name" },
        {
            data: null,
            title: "Actions",
            render: function (data, type, row) {
                var editButton = `<button class="btn btn-primary edit-entity" data-id=${data.id}>Edit</button>`;
                var deleteButton = `<button class="btn btn-danger delete-entity" data-id=${data.id}>Delete</button>`;
                return editButton + deleteButton;
            }
        }
    ];

    function load(config) {
        if (config.columns) {
            columns = columns.concat(config.columns);
        }

        var table = $(config.tableId).DataTable({
            serverSide: true,
            ajax: config.dataUrl,
            columns: columns,
            drawCallback: function () {
                $(`${config.tableId} .delete-entity`).click(function (event, a, v, c) {
                    var id = $(this).data('id');
                    console.log(id);

                    $.post(config.deleteUrl, { id: id }, function () {
                        table.ajax.reload();
                    });
                });
            }
        });
    }

    return {
        load: load
    }
}());