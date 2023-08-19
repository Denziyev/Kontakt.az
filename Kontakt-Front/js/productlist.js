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
