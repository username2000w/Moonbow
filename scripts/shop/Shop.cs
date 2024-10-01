using Godot;
using System;

public partial class Shop : VBoxContainer {

	public void OnShopButtonPressed() {
		this.Visible = !this.Visible;
	}
}
