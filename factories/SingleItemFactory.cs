using EndpointCompareGui.proxies;

namespace EndpointCompareGui.factories
{
    public class SingleItemFactory : IFactory
    {
        public ValueProxy Create() => new(SingleItem.Initialize(this.ItemFactory, this.LabelText));

        private IFactory ItemFactory { get; }
        private string LabelText { get; }

        public SingleItemFactory(IFactory itemFactory, string labelText = "+ Add Item")
        {
            this.ItemFactory = itemFactory;
            this.LabelText = labelText;
        }
    }
}
