using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu(fileName = "New Weapon", menuName = "Items/Weapons/Weapon")]
public abstract class Weapon : EquippableItem {
	
	[Header("Weapon:")]

    public float damage = 10f;


}