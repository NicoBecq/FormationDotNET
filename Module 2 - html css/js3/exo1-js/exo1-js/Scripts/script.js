document.querySelector('#image1').addEventListener('mouseover', function (e) {
    this.classList.add('img_border_red');
})
document.querySelector('#image1').addEventListener('mouseout', function () {
    this.classList.remove('img_border_red');
})
