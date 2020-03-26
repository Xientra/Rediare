using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerAttackManager : MonoBehaviour {

	private Player player;
	private PlayerSkills playerSkills;

	[SerializeField]
	private NPC target;

	void Start() {
		player = GetComponent<Player>();

		playerSkills = player.skills;

		//InventoryEventSystem.OnItemChanged += UpdateEquipmentSkills;
	}

	void Update() {
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
