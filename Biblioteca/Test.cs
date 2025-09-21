using System;

namespace Colecciones
{
    internal class Test
    {
        static void Main(string[] args)
        {
            Biblioteca biblioteca = new Biblioteca();

            // + Agregar libros a la biblioteca
            biblioteca.AgregarLibro("Cien Años de Soledad", "Gabriel García Márquez", "Sudamericana");
            biblioteca.AgregarLibro("Rayuela", "Julio Cortázar", "Sudamericana");
            biblioteca.AgregarLibro("El Aleph", "Jorge Luis Borges", "Emecé");

            // + Registrar lectores
            biblioteca.AltaLector("Juan Pérez", "123");
            biblioteca.AltaLector("María López", "456");

            // Listar estado inicial
            Console.WriteLine("\n+ Libros en la biblioteca:");
            biblioteca.ListarLibros();
            Console.WriteLine("\n+ Lectores registrados:");
            biblioteca.ListarLectores();

            // --- PRÉSTAMOS ---
            Console.WriteLine("\n--- PRÉSTAMOS ---");

            // Préstamos válidos
            Console.WriteLine(biblioteca.PrestarLibro("Cien Años de Soledad", "123"));
            Console.WriteLine(biblioteca.PrestarLibro("Rayuela", "123"));
            Console.WriteLine(biblioteca.PrestarLibro("El Aleph", "123"));

            // Tope de préstamos alcanzado
            biblioteca.AgregarLibro("Libro Extra", "Autor X", "Editorial X"); // nuevo libro para probar tope
            Console.WriteLine(biblioteca.PrestarLibro("Libro Extra", "123"));   // TOPE DE PRESTAMO ALCANZADO

            // Lector inexistente
            Console.WriteLine(biblioteca.PrestarLibro("Rayuela", "999"));

            // Libro inexistente
            Console.WriteLine(biblioteca.PrestarLibro("Libro Inexistente", "456"));


            // + Estado final
            Console.WriteLine("\n--- Estado final ---");
            Console.WriteLine("+ Libros en la biblioteca:");
            biblioteca.ListarLibros();
            Console.WriteLine("\n+ Lectores registrados:");
            biblioteca.ListarLectores();
        }
    }
}
