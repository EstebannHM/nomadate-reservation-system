// ========== VALIDACIÓN Y MANEJO DEL FORMULARIO DE CONTACTO ==========

document.addEventListener('DOMContentLoaded', function() {
    const contactForm = document.querySelector('.contact-form');
    
    if (contactForm) {
        // Validación en tiempo real
        const inputs = contactForm.querySelectorAll('input, textarea, select');
        
        inputs.forEach(input => {
            input.addEventListener('blur', function() {
                validateField(this);
            });
            
            input.addEventListener('input', function() {
                if (this.classList.contains('error')) {
                    validateField(this);
                }
            });
        });
        
        // Validación al enviar el formulario
        contactForm.addEventListener('submit', function(e) {
            e.preventDefault();
            
            let isValid = true;
            
            // Validar todos los campos
            inputs.forEach(input => {
                if (!validateField(input)) {
                    isValid = false;
                }
            });
            
            if (isValid) {
                // Aquí enviarías el formulario al servidor
                submitForm(this);
            }
        });
    }
    
    // Función para validar un campo individual
    function validateField(field) {
        const value = field.value.trim();
        let isValid = true;
        let errorMessage = '';
        
        // Remover mensajes de error previos
        removeError(field);
        
        // Validar campos requeridos
        if (field.hasAttribute('required') && value === '') {
            isValid = false;
            errorMessage = 'Este campo es obligatorio';
        }
        
        // Validación específica por tipo de campo
        if (value !== '') {
            switch(field.type) {
                case 'email':
                    const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
                    if (!emailRegex.test(value)) {
                        isValid = false;
                        errorMessage = 'Ingresa un correo electrónico válido';
                    }
                    break;
                    
                case 'tel':
                    const phoneRegex = /^[\d\s\-\(\)\+]{8,}$/;
                    if (!phoneRegex.test(value)) {
                        isValid = false;
                        errorMessage = 'Ingresa un teléfono válido';
                    }
                    break;
            }
            
            // Validación de nombre (solo letras y espacios)
            if (field.name === 'nombre') {
                const nameRegex = /^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$/;
                if (!nameRegex.test(value)) {
                    isValid = false;
                    errorMessage = 'El nombre solo puede contener letras';
                }
            }
            
            // Validación de longitud mínima para el mensaje
            if (field.name === 'mensaje' && value.length < 10) {
                isValid = false;
                errorMessage = 'El mensaje debe tener al menos 10 caracteres';
            }
        }
        
        if (!isValid) {
            showError(field, errorMessage);
        }
        
        return isValid;
    }
    
    // Función para mostrar mensaje de error
    function showError(field, message) {
        field.classList.add('error');
        
        const errorElement = document.createElement('span');
        errorElement.className = 'error-message';
        errorElement.textContent = message;
        
        field.parentNode.appendChild(errorElement);
    }
    
    // Función para remover mensaje de error
    function removeError(field) {
        field.classList.remove('error');
        
        const errorMessage = field.parentNode.querySelector('.error-message');
        if (errorMessage) {
            errorMessage.remove();
        }
    }
    
    // Función para enviar el formulario
    function submitForm(form) {
        const formData = new FormData(form);
        const submitBtn = form.querySelector('.btn-submit');
        const originalText = submitBtn.innerHTML;
        
        // Mostrar estado de carga
        submitBtn.disabled = true;
        submitBtn.innerHTML = `
            <svg width="20" height="20" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" class="loading-spinner">
                <circle cx="12" cy="12" r="10"></circle>
            </svg>
            Enviando...
        `;
        
        // Agregar estilos de animación si no existen
        if (!document.querySelector('#loading-spinner-style')) {
            const style = document.createElement('style');
            style.id = 'loading-spinner-style';
            style.textContent = `
                @keyframes spin {
                    0% { transform: rotate(0deg); }
                    100% { transform: rotate(360deg); }
                }
                .loading-spinner {
                    animation: spin 1s linear infinite;
                }
            `;
            document.head.appendChild(style);
        }
        
        // Simular envío (reemplazar con llamada real al servidor)
        setTimeout(() => {
            // Aquí harías el fetch/ajax al servidor
            // Por ahora, solo simulamos el éxito
            
            submitBtn.disabled = false;
            submitBtn.innerHTML = originalText;
            
            // Mostrar mensaje de éxito
            showSuccessMessage(form);
            
            // Limpiar el formulario
            form.reset();
            
        }, 2000);
    }
    
    // Función para mostrar mensaje de éxito
    function showSuccessMessage(form) {
        const successMessage = document.createElement('div');
        successMessage.className = 'success-message';
        successMessage.innerHTML = `
            <svg width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2">
                <polyline points="20 6 9 17 4 12"></polyline>
            </svg>
            <p>¡Mensaje enviado con éxito! Te contactaremos pronto.</p>
        `;
        
        form.parentNode.insertBefore(successMessage, form);
        
        // Agregar estilos del mensaje de éxito si no existen
        if (!document.querySelector('#success-message-style')) {
            const style = document.createElement('style');
            style.id = 'success-message-style';
            style.textContent = `
                .success-message {
                    background: #d4edda;
                    border: 2px solid #c3e6cb;
                    color: #155724;
                    padding: 1.5rem;
                    border-radius: 8px;
                    margin-bottom: 2rem;
                    display: flex;
                    align-items: center;
                    gap: 1rem;
                    animation: slideIn 0.3s ease;
                }
                .success-message svg {
                    flex-shrink: 0;
                }
                .success-message p {
                    margin: 0;
                    font-weight: 500;
                }
                .error-message {
                    color: #dc3545;
                    font-size: 0.85rem;
                    margin-top: 0.3rem;
                    display: block;
                }
                .contact-form input.error,
                .contact-form textarea.error,
                .contact-form select.error {
                    border-color: #dc3545;
                }
                @keyframes slideIn {
                    from {
                        opacity: 0;
                        transform: translateY(-20px);
                    }
                    to {
                        opacity: 1;
                        transform: translateY(0);
                    }
                }
            `;
            document.head.appendChild(style);
        }
        
        // Remover el mensaje después de 5 segundos
        setTimeout(() => {
            successMessage.style.opacity = '0';
            successMessage.style.transform = 'translateY(-20px)';
            successMessage.style.transition = 'all 0.3s ease';
            setTimeout(() => successMessage.remove(), 300);
        }, 5000);
    }
});
