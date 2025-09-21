using System;
using System.Collections.Generic;


namespace Colecciones

{
    internal class Biblioteca
    {
        private List<Libro> libros;
        private List<Lector> lectores;

        public Biblioteca()
        {
            libros = new List<Libro>();
            lectores = new List<Lector>();
        }

        // + Agrega un libro a la biblioteca si no existe
        public bool AgregarLibro(string titulo, string autor, string editorial)
        {
            if (BuscarLibro(titulo) == null)
            {
                libros.Add(new Libro(titulo, autor, editorial));
                return true;
            }
            return false;
        }

        // + Elimina un libro por título
        public bool EliminarLibro(string titulo)
        {
            Libro libro = BuscarLibro(titulo);
            if (libro != null)
            {
                libros.Remove(libro);
                return true;
            }
            return false;
        }

        // + Busca libro
        private Libro BuscarLibro(string titulo)
        {
            foreach (var libro in libros)
            {
                if (libro.Titulo.Equals(titulo))
                    return libro;
            }
            return null;
        }

        // + Busca lector
        private Lector BuscarLector(string dni)
        {
            foreach (var lector in lectores)
            {
                if (lector.Dni.Equals(dni))
                    return lector;
            }
            return null;
        }

        // + Registra un lector si no estaba previamente registrado
        public bool AltaLector(string nombre, string dni)
        {
            if (BuscarLector(dni) == null)
            {
                lectores.Add(new Lector(nombre, dni));
                return true;
            }
            return false;
        }

        // + Presta libro
        public string PrestarLibro(string titulo, string dni)
        {
            Lector lector = BuscarLector(dni);
            if (lector == null)
                return "LECTOR INEXISTENTE";

            if (!lector.PuedePrestar())
                return "TOPE DE PRESTAMO ALCANZADO";

            Libro libro = BuscarLibro(titulo);
            if (libro == null)
                return "LIBRO INEXISTENTE";

            // Prestamo exitoso
            lector.AgregarPrestamo(libro);
            libros.Remove(libro);
            return "PRESTAMO EXITOSO";
        }

        // + Lista libros
        public void ListarLibros()
        {
            if (libros.Count == 0)
                Console.WriteLine("   No hay libros en la biblioteca.");
            else
            {
                foreach (var libro in libros)
                    libro.MostrarInformacion();
            }
        }

        // + Lista lectores
        public void ListarLectores()
        {
            if (lectores.Count == 0)
                Console.WriteLine("   No hay lectores registrados.");
            else
            {
                foreach (var lector in lectores)
                    lector.MostrarPrestamos();
            }
        }
    }
}
