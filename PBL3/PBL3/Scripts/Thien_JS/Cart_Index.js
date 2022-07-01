document.getElementById("Buy").disabled = true;
var error = document.getElementById("error");
error.innerHTML = "Bạn chưa chọn hàng để mua.";
error.style.color = "red";
var count = 0;

document.getElementById('ChooseAll').onclick = function () {
    var checkboxes = document.getElementsByClassName('Choose_to_buy');
    for (var checkbox of checkboxes) {
        checkbox.checked = true;
        document.getElementById("Buy").disabled = false;
        error.innerHTML = "Bạn đã chọn " + checkboxes.length + " sản phẩm.";
        error.style.color = "#13c36b";
        document.getElementById("label_" + checkbox.id).style.backgroundImage = "url('/Image/OIP.jpg')";
        document.getElementById("label_" + checkbox.id).style.backgroundSize = "cover";
    }
}
document.getElementById('NotChooseAll').onclick = function () {
    var checkboxes = document.getElementsByClassName('Choose_to_buy');
    for (var checkbox of checkboxes) {
        checkbox.checked = false;
        error.innerHTML = "Bạn chưa chọn hàng để mua.";
        error.style.color = "red";
        document.getElementById("Buy").disabled = true;
        document.getElementById("label_" + checkbox.id).style.backgroundImage = "";
    }
}
function ValiSubmit() {
    var checkboxes = document.getElementsByClassName('Choose_to_buy');
    for (var checkbox of checkboxes) {
        if (!checkbox.checked) document.getElementById("quantity_input_" + checkbox.value).value = 0;
    }
    return true;
}
var c = document.getElementsByClassName('Choose_to_buy');
for (var ci of c) {
    ci.onclick = function () {
        var list = document.getElementsByClassName("Choose_to_buy");
        document.getElementById("Buy").disabled = true;
        var error = document.getElementById("error");
        error.innerHTML = "Bạn chưa chọn hàng để mua";
        error.style.color = "red";
        for (var i of list) {
            console.log(i.id);
            console.log(i.className);
            if (i.checked == false) document.getElementById("label_" + i.id).style.backgroundImage = "";
            if (i.checked == true) {
                document.getElementById("label_" + i.id).style.backgroundImage = "url('/Image/OIP.jpg')";
                document.getElementById("label_" + i.id).style.backgroundSize = "cover";
                count = count + 1;
            }
        }
        if (count > 0) {
            document.getElementById("Buy").disabled = false;
            error.innerHTML = "Bạn đã chọn " + count + " sản phẩm.";
            error.style.color = "springgreen";
            count = 0;
        }
    }
}
var check;
function Validate(Max,id,price) {
    var i = document.getElementById("quantity_input_" + id);
    if (i.value > Max) i.value = Max;
    if (i.value < 1) i.value = 1;
    var y = document.getElementsByClassName("totalPrice" + id).item(0);
    y.innerHTML = i.value * price;
}
function Validate2(Max, id, price) {
    var i = document.getElementById("quantity_input_" + id);
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
function Validate() {
    var name = document.getElementById("name");
    var phone = document.getElementById("phone");
    var sexNam = document.getElementById("sex");
    var sexNu = document.getElementById("sex");
    var address = document.getElementById("address");
    var email = document.getElementById("email");
    if (name.value == "" || name.value == null || phone.value == "" || phone.value == null ||
        (sexNam.checked == false && sexNu.checked == false) || address.value == "" || address.value == null) return false;
    if (email != "" && email != null) {
        if (/^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/.test(email.value)) {
            return true;
        }
        else return false;
    }
    return true;
}
