using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Player : MonoBehaviour {

	public PlayerStats playerStats;

	private void Update() {
		if (Input.GetKeyDown(KeyCode.Escape)) {
			InGameMenu.instance.gameObject.SetActive(!InGameMenu.instance.gameObject.activeSelf);
		}
	}
}