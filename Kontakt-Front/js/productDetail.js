var mainimg=document.querySelector(".mainImg .single-product-link img");
var sidebarimgs=Array.from(document.querySelectorAll(".slider>div>button>img"));


sidebarimgs.forEach((imgg)=>{
    imgg.addEventListener("click",()=>{
        console.log("deyisdi")
        mainimg.src=imgg.src;
    })
})
var youtubeiframe=document.querySelector("#video-lighbox-modal");
var youtubevideoBtn=document.querySelector(".side-menu>div:nth-child(1)>button");
var modalbackground=document.querySelector(".modalbackdrop.faded");

youtubevideoBtn.addEventListener("click",(x)=>{
    youtubeiframe.classList.add("show");
    youtubeiframe.style.display="block";
    youtubeiframe.style.paddingRight="17px";
    modalbackground.classList.add("show");
    x.preventDefault();
})

modalbackground.addEventListener("click",()=>{
    console.log("her");
    youtubeiframe.classList.remove("show");
    modalbackground.classList.remove("show");
    youtubeiframe.style.display="none";
})

var embedcontainer=document.querySelector(".embed-container");
embedcontainer.addEventListener("click",(e)=>{
    e.stopPropagation();
})


//===================================================================================


