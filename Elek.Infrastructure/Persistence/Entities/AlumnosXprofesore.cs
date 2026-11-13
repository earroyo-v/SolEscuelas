using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Elek.Infrastructure.Persistence.Entities;

[Table("AlumnosXProfesores")]
public partial class AlumnosXprofesore
{
    [Key]
    public int Id { get; set; }

    public int IdProfesor { get; set; }

    public int IdAlumno { get; set; }

    [ForeignKey("IdAlumno")]
    [InverseProperty("AlumnosXprofesores")]
    public virtual Alumno IdAlumnoNavigation { get; set; } = null!;

    [ForeignKey("IdProfesor")]
    [InverseProperty("AlumnosXprofesores")]
    public virtual Profesore IdProfesorNavigation { get; set; } = null!;
}
