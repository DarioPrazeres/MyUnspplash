var btnAdd = document.getElementById("add-btn");

var imageDetail = document.querySelectorAll('div.imageDetailHover');
var Labels = document.querySelectorAll("h3.labelImage");
var ImagesSrc = document.querySelectorAll('img#imageSrc');
var IdValue = document.querySelectorAll('p#valueInit');
var deleteLink = document.getElementById('deleteLink');

function openForm(className) {
    var formAdd = document.getElementById(className);
    formAdd.style.display = "flex";
}
function hiddenForm(className) {
    var formAdd = document.getElementById(className);
    formAdd.style.display = "none";
}
function openFormSection(className, index) {
    var formAdd = document.getElementById(className);
    formAdd.style.display = "flex";
    deleteLink.href = `Home/Delete/${IdValue[index].textContent}`;
}
function realizarPesquisa() {
    var valorPesquisa = document.getElementById("pesquisaInput").value.toLowerCase();
    var resultadosLabels = [];
    var resultadosImage = [];

    for (var i = 0; i < Labels.length; i++) {
        var nome = Labels[i].textContent.toLowerCase();
        if (nome.includes(valorPesquisa)) {
            resultadosLabels.push(Labels[i].textContent);
            resultadosImage.push(ImagesSrc[i].src);
        }
    }
    exibirResultados(resultadosLabels, resultadosImage);
}
function exibirResultados(resultadosLabels, resultadosImage) {

    var ImageSection = document.getElementById('sectionImages');
    ImageSection.innerHTML = "";
  
    resultadosLabels.forEach(function (resultado, index) {
        ImageSection.appendChild(elementImage(resultado, resultadosImage[index], index));
    });
}
function elementImage(labelValue, srcImage, index) {
    var imageSection = document.createElement("div");
    var imageDetail = document.createElement("div");
    var image = document.createElement('img');
    var imageDetailHover = document.createElement('div');
    var labelImage = document.createElement('h3');

    imageSection.classList.add("imageSection");
    imageDetail.classList.add("imageDetail");
    imageDetailHover.classList.add('imageDetailHover');
    labelImage.classList.add('labelImage');

    imageSection.appendChild(imageDetail);
    imageDetail.appendChild(image);
    imageDetail.appendChild(imageDetailHover);
    imageDetailHover.appendChild(labelImage);

    imageSection.addEventListener('mousemove', () => {
        imageDetailHover.style.display = "flex";
    });
    imageSection.addEventListener('mouseout', () => {
        imageDetailHover.style.display = "none";
    });

    image.src = srcImage;
    labelImage.innerText = labelValue;

    return imageSection;
}
function showLabel(index) {
    imageDetail[index].style.display = "flex";
}
function closeLabel(index) {
    imageDetail[index].style.display = "none";
}