var noteId, noteTitle, noteAuthorId, noteAuthorName, noteDesc, noteContent, noteUploaded;
var div1 = $("#div1");
var div2 = $("#div2");
var overlayTitle = $(".noteTitle");
var overlayAuthor = $(".noteAuthor");
var overlayDescription = $(".noteDescription");
var overlayContent = $(".noteContent");


$("#closeOverlayBtn").click(function() {
    RemoveOverlay();
    ResetGrid();
    $(".cards__item").css("width", "33.3333%");       
});

$("#closeRepostOverlayBtn").click(function() {
    RemoveRepostOverlay();
    ResetGrid();
    $(".cards__item").css("width", "33.3333%");       
});

$(document).on("click", ".glyphicon.glyphicon-heart", function() {
    noteId = $(this).closest("li").attr("id");
    var color = $( this ).css("color");        
    if (color == "rgb(255, 0, 0)") {
        $(this).css("color", "rgb(51, 51, 51)");           
    }
    if (color == "rgb(51, 51, 51)") {
        $(this).css("color", "rgb(255, 0, 0)");        
    }
    var like = {
        UserId: @Model.UserItem.Id,
        NoteId: noteId
    };
    var likeObj = { "like": like };
    var ajaxLike = JSON.stringify(likeObj); 
    $.ajax({
        type: "POST",
        url: "/Like/Add",
        data: ajaxLike,
        contentType: "application/json; charset=utf-8",
        dataType: "json"
    });
});

$(document).on("click", ".glyphicon.glyphicon-retweet", function() {
    noteId = $(this).closest("li").attr("id");
    var color = $( this ).css("color");        
    if (color == "rgb(255, 0, 0)") {
        $(this).css("color", "black");           
    }
    if (color == "rgb(51, 51, 51)") {
        $(this).css("color", "blue");        
    }       
    var closestLi = $(this).closest("li");
    noteId = $(this).closest("li").attr("id");
    noteTitle = closestLi.find("input#title").val();
    noteAuthorName = closestLi.find("input#authorName").val(); //id
    noteAuthorId = closestLi.find("input#author").val(); //name
    noteDesc = closestLi.find("input#description").val();
    noteContent = closestLi.find("input#content").val(); 
    noteUploaded = closestLi.find("input#uploaded").val(); 
    AddRepostOverlay(noteTitle, noteAuthorName, noteAuthorId, noteDesc, noteContent, noteUploaded);
});


$(document).on("click", ".clickableContent", function() {               
    var closestLi = $(this).closest("li");
    noteId = $(this).closest("li").attr("id");
    noteTitle = closestLi.find("input#title").val();
    noteAuthorName = closestLi.find("input#authorName").val(); //id
    noteAuthorId = closestLi.find("input#author").val(); //name
    noteDesc = closestLi.find("input#description").val();
    noteContent = closestLi.find("input#content").val();       
    $("#hiddenOAuthor").val(noteAuthorId); //original load here
    AddOverlay(noteId, noteTitle, noteAuthorName , noteDesc, noteContent);
});

function AddOverlay(noteId, noteTitle, noteAuthor, noteDesc, noteContent) {
    RemoveOverlay();
    $("#noteSection").addClass("noteOverlayStyling");
    div1.addClass("col-xs-8");
    div2.addClass("col-xs-4");
    $(".cards__item").css("width", "100%");        
    document.getElementById("overlay").style.display = "block";  
    $(overlayTitle).html(noteTitle);
    $(overlayAuthor).html(noteAuthor);
    $(overlayDescription).html(noteDesc);
    $(overlayContent).html(noteContent);
}

function AddRepostOverlay(noteTitle, noteAuthorName, noteAuthorId, noteDesc, noteContent, noteUploaded) {
    RemoveRepostOverlay();
    $("#noteSection").addClass("noteOverlayStyling");
    div1.addClass("col-xs-8");
    div2.addClass("col-xs-4");
    $(".cards__item").css("width", "100%");        
    document.getElementById("repostOverlay").style.display = "block";  
      
    $(overlayTitle).html(noteTitle);
    $(overlayAuthor).html(noteAuthorName);
    $(overlayDescription).html(noteDesc);
    $(overlayContent).html(noteContent);
        
    $("#overlayOAuthor").html("Original Author: " + noteAuthorName);
    $("#overlayUpload").html("Posted: " + noteUploaded);
}

function RemoveOverlay() {
    document.getElementById("searchBarContainer").style.display = "none";
    div2.removeClass("col-xs-12");
    document.getElementById("overlay").style.display = "none";
}

function RemoveRepostOverlay() {
    document.getElementById("searchBarContainer").style.display = "none";
    div2.removeClass("col-xs-12");
    document.getElementById("repostOverlay").style.display = "none";
}

function ResetGrid() {
    div2.addClass("col-xs-12");
    document.getElementById("searchBarContainer").style.display = "block";
}

$(document).on("click", ".glyphicon.glyphicon-search", function () {
    var searchText = $("#searchBarInput").val();
    alert(searchText);
});
   