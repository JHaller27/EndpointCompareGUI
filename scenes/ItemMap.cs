using System;
using Godot;

public class ItemMap : VBoxContainer
{
	private static readonly PackedScene _packedScene = (PackedScene) ResourceLoader.Load("res://scenes/ItemMap.tscn");
	private static ItemMap Instance()
	{
		return (ItemMap)_packedScene.Instance();
	}

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	public Action AddItemFunc { get; set; }

	public static ItemMap Initialize(string addButtonText)
	{
		ItemMap instance = Instance();
		instance.GetNode<Button>("AddButton").Text = addButtonText;

		return instance;
	}

	private void _on_AddButton_pressed() => this.AddItemFunc();
}
