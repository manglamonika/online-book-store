app.controller("bookCntr", function ($scope, BookService) {
    $scope.dvBook = true;
    $scope.dveditBook = false;
    GetBookList();
    $scope.books = [];
    $scope.ebooks=[];


    //To Get All Records  
    function GetBookList() {
        BookService.getAllBooks().success(function (book) {
            $scope.books = book;
            debugger;
            $scope.dvBook = true;
        }).error(function () {

            alert('Error in getting records' + error);
        });
    }

    // To display Add div
    $scope.AddNewBook = function () {
        $scope.Action = "Add";
        $scope.dvBook = true;
    }

    $scope.EditBook = function (book) {
        BookService.EditBook(book).success(function (msg) {
            $scope.ebooks = msg;
            $scope.dvAddBook = false;
            $scope.dveditBook = true;
            GetBookList();
        }, function () {
            alert('Error in adding record');
        });
    };
    // Adding New student record
    $scope.AddBook = function (book) {
        BookService.AddNewBook(book).success(function (msg) {
            $scope.books.push(msg)
            $scope.dvAddBook = false;
            GetBookList();
        }, function () {
            alert('Error in adding record');
        });
    }
    //$scope.uploadedFile = function (element) {

    //    $scope.$apply(function ($scope) {
    //        $scope.files = element.files;
    //    });

    //}
    // Deleting record.
    $scope.deleteBook = function (book, index) {
        var retval = BookService.deleteBook(book.BookId).success(function (msg) {
            $scope.books.splice(index, 1);
            alert('Book has been deleted successfully.');
            $scope.dveditBook = false;
            $scope.dvdeleteBook = false;            
            GetBookList();
            
        }).error(function () {
            alert('Oops! something went wrong.');
        });
    }


    // Updateing Records
    $scope.UpdateBook = function (Book) {
        debugger;
        var RetValData = BookService.UpdateBook(Book).success(function (msg) {
           BookId: $scope.BookId;
            Name: $scope.Name;
            Email: $scope.Email;
            $scope.dveditBook = false;
            alert('Book has been update successfully.');
            GetBookList();
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
