using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionBarPanel : MonoBehaviour {

	private PlayerAttackManager playerAttackManager;

	[SerializeField]
	public UIActionSlot[] actionSlots = new UIActionSlot[9];

	private void Start() {
		playerAttackManager = InGameMenu.instance.player.attackManager;
		SetActionSlotsIndexes();

		// add action bar update listener
		InGameMenuEventSystem.OnActionBarChanged += UpdateUIActionSlot;

		UpdateUI();
	}

	private void SetActionSlotsIndexes() {
		for (int i = 0; i < actionSlots.Length; i++) {
			actionSlots[i].Initialize(playerAttackManager, i);
		}
	}

	private void UpdateUI() {
		for (int i = 0; i < actionSlots.Length; i++) {
			actionSlots[i].UpdateValues();
		}
	}

	private void UpdateUIActionSlot(int index) {
		actionSlots[index].DisplayCooldown();
	}
}