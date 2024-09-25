using Godot;
using System;

public partial class Root : Control {
	private Label stardustCounter;
	private int stardust = 1000;

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
		string starType;
		if (stardust >= starPrice) {
			AddStardust(starPrice * -1);
			stars++;
			UpdateStarCounter();
			UpdateStarPrice();
			float rand = GD.Randf();

			if (rand <= 0.9f) {
				starType = "small_star";
			} else {
				starType = "medium_star";
			}
			AddChild(GD.Load<PackedScene>("res://scenes/stars/"+starType+".tscn").Instantiate());
		}
	}
}
