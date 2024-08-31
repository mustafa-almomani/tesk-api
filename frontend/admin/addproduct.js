var url = "https://localhost:7292/api/product";
var form = document.getElementById("formm");
async function addproduct() {
  debugger;
  event.preventDefault();
  var formData = new FormData(form);
  let response = await fetch(url, {
    method: "POST",
    body: formData,
  });
  alert("product added Successfully");
}

async function getAlloption() {
  const url = "https://localhost:7292/api/category";
  let request = await fetch(url);
  let data = await request.json();
  let option = document.getElementById("product");
  option.innerHTML = "";
  data.forEach((product) => {
    let newOption = `<option value="${product.categoryId}">${product.categoryName}</option>`;
    option.innerHTML += newOption;
  });
 
}
getAlloption();
