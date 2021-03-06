﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameMenu : MonoBehaviour {

    public static InGameMenu instance;

	public KeyCode openKey = KeyCode.Escape;

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

	public ActionBarPanel actionBarPanel;

	[Space(3)]

	public ItemInfoPanel itemInfoPanel;
	public SkillInfoPanel skillInfoPanel;

	[Header("DEBUG:")]
	public bool showStats = false;

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
		if (Input.GetKeyDown(openKey)) {
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

	private void OnGUI() {
		if (showStats == true) {
			string fps = "Fps: " + Time.frameCount / Time.time;
			string deltatime = "Delta Time: " + Time.deltaTime;


			GUI.Label(new Rect(3, 3, 500, 50), fps + " " + deltatime);
		}
	}
}