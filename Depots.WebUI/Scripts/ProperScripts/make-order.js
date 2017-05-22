$(document).ready(function () {
    $(".submit-order").attr("disabled", true);

    $("#DepotId").on("change", function () {
        if (!this.value) {
            $(".order-depot-units").hide();
            $(".no-units-message").hide();
            $(".submit-order").attr("disabled", true);
            return;
        }

        $.ajax({
            type: "GET",
            url: $("#DepotDrugTypesUrl").val(),
            data: { depotId: $("#DepotId").val() },
            contentType: "application/json",
            traditional: true,
            success: displayDrugTypes
        });
    });
});

var propertyName = "Lines";
function indexer(index) {
    return propertyName + "[" + index + "].";
}

function displayDrugTypes(drugTypes) {
    if (drugTypes.length > 0) {
        $(".no-units-message").hide();
        $(".order-depot-units").slideDown(500);
        $(".submit-order").attr("disabled", false);
    } else {
        $(".no-units-message").slideDown(500);
        $(".order-depot-units").hide();
        $(".submit-order").attr("disabled", true);
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

    $(".order-depot-units tbody").empty();
    uniqueTypes.forEach(function (drugType, index) {
        var row = document.createElement("tr");
        var inputAmount = document.createElement("input");
        inputAmount.classList.add("form-control");
        inputAmount.name = indexer(index) + "Amount";
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
        hiddenForId.name = indexer(index) + "DrugTypeId";
        hiddenForId.value = drugType.DrugTypeId;
        formGroup.appendChild(hiddenForId);
        formGroup.appendChild(inputAmount);
        inputCol.appendChild(formGroup);

        var maxCol = document.createElement("td");
        maxCol.innerHTML = "<span class='label-max'>" + maxTypeUnits(drugType.DrugTypeId) + "</span>";

        row.appendChild(typeCol);
        row.appendChild(inputCol);
        row.appendChild(maxCol);

        $(".order-depot-units tbody").append(row);
    });
}