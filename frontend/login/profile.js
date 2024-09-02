
async function userinfo(value){
var url =`https://localhost:7292/api/users/User/Userinfo/${value}`;
var response=await fetch(url);
var data = await response.json();
document.getElementById("useremail").innerHTML=data.email;
document.getElementById("Username").innerHTML=data.username;
document.getElementById("userid").innerHTML=data.userId;  
}
