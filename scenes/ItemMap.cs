using System.Collections.Generic;
using System.Linq;
using EndpointCompareGui.factories;
using EndpointCompareGui.proxies;
using Godot;

public class ItemMap<TK,TV> : VBoxContainer
{
	private static readonly PackedScene _packedScene = (PackedScene) ResourceLoader.Load("res://scenes/ItemMap.tscn");
	private static ItemMap<TK,TV> Instance()
	{
		return (ItemMap<TK,TV>)_packedScene.Instance();
	}

	private IFactory<TK> KeyFactory { get; set; }
	private IFactory<TV> ValFactory { get; set; }

	private List<KeyValuePair<ValueProxy<TK>, ValueProxy<TV>>> ProxyList { get; } = new();

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	public static ItemMap<TK,TV> Initialize(IFactory<TK> keyFactory, IFactory<TV> valFactory, string addButtonText)
	{
		ItemMap<TK,TV> instance = Instance();

		instance.KeyFactory = keyFactory;
		instance.ValFactory = valFactory;

		instance.GetNode<Button>("AddButton").Text = addButtonText;

		return instance;
	}

	public IDictionary<TK, TV> GetValues() => this.ProxyList.ToDictionary(
		kvp => kvp.Key.GetValue(),
		kvp => kvp.Value.GetValue()
	);

	private void _on_AddButton_pressed()
	{
		HBoxContainer item = new();

		Button button = new()
		{
			Text = "-",
		};
		button.Connect("pressed", this, nameof(RemoveItem), new(){item});

		item.AddChild(button);

		ValueProxy<TK> keyNode = this.KeyFactory.Create();
		SetNodeSizing(keyNode.Control, 1);
		item.AddChild(keyNode.Control);

		ValueProxy<TV> valNode = this.ValFactory.Create();
		SetNodeSizing(valNode.Control, 3);
		item.AddChild(valNode.Control);

		this.GetNode<VBoxContainer>("Items").AddChild(item);

		this.ProxyList.Add(new(keyNode, valNode));
	}

	private static void SetNodeSizing(Control node, int stretchRatio)
	{
		node.SizeFlagsStretchRatio = stretchRatio;
		node.SizeFlagsHorizontal = (int) SizeFlags.ExpandFill;
	}

	private void RemoveItem(Node item)
	{
		this.GetNode<VBoxContainer>("Items").RemoveChild(item);
	}
}
