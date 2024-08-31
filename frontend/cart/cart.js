
debugger
localStorage.UserId=1;
let userid =localStorage.getItem("UserId");
const url =`https://localhost:7292/api/CartItem/getallitems/${userid}`;

async function getallitem() 
{
    var response =await fetch(url);
    var result=await response.json();
    var table=document.getElementById("table")
    
   
    result.forEach((product) => {
     
        table.innerHTML += `

      <div class="row mb-4 d-flex justify-content-between align-items-center">
       <div class="col-md-1 col-lg-1 col-xl-1 text-end">
                              <h6 class="mb-0">${product.cartItemId}</h6>
                          </div>
                          <div class="col-md-2 col-lg-2 col-xl-2">
                            <img
                              src="../img/${product.product.ProductImage}"
                              class="img-fluid rounded-3" alt="${product.product.productName}">
                          </div>
                          <div class="col-md-3 col-lg-3 col-xl-3">
                            <h6 class="text-muted">Shirt</h6>
                            <h6 class="mb-0">${product.product.productName}</h6>
                          </div>
                          <div class="col-md-1 col-lg-1 col-sm-2 d-flex">
                            <button data-mdb-button-init data-mdb-ripple-init class="btn btn-link px-2"
                              onclick="this.parentNode.querySelector('input[type=number]').stepDown()">
                              <i class="fas fa-minus"></i>
                            </button>
      
                            <input style="padding-left: 10px;
    width: 25px;" id="form${product.cartItemId}"  name="quantity" value="${product.quantity}" type="number"
                              class="form-control form-control-lg" />
      
                            <button data-mdb-button-init data-mdb-ripple-init class="btn btn-link px-2"
                              onclick="this.parentNode.querySelector('input[type=number]').stepUp()">
                              <i class="fas fa-plus"></i>
                            </button>
                          </div>
                          <div class="col-md-3 col-lg-2 col-xl-2 offset-lg-1">
                            <h6 class="mb-0">€ ${product.product.price}</h6>
                          </div>
                          <div class="col-md-1 col-lg-1 col-xl-1 text-end">
                            <a href="#!" onclick="delet(${product.cartItemId})" class="text-muted"><i class="fas fa-times"></i></a>
                            <a href="#!" onclick="storeproductID(${product.cartItemId})" class="text-muted"><i class="fas fa-edit"></i></a>
                            
                          </div>
                        </div>

        `;
      });

}
getallitem() ;



async function delet(id)
{
  
 const url1 =`https://localhost:7292/api/CartItem/cartitem/deletitem/${id}`;
    

 
    var response= await fetch(url1 ,{
        method: "DELETE",
        
      

        
    })

    alert("product updated Successfully");
    location.reload();
  
}



  async function storeproductID(id)
  {
   
   const url1 =`https://localhost:7292/api/CartItem/cartitem/updateitem/${id}`;
      
     let q=document.getElementById(`form${id}`).value;
     let data =
     {
      quantity:q
     }
   
      var response= await fetch(url1 ,{
          method: "PUT",
          body : JSON.stringify(data),
          headers:
          {
            'Content-Type' : 'application/json'

          }
  
          
      })
  
      alert("product updated Successfully");
      location.reload();
    
  }
 













