// Write your Javascript code.
$(document).ready(function () {
    var projecttypes = []

    $("#UserId").on("change", function (e) {
        $.ajax({
            url: `/Users/Activate/${$(this).val()}`,
            method: "POST",
            dataType: "json",
            contentType: 'application/json; charset=utf-8'
        }).done(() => {
            location.reload();
        });
    });

    $.ajax({
        url: "/ProjectType/GetSubTypesForDropdown",
        method: "GET",
        headers: {
            "Content-Type": "application/json"
        }
    })
    .success(function (projectTypes) {
        subtypes.push(projectTypes);
    });

    $(".ProjectTypeId").on("change", function (e) {
        $(".ProductTypeId").html(`<select></select>`);
        for (var key in projecttypes[0]) {
            if (projecttypes[0][key].productTypeId == $(this).val()) {
                $(".ProductSubTypeId").append(`<option value="${subtypes[0][key].productSubTypeId}">${subtypes[0][key].name}</option>`);
            }
        }
        $(".ProjectTypeId").prepend(`<option value="0" selected>Project Type</option>`);
    })

});