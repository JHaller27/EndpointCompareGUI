using EndpointCompareGui.proxies;

namespace EndpointCompareGui.factories
{
    public class ItemListFactory : IFactory
    {
        public ValueProxy Create() => new(ItemList.Initialize(this.ItemFactory, this.AddButtonText));

        private IFactory ItemFactory { get; }
        private string AddButtonText { get; }

        public ItemListFactory(IFactory factory, string addButtonText = "+ Add Item")
        {
            this.ItemFactory = factory;
            this.AddButtonText = addButtonText;
        }
    }
}
