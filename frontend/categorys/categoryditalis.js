let n = Number(localStorage.getItem("CategoryIDChoosen"));
console.log("categoryid="+n);



function storeproductID(productId) {
  debugger;
  localStorage.pIDChoosen = productId;
}

// localStorage.setItem("ProductID",)
var url = `https://localhost:7292/api/product/product/GetProductById/${n}`;
console.log(url)
async function getproduct(){
    debugger;
    var request = await fetch(url);
    var result  = await request.json();
    
console.log(result )
console.log("Product ID:", result.productId);
        console.log("Product Name:", result.productName);
        console.log("Price:", result.price);
        console.log("Description:", result.descr);
        console.log("Product Image:", result.productImage);
    var contaner = document.getElementById("contaner");
    result.forEach(element => {
        contaner.innerHTML+=
    
        `  
         



               <div class="col">
            <div class="card h-100 shadow-sm">
              <img
                src="../img/${element.productImage}"
                class="card-img-top"
                alt="..."
              />
              <div class="card-body">
                <div class="clearfix mb-3">
                  <span style="color:black;" class="float-start badge rounded-pill bg-success"
                    >${element.price}$</span
                  >
                  <span class="float-end"><a href="#">Example</a></span>
                </div>
                <h4> ${element.productName}<h/4>
                <h5 class="card-title">
                ${element.descr}
                </h5>
                 <input type="number" id="input">
                <div class="d-grid gap-2 my-4">
                  <a href="../cart/cart.html" onclick="add(${element.productId})" class="btn btn-warning">add to cart</a>
                </div>
              </div>
            </div>
          </div>
          `;
    });
   
}
getproduct();


async function add(pID) {
  debugger;
  localStorage.setItem("productId",pID);
  localStorage.setItem("cartId",1);
  var Q = document.getElementById("input");

  const url = "https://localhost:7292/api/CartItem";
  var request = {
    CartId: localStorage.getItem("cartId"),
    ProductId: localStorage.getItem("productId"),
    Quantity: Q.value
    }
  var data = await fetch(url,
      {
        method : "POST",
        body : JSON.stringify(request),
        headers : {
            'Content-Type': 'application/json'
          }
      })
}