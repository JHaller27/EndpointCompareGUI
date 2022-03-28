using EndpointCompareGui.factories;
using Godot;

public class SingleItem : VBoxContainer
{
	private static readonly PackedScene _packedScene = (PackedScene) ResourceLoader.Load("res://scenes/SingleItem.tscn");
	private static SingleItem Instance()
	{
		return (SingleItem)_packedScene.Instance();
	}

	public static SingleItem Initialize(IFactory itemFactory, string label)
	{
		SingleItem instance = Instance();

		instance.GetNode<Label>("Label").Text = label;
		instance.AddChild(itemFactory.Create().Control);

		return instance;
	}
}
