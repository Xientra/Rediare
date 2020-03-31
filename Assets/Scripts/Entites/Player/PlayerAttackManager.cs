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

	public Skill[] equipedSkills = new Skill[9];

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
			equipedSkills[1 - 1]?.Activate(player, target);
		}
		if (Input.GetKeyDown(KeyCode.Alpha2)) {
			equipedSkills[2 - 1]?.Activate(player, target);
		}
		if (Input.GetKeyDown(KeyCode.Alpha3)) {
			equipedSkills[3 - 1]?.Activate(player, target);
		}
		if (Input.GetKeyDown(KeyCode.Alpha4)) {
			equipedSkills[4 - 1]?.Activate(player, target);
		}
		if (Input.GetKeyDown(KeyCode.Alpha5)) {
			equipedSkills[5 - 1]?.Activate(player, target);
		}
		if (Input.GetKeyDown(KeyCode.Alpha6)) {
			equipedSkills[6 - 1]?.Activate(player, target);
		}
		if (Input.GetKeyDown(KeyCode.Alpha7)) {
			equipedSkills[7 - 1]?.Activate(player, target);
		}
		if (Input.GetKeyDown(KeyCode.Alpha8)) {
			equipedSkills[8 - 1]?.Activate(player, target);
		}
		if (Input.GetKeyDown(KeyCode.Alpha9)) {
			equipedSkills[9 - 1]?.Activate(player, target);
		}
	}

	public void ActivateSkill(int index) {
		equipedSkills[index]?.Activate(player, target);
	}

	public void SwapEquipedSkills(int a, int b) {
		Skill s = equipedSkills[a];
		equipedSkills[a] = equipedSkills[b];
		equipedSkills[b] = s;
	}

	private void OnDrawGizmosSelected() {
		Gizmos.DrawWireSphere(transform.position, targetSelectionRange);
	}
}