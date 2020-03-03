using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Player : MonoBehaviour {

	public PlayerStats baseStats;
	public Stats itemStats;
	public PlayerStats fullStats;

	public PlayerEquipment equipment = new PlayerEquipment(10);

	private void Awake() {
		equipment = new PlayerEquipment(10);
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