using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIItemElement : MonoBehaviour {

    public const string EMPTY_TEXT = "[Empty]";

    public Item item;

    [Space(5)]

    public TextMeshProUGUI text;
    public Image image;

    [Space(5)]

    bool isCurrentlySelected = false;

    private void Start() {
        if (item != null) {
            UpdateValues();
        }
        else {
            //text.text = "";
        }
    }

    public void OnClick() {
        InGameMenu.instance.dragAndDropManager.ReciveOnClick(this);
        UpdateValues();
    }

    public void Empty() {
        //text.text = EMPTY_TEXT;
        //image.enabled = false;
        //image.sprite = null;
    }

    public void Select() {
        isCurrentlySelected = true;
    }

    public void DeSelect() {
        isCurrentlySelected = false;
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