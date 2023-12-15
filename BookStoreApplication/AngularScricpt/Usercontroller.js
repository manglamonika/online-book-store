app.controller("userCntr", function ($scope, UserService) {
    $scope.dvUser = true;
    GetUserList();
    $scope.users = [];


    //To Get All Records  
    function GetUserList() {
        UserService.getAllUsers().success(function (user) {
            $scope.users = user;
            $scope.dvUser = true;
        }).error(function () {

            alert('Error in getting records' + error);
        });
    }

    // To display Add div
    $scope.AddNewUser = function () {
        $scope.Action = "Add";
        $scope.dvStudent = true;
    }


    // Adding New student record
    $scope.AddUser = function (user) {
        UserService.AddNewUser(user).success(function (msg) {
            $scope.users.push(msg)
            $scope.dvAddUser = false;
            GetUserList();
        }, function () {
            alert('Error in adding record');
        });
    }

    // Deleting record.
    $scope.deleteUser = function (user, index) {
        var retval = UserService.deleteUser(user.UserId).success(function (msg) {
            $scope.users.splice(index, 1);
            alert('Book has been deleted successfully.');
            GetUserList();

        }).error(function () {
            alert('Oops! something went wrong.');
        });
    }


    // Updateing Records
    $scope.UpdateUser = function (user) {

        var RetValData = UserService.UpdateBook(user).success(function (msg) {
            BookId: $scope.UserId;
            Name: $scope.Name;
            Email: $scope.Email;
            alert('Book has been update successfully.');
            GetUserList();
        }, function () {
            alert('Error in getting records');
        });
        //getData.then(function (tbl_Student) {
        //    BookId: $scope.BookId;
        //    Name: $scope.Name;
        //    Email: $scope.Email;
        //    alert('Book has been update successfully.');
        //    GetBookList();
        //}, function () {
        //    alert('Error in getting records');
        //});
    }



});
