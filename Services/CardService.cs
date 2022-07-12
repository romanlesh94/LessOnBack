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
    public class CardService : ICardService
    {
        private readonly IGenericRepository<Card> _genericRepository;
        private readonly IMapper _mapper;

        public CardService(IGenericRepository<Card> genericRepository, IMapper mapper)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
        }

        public async Task<Card> AddCardAsync(AddCardDTO addCardDTO)
        {
            Card card = _mapper.Map<AddCardDTO, Card>(addCardDTO);

            await _genericRepository.CreateAsync(card);

            return card;
        }
    }
}
