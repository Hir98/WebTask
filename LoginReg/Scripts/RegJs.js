
var User = new Object();

function validateFirstname() {
    var FirstName = document.getElementById("firstname").value;
    var FirstNameError = document.getElementById('firstnameerror');

    var NameEx = /^[a-zA-Z ]+$/;
    if (FirstName == "") {
        FirstNameError.textContent = 'Please Enter First Name';
        FirstNameError.style.visibility = "visible";
        FirstNameError.style.color = "red";
        FirstNameError.focus();

        return false;
    }
    else if (NameEx.test(FirstName)) {
        FirstNameError.style.visibility = "hidden";
        return true;
    }
    else {
        FirstNameError.textContent = "First Name accepts Only letters";
        FirstNameError.style.visibility = "visible";
        FirstNameError.style.color = "red";

        //FirstName.focus();
        return false;
    }
}
function validateLastname() {
    var LastName = document.getElementById("lastname").value;
    var LastNameError = document.getElementById('lastnameerror');

    var NameEx = /^[a-zA-Z ]+$/;
    if (LastName == "") {
        LastNameError.textContent = 'Please Enter Last Name';
        LastNameError.style.visibility = "visible";
        LastNameError.style.color = "red";
        LastNameError.focus();

        return false;
    }
    else if (NameEx.test(LastName)) {
        LastNameError.style.visibility = "hidden";
        return true;
    }
    else {
        LastNameError.textContent = "Last Name accepts Only letters";
        LastNameError.style.visibility = "visible";
        LastNameError.style.color = "red";

        return false;
    }
}

function validateEmail() {
    var Email = document.getElementById("email").value;
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

function validateMobileno() {

    var Mobile = document.getElementById("mobile").value;
    var MobileError = document.getElementById('mobileerror');
    var MobileEx = /^\d{10}$/;
    

    if (Mobile == "") {
        MobileError.textContent = 'Please Enter Phone no';
        MobileError.style.visibility = "visible";
        MobileError.style.color = "red";
        MobileError.focus();

        return false;
    }
    else if (MobileEx.test(Mobile)) {
        MobileError.style.visibility = "hidden";
        return true;
    }
    else {
        MobileError.textContent = "Phone Number Only contain numbers";
        MobileError.style.visibility = "visible";
        MobileError.style.color = "red";

        return false;
    }
}

function ValidatePassword() {
     Password = document.getElementById("password").value;
    var PasswordError = document.getElementById('passworderror');
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

function ConformPasswordValidation() {
    var ConfirmPassword = document.getElementById("confirmpassword").value;
    var ConfirmPasswordError = document.getElementById('confirmpassworderror');
    var minNumberofChars = 6;
    var maxNumberofChars = 16;
    var val = /^[a-zA-Z0-9!@#$%^&*]{6,16}$/;

    if (ConfirmPassword == "") {
        ConfirmPasswordError.textContent = 'Please Enter ConformPassword';
        ConfirmPasswordError.style.visibility = "visible";
        ConfirmPasswordError.style.color = "red";
        ConfirmPasswordError.focus();

        //  ConfirmPassword.focus();
        return false;
    }
    else if (Password == ConfirmPassword) {
        ConfirmPasswordError.style.visibility = "hidden";
        return true;
    }
    else {
        ConfirmPasswordError.textContent = "ConformPassword must be match with Password";
        ConfirmPasswordError.style.visibility = "visible";
        ConfirmPasswordError.style.color = "red";

        //   ConfirmPassword.focus();
        return false;
    }
}



function allvalidate()
{

   
    var Fname = validateFirstname();
    var LName = validateLastname();
    var Email = validateEmail();
    var Mobile = validateMobileno();
    var Password = ValidatePassword();
    var Conpassword = ConformPasswordValidation();
    if (Fname && LName && Email && Mobile && Password && Conpassword) {

    //  var file = $("#SelectImage").get(0).files;
   // //var data = new FormData;
//     data.append("postedFile", file[0]);
   // User.Avatar = data;
   // User.FirstName = $("#firstname").val();
   // User.LastName = $("#lastname").val();
  //  User.Email = $("#email").val();
  //  User.Mobile = $("#mobile").val();
  //  User.Password = $("#password").val();
       alert("Validation success");

        RegistrationData();
    }
    else {
        alert("Put data According to given detail");

    }
}

var RegistrationData = function ()
{
    //for image
   // var file = $("#SelectImage").get(0).files;
  //  var data = new FormData;
  //  data.append("postedFile", file[0]);

    //for data
    //var formdata = $("#Registration").serialize();

    var formData = new FormData();
    var file = $("#SelectImage").get(0).files;

    formData.append("firstname", $("#firstname").val());
    formData.append("lastname", $("#lastname").val());
    formData.append("email", $("#email").val());
    formData.append("mobile", $("#mobile").val());
    formData.append("password", $("#password").val());  
    formData.append("postedFile", file[0]);


    $.ajax({
        type: "post",
        url: "/Register/AddUser",
        data: formData,
        contentType: false,
        processData: false,
        success: function (result) {
            //alert(result);
           
            if (result == "User Details Inserted Successfully!") {
                $("#Registration")[0].reset();
                //window.location.href = "/Login/Index";
                $("#message1").show();
                $("#message2").hide();

            }
            else if (result == "Duplicate") {
                $("#Registration")[0].reset();
                alert("Already Register Try with other users");

            }
            else {
                //  window.location.href = "/Login/Index";
                $("#message1").hide();
                $("#message2").show();

            }
        }
      /*  if($(Data).attr('enctype') == "multipart/form-data") {
        ajaxConfig["contentType"] = false;
        ajaxConfig["processData"] = false;
    }
    $.ajax(ajaxConfig);
    return false;*/
    });
};

