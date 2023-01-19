let removeProductImgBtns = document.querySelectorAll(".removeProductImgBtn");

removeProductImgBtns.forEach(btn => btn.addEventListener("click", function (e) {
    e.preventDefault();

    btn.parentElement.remove();
}))