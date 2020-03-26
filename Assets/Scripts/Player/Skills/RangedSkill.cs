using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Ranged Skill", menuName = "Skills/RangedSkill")]
public class RangedSkill : Skill {

	//public GameObject projectile;
	public float damageDelay = 0.2f;

	public override void Activate(Player origin, NPC target) {
		
	}

	private IEnumerator dealDamage(NPC target, float delay) {
		yield return new WaitForSeconds(delay);

	}
}
