using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryWindow : MonoBehaviour {

	public GameObject itemElementPrefab;
	public GameObject content;

	public UIItemSlot[] itemElements;

	private PlayerEquipment playersItems;

	private void Start() {
		playersItems = InGameMenu.instance.player.equipment;

		CreateUIItemElementObjects();

		UpdateUI();
	}

	public void CreateUIItemElementObjects() {
		ClearItemElementObjects();

		itemElements = new UIItemSlot[playersItems.inventorySize];

		for (int i = 0; i < itemElements.Length; i++) {
			UIItemSlot newElement = Instantiate(itemElementPrefab, content.transform).GetComponent<UIItemSlot>();
			newElement.ItemSlot = playersItems.GetItemSlot(i);

			itemElements[i] = newElement;
		}
	}

	public void UpdateUI() {
		for (int i = 0; i < itemElements.Length; i++) {
			itemElements[i].UpdateValues();
		}
	}

	public void SetItemElementsSize(int size) {
		if (size == itemElements.Length) return;
		if (size < itemElements.Length) {
			Debug.LogError("Making the Inventoy smaller is not yet(?) supported.");
			return;
		}

		UIItemSlot[] newItemElements = new UIItemSlot[size]; // TO SORT OUT ----------------------------------------------------------

		for (int i = 0; i < itemElements.Length; i++) {
			newItemElements[i] = itemElements[i];
		}

		itemElements = newItemElements;
	}

	public void ClearItemElementObjects() {
		foreach (Transform t in content.transform) {
			Destroy(t.gameObject);
		}
	}
}