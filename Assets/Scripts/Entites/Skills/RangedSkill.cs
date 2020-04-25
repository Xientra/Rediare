using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Ranged Skill", menuName = "Skills/RangedSkill")]
public class RangedSkill : Skill {

	[Header("Ranged Settings:")]

	public Projectile projectilePrefab;
	public float range = 20;
	[Tooltip("The duration for a full range shoot.")]
	public float projectileDuration = 0.5f;

	public override bool Activate(Entity origin, Entity target) {

		if ((origin.transform.position - target.transform.position).magnitude <= range) {

			Projectile p = Instantiate(projectilePrefab.gameObject, origin.Center, origin.transform.rotation).GetComponent<Projectile>();

			// v = s / t  t = s / v

			// this will fire the skill and deal damage once it is done animating
			p.Fire(target, (-origin.Center + target.Center).magnitude / (range / projectileDuration), () => {
				target.DealDamage(damage + origin.Attack, origin);
			});
			return true;
		}
		else return false;
	}
}