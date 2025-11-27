-- =============================================
-- Script de Habitaciones para Hotel Nomadate
-- Insertar datos de ejemplo en la tabla Habitacion
-- =============================================

USE nomadate;
GO

-- Verificar si la tabla existe
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Habitacion')
BEGIN
    PRINT 'ERROR: La tabla Habitacion no existe. Por favor ejecute primero el script de creación de tablas.'
    RETURN;
END
GO

-- Limpiar datos existentes (opcional - comentar si no se desea)
-- DELETE FROM Habitacion;
-- DBCC CHECKIDENT ('Habitacion', RESEED, 0);
-- GO

-- =============================================
-- Insertar Habitaciones Individuales (1 persona)
-- =============================================

INSERT INTO Habitacion (Numero_Habitacion, Capacidad, Precio, Descripcion, Tiene_Aire, Tiene_TV, Ruta_Imagen)
VALUES 
('101', 1, 45.00, 'Habitación individual acogedora con cama simple, ideal para viajeros solitarios. Incluye escritorio y baño privado.', 1, 1, '/images/rooms/room-101.jpg'),
('102', 1, 45.00, 'Habitación individual con vista a la ciudad. Perfecta para estancias de negocio, con espacio de trabajo.', 1, 1, '/images/rooms/room-102.jpg'),
('103', 1, 42.00, 'Habitación individual económica con ventilador. Cómoda y funcional para estancias cortas.', 0, 1, '/images/rooms/room-103.jpg');

-- =============================================
-- Insertar Habitaciones Dobles (2 personas)
-- =============================================

INSERT INTO Habitacion (Numero_Habitacion, Capacidad, Precio, Descripcion, Tiene_Aire, Tiene_TV, Ruta_Imagen)
VALUES 
('201', 2, 75.00, 'Habitación doble estándar con cama matrimonial. Amplio armario y baño completo con ducha.', 1, 1, '/images/rooms/room-201.jpg'),
('202', 2, 75.00, 'Habitación doble con dos camas individuales. Ideal para amigos o colegas de trabajo.', 1, 1, '/images/rooms/room-202.jpg'),
('203', 2, 80.00, 'Habitación doble superior con cama king size y balcón privado. Vista panorámica a la ciudad.', 1, 1, '/images/rooms/room-203.jpg'),
('204', 2, 70.00, 'Habitación doble con cama queen size. Decoración moderna y televisión de pantalla plana.', 1, 1, '/images/rooms/room-204.jpg'),
('205', 2, 65.00, 'Habitación doble económica con ventilador. Limpia y confortable para presupuestos ajustados.', 0, 1, '/images/rooms/room-205.jpg');

-- =============================================
-- Insertar Habitaciones Triples (3 personas)
-- =============================================

INSERT INTO Habitacion (Numero_Habitacion, Capacidad, Precio, Descripcion, Tiene_Aire, Tiene_TV, Ruta_Imagen)
VALUES 
('301', 3, 95.00, 'Habitación triple con una cama matrimonial y una individual. Perfecta para familias pequeñas.', 1, 1, '/images/rooms/room-301.jpg'),
('302', 3, 95.00, 'Habitación triple con tres camas individuales. Amplio espacio de almacenamiento.', 1, 1, '/images/rooms/room-302.jpg'),
('303', 3, 100.00, 'Habitación triple superior con baño grande y área de estar. Incluye minibar.', 1, 1, '/images/rooms/room-303.jpg'),
('304', 3, 90.00, 'Habitación triple estándar con closet amplio. Iluminación natural y ambiente acogedor.', 1, 1, '/images/rooms/room-304.jpg');

-- =============================================
-- Insertar Habitaciones Familiares (4+ personas)
-- =============================================

INSERT INTO Habitacion (Numero_Habitacion, Capacidad, Precio, Descripcion, Tiene_Aire, Tiene_TV, Ruta_Imagen)
VALUES 
('401', 4, 120.00, 'Habitación familiar con dos camas matrimoniales. Espacio amplio para toda la familia.', 1, 1, '/images/rooms/room-401.jpg'),
('402', 4, 120.00, 'Suite familiar con cama king y dos individuales. Incluye área de estar separada.', 1, 1, '/images/rooms/room-402.jpg'),
('403', 4, 130.00, 'Suite familiar deluxe con dos habitaciones conectadas. Baño compartido grande y balcón.', 1, 1, '/images/rooms/room-403.jpg'),
('404', 5, 150.00, 'Suite familiar premium para 5 personas. Dos habitaciones, sala de estar y comedor pequeño.', 1, 1, '/images/rooms/room-404.jpg'),
('405', 4, 115.00, 'Habitación familiar estándar con litera y cama matrimonial. Funcional y económica.', 1, 1, '/images/rooms/room-405.jpg');

-- =============================================
-- Insertar Suites de Lujo
-- =============================================

INSERT INTO Habitacion (Numero_Habitacion, Capacidad, Precio, Descripcion, Tiene_Aire, Tiene_TV, Ruta_Imagen)
VALUES 
('501', 2, 200.00, 'Suite de lujo con cama king size y jacuzzi privado. Vista espectacular y servicio premium.', 1, 1, '/images/rooms/room-501.jpg'),
('502', 2, 220.00, 'Suite presidencial con sala de estar, comedor y balcón amplio. Decoración elegante y refinada.', 1, 1, '/images/rooms/room-502.jpg'),
('503', 3, 250.00, 'Suite junior de lujo con dos habitaciones. Perfecta para luna de miel o ocasiones especiales.', 1, 1, '/images/rooms/room-503.jpg');

-- =============================================
-- Insertar Habitaciones Accesibles
-- =============================================

INSERT INTO Habitacion (Numero_Habitacion, Capacidad, Precio, Descripcion, Tiene_Aire, Tiene_TV, Ruta_Imagen)
VALUES 
('106', 2, 75.00, 'Habitación accesible en planta baja con baño adaptado. Amplias puertas y barras de apoyo.', 1, 1, '/images/rooms/room-106.jpg'),
('107', 2, 75.00, 'Habitación accesible con ducha sin escalón. Diseñada para personas con movilidad reducida.', 1, 1, '/images/rooms/room-107.jpg');

-- =============================================
-- Verificar inserción
-- =============================================

PRINT '============================================='
PRINT 'Resumen de habitaciones insertadas:'
PRINT '============================================='

SELECT 
    'Total de habitaciones' AS Descripcion,
    COUNT(*) AS Cantidad
FROM Habitacion
UNION ALL
SELECT 
    'Individuales (1 persona)',
    COUNT(*)
FROM Habitacion
WHERE Capacidad = 1
UNION ALL
SELECT 
    'Dobles (2 personas)',
    COUNT(*)
FROM Habitacion
WHERE Capacidad = 2
UNION ALL
SELECT 
    'Triples (3 personas)',
    COUNT(*)
FROM Habitacion
WHERE Capacidad = 3
UNION ALL
SELECT 
    'Familiares (4+ personas)',
    COUNT(*)
FROM Habitacion
WHERE Capacidad >= 4
UNION ALL
SELECT 
    'Con aire acondicionado',
    COUNT(*)
FROM Habitacion
WHERE Tiene_Aire = 1
UNION ALL
SELECT 
    'Con televisión',
    COUNT(*)
FROM Habitacion
WHERE Tiene_TV = 1;

PRINT '============================================='
PRINT 'Datos insertados correctamente!'
PRINT '============================================='

-- Mostrar todas las habitaciones
SELECT 
    Id_Habitacion,
    Numero_Habitacion AS 'Número',
    Capacidad AS 'Capacidad',
    Precio AS 'Precio/Noche',
    CASE WHEN Tiene_Aire = 1 THEN 'Sí' ELSE 'No' END AS 'A/C',
    CASE WHEN Tiene_TV = 1 THEN 'Sí' ELSE 'No' END AS 'TV',
    Descripcion AS 'Descripción'
FROM Habitacion
ORDER BY Numero_Habitacion;

GO
