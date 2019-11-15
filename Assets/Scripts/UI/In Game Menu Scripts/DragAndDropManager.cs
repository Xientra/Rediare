using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DragAndDropManager : MonoBehaviour {

    public static DragAndDropManager activeInstance;

    public GameObject dragGraphicPrefab;

    public UIItemElement selectedUIItemElement;

    public void Update() {
        if (Input.GetMouseButtonDown(0)) {

        }
    }

    public void ReciveOnClick(UIItemElement element) {
        if (selectedUIItemElement == null) {
            selectedUIItemElement = element;
        }
        else {
            SwapItems(selectedUIItemElement, element);
            selectedUIItemElement = null;
        }
    }

    private void SwapItems(UIItemElement element1, UIItemElement element2) {
        Item temp = element1.item;
        element1.SetItem(element2.item);
        element2.SetItem(temp);
    }
}