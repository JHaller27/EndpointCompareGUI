using EndpointCompareGui.factories;
using Godot;

public class ItemMap : VBoxContainer
{
	private static readonly PackedScene _packedScene = (PackedScene) ResourceLoader.Load("res://scenes/ItemMap.tscn");
	private static ItemMap Instance()
	{
		return (ItemMap)_packedScene.Instance();
	}

	private IFactory KeyFactory { get; set; }
	private IFactory ValFactory { get; set; }

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	public static ItemMap Initialize(IFactory keyFactory, IFactory valFactory, string addButtonText)
	{
		ItemMap instance = Instance();

		instance.KeyFactory = keyFactory;
		instance.ValFactory = valFactory;

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

		Control keyNode = this.KeyFactory.Create();
		SetNodeSizing(keyNode, 1);
		item.AddChild(keyNode);

		Control valNode = this.ValFactory.Create();
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
