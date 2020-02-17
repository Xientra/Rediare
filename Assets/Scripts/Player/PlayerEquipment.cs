using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Events;
//using UnityEngine.EventSystems;

[System.Serializable]
public class PlayerEquipment {

	public readonly int inventorySize;
	//public int InventorySize { get => inventorySize; }

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

	public PlayerEquipment(int inventorySize) {
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
			InGameMenu.instance.inventoryWindow.UpdateUI(); // <----------------------------------------------------------------------------- pls think of a better interconnection
			return true;
		}
		return false;
	}

	public Item GetItem(int position) {
		return inventory[position];
	}

	public Item RemoveFromInventory(int position) {
		Item item = inventory[position];
		inventory[position] = null;
		return item;
	}

	public int GetFreeInventorySlot() {
		for (int i = 0; i < inventory.Length; i++) {
			if (inventory[i] == null) {
				return i;
			}
		}
		return -1;
	}
}