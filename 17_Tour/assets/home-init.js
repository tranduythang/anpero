var homeFontend = function () {
    function bindProduct(categoryId) {
        
        $("#feature-pr-content").addClass("loading-lazy");
        $.ajax({
            url: "/product/getByCategory",
            type:"post",
            data: { id: categoryId },
            success: function (data) {
                $("#feature-pr-content").removeClass("loading-lazy");
                $("#feature-pr-content").html(data);
            }
        });
    }
    function init() {
        $(".feature-product").click(function () {
            $(".feature-product").removeClass("actice");
            $(this).addClass("active");
            bindProduct($(this).data("id"));
        });
    }
    return {
        initHome: init
    };

}();