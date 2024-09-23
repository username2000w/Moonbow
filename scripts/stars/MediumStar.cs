using Godot;
using System;

public partial class MediumStar : Control {
	private Timer timer;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready() {
		Position = new Vector2(GD.Randf() * GetViewportRect().Size.X, GD.Randf() * GetViewportRect().Size.Y);

		timer = GetNode<Timer>("Timer");
		timer.WaitTime = 5;

		timer.Start();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta) {

	}

	public void OnTimerTimeout() {
		if (GetParent() is Root root) {
			root.AddStardust(1);
		}
	}
}
