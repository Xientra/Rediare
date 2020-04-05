using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

[RequireComponent(typeof(EventTrigger))]
public class UISkillSlot : UISlot {

	[Tooltip("The skill this UISlot represents.")]
	[SerializeField]
	private Skill skill;
	
	public Skill Skill {
		get => skill;
		set {
			skill = value;
			UpdateValues();
		}
	}
	

	private void Start() {
		UpdateValues();

		InGameMenuEventSystem.OnSkillsChanged += UpdateValues;
	}

	public override void UpdateValues() {
		if (skill != null) {
			text.text = skill.name;
			image.enabled = true;
			image.sprite = skill.image;
		}
		else {
			text.text = EMPTY_TEXT;
			image.enabled = false;
			image.sprite = null;
		}
	}

	public override bool IsEmpty() {
		return false; // can never be emty
	}

	public override void OnDrop() {
		if (DragAndDropManager.instance.dragging == true) {

			// :=:=:=:=:=:=:=:=:=:=:=:=:=:=:=:=:=:=:=:=:=:=:=:=:=: //
			// UISKillSlot wont accept any drag and drop, for now  //
			// :=:=:=:=:=:=:=:=:=:=:=:=:=:=:=:=:=:=:=:=:=:=:=:=:=: //

		}
	}

	#region hover effect for SkillInfoPanel
	public override void OnPointerEnter() {
		Debug.LogWarning("OnPointerEnter for UISkillSlot has not been implemented yet.");
	}

	public override void OnPointerExit() {
		Debug.LogWarning("OnPointerExit for UISkillSlot has not been implemented yet.");
	}
	#endregion
}