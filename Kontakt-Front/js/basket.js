var totalprice= document.querySelector(".about .price .pricespan");
var totalpricce= document.querySelector(".total .pricetotal");
var prices=Array.from(document.querySelectorAll(".details .details-right .gridprice .nprice"));
var pricescount=Array.from(document.querySelectorAll(".details .details-right .quantity input"));


var totalpricee;
for (let index = 0; index < pricescount.length; index++) {
   
    pricescount[index].previousElementSibling.addEventListener("click",()=>{
        totalpricee=0;
       for (let i = 0; i < prices.length; i++) {
           totalpricee+=(parseFloat(prices[i].textContent)*pricescount[i].value)
       }
        totalprice.textContent=`${totalpricee.toFixed(2)}`
        totalpricce.textContent=`${totalpricee.toFixed(2)}`
    })
    pricescount[index].nextElementSibling.addEventListener("click",()=>{
        totalpricee=0;
       for (let i = 0; i < prices.length; i++) {
           totalpricee+=(parseFloat(prices[i].textContent)*pricescount[i].value)
       }
        totalprice.textContent=`${totalpricee.toFixed(2)}`
        totalpricce.textContent=`${totalpricee.toFixed(2)}`
    })
}


