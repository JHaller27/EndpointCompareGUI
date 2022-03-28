using System.Collections.Generic;
using EndpointCompareGui.proxies;

namespace EndpointCompareGui.factories
{
	public class EnumFactory : IFactory<string>
	{
		public ValueProxy<string> Create() => new EnumProxy(EnumValue.Initialize(this.Items));
		private IEnumerable<string> Items { get; }

		public EnumFactory(IEnumerable<string> items)
		{
			this.Items = items;
		}
	}
}
