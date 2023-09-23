"use strict";

// Class definition
var KTAppAccountManager = function () {
    // Shared variables
    var table;
    var datatable;

    // Private functions
    var initDatatable = function () {
        // Init datatable --- more info on datatables: https://datatables.net/manual/
        datatable = $(table).DataTable({
            "info": false,
            'order': [],
            'pageLength': 5
        });

    }

    // Search Datatable --- official docs reference: https://datatables.net/reference/api/search()
    var handleSearchDatatable = () => {
        const filterSearch = document.querySelector('[data-kt-save-post-table-filter="search"]');
        filterSearch.addEventListener('keyup', function (e) {
            datatable.search(e.target.value).draw();
        });
    }

    //// Handle status filter dropdown
    //var handleStatusFilter = () => {
    //    const filterStatus = document.querySelector('[data-kt-bm-die-table-filter="status"]');
    //    $(filterStatus).on('change', e => {
    //        let value = e.target.value;
    //        if (value === 'all') {
    //            value = '';
    //        }
    //        datatable.column(1).search(value).draw();
    //    });
    //}

    // Public methods
    return {
        init: function () {
            table = document.querySelector('#table_adspy_post');

            if (!table) {
                return;
            }
            initDatatable();
            handleSearchDatatable();
        }
    };
}();

// On document ready
KTUtil.onDOMContentLoaded(function () {
    KTAppAccountManager.init();
});
