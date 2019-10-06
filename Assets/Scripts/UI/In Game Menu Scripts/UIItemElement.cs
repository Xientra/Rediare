using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIItemElement : MonoBehaviour {

    public Item item;

    [Space(5)]

    public TextMeshProUGUI text;
    public Image image;

    private void Start() {
        if (item != null) UpdateValues();
        else {
            text.text = "";
        }
    }

    public void SetItem(Item item) {
        this.item = item;
        UpdateValues();
    }

    public void UpdateValues() {
        text.text = item.name;
    }
}