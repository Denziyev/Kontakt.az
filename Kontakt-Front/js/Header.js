


const submit = document.querySelector(".search");
const searchInput = document.querySelector(".title-search-input")
const containertag = document.querySelector(".searchbytag")
const containerproduct = document.querySelector(".searchbyproduct")
const containercategory = document.querySelector(".searchbycategory")
const searchresult = document.querySelector(".searchResult")

searchInput.addEventListener("input", (e) => {
    e.preventDefault();

    if(searchInput.value.trim()!=""){
    searchresult.style.display="block";

    
    let hreff = `/product/searchbytag?search=${searchInput.value}`;
    fetch(hreff)
        .then(x => x.json())
        .then(x => {
      
            containertag.innerHTML = ` <dt role="listbox" class="autocomplete-list-title title-term">Axtarış şərtləri</dt>`
         
            x.forEach(item => {
             
                let view = `
                            
                                           <dd class="" id="qs-option-0" role="option">
                                            <span class="qs-option-name">${item.name}</span>
                                                <span aria-hidden="true" class="amount">${item.productTags?.length}</span>
                                        </dd>
                    `;
                containertag.innerHTML += view;
            })
        });



    let href = `/product/search?search=${searchInput.value}`;
    fetch(href)
        .then(x => x.json())
        .then(x => {
         
            containerproduct.innerHTML = ` <dt role="listbox" class="autocomplete-list-title title-product">Products</dt>`
           
            x.forEach(item => {
           
                let view = `
                    <a
                                        class="searchResultItem" id="qs-option-5" role="option"
                                        href="/product/detail/${item.id}">
                                        <div class="searchResultItem__img">
                                            <img width="50px" height="50px"
                                                    src="/Assets/assets/images/Products/${item.productImages[0].image}"
                                                alt="iPhone 11 128 GB Black">
                                        </div>
                                        <div class="searchResultItem__title">${item.name}</div>
                                        <div class="searchResultItem__price searchResultItem__price--fd">
                                                <em>${item.price}&nbsp;₼</em><span>  ${item.price - ((item.discountofProduct.percent * item.price) / 100 )}&nbsp;₼</span>
                                        </div>
                                    </a>
            `;
                containerproduct.innerHTML += view;
            })
        });

    let href2 = `/product/searchbycategory?search=${searchInput.value}`;
    fetch(href2)
        .then(x => x.json())
        .then(x => {

            containercategory.innerHTML = `                                                                 <dt role="listbox" class="autocomplete-list-title title-product">Categories</dt>`

            x.forEach(item => {
              

  
                var maps = new Array();
                maps.push(item.name)

  


if (item.parentCategory != undefined)
{
  
    var currentItem = item; // Create a copy of the current item
    while (currentItem?.parentCategory != undefined)
    {
        currentItem = currentItem.parentCategory; // Move to the parent category
        if (currentItem != undefined)
        {
            maps.push(currentItem.name);
        }
    }

}
                let view = `


                          <a
                                        class="" id="qs-option-10" role="option"
                                        href="/category/index/${item.id}">         
                `;

                for (var i = maps.length-1; i >= 0; i--) {
                    if (i != 0) {
                       view+=` <span>${maps[i]} > </span>`
                    }
                    else {
                        view += ` <span style="opacity:0.8"><strong>${maps[i]} </strong> </span>`
                    }
                }

                view+=`</a>`;


                containercategory.innerHTML += view;
            })
        })

}
else{
containercategory.innerHTML="";
containerproduct.innerHTML="";
containertag.innerHTML="";
searchresult.style.display="none";

}

})

// const Modal=document.querySelector(".monthly-payment-modal")
const ModalBtn=document.querySelector(".info ul .ModalBtn")
const ModalContainer=document.querySelector(".Modal-container")
const ModalContent=document.querySelector(".Modal-content")



ModalBtn.addEventListener("click", (x) => {
    ModalContainer.style.display="block";
    x.preventDefault();

});

ModalContainer.addEventListener("click",()=>{
    ModalContainer.style.display="none";
});

ModalContent.addEventListener("click",(e)=>{
     e.stopPropagation();
});


const MenuModalBtn=document.querySelector(".menu-icon")
const MenuModalContainer=document.querySelector(".MenuModal-container")
const Menusidebar=document.querySelector(".menusidebar .MenuModal-content")
const MenuModalContent=document.querySelector(".MenuModal-content")


MenuModalBtn.addEventListener("click", (x) => {
    MenuModalContainer.style.display="block";
    Menusidebar.style.display="none";

    x.preventDefault();

});

MenuModalContainer.addEventListener("click",()=>{
    MenuModalContainer.style.display="none";
    Menusidebar.style.display="block";
});

MenuModalContent.addEventListener("click",(e)=>{
     e.stopPropagation();
});

// const MenuModalvisiblecontainer=document.querySelector(".MenuModalvisible-container");
// const MenuModalvisibleContent=document.querySelector(".MenuModalvisible-content")
// MenuModalvisibleContent.addEventListener("mouseover",(e)=>{
//     MenuModalvisiblecontainer.style.width="100vw";
//     MenuModalvisiblecontainer.style.height="100vh";
// })

// MenuModalvisibleContent.addEventListener("mouseout",(e)=>{
//     MenuModalvisiblecontainer.style.width="267px";
//     MenuModalvisiblecontainer.style.height="580px";
// })

var headerproductmenu=Array.from(document.querySelectorAll(".header-MenuModal-Container .product-menu>li"));
var headerproductmenuopentop=2;
for (let index = 0; index < headerproductmenu.length; index++) {
    headerproductmenu[index].addEventListener("mouseover",()=>{
      headerproductmenuopentop=-((index)*38+1);
      headerproductmenu[index].querySelector(".menuopen").style.top=`${headerproductmenuopentop}px`;
      headerproductmenu[index].querySelector(".menuopen").style.height=`${(headerproductmenu.length)*38}px`;
      headerproductmenu[index].querySelector(".menuopen").style.border = "1px solid rgba(0, 0, 0,0.2)";
      headerproductmenu[index].querySelector(".menuopen").style.borderLeft = "0px solid rgba(0, 0, 0,0.2)";
 
  })

}



var productmenu=Array.from(document.querySelectorAll(".menusidebar .product-menu>li"));

var productmenuopentop=0;
for (let index = 0; index < productmenu.length; index++) {
  productmenu[index].addEventListener("mouseover",()=>{
  
    productmenuopentop=-((index)*46+1);
    productmenu[index].querySelector(".menuopen").style.top=`${productmenuopentop}px`;
    productmenu[index].querySelector(".menuopen").style.height=`${(productmenu.length)*46+2}px`;
    productmenu[index].querySelector(".menuopen").style.border = "1px solid rgba(0, 0, 0,0.2)";
    productmenu[index].querySelector(".menuopen").style.borderLeft = "0px solid rgba(0, 0, 0,0.2)";

  })

}


//-----------------------------------------------------------------------
var  headertop=document.querySelector(".header-top");
var headerbottom=document.querySelector(".header-bottom");
var tabheader=document.querySelector(".tablet-header");


    window.onscroll = function() {myFunction()};
function myFunction() {
    if (window.pageYOffset > headertop.offsetHeight) {
      headerbottom.style.position="fixed"
      headerbottom.style.borderBottom="2px solid rgba(0, 0, 0, .08)"
      headerbottom.style.width="100%"
      if(tabheader.style.display!="none"){
        tabheader.style.position="fixed"
        tabheader.style.borderBottom="2px solid rgba(0, 0, 0, .08)"
        tabheader.style.width="100%"
      }
    } else {
        headerbottom.style.position="initial";
        tabheader.style.position="initial";

    }
  }

  //-----------------------------------------------------------------------------

  const ModalBtn1=document.querySelector(".category-select .modalayliq2");
const ModalContainer1=document.querySelector(" #monthly-payment-modall");
const ModalContent1=document.querySelector("#monthly-payment-modall .Modal-content");

var mobmainmenu=document.querySelector("#mob-main-menu");



ModalBtn1.addEventListener("click", (x) => {
   mobmainmenu.classList.remove("active");
    ModalContainer1.style.display="block";
    x.preventDefault();

});

ModalContainer1.addEventListener("click",()=>{
    ModalContainer1.style.display="none";
});

ModalContent1.addEventListener("click",(e)=>{
     e.stopPropagation();
});