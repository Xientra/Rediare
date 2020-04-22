using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class Skill : ScriptableObject {

	[Header("Base Settings:")]
	public new string name = "New Skill";
	public Sprite image;


	public float damage = 10;
	public float cooldown = 5;


	public abstract bool Activate(Player origin, Entity target);

}