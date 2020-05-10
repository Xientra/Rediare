using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using UnityEngine;
using UnityEngine.SocialPlatforms;

[CreateAssetMenu(fileName = "New Melee Skill", menuName = "Skills/SwordAttackSkill")]
public class SwordAttackSkill : Skill {

	public Slash slashPrefab;
	public float range = 2f;
	[Tooltip("How long the skill stays active and is able to hit.")]
	public float lingeringDuration = 1f;

	public override bool Activate(Entity origin, Entity target) {

		Slash s = Instantiate(slashPrefab.gameObject, origin.Center, origin.transform.rotation).GetComponent<Slash>();

		s.Fire(origin, target, range, lingeringDuration, () => {
			target.DealDamage(damage + origin.Attack, origin);
		});

		return true;
	}
}
