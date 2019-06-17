var img1 = document.querySelector('#image1')
var img2 = "images/image1_2.jpg";
img1.addEventListener('mouseover', function () {
    img1.setAttribute('src', img2);   
})