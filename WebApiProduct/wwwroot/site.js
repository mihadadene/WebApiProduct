const uri = "api/todo";
let todos = null;
function getCount(data) {
    const el = $("#counter");
    let name = "to-do";
    if (data) {
        if (data > 1) {
            name = "to-dos";
        }
        el.text(data + " " + name);
    } else {
        el.text("No " + name);
    }
}
$(document).ready(function () {
    alert("Bonjour!!!");
    getData();
});
function getData() {
   // alert("Bonjour!!!");
    $.ajax({
        type: "GET",
        url: uri,
        cache: false,
        success: function (data) {
            const tBody = $("#todos");
            $(tBody).empty();
            getCount(data.length);
            $.each(data, function (key, item) {
                const tr = $("<tr></tr>")
                    //.append(
                    //    $("<td></td>").append(
                    //        $("<input/>", {
                    //            type: "checkbox",
                    //            disabled: true,
                    //            checked: item.isComplete
                    //        })
                    //    )
                    //)
                    .append($("<td></td>").text(item.nomProd))
                    .append($("<td></td>").text(item.qtyProd))
                    .append($("<td></td>").text(item.prixProd))
                    .append(
                        $("<td></td>").append(
                            $("<button>Edit</button>").on("click", function () {
                                editItem(item.id);
                            })
                        )
                    )
                    .append(
                        $("<td></td>").append(
                            $("<button>Delete</button>").on("click", function () {
                                deleteItem(item.id);
                            })
                        )
                    );
                tr.appendTo(tBody);
            });
            todos = data;
        }
    });
}
function addItem() {
    const item = {
        NomProd: $("#add-NomProd").val(),
        QtyProd: $("#add-QtyProd").val(),
        PrixProd: $("#add-PrixProd").val(),
        isComplete: false
    };
    $.ajax({
        type: "POST",
        accepts: "application/json",
        url: uri,
        contentType: "application/json",
        data: JSON.stringify(item),
        error: function (jqXHR, textStatus, errorThrown) {
            alert("Something went wrong!");
        },
        success: function (result) {
            getData();
          // $("#add-IdProd").val("");
            $("#add-NomProd").val("");
            $("#add-QtyProd").val("");
            $("#add-PrixProd").val("");
        }
    });
}
function deleteItem(id) {
    $.ajax({
        url: uri + "/" + id,
        type: "DELETE",
        success: function (result) {
            getData();
        }
    });
}
function editItem(id) {
    $.each(todos, function (key, item) {
        if (item.id === id) {
            $("#edit-NomProd").val(item.NomProd);
            $("#edit-QtyProd").val(item.QtyProd);
            $("#edit-PrixProd").val(item.PrixProd);
            $("#edit-IdProd").val(item.IdProd);
           // $("#edit-isComplete")[0].checked = item.isComplete;
        }
    });
    $("#spoiler").css({ display: "block" });
}
$(".my-form").on("submit", function () {
    const item = {
        NomProd: $("#edit-NomProd").val(),
        QtyProd: $("#edit-QtyProd").val(),
        PrixProd: $("#edit-PrixProd").val(),
       // isComplete: $("#edit-isComplete").is(":checked"),
        id: $("#edit-idProd").val()
    };
    $.ajax({
        url: uri + "/" + $("#edit-id").val(),
        type: "PUT",
        accepts: "application/json",
        contentType: "application/json",
        data: JSON.stringify(item),
        success: function (result) {
            getData();
        }
    });
    closeInput();
    return false;
});
function closeInput() {
    $("#spoiler").css({ display: "none" });
}