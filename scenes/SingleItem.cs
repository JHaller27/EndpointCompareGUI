using EndpointCompareGui.proxies;
using Godot;

public class SingleItem : VBoxContainer
{
	private static readonly PackedScene _packedScene = (PackedScene) ResourceLoader.Load("res://scenes/SingleItem.tscn");
	private static SingleItem Instance()
	{
		return (SingleItem)_packedScene.Instance();
	}

	public static SingleItem Initialize(IProxy itemProxy, string label)
	{
		SingleItem instance = Instance();

		instance.GetNode<Label>("Label").Text = label;
		instance.AddChild(itemProxy.Node);

		return instance;
	}
}
