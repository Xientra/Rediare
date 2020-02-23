using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Player : MonoBehaviour {

	public PlayerStats playerStats;

	public PlayerEquipment playerEquipment = new PlayerEquipment(10);

	private void Awake() {
		playerEquipment = new PlayerEquipment(10);
	}

	private void Start() {
		
	}

	private void Update() {
		if (Input.GetKeyDown(KeyCode.Escape)) {
			InGameMenu.instance.gameObject.SetActive(!InGameMenu.instance.gameObject.activeSelf);
		}
	}

	public void PickupItem(Item item) {
		playerEquipment.AddToInventory(item);
	}
}