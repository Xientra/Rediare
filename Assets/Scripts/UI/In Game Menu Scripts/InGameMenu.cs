using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameMenu : MonoBehaviour {

    public static InGameMenu instance;

	public Player player;

	public GameObject content;

	[Space(5)]

    public DragAndDropManager dragAndDropManager;

	[Space(5)]

	public EquipmentWindow equipmentWindow;
	public InventoryWindow inventoryWindow;
	public StatsWindow statsWindow;
	public SkillsWindow skillsWindow;

	[Space(3)]
	public ItemInfoPanel itemInfoPanel;

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
		UpdateUI();

		content.SetActive(false);
	}

	private void Update() {
		if (Input.GetKeyDown(KeyCode.Escape)) {
			InGameMenu.instance.content.SetActive(!InGameMenu.instance.content.activeSelf);
		}
	}

	public void Show() { 
		
	}

	public void Hide() { 
	
	}

	public void UpdateUI() {
		equipmentWindow.UpdateUI();
		inventoryWindow.UpdateUI();
		statsWindow.UpdateUI();
		skillsWindow.UpdateUI();
	}
}