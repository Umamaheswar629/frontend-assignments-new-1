document.getElementById("paymentSection").addEventListener("click", function () {
    console.log("Payment Section Clicked");
});

document.getElementById("payBtn").addEventListener("click", function () {
    console.log("Pay Premium Button Clicked");
});

document.getElementById("policyContainer").addEventListener(
    "click",
    function () {
        console.log("Parent Validation Executed");
    },
    true
);

document.getElementById("viewPolicy").addEventListener(
    "click",
    function () {
        console.log("Policy Details Shown");
    },
    true
);

document.getElementById("policyCard").addEventListener("click", function () {
    console.log("Navigating to Policy Details");
});

document.getElementById("deleteBtn").addEventListener("click", function (event) {
    event.stopPropagation();
    console.log("Policy Deleted");
});

document.getElementById("claimRow").addEventListener("click", function () {
    console.log("Opening Claim Details");
});

document.getElementById("approveBtn").addEventListener("click", function (event) {
    event.stopPropagation();
    console.log("Claim Approved");
});
