$(function () {
    $("#responsive-panel").kendoResponsivePanel({
        breakpoint: 768,
        autoClose: false,
        orientation: "top"
    });

    $("#menu").kendoMenu();
    $(".textButton").kendoButton();

    $("#moderatorGrid").kendoGrid({
        sortable: true,
        groupable: true,
        scrollable: true,
        height: "300px",
        pageable: {
            pageSize: 10
        },
        dataSource: {
            transport: {
                read: {
                    url: "/AdminPanel/GetGoodsJSON",
                    dataType: "Json"
                }
            }
        },
        columns: [
            { field: "Name", title: "Name" },
            { field: "Price", title: "Price" },
            { field: "Amount", title: "Amount" },
            { field: "Id", template: "<a href='/AdminPanel/Edit/${Id}'>Edit</a>" }
        ]
    });
});