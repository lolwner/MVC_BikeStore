$(function () {
    $("#responsive-panel").kendoResponsivePanel({
        breakpoint: 768,
        autoClose: false,
        orientation: "top"
    });

    $("#menu").kendoMenu();
    $(".textButton").kendoButton();

    $("#grid").kendoGrid({
        sortable: true,
        groupable: true,
        scrollable: true,
        height: "300px",
        pageable: {
            pageSizes: 10
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
            { field: "Good_ID", template: "<a href='/AdminPanel/Edit/${Good_ID}'>${Good_ID}</a>" }
        ]
    });

    $("#usersGrid").kendoGrid({
        sortable: true,
        groupable: true,
        scrollable: true,
        height: "300px",
        pageable: {
            pageSizes: 10
        },
        dataSource: {
            transport: {
                read: {
                    url: "/RoleManagement/GetUsersJSON",
                    dataType: "Json"
                }
            }
        },
        columns: [
            { field: "Email", title: "Email" },
            { field: "Id", template: "<a href='/RoleManagement/AssignRole/${Id}'>Assign role</a>" }
        ]
    });
});