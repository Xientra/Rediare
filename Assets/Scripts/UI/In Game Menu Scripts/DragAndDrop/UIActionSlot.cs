using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIActionSlot : UISlot {

	private UISlot referenceSlot;

	public override bool IsEmpty() {
		return referenceSlot.IsEmpty();
	}

	public override void OnDrop() {
		if (DragAndDropManager.instance.dragging == true) {

			// checks what the dragOrigin is
			if (DragAndDropManager.instance.dragOrigin is UIItemSlot) {
				UIItemSlot uiItemSlotOrigin = (UIItemSlot)DragAndDropManager.instance.dragOrigin;

				// check if this itemSlot accepts the item from the other item slot
				if (itemSlot.Accepts(uiItemSlotOrigin.itemSlot.Item)) {

					//swaps items in this UIItemElements slot and the DragAndDrop origin UIItemElement
					ItemSlot.SwapItems(itemSlot, uiItemSlotOrigin.itemSlot);

					// update all changed elements
					uiItemSlotOrigin.UpdateValues();
					UpdateValues();
				}
			}
			else if (DragAndDropManager.instance.dragOrigin is UISkillSlot) {

			}
		}
	}

	public override void OnPointerEnter() {
		referenceSlot.OnPointerEnter();
	}

	public override void OnPointerExit() {
		referenceSlot.OnPointerExit();
	}

	public override void UpdateValues() {
		//throw new System.NotImplementedException();
	}

	//private Usable usable; ?

	private void Start() {
		UpdateValues();
	}


}