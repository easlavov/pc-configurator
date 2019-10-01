$(document).ready(function () {
    grid.load({
        tableId: "#component-types-table",
        dataUrl: 'Management/LoadComponentTypes',
        deleteUrl: 'Management/DeleteComponentType'
    });

    grid.load({
        tableId: "#components-table",
        dataUrl: 'Management/LoadComponents',
        deleteUrl: 'Management/DeleteComponent'
    });
});