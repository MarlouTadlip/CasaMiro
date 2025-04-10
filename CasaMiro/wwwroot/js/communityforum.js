let dotNetReference = null;

window.setDotNetReference = (reference) => {
    dotNetReference = reference;
};

// Function to close the new post modal
window.closeNewPostModal = () => {
    var modalElement = document.getElementById('newPostModal');
    var modal = bootstrap.Modal.getInstance(modalElement);
    if (modal) {
        modal.hide();
    }
};

document.addEventListener('DOMContentLoaded', function () {
    // Set up event listener for the modal being hidden
    document.querySelector('#newPostModal').addEventListener('hidden.bs.modal', function () {
        if (dotNetReference) {
            dotNetReference.invokeMethodAsync('RefreshAfterModalClose');
        }
    });
});