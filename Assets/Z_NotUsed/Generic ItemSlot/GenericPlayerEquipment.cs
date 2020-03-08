using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Events;
//using UnityEngine.EventSystems;

[System.Serializable]
public class GenericPlayerEquipment {

	public readonly int inventorySize;
	//public int InventorySize { get => inventorySize; }

	#region head, chest, legs, weapon slots
	[SerializeField]
	private GenericItemSlot<HeadArmor> headSlot;
	public GenericItemSlot<HeadArmor> HeadSlot { get => headSlot; }

	[SerializeField]
	private GenericItemSlot<ChestArmor> chestSlot;
	public GenericItemSlot<ChestArmor> ChestSlot { get => chestSlot; }

	[SerializeField]
	private GenericItemSlot<LegArmor> legsSlot;
	public GenericItemSlot<LegArmor> LegsSlot { get => legsSlot; }

	[SerializeField]
	private GenericItemSlot<Weapon> weaponSlot;
	public GenericItemSlot<Weapon> WeaponSlot { get => weaponSlot; }
	#endregion

	[SerializeField]
	private GenericItemSlot<Item>[] inventory;

	public GenericPlayerEquipment(int inventorySize) {
		this.inventorySize = inventorySize;

		// -------------------------------- pls think of a way so that the editor is not ignored and overwritten (i don't think there is a way, i'll just have to save them myself PepeHands)

		
		headSlot = new GenericItemSlot<HeadArmor>();
		chestSlot = new GenericItemSlot<ChestArmor>();
		legsSlot = new GenericItemSlot<LegArmor>();
		weaponSlot = new GenericItemSlot<Weapon>();

		inventory = new GenericItemSlot<Item>[inventorySize];

		for (int i = 0; i < inventory.Length; i++) {
			inventory[i] = new GenericItemSlot<Item>();
		}
		
	}

	private void SetSlot(Item item, int position) { 
	
	}

	public GenericItemSlot<Item> GetItemSlot(int i) {
		return inventory[i];
	}

	public GenericItemSlot<Item> GetFreeInventorySlot() {
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
		GenericItemSlot<Item> slot = GetFreeInventorySlot();
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

		GenericItemSlot<Item>[] newInventory = new GenericItemSlot<Item>[size];

		for (int i = 0; i < newInventory.Length; i++) {
			if (i < inventory.Length) {
				newInventory[i] = inventory[i];
			}
			else {
				newInventory[i] = new GenericItemSlot<Item>();
			}
		}

		inventory = newInventory;

		// update whole inventory
		InGameMenu.instance.inventoryWindow.UpdateUI();
	}
}