app.service("SearchBookService", function ($http) {





    //get All Eployee
    this.getviewAllBooks = function () {
        return $http.get("SearchBook/GetViewBookList");
    };
    // View Record
    this.ViewBook = function (tblOrderBook) {
        return $http({
            method: "post",
            url: "SearchBook/ViewBook",
            data: JSON.stringify(tblOrderBook),
            dataType: "json"
        });
    }
    this.BuyBook = function (tblOrderBook) {
        return $http({
            method: "post",
            url: "SearchBook/BuyBook",
            data: JSON.stringify(tblOrderBook),
            dataType: "json"
        });
    }


});
