using System;
using System.Collections.Generic;

namespace Colecciones
{
    internal class Lector
    {
        private string nombre;
        private string dni;
        private List<Libro> prestamos;

        public Lector(string nombre, string dni)
        {
            this.nombre = nombre;
            this.dni = dni;
            prestamos = new List<Libro>();
        }

        public string Dni { get { return dni; } }
        public string Nombre { get { return nombre; } }
        public List<Libro> Prestamos { get { return prestamos; } }

        // + Verifica si puede tomar un nuevo préstamo
        public bool PuedePrestar()
        {
            return prestamos.Count < 3;
        }

        // + Agrega un libro a la lista de préstamos
        public void AgregarPrestamo(Libro libro)
        {
            if (PuedePrestar())
                prestamos.Add(libro);
        }

        // + Muestra los préstamos del lector
        public void MostrarPrestamos()
        {
            Console.WriteLine($"Lector: {nombre} (DNI: {dni})");
            if (prestamos.Count == 0)
            {
                Console.WriteLine("   Sin préstamos vigentes.");
            }
            else
            {
                Console.WriteLine("   Préstamos vigentes:");
                foreach (var libro in prestamos)
                    libro.MostrarInformacion();
            }
        }
    }
}
