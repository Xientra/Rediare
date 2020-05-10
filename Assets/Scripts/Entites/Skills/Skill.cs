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

	/// <summary>
	/// 
	/// <para>returns true if the skill activated, false if it did not activate, for example if it was out of range</para>
	/// </summary>
	/// <param name="origin"> the entity that activated the skill </param>
	/// <param name="target"> the entity that is targeted by this activation </param>
	/// <returns> true if the skill activated, false if it did not activate, for example if it was out of range </returns>
	public abstract bool Activate(Entity origin, Entity target);

}