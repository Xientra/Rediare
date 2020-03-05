using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Player : MonoBehaviour {

	public PlayerStats baseStats;
	public ModifiableStats itemStats;
	public PlayerStats fullStats;

	public PlayerEquipment equipment = new PlayerEquipment(10);
	public GenericPlayerEquipment gEquipment = new GenericPlayerEquipment(10);

	private void Awake() {

		baseStats = PlayerStats.Default;
		itemStats = ModifiableStats.Zero;
		itemStats.SetBasedOnEquipment();
		fullStats = PlayerStats.CalculateFullStats(baseStats, itemStats);


		equipment.SetInventorySize(fullStats.InventorySize); // equipment is serialized, that means that it allready exists in the instector
		gEquipment.SetInventorySize(fullStats.InventorySize);

		gEquipment.WeaponSlot.Accepts(equipment.GetItemSlot(0).Item);
		gEquipment.WeaponSlot.Accepts(equipment.GetItemSlot(1).Item);

		gEquipment.GetItemSlot(0).Accepts(equipment.GetItemSlot(1).Item);
	}

	private void Start() {

	}

	private void Update() {
		if (Input.GetKeyDown(KeyCode.Escape)) {
			InGameMenu.instance.gameObject.SetActive(!InGameMenu.instance.gameObject.activeSelf);
		}
	}

	public void PickupItem(Item item) {
		equipment.AddToInventory(item);
	}
}