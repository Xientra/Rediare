using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemModifier {

	private bool isSet = false;

	//---------------------------------------------------- ok no this is shit i can still see the unjused ones...
	[SerializeField]
	private float maxHP;
	public float MaxHP { get => maxHP; }

	public void SetMaxHP(float maxHP) {
		this.maxHP = maxHP;
	}
}