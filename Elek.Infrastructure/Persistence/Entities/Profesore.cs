using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Elek.Infrastructure.Persistence.Entities;

[Index("Uuid", Name = "UQ__Profesor__65A475E61B9AB92F", IsUnique = true)]
public partial class Profesore
{
    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string Nombre { get; set; } = null!;

    [StringLength(50)]
    [Unicode(false)]
    public string Apellido { get; set; } = null!;

    public int IdEscuela { get; set; }

    [Column("UUID")]
    public Guid Uuid { get; set; }

    [InverseProperty("IdProfesorNavigation")]
    public virtual ICollection<AlumnosXprofesore> AlumnosXprofesores { get; set; } = new List<AlumnosXprofesore>();

    [ForeignKey("IdEscuela")]
    [InverseProperty("Profesores")]
    public virtual Escuela IdEscuelaNavigation { get; set; } = null!;
}
