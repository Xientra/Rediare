using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

[RequireComponent(typeof(EventTrigger))]
public class UISkillSlot : MonoBehaviour {

	[Header("UI References:")]
	public TextMeshProUGUI text;
	public Image image;

	public const string EMPTY_TEXT = "[Empty]";

	[Tooltip("Reference to the equipment slot, represented.")]
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

	public void UpdateValues() {
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

	public void OnValidate() {
		UpdateValues();
	}

	/* later
	#region Drag and Drop 
	public void OnDragTrigger() {
		DragAndDropManager.instance.OnDrag();
	}

	public void OnBeginDragTrigger() {
		DragAndDropManager.instance.OnBeginDrag(this.gameObject);
	}

	public void OnEndDragTrigger() {
		DragAndDropManager.instance.OnEndDrag();
	}

	// is called whenever the mouse button is released over the game object (i think)
	public void OnDrop() {
		if (DragAndDropManager.instance.dragging == true) {
			UISkillSlot itemElementOrigin = DragAndDropManager.instance.itemElementOrigin;

			//Debug.Log(itemSlot.Accepts(itemElementOrigin.itemSlot.Item));

			if (itemSlot.Accepts(itemElementOrigin.itemSlot.Item)) {

				//swaps items in this UIItemElements slot and the DragAndDrop origin UIItemElement
				ItemSlot.SwapItems(itemSlot, itemElementOrigin.itemSlot);

				// update all changed elements
				itemElementOrigin.UpdateValues();
				UpdateValues();
			}
		}
	}
	#endregion

	#region hover effect for SkillInfoPanel
	public void OnPointerEnter() {
		Debug.LogError("OnPointerEnter for UISkillSlot has not been implemented yet.");
	}

	public void OnPointerExit() {
		Debug.LogError("OnPointerExit for UISkillSlot has not been implemented yet.");
	}
	#endregion
	*/
}