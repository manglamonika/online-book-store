app.controller("loginCntr", function ($scope, $location, $window, LoginService) {
    $scope.dvLogin = true;

    $scope.users = [];




    // To display Add div
    //$scope.AddUser = function () {
    //    $scope.Action = "Add";
    //    $scope.dvRegistration = true;
    //}


    // Adding New student record
    $scope.Login = function (user) {
        LoginService.Login(user).success(function (msg) {
            debugger;
           // $scope.users.push(msg)
            if (msg) {

                alert('Login Successfully');
                //$location.path('~/Home/Index');
                $window.location.href = '/Home';
                //$location.path("Home");
                $scope.dvLogin = false;
            }
            else {
                alert('Validation failed, Please Enter the Correct Details');
                //$location.path('~/Home/Index');
                //$location.path("Home");
                $scope.dvLogin = true;
            }
            
            $scope.url = $location.absUrl().split('/')[2];;
           // $location.path('/Home/Index');
           
        }, function () {
            alert('Error in adding record');
        });
    }



});
