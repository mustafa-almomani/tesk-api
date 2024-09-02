var url="https://localhost:7292/api/users/register"
var form=document.getElementById("form");
async function register()
 {
    debugger;
    
    event.preventDefault();
    let formData =new FormData(form);
  
     let response=await fetch(url,
        {
          method:"POST",
          body:formData
        }
        
     );

     if(document.getElementById("password").value===document.getElementById("confairmpassword"))
     { alert("user register is Successfully");
      window.location.href="login.html"
     }
     else{
      alert("user register is not Successfully");
     }
     
    
    
}