using System;
using Godot;

public class ItemList : VBoxContainer
{
	private static readonly PackedScene _packedScene = (PackedScene) ResourceLoader.Load("res://scenes/ItemList.tscn");
	private static ItemList Instance()
	{
		return (ItemList)_packedScene.Instance();
	}

	public Action OnAddItem { get; set; }

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	public static ItemList Initialize(string addButtonText)
	{
		ItemList instance = Instance();
		instance.GetNode<Button>("AddButton").Text = addButtonText;

		return instance;
	}

	private void _on_AddButton_pressed() => this.OnAddItem();

	public void RemoveItem(Node item)
	{
		this.GetNode<VBoxContainer>("Items").RemoveChild(item);
	}
}
