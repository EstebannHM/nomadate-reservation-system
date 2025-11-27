# Hotel Nomadate - Sistema de Reservaciones Web

## 📋 Descripción General del Proyecto

Sistema web de gestión hotelera desarrollado en **ASP.NET Core 8.0 MVC** con **Entity Framework Core** y **SQL Server**. El proyecto incluye una interfaz pública para usuarios y un panel administrativo para gestión interna.

---

## 🎨 Diseño y Colores

### Paleta de Colores
- **Primario:** `#112B3C` (RGB: 17, 43, 60) - Azul oscuro
- **Secundario:** `#205375` - Azul medio
- **Claro:** `#f8f9fa` - Gris muy claro
- **Oscuro:** `#1a1a1a` - Negro
- **Texto:** `#333` - Gris oscuro

### Iconografía
- **SVG Icons:** Estilo Feather Icons para todos los elementos visuales
- Sin emojis ni fuentes de iconos externas
- Diseño minimalista y profesional

---

## 👥 PARTE DE USUARIO (Frontend Público)

### 1. **Página de Inicio** (`/`)
**Ubicación:** `Views/Home/Index.cshtml`  
**CSS:** `wwwroot/css/index.css`  
**JavaScript:** `wwwroot/js/validations.js`

#### Secciones:
1. **Hero Section con Barra de Búsqueda**
   - Título y subtítulo de bienvenida
   - Formulario de búsqueda con:
     - Fecha de entrada (date picker)
     - Fecha de salida (date picker)
     - Nombre completo (text input)
     - Número de huéspedes (select dropdown)
     - Botón "Buscar Disponibilidad"
   - Validación JavaScript para fechas (no permitir fechas pasadas, checkout después de checkin)

2. **Imagen Destacada**
   - Banner grande con overlay de texto
   - Mensaje promocional

3. **¿Por Qué Elegirnos?**
   - Grid de 4 tarjetas con características:
     - Ubicación privilegiada
     - Servicio excepcional
     - Comodidad garantizada
     - Experiencia única
   - Cada tarjeta con imagen, título y descripción

4. **Call to Action (CTA)**
   - Sección final con botón para reservar

#### Características Técnicas:
- Diseño responsive (mobile, tablet, desktop)
- Validación de formulario en tiempo real
- Animaciones hover en tarjetas

---

### 2. **Página de Habitaciones** (`/Habitaciones`)
**Ubicación:** `Views/Habitaciones/Index.cshtml`  
**Controller:** `Controllers/HabitacionesController.cs`  
**CSS:** `wwwroot/css/habitaciones.css`  
**Modelo:** `Models/Habitacion.cs`

#### Estructura:
1. **Hero Section con Búsqueda**
   - Misma barra de búsqueda que la página de inicio
   - Título: "Nuestras Habitaciones"

2. **Grid de Habitaciones**
   - Muestra todas las habitaciones desde la base de datos
   - Cada tarjeta incluye:
     - Imagen de la habitación
     - Badge con número de habitación
     - Nombre/Número
     - Descripción
     - Amenidades con íconos SVG:
       - Capacidad (número de personas)
       - Aire Acondicionado (si aplica)
       - Televisión (si aplica)
     - Precio por noche
     - Botón "Ver Detalles"

3. **Estado Vacío**
   - Mensaje cuando no hay habitaciones disponibles

#### Datos desde Base de Datos:
```csharp
Model: IEnumerable<Habitacion>
- IdHabitacion
- NumeroHabitacion
- Capacidad
- Precio
- TieneAire (bool)
- TieneTv (bool)
- Descripcion
- RutaImagen
```

#### Controller:
```csharp
public IActionResult Index()
{
    var habitaciones = _context.Habitacion.ToList();
    return View(habitaciones);
}
```

---

### 3. **Página Sobre Nosotros** (`/Home/About`)
**Ubicación:** `Views/Home/About.cshtml`  
**CSS:** `wwwroot/css/about.css`

#### Secciones:
1. **Hero Section**
   - Título: "Sobre Hotel Nomadate"
   - Subtítulo con años de experiencia

2. **Nuestra Historia**
   - Grid de 2 columnas (texto + imagen)
   - Historia de la fundación del hotel
   - Imagen representativa

3. **Misión, Visión y Valores**
   - 3 tarjetas con íconos SVG:
     - **Misión:** Proporcionar experiencia excepcional
     - **Visión:** Ser el hotel preferido en Costa Rica
     - **Valores:** Hospitalidad, Integridad, Excelencia

4. **Nuestro Equipo**
   - Grid de 3 miembros:
     - **Esteban Hernandez** - Director
     - **Santiago Osejo** - Gerente de Atención
     - **Jason Flores** - Gerente de Operaciones
   - Cada miembro con foto, nombre, cargo y biografía

5. **Estadísticas**
   - 4 números destacados:
     - 10+ Años de Experiencia
     - 5000+ Huéspedes Satisfechos
     - 50+ Habitaciones Disponibles
     - 98% Tasa de Satisfacción

6. **Call to Action**
   - Botón para reservar ahora

---

### 4. **Página de Contacto** (`/Home/Contact`)
**Ubicación:** `Views/Home/Contact.cshtml`  
**CSS:** `wwwroot/css/contact.css`  
**JavaScript:** `wwwroot/js/contact.js`

#### Estructura (Grid 2 columnas):

**Columna Izquierda - Información:**
- Descripción del hotel
- Datos de contacto con íconos SVG:
  - **Dirección:** San José, Costa Rica
  - **Teléfono:** +506 2222-3333
  - **Email:** info@hotelnomadate.com
  - **Horarios:** 24/7
- Enlaces a redes sociales (Facebook, Instagram, Twitter)

**Columna Derecha - Formulario:**
- Campos:
  - Nombre (required, solo letras)
  - Email (required, validación de formato)
  - Teléfono (validación de formato)
  - Asunto (select dropdown)
  - Mensaje (textarea, mínimo 10 caracteres)
- Botón de envío con animación de loading

**Sección Inferior:**
- Placeholder para mapa de Google Maps (400px de altura)

#### Validaciones JavaScript:
- Validación en tiempo real (blur event)
- Regex para email y teléfono
- Mensaje de error debajo de cada campo
- Animación de spinner al enviar
- Mensaje de éxito después del envío
- Auto-limpieza del formulario

---

### 5. **Header y Footer** (Compartidos)
**Ubicación:** `Views/Shared/_Layout.cshtml`  
**CSS:** `wwwroot/css/components/header-footer.css`

#### Header:
- **Logo** (izquierda): Imagen del hotel con link a inicio
- **Navegación** (centro):
  - Inicio
  - Habitaciones
  - Sobre Nosotros
  - Contacto
- **Botones de autenticación** (derecha):
  - Iniciar Sesión
  - Registrarse
- Sticky header (se mantiene visible al hacer scroll)

#### Footer:
- **3 Columnas:**
  1. **Sobre Nosotros:** Descripción breve
  2. **Enlaces Rápidos:** Navegación duplicada
  3. **Contacto:** Dirección, teléfono, email con íconos SVG
- **Redes Sociales:** Enlaces con íconos SVG (Facebook, Instagram, Twitter)
- Copyright y año actual

---

### 6. **Modales de Autenticación**
**Ubicación:** Incluidos en `_Layout.cshtml`  
**JavaScript:** `wwwroot/js/site.js`

#### Modal de Login:
- Campo de email/usuario
- Campo de contraseña
- Checkbox "Recordarme"
- Botón "Iniciar Sesión"
- Link para cambiar a modal de registro

#### Modal de Registro:
- Nombre completo
- Email
- Contraseña
- Confirmar contraseña
- Botón "Registrarse"
- Link para cambiar a modal de login

#### Funcionalidades JavaScript:
- Abrir/cerrar modales
- Cambiar entre login y registro
- Cerrar con ESC
- Cerrar al hacer click fuera del modal

---

## 🔐 PARTE DE ADMINISTRADOR (Backend)

### 1. **Sistema de Autenticación**
**Ubicación:** `Controllers/AdminController.cs`

#### Credenciales:
- **Usuario:** `admin`
- **Contraseña:** `admin123`

#### Rutas:
- `/admin` → Redirige a login o dashboard según autenticación
- `/admin/login` → Página de inicio de sesión
- `/admin/logout` → Cierra sesión y redirige a login

#### Seguridad:
- **Sesiones ASP.NET Core:**
  - Timeout: 30 minutos
  - Cookie HttpOnly
  - Validación en cada request
- **Protección de rutas:**
  - Redireccionamiento automático si no está autenticado
  - Session key: "AdminAuthenticated"

---

### 2. **Página de Login Admin**
**Ubicación:** `Views/Admin/Login.cshtml`  
**Layout:** Independiente (sin header/footer público)

#### Diseño:
- Fondo con degradado azul (#112B3C → #205375)
- Tarjeta central blanca con sombra
- Ícono de usuario en círculo azul
- Título: "Panel Administrativo - Hotel Nomadate"
- Formulario simple:
  - Campo de usuario
  - Campo de contraseña
  - Botón "Iniciar Sesión"
- Mensaje de error si las credenciales son incorrectas
- Link para volver al sitio público

---

### 3. **Dashboard Administrativo**
**Ubicación:** `Views/Admin/Index.cshtml`  
**CSS:** `wwwroot/css/admin.css`

#### Estructura (Layout con Sidebar):

**Sidebar (Izquierda - Fijo):**
- **Header:**
  - Logo/Nombre: "Hotel Nomadate"
  - Subtítulo: "Panel Admin"
- **Navegación:**
  - Dashboard (activo)
  - Habitaciones
  - Reservaciones
  - Usuarios
  - (Cada ítem con ícono SVG)
- **Footer:**
  - Botón "Cerrar Sesión" con ícono

**Área Principal (Derecha):**
1. **Header:**
   - Título de la sección actual
   - Saludo: "Bienvenido, admin"

2. **Tarjetas de Estadísticas (Grid 4 columnas):**
   - **Total Habitaciones:** 25 (ícono verde)
   - **Reservaciones Activas:** 12 (ícono azul)
   - **Total Usuarios:** 156 (ícono naranja)
   - **Ingresos del Mes:** $15,240 (ícono morado)

3. **Sección de Bienvenida:**
   - Mensaje de bienvenida
   - Nota: "Las funcionalidades específicas se agregarán próximamente"

#### Responsive:
- **Desktop (>968px):** Sidebar completo (260px)
- **Tablet (768-968px):** Sidebar colapsado solo íconos (80px)
- **Mobile (<768px):** Sidebar horizontal en la parte superior

---

## 🗄️ BASE DE DATOS

### Configuración:
**Archivo:** `appsettings.json`
```json
"ConnectionStrings": {
  "NomadateDB": "Server=localhost,1433;Database=nomadate;User Id=sa;Password=tu_password;TrustServerCertificate=True;"
}
```

### Modelos Entity Framework:

#### 1. **Habitacion**
```csharp
- IdHabitacion (int, PK)
- NumeroHabitacion (string)
- Capacidad (int)
- Precio (decimal)
- TieneAire (bool)
- TieneTv (bool)
- Descripcion (string)
- RutaImagen (string)
- Disponible (bool)
```

#### 2. **Usuario**
```csharp
- IdUsuario (int, PK)
- NombreCompleto (string)
- Email (string)
- Password (string)
- FechaRegistro (DateTime)
- Activo (bool)
```

#### 3. **Reservacion**
```csharp
- IdReservacion (int, PK)
- IdUsuario (int, FK)
- IdHabitacion (int, FK)
- FechaEntrada (DateTime)
- FechaSalida (DateTime)
- NumeroHuespedes (int)
- PrecioTotal (decimal)
- Estado (string)
- FechaCreacion (DateTime)
```

#### 4. **ReservacionDetalle**
```csharp
- IdDetalle (int, PK)
- IdReservacion (int, FK)
- Concepto (string)
- Monto (decimal)
```

#### 5. **Resenna** (Reseña)
```csharp
- IdResenna (int, PK)
- IdUsuario (int, FK)
- IdHabitacion (int, FK)
- Calificacion (int)
- Comentario (string)
- FechaResenna (DateTime)
```

### DbContext:
**Archivo:** `Models/NomadateContext.cs`  
**Registrado en:** `Program.cs` con DI (Dependency Injection)

---

## 📁 ESTRUCTURA DE ARCHIVOS

```
nomadate_web/
│
├── Controllers/
│   ├── AdminController.cs          # Controlador del panel admin
│   ├── HabitacionesController.cs   # Controlador de habitaciones
│   └── HomeController.cs           # Controlador páginas públicas
│
├── Models/
│   ├── ErrorViewModel.cs
│   ├── Habitacion.cs              # Modelo de habitación
│   ├── NomadateContext.cs         # DbContext EF Core
│   ├── Resenna.cs                 # Modelo de reseña
│   ├── Reservacion.cs             # Modelo de reservación
│   ├── ReservacionDetalle.cs      # Detalle de reservación
│   └── Usuario.cs                 # Modelo de usuario
│
├── Views/
│   ├── Admin/
│   │   ├── Index.cshtml           # Dashboard admin
│   │   └── Login.cshtml           # Login admin
│   │
│   ├── Habitaciones/
│   │   └── Index.cshtml           # Listado de habitaciones
│   │
│   ├── Home/
│   │   ├── About.cshtml           # Sobre Nosotros
│   │   ├── Contact.cshtml         # Contacto
│   │   ├── Index.cshtml           # Página de inicio
│   │   └── Privacy.cshtml         # Política de privacidad
│   │
│   ├── Shared/
│   │   ├── _Layout.cshtml         # Layout principal (header/footer)
│   │   ├── _ValidationScriptsPartial.cshtml
│   │   ├── _ViewImports.cshtml
│   │   ├── _ViewStart.cshtml
│   │   └── Error.cshtml
│
├── wwwroot/
│   ├── css/
│   │   ├── components/
│   │   │   └── header-footer.css  # Estilos header/footer
│   │   ├── about.css              # Estilos página Sobre Nosotros
│   │   ├── admin.css              # Estilos panel admin
│   │   ├── contact.css            # Estilos página Contacto
│   │   ├── global.css             # Variables CSS globales
│   │   ├── habitaciones.css       # Estilos página Habitaciones
│   │   ├── index.css              # Estilos página Inicio
│   │   └── site.css               # Estilos generales
│   │
│   ├── js/
│   │   ├── contact.js             # Validación formulario contacto
│   │   ├── site.js                # Funciones modales
│   │   └── validations.js         # Validación búsqueda
│   │
│   └── images/
│       ├── logo.jpeg              # Logo del hotel
│       ├── about-history.jpg      # Imagen historia
│       ├── team-1.jpg, team-2.jpg, team-3.jpg  # Fotos equipo
│       └── room-default.jpg       # Imagen default habitaciones
│
├── database/
│   ├── 1_create_database.sql
│   ├── 2_create_tables.sql
│   └── 3_seed_data.sql
│
├── appsettings.json               # Configuración (connection strings)
├── Program.cs                     # Configuración de la app
├── nomadate_web.csproj           # Archivo del proyecto
└── README.md                      # Documentación
```

---

## 🚀 TECNOLOGÍAS UTILIZADAS

### Backend:
- **ASP.NET Core 8.0:** Framework MVC
- **Entity Framework Core 9.0.10:** ORM para base de datos
- **SQL Server:** Base de datos relacional
- **C# 12:** Lenguaje de programación

### Frontend:
- **Razor Views:** Motor de vistas de ASP.NET
- **CSS3:** Estilos personalizados con variables CSS
- **JavaScript Vanilla:** Sin frameworks adicionales
- **SVG:** Iconografía vectorial

### Arquitectura:
- **MVC (Model-View-Controller):** Patrón de diseño
- **Database-First:** Modelos generados desde la BD
- **Session Management:** Para autenticación admin
- **Dependency Injection:** Para DbContext

---

## 📝 CARACTERÍSTICAS TÉCNICAS

### CSS:
- **Arquitectura Modular:**
  - `global.css` → Variables y utilidades
  - `components/` → Componentes reutilizables
  - Archivos específicos por página
- **CSS Variables** para tema consistente
- **Flexbox y Grid** para layouts
- **Media Queries** para responsive
- **Animaciones y transiciones** con hover effects

### JavaScript:
- **Modular:** Archivo separado por funcionalidad
- **Sin dependencias externas:** Vanilla JS puro
- **Event Listeners** para interactividad
- **Validación de formularios** en tiempo real
- **Regex** para validación de email/teléfono

### Seguridad:
- **Sessions** con timeout configurado
- **HttpOnly cookies**
- **HTTPS redirection**
- **Input validation** cliente y servidor
- **SQL Server Integrated Security**

---

## 🎯 FUNCIONALIDADES IMPLEMENTADAS

### Usuario (Público):
✅ Navegación completa del sitio  
✅ Búsqueda de disponibilidad (UI)  
✅ Visualización de habitaciones desde BD  
✅ Información sobre el hotel  
✅ Formulario de contacto con validación  
✅ Modales de login/registro (UI)  
✅ Diseño responsive completo  

### Administrador:
✅ Sistema de login con sesiones  
✅ Dashboard con estadísticas (mockup)  
✅ Navegación del panel admin  
✅ Logout funcional  
✅ Protección de rutas  

---

## 🔜 FUNCIONALIDADES PENDIENTES

### Usuario:
- ⏳ Implementar autenticación de usuarios
- ⏳ Sistema de reservaciones funcional
- ⏳ Integración con pasarela de pago
- ⏳ Sistema de reseñas
- ⏳ Perfil de usuario
- ⏳ Historial de reservaciones
- ⏳ Confirmación por email

### Administrador:
- ⏳ CRUD de habitaciones
- ⏳ Gestión de reservaciones
- ⏳ Gestión de usuarios
- ⏳ Reportes y estadísticas reales
- ⏳ Gestión de disponibilidad
- ⏳ Configuración del sistema
- ⏳ Dashboard con datos en tiempo real

---

## 🛠️ COMANDOS PARA EJECUTAR

### Desarrollo:
```bash
cd "/Users/esteban/Desktop/Universidad /VI Cuatrimestre/Bases de datos 2/nomadate_web"

# Restaurar dependencias
dotnet restore

# Ejecutar la aplicación
dotnet run

# Ejecutar con hot reload
dotnet watch run
```

### Acceso:
- **Sitio público:** https://localhost:5001
- **Panel admin:** https://localhost:5001/admin
- **Login admin:** https://localhost:5001/admin/login

### Base de Datos:
```bash
# Conectarse a SQL Server
sqlcmd -S localhost,1433 -U sa -P tu_password

# Crear base de datos
USE master;
CREATE DATABASE nomadate;
```

---

## 👥 EQUIPO DE DESARROLLO

- **Esteban Hernandez** - Director y Desarrollador Principal
- **Santiago Osejo** - Gestión y Testing
- **Jason Flores** - Operaciones y Base de Datos

---

## 📄 LICENCIA Y NOTAS

Este proyecto es parte de un sistema de gestión hotelera para Hotel Nomadate. 

**Versión Actual:** 1.0  
**Última Actualización:** 26 de noviembre de 2025  
**Estado:** En desarrollo activo

---

## 🐛 BUGS CONOCIDOS

Ninguno reportado hasta el momento.

---

## 📞 SOPORTE

Para preguntas o problemas:
- Email: info@hotelnomadate.com
- Teléfono: +506 2222-3333
