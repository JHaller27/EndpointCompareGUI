using Godot;
using System;
using System.Collections.Generic;

public class EnumValue : OptionButton
{
	private static readonly PackedScene _packedScene = (PackedScene) ResourceLoader.Load("res://scenes/EnumItem.tscn");
	private static EnumValue Instance()
	{
		return (EnumValue)_packedScene.Instance();
	}

	public static EnumValue Initialize(IEnumerable<string> values)
	{
		EnumValue instance = Instance();

		foreach (string value in values)
		{
			instance.AddItem(value);
		}

		return instance;
	}
}
