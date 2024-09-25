using Godot;
using System;

public partial class SmallStar : Star {
    public override void _Ready() {
		base._Ready();

		// change the star sprite to a medium star sprite
		GetChild<Sprite2D>(0).Texture = GD.Load<Texture2D>("res://assets/small_star.png");
	}
}