using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using BlazorApp.Services.Constant;
using BlazorApp.Services.Interfaces;
using BlazorApp.Services.Models;
using Microsoft.Extensions.Logging;

namespace BlazorApp.Services.Implementations
{
    public class CardService : ServiceBase, ICardService
    {
        public CardService(ILogger<CardService> logger) : base(logger)
        {

        }

        public IEnumerable<Card> GetInitialCards()
        {
            Logger.LogInformation("Get Initial Card Arrangement...");
            foreach (var cardDto in ProcessGetAllCard())
                yield return cardDto;
        }
        public IEnumerable<Card> ShuffleCards()
        {
            Logger.LogInformation("Shuffle Cards...");
            var cards = GetInitialCards();
            return ProcessShuffle(cards.ToList());
        }
        private IEnumerable<Card> ProcessShuffle(List<Card> cards)
        {
            Logger.LogInformation("Process Shuffle...");
            Random random = new Random();
            for (int i = cards.Count() - 1; i > 0; --i)
            {
                int k = random.Next(i + 1);
                Card temp = cards[i];
                cards[i] = cards[k];
                cards[k] = temp;
            }
            return cards;
        }

        private IEnumerable<Card> ProcessGetAllCard()
        {
            Logger.LogInformation("Process Get all cards...");
            for (int i = 1; i <= 13; i++)
            {
                for (int c = 1; c <= 4; c++)
                    yield return new Card
                    { CardNumber = i, CardType = (CardTypeEnum)c};
            }
        }

    }
}
