using AutoMapper;
using Entities;
using Entities.DTO;
using Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CardsetService : ICardsetService
    {
        private readonly IGenericRepository<Cardset> _genericRepository;
        private readonly IMapper _mapper;

        public CardsetService(IGenericRepository<Cardset> genericRepository, IMapper mapper)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
        }

        public async Task<Cardset> AddCardsetAsync(AddCardsetDTO addCardsetDTO)
        {
            Cardset cardset = _mapper.Map<AddCardsetDTO, Cardset>(addCardsetDTO);

            await _genericRepository.CreateAsync(cardset);

            return cardset;
        }

    }
}
