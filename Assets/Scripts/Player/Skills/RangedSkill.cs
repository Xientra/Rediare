using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Ranged Skill", menuName = "Skills/RangedSkill")]
public class RangedSkill : Skill {

	//public GameObject projectile;
	public GameObject effect;
	public float range = 20;

	public override void Activate(Player origin, NPC target) {

		if ((origin.transform.position - target.transform.position).magnitude <= range) {

			target.stats.ChangeHealth(-damage); // <---------------------------------------------------------- i hate that FUCK
			GameObject temp = Instantiate(effect, target.transform.position, effect.transform.rotation);
			Destroy(temp, 3f);
		}
	}
}
