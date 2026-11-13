using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Elek.Infrastructure.Persistence.Entities;

[Index("Uuid", Name = "UQ__Alumnos__65A475E699FD6AB9", IsUnique = true)]
public partial class Alumno
{
    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string Nombre { get; set; } = null!;

    [StringLength(50)]
    [Unicode(false)]
    public string Apellido { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime FechaNacimiento { get; set; }

    public int IdEscuela { get; set; }

    [Column("UUID")]
    public Guid Uuid { get; set; }

    [InverseProperty("IdAlumnoNavigation")]
    public virtual ICollection<AlumnosXprofesore> AlumnosXprofesores { get; set; } = new List<AlumnosXprofesore>();

    [ForeignKey("IdEscuela")]
    [InverseProperty("Alumnos")]
    public virtual Escuela IdEscuelaNavigation { get; set; } = null!;
}
