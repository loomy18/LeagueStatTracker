var numSummoners = 1;

function removeNestedForm(element, container, deleteElement) {
    if (numSummoners > 1) {
        numSummoners = numSummoners - 1;
        $container = $(element).parents(container);
        $container.find(deleteElement).val('True');
        $container.hide();
    }
    if (numSummoners == 4) $("#AddSummoner").show();
    if (numSummoners == 1) $("#RemoveSummoner").hide();
}

function addNestedForm(container, counter, ticks, content) {
    if (numSummoners < 5) {
        numSummoners = numSummoners + 1;
        var nextIndex = $(counter).length;
        var pattern = new RegExp(ticks, "gi");
        content = content.replace(pattern, nextIndex);
        $(container).append(content);
    }
    if (numSummoners == 5) $("#AddSummoner").hide();
    if (numSummoners == 2) $("#RemoveSummoner").show();
}

function checkUsername() {
    var url = "/Account/CheckUserName";
    var name = $('#Username').val();
    $.get(url, { input: name }, function (data) {
        if (data == "Available") {
            $("#statusSpan").html("<span style='color:green'>Available</span>");
            $("#Username").css('background-color', '');
        }
        else {
            $("#statusSpan").html("<span style='color:red'>Not Available</span>");
            $("#Username").css('background-color', '#e97878');
        }
    })
}