$(document).ready(function () {
    grid.load({
        tableId: "#configurations-table",
        dataUrl: 'Configurations/Load',
        deleteUrl: 'Configurations/Delete'
    });
});