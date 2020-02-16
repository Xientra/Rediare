using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Player : MonoBehaviour {

	public PlayerStats playerStats;

	public PlayerItems playerItems = new PlayerItems(10);

	private void Start() {
		
	}

	private void Update() {
		if (Input.GetKeyDown(KeyCode.Escape)) {
			InGameMenu.instance.gameObject.SetActive(!InGameMenu.instance.gameObject.activeSelf);
		}
	}

	public void PickupItem(Item item) {
		int index = playerItems.GetFreeInventorySlot();
		if (index == -1)
			return;

		playerItems.AddToInventory(item, index);
	}
}