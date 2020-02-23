using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class ItemPickup : MonoBehaviour {

	[SerializeField]
	private Item item;
	//public Item Item { get => item; }

	private Collider col;

	[SerializeField]
	private Transform displayPoint = null;

	[SerializeField]
	private ParticleSystem particleSys = null;
	[SerializeField]
	private Light pointLight = null;

	[SerializeField]
	private GameObject itemGraphic;

	private void Start() {
		SetItem(item);
		col = GetComponent<Collider>();
	}

	public void SetItem(Item item) {
		this.item = item;
		gameObject.name = "PickUp" + " \"" + item.name + "\"";


		particleSys.Play();
		pointLight.enabled = true;

		if (itemGraphic == null) {
			itemGraphic = Instantiate(item.graphic, displayPoint);
		}
	}

	public Item PickUpItem() {
		particleSys.Stop();
		pointLight.enabled = false;

		Item temp = item;
		item = null;
		Destroy(this.gameObject, 0.5f);
		return temp;
	}

	private void OnTriggerEnter(Collider other) {
		if (other.CompareTag("Player")) {
			other.GetComponent<Player>().PickupItem(PickUpItem());
		}
	}



	private void OnValidate() {
		if (item != null)
			SetItem(item);
		else {
			if (itemGraphic != null)
				Destroy(itemGraphic);
			gameObject.name = "PickUp";
		}
	}
}