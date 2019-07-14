// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

// Credit to https://codepen.io/faur/pen/WXzQxN

(function ($) {
    $(document).ready(function () {
        // amount slider
        $('.amount-input-range').each(function () {
            var value = $(this).attr('data-slider-value');
            var separator = value.indexOf(',');
            if (separator !== -1) {
                value = value.split(',');
                value.forEach(function (item, i, arr) {
                    arr[i] = parseFloat(item);
                });
            } else {
                value = parseFloat(value);
            }
            $(this).slider({
                formatter: function (value) {
                    console.log(value);
                    return '$' + value.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",");
                },
                min: parseFloat($(this).attr('data-slider-min')),
                max: parseFloat($(this).attr('data-slider-max')),
                range: $(this).attr('data-slider-range'),
                value: value,
                tooltip_split: $(this).attr('data-slider-tooltip_split'),
                tooltip: $(this).attr('data-slider-tooltip')
            });
        });

        // term slider
        $('.term-input-range').each(function () {
            var value = $(this).attr('data-slider-value');
            var separator = value.indexOf(',');
            if (separator !== -1) {
                value = value.split(',');
                value.forEach(function (item, i, arr) {
                    arr[i] = parseFloat(item);
                });
            } else {
                value = parseFloat(value);
            }
            $(this).slider({
                formatter: function (value) {
                    console.log(value);
                    return value.toString() + ' months';
                },
                min: parseFloat($(this).attr('data-slider-min')),
                max: parseFloat($(this).attr('data-slider-max')),
                range: $(this).attr('data-slider-range'),
                value: value,
                tooltip_split: $(this).attr('data-slider-tooltip_split'),
                tooltip: $(this).attr('data-slider-tooltip')
            });
        });
    });
})(jQuery);