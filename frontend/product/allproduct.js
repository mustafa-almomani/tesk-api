function storeproductID(productId) {
    debugger;
      localStorage.CategoryIDChoosen = productId;
    }
    async function fetchCardData() {
      let url = "https://localhost:7292/api/product/product/getAllProducts";
      const response = await fetch(url);
      let data = await response.json();
      // allData = data;
      let card = document.getElementById("contener");
    
      data.forEach((product) => {
        card.innerHTML += `
      <div class="col">
            <div class="card h-100 shadow-sm">
              <img
                src="../img/${product.productImage}"
                class="card-img-top"
                alt="..."
              />
              <div class="card-body">
                <div class="clearfix mb-3">
                  <span class="float-start badge rounded-pill bg-success"
                    >${product.price};</span
                  >
                  <span class="float-end"><a href="#">Example</a></span>
                </div>
                <h5 class="card-title">
                   ${product.productName}
                </h5>
                <div class="d-grid gap-2 my-4">
                  <a href="categoryditalis.html" onclick="storeCategoryID(${product.descr})" class="btn btn-warning">show more</a>
                </div>
              </div>
            </div>
          </div>

    
        `;
      });
      console.log(data);
    }
    
    fetchCardData();
    