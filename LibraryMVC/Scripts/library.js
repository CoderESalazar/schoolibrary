//Discovery Roadrunner Search script
function limittoFullText(myForm) {
    if (myForm.fulltext_checkbox.checked) myForm.clv0.value = "Y";
    else myForm.clv0.value = "N";
}
function limittoScholarly(myForm) {
    if (myForm.scholarly_checkbox.checked) myForm.clv1.value = "Y";
    else myForm.clv1.value = "N";
}
function ebscoPreProcess(myForm) {
    myForm.bquery.value = myForm.search_prefix.value + myForm.uquery.value;
}
(function (i, s, o, g, r, a, m) {
    i['GoogleAnalyticsObject'] = r; i[r] = i[r] || function () {
        (i[r].q = i[r].q || []).push(arguments)
    }, i[r].l = 1 * new Date(); a = s.createElement(o),
    m = s.getElementsByTagName(o)[0]; a.async = 1; a.src = g; m.parentNode.insertBefore(a, m)
})(window, document, 'script', '//www.google-analytics.com/analytics.js', 'ga');

ga('create', 'UA-54065804-1', 'auto');
ga('send', 'pageview');

//DatePicker Script            
//jQuery(function ($) {

//    $("#date").datepicker({ minDate: 3, maxDate: "+1M +10D" });

//});

//function used to check file size before uploading
jQuery(function ($) {
    $('#uploadfile').bind('change', function () {

        var filesize = this.files[0].size;
        var len = $("#uploadfile").val().length;

        if (len > 50) {

            alert('File name exceeds 50 characters! Please rename file and reselect.');

            return false;
        }
        if (filesize > 4194304) {
            confirm("File size exceeds 4MB! Proceeding further will result in a page error.");

            return false;
        }

        var f = document.querySelectorAll('input[type=file]');
        var clearInput = function () { this.value = '' };
        for (var i = 0; i < f.length; i++) {
        f[i].addEventListener('click', clearInput);
        }

    })

});

//Autocomplete Script        
jQuery(function ($) {

    $("#tags").autocomplete({
        minLength: 3,
        source: function (request, response) {
            $.ajax({
                //url: '@Url.Action("FindFaqs", "Search")', type: "POST", dataType: "json",
                url: "/home/findfaqs", type: "POST", dataType: "json",
                data: { searchText: request.term, maxResults: 15 },
                success: function (data) {
                    response($.map(data, function (item) {

                        return { label: item.lib_q_edit, value: item.lib_q_edit, id: item.q_id }


                    }));

                }

            });

        },
        select: function (event, ui) {

            window.location.href = '/faq/faqview/' + ui.item.id.toString();
            //                    alert(ui.item ? ("You picked '" + ui.item.label + "' with an ID of " + ui.item.id) 
            //                        : "Nothing selected, input was " + this.value);
        }
    }).each(function () {
        $(this).data("uiAutocomplete")._renderItem = function (ul, item) {
            return $("<li></li>").data("item.autocomplete", item).append("<a>" + item.label + "</a>").appendTo(ul);


        }

    });

});



