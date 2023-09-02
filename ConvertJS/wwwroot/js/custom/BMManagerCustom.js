﻿"use strict";

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
            'pageLength': 10,
            'columnDefs': [
                { orderable: false, targets: 9 }, // Disable ordering on column 0 (checkbox)
                { orderable: false, targets: 13 }, // Disable ordering on column 7 (actions)
            ]
        });

    }

    // Search Datatable --- official docs reference: https://datatables.net/reference/api/search()
    var handleSearchDatatable = () => {
        const filterSearch = document.querySelector('[data-kt-BM-table-filter="search"]');
        filterSearch.addEventListener('keyup', function (e) {
            datatable.search(e.target.value).draw();
        });
    }

    // Handle status filter dropdown
    var handleStatusFilter = () => {
        const filterStatus = document.querySelector('[data-kt-BM-table-filter="status"]');
        $(filterStatus).on('change', e => {
            let value = e.target.value;
            if (value === 'all') {
                value = '';
            }
            datatable.column(1).search(value).draw();
        });
        const filterLimit = document.querySelector('[data-kt-BM-table-filter="limit"]');
        $(filterLimit).on('change', e => {
            let value = e.target.value;
            if (value === 'all') {
                value = '';
            }
            datatable.column(4).search(value).draw();
        });
        const filterType = document.querySelector('[data-kt-BM-table-filter="type"]');
        $(filterType).on('change', e => {
            let value = e.target.value;
            if (value === 'all') {
                value = '';
            }
            datatable.column(2).search(value).draw();
        });
    }

    // Public methods
    return {
        init: function () {
            table = document.querySelector('#table_BM');

            if (!table) {
                return;
            }

            initDatatable();
            handleSearchDatatable();
            handleStatusFilter();
        }
    };
}();

// On document ready
KTUtil.onDOMContentLoaded(function () {
    KTAppAccountManager.init();
});
