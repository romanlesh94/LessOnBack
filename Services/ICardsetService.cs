using Entities;
using Entities.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface ICardsetService
    {
        Task<Cardset> AddCardsetAsync(AddCardsetDTO addCardsetDTO);
    }
}
