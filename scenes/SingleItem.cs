using EndpointCompareGui.factories;
using EndpointCompareGui.proxies;
using Godot;

public class SingleItem<T> : VBoxContainer
{
	private static readonly PackedScene _packedScene = (PackedScene) ResourceLoader.Load("res://scenes/SingleItem.tscn");
	private static SingleItem<T> Instance()
	{
		return _packedScene.Instance<SingleItem<T>>();
	}

	private ValueProxy<T> Proxy { get; set; }

	public static SingleItem<T> Initialize(IFactory<T> itemFactory, string label)
	{
		SingleItem<T> instance = Instance();

		instance.Proxy = itemFactory.Create();

		instance.GetNode<Label>("Label").Text = label;
		instance.AddChild(instance.Proxy.Control);

		return instance;
	}

	public T GetValue() => this.Proxy.GetValue();
}
