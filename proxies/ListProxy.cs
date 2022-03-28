using System.Collections.Generic;
using System.Linq;
using EndpointCompareGui.factories;
using Godot;

namespace EndpointCompareGui.proxies
{
	public class ListProxy<T> : ValueProxy<List<T>>
	{
		private ItemList Node { get; }
		public ListProxy(ItemList control, IFactory<T> itemFactory) : base(control)
		{
			this.Node = control;
			this.Node.OnAddItem = this.AddChild;

			this.ItemFactory = itemFactory;
		}

		public override List<T> GetValue() => this.ChildProxies.Select(p => p.GetValue()).ToList();

		private IFactory<T> ItemFactory { get; }
		private List<ValueProxy<T>> ChildProxies { get; } = new();

		private void AddChild()
		{
			HBoxContainer item = new();

			Button button = new()
			{
				Text = "-",
			};
			button.Connect("pressed", this.Node, nameof(ItemList.RemoveItem), new(){item});

			ValueProxy<T> childProxy = this.ItemFactory.Create();
			item.AddChild(button);
			item.AddChild(childProxy.Control);

			this.Node.GetNode<VBoxContainer>("Items").AddChild(item);

			this.ChildProxies.Add(childProxy);
		}
	}
}
