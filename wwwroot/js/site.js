// ========== CONTROL DE MODALES ==========

// Función para abrir modal de login
function openLoginModal() {
    const modal = document.getElementById('loginModal');
    modal.classList.add('active');
    document.body.style.overflow = 'hidden'; // Prevenir scroll en el body
}

// Función para cerrar modal de login
function closeLoginModal() {
    const modal = document.getElementById('loginModal');
    modal.classList.remove('active');
    document.body.style.overflow = 'auto';
}

// Función para abrir modal de registro
function openRegisterModal() {
    const modal = document.getElementById('registerModal');
    modal.classList.add('active');
    document.body.style.overflow = 'hidden';
}

// Función para cerrar modal de registro
function closeRegisterModal() {
    const modal = document.getElementById('registerModal');
    modal.classList.remove('active');
    document.body.style.overflow = 'auto';
}

// Función para cambiar de login a registro
function switchToRegister() {
    closeLoginModal();
    setTimeout(() => {
        openRegisterModal();
    }, 300);
    return false; // Prevenir navegación
}

// Función para cambiar de registro a login
function switchToLogin() {
    closeRegisterModal();
    setTimeout(() => {
        openLoginModal();
    }, 300);
    return false; // Prevenir navegación
}

// Cerrar modal al hacer click fuera del contenido
window.onclick = function(event) {
    const loginModal = document.getElementById('loginModal');
    const registerModal = document.getElementById('registerModal');
    
    if (event.target === loginModal) {
        closeLoginModal();
    }
    if (event.target === registerModal) {
        closeRegisterModal();
    }
}

// Cerrar modal con tecla ESC
document.addEventListener('keydown', function(event) {
    if (event.key === 'Escape') {
        closeLoginModal();
        closeRegisterModal();
    }
});

// ========== MANEJO DE FORMULARIOS (PLACEHOLDER) ==========
// Estas funciones las puedes conectar más adelante con el backend

document.addEventListener('DOMContentLoaded', function() {
    // Prevenir submit por defecto y mostrar mensaje
    const forms = document.querySelectorAll('.auth-form');
    
    forms.forEach(form => {
        form.addEventListener('submit', function(e) {
            e.preventDefault();
            
            // Aquí puedes agregar la lógica de validación y envío al backend
            const formData = new FormData(form);
            
            // Por ahora solo mostramos un mensaje en consola
            console.log('Formulario enviado:', Object.fromEntries(formData));
            
            // Simulación de éxito
            alert('Formulario recibido (funcionalidad pendiente de implementar con BD)');
        });
    });

    // Validación de confirmación de contraseña en registro
    const registerForm = document.querySelector('#registerModal .auth-form');
    if (registerForm) {
        registerForm.addEventListener('submit', function(e) {
            const password = document.getElementById('registerPassword').value;
            const confirmPassword = document.getElementById('registerConfirmPassword').value;
            
            if (password !== confirmPassword) {
                e.preventDefault();
                alert('Las contraseñas no coinciden');
                return false;
            }
        });
    }
});