using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Ranged Skill", menuName = "Skills/RangedSkill")]
public class RangedSkill : Skill {

	public Projectile projectilePrefab;
	public float range = 20;
	[Tooltip("The duration for a full range shoot.")]
	public float projectileDuration = 0.5f;



	public override void Activate(Player origin, NPC target) { // <----------------------------------- OH GOD NO THIS SHOULD WORK FOR JUST ENTITIES

		if ((origin.transform.position - target.transform.position).magnitude <= range) {

			Projectile p = Instantiate(projectilePrefab.gameObject, origin.Center, origin.transform.rotation).GetComponent<Projectile>();

			// v = s / t  t = s / v
			p.Fire(target, (-origin.Center + target.Center).magnitude / (range / projectileDuration), () => DealDamage(target));
		}
	}

	private void DealDamage(NPC target) {
		target.stats.ChangeHealth(-damage);
	}
}
