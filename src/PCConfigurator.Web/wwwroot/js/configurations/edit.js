var configurationId;

function loadConfiguration(id) {
    $.getJSON("/Components/LoadAllComponents").done(function (response) {

        componentsByType = response;
        types = _.pluck(componentsByType, 'Key')

        var components = _.chain(componentsByType).pluck('Value').flatten().value();
        components.forEach(function (component) {
            componentsPrice[component.Id] = component.Price;
        });

        components.forEach(function (component) {
            componentsType[component.Id] = component.ComponentType.Id;
        });

        $.getJSON("/Configurations/LoadById", { id: id }).done(function (response) {
            $nameBox.val(response.name)
            configurationId = response.id;
            response.components.forEach(function (comp) {
                addNewComponent(comp);
            });
        });        
    });
}

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

    var name = $nameBox.val();

    $.post('Edit', { name: name, components: selectedComponents, id: configurationId }).done(function () {
        window.location = '/'
    });
});