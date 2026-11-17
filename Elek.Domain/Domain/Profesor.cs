using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elek.Domain.Domain
{
    public class Profesor
    {
        public int Id { get; private set; }

        public string Nombre { get; private set; } = null!;

        public string Apellido { get; private set; } = null!;

        public int IdEscuela { get; private set; }

        public Guid Uuid { get; private set; }

        private Profesor() { }

        public Profesor(string nombre, string apellido, int idEscuela)
        {
            Nombre = nombre;
            Apellido = apellido;
            IdEscuela = idEscuela;
            Uuid = Guid.NewGuid();
        }
        public Profesor(int id, string nombre, string apellido, int idEscuela, Guid uuid)
        {
            Id = id;
            Nombre = nombre;
            Apellido = apellido;
            IdEscuela = idEscuela;
            Uuid = uuid;
        }

        public static Profesor Create(string nombre, string apellido, int idEscuela)
        {
            if (string.IsNullOrWhiteSpace(nombre))
            {
                throw new ArgumentException("El nombre no puede estar vacío.", nameof(nombre));
            }
            if (string.IsNullOrWhiteSpace(apellido))
            {
                throw new ArgumentException("El apellido no puede estar vacío.", nameof(apellido));
            }
            if (idEscuela <= 0)
            {
                throw new ArgumentException("El id de la escuela debe ser un número positivo.", nameof(idEscuela));
            }
            return new Profesor(nombre, apellido, idEscuela);
        }

        public void Update(string nombre, string apellido, int idEscuela)
        {
            if (string.IsNullOrWhiteSpace(nombre))
            {
                throw new ArgumentException("El nombre no puede estar vacío.", nameof(nombre));
            }
            if (string.IsNullOrWhiteSpace(apellido))
            {
                throw new ArgumentException("El apellido no puede estar vacío.", nameof(apellido));
            }
            if (idEscuela <= 0)
            {
                throw new ArgumentException("El id de la escuela debe ser un número positivo.", nameof(idEscuela));
            }
            Nombre = nombre;
            Apellido = apellido;
            IdEscuela = idEscuela;
        }
    }
}
