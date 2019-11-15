Search = (function () {
    
    var config = {
        property: "",
        brands: "",
        category: "",
        sortBy:"nameDesc"
    };
    function doSearch() {
        var conditon = "";
        var param = "?";
        var properties = $("input[type=checkbox][name=properties]:checked");
        
        var branch = $("input[name=brands]:checked");
        
        var category = $("input[name=category]:checked");
        if (properties.length > 0) {
            var attributeIdList = "";
            properties.each(function () {
                attributeIdList += $(this).val() + ",";
            });
            conditon += param + "property=" + attributeIdList.substring(0, attributeIdList.length - 1);
            param = "&";
        }
        if (branch.length > 0) {
            var branchList = "";
            branch.each(function () {
                branchList += $(this).val() + ",";
            });
            conditon += param + "brands=" + branchList.substring(0, branchList.length - 1);
            param = "&";
        }
        if (category.length > 0) {
            var categoryList = "";
            category.each(function () {
                categoryList += $(this).val() + ",";
            });
            conditon += param + "category=" + categoryList.substring(0, categoryList.length - 1);
            param = "&";
        } else if (config.category!=""){
            conditon += param + "category=" + config.category;
            param = "&";
        }
        if (config.sortBy != "") {
            conditon += param + "SortBy=" + config.sortBy;
        }
        
        window.location.href = "/search" + conditon;
    }
    function init(param) {      
        var sortBy =getParameterByName("SortBy");
        if (typeof sortBy != 'undefined' && sortBy != null && sortBy !="") {
            $("#sort_by_select").val(sortBy);
        }
        
        config = $.extend(config, param);        
        $("input[type=checkbox][name=properties],input[name=brands],input[name=category]").click(function () {
            doSearch();           
        });
        $("#sort_by_select").change(function () {
            config.sortBy = $(this).val();
            doSearch();           
        });      
        if (config.property != "") {
            var propertyList = config.property.split(",");
            $("li.property-item").removeClass("active");
            for (var i = 0; i < propertyList.length; i++) {
                try {
                    $("li.property-item[data-id=" + propertyList[i] + "]").addClass("active");
                    $("input[type=checkbox][name=properties][value=" + propertyList[i] + "]").prop("checked", true);
                } catch (e) {
                    // do nothing
                }
            }
        }
        if (config.brands != "") {
            var brandsList = config.brands.split(",");            
            for (var i = 0; i < brandsList.length; i++) {
                try {
                    $("input[type=checkbox][name=brands][value=" + brandsList[i] + "]").prop("checked", true);
                } catch (e) {
                    // do nothing
                }
            }            
        }
        if (this.config.category != "" && this.config.category != "%") {
            var categoryList = config.category.split(",");      
            for (var i = 0; i < categoryList.length; i++) {
                try {
                    $("input[name=category][value=" + categoryList[i] + "]").prop("checked", true);
                } catch (e) {
                    // do nothing
                }
            }
        }
    }
    function getParameterByName(n) { n = n.replace(/[\[]/, "\\[").replace(/[\]]/, "\\]"); var i = new RegExp("[\\?&]" + n + "=([^&#]*)"), t = i.exec(location.search); return t == null ? "" : decodeURIComponent(t[1].replace(/\+/g, " ")) }
    return {
        init: init,
        config: config,
        doSearch: doSearch
       
    };
})();
