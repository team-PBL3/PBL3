function Check(txtID) {
    var x = document.getElementById(txtID).value;
    if (!x.includes("@")) {
        var y = document.getElementById("LackCharacter");
        y.innerHTML = "This field must include '@'";
    }
    if (x.includes("@")) y.innerHTML = "";
    return;
}