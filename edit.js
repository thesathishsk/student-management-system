function showphoto() {
    $("#enroll").hide();
    $("#photo").show();
    $("#parent").hide();
    $("#document").hide();
    $("#sign").hide();
    $("#lunch").hide();
    $("#health").hide();
    $("#siblings").hide();
    $("#contact").hide();
    $(".photobtn").css("border-bottom", "4px solid blue");

    $(".parentbtn").css("border-bottom", "0px solid blue");
    $(".lunchbtn").css("border-bottom", "0px solid blue");
    $(".signbtn").css("border-bottom", "0px solid blue");
    $(".documentbtn").css("border-bottom", "0px solid blue");
    $(".contactbtn").css("border-bottom", "0px solid blue");
    $(".enrollbtn").css("border-bottom", "0px solid blue");
    $(".healthbtn").css("border-bottom", "0px solid blue");

    $(".siblingsbtn").css("border-bottom", "0px solid blue");
}

function showenroll() {

    $("#photo").hide();
    $("#parent").hide();
    $("#document").hide();
    $("#sign").hide();
    $("#lunch").hide();
    $("#health").hide();
    $("#siblings").hide();
    $("#contact").hide();
    $("#enroll").show();
    $(".enrollbtn").css("border-bottom", "4px solid blue");
    localStorage.setItem("current", "enroll")
    $(".parentbtn").css("border-bottom", "0px solid blue");
    $(".lunchbtn").css("border-bottom", "0px solid blue");
    $(".signbtn").css("border-bottom", "0px solid blue");
    $(".documentbtn").css("border-bottom", "0px solid blue");
    $(".contactbtn").css("border-bottom", "0px solid blue");

    $(".healthbtn").css("border-bottom", "0px solid blue");
    $(".photobtn").css("border-bottom", "0px solid blue");
    $(".siblingsbtn").css("border-bottom", "0px solid blue");
}

function showlunch() {
    $("#photo").hide();
    $("#document").hide();
    $("#sign").hide();
    $("#lunch").show();
    $("#health").hide();
    $("#siblings").hide();
    $("#contact").hide();
    $("#enroll").hide();
    $("#parent").hide();
    $(".lunchbtn").css("border-bottom", "4px solid blue");

    $(".parentbtn").css("border-bottom", "0px solid blue");

    $(".signbtn").css("border-bottom", "0px solid blue");
    $(".documentbtn").css("border-bottom", "0px solid blue");
    $(".contactbtn").css("border-bottom", "0px solid blue");
    $(".enrollbtn").css("border-bottom", "0px solid blue");
    $(".healthbtn").css("border-bottom", "0px solid blue");
    $(".photobtn").css("border-bottom", "0px solid blue");
    $(".siblingsbtn").css("border-bottom", "0px solid blue");
}

function showhealth() {
    $("#photo").hide();
    $("#document").hide();
    $("#sign").hide();
    $("#lunch").hide();
    $("#health").show();
    $("#siblings").hide();
    $("#contact").hide();
    $("#enroll").hide();
    $("#parent").hide();
    $(".healthbtn").css("border-bottom", "4px solid blue");

    $(".parentbtn").css("border-bottom", "0px solid blue");
    $(".lunchbtn").css("border-bottom", "0px solid blue");
    $(".signbtn").css("border-bottom", "0px solid blue");
    $(".documentbtn").css("border-bottom", "0px solid blue");
    $(".contactbtn").css("border-bottom", "0px solid blue");
    $(".enrollbtn").css("border-bottom", "0px solid blue");

    $(".photobtn").css("border-bottom", "0px solid blue");
    $(".siblingsbtn").css("border-bottom", "0px solid blue");
}



function showdocument() {
    $("#photo").hide();
    $("#document").show();
    $("#sign").hide();
    $("#lunch").hide();
    $("#health").hide();
    $("#siblings").hide();
    $("#contact").hide();
    $("#enroll").hide();
    $("#parent").hide();
    $(".documentbtn").css("border-bottom", "4px solid blue");
    $("#current").val("doc");
    localStorage.setItem("current","doc")
    $(".parentbtn").css("border-bottom", "0px solid blue");
    $(".lunchbtn").css("border-bottom", "0px solid blue");
    $(".signbtn").css("border-bottom", "0px solid blue");

    $(".contactbtn").css("border-bottom", "0px solid blue");
    $(".enrollbtn").css("border-bottom", "0px solid blue");
    $(".healthbtn").css("border-bottom", "0px solid blue");
    $(".photobtn").css("border-bottom", "0px solid blue");
    $(".siblingsbtn").css("border-bottom", "0px solid blue");
}


function showsign() {
    $("#photo").hide();
    $("#document").hide();
    $("#sign").show();
    $("#lunch").hide();
    $("#health").hide();
    $("#siblings").hide();
    $("#contact").hide();
    $("#enroll").hide();
    $("#parent").hide();
    $(".signbtn").css("border-bottom", "4px solid blue");

    $(".parentbtn").css("border-bottom", "0px solid blue");
    $(".lunchbtn").css("border-bottom", "0px solid blue");
    $(".documentbtn").css("border-bottom", "0px solid blue");
    $(".contactbtn").css("border-bottom", "0px solid blue");
    $(".enrollbtn").css("border-bottom", "0px solid blue");
    $(".healthbtn").css("border-bottom", "0px solid blue");
    $(".photobtn").css("border-bottom", "0px solid blue");
    $(".siblingsbtn").css("border-bottom", "0px solid blue");
}



function showparent() {
    $("#photo").hide();
    $("#document").hide();
    $("#sign").hide();
    $("#lunch").hide();
    $("#health").hide();
    $("#siblings").hide();
    $("#contact").hide();
    $("#enroll").hide();
    $("#parent").show();

    $(".parentbtn").css("border-bottom", "4px solid blue");
    $(".lunchbtn").css("border-bottom", "0px solid blue");
    $(".signbtn").css("border-bottom", "0px solid blue");
    $(".documentbtn").css("border-bottom", "0px solid blue");
    $(".contactbtn").css("border-bottom", "0px solid blue");
    $(".enrollbtn").css("border-bottom", "0px solid blue");
    $(".healthbtn").css("border-bottom", "0px solid blue");
    $(".photobtn").css("border-bottom", "0px solid blue");
    $(".siblingsbtn").css("border-bottom", "0px solid blue");
}



function showsiblings() {
    $("#photo").hide();
    $("#document").hide();
    $("#sign").hide();
    $("#lunch").hide();
    $("#health").hide();
    $("#siblings").show();
    $("#contact").hide();
    $("#enroll").hide();
    $("#parent").hide();
    $(".siblingsbtn").css("border-bottom", "4px solid blue");

    $(".parentbtn").css("border-bottom", "0px solid blue");
    $(".lunchbtn").css("border-bottom", "0px solid blue");
    $(".signbtn").css("border-bottom", "0px solid blue");
    $(".documentbtn").css("border-bottom", "0px solid blue");
    $(".contactbtn").css("border-bottom", "0px solid blue");
    $(".enrollbtn").css("border-bottom", "0px solid blue");
    $(".healthbtn").css("border-bottom", "0px solid blue");
    $(".photobtn").css("border-bottom", "0px solid blue");

}

function showcontact() {
    $("#photo").hide();
    $("#document").hide();
    $("#sign").hide();
    $("#lunch").hide();
    $("#health").hide();
    $("#siblings").hide();
    $("#contact").show();
    $("#enroll").hide();
    $("#parent").hide();
    $(".contactbtn").css("border-bottom", "4px solid blue");

    $(".parentbtn").css("border-bottom", "0px solid blue");
    $(".lunchbtn").css("border-bottom", "0px solid blue");
    $(".signbtn").css("border-bottom", "0px solid blue");
    $(".documentbtn").css("border-bottom", "0px solid blue");

    $(".enrollbtn").css("border-bottom", "0px solid blue");
    $(".healthbtn").css("border-bottom", "0px solid blue");
    $(".photobtn").css("border-bottom", "0px solid blue");
    $(".siblingsbtn").css("border-bottom", "0px solid blue");
}


$(document).ready(function () {

  
    

});