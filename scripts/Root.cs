using Godot;
using System;

public partial class Root : Control
{
	private Label stardustCounter;
	private int stardust = 0;

	private Label starCounter;
	private int stars = 0;
	private Button starBuyButton;
	private int starPrice = 10;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready() {
		stardustCounter = GetNode<Label>("Resources/StardustCounter");
		UpdateStardustCounter();

		starCounter = GetNode<Label>("Shop/Star/StarCounter");
		UpdateStarCounter();
		starBuyButton = GetNode<Button>("Shop/Star/StarBuyButton");
		UpdateStarPrice();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta) {
	}

	public void AddStardust(int amount) {
		stardust += amount;
		UpdateStardustCounter();
	}

	public void UpdateStardustCounter() {
		stardustCounter.Text = "Stardust: " + stardust;
	}

	public void UpdateStarCounter() {
        string starPlural = stars == 1 ? "" : "s";
		starCounter.Text = stars + " Star" + starPlural;
	}

	public void UpdateStarPrice() {
		// The base price is 10 stardust but increases by 10% for each star bought.
		starPrice += (int) (10 * stars * 0.1f);
		starBuyButton.Text = "Buy Star (" + starPrice + " Stardust)";
	}

	public void OnMoonButtonPressed() {
		AddStardust(1);
	}

	public void OnStarBuyButtonPressed() {
		if (stardust >= starPrice) {
			AddStardust(starPrice * -1);
			stars++;
			UpdateStarCounter();
			UpdateStarPrice();

			// Add a new star sprite to the scene.
			GetTree().Root.AddChild(GD.Load<PackedScene>("res://scenes/stars/medium_star.tscn").Instantiate());

			// Sprite2D star = new Sprite2D();
			// GetTree().Root.AddChild(star);
			// star.Texture = GD.Load<Texture2D>("res://assets/medium_star.png");
			// star.Position = new Vector2(100 + 50 * stars, 100);
		}
	}
}
