using Godot;
using System;

public partial class MediumStar : Control
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Position = new Vector2(GD.Randf() * GetViewportRect().Size.X, GD.Randf() * GetViewportRect().Size.Y);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
