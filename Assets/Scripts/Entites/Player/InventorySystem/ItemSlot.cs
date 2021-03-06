﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// ItemSlot is a wrapper for the Item class.
/// It's meant to be usable for both inventory slots and Equipment slots by beeing able to set what item types to accept.
/// </summary>
[Serializable]
public class ItemSlot {

	[SerializeField]
	private Item item;
	public Item Item { get => item; }

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
			InGameMenuEventSystem.ItemChanged(this);
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