
document.getElementsByClassName("list_order")[0].style.minHeight = (window.innerHeight-71) +"px";
document.getElementsByClassName("poster")[0].style.height = (window.innerHeight - 71) + "px";
document.getElementsByClassName("poster")[1].style.height = (window.innerHeight - 71) + "px";
window.onscroll = function () {
    var i = document.getElementsByClassName("poster");
    var body = document.getElementsByTagName("body")[0].getBoundingClientRect();
    var home = document.getElementsByClassName("home")[0].getBoundingClientRect();
    var i1 = document.getElementsByClassName("list_order")[0].getBoundingClientRect();
    var header = document.getElementsByClassName("header_container")[0].getBoundingClientRect();
    if (self.pageYOffset <= (home.y - body.y) + home.height - header.height) {
        var y = home.y - body.y + home.height - self.pageYOffset;
        i[0].style.top = y + "px";
        i[1].style.top = y + "px";
    }
    else if (self.pageYOffset + window.innerHeight > (i1.y - body.y) + i1.height)
    {
        i[0].style.top = (i1.y - body.y + i1.height - self.pageYOffset - window.innerHeight + header.height) + "px";
        i[1].style.top = i[0].style.top;
    }
    else {
        i[0].style.top = header.height+"px";
        i[1].style.top = i[0].style.top;
    }
}
