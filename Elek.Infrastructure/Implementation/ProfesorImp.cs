using Elek.Application.Repositories;
using Elek.Application.Services.Profesores.DTO;
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
    public class ProfesorImp : IProfesorRepository
    {
        private readonly AppDbContext _context;
        public ProfesorImp(AppDbContext context)
        {
            _context = context;
        }
        public async Task<ProfesorDTO> Create(Profesor user)
        {
            var profesores = await _context.ProfesoresSP
            .FromSqlInterpolated($@"
                    EXECUTE dbo.sp_Profesores_CRUD
                    @Accion = {"INSERT"},
                    @Nombre = {user.Nombre},
                    @Apellido = {user.Apellido},
                    @IdEscuela = {user.IdEscuela},
                    @UUID = {user.Uuid}
                ")
            .AsNoTracking()
            .ToListAsync();

            var profesor = profesores.FirstOrDefault();

            return profesor?.ToDTO()!;
        }

        public async Task<ProfesorDTO> Delete(Guid UUID)
        {
            var profesores = await _context.ProfesoresSP
            .FromSqlInterpolated($@"
                    EXECUTE dbo.sp_Profesores_CRUD
                    @Accion = {"DELETE"},
                    @UUID = {UUID}
                ")
            .AsNoTracking()
            .ToListAsync();

            var profesor = profesores.FirstOrDefault();

            return profesor?.ToDTO()!;
        }

        public async Task<ProfesorDTO> Read(Guid UUID)
        {
            var profesores = await _context.ProfesoresSP
            .FromSqlInterpolated($@"
                    EXECUTE dbo.sp_Profesores_CRUD
                    @Accion = {"GET_UUID"},
                    @UUID = {UUID}
                ")
            .AsNoTracking()
            .ToListAsync();

            var profesor = profesores.FirstOrDefault();

            return profesor?.ToDTO()!;
        }

        public async Task<List<ProfesorDTO>> ReadAll()
        {
            var profesores = await _context.ProfesoresSP.FromSqlInterpolated($@"
                    EXECUTE dbo.sp_Profesores_CRUD
                    @Accion = {"GET_ALL"}
                    ")
                .AsNoTracking()
                .ToListAsync();
            return profesores.Select(e => e.ToDTO()).ToList();
        }

        public async Task<ProfesorDTO> Update(Profesor user)
        {
            var profesores = await _context.ProfesoresSP
            .FromSqlInterpolated($@"
                    EXECUTE dbo.sp_Profesores_CRUD
                    @Accion = {"UPDATE"},
                    @Nombre = {user.Nombre},
                    @Apellido = {user.Apellido},
                    @IdEscuela = {user.IdEscuela},
                    @UUID = {user.Uuid}
                ")
            .AsNoTracking()
            .ToListAsync();

            var profesor = profesores.FirstOrDefault();

            return profesor?.ToDTO()!;
        }
        public async Task<ProfesorDTO> UpdateName(Profesor user)
        {
            var profesores = await _context.ProfesoresSP
            .FromSqlInterpolated($@"
                    EXECUTE dbo.sp_Profesores_CRUD
                    @Accion = {"UPDATE_NAME"},
                    @Nombre = {user.Nombre},
                    @UUID = {user.Uuid}
                ")
            .AsNoTracking()
            .ToListAsync();

            var profesor = profesores.FirstOrDefault();

            return profesor?.ToDTO()!;
        }
        public async Task<ProfesorDTO> UpdateApellido(Profesor user)
        {
            var profesores = await _context.ProfesoresSP
            .FromSqlInterpolated($@"
                    EXECUTE dbo.sp_Profesores_CRUD
                    @Accion = {"UPDATE_SUB"},
                    @Apellido = {user.Apellido},
                    @UUID = {user.Uuid}
                ")
            .AsNoTracking()
            .ToListAsync();

            var profesor = profesores.FirstOrDefault();

            return profesor?.ToDTO()!;
        }
    }
}
