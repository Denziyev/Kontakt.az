// function selectbox() {
//     $ = jQuery;
//     var selectHolder = $(".selectHolder");
//     selectHolder.each(function() {
//         var currentSelectHolder = $(this);
//         if (currentSelectHolder.find("h5").html() == undefined) {
//             var select = currentSelectHolder.find("select");
//             var options = select.children();
//             var selected_option = select.find("option:checked");
//             var selectHeader = $("<h5></h5>");
//             selectHeader.addClass("select_header");
//             selectHeader.html(selected_option.html());
//             currentSelectHolder.append(selectHeader);
//             var selectBodyHolder = $("<div></div>");
//             selectBodyHolder.addClass("select_body_holder");
//             currentSelectHolder.append(selectBodyHolder);
//             var selectBody = $("<ul></ul>");
//             selectBody.addClass("select_body");
//             window.flop_appended = 0;
//             options.each(function() {
//                 var option_text = $(this).html();
//                 var value = $(this).attr("value");
//                 if ($(this).attr("data-country") != undefined) {
//                     if (window.flop_appended == 0)
//                         selectHeader.html(selected_option.html().replace('[az]', '<img src="https://kontakt.az/wp-content/uploads/flags/az.svg">'));
//                     window.flop_appended = 1;
//                     option_text = option_text.replace('[' + $(this).attr("data-country") + ']', '<img src="https://kontakt.az/wp-content/uploads/flags/' + $(this).attr("data-country") + '.svg">');
//                 }
//                 var disabled = $(this).attr("disabled");
//                 var li = $("<li></li>")
//                 li.append(option_text);
//                 li.attr("data-value", value);
//                 if (disabled) {
//                     li.attr("data-disabled", "true")
//                 } else {
//                     li.attr("data-disabled", "false")
//                 }
//                 selectBody.append(li);
//             });
//             selectBodyHolder.append(selectBody);
//         }
//     });
// }
// jQuery(document).on("click", ".select_header", function($) {
//     jQuery(".selectHolder .select_header").not(jQuery(this)).removeClass("active");
//     jQuery(".selectHolder .select_body_holder").not(jQuery(this).next(0)).removeClass("active");
// });
// jQuery(document).on("click", ".select_body li", function($) {
//     var select = jQuery(this).parents(".select_body_holder").prevAll().eq(1);
//     if (!(jQuery(this).data("disabled"))) {
//         select.val(jQuery(this).data("value")).trigger("change");
//         jQuery(this).parents(".select_body_holder").prev().html(jQuery(this).html()).removeClass("active");
//         jQuery(this).parents(".select_body_holder").removeClass("active");
//     }
// });
// jQuery(document).on("click", function(e) {
//     var target = jQuery(e.target);
//     if (!(target.hasClass("selectHolder") || target.parents(".selectHolder").length)) {
//         jQuery(".selectHolder").children().removeClass("active");
//     }
// });



var selectheader= document.querySelector(".selecttheaderr");
var headerimg=selectheader.querySelector("img");
var prefixs=document.querySelector(".selectHolderpref");
var prefselectbodyholder=prefixs.querySelector(".select_body_holder");
var prefselectheader=prefixs.querySelector(".select_header");
var myphoneinput=document.querySelector(".myphonee");
var selectbodyholder=document.querySelector(".myselect_body_holder");
var flags=document.querySelectorAll(".myselect_body_holder>ul>li")
var prefs=prefselectbodyholder.querySelectorAll("ul>li");
selectheader.addEventListener("click",()=>{
  selectbodyholder.classList.toggle("actived");
})

prefselectheader.addEventListener("click",()=>{
   prefselectbodyholder.classList.toggle("actived");
})

flags.forEach((flag)=>{
   flag.addEventListener("click",()=>{
  selectheader.innerHTML=flag.innerHTML;

  selectbodyholder.classList.remove("actived");
if(flag !=flags[0]){
    prefixs.style.display="none"
    myphoneinput.classList.add("notaz");
}
else{
    prefixs.style.display="block";
    myphoneinput.classList.remove("notaz");
}
})
})

prefs.forEach((pref)=>{
    pref.addEventListener("click",()=>{
        prefselectheader.innerHTML=pref.innerHTML;
        prefselectbodyholder.classList.remove("actived");
    })
})


