var loginobj = new Object();

function validateEmail() {
    var Email = document.getElementById("logemail").value;
    var EmailError = document.getElementById('emailerror');

    var EmailEx = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/;
    if (Email == "") {
        EmailError.textContent = 'Please Enter Email';
        EmailError.style.visibility = "visible";
        EmailError.style.color = "red";
        EmailError.focus();

        //Email.focus();
        return false;
    }
    else if (EmailEx.test(Email)) {
        EmailError.style.visibility = "hidden";
        return true;
    }
    else {
        EmailError.textContent = "Email address in not in Validae formate";
        EmailError.style.visibility = "visible";
        EmailError.style.color = "red";

        return false;
    }
}

function ValidatePassword() {
    Password = document.getElementById("logpassword").value;
    var PasswordError = document.getElementById('pwderror');
    var minNumberofChars = 6;
    var maxNumberofChars = 16;
    var PasswordEx = /^[a-zA-Z0-9!@#$%^&*]{6,20}$/;

    if (Password == "") {
        PasswordError.textContent = 'Please Enter Password';
        PasswordError.style.visibility = "visible";
        PasswordError.style.color = "red";
        PasswordError.focus();

        //   Password.focus();
        return false;
    }
    else if (PasswordEx.test(Password) && (Password.length >= minNumberofChars || Password.length <= maxNumberofChars)) {
        PasswordError.style.visibility = "hidden";
        return true;
    }
    else {
        PasswordError.textContent = "Password Should be between 6 - 20 ";
        PasswordError.style.visibility = "visible";
        PasswordError.style.color = "red";

        //  Password.focus();
        return false;
    }
}
function Login() {

    var test1 = validateEmail();
    var test2 = ValidatePassword();

    if (test1 && test2) {

        loginobj.Email = $("#logemail").val();
        loginobj.Password = $("#logpassword").val();
      
        LoginData();
    }
    else {
        alert("Put data According to given detail");

    }
}
var LoginData= function () {
    var data = loginobj;
    //var data = $("#Registration").serialize();
    $.ajax({
        type: "post",
        url: "/Login/CheckValidUser",
        data: data,
        success: function (result)
        {
<<<<<<< HEAD
           
            if (result == "Admin") {
                window.location.href = "/Login/Admin";
                //alert("You Are admin ");
               
            }
            else if (result=="User")
                {
                window.location.href = "/Login/User"; alert("You Are User ");
                $("#msg").hide();
            }
            else if (result == "Fail")
            {
                $("#loginForm")[0].reset();
                $("#msg").show();
            }
            
=======
            if (result == "Fail") {
                $("#loginForm")[0].reset();
                $("#msg").show();
            }
            else {
                window.location.href = "/Login/Welcome";
                $("#msg").hide();
            }
>>>>>>> d6480a83ec64e5e645cacca771a042f600696335
        }
    });
};