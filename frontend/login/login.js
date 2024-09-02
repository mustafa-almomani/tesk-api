var url = "https://localhost:7292/api/users/login";
async function login() {
  debugger;
  event.preventDefault();
  var data = {
    username: document.getElementById("username").value,
    password: document.getElementById("password").value,
    email: document.getElementById("email").value,
  };
  var responce = await fetch(url, {
    method: "POST",
    body: JSON.stringify(data),
    headers: {
      "Content-Type": "application/json",
    },
    
  });
 if (responce.ok){
    alert("user login is Successfully");
    window.location.href="../categorys/allcaregory.html"
 }
 else{
    alert("invalid username or password");
 }
}
