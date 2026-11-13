using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Elek.Infrastructure.Persistence.Entities;

[Index("Uuid", Name = "UQ__Escuelas__65A475E610D6570C", IsUnique = true)]
public partial class Escuela
{
    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string Nombre { get; set; } = null!;

    [StringLength(100)]
    [Unicode(false)]
    public string? Descripcion { get; set; }

    [Column("UUID")]
    public Guid Uuid { get; set; }

    [InverseProperty("IdEscuelaNavigation")]
    public virtual ICollection<Alumno> Alumnos { get; set; } = new List<Alumno>();

    [InverseProperty("IdEscuelaNavigation")]
    public virtual ICollection<Profesore> Profesores { get; set; } = new List<Profesore>();
}
