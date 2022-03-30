using Godot;

public class FileDialogScript : FileDialog
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	[Signal]
	public delegate void SetExport();

	[Signal]
	public delegate void SetImport();

	private void _on_ExportButton_pressed()
	{
		this.Mode = ModeEnum.OpenFile;
		this.WindowTitle = "Import Config";
		this.Popup_();
	}

	private void _on_ImportButton_pressed()
	{
		this.Mode = ModeEnum.SaveFile;
		this.WindowTitle = "Export Config";
		this.Popup_();
	}
}
