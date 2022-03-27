using EndpointCompareGui.proxies;
using Godot;

public class ItemMap : VBoxContainer
{
	private static readonly PackedScene _packedScene = (PackedScene) ResourceLoader.Load("res://scenes/ItemMap.tscn");
	private static ItemMap Instance()
	{
		return (ItemMap)_packedScene.Instance();
	}

	private IProxy KeyProxy { get; set; }
	private IProxy ValProxy { get; set; }

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	public static ItemMap Initialize(IProxy keyProxy, IProxy valProxy, string addButtonText)
	{
		ItemMap instance = Instance();

		instance.KeyProxy = keyProxy;
		instance.ValProxy = valProxy;

		instance.GetNode<Button>("AddButton").Text = addButtonText;

		return instance;
	}

	private void _on_AddButton_pressed()
	{
		HBoxContainer item = new();

		Button button = new()
		{
			Text = "-",
		};
		button.Connect("pressed", this, nameof(RemoveItem), new(){item});

		item.AddChild(button);

		Control keyNode = this.KeyProxy.Create();
		SetNodeSizing(keyNode, 1);
		item.AddChild(keyNode);

		Control valNode = this.ValProxy.Create();
		SetNodeSizing(valNode, 3);
		item.AddChild(valNode);

		this.GetNode<VBoxContainer>("Items").AddChild(item);
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
