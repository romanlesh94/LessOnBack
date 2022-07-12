using Entities;
using Entities.DTO;
using System.Threading.Tasks;

namespace Services
{
    public interface ICardService
    {
        Task<Card> AddCardAsync(AddCardDTO addCardDTO);
    }
}
