using Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IUnitService
    {
        Task<Unit> AddUnitAsync(string name, string description, string imagePath);
        Task<List<Unit>> GetUnitsAsync();
    }
}
