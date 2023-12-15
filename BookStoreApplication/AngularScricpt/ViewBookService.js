app.service("ViewBookService", function ($http) {


    
    

    //get All Eployee
    this.getviewAllBooks = function () {
        return $http.get("ViewBook/GetViewBookList");
    };
    // View Record
    this.ViewBook = function (tbl_Book) {
        return $http({
            method: "post",
            url: "ViewBook/ViewBook",
            data: JSON.stringify(tbl_Book),
            dataType: "json"
        });
    }
    this.SellBook = function (tbl_Book) {
        return $http({
            method: "post",
            url: "ViewBook/SellBook",
            data: JSON.stringify(tbl_Book),
            dataType: "json"
        });
    }

   
});
