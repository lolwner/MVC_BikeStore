$(function () {
    $("#responsive-panel").kendoResponsivePanel({
        breakpoint: 768,
        autoClose: false,
        orientation: "top"
    });

    $("#menu").kendoMenu();
    $(".textButton").kendoButton();

    $("#roleGrid").kendoGrid({
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