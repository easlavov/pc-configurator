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

    var formData = gatherFormData();

    if (formData.components.length == 0) {
        alert('You must select at least one component to save the configuration!');
        return;
    }
    
    $.post('Edit', { name: formData.name, components: formData.components, id: formData.id }).done(function () {
        window.location = '/'
    });
});