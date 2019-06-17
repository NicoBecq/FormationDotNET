function checkPassword() {
    var password = document.getElementById('password');
    var confirmPassword = document.getElementById('confirmPassword');
    if (confirmPassword.value === password.value && password.value.length >= 8) {
        password.style.border = '2px solid green';
        confirmPassword.style.border = '2px solid green';
    } else {
        password.style.border = '2px solid red';
        confirmPassword.style.border = '2px solid red';
    }
}