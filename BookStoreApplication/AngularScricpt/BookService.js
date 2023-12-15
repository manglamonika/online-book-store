app.service("BookService", function ($http) {


    //get All Eployee
    this.getAllBooks = function () {
        return $http.get("Book/GetBookList");
    };



    // Adding Record
    this.AddNewBook = function (tbl_Book) {
        return $http({
            method: "post",
            url: "Book/AddBook",
            data: JSON.stringify(tbl_Book),
            dataType: "json"
        });
    }

    this.EditBook = function (tbl_Book) {
        return $http({
            method: "post",
            url: "Book/EditBook",
            data: JSON.stringify(tbl_Book),
            dataType: "json"
        });
    }

    

    // Updating record
    this.UpdateBook = function (tbl_Book) {
        return $http({
            method: "post",
            url: "Book/UpdateBook",
            data: JSON.stringify(tbl_Book),
            dataType: "json"
        });

    }



    // Deleting records
    this.deleteBook = function (BookId) {
        return $http.post('Book/DeleteBook?BookId=' + BookId)
    }

});
