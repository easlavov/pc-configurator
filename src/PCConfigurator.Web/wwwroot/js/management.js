// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function () {
    var table = $('#component-types-table').DataTable({
        serverSide: true,
        ajax: 'Management/LoadComponentTypes',
        columns: [
            { data: "id", title: "Id" },
            { data: "name", title: "Name" },
            {
                data: null,
                title: "Actions",
                render: function (data, type, row) {
                    var editButton = `<button class=edit-component-type data-id=${data.id}>Edit</button>`;
                    var deleteButton = `<button class=delete-component-type data-id=${data.id}>Delete</button>`;
                    return editButton + deleteButton;
                }
            },

        ],
        drawCallback: function () {
            $(".delete-component-type").click(function (event, a, v, c) {
                var id = $(this).data('id');
                console.log(id);

                $.post("Management/DeleteComponentType", { id: id }, function () {
                    table.ajax.reload();
                });
            });
        }
    });
});