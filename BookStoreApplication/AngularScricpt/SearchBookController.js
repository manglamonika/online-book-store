app.controller("searchbookCntr", function ($scope, SearchBookService) {
    $scope.dvSearchBook = true;
    GetViewBookList();
    $scope.viewbooks = [];


    function GetViewBookList() {
        SearchBookService.getviewAllBooks().success(function (book) {
            $scope.viewbooks = book;
            $scope.dvSearchBook = true;
        }).error(function () {

            alert('Error in getting records' + error);
        });
    }


    // Adding New student record
    $scope.SearchBook = function (book1) {

        SearchBookService.ViewBook(book1).success(function (msg) {
            $scope.viewbooks = msg;
            //$scope.viewbooks.push(msg)
            $scope.dvSearchBook = true;
            //$("#tblviewbooks").DataTable().fnDestroy();
            // $("#tblviewbooks").DataTable().fnDestroy();
            // $("#tblviewbooks").DataTable();

        }, function () {
            alert('Error in adding record');
        });
    }
    $scope.BuyBook = function (book1) {

        SearchBookService.BuyBook(book1).success(function (msg) {
            // $scope.viewbooks = msg;
            //$scope.viewbooks.push(msg)

            $scope.dvSearchBook = true;
            GetViewBookList();
            //$("#tblviewbooks").DataTable().fnDestroy();
            // $("#tblviewbooks").DataTable().fnDestroy();
            // $("#tblviewbooks").DataTable();

        }, function () {
            alert('Error in adding record');
        });
    }



});
