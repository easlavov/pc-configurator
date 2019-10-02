$.getJSON("/Components/LoadAllComponents").done(function (response) {      

    componentsByType = response;
    //componentTypes = _.chain(components).pluck('componentType').uniq(function (x) { return x.id; }).value();
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
        var quantity = $component.find('.quantity').val();
        selectedComponents.push({
            id: id,
            quantity: quantity
        });
    });

    var name = $nameBox.val();

    $.post('Add', { name: name, components: selectedComponents }).done(function () {
        window.location = '/'
    });
});