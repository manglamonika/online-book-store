app.controller("registrationCntr", function ($scope, RegistrationService) {
    $scope.dvRegistration = true;
  
    $scope.users = [];


   

    // To display Add div
    //$scope.AddUser = function () {
    //    $scope.Action = "Add";
    //    $scope.dvRegistration = true;
    //}


    // Adding New student record
    $scope.AddUser = function (user) {
        RegistrationService.AddUser(user).success(function (msg) {
            $scope.users.push(msg)
            $scope.dvRegistration = false;
            alert('adding record successfully');
        }, function () {
            alert('Error in adding record');
        });
    }

    

});
