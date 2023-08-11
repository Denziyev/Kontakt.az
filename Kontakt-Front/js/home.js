//home page first carousel-------------------------------------------------------------------------------------------------
var nextBtn=document.querySelector(".carousel-control-next");
var PrevBtn=document.querySelector(".carousel-control-prev");
var currentslide=document.querySelectorAll(".carousel-inner .active")[0];
var firstslide=document.querySelectorAll(".carousel-inner .carousel-item")[0];
var lastslide=document.querySelectorAll(".carousel-inner .carousel-item")[document.querySelectorAll(".carousel-inner .carousel-item").length-1]

nextBtn.addEventListener("click",nextslidefunction);
PrevBtn.addEventListener("click",previousslidefunction);
function nextslidefunction(){
    currentslide=document.querySelectorAll(".carousel-inner .active")[0];

    if(currentslide.nextElementSibling==null){
      firstslide.classList.add("active");
    }
    else{
        currentslide.nextElementSibling.classList.add("active");
    }
    currentslide.classList.remove("active");
}


function previousslidefunction(){
    currentslide=document.querySelectorAll(".carousel-inner .active")[0];
    if(currentslide.previousElementSibling==null){
        lastslide.classList.add("active");
      }
      else{
          currentslide.previousElementSibling.classList.add("active");
      }
    currentslide.classList.remove("active");
}


setInterval(nextslidefunction, 3000);

//----------------------------------------------------------------------------

const partnerprevbtn=document.getElementsByClassName("owl-prev")[0];
const partnernextbtn=document.getElementsByClassName("owl-next")[0];
const partnertransformelement =Array.from(document.getElementsByClassName("owl-item"));
// console.log(partnernextbtn)
// console.log(partnertransformelement)
var firstactivepartner=[...document.getElementsByClassName("owl-carousel")[0].getElementsByClassName("owl-stage")];
// console.log(firstactivepartner)
// var firstactivepartner=setTimeout([...document.getElementsByClassName("owl-carousel")[0].getElementsByClassName("owl-stage")], 5000);
function nextpartnerfunction(){
    
}


//----------------------------------------------------------------------------------------

//partner slider setinterval







//-----------------------topsellerdə active category dəyişməsi--------------------------------------------------
var topselleritemslink=document.querySelectorAll(".round-edge-tab .nav-item  .nav-link");
var topselleritems=Array.from(document.querySelectorAll(".round-edge-tab .nav-item"));
var currentactivetopsellerlink=document.querySelector(".round-edge-tab .nav-item .active");
var alltopselleritems=Array.from(document.querySelectorAll(".topseller_theme .cart-item"));
var chooseitems=Array.from(document.querySelectorAll(".topseller_theme .Smartsaat"));
topselleritems.forEach((item)=>{
    item.addEventListener("click",()=>{
        currentactivetopsellerlink=document.querySelector(".round-edge-tab .nav-item .active");
   currentactivetopsellerlink.classList.remove("active");
   item.getElementsByClassName("nav-link")[0].classList.add("active");
//    console.log(item.textContent.trim().toString())


   alltopselleritems.forEach((x)=>{
    if(!x.classList.contains(item.textContent.trim())){
        x.parentElement.style.display="none";
    }
    else{
        x.parentElement.style.display="none";
        // console.log( x.parentElement)
    }
   })
    })
})
//------------------------------------------------------------------------------------------------------------------------------------------------


