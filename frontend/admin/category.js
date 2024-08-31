// function myFunction11(id) {
//     debugger;
//     localStorage.setItem("id", product.categoryId);
//   }

function storeCategoryID(CategoryID) {
    debugger;
    localStorage.CategoryIDChoosen = CategoryID;
  }
  
  async function fetchCardData() {
    let url = "https://localhost:7292/api/category";
    const response = await fetch(url);
    let data = await response.json();
    // allData = data;
    let card = document.getElementById("table");
  
    data.forEach((product) => {
      card.innerHTML += `
  
      <tbody>
      <tr>
     
        <td>${product.categoryId}</td>
        <td>${product.categoryName}</td>
        <td><img src="../img/${product.categoryImage}"  style="width: 100px ; height: 100px;" ></td>
        <td scope="col"><button onclick="storeCategoryID(${product.categoryId})" class="btn" ><a style="color:black" href="editcategory.html">edit</a></button></td>
  
      </tr>
       </tbody>
  
        
         
        `;
    });
    console.log(data);
  }
  
  fetchCardData();
  
  
  