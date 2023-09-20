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

var cartremoves = document.querySelectorAll(".cart_remove");
var listProducts = document.querySelector(".cart_object");


cartremoves.forEach((cart) => {
cart.addEventListener("click", function () {
    debugger
    var idd = $(this).attr("data-id");


    $.ajax({
        url: "/product/RemoveBasket/" + idd,
        type: "POST",
        data: { idd: idd, },
        success: function (response) {

                debugger
                $.ajax({
                    url: "/product/GetAllBaskets/",
                    type: "Get",
                    dataType: "json",
                    success: function (response) {
                        cartobject.innerHTML = "";
                        response.foreach(item => {
                            let basketitem = `
                                       <section id="selected-cart-item-1103948" data-product-guid="TM-DG-SBP-1105-SM-1959"
                                class="selected-cart-item cart_object">
                                <div class="chosen-cart">
                                    <div class="checkbox">
                                        <input type="checkbox" class="form-check-input cart_select_item"
                                            id="select-1103948" data-id="1103948">
                                        <label class="form-check-label" for="select-1103948"></label>
                                    </div>

                                    <div class="photo-box">
                                        <div class="imgHolder">
                                            <img alt="iPhone 14 Pro 128 GB Deep Purple" data-qazy="true"
                                                src="~/Assets/assets/images/Products/${item.Product.ProductImages.FirstOrDefault().Image}">
                                        </div>
                                    </div>
                                    <div class="details">
                                        <div class="roww">
                                            <div class="details-left">
                                                <div class="features">
                                                    <p>
                                                        <a href="https://kontakt.az/iphone-14-pro-128-gb-deep-purple/"
                                                            data-id="1103948" data-reserve-id="1103948"
                                                            data-mid="TM-DG-SBP-1105-SM-1959"
                                                            data-price="2659.99" data-quantity="1">
${item.Product.Name}</a>
                                                    </p>
                                                    <p></p>


                                                    <div class="labels">


                                                        <div class="lbl-percentage">
                                                            <p>12 ay <span>Faizsiz</span></p>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="details-right">
                                                <div class="second-half">
                                                    <div class="quantity">
                                                        <p>Miqdar</p>
                                                            <button type="button" data-id="${item.Id}" class="decrease">-</button>
                                                        <input type="number"  value="${item.ProductCount}"
                                                            min="0" readonly="readonly" max="3"
                                                            class="amount cart_amount cart_amount_1103948"
                                                            data-id="1103948">
                                                                <button type="button" data-id="${item.Id}" class="increase">+</button>

                                                    </div>



                                                    <div class="price">
                                                        <p class="gridprice gridprice_cash endirimvar">
                                                            <span style="text-decoration:line-through;font-weight:normal">
${item.Product.Price}
                                                                <small
                                                                    class="azn_span">M</small></span><br><span class="nprice" id="price-1103948">
${(item.Product.Price - ((item.Product.DiscountofProduct.Percent * item.Product.Price) / 100))} <small class="azn_span">‎M</small>
                                                                </span>
                                                        </p>
                                                    </div>
                                                    <div class="cart-summary">
                                                        <a type="button" class="remove cart_remove"
                                                        data-id="${item.Id}" >
                                                            <img src="https://kontakt.az/wp-content/themes/kontakt8/ktn-assets/assets/bin.png"
                                                                     alt="">
                                                        </a>
                                                        <p><span id="price-1103948">2849.99</span><span
                                                                class="azn_span">‎M</span></p>
                                                    </div>
                                                </div>

                                            </div>

                                        </div>

                                        <div class="detail-mob">

                                            <div class="quantity">
                                                <p>Miqdar</p>
                                                <button type="button" class="decrease">-</button>
                                                <input type="number" id="amount_1103948" value="0" min="1"
                                                    max="3" readonly="readonly"
                                                    class="amount cart_amount cart_amount_1103948"
                                                    data-id="1103948">
                                                <button onclick="" type="button" class="increase">+</button>
                                            </div>
                                            <div>
                                                <p style="text-decoration:line-through ">2849.99 <small
                                                        class="azn_span">M</small></p>
                                                    <p style="color:red">
                                                        2659.99 <small class="azn_span">‎₼</small>
                                                </p>
                                            </div>


                                        </div>

                                    </div>

                                </div>
                                <div class="total-price">
                                    <p style="display:none">Cəmi: <span class="itemtotals itemtotal-1103948"
                                            data-id="1103948">2659.99 </span><span class="azn_span">‎M</span>
                                    </p>
                                    <p style="display:none" class="catdirilma_p">Çatdırılma:
                                        <span class="catdirilma_span"></span> <span>‎₼</span>
                                    </p>

                                </div>







                            </section>
                            `;
                            cartobject.innerHTML += basketitem;
                        })
                    }
                });
            
        }
    });
});
})





var increase = document.querySelectorAll(".increase")

increase.forEach((btnn) => {

btnn.addEventListener("click", function () {
    debugger
    var id = $(this).attr("data-id");

    $.ajax({
        url: "/product/increase/" + id,
        type: "POST",
        data: { id: id, },
        success: function (response) {
            if (response == "ok") {


            }
        }
    });
});
})


var decrease = document.querySelectorAll(".decrease")

decrease.forEach((btnn) => {

btnn.addEventListener("click", function () {
    debugger
    var id = $(this).attr("data-id");

    $.ajax({
        url: "/product/decrease/" + id,
        type: "POST",
        data: { id: id, },
        success: function (response) {
            if (response == "ok") {


            }
        }
    });
});
})



