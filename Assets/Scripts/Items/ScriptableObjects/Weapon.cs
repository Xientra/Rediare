using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu(fileName = "New Weapon", menuName = "Items/Weapons/Weapon")]
public abstract class Weapon : Item {
	
	[Header("Weapon:")]

    public float damage = 1f;

	[Header("Requirements:")]
	public float requiredLevel = 0;
	public float requiredStrength = 0;
	public float requiredDexterity = 0;
	public float requiredIntelligence = 0;
}