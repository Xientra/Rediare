using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Player : MonoBehaviour {

	public PlayerStats baseStats;
	public ModifiableStats itemStats;
	public PlayerStats fullStats;

	public PlayerEquipment equipment = new PlayerEquipment(10);
	public GenericPlayerEquipment genericEquipment = new GenericPlayerEquipment(10);


	private void Awake() {

		baseStats = PlayerStats.Default;
		itemStats = ModifiableStats.Zero;
		itemStats.SetBasedOnEquipment(equipment);
		fullStats = PlayerStats.CalculateFullStats(baseStats, itemStats);

		// equipment is serialized, that means that it allready exists in the instector
		equipment.SetInventorySize(fullStats.InventorySize);
	}

	private void Start() {

	}

	private void Update() {
		if (Input.GetKeyDown(KeyCode.Escape)) {
			InGameMenu.instance.gameObject.SetActive(!InGameMenu.instance.gameObject.activeSelf);
		}


		itemStats.SetBasedOnEquipment(equipment); //----
		fullStats = PlayerStats.CalculateFullStats(baseStats, itemStats); //--------------------------- yeah no
	}

	public void PickupItem(Item item) {
		equipment.AddToInventory(item);
	}
}