


$("#repostSubmitBtn").click(function () {

    alert("wtf");
    // alert("submit button clicked");
    var tagList = new Array();

    //going to find out the note that was submitted by name of title

    $(".tags").each(function () {

        alert($(this).text());

        var tag = {
            Name: $(this).text()
        };

        ////test += " " + tag;
       // console.log("d" + test);
        //var tagObj = { "tag": tag };
       // var ajaxTag = JSON.stringify(tagObj);

        //tagList.push(tagObj);
        /* AJAX TO TAG DB :)  
        $.ajax({
            type: "POST",
            url: "/Tag/Create",
            data: ajaxTag,
            contentType: "application/json; charset=utf-8",
            dataType: "json"
        });       */
    });
    //alert("after button clicked");
});

$("#addNoteBtn").click(function () {
   // alert("submit button clicked");
    var tagList = new Array();
    
    //going to find out the note that was submitted by name of title

    $(".tags").each(function () {    

        alert($(this).text());

        var tag = {           
            Name: $(this).text()
        };

        test += " " + tag;
        console.log("d" + test);
        var tagObj = { "tag": tag };
        var ajaxTag = JSON.stringify(tagObj);

        //tagList.push(tagObj);
        /* AJAX TO TAG DB :)  
        $.ajax({
            type: "POST",
            url: "/Tag/Create",
            data: ajaxTag,
            contentType: "application/json; charset=utf-8",
            dataType: "json"
        });       */
    });
    //alert("after button clicked");
});

function existingTag(text) {
    var existing = false,
        text = text.toLowerCase();

    $(".tags").each(function () {
        if ($(this).text().toLowerCase() == text) {
            existing = true;
            return "";
        }
    });
    return existing;
}

$(function () {
    $(".tags-new input").focus();

    $(".tags-new input").keyup(function () {

        var tag = $(this).val().trim(),
            length = tag.length;

        if ((tag.charAt(length - 1) == ',') && (tag != ",")) {
            tag = tag.substring(0, length - 1);

            if (!existingTag(tag)) {
                $('<li class="tags"><span>' + tag + '</span><i class="fa fa-times"></i></i></li>').insertBefore($(".tags-new"));
                $(this).val("");
            }
            else {
                $(this).val(tag);
            }
        }
    });

    $(document).on("click", ".tags i", function () {
        $(this).parent("li").remove();
    });

});
