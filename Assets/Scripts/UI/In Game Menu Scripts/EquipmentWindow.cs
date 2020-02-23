using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentWindow : MonoBehaviour {

	public UIItemElement headSlot;
	public UIItemElement chestSlot;
	public UIItemElement legsSlot;
	public UIItemElement weaponSlot;

	PlayerEquipment playerEquipment;

	private void Start() {
		playerEquipment = InGameMenu.instance.player.playerEquipment;

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