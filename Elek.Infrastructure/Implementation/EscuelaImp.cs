using Elek.Application.Repositories;
using Elek.Application.Services.Escuelas;
using Elek.Application.Services.Escuelas.DTO;
using Elek.Domain.Domain;
using Elek.Infrastructure.Mappers;
using Elek.Infrastructure.Persistence.Data;
using Elek.Infrastructure.Persistence.StoredProcedures.Entities;
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
        public async Task<EscuelaDTO> Create(Escuela user)
        {
            var escuelas = await _context.EscuelasSP
            .FromSqlInterpolated($@"
                    EXECUTE dbo.sp_Escuelas_CRUD
                    @Accion = {"INSERT"},
                    @Nombre = {user.Nombre},
                    @Descripcion = {user.Descripcion},
                    @UUID = {user.UUID}
                ")
            .AsNoTracking()
            .ToListAsync();

            var escuela = escuelas.FirstOrDefault();

            return escuela?.ToDTO()!;
        }

        public async Task<EscuelaDTO> Delete(Guid UUID)
        {
            var escuelas = await _context.EscuelasSP
            .FromSqlInterpolated($@"
                    EXECUTE dbo.sp_Escuelas_CRUD
                    @Accion = {"DELETE"},
                    @UUID = {UUID}
                ")
            .AsNoTracking()
            .ToListAsync();

            var escuela = escuelas.FirstOrDefault();

            return escuela?.ToDTO()!;
        }

        public async Task<EscuelaDTO> Read(Guid UUID)
        {
            var escuelas = await _context.EscuelasSP
            .FromSqlInterpolated($@"
                    EXECUTE dbo.sp_Escuelas_CRUD
                    @Accion = {"GET_UUID"},
                    @UUID = {UUID}
                ")
            .AsNoTracking()
            .ToListAsync();

            var escuela = escuelas.FirstOrDefault();

            return escuela?.ToDTO()!;
        }

        public async Task<List<EscuelaDTO>> ReadAll()
        {
            var escuelas = await _context.EscuelasSP.FromSqlInterpolated($@"
                    EXECUTE dbo.sp_Escuelas_CRUD
                    @Accion = {"GET_ALL"}
                    ")
                .AsNoTracking()
                .ToListAsync();
            return escuelas.Select(e => e.ToDTO()).ToList();
        }

        public async Task<EscuelaDTO> Update(Escuela user)
        {
            var escuelas = await _context.EscuelasSP
            .FromSqlInterpolated($@"
                    EXECUTE dbo.sp_Escuelas_CRUD
                    @Accion = {"UPDATE"},
                    @Nombre = {user.Nombre},
                    @Descripcion = {user.Descripcion},
                    @UUID = {user.UUID}
                ")
            .AsNoTracking()
            .ToListAsync();

            var escuela = escuelas.FirstOrDefault();

            return escuela?.ToDTO()!;
        }
        public async Task<EscuelaDTO> UpdateName(Escuela user)
        {
            var escuelas = await _context.EscuelasSP
            .FromSqlInterpolated($@"
                    EXECUTE dbo.sp_Escuelas_CRUD
                    @Accion = {"UPDATE_NAME"},
                    @Nombre = {user.Nombre},
                    @UUID = {user.UUID}
                ")
            .AsNoTracking()
            .ToListAsync();

            var escuela = escuelas.FirstOrDefault();

            return escuela?.ToDTO()!;
        }
        public async Task<EscuelaDTO> UpdateDescription(Escuela user)
        {
            var escuelas = await _context.EscuelasSP
            .FromSqlInterpolated($@"
                    EXECUTE dbo.sp_Escuelas_CRUD
                    @Accion = {"UPDATE_DESC"},
                    @Descripcion = {user.Descripcion},
                    @UUID = {user.UUID}
                ")
            .AsNoTracking()
            .ToListAsync();

            var escuela = escuelas.FirstOrDefault();

            return escuela?.ToDTO()!;
        }
    }
}
