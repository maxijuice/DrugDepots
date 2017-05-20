$(document).ready(function () {
    $("#DepotId").on("change", function() {
        $.ajax({
            type: "GET",
            url: $("#GetDepotDrugTypesUrl").val(),
            data: { depotId: $("#DepotId").val() },
            contentType: "application/json",
            traditional: true,
            success: displayDrugTypes
        });
    });
});


function displayDrugTypes(drugTypes) {
    if (drugTypes.length > 0) {
        $(".no-units-message").hide();
        $("#depot-units").slideDown(500);
    } else {
        $(".no-units-message").slideDown(500);
        $("#depot-units").hide();
    }

    var typesIDs = drugTypes.map(function (type) {
        return type.DrugTypeId;
    });

    function maxTypeUnits(id) {
        var counter = typesIDs.reduce(function (accum, next) {
            if (next === id) {
                accum += 1;
            }

            return accum;
        }, 0);

        return counter;
    }

    var uniqueTypes = drugTypes.filter(function (value, index) {
        return typesIDs.indexOf(value.DrugTypeId) === index;
    });

    $("#depot-units tbody").empty();
    uniqueTypes.forEach(function (drugType) {
        var row = document.createElement("tr");
        var inputAmount = document.createElement("input");
        inputAmount.classList.add("form-control");
        inputAmount.name = "Amount";
        inputAmount.type = "number";
        inputAmount.min = 0;
        inputAmount.max = maxTypeUnits(drugType.DrugTypeId);

        var typeCol = document.createElement("td");
        typeCol.appendChild(document.createTextNode(drugType.DrugTypeName));

        var inputCol = document.createElement("td");
        var formGroup = document.createElement("div");
        formGroup.classList.add("form-group");
        formGroup.name = "OrderLine";
        var hiddenForId = document.createElement("input");
        hiddenForId.type = "hidden";
        hiddenForId.name = "DrugTypeId";
        hiddenForId.value = drugType.DrugTypeId;
        formGroup.appendChild(hiddenForId);
        formGroup.appendChild(inputAmount);
        inputCol.appendChild(formGroup);

        var maxCol = document.createElement("td");
        maxCol.innerHTML = "<span class='label-max'>" + maxTypeUnits(drugType.DrugTypeId) + "</span>";

        row.appendChild(typeCol);
        row.appendChild(inputCol);
        row.appendChild(maxCol);

        $("#depot-units tbody").append(row);
    });
}