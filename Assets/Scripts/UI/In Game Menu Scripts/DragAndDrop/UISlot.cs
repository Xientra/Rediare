using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

[RequireComponent(typeof(EventTrigger))]
public abstract class UISlot : MonoBehaviour {

	public const string EMPTY_TEXT = "[Empty]";

	[Header("UI References:")]
	public TextMeshProUGUI text;
	public Image image;



	private void Start() {
		UpdateValues();
	}


	public abstract void UpdateValues();


	//public abstract void UpdateBasedOnContent();

	//public abstract bool IsUsable();

	public abstract bool IsEmpty();

	#region Drag and Drop 
	// is called whenever the mouse button is released over the game object (i think)
	public abstract void OnDrop();

	public void OnDragTrigger() {
		DragAndDropManager.instance.OnDrag();
	}

	public void OnBeginDragTrigger() {
		DragAndDropManager.instance.OnBeginDrag(this);
	}

	public void OnEndDragTrigger() {
		DragAndDropManager.instance.OnEndDrag();
	}
	#endregion

	#region hover effect for ItemInfoPanel
	public abstract void OnPointerEnter();

	public abstract void OnPointerExit();
	#endregion


	public void OnValidate() {
		UpdateValues();
	}
}