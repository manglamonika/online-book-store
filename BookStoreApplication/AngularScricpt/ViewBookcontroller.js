app.controller("viewbookCntr", function ($scope, ViewBookService) {
    $scope.dvViewBook = true;
    GetViewBookList();
    $scope.viewbooks = [];


    function GetViewBookList() {
        ViewBookService.getviewAllBooks().success(function (book) {
            $scope.viewbooks = book;
            $scope.dvBook = true;
        }).error(function () {

            alert('Error in getting records' + error);
        });
    }


    // Adding New student record
    $scope.SearchBook = function (book1) {
       
        ViewBookService.ViewBook(book1).success(function (msg) {
            $scope.viewbooks = msg;
            //$scope.viewbooks.push(msg)
            $scope.dvViewBook = true;
            //$("#tblviewbooks").DataTable().fnDestroy();
           // $("#tblviewbooks").DataTable().fnDestroy();
           // $("#tblviewbooks").DataTable();
            
        }, function () {
            alert('Error in adding record');
        });
    }
    $scope.SellBook = function (book1) {

        ViewBookService.SellBook(book1).success(function (msg) {
           // $scope.viewbooks = msg;
            //$scope.viewbooks.push(msg)
            
           // $scope.dvViewBook = true;
            GetViewBookList();
            //$("#tblviewbooks").DataTable().fnDestroy();
            // $("#tblviewbooks").DataTable().fnDestroy();
            // $("#tblviewbooks").DataTable();

        }, function () {
            alert('Error in adding record');
        });
    }
    
    

});
