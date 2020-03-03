using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryWindow : MonoBehaviour {

	public GameObject itemElementPrefab;
	public GameObject content;

	public UIItemElement[] itemElements;

	private PlayerEquipment playersItems;

	private void Start() {
		playersItems = InGameMenu.instance.player.equipment;

		CreateUIItemElementObjects();

		UpdateUI();
	}

	public void CreateUIItemElementObjects() {
		ClearItemElementObjects();

		itemElements = new UIItemElement[playersItems.inventorySize];

		for (int i = 0; i < itemElements.Length; i++) {
			UIItemElement newElement = Instantiate(itemElementPrefab, content.transform).GetComponent<UIItemElement>();
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

		UIItemElement[] newItemElements = new UIItemElement[size]; // TO SORT OUT ----------------------------------------------------------

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