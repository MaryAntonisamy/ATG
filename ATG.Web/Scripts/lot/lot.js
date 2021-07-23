/// <reference path="../knockout-3.5.1.debug.js" />
///<reference path=


    $(function () {

        var viewModel = {
            // Data
            name: ko.observable(""),
            email: ko.observable(""),
            password: ko.observable(""),

            cname: ko.observable(""),
            industry: ko.observable(""),
            csizes: [
                { key: "S", name: "Small" },
                { key: "M", name: "Medium" },
                { key: "L", name: "Large" }],
            csize: ko.observable(),
           // csize: ko.observable(""),

            bAddress: ko.observable(""),
            postcode: ko.observable(""),
            isTCAccept: ko.observable(false),


            
        };

    ko.applyBindings(viewModel);


})



