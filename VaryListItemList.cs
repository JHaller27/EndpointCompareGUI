using Godot;

public class VaryListItemList : VBoxContainer
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{

	}

	private void _on_AddButton_pressed()
	{
		HBoxContainer uberContainer = new();
		uberContainer.AddChild(
		new LineEdit
			{
				PlaceholderText = "Key",
				SizeFlagsHorizontal = (int)SizeFlags.ExpandFill,
				SizeFlagsVertical = 0,
				SizeFlagsStretchRatio = 1,
			}
		);

		VBoxContainer valueContainer = new()
		{
			SizeFlagsHorizontal = (int)SizeFlags.ExpandFill,
			SizeFlagsStretchRatio = 3,
		};
		valueContainer = valueContainer.SafelySetScript("res://ValueItemList.cs");
		valueContainer.AddChild(
		new LineEdit
			{
				PlaceholderText = "Value",
			}
		);
		Button addValueButton = new()
		{
			Text = "+ Add Value",
		};
		valueContainer.AddChild(addValueButton);

		Button button = new()
		{
			Text = "-",
		};

		uberContainer.AddChild(valueContainer);
		uberContainer.AddChild(button);

		this.AddChild(uberContainer);

		button.Connect("pressed", this, nameof(_on_RemoveButton_pressed), new(){uberContainer});
	}

	private void _on_RemoveButton_pressed(Node node)
	{
		this.RemoveChild(node);
	}
}
