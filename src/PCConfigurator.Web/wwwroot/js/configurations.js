$(document).ready(function () {
    grid.load({
        tableId: "#configurations-table",
        dataUrl: 'Configurations/Load',
        deleteUrl: 'Configurations/Delete',
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