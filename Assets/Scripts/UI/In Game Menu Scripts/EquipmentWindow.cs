using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentWindow : MonoBehaviour {

	public UIItemSlot headSlot;
	public UIItemSlot chestSlot;
	public UIItemSlot legsSlot;
	public UIItemSlot weaponSlot;

	PlayerEquipment playerEquipment;

	private void Start() {
		playerEquipment = InGameMenu.instance.player.equipment;

		headSlot.ItemSlot = playerEquipment.HeadSlot;
		chestSlot.ItemSlot = playerEquipment.ChestSlot;
		legsSlot.ItemSlot = playerEquipment.LegsSlot;
		weaponSlot.ItemSlot = playerEquipment.WeaponSlot;
	}

	public void UpdateUI() {
		headSlot.UpdateValues();
		chestSlot.UpdateValues();
		legsSlot.UpdateValues();
		weaponSlot.UpdateValues();
	}
}