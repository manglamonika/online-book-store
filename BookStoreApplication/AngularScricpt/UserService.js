app.service("UserService", function ($http) {


    //get All Eployee
    this.getAllUsers = function () {
        return $http.get("User/GetUserList");
    };



    // Adding Record
    this.AddNewUser = function (tbl_Users) {
        return $http({
            method: "post",
            url: "User/AddUser",
            data: JSON.stringify(tbl_Users),
            dataType: "json"
        });
    }



    // Updating record
    this.UpdateUser = function (tbl_Users) {
        return $http({
            method: "post",
            url: "User/UpdateUser",
            data: JSON.stringify(tbl_Users),
            dataType: "json"
        });

    }



    // Deleting records
    this.deleteUser = function (UserId) {
        return $http.post('User/DeleteUser?UserId=' + UserId)
    }

});
