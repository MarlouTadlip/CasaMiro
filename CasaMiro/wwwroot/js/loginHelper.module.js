// This ensures SweetAlert is properly loaded before we try to use it
export function ensureSwalIsLoaded() {
    return new Promise((resolve, reject) => {
        // Check if SweetAlert is already loaded
        if (window.Swal) {
            console.log("SweetAlert is already loaded");
            resolve();
            return;
        }

        console.log("Loading SweetAlert dynamically");

        // If not loaded, try to ensure it's loaded
        // This assumes you have SweetAlert in your _Host.cshtml or index.html
        // If not, you might need to load it dynamically here

        // Allow some time for potential async loading
        setTimeout(() => {
            if (window.Swal) {
                console.log("SweetAlert loaded successfully");
                resolve();
            } else {
                console.error("SweetAlert could not be loaded");
                reject(new Error("SweetAlert is not available"));
            }
        }, 500);
    });
}

// Function to trigger shake animation
export function triggerShakeAnimation() {
    const errorMessage = document.getElementById('errorMessage');
    if (errorMessage) {
        errorMessage.classList.remove("animate__shakeX");
        // Trigger reflow to restart animation
        void errorMessage.offsetWidth;
        errorMessage.classList.add("animate__shakeX");
    }
}

// Function to show suspended account alert
export function showSuspendedAlert() {
    if (window.Swal) {
        Swal.fire({
            title: "Account Suspended",
            text: "Your account has been suspended. Please contact support for further assistance.",
            icon: "error",
            confirmButtonText: "OK"
        });
    } else {
        alert("Your account has been suspended. Please contact support for further assistance.");
    }
}