$(document).ready(function () {
    grid.load({
        tableId: "#component-types-table",
        dataUrl: 'Components/LoadComponentTypes',
        deleteUrl: 'Components/DeleteComponentType'
    });

    grid.load({
        tableId: "#components-table",
        dataUrl: 'Components/LoadComponents',
        deleteUrl: 'Components/DeleteComponent',
        columns: [
            {
                data: function (row, type, set) {                    
                    return row.componentType.name;                    
                },
                title: "Type"
            }
        ]
    });
});