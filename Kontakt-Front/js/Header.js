

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
const MenuModalContent=document.querySelector(".MenuModal-content")


MenuModalBtn.addEventListener("click", (x) => {
    MenuModalContainer.style.display="block";
    x.preventDefault();

});

MenuModalContainer.addEventListener("click",()=>{
    MenuModalContainer.style.display="none";
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

