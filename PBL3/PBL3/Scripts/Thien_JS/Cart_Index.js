document.getElementById("Buy").disabled = true;
var error = document.getElementById("error");
error.innerHTML = "Bạn chưa chọn hàng để mua";

document.getElementById('ChooseAll').onclick = function () {
    var checkboxes = document.getElementsByClassName('Choose_to_buy');
    for (var checkbox of checkboxes) {
        checkbox.checked = true;
        document.getElementById("Buy").disabled = false;
        error.innerHTML = "";
    }
}
document.getElementById('NotChooseAll').onclick = function () {
    var checkboxes = document.getElementsByClassName('Choose_to_buy');
    for (var checkbox of checkboxes) {
        checkbox.checked = false;
        error.innerHTML = "Bạn chưa chọn hàng để mua";
        document.getElementById("Buy").disabled = true;
    }
}
var c = document.getElementsByClassName('Choose_to_buy');
for (var ci of c) {
    ci.onclick = function () {
        var list = document.getElementsByClassName("Choose_to_buy");
        document.getElementById("Buy").disabled = true;
        var error = document.getElementById("error");
        error.innerHTML = "Bạn chưa chọn hàng để mua";
        for (var i of list) {
            if (i.checked == true) {
                document.getElementById("Buy").disabled = false;
                error.innerHTML = "";
                break;
            }
        }
    }
}
var check;
function SaveOld() {
    check = document.getElementById("quantity_input").value;
}
function Validate(Max) {
    var i = document.getElementById("quantity_input");
    if (i.value < 1 || i.value > Max) i.value = check;
}
function Validate2(Max, id, price) {
    var i = document.getElementById("quantity_input");
    if (i.value < 1) i.value = 1;
    if (i.value > Max) i.value = Max;
    var y = document.getElementsByClassName("totalPrice" + id).item(0);
    y.innerHTML = i.value * price;
}
function Btnc(text, id, Max, price) {
    var i = document.getElementsByClassName(id).item(0);
    if (text == 'up-button' && i.value < Max) i.value++;
    if (text == 'down-button' && i.value > 1) i.value--;
    var y = document.getElementsByClassName("totalPrice" + id).item(0);
    y.innerHTML = i.value * price;
}