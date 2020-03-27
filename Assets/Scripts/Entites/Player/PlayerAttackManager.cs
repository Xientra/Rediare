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
			RaycastHit[] hits = Physics.SphereCastAll(transform.position, targetSelectionRange, Vector3.zero, 0.001f, LayerMask.NameToLayer("NPC"));
			foreach (RaycastHit hit in hits) {
				NPC npc = hit.transform.GetComponent<NPC>();
				if (npc.IsHostile) {
					target = npc;
					return;
				}
			}
		}
	}

	private void ActivateSkills() {
		if (Input.GetKeyDown(KeyCode.Alpha1)) {
			playerSkills.equipedSkills[1 - 1].Activate(player, target);
		}
		if (Input.GetKeyDown(KeyCode.Alpha2)) {
			playerSkills.equipedSkills[2 - 1].Activate(player, target);
		}
		if (Input.GetKeyDown(KeyCode.Alpha3)) {
			playerSkills.equipedSkills[3 - 1].Activate(player, target);
		}
	}
}
