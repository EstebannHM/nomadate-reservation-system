// ========== VALIDACIONES DE FORMULARIOS ==========

/**
 * Validación de fechas para búsqueda de habitaciones
 * Se asegura que las fechas sean válidas y que la fecha de salida sea posterior a la de entrada
 */
function initializeDateValidation() {
    const checkInInput = document.getElementById('checkIn');
    const checkOutInput = document.getElementById('checkOut');
    
    if (!checkInInput || !checkOutInput) return;
    
    // Establecer fecha mínima como hoy
    const today = new Date().toISOString().split('T')[0];
    checkInInput.setAttribute('min', today);
    checkOutInput.setAttribute('min', today);
    
    // Actualizar fecha mínima de salida cuando se selecciona entrada
    checkInInput.addEventListener('change', function() {
        checkOutInput.setAttribute('min', this.value);
        if (checkOutInput.value && checkOutInput.value <= this.value) {
            checkOutInput.value = '';
        }
    });
}

/**
 * Manejo del formulario de búsqueda de habitaciones
 * Valida los datos y prepara la búsqueda
 */
function initializeSearchForm() {
    const searchForm = document.querySelector('.search-form');
    
    if (!searchForm) return;
    
    searchForm.addEventListener('submit', function(e) {
        e.preventDefault();
        
        const formData = new FormData(this);
        const data = Object.fromEntries(formData);
        
        // Validar que todos los campos estén completos
        if (!data.checkIn || !data.checkOut || !data.guestName || !data.guests) {
            alert('Por favor, completa todos los campos');
            return;
        }
        
        // Validar que la fecha de salida sea posterior a la de entrada
        if (data.checkOut <= data.checkIn) {
            alert('La fecha de salida debe ser posterior a la fecha de entrada');
            return;
        }
        
        console.log('Búsqueda:', data);
        
        // TODO: Implementar búsqueda real con backend
        alert('Funcionalidad de búsqueda pendiente. Datos: ' + JSON.stringify(data));
        
        // Cuando esté lista la página de habitaciones, redirigir así:
        // window.location.href = `/Habitaciones/Index?checkIn=${data.checkIn}&checkOut=${data.checkOut}&guests=${data.guests}&name=${encodeURIComponent(data.guestName)}`;
    });
}

/**
 * Inicializar todas las validaciones cuando el DOM esté listo
 */
document.addEventListener('DOMContentLoaded', function() {
    initializeDateValidation();
    initializeSearchForm();
});
