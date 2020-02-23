using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

[RequireComponent(typeof(EventTrigger))]
public class UIItemElement : MonoBehaviour {

	public const string EMPTY_TEXT = "[Empty]";

	[Tooltip("Reference to the equipment slot, represented.")]
	[SerializeField]
	private ItemSlot itemSlot;
	public ItemSlot ItemSlot {
		get => itemSlot;
		set {
			itemSlot = value;
			value.uiElement = this;
		}
	}

	[Header("UI References:")]

	public TextMeshProUGUI text;
	public Image image;


	private void Start() {
		UpdateValues();
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
			UIItemElement itemElementOrigin = DragAndDropManager.instance.itemElementOrigin;

			if (itemSlot.Accepts(itemElementOrigin.itemSlot.Item)) {

				//swaps items in this UIItemElements slot and the DragAndDrop origin UIItemElement
				ItemSlot.SwapItems(itemSlot, itemElementOrigin.itemSlot);

				// update all changed elements
				itemElementOrigin.UpdateValues();
				UpdateValues();
			}
		}
	}
}