var counter = 0;
var components = [];
var types = [];
var componentsByType = [];
var $form = $('#configuration-form');
var $nameBox = $('#name');
var $componentContainer = $('#components-box')

function addNewComponent() {
    var $container = $('<div>');
    $container.addClass('form-group');
    $container.data('row', counter);
    var $typeSelect = generateTypeSelect();
    var $componentSelect = $('<select>');
    $componentSelect.addClass('component-select');
    $container.append($typeSelect);
    $container.append($componentSelect);
    $componentContainer.append($container);
    counter++;

    $typeSelect.change(function (a, b, c) {
        var selectedType = $(this).val();
        populateComponentSelect(selectedType);
        console.log(selectedType)
    });

    function populateComponentSelect(type) {
        var componentsOfSelectedType = _.find(componentsByType, function (obj) {
            return obj.Key.Id == type
        }).Value;

        $componentSelect.empty();
        componentsOfSelectedType.forEach(function (component) {
            var $option = $('<option>');
            $option.val(component.Id);
            $option.text(component.Name);
            $componentSelect.append($option)
        });

        var k = 5;
    }
}

function generateTypeSelect() {
    var $select = $('<select>');
    $select.addClass('type-select');
    $select.append($('<option>'));
    types.forEach(function (type) {
        var $option = $('<option>');
        $option.val(type.Id);
        $option.text(type.Name);
        $select.append($option);
    });

    return $select;
}

$.getJSON("/Components/LoadAllComponents").done(function (response) {      

    componentsByType = response;
    //componentTypes = _.chain(components).pluck('componentType').uniq(function (x) { return x.id; }).value();
    types = _.pluck(componentsByType, 'Key')
    addNewComponent();
    var k = 5;
});

$('#add-component-btn').click(function (event) {    
    addNewComponent();
})

$form.submit(function (e) {
    e.preventDefault();

    var selectedComponentsIds = []
    var name = $nameBox.val();
    var selects = $('.component-select')
    selects.each(function () {
        var val = $(this).val()
        selectedComponentsIds.push(val);
    });

    $.post('Add', { name: name, componentIds: selectedComponentsIds }).done(function () {
        console.log('success!')
    });
});