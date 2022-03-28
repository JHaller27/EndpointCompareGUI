using Godot;

namespace EndpointCompareGui.proxies
{
	public abstract class ValueProxy<T>
	{
		public Control Control { get; }

		public ValueProxy(Control control)
		{
			this.Control = control;
		}

		public abstract T GetValue();
	}
}
