using System.Collections.Generic;
using EndpointCompareGui.proxies;

namespace EndpointCompareGui.factories
{
    public class ItemListFactory<T> : IFactory<IEnumerable<T>>
    {
        public ValueProxy<IEnumerable<T>> Create() => new ListProxy<T>(ItemList<T>.Initialize(this.ItemFactory, this.AddButtonText));

        private IFactory<T> ItemFactory { get; }
        private string AddButtonText { get; }

        public ItemListFactory(IFactory<T> factory, string addButtonText = "+ Add Item")
        {
            this.ItemFactory = factory;
            this.AddButtonText = addButtonText;
        }
    }
}
