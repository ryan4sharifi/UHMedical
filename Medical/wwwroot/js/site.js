document.querySelector(".menu-toggle").addEventListener("click", function () {
    var nav = document.querySelector(".nav-list");
    if (nav.style.display === "none" || nav.style.display === "") {
        nav.style.display = "flex";
        nav.classList.add('active');
    } else {
        nav.style.display = "none";
        nav.classList.remove('active');
    }
});
