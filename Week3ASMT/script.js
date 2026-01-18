const API_URL = "https://jsonplaceholder.typicode.com/users";
let accounts = [];

const saveToStorage = () =>
  localStorage.setItem("accounts", JSON.stringify(accounts));

const loadFromStorage = () =>
  JSON.parse(localStorage.getItem("accounts"));

const randomBalance = () =>
  Math.floor(Math.random() * 40000) + 10000;
async function fetchAccounts() {
  document.getElementById("loader").classList.remove("hidden");

  try {
    const res = await fetch(API_URL);
    const data = await res.json();

    accounts = data.map(u => ({
      id: u.id,
      name: u.name,
      email: u.email,
      branch: u.address.city,
      balance: randomBalance(),
      history: []
    }));

    saveToStorage();
    populateBranches();
    render();
  } catch (err) {
    document.getElementById("error").innerText =
      "Failed to load accounts";
  } finally {
    document.getElementById("loader").classList.add("hidden");
  }
}

/* Render  */
function render(list = accounts) {
  const table = document.getElementById("accountsTable");
  table.innerHTML = "";

  list.forEach(acc => {
    const lowBalance = acc.balance < 5000 ? "bg-red-100" : "";

    table.innerHTML += `
      <tr class="${lowBalance}">
        <td class="p-2">${acc.id}</td>
        <td class="p-2">${acc.name}</td>
        <td class="p-2">${acc.email}</td>
        <td class="p-2">${acc.branch}</td>
        <td class="p-2">₹${acc.balance}</td>
        <td class="p-2 space-x-1">
          <button onclick="deposit(${acc.id})"
            class="bg-green-500 text-white px-2 rounded">+</button>
          <button onclick="withdraw(${acc.id})"
            class="bg-yellow-500 text-white px-2 rounded">−</button>
          <button onclick="showHistory(${acc.id})"
            class="bg-blue-500 text-white px-2 rounded">H</button>
          <button onclick="removeAccount(${acc.id})"
            class="bg-red-500 text-white px-2 rounded">X</button>
        </td>
      </tr>
    `;
  });

  calcTotal();
}

/* Search & Filter  */
document.getElementById("searchInput").addEventListener("input", e => {
  const val = e.target.value.toLowerCase();
  render(accounts.filter(a => a.name.toLowerCase().includes(val)));
});

document.getElementById("branchFilter").addEventListener("change", e => {
  const val = e.target.value;
  render(val ? accounts.filter(a => a.branch === val) : accounts);
});

function populateBranches() {
  const branches = [...new Set(accounts.map(a => a.branch))];
  const select = document.getElementById("branchFilter");
  branches.forEach(b =>
    select.innerHTML += `<option value="${b}">${b}</option>`
  );
}

/*Transactions*/
function deposit(id) {
  const amt = Number(prompt("Enter deposit amount"));
  if (!amt) return;

  const acc = accounts.find(a => a.id === id);
  acc.balance += amt;
  acc.history.push({ type: "Deposit", amt, time: new Date() });

  saveToStorage();
  render();
}

function withdraw(id) {
  const amt = Number(prompt("Enter withdrawal amount"));
  if (!amt) return;

  const acc = accounts.find(a => a.id === id);

  if (acc.balance < amt) {
    alert("Insufficient balance");
    return;
  }

  acc.balance -= amt;
  acc.history.push({ type: "Withdraw", amt, time: new Date() });

  if (acc.balance < 5000) {
    acc.balance -= 200;
    alert("Minimum balance violated. ₹200 penalty applied");
  }

  saveToStorage();
  render();
}

/*History  */
function showHistory(id) {
  const acc = accounts.find(a => a.id === id);
  const list = document.getElementById("historyList");
  list.innerHTML = "";

  acc.history.forEach(h => {
    list.innerHTML += `<li>
      ${h.type} ₹${h.amt} — ${new Date(h.time).toLocaleString()}
    </li>`;
  });

  document.getElementById("historyModal").classList.remove("hidden");
  document.getElementById("historyModal").classList.add("flex");
}

function closeHistory() {
  document.getElementById("historyModal").classList.add("hidden");
}

/* Create & Delete */
document.getElementById("createBtn").onclick = async () => {
  const name = newName.value;
  const email = newEmail.value;
  const branch = newBranch.value;

  if (!name || !email || !branch) return alert("Fill all fields");

  await fetch(API_URL, {
    method: "POST",
    body: JSON.stringify({ name, email }),
    headers: { "Content-Type": "application/json" }
  });

  accounts.push({
    id: Date.now(),
    name,
    email,
    branch,
    balance: 10000,
    history: []
  });

  saveToStorage();
  render();
};

function removeAccount(id) {
  if (!confirm("Delete this account?")) return;
  accounts = accounts.filter(a => a.id !== id);
  saveToStorage();
  render();
}

/*  Sort & Reduce */
document.getElementById("sortBtn").onclick = () => {
  accounts.sort((a, b) => b.balance - a.balance);
  render();
};

function calcTotal() {
  const total = accounts.reduce((sum, a) => sum + a.balance, 0);
  document.getElementById("totalBalance").innerText = total;
}

/* Init */
const stored = loadFromStorage();
stored ? (accounts = stored, populateBranches(), render()) : fetchAccounts();

