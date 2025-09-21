# Proyecto Biblioteca en C# – Manejo de Colecciones

## Descripción

Este proyecto simula la gestión de una biblioteca utilizando **colecciones y listas en C#**.  

Se pueden registrar libros y lectores, realizar préstamos de libros y controlar el estado de los préstamos. Cada lector puede tener hasta **3 préstamos vigentes**. Los libros se identifican por su título y se manejan mediante una colección (`List<Libro>`), mientras que los lectores también se almacenan en una colección (`List<Lector>`).  

El proyecto permite probar distintas acciones, como agregar libros, eliminar libros, registrar lectores y realizar préstamos, mostrando mensajes claros sobre el resultado de cada operación.

---

## Funcionalidades

- Registrar libros en la biblioteca.
- Eliminar libros existentes.
- Listar todos los libros disponibles.
- Dar de alta lectores si no estaban previamente registrados.
- Listar lectores y sus préstamos vigentes.
- Prestar libros a lectores:
  - Retira el libro de la biblioteca.
  - Asigna el libro al lector.
  - Controla el máximo de 3 préstamos por lector.
  - Maneja casos de error:
    - Libro inexistente.
    - Lector inexistente.
    - Tope de préstamos alcanzado.

---

## Estructura de Clases

### Biblioteca
- **Atributos:**  
  - `List<Libro> libros`  
  - `List<Lector> lectores`  
- **Métodos principales:**  
  - `AgregarLibro(string titulo, string autor, string editorial)`  
  - `EliminarLibro(string titulo)`  
  - `ListarLibros()`  
  - `AltaLector(string nombre, string dni)`  
  - `ListarLectores()`  
  - `PrestarLibro(string titulo, string dni)`

### Lector
- **Atributos:**  
  - `string nombre`  
  - `string dni`  
  - `List<Libro> prestamos`  
- **Métodos principales:**  
  - `PuedePrestar()`  
  - `AgregarPrestamo(Libro libro)`  
  - `MostrarPrestamos()`

### Libro
- **Atributos:**  
  - `string titulo`  
  - `string autor`  
  - `string editorial`  
- **Métodos principales:**  
  - `MostrarInformacion()`  
  - `Titulo { get; }`

---

## UML (Clases y relaciones)
+------------------+
| Biblioteca |
+------------------+
| - libros: List<Libro> |
| - lectores: List<Lector> |
+------------------+
| + AgregarLibro(...) |
| + EliminarLibro(...) |
| + ListarLibros() |
| + AltaLector(...) |
| + ListarLectores() |
| + PrestarLibro(...) |
+------------------+
     1
     |
     *
+------------------+
| Lector |
+------------------+
| - nombre: string |
| - dni: string |
| - prestamos: List<Libro> |
+------------------+
| + PuedePrestar() |
| + AgregarPrestamo(...) |
| + MostrarPrestamos() |
+------------------+
     1
     |
     *
+------------------+
| Libro |
+------------------+
| - titulo: string |
| - autor: string |
| - editorial: string |
+------------------+
| + MostrarInformacion() |
+------------------+
---

## Ejemplo de Uso

```csharp
Biblioteca biblioteca = new Biblioteca();

// Agregar libros
biblioteca.AgregarLibro("Cien Años de Soledad", "Gabriel García Márquez", "Sudamericana");
biblioteca.AgregarLibro("Rayuela", "Julio Cortázar", "Sudamericana");
biblioteca.AgregarLibro("El Aleph", "Jorge Luis Borges", "Emecé");

// Registrar lectores
biblioteca.AltaLector("Juan Pérez", "123");
biblioteca.AltaLector("María López", "456");

// Realizar préstamos
Console.WriteLine(biblioteca.PrestarLibro("Cien Años de Soledad", "123")); // PRESTAMO EXITOSO
Console.WriteLine(biblioteca.PrestarLibro("Rayuela", "123")); // PRESTAMO EXITOSO
Console.WriteLine(biblioteca.PrestarLibro("El Aleph", "123")); // PRESTAMO EXITOSO
Console.WriteLine(biblioteca.PrestarLibro("Rayuela", "123")); // TOPE DE PRESTAMO ALCANZADO
Console.WriteLine(biblioteca.PrestarLibro("Cien Años de Soledad", "999")); // LECTOR INEXISTENTE
Console.WriteLine(biblioteca.PrestarLibro("Libro Inexistente", "123")); // LIBRO INEXISTENTE
