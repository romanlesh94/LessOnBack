﻿using Entities;
using Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class UnitService : IUnitService
    {
        private readonly IGenericRepository<Unit> _genericRepository;
        public UnitService(IGenericRepository<Unit> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public async Task<Unit> AddUnitAsync(string name, string description, string imagePath)
        {
            Unit unit = new Unit { Name = name, Description = description, ImagePath = imagePath };

            await _genericRepository.CreateAsync(unit);

            return unit;
        }
    }
}