using System;
using System.Collections.Generic;
using EndpointCompareGui.factories;
using EndpointCompareGui.factories.primitives;
using EndpointCompareGui.proxies;
using Godot;
using Newtonsoft.Json;
using File = System.IO.File;

public class MainInputs : VBoxContainer
{
	private readonly StringFactory _stringFactory = new();
	private readonly BoolFactory _boolFactory = new();

	private List<Action<EndpointCompareConfig>> ExportActions = new();
	private List<Action<EndpointCompareConfig>> ImportActions = new();
	
	private bool ExportMode { get; set; }

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		// Add Source + Target
		this.AddItem(_stringFactory, "Source",
			(val, config) => config.Source = val,
			config => config.Source
		);
		this.AddItem(_stringFactory, "Target",
			(val, config) => config.Target = val,
			config => config.Target
		);

		this.AddChild(new HSeparator());

		// Add Headers section
		this.AddItem(new ItemMapFactory<string, string>(_stringFactory, _stringFactory), "Headers",
			(val, config) => config.Headers = val,
			config => config.Headers
		);

		// Add VaryList
		this.AddItem(_boolFactory, "Cartesian Product",
			(val, config) => config.CartesianProduct = val,
			config => config.CartesianProduct
		);
		this.AddItem(new ItemMapFactory<string, List<string>>(_stringFactory, new ItemListFactory<string>(_stringFactory)), "VaryList",
			(val, config) => config.VaryList = val,
			config => config.VaryList
		);

		this.AddChild(new HSeparator());

		// Add misc config
		this.AddItem(_boolFactory, "Allow Case-sensitive",
			(val, config) => config.AllowCaseSensitive = val,
			config => config.AllowCaseSensitive
		);
	}

	private void AddItem<T>(IFactory<T> factory, string label,
		Action<T, EndpointCompareConfig> exportFunc,
		Func<EndpointCompareConfig, T> importFunc
	)
	{
		ValueProxy<T> itemProxy = new SingleItemFactory<T>(factory, label).Create();
		this.AddChild(itemProxy.Control);

		this.ExportActions.Add(config => exportFunc(itemProxy.GetValue(), config));
		this.ImportActions.Add(config => itemProxy.SetValue(importFunc(config)));
	}

	private void _on_FileDialog_file_selected(string path)
	{
		if (this.ExportMode)
		{
			this.Export(path);
		}
		else
		{
			this.Import(path);
		}
	}

	private void _on_ExportButton_pressed()
	{
		this.ExportMode = true;
	}

	private void _on_ImportButton_pressed()
	{
		this.ExportMode = false;
	}

	private void Export(string path)
	{
		EndpointCompareConfig config = new();
		foreach (Action<EndpointCompareConfig> exportAction in this.ExportActions)
		{
			exportAction(config);
		}

		string jsonString = JsonConvert.SerializeObject(config);
		File.WriteAllText(path, jsonString);
	}

	private void Import(string path)
	{
		string jsonString = File.ReadAllText(path);
		EndpointCompareConfig config = JsonConvert.DeserializeObject<EndpointCompareConfig>(jsonString);

		foreach (Action<EndpointCompareConfig> importAction in this.ImportActions)
		{
			importAction(config);
		}
	}

	private class EndpointCompareConfig
	{
		public string Source { get; set; }
		public string Target { get; set; }
		public Dictionary<string, string> Headers { get; set; }
		public Dictionary<string, List<string>> VaryList { get; set; }
		public bool CartesianProduct { get; set; }
		public bool AllowCaseSensitive { get; set; }
	}
}

