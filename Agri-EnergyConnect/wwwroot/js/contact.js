$('#organization_subdivision').change(function() {
    $('#suggested_email').prop(
        'selectedIndex', $(this).prop('selectedIndex')
    );
})

$('#suggested_email').change(function() {
    $('#organization_subdivision').prop(
        'selectedIndex', $(this).prop('selectedIndex')
    );
})