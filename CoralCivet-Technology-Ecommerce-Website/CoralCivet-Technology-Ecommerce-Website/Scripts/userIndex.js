var slideIndex = 1;
showSlides(slideIndex);

// Next/previous controls
function plusSlides(n) {
    showSlides(slideIndex += n);
}

// Thumbnail image controls
function currentSlide(n) {
    showSlides(slideIndex = n);
}

function showSlides(n) {
    var i;
    var slides = document.getElementsByClassName("mySlides");
    var dots = document.getElementsByClassName("dot");
    if (n > slides.length) { slideIndex = 1 }
    if (n < 1) { slideIndex = slides.length }
    for (i = 0; i < slides.length; i++) {
        slides[i].style.display = "none";
    }
    for (i = 0; i < dots.length; i++) {
        dots[i].className = dots[i].className.replace(" active", "");
    }
    slides[slideIndex - 1].style.display = "block";
    dots[slideIndex - 1].className += " active";
}

function GetQty() {
    var qty = document.getElementById("product-Qty").value;
    return qty;
}

function AddCart(id) {
    var url = '/Order/IndexAProduct/';
    $.ajax({
        type: "GET",
        url: url,
        data: { productId = id.value, value = GetQty()},
        dataType: "html"
    });
}

document.getElementById("order_transport_type").onclick = function () { changeFee(document.getElementById("order_transport_type").value) }

function changeFee(e) {
    if (e == 0) {
        document.getElementById("delivery-fee").innerHTML = "25,000"
    }
    if (e == 1) {
        document.getElementById("delivery-fee").innerHTML = "30,000"
    }
}