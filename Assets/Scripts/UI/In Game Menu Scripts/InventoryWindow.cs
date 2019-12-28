using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class InventoryWindow : MonoBehaviour {

	public GameObject itemElementPrefab;
	public GameObject content;
	private LayoutGroup contentLayoutGroup;

	public UIItemElement[] itemElements;

	private void Start() {
		contentLayoutGroup = content.GetComponent<LayoutGroup>();

		SetItemElementsSize(10);
		CreateUIItemElementObjects();
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
}