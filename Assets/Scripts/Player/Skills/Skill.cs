using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Skill : ScriptableObject {

	public float damage = 10;
	public float cooldown = 5;


	public abstract void Activate(Player origin, NPC target);

}
