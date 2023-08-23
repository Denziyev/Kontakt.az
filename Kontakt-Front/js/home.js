//home page first carousel-------------------------------------------------------------------------------------------------
var nextBtn = document.querySelector(".carousel-control-next");
var PrevBtn = document.querySelector(".carousel-control-prev");
var currentslide = document.querySelectorAll(".carousel-inner .active")[0];
var firstslide = document.querySelectorAll(".carousel-inner .carousel-item")[0];
var lastslide = document.querySelectorAll(".carousel-inner .carousel-item")[document.querySelectorAll(".carousel-inner .carousel-item").length - 1]

nextBtn.addEventListener("click", nextslidefunction);
PrevBtn.addEventListener("click", previousslidefunction);
function nextslidefunction() {
    currentslide = document.querySelectorAll(".carousel-inner .active")[0];

    if (currentslide.nextElementSibling == null) {
        firstslide.classList.add("active");
    }
    else {
        currentslide.nextElementSibling.classList.add("active");
    }
    currentslide.classList.remove("active");
}


function previousslidefunction() {
    currentslide = document.querySelectorAll(".carousel-inner .active")[0];
    if (currentslide.previousElementSibling == null) {
        lastslide.classList.add("active");
    }
    else {
        currentslide.previousElementSibling.classList.add("active");
    }
    currentslide.classList.remove("active");
}


setInterval(nextslidefunction, 3000);

//----------------------------------------------------------------------------

const partnerprevbtn = document.getElementsByClassName("owl-prev")[0];
const partnernextbtn = document.getElementsByClassName("owl-next")[0];


setTimeout(() => {
    const partnertransformelement = Array.from(document.getElementsByClassName("owl-item"));
}, 1000);

// console.log(partnernextbtn)
// console.log(partnertransformelement)
var firstactivepartner = [...document.getElementsByClassName("owl-carousel")[0].getElementsByClassName("owl-stage")];
// console.log(firstactivepartner)
// var firstactivepartner=setTimeout([...document.getElementsByClassName("owl-carousel")[0].getElementsByClassName("owl-stage")], 5000);
function nextpartnerfunction() {

}

//-----------------------topsellerdə active category dəyişməsi--------------------------------------------------
var topselleritemslink = document.querySelectorAll(".round-edge-tab .nav-item  .nav-link");
var topselleritems = Array.from(document.querySelectorAll(".round-edge-tab .nav-item"));
var currentactivetopsellerlink = document.querySelector(".round-edge-tab .nav-item .active");
var alltopselleritems = Array.from(document.querySelectorAll(".topseller_theme .cart-item"));
// console.log(alltopselleritems)
var chooseitems = Array.from(document.querySelectorAll(".topseller_theme .Smartsaat"));
topselleritems.forEach((item) => {
    item.addEventListener("click", () => {
        currentactivetopsellerlink = document.querySelector(".round-edge-tab .nav-item .active");
        currentactivetopsellerlink.classList.remove("active");
        item.getElementsByClassName("nav-link")[0].classList.add("active");
        //    console.log(item.textContent.trim().toString())
        // console.log(alltopselleritems)

        alltopselleritems.forEach((x) => {
            console.log(x.classList.contains(item.textContent.trim()))
            if (!x.classList.contains(item.textContent.trim())) {
                x.parentElement.style.display = "none";
                // console.log(x.parentElement)
            }
            else {
                x.parentElement.style.display = "flex";
            }
        })
    })
})
//------------------------------------------------------------------------------------------------------------------------------------------------


var cardlikbuttons=Array.from(document.querySelectorAll(".cart-action>button:nth-child(1)"));
var cardscalebuttons=Array.from(document.querySelectorAll(".cart-action>button:nth-child(2)"));

cardlikbuttons.forEach((btn)=>{
    btn.addEventListener("click",()=>{
       if(btn.style.backgroundColor=="red"){
        btn.style.backgroundColor="white";
       }
       else{
        btn.style.backgroundColor="red"
       }
    })
})
cardscalebuttons.forEach((btn)=>{
    btn.addEventListener("click",()=>{
    
       if(btn.style.backgroundColor=="red"){
        btn.style.backgroundColor="white"
       }
       else{
        btn.style.backgroundColor="red"
       }
    })
})



//====================================================================

var mobmainmenu=document.querySelector("#mob-main-menu");
var hamburgericon=document.querySelector(".HamburgerIcon");
var menuxiconmobs=document.querySelector(".menu-icon-mobs");
var allcategorymenu=document.querySelector(".all-category-menu");



hamburgericon.addEventListener("click",()=>{
    mobmainmenu.classList.add("active");
})
allcategorymenu.addEventListener("click",()=>{
    mobmainmenu.classList.add("active");
})
menuxiconmobs.addEventListener("click",()=>{
    mobmainmenu.classList.remove("active");
})

//===================================================================

var productmenuuli=Array.from(document.querySelectorAll(".category-menu>.product-menu>li"))
var menubuttonn=Array.from(document.querySelectorAll(".menu-button"))[1];
var categorymenuu=document.querySelector(".category-menu");

productmenuuli.forEach((li)=>{
 li.querySelector("a").addEventListener("click",()=>{
    document.querySelector(".category-select").classList.toggle("disnonee");
    li.querySelector(".sub-menu").classList.toggle("active");
   menubuttonn.classList.toggle("disnonee")
   document.querySelector(".divu6060").classList.toggle("disnonee");
   document.querySelector(".mobmenugeri").classList.toggle("disblockk")
   li.querySelector(".sub-menu-open").classList.toggle("disblockk")
   productmenuuli.forEach((lii)=>{
    if(lii!=li){
        lii.classList.toggle("disnonee")
    }
   })
 })
})

document.querySelector(".mobmenugeri").addEventListener("click",()=>{
    menubuttonn.classList.remove("disnonee");
    productmenuuli.forEach((li)=>{
        li.querySelector(".sub-menu").classList.remove("active");
        li.querySelector(".sub-menu-open").classList.remove("disblockk")
        li.classList.remove("disnonee");
    })
    document.querySelector(".divu6060").classList.toggle("disnonee");
    document.querySelector(".mobmenugeri").classList.toggle("disblockk")
    document.querySelector(".category-select").classList.toggle("disnonee");
})



var submenulis=Array.from(document.querySelectorAll(".category-menu>.product-menu>li>.sub-menu-open>ul>li"));

submenulis.forEach((subli)=>{
    subli.addEventListener("click",()=>{
        subli.querySelector(".sub-menu-product-open").classList.toggle("disblockk");
    })
})







menubuttonn.addEventListener("click",()=>{
    menubuttonn.classList.toggle("active");
    if(categorymenuu.style.display=="block"){
        categorymenuu.style.display="none" ;
    }
    else{
        categorymenuu.style.display="block";
    }
})


//------------------------------------------------------------------------------------------------------------------
var nextBtn1 = document.querySelector(".respdiscountsidebartopslidertop .carousel-control-next");
var PrevBtn1 = document.querySelector(".respdiscountsidebartopslidertop .carousel-control-prev");
var currentslide1 = document.querySelectorAll(".respdiscountsidebartopslidertop .carousel-inner .active")[0];
var firstslide1 = document.querySelectorAll(".respdiscountsidebartopslidertop .carousel-inner .carousel-item")[0];
var lastslide1 = document.querySelectorAll(".respdiscountsidebartopslidertop .carousel-inner .carousel-item")[document.querySelectorAll(".carousel-inner .carousel-item").length - 1]

nextBtn1.addEventListener("click",nextslidefunction1);
PrevBtn1.addEventListener("click", previousslidefunction1);
function nextslidefunction1() {
    currentslide1 = document.querySelectorAll(".respdiscountsidebartopslidertop .carousel-inner .active")[0];

    if (currentslide1.nextElementSibling == null) {
        firstslide1.classList.add("active");
    }
    else {
        currentslide1.nextElementSibling.classList.add("active");
    }
    currentslide1.classList.remove("active");
}


function previousslidefunction1() {
    currentslide1 = document.querySelectorAll(".respdiscountsidebartopslidertop .carousel-inner .active")[0];
    if (currentslide1.previousElementSibling == null) {
        lastslide1.classList.add("active");
    }
    else {
        currentslide1.previousElementSibling.classList.add("active");
    }
    currentslide1.classList.remove("active");
}


setInterval(nextslidefunction1, 3000);



//===============================================================

var selectheader=document.querySelector(".select_header");

selectheader.addEventListener("click",()=>{
    selectheader.classList.toggle("active")
    selectheader.nextElementSibling.classList.toggle("active");
})

selectheader.nextElementSibling.querySelectorAll("li").forEach((onecateitem)=>{
    onecateitem.addEventListener("click",()=>{
        selectheader.textContent=onecateitem.textContent
        selectheader.classList.remove("active")
        selectheader.nextElementSibling.classList.remove("active");
    })
})

//=============================================================