using BlazorApp.Services.Constant;

namespace BlazorApp.Services.Extensions
{
    public static class CardTypeExtensions
    {
        public static string GetCardTypeName(this CardTypeEnum cardType)
        {
            switch (cardType)
            {
                case CardTypeEnum.Diamond: return "Diamond";
                case CardTypeEnum.Heart: return "Heart";
                case CardTypeEnum.Flower: return "Flower";
                case CardTypeEnum.Spade: return "Spade";
                default: return string.Empty;
            }
        }
    }
}
