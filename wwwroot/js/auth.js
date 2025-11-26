// Abrir el modal desde un botón
document.addEventListener("DOMContentLoaded", () => {
    const modal = document.getElementById("authModal");
    const closeModal = document.getElementById("closeModal");
    const showLogin = document.getElementById("showLogin");
    const showRegister = document.getElementById("showRegister");
    const loginForm = document.getElementById("loginForm");
    const registerForm = document.getElementById("registerForm");

    // Abrir modal desde boton login
    document.querySelectorAll(".btn-login").forEach(btn => {
        btn.addEventListener("click", () => {
            modal.classList.remove("hidden");
            loginForm.classList.remove("hidden");
            registerForm.classList.add("hidden");
        });
    });

    closeModal.addEventListener("click", () => modal.classList.add("hidden"));

    showRegister.addEventListener("click", () => {
        loginForm.classList.add("hidden");
        registerForm.classList.remove("hidden");
    });

    showLogin.addEventListener("click", () => {
        registerForm.classList.add("hidden");
        loginForm.classList.remove("hidden");
    });

    // Obtener AntiForgery Token
    const tokenElement = document.querySelector("input[name='__RequestVerificationToken']");
    const token = tokenElement ? tokenElement.value : null;

    // LOGIN
    document.getElementById("formLogin").addEventListener("submit", async function(e) {
        e.preventDefault();

        let formData = new FormData(this);

        const response = await fetch("/Account/Login", {
            method: "POST",
            body: formData,
            headers: {
                "RequestVerificationToken": token
            }
        });

        const msg = document.getElementById("loginMsg");

        if (response.ok) {
            msg.innerHTML = "<p class='ok'>Login exitoso</p>";
            setTimeout(() => location.reload(), 800);
        } else {
            msg.innerHTML = "<p class='error'>Credenciales incorrectas</p>";
        }
    });

    // REGISTRO
    document.getElementById("formRegister").addEventListener("submit", async function(e) {
        e.preventDefault();

        let formData = new FormData(this);

        const response = await fetch("/Account/Register", {
            method: "POST",
            body: formData,
            headers: {
                "RequestVerificationToken": token
            }
        });

        const msg = document.getElementById("registerMsg");

        if (response.ok) {
            msg.innerHTML = "<p class='ok'>Cuenta creada correctamente</p>";
            setTimeout(() => {
                registerForm.classList.add("hidden");
                loginForm.classList.remove("hidden");
            }, 1000);
        } else {
            msg.innerHTML = "<p class='error'>Error: El correo ya existe.</p>";
        }
    });
});
