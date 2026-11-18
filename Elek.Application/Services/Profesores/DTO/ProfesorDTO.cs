using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elek.Application.Services.Profesores.DTO
{
    public class ProfesorDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public int IdEscuela { get; set; }
        public Guid Uuid { get; set; }
    }
}
