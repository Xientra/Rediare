using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIActionSlot : UISlot {

	public Image cooldownImage;

	private PlayerAttackManager playerAttackManager;
	private int actionBarIndex;

	private void Start() {
		UpdateValues();
	}

	public override void UpdateValues() {
		if (playerAttackManager != null && playerAttackManager.equipedSkills[actionBarIndex] != null) {
			image.sprite = playerAttackManager.equipedSkills[actionBarIndex].image;
			image.enabled = true;
		}
		else {
			image.enabled = false;
		}
	}

	public void DisplayCooldown() {
		DisplayCooldown(playerAttackManager.GetCooldown01(actionBarIndex));
	}
	private void DisplayCooldown(float cooldownPercent) {
		cooldownPercent = Mathf.Clamp01(cooldownPercent);
		Vector3 newScale = cooldownImage.GetComponent<RectTransform>().localScale;
		newScale = new Vector3(newScale.x, cooldownPercent, newScale.z);
		cooldownImage.GetComponent<RectTransform>().localScale = newScale;
	}

	public void Initialize(PlayerAttackManager playerAttackManager, int actionBarIndex) {
		this.playerAttackManager = playerAttackManager;
		this.actionBarIndex = actionBarIndex;
	}

	public override bool IsEmpty() {
		return playerAttackManager.equipedSkills[actionBarIndex] == null;
	}

	public void OnClick() {
		playerAttackManager.ActivateSkill(actionBarIndex);
	}

	public override void OnDrop() {
		Debug.LogWarning("OnDrop");

		if (DragAndDropManager.instance.dragging == true) {
			// checks what the dragOrigin is
			if (DragAndDropManager.instance.dragOrigin is UISkillSlot uiSkillSlotOrigin) {

				playerAttackManager.equipedSkills[actionBarIndex] = uiSkillSlotOrigin.Skill;
				UpdateValues();
			}
			else if (DragAndDropManager.instance.dragOrigin is UIActionSlot uiActionSlotOrigin) {

				playerAttackManager.SwapEquipedSkills(actionBarIndex, uiActionSlotOrigin.actionBarIndex); // <---------------------this does not work bc OnEmptyDrop is allways called

				UpdateValues();
				uiActionSlotOrigin.UpdateValues();
			}
			else if (DragAndDropManager.instance.dragOrigin is UIItemSlot) {
				// UIActionSlot does not support the equipping of items yet
			}
		}
	}

	/// <summary>
	/// Called by the DragAndDropManager whenever a drag from a Action Slot ends over nothing
	/// </summary>
	public void OnEmptyDrop() {
		playerAttackManager.equipedSkills[actionBarIndex] = null;
		UpdateValues();
	}

	public override void OnPointerEnter() {
		//referencedSlot.OnPointerEnter();
	}

	public override void OnPointerExit() {
		//referencedSlot.OnPointerExit();
	}
}