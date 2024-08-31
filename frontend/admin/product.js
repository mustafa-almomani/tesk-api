function storeproductID(productId) {
    debugger;
      localStorage.CategoryIDChoosen = productId;
    }
    async function fetchCardData() {
      let url = "https://localhost:7292/api/product/product/getAllProducts";
      const response = await fetch(url);
      let data = await response.json();
      // allData = data;
      let card = document.getElementById("table");
    
      data.forEach((product) => {
        card.innerHTML += `
        
       <tbody>
        <tr>
       
          <td>${product.productId}</td>
          <td>${product.productName}</td>
          <td>${product.descr}</td>
          <td>${product.price}</td>
          <td>${product.categoryId}</td>
          <td><img src="../img/${product.productImage}"  style="width: 100px ; height: 100px;" ></td>
          <td scope="col"><button class="btn" onclick="storeproductID(${product.productId})" ><a style="color:black" href="editproduct.html">edit</a></button></td>
    
        </tr>
         </tbody>
    
        `;
      });
      console.log(data);
    }
    
    fetchCardData();
    