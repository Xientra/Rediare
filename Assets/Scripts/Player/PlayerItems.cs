using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Events;
//using UnityEngine.EventSystems;

[System.Serializable]
public class PlayerItems {

	private int inventorySize;

	[SerializeField]
	private Item headItem;
	[SerializeField]
	private Item chestItem;
	[SerializeField]
	private Item legsItem;
	[SerializeField]
	private Item weapon;

	[SerializeField]
	private Item[] inventory;

	public PlayerItems(int inventorySize) {
		this.inventorySize = inventorySize;
		inventory = new Item[inventorySize];
	}

	public Item HeadItem { get => headItem; set => headItem = value; }
	public Item ChestItem { get => chestItem; set => chestItem = value; }
	public Item LegsItem { get => legsItem; set => legsItem = value; }
	public Item Weapon { get => weapon; set => weapon = value; }

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