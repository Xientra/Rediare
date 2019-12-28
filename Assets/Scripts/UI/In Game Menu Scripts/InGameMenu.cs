﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameMenu : MonoBehaviour {

    public static InGameMenu instance;

    [Space(5)]

    public DragAndDropManager dragAndDropManager;

	public EquipmentWindow equipmentWindow;

	public InventoryWindow inventoryWindow;

    private void Awake() {
        if (instance == null) {
            instance = this;
        }
        else {
            Destroy(this.gameObject);
            Debug.LogError("Destroyed " + gameObject.name + " because another instance of InGameMenu allready exists.");
        }
    }

	private void Start() {
		//gameObject.SetActive(false);
	}
}