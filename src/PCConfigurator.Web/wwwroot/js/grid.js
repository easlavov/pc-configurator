var grid = (function () {
    'use strict';

    function load(config) {
        var table = $(config.tableId).DataTable({
            serverSide: true,
            ajax: config.dataUrl,
            columns: [
                { data: "id", title: "Id" },
                { data: "name", title: "Name" },
                {
                    data: null,
                    title: "Actions",
                    render: function (data, type, row) {
                        var editButton = `<button class=edit-entity data-id=${data.id}>Edit</button>`;
                        var deleteButton = `<button class=delete-entity data-id=${data.id}>Delete</button>`;
                        return editButton + deleteButton;
                    }
                },

            ],
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