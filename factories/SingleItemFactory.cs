using EndpointCompareGui.proxies;

namespace EndpointCompareGui.factories
{
	public class SingleItemFactory<T> : IFactory<T>
	{
		public ValueProxy<T> Create() => new SingleItemProxy<T>(SingleItem.Initialize(this.LabelText), this.ItemFactory);

		private IFactory<T> ItemFactory { get; }
		private string LabelText { get; }

		public SingleItemFactory(IFactory<T> itemFactory, string labelText = "+ Add Item")
		{
			this.ItemFactory = itemFactory;
			this.LabelText = labelText;
		}
	}
}
