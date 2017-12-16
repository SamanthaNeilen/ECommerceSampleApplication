ECommerceApp = (function() {
    function initialize() {
        $(".modal-link").on('click', function () {
            loadModal(this);
            return false;
        });
    }

    function loadModal(link)
    {
        $("#modalPlaceholder").load(link.href, function () {           
            fixUnobtrusiveJqueryValdationForPartialViews();
            $("#modalWrapper .modal").modal('show');
        });        
    }

    function fixUnobtrusiveJqueryValdationForPartialViews()
    {
        $("form").removeData("validator");
        $("form").removeData("unobtrusiveValidation");
        $.validator.unobtrusive.parse("form");
    }
  
    return {
        initialize: initialize
    };
}());

$(document).ready(function () {
    ECommerceApp.initialize();
});

