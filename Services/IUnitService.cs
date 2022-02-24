using Entities;
using Entities.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IUnitService
    {
        Task<Unit> AddUnitAsync(CreateUnitDTO createUnitDTO);
        Task<Unit> UpdateUnitAsync(UpdateUnitDTO updateUnitDTO);
        Task<Unit> DeleteUnitAsync(long id);
        Task<List<Unit>> GetUnitsAsync();
    }
}
