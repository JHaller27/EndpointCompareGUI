using System.Collections.Generic;
using EndpointCompareGui.proxies;

namespace EndpointCompareGui.factories
{
	public class ItemListFactory<T> : IFactory<List<T>>
	{
		public ValueProxy<List<T>> Create() => new ListProxy<T>(ItemList.Initialize(this.AddButtonText), this.ItemFactory);

		private IFactory<T> ItemFactory { get; }
		private string AddButtonText { get; }

		public ItemListFactory(IFactory<T> factory, string addButtonText = "+ Add Item")
		{
			this.ItemFactory = factory;
			this.AddButtonText = addButtonText;
		}
	}
}
