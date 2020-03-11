using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EquippableItem : Item {

	[Header("Requirements:")]
	public float requiredLevel = 0;
	public float requiredStrength = 0;
	public float requiredDexterity = 0;
	public float requiredIntelligence = 0;
}