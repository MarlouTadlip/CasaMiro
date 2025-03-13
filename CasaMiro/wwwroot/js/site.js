function closeModal(modalId) {
    var modal = bootstrap.Modal.getInstance(document.getElementById(modalId));
    if (modal) {
        modal.hide();
    }
}

document.addEventListener("DOMContentLoaded", function () {
    document.querySelector(".sidebar-container").classList.add("show");
});

function toggleSidebar() {
    document.querySelector(".sidebar-container").classList.toggle("closed");
}

window.triggerShakeAnimation = () => {
    let errorMessage = document.getElementById("errorMessage");
    if (errorMessage) {
        errorMessage.classList.add("shake");
        setTimeout(() => errorMessage.classList.remove("shake"), 400);
    }
};
