$(function() {
    
    // Table setup
    // ------------------------------

    // Setting datatable defaults
    $.extend($.fn.dataTable.defaults, {
        autoWidth: true,
        dom: '<"datatable-header"fl><"datatable-scroll"t><"datatable-footer"ip>',
        language: {
            search: '<span>Filtrar:</span> _INPUT_',
            lengthMenu: '<span>Mostrar:</span> _MENU_',
            paginate: { 'first': 'First', 'last': 'Last', 'next': '&rarr;', 'previous': '&larr;' }
        }
    });


    // External table additions
    // ------------------------------

    // Add placeholder to the datatable filter option
    $('.dataTables_filter input[type=search]').attr('placeholder', 'Escriba para filtrar...');

    // Enable Select2 select for the length option
    $('.dataTables_length select').select2({
        minimumResultsForSearch: "-1"
    });


});