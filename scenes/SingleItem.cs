using EndpointCompareGui.proxies;
using Godot;

public class SingleItem : VBoxContainer
{
	private static readonly PackedScene _packedScene = (PackedScene) ResourceLoader.Load("res://scenes/SingleItem.tscn");
	private static SingleItem Instance()
	{
		return _packedScene.Instance<SingleItem>();
	}

	public static SingleItem Initialize(string label)
	{
		SingleItem instance = Instance();
		instance.GetNode<Label>("Label").Text = label;

		return instance;
	}

	public void AddItem(Control subItem)
	{
		this.AddChild(subItem);
	}
}
