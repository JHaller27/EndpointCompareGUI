using System.Collections.Generic;
using EndpointCompareGui.factories;
using EndpointCompareGui.factories.primitives;
using EndpointCompareGui.proxies;
using Godot;

public class MainInputs : VBoxContainer
{
	private readonly StringFactory _stringFactory = new();
	private readonly BoolFactory _boolFactory = new();

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		// Add Source + Target
		this.AddItem(_stringFactory, "Source");
		this.AddItem(_stringFactory, "Target");

		this.AddChild(new HSeparator());

		// Add Headers section
		this.AddItem(new ItemMapFactory<string, string>(_stringFactory, _stringFactory), "Headers");

		// Add VaryList
		this.AddItem(_boolFactory, "Cartesian Product");
		this.AddItem(new ItemMapFactory<string, IEnumerable<string>>(_stringFactory, new ItemListFactory<string>(_stringFactory)), "VaryList");

		this.AddChild(new HSeparator());

		// Add misc config
		this.AddItem(_boolFactory, "Allow Case-sensitive");
	}

	private ValueProxy<T> AddItem<T>(IFactory<T> factory, string label)
	{
		ValueProxy<T> itemProxy = new SingleItemFactory<T>(factory, label).Create();
		this.AddChild(itemProxy.Control);

		return itemProxy;
	}
}
