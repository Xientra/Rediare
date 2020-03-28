using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerAttackManager : MonoBehaviour {

	private Player player;
	private PlayerSkills playerSkills;

	[SerializeField]
	private NPC target;

	public float targetSelectionRange = 20f;

	void Start() {
		player = GetComponent<Player>();

		playerSkills = player.skills;
	}

	void Update() {
		TargetSelection();
		ActivateSkills();
	}

	private void TargetSelection() { // <---------------------------------------------------- gets only the nearest(?) enemy
		if (Input.GetKeyDown(KeyCode.Tab)) {
			TargetNPC();
		}
	}

	private void TargetNPC() {
		Collider[] hits = Physics.OverlapSphere(transform.position, targetSelectionRange, 1 << LayerMask.NameToLayer("NPCs"));

		NPC closestNpc = null;
		foreach (Collider hit in hits) {
			NPC npc = hit.transform.GetComponent<NPC>();
			if (npc != null && npc.IsHostile) {
				target = npc;
				if (closestNpc == null || (-transform.position + npc.transform.position).sqrMagnitude < (-transform.position + closestNpc.transform.position).sqrMagnitude) {
					closestNpc = npc;
				}
			}
		}
		target = closestNpc;
	}

	private void ActivateSkills() {
		if (target == null)
			TargetNPC();
		if (target == null)
			return;

		if (Input.GetKeyDown(KeyCode.Alpha1)) {
			//playerSkills.equipedSkills[1 - 1].Activate(player, target);
		}
		if (Input.GetKeyDown(KeyCode.Alpha2)) {
			//playerSkills.equipedSkills[2 - 1].Activate(player, target);
		}
		if (Input.GetKeyDown(KeyCode.Alpha3)) {
			//playerSkills.equipedSkills[3 - 1].Activate(player, target);
		}
	}

	private void OnDrawGizmosSelected() {
		Gizmos.DrawWireSphere(transform.position, targetSelectionRange);
	}
}