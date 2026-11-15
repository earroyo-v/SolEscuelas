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
                throw new InvalidOperationException("El nombre no puede estar vacío.");

            return new Escuela(nombre, descripcion);
        }
        public void Actualizar(string newNombre, string newDescripcion)
        {
            if (string.IsNullOrWhiteSpace(newNombre))
            {
                throw new InvalidOperationException("El nombre de la escuela no puede estar vacío.");
            }
            if (newNombre == Nombre && newDescripcion == Descripcion)
            {
                throw new InvalidOperationException("No se realizaron cambios en la escuela.");
            }
            Nombre = newNombre;
            Descripcion = newDescripcion;
        }
        public void ActualizarNombre(string newNombre)
        {
            if (string.IsNullOrWhiteSpace(newNombre))
            {
                throw new InvalidOperationException("El nombre de la escuela no puede estar vacío.");
            }
            if (newNombre == Nombre)
            {
                throw new InvalidOperationException("No se realizaron cambios en la escuela.");
            }
            Nombre = newNombre;
        }
        public void ActualizarDescripcion(string newDescripcion)
        {
            if (string.IsNullOrWhiteSpace(newDescripcion))
            {
                throw new InvalidOperationException("La descripción de la escuela no puede estar vacía.");
            }
            if (newDescripcion == Descripcion)
            {
                throw new InvalidOperationException("No se realizaron cambios en la escuela.");
            }
            Descripcion = newDescripcion;
        }
    }
}
