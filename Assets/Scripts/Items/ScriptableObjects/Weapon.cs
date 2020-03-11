using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu(fileName = "New Weapon", menuName = "Items/Weapons/Weapon")]
public abstract class Weapon : EquippableItem {
	
	[Header("Weapon:")]

    public float damage = 10f;

	[Header("Modifiers:")]
	[SerializeField]
	private ItemModifier[] modifiers = new ItemModifier[0];
	/// <summary>
	/// Returns a copy of the modifiers Array. (modifying the copy will not change the acual values of this Item)
	/// </summary>
	public ItemModifier[] Modifiers { get => (ItemModifier[])modifiers.Clone(); }
}