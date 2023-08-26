var mainimg=document.querySelector(".mainImg .single-product-link img");
var sidebarimgs=Array.from(document.querySelectorAll(".slider>div>button>img"));


sidebarimgs.forEach((imgg)=>{
    imgg.addEventListener("click",()=>{
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
    youtubeiframe.classList.remove("show");
    modalbackground.classList.remove("show");
    youtubeiframe.style.display="none";
})

var embedcontainer=document.querySelector(".embed-container");
embedcontainer.addEventListener("click",(e)=>{
    e.stopPropagation();
})


//===================================================================================

var finpopover=document.querySelector(".finpopover");
var popover=document.querySelector(".popover");

console.log(finpopover)

var closebutton=document.querySelector("#kontakt-modal-birklik .k7closebut")
closebutton.addEventListener("click",()=>{
    popover.classList.remove("active");
})
var modall=document.querySelector("#kontakt-modal-birklik")
modall.addEventListener("click",()=>{
    if(popover.classList.contains("active")){
        popover.classList.remove("active");  
    }
})

finpopover.addEventListener("click",()=>{
    setTimeout(()=>{
        popover.classList.add("active");
    },100)
})
popover.addEventListener("click",(e)=>{
   e.stopPropagation();
})


var birklikbtn=document.querySelector(".birkliker_sub");
var nisye_onc=document.querySelector(".nisye_onc");
var naqqd=document.querySelector("#inlineRadio1");
birklikbtn.addEventListener("click",()=>{
    if(nisye_onc.style.display=="none"){
    console.log(naqqd.nextElementSibling.after());
    }
})




var increasebtns=Array.from(document.querySelectorAll("button.increase"))

increasebtns.forEach((btn)=>{
   btn.addEventListener("click",()=>{
    btn.previousElementSibling.value=`${parseInt(btn.previousElementSibling.value)+1}`
   })
})


var decreasebtns=Array.from(document.querySelectorAll("button.decrease"))

decreasebtns.forEach((btn)=>{
   btn.addEventListener("click",()=>{
    if(btn.nextElementSibling.value>0){
    btn.nextElementSibling.value=`${parseInt(btn.nextElementSibling.value)-1}`
    }
   })
})


var checkboxes=Array.from(document.querySelectorAll(".checkbox .form-check-label"));
console.log(checkboxes)
checkboxes.forEach((item)=>{
  item.addEventListener("click",()=>{
    if(item.style.getPropertyValue("--pseudo-opacity")=="0"){
        item.style.setProperty("--pseudo-opacity", `1`);
    }
    else{
        item.style.setProperty("--pseudo-opacity", `0`);
    }
  })
})

// var cartamount=document.querySelectorAll(".cart_amount");
// var yekuncash=document.querySelector(".proceed-to-payment .pricespan")
// var cemm=0;
// cartamount.forEach((item)=>{
//     item.addEventListener("change",()=>{
//         cartamount.forEach((cashh)=>{
//             console.log(parseInt(cashh))
//             cemm+=(parseInt(cashh)*parseInt(cashh.parentElement.nextElementSibling.querySelector(".nprice").textContent));
//         })
//         yekuncash.textContent=`${cemm}`;
//     })
// })

var backtocart=document.querySelector(".back-to-cart");
backtocart.addEventListener("click",()=>{
    document.querySelector("#my-cart-modal").classList.remove("show");
})


var nisye_ay_modal=Array.from(document.querySelectorAll(".nisye_ay_modal"));
nisye_ay_modal.forEach((item)=>{
   item.addEventListener("click",()=>{
      nisye_ay_modal.forEach((modal)=>{
        modal.classList.remove("active");
      })
      item.classList.add("active");
      item.parentElement.nextElementSibling.querySelector(".aysay").textContent=`${item.value}`
      item.parentElement.nextElementSibling.querySelector(".ilkin").textContent=`${item.getAttribute("data-prepay")}`
      item.parentElement.nextElementSibling.querySelector(".ayliq").textContent=`${item.getAttribute("data-amount")}`
   })
})

var nisye_increasebtns=Array.from(document.querySelectorAll("button.nisye_increase"))

nisye_increasebtns.forEach((btn)=>{
   btn.addEventListener("click",()=>{
    btn.previousElementSibling.value=`${parseInt(btn.previousElementSibling.value)+1}`
   })
})


var nisye_decreasebtns=Array.from(document.querySelectorAll("button.nisye_decrease"))

nisye_decreasebtns.forEach((btn)=>{
   btn.addEventListener("click",()=>{
    if(btn.nextElementSibling.value>0){
    btn.nextElementSibling.value=`${parseInt(btn.nextElementSibling.value)-1}`
    }
   })
})

