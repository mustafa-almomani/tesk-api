var id=localStorage.getItem("CategoryIDChoosen")
const url =`https://localhost:7292/api/product/${id}`
var form=document.getElementById("form");

async function editproduct()
{
    event.preventDefault();
   
    var formData = new FormData(form);
    var response= await fetch(url ,{
        method: "PUT",
        body : formData 

        
    })

    alert("product updated Successfully");
  
}






async function getAlloption() {
    const url="https://localhost:7292/api/category"
    let request = await fetch(url);
    let data = await request.json();
    let option  = document.getElementById("Category");
    option.innerHTML = ""; 
    data.forEach((category) => {
        let newOption=`<option value="${category.categoryId}">${category.categoryName}</option>`;
        option.innerHTML += newOption;
    });

}
getAlloption()
  