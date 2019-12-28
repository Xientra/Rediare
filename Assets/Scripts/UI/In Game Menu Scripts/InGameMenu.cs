using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameMenu : MonoBehaviour {

    public static InGameMenu instance;

	public Player player;

	[Space(5)]

    public DragAndDropManager dragAndDropManager;

	[Space(5)]

	public EquipmentWindow equipmentWindow;
	public InventoryWindow inventoryWindow;
	//public StatsWindow statsWindow;

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
		UpdateWholeUI();

		gameObject.SetActive(false);
	}

	public void UpdateWholeUI() {

	}
}