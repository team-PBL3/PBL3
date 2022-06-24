﻿
function searchbar(search_text, value) {
    for (var i = listNotSearch.length - 1; i >= 0; i--) {
        listNotSearch[0].className = classFrameName;
    }
    for (var i = list.length - 1; i >= 0; i--) {
        list[i].style.display = "none";
        list[i].className = classFrameName + "0";
        if (document.getElementsByClassName("name-product")[i].innerHTML.search(value) != -1) {
            listNotSearch[0].style.display = "inline-block";
            listNotSearch[0].className = classFrameName;
        }
        console.log(list.length + " " + i + " " + listNotSearch.length);
    }
    changePage(1);
}
var classFrameName = document.getElementById("FrameName").innerHTML;
var PageProductNumber = document.getElementById("FrameNumber").innerHTML;
var list = document.getElementsByClassName(classFrameName);
var listNotSearch = document.getElementsByClassName(classFrameName + "0");

var firstPage = document.getElementById("First-Page");
var previousPage = document.getElementsByClassName("Previous-Page");
var threedot1 = document.getElementById("Three-dot1");
var currentPage = document.getElementById("Current-Page").innerHTML;
var threedot2 = document.getElementById("Three-dot2");
var nextPage = document.getElementsByClassName("Next-Page");
var lastPage = document.getElementById("Last-Page");

var totalproduct = document.getElementsByClassName('total_product');

function changePage(page) {
    if (list.length > 0) totalproduct[0].innerHTML = "Có " + list.length + " sản phẩm được tìm thấy.";
    else totalproduct[0].innerHTML = "Không có sản phẩm nào được tìm thấy.";
    for (var i = 0; i < list.length; i++) {
        list[i].style.display = "none";
    }
    lastPage.value = 1 + parseInt((list.length - 1) / 6);
    var i = 1;
    for (var y = 0; y < PageProductNumber; y++) {
        i = (currentPage - 1) * PageProductNumber + y;
        if (i < list.length) {
            list[i].style.display = "none";
        }
        i = (page - 1) * PageProductNumber + y;
        if (i < list.length) {
            list[i].style.display = "inline-block";
        }
    }
    currentPage = page;
    document.getElementById("Current-Page").innerHTML = page;
    firstPage.style.display = "inline-block";
    for (let i = 0; i < previousPage.length; i++) {
        previousPage[i].style.display = "inline-block";
        previousPage[i].value = parseInt(currentPage) - 1;
    }
    previousPage[1].innerHTML = parseInt(currentPage) - 1;
    threedot1.style.display = "inline-block";
    lastPage.style.display = "inline-block";
    for (let i = 0; i < nextPage.length; i++) {
        nextPage[i].style.display = "inline-block";
        nextPage[i].value = parseInt(currentPage) + 1;
    }
    nextPage[0].innerHTML = parseInt(currentPage) + 1;
    threedot2.style.display = "inline-block";

    if (currentPage == 1) {
        firstPage.style.display = "none";
        for (let i = 0; i < previousPage.length; i++) previousPage[i].style.display = "none";
        threedot1.style.display = "none";
    }
    if (currentPage == 2) threedot1.style.display = "none";
    if (currentPage == lastPage.value - 1) threedot2.style.display = "none";
    if (currentPage == lastPage.value) {
        lastPage.style.display = "none";
        for (let i = 0; i < nextPage.length; i++) nextPage[i].style.display = "none";
        threedot2.style.display = "none";
    }
}
changePage(1);
