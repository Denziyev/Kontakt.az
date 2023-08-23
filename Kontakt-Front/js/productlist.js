var formheaders=Array.from(document.querySelectorAll(".searchpageleft form>button"));  


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

var sortbtns=document.querySelectorAll(".list-view-by-cat>.list-view>li");



  function azsort() {
    var cards = document.querySelectorAll('.product-list-items>.cart-item');
    var sortedCards = Array.from(cards).sort(function(a, b) {
      var aName = a.querySelector('.name>a').textContent;
      var bName = b.querySelector('.name>a').textContent;
      return aName.localeCompare(bName);
    });
  
    var productlist = document.querySelector('.product-list-items');
    sortedCards.forEach(function(card) {
        productlist.removeChild(card);
        productlist.appendChild(card);
    });
  }

  function zasort() {
    var cards = document.querySelectorAll('.product-list-items>.cart-item');
    var sortedCards = Array.from(cards).sort(function(a, b) {
      var aName = a.querySelector('.name>a').textContent;
      var bName = b.querySelector('.name>a').textContent;
      return bName.localeCompare(aName);
    });
  
    var productlist = document.querySelector('.product-list-items');
    sortedCards.forEach(function(card) {
        productlist.removeChild(card);
        productlist.appendChild(card);
    });
  }

  
  var aaa=false;
  var zzz=false;

  sortbtns[0].addEventListener('click',(e)=>{
    if(aaa==false && zzz==false){
        azsort();
        aaa=true;
        sortbtns[0].querySelector("svg").classList.toggle("sgvup");
    }
    e.preventDefault()
  });

  sortbtns[0].addEventListener('click',(e)=>{
    if(aaa==true && zzz==true){
        zasort();
        zzz=false;
        aaa=false;
        sortbtns[0].querySelector("svg").classList.toggle("sgvup");
    }
    else{
        zzz=true;
    }
    e.preventDefault()
  });


  
  function oneninesort() {
    var cards = document.querySelectorAll('.product-list-items>.cart-item');
    var sortedCards = Array.from(cards).sort(function(a, b) {
      var aPrice = a.querySelector('.gridprice_cash>span').textContent;
      var bPrice = b.querySelector('.gridprice_cash>span').textContent;
      return aPrice-bPrice
    });
  
    var productlist = document.querySelector('.product-list-items');
    sortedCards.forEach(function(card) {
        productlist.removeChild(card);
        productlist.appendChild(card);
    });
  }

  function nineonesort() {
    var cards = document.querySelectorAll('.product-list-items>.cart-item');
    var sortedCards = Array.from(cards).sort(function(a, b) {
      var aPrice = a.querySelector('.gridprice_cash>span').textContent;
      var bPrice = b.querySelector('.gridprice_cash>span').textContent;
      return bPrice-aPrice
    });
  
    var productlist = document.querySelector('.product-list-items');
    sortedCards.forEach(function(card) {
        productlist.removeChild(card);
        productlist.appendChild(card);
    });
  }

var bbb=false;
var ttt=false;

  sortbtns[1].addEventListener('click',(e)=>{
    if(bbb==false && ttt==false){
        nineonesort();
        bbb=true;
        sortbtns[1].querySelector("svg").classList.toggle("sgvup");
        sortbtns[1].querySelector("svg").parentElement.querySelector("p").textContent=`Bahadan-ucuza`;
    }
    e.preventDefault()
  })

  sortbtns[1].addEventListener('click',(e)=>{
    if(bbb==true && ttt==true){
        oneninesort();
        ttt=false;
        bbb=false;
        sortbtns[1].querySelector("svg").classList.toggle("sgvup");
        sortbtns[1].querySelector("svg").parentElement.querySelector("p").textContent="Ucuzdan-bahaya";
    }
    else{
        ttt=true;
    }
    e.preventDefault()
})
  

var searchlabels=Array.from(document.querySelectorAll(".producer li label"));
searchlabels.forEach((label)=>{
   label.addEventListener("click",()=>{
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


//-------------------------------------------------------------

var filterbutton=document.querySelector(".right-nav");
var filterpage=document.querySelector(".searchpageleft")
var btnclosee=document.querySelector(".btn-close")
var footfixmenuu=document.querySelector(".footfixmenu");

filterbutton.addEventListener("click",()=>{
   filterpage.classList.add("active");
   footfixmenuu.style.display="none";
})
btnclosee.addEventListener("click",()=>{
    filterpage.classList.remove("active");
    footfixmenuu.style.display="flex";
 })

 var centernav=document.querySelector(".center-nav");
 centernav.addEventListener("click",(e)=>{
    if(centernav.querySelector("p").textContent=="Bahadan-ucuza"){
        centernav.querySelector("p").textContent="Ucuzdan-bahaya";
    }else{
        centernav.querySelector("p").textContent="Bahadan-ucuza";
    }

    e.preventDefault();
 })

 //=====================================================================