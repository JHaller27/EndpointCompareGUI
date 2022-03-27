using EndpointCompareGui.proxies;
using Godot;

public class MainInputs : VBoxContainer
{
	private readonly IProxy _stringProxy = new PrimitiveProxy("String");
	private readonly IProxy _boolProxy = new PrimitiveProxy("Bool");

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		// Add Source + Target
		this.AddItem(_stringProxy, "Source");
		this.AddItem(_stringProxy, "Target");

		this.AddChild(new HSeparator());

		// Add Headers section
		this.AddItem(new ItemMapProxy(_stringProxy, _stringProxy), "Headers");

		// Add VaryList
		this.AddItem(_boolProxy, "Cartesian Product");
		this.AddItem(new ItemMapProxy(_stringProxy, new ItemListProxy(_stringProxy)), "VaryList");

		this.AddChild(new HSeparator());

		// Add misc config
		this.AddItem(_boolProxy, "Allow Case-sensitive");
	}

	private void AddItem(IProxy proxy, string label)
	{
		this.AddChild(SingleItem.Initialize(proxy, label));
	}
}
