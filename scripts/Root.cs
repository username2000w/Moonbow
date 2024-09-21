using Godot;
using System;

public partial class Root : Control
{
	private Label stardustCounter;
	private int stardust = 0;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		stardustCounter = GetNode<Label>("StardustCounter");
		UpdateStardustCounter();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void AddStardust(int amount)
	{
		stardust += amount;
		UpdateStardustCounter();
	}

	public void UpdateStardustCounter()
	{
		stardustCounter.Text = "Stardust: " + stardust;
	}

	public void OnMoonButtonPressed() {
		AddStardust(1);
	}
}
