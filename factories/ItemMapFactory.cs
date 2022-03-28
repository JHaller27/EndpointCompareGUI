using System.Collections.Generic;
using EndpointCompareGui.proxies;

namespace EndpointCompareGui.factories
{
	public class ItemMapFactory<TK,TV> : IFactory<Dictionary<TK,TV>>
	{
		public ValueProxy<Dictionary<TK,TV>> Create() => new MapProxy<TK, TV>(ItemMap.Initialize(this.AddButtonText), this.KeyFactory, this.ValFactory);

		private IFactory<TK> KeyFactory { get; }
		private IFactory<TV> ValFactory { get; }
		private string AddButtonText { get; }

		public ItemMapFactory(IFactory<TK> keyFactory, IFactory<TV> valFactory, string addButtonText = "+ Add Item")
		{
			this.KeyFactory = keyFactory;
			this.ValFactory = valFactory;
			this.AddButtonText = addButtonText;
		}
	}
}
