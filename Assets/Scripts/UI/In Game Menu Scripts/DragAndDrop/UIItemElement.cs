using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

[RequireComponent(typeof(EventTrigger))]
public class UIItemElement : MonoBehaviour {

	public const string EMPTY_TEXT = "[Empty]";

    public Item item;

    [Space(5)]

    public TextMeshProUGUI text;
    public Image image;

	//[Space(5)]

	public AcceptableItems acceptableItems;

    private void Start() {
        if (item != null) {
            UpdateValues();
        }
        else {
			Empty();
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

	public void OnDrop() { // is called whenever i release the mouse button over the game object (i think)
		Item itemToDrop = DragAndDropManager.itemDragger;

		if (CheckIfItemIsAcceptable(itemToDrop)) {

			DragAndDropManager.itemElementOrigin.SetItem(item); //swaps items in the slots
			this.SetItem(itemToDrop);

			DragAndDropManager.itemDragger = null; // this tells the DragAndDropManager the Drag was successfull

			UpdateValues();
		}
	}

	
	private bool CheckIfItemIsAcceptable(Item item) {
		bool result = false;

		//check armor
		if ((item is HeadArmor && acceptableItems.headSlot == true) ||
			(item is ChestArmor && acceptableItems.chestSlot == true) ||
			(item is LegArmor && acceptableItems.legSlot == true)) {

			result = true;
		}

		/*
		//check weapons
		if ((item is Sword && acceptableItems.swordSlot == true) ||
			(item is Bow && acceptableItems.bowSlot == true) ||
			(item is Staff && acceptableItems.staffSlot == true)) {

			result = true;
		}
		*/
		if ((item is Weapon && acceptableItems.weaponSlot == true)) {

			result = true;
		}

		return result;
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

	private void Empty() {
		item = null;

		text.text = EMPTY_TEXT;
		image.enabled = false;
		image.sprite = null;
	}

	public void OnValidate() {
        UpdateValues();
    }
}

[System.Serializable]
public class AcceptableItems {

	[Header("Armor: ")]
	public bool headSlot = true;
	public bool chestSlot = true;
	public bool legSlot = true;

	[Header("Weapons: ")]
	/*
	public bool swordSlot = true;
	public bool bowSlot = true;
	public bool staffSlot = true;
	*/

	public bool weaponSlot = false;

	public AcceptableItems() {
		headSlot = true;
		chestSlot = true;
		legSlot = true;

		weaponSlot = true;

		//swordSlot = true;
		//bowSlot = true;
		//staffSlot = true;
	}
}