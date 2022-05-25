function Check(txtID) {
    var x = document.getElementById(txtID).value;
    var y = document.getElementById("LackCharacter");
    if (!x.includes("@")) {
        y.innerHTML = "This field must include '@'";
    }
    else y.innerHTML = "";
    return;
}