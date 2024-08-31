var url ='https://localhost:7292/api/category'
var form=document.getElementById("form")
 async function addcategore (){
    event.preventDefault();

    var formData= new FormData(form);
   
let response =await fetch(url,{
    method:'POST',
    body:formData,


})
alert("Category added Successfully");
 }