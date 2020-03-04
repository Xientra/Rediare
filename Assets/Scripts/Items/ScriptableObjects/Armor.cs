using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu(fileName = "New Armor", menuName = "Items/Armor/Armor")]
public abstract class Armor : Item {

	[Header("Armor")]	

    public float defence = 1f;


	[Header("Requirements:")]
	public float requiredLevel = 0;
	public float requiredStrength = 0;
	public float requiredDexterity = 0;
	public float requiredIntelligence = 0;
}