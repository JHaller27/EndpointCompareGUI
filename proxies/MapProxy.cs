using System.Collections.Generic;
using System.Linq;
using EndpointCompareGui.factories;
using Godot;

namespace EndpointCompareGui.proxies
{
    public class MapProxy<TK,TV> : ValueProxy<IDictionary<TK,TV>>
    {
        private ItemMap Node { get; }
        private IFactory<TK> KeyFactory { get; }
        private IFactory<TV> ValFactory { get; }

        private List<KeyValuePair<ValueProxy<TK>, ValueProxy<TV>>> ProxyList { get; } = new();

        public IDictionary<TK, TV> GetValues() => this.ProxyList.ToDictionary(
            kvp => kvp.Key.GetValue(),
            kvp => kvp.Value.GetValue()
        );


        public MapProxy(ItemMap control, IFactory<TK> keyFactory, IFactory<TV> valFactory) : base(control)
        {
            this.Node = control;
            this.KeyFactory = keyFactory;
            this.ValFactory = valFactory;

            this.Node.AddItemFunc = this.OnAddItem;
        }

        public override IDictionary<TK, TV> GetValue() => this.GetValues();

        private void OnAddItem()
        {
			HBoxContainer item = new();

			Button button = new()
			{
				Text = "-",
			};
			button.Connect("pressed", this.Node, nameof(RemoveItem), new(){item});

			item.AddChild(button);

			ValueProxy<TK> keyNode = this.KeyFactory.Create();
			SetNodeSizing(keyNode.Control, 1);
			item.AddChild(keyNode.Control);

			ValueProxy<TV> valNode = this.ValFactory.Create();
			SetNodeSizing(valNode.Control, 3);
			item.AddChild(valNode.Control);

			this.Node.GetNode<VBoxContainer>("Items").AddChild(item);

			this.ProxyList.Add(new(keyNode, valNode));
        }

		private static void SetNodeSizing(Control node, int stretchRatio)
		{
			node.SizeFlagsStretchRatio = stretchRatio;
			node.SizeFlagsHorizontal = (int) Control.SizeFlags.ExpandFill;
		}

		private void RemoveItem(Node item)
		{
			this.Node.GetNode<VBoxContainer>("Items").RemoveChild(item);
		}
    }
}
