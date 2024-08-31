var id=localStorage.getItem("CategoryIDChoosen")
const url=`https://localhost:7292/api/category/category/${id}`;
var form=document.getElementById("form");
async function editcategory() 
{
  
    event.preventDefault();
   
    var formData = new FormData(form);
    var response= await fetch(url ,{
        method: "PUT",
        body : formData 

        
    })
    
    alert("Category updated Successfully");
}


