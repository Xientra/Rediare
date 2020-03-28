using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

[RequireComponent(typeof(EventTrigger))]
public class UIItemSlot : MonoBehaviour {

	public const string EMPTY_TEXT = "[Empty]";

	[Tooltip("Reference to the equipment slot, represented.")]
	[SerializeField]
	private ItemSlot itemSlot;
	public ItemSlot ItemSlot {
		get => itemSlot;
		set {
			itemSlot = value;
			UpdateValues();
		}
	}

	[Header("UI References:")]

	public TextMeshProUGUI text;
	public Image image;


	private void Start() {
		UpdateValues();

		InGameMenuEventSystem.OnItemChanged += UpdateValues;
	}

	private void UpdateValues(ItemSlot itemSlot) {
		if (itemSlot == this.itemSlot) {
			UpdateValues();
		}
	}

	public void UpdateValues() {
		if (itemSlot != null) {
			Item item = itemSlot.Item;
			if (item != null) {
				text.text = item.name;
				image.enabled = true;
				image.sprite = item.image;
			}
			else {
				text.text = EMPTY_TEXT;
				image.enabled = false;
				image.sprite = null;
			}
		}
	}

	public void OnValidate() {
		UpdateValues();
	}

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
			UIItemSlot itemElementOrigin = DragAndDropManager.instance.itemElementOrigin;

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

	#region hover effect for ItemInfoPanel
	public void OnPointerEnter() {
		if (itemSlot.IsEmpty() == false)
			InGameMenu.instance.itemInfoPanel.Enable(itemSlot.Item, image.GetComponent<RectTransform>().position);
	}

	public void OnPointerExit() {
		if (itemSlot.IsEmpty() == false)
			InGameMenu.instance.itemInfoPanel.Disable();
	}
	#endregion
}