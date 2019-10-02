'use strict';

$.getJSON("/Components/LoadAllComponents").done(function (response) {      

    componentsByType = response;
    types = _.pluck(componentsByType, 'Key')

    var components = _.chain(componentsByType).pluck('Value').flatten().value();
    components.forEach(function (component) {
        componentsPrice[component.Id] = component.Price;
    });

    addNewComponent();
});

$form.submit(function (e) {
    e.preventDefault();

    var formData = gatherFormData();

    if (formData.components.length == 0) {
        alert('You must select at least one component to save the configuration!');
        return;
    }

    $.post('Add', { name: formData.name, components: formData.components }).done(function () {
        window.location = '/'
    });
});