'use strict';
$(document).ready(function () {
    grid.load({
        tableId: "#components-table",
        dataUrl: 'Components/LoadComponents',
        deleteUrl: 'Components/DeleteComponent',
        editUrl: 'Components/EditComponent',
        columns: [
            {
                data: function (row, type, set) {                    
                    return row.componentType.name;                    
                },
                title: "Type"
            },
            {
                data: function (row, type, set) {
                    return row.price;
                },
                title: "Price"
            },
        ]
    });

    grid.load({
        tableId: "#component-types-table",
        dataUrl: 'Components/LoadComponentTypes',
    });
});