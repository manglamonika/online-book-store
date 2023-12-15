app.service("RegistrationService", function ($http) {


    
    // Adding Record
    this.AddUser = function (tbl_Users) {
        return $http({
            method: "post",
            url: "Registration/AddUsers",
            data: JSON.stringify(tbl_Users),
            dataType: "json"
        });
    }



});
