'use strict';

$(document).ready(function () {
    grid.load({
        tableId: "#configurations-table",
        dataUrl: 'Configurations/Load',
        deleteUrl: 'Configurations/Delete',
        editUrl: 'Configurations/Edit',
        columns: [
            {
                data: function (row, type, set) {
                    return row.totalPrice;
                },
                title: "Total price"
            }
        ]
    });
});