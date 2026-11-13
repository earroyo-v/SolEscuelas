using Elek.Application.Services.Escuelas.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elek.Application.Services.Escuelas
{
    public class EscuelaService : IEscuelaService
    {
        private readonly Repositories.IEscuelaRepository _escuelaRepository;
        public EscuelaService(Repositories.IEscuelaRepository escuelaRepository)
        {
            _escuelaRepository = escuelaRepository;
        }
        public Task ActualizaEscuela(EscuelaDTO escuelaDTO)
        {
            throw new NotImplementedException();
        }

        public Task CrearEscuela(EscuelaDTO escuelaDTO)
        {
            throw new NotImplementedException();
        }

        public Task EliminaEscuela(Guid UUID)
        {
            throw new NotImplementedException();
        }

        public async Task<EscuelaDTO> ObtenEscuela(Guid UUID)
        {
            throw new NotImplementedException();
        }

        public async Task<List<EscuelaDTO>> ObtenEscuelas()
        {
            try
            {
                var escuelas = await _escuelaRepository.ReadAll();
                return escuelas;
            }
            catch (Exception ex)
            {
                // Log the exception (you can use a logging framework here)
                throw new ApplicationException("An error occurred while retrieving schools.", ex);
            }
        }
    }
}
