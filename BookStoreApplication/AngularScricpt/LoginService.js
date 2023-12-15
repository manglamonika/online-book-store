app.service("LoginService", function ($http) {



    // Adding Record
    this.Login = function (tblloginUser) {
        return $http({
            method: "post",
            url: "Login/Login",
            data: JSON.stringify(tblloginUser),
            dataType: "json"
        });
    }



});