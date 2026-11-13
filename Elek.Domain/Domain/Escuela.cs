using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Elek.Domain.Domain
{
    public class Escuela
    {
        public int Id { get; private set; }
        public string Nombre { get; private set; } = null!;
        public string Descripcion { get; private set; } = null!;
        public Guid UUID { get; private set; }

        private Escuela() { }
        // Creación
        private Escuela(string nombre, string descripcion)
        {
            Nombre = nombre;
            Descripcion = descripcion;
            UUID = Guid.NewGuid();
        }
        // Reconstrucción desde persistencia
        public Escuela(int id, string nombre, string descripcion, Guid uuid)
        {
            Id = id;
            Nombre = nombre;
            Descripcion = descripcion;
            UUID = uuid;
        }
        public static Escuela Create(string nombre, string descripcion)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                throw new ArgumentException("El nombre no puede estar vacío.");

            return new Escuela(nombre, descripcion);
        }
        public void Actualizar(string nombre, string descripcion)
        {
            if (string.IsNullOrWhiteSpace(nombre))
            {
                throw new ArgumentException("El nombre de la escuela no puede estar vacío.");
            }
            Nombre = nombre;
            Descripcion = descripcion;
        }
    }
}
