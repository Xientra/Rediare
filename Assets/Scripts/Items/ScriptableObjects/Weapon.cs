using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu(fileName = "New Weapon", menuName = "Items/Weapons/Weapon")]
public abstract class Weapon : Item {
	
	[Header("Weapon:")]

    public float damage = 10f;

	[Header("Requirements:")]
	public float requiredLevel = 0;
	public float requiredStrength = 0;
	public float requiredDexterity = 0;
	public float requiredIntelligence = 0;

	[Header("Modifiers:")]
	[SerializeField]
	private ItemModifier[] modifiers = new ItemModifier[0];
	/// <summary>
	/// Returns a copy of the modifiers Array. (modifying the copy will not change the acual values of this Item)
	/// </summary>
	public ItemModifier[] Modifiers { get => (ItemModifier[])modifiers.Clone(); }
}