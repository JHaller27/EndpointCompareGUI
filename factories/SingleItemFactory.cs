using EndpointCompareGui.proxies;

namespace EndpointCompareGui.factories
{
    public class SingleItemFactory<T> : IFactory<T>
    {
        public ValueProxy<T> Create() => new SingleItemProxy<T>(SingleItem<T>.Initialize(this.ItemFactory, this.LabelText));

        private IFactory<T> ItemFactory { get; }
        private string LabelText { get; }

        public SingleItemFactory(IFactory<T> itemFactory, string labelText = "+ Add Item")
        {
            this.ItemFactory = itemFactory;
            this.LabelText = labelText;
        }
    }
}
