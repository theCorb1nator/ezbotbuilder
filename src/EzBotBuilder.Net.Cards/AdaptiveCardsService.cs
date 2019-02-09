using AdaptiveCards;
using Microsoft.Bot.Schema;
using System;
using System.Collections.Generic;

namespace EzBotBuilder.Cards
{
    public class AdaptiveCardsService
    {
        public Attachment GetAdaptiveCard(string tag)
        {
            return new Attachment()
            {
                ContentType = AdaptiveCard.ContentType,
                Content = GetCard(tag)
            };
        }
        private AdaptiveCard GetCard(string tag)
        {
            AdaptiveCard card = new AdaptiveCard()
            {
                Body = new List<CardElement>()
                {
                 new AdaptiveCardsContainerBuilder()
                .AddTextBlock("Current Versions", TextWeight.Bolder, TextSize.Medium)
                .AddFactSet("fs2", new List<AdaptiveCards.Fact>()
                {
                    new AdaptiveCards.Fact() {Title = "new fact",Value= "this is a new fact"},
                    new AdaptiveCards.Fact() {Title = "new new fact",Value = "this is a new new fact"}
                })
                .AddTextBlock("This is another text block", TextWeight.Normal, TextSize.ExtraLarge)
                .Build()
                }
            };
            return card;
        }
    }
}