

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

var headerproductmenu=Array.from(document.querySelectorAll(".header-MenuModal-Container .product-menu li"));
var headerproductmenuopentop=2;
for (let index = 0; index < headerproductmenu.length; index++) {
    headerproductmenu[index].addEventListener("mouseover",()=>{
        console.log(index)
    headerproductmenuopentop=-(index*38);
    headerproductmenu[index].querySelector(".menuopen").style.top=`${headerproductmenuopentop}px`
    headerproductmenu[index].querySelector(".menuopen").style.border = "1px solid rgba(0, 0, 0,0.2)";
  })

}

var productmenu=Array.from(document.querySelectorAll(".menusidebar .product-menu li"));
var productmenuopentop=2;
for (let index = 0; index < productmenu.length; index++) {
  productmenu[index].addEventListener("mouseover",()=>{
    console.log(index)
    productmenuopentop=-(index*38);
    productmenu[index].querySelector(".menuopen").style.top=`${productmenuopentop}px`;
    productmenu[index].querySelector(".menuopen").style.height=`${productmenu.length*39.5+2}px`;
    productmenu[index].querySelector(".menuopen").style.border = "1px solid rgba(0, 0, 0,0.2)";
  })

}