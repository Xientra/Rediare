using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Events;
//using UnityEngine.EventSystems;

[System.Serializable]
public class PlayerEquipment {

	public readonly int inventorySize;
	//public int InventorySize { get => inventorySize; }

	#region head, chest, legs, weapon slots
	[SerializeField]
	private ItemSlot headSlot;
	public ItemSlot HeadSlot { get => headSlot; }

	[SerializeField]
	private ItemSlot chestSlot;
	public ItemSlot ChestSlot { get => chestSlot; }

	[SerializeField]
	private ItemSlot legsSlot;
	public ItemSlot LegsSlot { get => legsSlot; }

	[SerializeField]
	private ItemSlot weaponSlot;
	public ItemSlot WeaponSlot { get => weaponSlot; }
	#endregion

	[SerializeField]
	private ItemSlot[] inventory;

	public PlayerEquipment(int inventorySize) {
		this.inventorySize = inventorySize;

		// ------------------------------------------------------------------------------------------pls think of a way so that the editor is not ignored and overwritten

		headSlot = new ItemSlot();
		chestSlot = new ItemSlot();
		legsSlot = new ItemSlot();
		weaponSlot = new ItemSlot();

		inventory = new ItemSlot[inventorySize];

		for (int i = 0; i < inventory.Length; i++) {
			inventory[i] = new ItemSlot();
		}
	}

	private void SetSlot(Item item, int position) { 
	
	}

	public ItemSlot GetItemSlot(int i) {
		return inventory[i];
	}

	public ItemSlot GetFreeInventorySlot() {
		for (int i = 0; i < inventory.Length; i++) {
			if (inventory[i].IsEmpty()) {
				return inventory[i];
			}
		}
		return null;
	}

	/// <summary>
	/// Adds the item to the first empty slot in the inventroy.
	/// </summary>
	public bool AddToInventory(Item item) {
		ItemSlot slot = GetFreeInventorySlot();
		if (slot == null)
			return false;

		slot.SetItem(item);
		return true;
	}

	public Item RemoveFromInventory(int index) {
		return inventory[index].ClearItem();
	}

	// will probably change to just UpdateInventroySize(), getting the size from the playerStats
	public void SetInventorySize(int size) {
		if (size == inventory.Length) return;
		if (size < inventory.Length) {
			Debug.LogError("Making the Inventoy smaller is not (yet?) supported.");
			return;
		}

		ItemSlot[] newInventory = new ItemSlot[size];

		for (int i = 0; i < newInventory.Length; i++) {
			if (i < inventory.Length) {
				newInventory[i] = inventory[i];
			}
			else {
				newInventory[i] = new ItemSlot();
			}
		}

		inventory = newInventory;

		// update whole inventory
		InGameMenu.instance.inventoryWindow.UpdateUI();
	}
}