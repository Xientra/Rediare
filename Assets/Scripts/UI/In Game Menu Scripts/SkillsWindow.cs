using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillsWindow : MonoBehaviour {

	public GameObject skillSlotPrefab;

	public GameObject naturalSkillSlotsContent;
	public GameObject equipmentSkillSlotsContent;

	public UISkillSlot[] naturalSkillSlots;

	public UISkillSlot[] equipmentSkillSlots;

	private PlayerSkills playerSkills;

	private void Start() {
		playerSkills = InGameMenu.instance.player.skills;

		UpdateUI();
	}

	public void SetSkillSlots() {
		SetNaturalSkillSlots();
		SetEquipmentSkillSlots();
	}

	private void SetNaturalSkillSlots() {
		ClearNaturalSkillSlotsContent();
		foreach (Skill s in playerSkills.naturalSkills) {
			UISkillSlot newSlot = Instantiate(skillSlotPrefab, naturalSkillSlotsContent.transform).GetComponent<UISkillSlot>();
			newSlot.Skill = s;
		}
	}

	private void SetEquipmentSkillSlots() {
		ClearEquipmentSkillSlotsContent();
		foreach (Skill s in playerSkills.equipmentSkills) {
			UISkillSlot newSlot = Instantiate(skillSlotPrefab, equipmentSkillSlotsContent.transform).GetComponent<UISkillSlot>();
			newSlot.Skill = s;
		}
	}

	public void UpdateUI() {
		SetSkillSlots();
	}

	/// <summary>
	/// Destroys all children of the content transform.
	/// </summary>
	public void ClearItemElementObjects() {
		ClearNaturalSkillSlotsContent();
		ClearEquipmentSkillSlotsContent();
	}

	private void ClearNaturalSkillSlotsContent() {
		foreach (Transform t in naturalSkillSlotsContent.transform) {
			Destroy(t.gameObject);
		}
	}
	private void ClearEquipmentSkillSlotsContent() {
		foreach (Transform t in equipmentSkillSlotsContent.transform) {
			Destroy(t.gameObject);
		}
	}
}