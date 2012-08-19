$(function () {
    $('#addItem').click(function (event) {
        event.preventDefault();
        var clone = $('#template').clone().html();
        if ($('#tableItems tbody tr').length) {
            $('#tableItems tbody tr:last').after(clone);
        } else {
            $('#tableItems tbody').append(clone);
        }
        fixTable();
    });

    $('body').on("click", ".deleteRow", function (event) {
        event.preventDefault();
        $(this).parents('tr').remove();
        fixTable();
    });


    function fixTable() {
        $('#tableItems tbody tr').each(function(index) {
            $(this).find('input').each(function() {
                var name = $(this).attr('name');
                var split = name.split('.');
                $(this).attr('name', 'items[' + index + '].' + split[1]);

            });
        });
    }
});