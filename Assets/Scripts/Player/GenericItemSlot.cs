using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GenericItemSlot<T> where T : Item {

	[SerializeField]
	private T item;
	public T Item { get => item; }

	public AcceptableItems acceptableItems;

	public UIItemElement uiElement;


	public GenericItemSlot() { 
	}
	public GenericItemSlot(T item) {
		this.item = item;
	}

	public bool IsEmpty() {
		return item == null;
	}

	public bool SetItem(T item) {
		if (Accepts(item)) {
			this.item = item;
			UpdateUIRepresentation();
			return true;
		}
		return false;
	}

	public T ClearItem() {
		T i = item;
		item = null;
		return i;
	}

	public bool Accepts(Item item) {

		if (item is T) {
			Debug.Log(item.GetType().ToString() + " accepted");
			return true;
		}
		else {
			Debug.Log(item.GetType().ToString() + " rejected");
			return false;
		}

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

	private void UpdateUIRepresentation() {
		if (uiElement != null) {
			uiElement.UpdateValues();
		}
	}



	/* --===== Static =====-- */

	public static bool SwapItems(GenericItemSlot<Item> slot1, GenericItemSlot<Item> slot2) {
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