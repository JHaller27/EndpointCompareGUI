using System.Collections.Generic;
using System.Linq;
using EndpointCompareGui.factories;
using EndpointCompareGui.proxies;
using Godot;

public class ItemList<T> : VBoxContainer
{
	private static readonly PackedScene _packedScene = (PackedScene) ResourceLoader.Load("res://scenes/ItemList.tscn");
	private static ItemList<T> Instance()
	{
		return (ItemList<T>)_packedScene.Instance();
	}

	private IFactory<T> ItemFactory { get; set; }
	private List<ValueProxy<T>> ChildProxies { get; } = new();

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	public static ItemList<T> Initialize(IFactory<T> itemFactory, string addButtonText)
	{
		ItemList<T> instance = Instance();

		instance.ItemFactory = itemFactory;
		instance.GetNode<Button>("AddButton").Text = addButtonText;

		return instance;
	}

	public IEnumerable<T> GetChildValues() => this.ChildProxies.Select(p => p.GetValue());

	private void _on_AddButton_pressed()
	{
		HBoxContainer item = new();

		Button button = new()
		{
			Text = "-",
		};
		button.Connect("pressed", this, nameof(RemoveItem), new(){item});

		ValueProxy<T> childProxy = this.ItemFactory.Create();
		item.AddChild(button);
		item.AddChild(childProxy.Control);

		this.GetNode<VBoxContainer>("Items").AddChild(item);

		this.ChildProxies.Add(childProxy);
	}

	private void RemoveItem(Node item)
	{
		this.GetNode<VBoxContainer>("Items").RemoveChild(item);
	}
}
