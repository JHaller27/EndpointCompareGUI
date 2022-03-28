using EndpointCompareGui.factories;
using Godot;

public class ItemList : VBoxContainer
{
	private static readonly PackedScene _packedScene = (PackedScene) ResourceLoader.Load("res://scenes/ItemList.tscn");
	private static ItemList Instance()
	{
		return (ItemList)_packedScene.Instance();
	}

	private IFactory ItemFactory { get; set; }

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	public static ItemList Initialize(IFactory itemFactory, string addButtonText)
	{
		ItemList instance = Instance();

		instance.ItemFactory = itemFactory;
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
		item.AddChild(this.ItemFactory.Create().Control);

		this.GetNode<VBoxContainer>("Items").AddChild(item);
	}

	private void RemoveItem(Node item)
	{
		this.GetNode<VBoxContainer>("Items").RemoveChild(item);
	}
}
