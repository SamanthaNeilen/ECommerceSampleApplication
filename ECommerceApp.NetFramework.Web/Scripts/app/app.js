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
            $("#modalPlaceholder .modal").modal('show');
        });        
    }
  
    return {
        initialize: initialize
    };
}());

$(document).ready(function () {
    ECommerceApp.initialize();
});

