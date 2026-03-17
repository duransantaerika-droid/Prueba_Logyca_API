# 🚀 Prueba Técnica Logyca API

API desarrollada en **ASP.NET Core** siguiendo principios de **Clean Architecture**, orientada a la gestión de empleados con buenas prácticas de diseño, separación de responsabilidades y escalabilidad.

---

## 🧱 Arquitectura

El proyecto está estructurado bajo el enfoque de **Clean Architecture**, dividiendo responsabilidades en capas bien definidas:

### 🔹 Domain
Contiene el núcleo del negocio:
- Entidades (Enterprise, Code)
- Reglas de negocio
- Lógica pura (sin dependencias externas)

### 🔹 Application
Define los casos de uso:
- Interfaces 
- DTOs
- Validaciones

### 🔹 Infrastructure
Implementaciones concretas:
- Repositorios
- Acceso a base de datos (Entity Framework Core)
- Configuraciones externas

Esta capa implementa las interfaces definidas en Application.

### 🔹 API (Presentation)
Punto de entrada del sistema:
- Controladores
- Endpoints REST
- Configuración de middlewares

---

## ⚙️ Tecnologías utilizadas

- .NET 8 / ASP.NET Core
- Entity Framework Core
- PostgreSQL
- ORM
- Swagger (OpenAPI)
- Git

---

## 📌 Principios aplicados

- Separación de responsabilidades (SRP)
- Inversión de dependencias (DIP)
- Arquitectura desacoplada
- Inyección de dependencias
- Código limpio y mantenible

---

## 📬 Endpoints principales

| Método | Endpoint               | Descripción              |
|--------|------------------------|--------------------------|
| GET    | /api/employees         | Obtener todos los empleados |
| GET    | /api/employees/{id}    | Obtener un empleado por ID |
| POST   | /api/employees         | Crear un nuevo empleado   |
| PUT    | /api/employees/{id}    | Actualizar un empleado    |
| DELETE | /api/employees/{id}    | Eliminar un empleado      |


## 🗂️ Estructura del proyecto

/Domain
/Application
/Infrastructure
/API



