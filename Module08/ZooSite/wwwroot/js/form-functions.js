$(function () {
    $('.pricing select').change(function (event) {
        var target = $(event.target);
        var value = parseInt(target.val());
        var container = target.parent();
        var price = container.prev();
        var label = price.prev();

        $("#" + label.text()).remove();
    });

    function calculateSum() {
        var rows = document.querySelectorAll("#totalAmount tr .sum");
        var sum = 0;

        for (var i = 0; i < rows.length; i++) {
            sum = sum + parseFloat(parseFloat(rows[i].innerHTML.substring(1, rows[i].innerHTML.length)).toFixed(2));
        }

        document.getElementById("sum").innerHTML = "Total: $" + sum;
    }
});