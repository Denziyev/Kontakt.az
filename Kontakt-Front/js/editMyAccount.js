var fieldsetpassword=Array.from(document.querySelectorAll(".fieldset.password>div"));
var checkbox=Array.from(document.querySelectorAll(".field.choice>input"));
console.log(fieldsetpassword)
checkbox.forEach((item)=>{
    item.addEventListener("click",()=>{
        console.log("skjda")
        if(checkbox[0].checked){
            fieldsetpassword[0].style.display="block";
            fieldsetpassword[1].style.display="block";
            fieldsetpassword[2].style.display="none";
            fieldsetpassword[3].style.display="none";
        }
        if(checkbox[1].checked){
            fieldsetpassword[0].style.display="none";
            fieldsetpassword[1].style.display="block";
            fieldsetpassword[2].style.display="block";
            fieldsetpassword[3].style.display="block";
        }
        if(checkbox[0].checked && checkbox[1].checked){
            fieldsetpassword[0].style.display="block";
            fieldsetpassword[1].style.display="block";
            fieldsetpassword[2].style.display="block";
            fieldsetpassword[3].style.display="block";
        }
        if(!checkbox[0].checked && !checkbox[1].checked){
            fieldsetpassword[0].style.display="none";
            fieldsetpassword[1].style.display="none";
            fieldsetpassword[2].style.display="none";
            fieldsetpassword[3].style.display="none";
        }
    })
})