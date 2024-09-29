-- base de datos "juego"
CREATE DATABASE juego;

-- Uso de la base de datos "juego"
USE juego;

-- Creación de la tabla "jugadores"
CREATE TABLE jugadores (
    id INT AUTO_INCREMENT PRIMARY KEY, -- Identificador del jugador
    nombre VARCHAR(50) NOT NULL, -- Nombre del jugador
    contrasena VARCHAR(100) NOT NULL, -- Contraseña del jugador
    partidas_ganadas INT DEFAULT 0, -- Número de partidas ganadas (por defecto 0)
    partidas_perdidas INT DEFAULT 0 -- Número de partidas perdidas (por defecto 0)
);

-- Inserción de registros de ejemplo
INSERT INTO jugadores (nombre, contrasena, partidas_ganadas, partidas_perdidas) VALUES 
('Jugador1', 'contrasena1', 10, 5),
('Jugador2', 'contrasena2', 20, 15),
('Jugador3', 'contrasena3', 5, 5);
('Jugador4', 'contrasena4',15, 10);
('Jugador5', 'contrasena5', 25, 20);

-- Selección de todos los registros para verificar la inserción
SELECT * FROM jugadores;
