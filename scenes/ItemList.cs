using EndpointCompareGui.proxies;
using Godot;

public class ItemList : VBoxContainer
{
	private static readonly PackedScene _packedScene = (PackedScene) ResourceLoader.Load("res://scenes/ItemList.tscn");
	private static ItemList Instance()
	{
		return (ItemList)_packedScene.Instance();
	}

	private IProxy ItemProxy { get; set; }

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	public static ItemList Initialize(IProxy itemProxy, string addButtonText)
	{
		ItemList instance = Instance();

		instance.ItemProxy = itemProxy;
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
		item.AddChild(this.ItemProxy.Node);

		this.GetNode<VBoxContainer>("Items").AddChild(item);
	}

	private void RemoveItem(Node item)
	{
		this.GetNode<VBoxContainer>("Items").RemoveChild(item);
	}
}
