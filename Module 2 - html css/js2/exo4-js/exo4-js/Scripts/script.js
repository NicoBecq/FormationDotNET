document.querySelector('#submit').addEventListener('click', function (e) {
    document.querySelector('#lastname').setAttribute('value', "");
    document.querySelector('#firstname').setAttribute('value', "");
    document.querySelector('#city').setAttribute('value', "");
    e.preventDefault();
})