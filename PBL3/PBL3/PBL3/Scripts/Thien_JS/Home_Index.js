
var firstPage = document.getElementById("First-Page");
var previousPage = document.getElementsByClassName("Previous-Page");
var threedot1 = document.getElementById("Three-dot1");
var currentPage = document.getElementById("Current-Page").innerHTML;
var threedot2 = document.getElementById("Three-dot2");
var nextPage = document.getElementsByClassName("Next-Page");
var lastPage = document.getElementById("Last-Page");
if (currentPage == "1") {
    firstPage.style.display = "none";
    for (let i = 0; i < previousPage.length; i++) previousPage[i].style.display = "none";
    threedot1.style.display = "none";
}
if (currentPage == "2") threedot1.style.display = "none";
if (currentPage == lastPage.value - 1) threedot2.style.display = "none";
if (currentPage == lastPage.value) {
    lastPage.style.display = "none";
    for (let i = 0; i < nextPage.length; i++) nextPage[i].style.display = "none";
    threedot2.style.display = "none";
}