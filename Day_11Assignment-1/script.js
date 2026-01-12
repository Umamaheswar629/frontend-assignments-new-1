//1
document.getElementById("pageTitle").innerHTML="Customer Insurance Overiew";
//2
 let x=document.getElementsByTagName("li");
 for (let i=0;i<x.length;i++){
        x[i].style.border="2px solid";
        x[i].style.padding="3px";
        x[i].style.margin="2px";
 }
console.log(x.length);
//3
let t=document.getElementsByClassName("policy")
for(let i=0;i<t.length;i++){
   t[i].classList.add("highlight");
    t[i].style.color="blue";
}

/*let x1=document.querySelectorAll(".plocy").forEach(x1=>{
    x1.classList.add("highlight");
});*/
//4 
let c=document.querySelector(".customer")
console.log(c); 
let allc=document.querySelectorAll(".customer");
for(let i=0;i<allc.length;i++){
    console.log(allc[i]);
}
let l=allc.length
allc[l-1].classList.add("active");
//5:
let ll=document.querySelectorAll("form")
console.log(ll.length)
let il=document.querySelectorAll("img");
console.log(il.length);
let li=document.getElementsByTagName("a")
for(let i=0;i<li.length;i++){
    li[i].innerText="MoreInfo";
}
//6:
let el=document.createElement("li")
el.className="customer";
el.textContent="vaishnavi-home";
document.getElementById("customerList").appendChild(el);
//7:
let tl=document.querySelectorAll("input[type='text']");
for(let i=0;i<tl.length;i++){
    tl[i].style.background="yellow";
     tl[i].placeholder = "enterfullname"
}   
//8:
const prioritycustomers = 
    document.querySelectorAll(".customer.active");
prioritycustomers.forEach(customer => {
  customer.style.color = "green";
  customer.textContent += "(priority customer);"
});
//9:
const ds=document.querySelectorAll("#customerList li");
console.log(ds.length);
const cds=document.querySelectorAll("#customerList>li")
console.log(cds)
//10:
let ec=document.querySelectorAll(".customer");
for(let i=0;i<ec.length;i++){
    if(i%2==0){
        ec[i].style.background="lightgray";
       
    }
    else{
         ec[i].style.background = "lightblue";
    }
}
//11:
const enquiryForm = document.forms["enquiryForm"];
for(let i of enquiryForm.elements){
      console.log(element.name);
}
enquiryForm.querySelector("button").disabled=true;

//12
const pp=document.getElementsByClassName("policy");
const b=document.querySelectorAll(".policy")
const np=document.createElement("p");
np.className="policy";
np.textContent="travel";
document.body.appendChild(np);
//13:
const sc=document.querySelectorAll(".customer")
    sc.forEach(customer=>{
        let text=customer.textContent.toLowerCase();
        if(text.includes("life")){
        customer.style.backgroundColor = "lightgreen";            
        }
        if(text.includes("vehicle")){
            customer.style.display="none";
        }
    });

//14:
const cs=document.querySelectorAll(".customer")
cs.forEach(customer=>{
    customer.addEventListener("click",function(){
        const pul=this.closest("ul");
        pul.style.border="3px solid black"
    })
}); 

//15:
const rp=document.querySelectorAll("p.policy:not(first-child)");
rp.forEach(policy=>{
    policy.style.fontStyle="italic";
    policy.textContent = "✔ " + policy.textContent;
});