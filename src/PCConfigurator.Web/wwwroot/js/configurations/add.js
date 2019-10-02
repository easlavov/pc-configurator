$.getJSON("/Components/LoadAllComponents").done(function (response) {      

    componentsByType = response;
    types = _.pluck(componentsByType, 'Key')

    var components = _.chain(componentsByType).pluck('Value').flatten().value();
    components.forEach(function (component) {
        componentsPrice[component.Id] = component.Price;
    });

    addNewComponent();
    var k = 5;
});

$form.submit(function (e) {
    e.preventDefault();

    var selectedComponents = []
    $components.forEach(function ($component) {
        var id = $component.find('.component-select').val();
        if (!id) return;
        var quantity = $component.find('.quantity').val();
        selectedComponents.push({
            id: id,
            quantity: quantity
        });
    });

    if (selectedComponents.length == 0) {
        alert('You must select at least one component to save the configuration!');
        return;
    }

    var name = $nameBox.val();

    $.post('Add', { name: name, components: selectedComponents }).done(function () {
        window.location = '/'
    });
});