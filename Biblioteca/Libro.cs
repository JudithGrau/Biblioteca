using System;


namespace Colecciones
{
    internal class Libro
    {
        private string titulo;
        private string autor;
        private string editorial;
        public Libro(string titulo, string autor, string editorial)
        {
            this.titulo = titulo;
            this.autor = autor;
            this.editorial = editorial;
        }
        public string Titulo { get { return titulo; } }
        public string Autor { get { return autor; } }
        public string Editorial { get { return editorial; } }

        public void MostrarInformacion()
        {
            Console.WriteLine("Título: " + titulo + ", Autor: " + autor + ", Editorial: " + editorial);
        }
    }
}
