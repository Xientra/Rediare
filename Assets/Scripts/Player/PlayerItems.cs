using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerItems {

	private int inventorySize;

	private Item[] inventory;

	public PlayerItems(int inventorySize) {
		this.inventorySize = inventorySize;
		inventory = new Item[inventorySize];
	}

	public bool AddToInventory(Item item, int position) {
		if (inventory[position] == null) {
			inventory[position] = item;
			return true;
		}
		return false;
	}

	public Item RemoveFromInventory(int position) {
		Item item = inventory[position];
		inventory[position] = null;
		return item;
	}
}