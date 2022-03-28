using EndpointCompareGui.factories;

namespace EndpointCompareGui.proxies
{
	public class SingleItemProxy<T> : ValueProxy<T>
	{
		private SingleItem Node { get; }

		private ValueProxy<T> ItemProxy { get; }

		public SingleItemProxy(SingleItem control, IFactory<T> itemFactory) : base(control)
		{
			this.Node = control;
			this.ItemProxy = itemFactory.Create();

			this.Node.AddItem(this.ItemProxy.Control);
		}

		public override T GetValue() => this.ItemProxy.GetValue();
	}
}
