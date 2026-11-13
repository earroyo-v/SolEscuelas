using System;
using System.Collections.Generic;
using Elek.Infrastructure.Persistence.StoredProcedures.Entities;
using Microsoft.EntityFrameworkCore;

namespace Elek.Infrastructure.Persistence.Data
{
    public partial class AppDbContext : DbContext
    {
        public virtual DbSet<EscuelaSP> EscuelasSP { get; set; } = null!;
    }
}
