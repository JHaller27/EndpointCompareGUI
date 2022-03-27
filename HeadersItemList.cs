using Godot;

public class HeadersItemList : VBoxContainer
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	private void _on_AddButton_pressed()
	{
		HBoxContainer container = new();
		container.AddChild(
		new LineEdit
			{
				PlaceholderText = "Key",
				SizeFlagsHorizontal = (int)SizeFlags.ExpandFill,
				SizeFlagsStretchRatio = 1,
			}
		);
		container.AddChild(
		new LineEdit
			{
				PlaceholderText = "Value",
				SizeFlagsHorizontal = (int)SizeFlags.ExpandFill,
				SizeFlagsStretchRatio = 3,
			}
		);
		Button button = new()
		{
			Text = "-",
		};
		container.AddChild(button);

		this.AddChild(container);

		button.Connect("pressed", this, nameof(_on_RemoveButton_pressed), new(){container});
	}

	private void _on_RemoveButton_pressed(Node node)
	{
		this.RemoveChild(node);
	}
}
