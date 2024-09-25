using Godot;
using System;

public partial class MediumStar : Control {
	private Timer timer;

	private bool mouseOver = false;
	private bool ok = false;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready() {
		Position = new Vector2(GD.Randf() * GetViewportRect().Size.X, GD.Randf() * GetViewportRect().Size.Y);

		timer = GetNode<Timer>("Timer");
		timer.WaitTime = 5;

		timer.Start();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta) {
		if (mouseOver && Input.IsActionJustPressed("click")) {
			if (ok) {
				ok = false;
			} else {
				ok = true;
			}
		}
		if (ok) Position = GetGlobalMousePosition() - GetChild<Sprite2D>(0).Texture.GetSize() / 2;
	}

	public void OnTimerTimeout() {
		if (GetParent() is Root root) {
			root.AddStardust(1);
		}
	}

	public void OnMouseEntered() {
		mouseOver = true;
	}

	public void OnMouseExited() {
		mouseOver = false;
	}
}
