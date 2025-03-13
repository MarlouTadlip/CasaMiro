// sweetalert.js
var dotNetReference = null;

function setDotNetReference(reference) {
    dotNetReference = reference;
}

function confirmDelete(userId) {
    Swal.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
        if (result.isConfirmed) {
            dotNetReference.invokeMethodAsync('DeleteUserConfirmed', userId);
        }
    });
}

function showDeleteSuccess() {
    Swal.fire(
        'Deleted!',
        'User has been deleted successfully.',
        'success'
    );
}

function closeModal(modalId) {
    const modalElement = document.getElementById(modalId);
    const modal = bootstrap.Modal.getInstance(modalElement);
    modal.hide();
}

function showSuspendedAlert() {
    Swal.fire({
        title: 'Account Suspended',
        text: 'Your account has been suspended. Please contact support for further assistance.',
        icon: 'error',
        confirmButtonText: 'OK'
    });
}