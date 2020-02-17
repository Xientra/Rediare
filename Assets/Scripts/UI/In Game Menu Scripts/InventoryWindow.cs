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
		playersItems = InGameMenu.instance.player.playerItems;


		SetItemElementsSize(playersItems.inventorySize);

		CreateUIItemElementObjects();

		UpdateUI();
	}

	public void CreateUIItemElementObjects() {
		ClearItemElementObjects();

		for (int i = 0; i < itemElements.Length; i++) {
			UIItemElement newElement = Instantiate(itemElementPrefab, content.transform).GetComponent<UIItemElement>();
			if (itemElements[i] != null) {
				newElement.CloneValues(itemElements[i]);
			}
			itemElements[i] = newElement;
		}
	}

	public void SetItemElementsSize(int size) {
		if (size == itemElements.Length) return;
		if (size < itemElements.Length) {
			Debug.LogError("Making the Inventoy smaller is not yet(?) supported.");
			return;
		}

		UIItemElement[] newItemElements = new UIItemElement[size];

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

	public void UpdateUI() {
		for (int i = 0; i < itemElements.Length; i++) {
			itemElements[i].SetItem(playersItems.GetItem(i));
		}
	}


	/*
	public bool AddItem(Item item) {
		for (int i = 0; i < itemElements.Length; i++) {
			UIItemElement ie = itemElements[i];

			if (ie.item == null && ie.CheckIfItemIsAcceptable(item)) {
				ie.SetItem(item);
				return true;
			}
		}

		return false;
	}
	*/
}