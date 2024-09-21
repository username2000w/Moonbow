using Godot;
using System;

public partial class MoonSprite : Sprite2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready() {
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta) {
		// The moon sprite will grow and shrink in size over time.
		float scale = 1.5f + 0.1f * (float) Math.Sin(Time.GetTicksMsec() / 1000.0);
		this.Scale = new Vector2(scale, scale);
	}
}
