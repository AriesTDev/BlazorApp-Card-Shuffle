using BlazorApp.Services.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorApp.Services.Interfaces
{
    public interface ICardService
    {
        IEnumerable<Card> GetInitialCards();
        IEnumerable<Card> ShuffleCards();
    }
}
