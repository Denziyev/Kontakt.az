var formheaders=Array.from(document.querySelectorAll(".searchpageleft form>button"));  
console.log(formheaders)

formheaders.forEach((button)=>{
    button.addEventListener("click",()=>{
       console.log(button.nextElementSibling.style.display)
        button.classList.toggle("active");
        if(button.nextElementSibling.style.display=="none"){
            button.nextElementSibling.style.display="block";
        }
        else{
            button.nextElementSibling.style.display="none";
        }
    })

    
})


var naqdkreditbtns=Array.from(document.querySelectorAll(".btn-group-neqd-kred>button"));
var naqddisplays=Array.from(document.querySelectorAll(".gridprice_cash"));
var ayliqdisplays=Array.from(document.querySelectorAll(".gridprice_monthly"));
var sebeteatbtns=Array.from(document.querySelectorAll(".btn-add-to-cart"));

naqdkreditbtns[0].addEventListener("click",()=>{
    naqdkreditbtns[0].classList.add("active");
    naqdkreditbtns[1].classList.remove("active");
    naqddisplays.forEach((naqditem)=>{
        naqditem.style.display="block";
    })
     ayliqdisplays.forEach((ayliqitem)=>{
        ayliqitem.style.display="none";
     })
   sebeteatbtns.forEach((eachbtn)=>{
    eachbtn.textContent="Səbətə at";
   })
})

naqdkreditbtns[1].addEventListener("click",()=>{
    naqdkreditbtns[1].classList.add("active");
    naqdkreditbtns[0].classList.remove("active");
    naqddisplays.forEach((naqditem)=>{
        naqditem.style.display="none";
    })
     ayliqdisplays.forEach((ayliqitem)=>{
        ayliqitem.style.display="block";
     })

     sebeteatbtns.forEach((eachbtn)=>{
        eachbtn.textContent="Almaq";
       })

})

// var sortbtns=document.querySelectorAll(".list-view-by-cat>.list-view>li");
//   function sort() {
//     var cards = document.querySelectorAll('.product-list-items>.cart-item');
//     var sortedCards = Array.from(cards).sort(function(a, b) {
//       var aName = a.querySelector('.name>a').textContent;
//       var bName = b.querySelector('.name>a').textContent;
//       return aName.localeCompare(bName);
//     });
  
//     var productlist = document.querySelector('.product-list-items');
//     sortedCards.forEach(function(card) {
//         productlist.removeChild(card);
//         productlist.appendChild(card);
//     });
//   }
  

//   sortbtns[0].addEventListener('click',(e)=>{
//     sort();
//   });
  

var searchlabels=Array.from(document.querySelectorAll(".producer li label"));
searchlabels.forEach((label)=>{
   label.addEventListener("click",()=>{
    console.log("helllo")
      label.classList.toggle("active");
   })
})


var categorybestsellerbtn=document.querySelector("#scn_af784b3476000")
var lastwatchedbtn=document.querySelector("#scn_b8bb26baf6000");
var slidercategorybestsellerbtn=document.querySelector(".slidercategorybestsellerbtn")
var sliderlastwatchedbtn=document.querySelector(".sliderlastwatchedbtn");

categorybestsellerbtn.addEventListener("click",()=>{
    categorybestsellerbtn.classList.remove("seg-active");
    lastwatchedbtn.classList.remove("seg-active");
    categorybestsellerbtn.classList.add("seg-active");
   slidercategorybestsellerbtn.style.display="flex";
   sliderlastwatchedbtn.style.display="none";
})

lastwatchedbtn.addEventListener("click",()=>{
    categorybestsellerbtn.classList.remove("seg-active");
    lastwatchedbtn.classList.add("seg-active");
   sliderlastwatchedbtn.style.display="block";
   slidercategorybestsellerbtn.style.display="none";
})