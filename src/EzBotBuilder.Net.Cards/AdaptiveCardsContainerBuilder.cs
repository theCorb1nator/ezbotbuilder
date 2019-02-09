using AdaptiveCards;
using System.Collections.Generic;
using System.Linq;
namespace EzBotBuilder.Cards
{
    public class AdaptiveCardsContainerBuilder
    {
        private AdaptiveCards.Container _container;
        private readonly IDictionary<string, FactSet> _factSets;
        public AdaptiveCardsContainerBuilder()
        {
            _container = new AdaptiveCards.Container();
            _factSets = new Dictionary<string, FactSet>();
        }
        public AdaptiveCards.Container Build()
        {
            foreach (var factSet in _factSets)
            {
                _container.Items.Add(factSet.Value);
            }
            return _container;
        }

        public AdaptiveCardsContainerBuilder AddContainer(Container container)
        {
            _container.Items.Add(container);
            return this;
        }

        public AdaptiveCardsContainerBuilder AddTextBlock(string text, TextWeight weight, TextSize size)
        {
            TextBlock textBlock = new TextBlock()
            {
                Text = text,
                Weight = weight,
                Size = size
            };
            _container.Items.Add(textBlock);
            return this;
        }
        public AdaptiveCardsContainerBuilder AddImage(string url, ImageSize size, ImageStyle style)
        {
            Image img = new Image()
            {
                Url = url,
                Style = style,
                Size = size

            };
            _container.Items.Add(img);
            return this;
        }

        public AdaptiveCardsContainerBuilder AddFactSet(string factSetId, List<Fact> facts) 
        {
            FactSet fs = new FactSet() { Facts = facts };
            _container.Items.Add(fs);
            return this;
        }
    }
}
