app.controller("orderCntr", function ($scope, OrderBookService) {
    $scope.dvViewOrder = true;
    // GetOrderList();
    GetOrderList();
    $scope.orderbooks = [];


    function GetOrderList() {
        OrderBookService.GetViewAllOrderBooks().success(function (book) {
            debugger;
            $scope.orderbooks = book;
            $scope.dvViewOrder = true;
        }).error(function () {

            alert('Error in getting records' + error);
        });
    }

    // Adding New student record
    $scope.SearchOrder = function (book) {
        OrderBookService.ViewOrderBook(book).success(function (msg) {
            $scope.orderbooks = msg;
            $scope.dvViewOrder = true;

        }, function () {
            alert('Error in adding record');
        });
    }



});
