app.service("OrderBookService", function ($http) {



    //get All Order
    this.GetViewAllOrderBooks = function () {
        return $http.get("ViewOrder/GetViewAllOrderBooks");
    };


    // View Record
    this.ViewOrderBook = function (tblOrderBook) {
        return $http({
            method: "post",
            url: "ViewOrder/ViewOrder",
            data: JSON.stringify(tblOrderBook),
            dataType: "json"
        });
    }




});
