using Elek.Application.Repositories;
using Elek.Application.Services.Escuelas;
using Elek.Application.Services.Escuelas.DTO;
using Elek.Domain.Domain;
using Elek.Infrastructure.Mappers;
using Elek.Infrastructure.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elek.Infrastructure.Implementation
{
    public class EscuelaImp : IEscuelaRepository
    {
        private readonly AppDbContext _context;
        public EscuelaImp(AppDbContext context)
        {
            _context = context;
        }
        public Task Create(Escuela user)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Guid UUID)
        {
            throw new NotImplementedException();
        }

        public Task<EscuelaDTO> Read(Guid UUID)
        {
            throw new NotImplementedException();
        }

        public async Task<List<EscuelaDTO>> ReadAll()
        {
            try
            {
                var escuelas = await _context.EscuelasSP.FromSqlInterpolated($@"
                    EXECUTE dbo.sp_Escuelas_CRUD
                    @Accion = {"GET_ALL"}
                    ")
                    .AsNoTracking()
                    .ToListAsync();
                return escuelas.Select(e => e.ToDTO()).ToList();
            }
            catch (Exception ex)
            {
                // Handle the exception (e.g., log it)
                throw new Exception("An error occurred while reading all schools.", ex);
            }
        }

        public Task Update(Escuela user)
        {
            throw new NotImplementedException();
        }
    }
}
