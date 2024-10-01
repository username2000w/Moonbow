using Godot;
using System;

public partial class Shop : VBoxContainer {
	Button _shopButton;

	public override void _Ready() {
		this._shopButton = this.GetNode<Button>("../ShopButton");
	}

	public void OnShopButtonPressed() {
		this.Visible = !this.Visible;
		_shopButton.Text = this.Visible ? "Close Shop" : "Open Shop";
	}
}
