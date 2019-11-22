using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

//[RequireComponent(typeof(EventTrigger))]
public class UIItemElement : MonoBehaviour {

    public const string EMPTY_TEXT = "[Empty]";

    public Item item;

    [Space(5)]

    public TextMeshProUGUI text;
    public Image image;

    //[Space(5)]

    private void Start() {
        if (item != null) {
            UpdateValues();
        }
        else {
			Empty();
        }
    }

    public void OnDrop() { // is called whenever i release the mouse button over the game object (i think)
        if (item == null) {
            item = DragAndDropManager.itemDragger;
            DragAndDropManager.itemDragger = null; // this tells the DragAndDropManager the Drag was successfull
            UpdateValues();
        }
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

    #region OnDrop for the acual moving version
    /*
    public void OnDrop() { // is called whenever i release the mouse button over the game object (i think)
        if (item == null) {
            DragAndDropManager.objectDragger.transform.SetParent(transform);
            item = DragAndDropManager.itemDragger;
            UpdateValues();
        }
    }
    */
    #endregion

    public void Empty() {
        item = null;

        text.text = EMPTY_TEXT;
        image.enabled = false;
        image.sprite = null;
    }

    public void SetItem(Item item) {
        this.item = item;
        UpdateValues();
    }

    public void UpdateValues() {
        
        if (item != null) {
            text.text = item.name;
            image.enabled = true;
            image.sprite = item.image;
        }
        else {
            Empty();
        }
    }

    public void OnValidate() {
        UpdateValues();
    }
}