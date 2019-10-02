'use strict';

var grid = (function () {

    var requiredColumns = [
        { data: "id", title: "Id" },
        { data: "name", title: "Name" }
    ];

    var actionsColumn = {
        data: null,
        title: "Actions",
        render: function (data, type, row) {
            var editButton = `<button class="btn btn-primary edit-entity" data-id=${data.id}>Edit</button>`;
            var deleteButton = `<button class="btn btn-danger delete-entity" data-id=${data.id}>Delete</button>`;
            return editButton + deleteButton;
        }
    };

    function load(config) {
        var columns = requiredColumns;
        if (config.columns) {
            columns = columns.concat(config.columns);
        }

        columns = columns.concat(actionsColumn);

        var table = $(config.tableId).DataTable({
            serverSide: true,
            ajax: config.dataUrl,
            columns: columns,
            drawCallback: function () {
                if (config.deleteUrl) {
                    var $button = $(`${config.tableId} .delete-entity`)
                    $button.click(function (event, a, v, c) {
                        var id = $(this).data('id');

                        $.post(config.deleteUrl, { id: id }, function () {
                            table.ajax.reload();
                        });
                    });
                } else {
                    var $button = $(`${config.tableId} .delete-entity`)
                    $button.remove();
                }                

                if (config.editUrl) {
                    var $button = $(`${config.tableId} .edit-entity`)
                    $button.click(function (event, a, v, c) {
                        var id = $(this).data('id');

                        window.location = config.editUrl + `?id=${id}`;
                    });
                } else {
                    var $button = $(`${config.tableId} .edit-entity`)
                    $button.remove();
                }          
            },
            language: {
                loadingRecords: '&nbsp;',
                processing: '<div class="spinner"></div>'
            },
            searching: false,
            ordering: false
        });
    }

    return {
        load: load
    }
}());