$(function () {
    var slider = $("#slider").slider({
        value: 500,
        min: 0,
        max: 1000,
        step: 50,
        start: function (event, ui) {
            console.log(ui);
            $(ui.handle).find('.ui-slider-tooltip').show();
        },
        stop: function (event, ui) {
            $(ui.handle).find('.ui-slider-tooltip').hide();
        },
        slide: function (event, ui) {
            $(ui.handle).find('.ui-slider-tooltip').text(ui.value);
        },
        create: function (event, ui) {
            var tooltip = $('<div class="ui-slider-tooltip" />').css({
                position: 'absolute',
                top: -25,
                left: -10
            });

            $(event.target).find('.ui-slider-handle').append(tooltip);
        },
        change: function (event, ui) { }
    });
});
