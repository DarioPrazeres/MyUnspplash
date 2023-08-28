var btnAdd = document.getElementById("add-btn");
var formAdd = document.getElementById("addForm");
btnAdd.addEventListener("click", () => {
    formAdd.style.display = "flex";
});

function hiddenForm() {
    var btnCancel = document.getElementById("cancel");    
    formAdd.style.display = "none";
}
