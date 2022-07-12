using AutoMapper;
using Entities;
using Entities.DTO;
using Microsoft.EntityFrameworkCore;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class UnitService : IUnitService
    {
        private readonly IGenericRepository<Unit> _genericRepository;
        private readonly IMapper _mapper;

        public UnitService(IGenericRepository<Unit> genericRepository, IMapper mapper)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
        }

        public async Task<Unit> AddUnitAsync(CreateUnitDTO createUnitDTO)
        {
            Unit unit = _mapper.Map<CreateUnitDTO, Unit>(createUnitDTO);

            await _genericRepository.CreateAsync(unit);

            return unit;
        }

        public async Task<List<GetUnitsDTO>> GetUnitsAsync()
        {
            var units = await (await _genericRepository.QueryAsync()).Include(u => u.Lessons).ToListAsync();

            var unitsDTO = _mapper.Map<List<GetUnitsDTO>>(units);

            return unitsDTO;
        }

        public async Task<Unit> UpdateUnitAsync(UpdateUnitDTO updateUnitDTO)
        {
            Unit unit = _mapper.Map<UpdateUnitDTO, Unit>(updateUnitDTO);

            await _genericRepository.UpdateAsync(unit);

            return unit;
        }

        public async Task<Unit> DeleteUnitAsync(long id)
        {

            Unit unitToDelete = new Unit { Id = id };

            await _genericRepository.RemoveAsync(unitToDelete);            

            return unitToDelete;
        }

    }
}
