var counter = 0;
var components = [];
var types = [];
var componentsByType = [];
var componentsPrice = {};
var $form = $('#configuration-form');
var $nameBox = $('#name');
var $componentContainer = $('#components-box')
var $totalPrice = $('#total-price')

function addNewComponent() {
    var $container = $('<div>');
    $container.addClass('form-group');
    $container.data('row', counter);

    var $typeSelect = generateTypeSelect();

    var $componentSelect = $('<select>');
    $componentSelect.addClass('component-select');

    var $quantitySelector = $('<input>');
    $quantitySelector.addClass('quantity');
    $quantitySelector.attr('type', 'number');
    $quantitySelector.attr('min', '0');
    $quantitySelector.attr('max', '10');
    $quantitySelector.attr('step', '1');
    $quantitySelector.val('0');

    var $individualPrice = $('<input>');
    $individualPrice.addClass('individual-price');
    $individualPrice.val(0);
    $individualPrice.text('N/A');

    var $accumulatedPrice = $('<input>');
    $accumulatedPrice.addClass('accumulated-price');
    $accumulatedPrice.text('N/A');

    $container.append($typeSelect);
    $container.append($componentSelect);
    $container.append($individualPrice);
    $container.append($quantitySelector);
    $container.append($accumulatedPrice);

    $componentContainer.append($container);
    counter++;

    $typeSelect.change(function (a, b, c) {
        var selectedType = $(this).val();
        populateComponentSelect(selectedType);
    });

    $componentSelect.change(function (a, b, c) {
        var selectedComponent = $(this).val();
        var individualPrice = componentsPrice[selectedComponent];
        $individualPrice.data('price', individualPrice | 0);
        $individualPrice.val(individualPrice);
        $individualPrice.trigger('change');
    });

    $individualPrice.change(function () {
        recalculateAccumulatedPrice();
    });

    $quantitySelector.change(function () {
        recalculateAccumulatedPrice();
    });

    $accumulatedPrice.change(function () {
        calculateTotalPrice();
    });

    function calculateTotalPrice() {
        var total = 0;
        $('.accumulated-price').each(function () {
            total += parseInt($(this).val());
        });

        $totalPrice.empty();
        $totalPrice.text(total);
    }

    function recalculateAccumulatedPrice() {
        var individualPrice = parseInt($individualPrice.data('price'));
        var quantity = parseInt($quantitySelector.val());
        var accumulatedPrice = individualPrice * quantity;
        $accumulatedPrice.val(accumulatedPrice);
        $accumulatedPrice.text(accumulatedPrice);
        $accumulatedPrice.trigger('change');
    }

    function populateComponentSelect(type) {
        var componentsOfSelectedType = _.find(componentsByType, function (obj) {
            return obj.Key.Id == type
        }).Value;

        $componentSelect.empty();
        $componentSelect.append($('<option>'))
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

    var components = _.chain(componentsByType).pluck('Value').flatten().value();
    components.forEach(function (component) {
        componentsPrice[component.Id] = component.Price;
    });

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