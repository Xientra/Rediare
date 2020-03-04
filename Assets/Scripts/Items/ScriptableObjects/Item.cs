using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "New Item", menuName = "Items/Item")]
public class Item : ScriptableObject {
	
	[Header("Item:")]

    public new string name = "Item";
    public Sprite image;
    public float value = 10;

	public GameObject graphic;
}