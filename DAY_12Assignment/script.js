
const policiesData = [
  { id: 1, name: "Health Plus", type: "Health", premium:12000, duration: 1, status: "Active" },
  { id: 2, name: "Life Secure", type: "Life", premium: 9000, duration: 10, status: "Inactive" },
  { id: 3, name: "Car Protect", type: "Vehicle", premium: 7000, duration: 1, status: "Active" },
  { id: 4, name: "Family Health", type: "Health", premium: 15000, duration: 2, status: "Active" }
];
function fetchfrom(){
    return  new Promise((resolve,reject)=>{
        setTimeout(()=>{
        let s=true;
        if(s){
            resolve(policiesData);
        }
        else{
            reject("Failed to fetch the data");
        }
        },1000);
    }
)};
async function fetchp(){
    try{
        policies=await fetchfrom();
        console.log("policies fetched sucessfully",policies);
    } catch(error){
        console.error("Api error",error);
    }
};
fetchp();

let t=document.getElementById("Insurance");
policiesData.forEach((ins)=>{
    console.log(ins)
    let div=document.createElement("div");
    div.innerHTML=`${ins.id}| ${ins.name}| ${ins.type}|${ins.premium}|${ins.duration}|${ins.status}<br>`;
    t.append(div)
});
let x=document.getElementById("Insurance-2");
 policiesData.forEach((ins)=>{
    let div=document.createElement("div");
    div.innerHTML=`${ins.name} | ${ins.type}| ${ins.premium} |${ins.duration} |${ins.status} <br>`;
    x.append(div);
 });
let healthPolicies = policiesData.filter(p => p.type === "Health");
console.log(healthPolicies);
let LifePolicies=policiesData.filter(p=>p.type==="Life");
console.log(LifePolicies);
let mk=policiesData.filter(p=>p.type==="Vehicle");
console.log(mk);
//4:
let TotalPremium=policiesData.reduce((total,p)=>{
if(p.status==='Active'){
  return total+p.premium;
}
return total;
},0);
console.log(TotalPremium);
//5:
let Dis=policiesData.map(p=>{
    if(p.premium>10000){ return p.premium-p.premium*0.1}
    return p.premium;
});
console.log(Dis);
//6:
function approvePolicy(policyId, callback) {
    console.log("Checking policy...");

    setTimeout(() => {
        const policy = policiesData.find(p => p.id === policyId);

        if (!policy) {
            callback("Invalid Policy ID", null);
        } else if (policy.status !== "Active") {
            callback("Policy is inactive", null);
        } else {
            callback(null, `Policy "${policy.name}" approved successfully`);
        }
    }, 2000);
}
approvePolicy(1, function (error, result) {
    if (error) {
        console.error(error);
    } else {
        console.log(result);
    }
});
//7:
function purchasePolicy(policyId) {
    return new Promise((resolve, reject) => {
        setTimeout(() => {
            const policy = policiesData.find(p => p.id === policyId);

            if (!policy) {
                reject("Invalid Policy ID");
            } else if (policy.status !== "Active") {
                reject("Policy is inactive");
            } else {
                resolve(`Policy "${policy.name}" purchased successfully`);
            }
        }, 2000);
    });
}
purchasePolicy(3)
    .then(result => console.log(result))
    .catch(error => console.error(error));

//8:
function calculatePremium(policyId) {
    return new Promise((resolve, reject) => {
        const policy = policiesData.find(p => p.id === policyId);

        if (!policy) {
            reject("Invalid Policy ID");
        } else if (typeof policy.premium !== "number") {
            reject("Premium calculation error");
        } else {
            resolve(policy.premium * policy.duration);
        }
    });
}

function fetchPolicyFromAPI() {
    return new Promise((resolve, reject) => {
        const apiStatus = false;

        if (apiStatus) {
            resolve("API success");
        } else {
            reject("API failure");
        }
    });
}

calculatePremium(4)
    .then(total => console.log("Total Premium:", total))
    .catch(error => console.error(error));

fetchPolicyFromAPI()
    .then(res => console.log(res))
    .catch(err => console.error(err));


