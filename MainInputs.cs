using EndpointCompareGui.factories;
using Godot;

public class MainInputs : VBoxContainer
{
	private readonly IFactory _stringFactory = new PrimitiveFactory("String");
	private readonly IFactory _boolFactory = new PrimitiveFactory("Bool");

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		// Add Source + Target
		this.AddItem(_stringFactory, "Source");
		this.AddItem(_stringFactory, "Target");

		this.AddChild(new HSeparator());

		// Add Headers section
		this.AddItem(new ItemMapFactory(_stringFactory, _stringFactory), "Headers");

		// Add VaryList
		this.AddItem(_boolFactory, "Cartesian Product");
		this.AddItem(new ItemMapFactory(_stringFactory, new ItemListFactory(_stringFactory)), "VaryList");

		this.AddChild(new HSeparator());

		// Add misc config
		this.AddItem(_boolFactory, "Allow Case-sensitive");
	}

	private void AddItem(IFactory factory, string label)
	{
		this.AddChild(SingleItem.Initialize(factory, label));
	}
}
