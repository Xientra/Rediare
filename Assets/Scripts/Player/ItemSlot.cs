using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class ItemSlot {

	[SerializeField]
	private Item item;
	public Item Item { get => item; }

	//public AcceptableItems acceptableItems;

	public UIItemElement uiElement;

	public enum SlotTypes { inventory, head, chest, legs, weapon }
	public SlotTypes slotType = SlotTypes.inventory;

	public ItemSlot() {
	}
	public ItemSlot(Item item) {
		this.item = item;
	}

	public bool IsEmpty() {
		return item == null;
	}

	public bool SetItem(Item item) {
		if (Accepts(item)) {
			this.item = item;
			UpdateUIRepresentation();
			return true;
		}
		return false;
	}

	public Item ClearItem() {
		Item i = item;
		item = null;
		return i;
	}

	public bool Accepts(Item item) {

		// if you wanna put nothing in here that still works (think of item swapping)
		if (item == null)
			return true;

		switch (slotType) {
			case SlotTypes.inventory:
				return true;

			case SlotTypes.head:
				return (item is HeadArmor);
			case SlotTypes.chest:
				return (item is ChestArmor);
			case SlotTypes.legs:
				return (item is LegArmor);

			case SlotTypes.weapon:
				return (item is Weapon);

			default:
				return false;
		}
	}
	/*
	public bool Accepts(Item item) {

		bool result = false;

		//check armor
		if ((item is HeadArmor && acceptableItems.head == true) ||
			(item is ChestArmor && acceptableItems.chest == true) ||
			(item is LegArmor && acceptableItems.leg == true)) {

			result = true;
		}

		if (item is Weapon && acceptableItems.weapon == true) {

			result = true;
		}

		return result;
	}
	*/

	private void UpdateUIRepresentation() {
		if (uiElement != null) {
			uiElement.UpdateValues();
		}
	}



	/* --===== Static =====-- */

	public static bool SwapItems(ItemSlot slot1, ItemSlot slot2) {
		Item i1 = slot1.Item;
		Item i2 = slot2.Item;

		if (slot1.Accepts(i2) && slot2.Accepts(i1)) {
			slot1.SetItem(i2);
			slot2.SetItem(i1);
			return true;
		}
		else {
			return false;
		}
	}
}

[System.Serializable]
public class AcceptableItems {

	[Header("Armor: ")]
	public bool head = true;
	public bool chest = true;
	public bool leg = true;

	[Header("Weapons: ")]
	public bool weapon = true;
	/*
	public bool sword = true;
	public bool bow = true;
	public bool staff = true;
	*/

	public AcceptableItems() {
		head = true;
		chest = true;
		leg = true;

		weapon = true;

		//swordSlot = true;
		//bowSlot = true;
		//staffSlot = true;
	}
}