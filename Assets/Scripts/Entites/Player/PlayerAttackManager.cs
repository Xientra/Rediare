﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerAttackManager : MonoBehaviour {

	private Player player;
	private PlayerSkills playerSkills;

	[SerializeField]
	private NPC target;

	public float targetSelectionRange = 20f;


	//public ActionBarSlot[] actionBarSlots = new ActionBarSlot[9];
	public Skill[] equipedSkills = new Skill[9];
	[SerializeField]
	private float[] cooldowns = new float[9]; 

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

		if (cooldowns[1 - 1] == 0)
			if (Input.GetKey(KeyCode.Alpha1))
				ActivateSkill(1 - 1);

		if (cooldowns[2 - 1] == 0)
			if (Input.GetKey(KeyCode.Alpha2))
				ActivateSkill(2 - 1);

		if (cooldowns[3 - 1] == 0)
			if (Input.GetKey(KeyCode.Alpha3))
				ActivateSkill(3 - 1);

		if (cooldowns[4 - 1] == 0)
			if (Input.GetKey(KeyCode.Alpha4))
				ActivateSkill(4 - 1);

		if (cooldowns[5 - 1] == 0)
			if (Input.GetKey(KeyCode.Alpha5))
				ActivateSkill(5 - 1);

		if (cooldowns[6 - 1] == 0)
			if (Input.GetKey(KeyCode.Alpha6))
				ActivateSkill(6 - 1);

		if (cooldowns[7 - 1] == 0)
			if (Input.GetKey(KeyCode.Alpha7))
				ActivateSkill(7 - 1);

		if (cooldowns[8 - 1] == 0)
			if (Input.GetKey(KeyCode.Alpha8))
				ActivateSkill(8 - 1);

		if (cooldowns[9 - 1] == 0)
			if (Input.GetKey(KeyCode.Alpha9))
				ActivateSkill(9 - 1);
	}

	public void ActivateSkill(int index) {
		if (index >= 0 && index <= 9 && equipedSkills[index] != null) {
			if (cooldowns[index] == 0) {
				bool result = equipedSkills[index].Activate(player, target);
				if (result == true)
					StartCoroutine(Cooldown(index, equipedSkills[index].cooldown));
			}
		}
	}

	private IEnumerator Cooldown(int index, float seconds) {
		cooldowns[index] = seconds; 
		while (cooldowns[index] > 0) {
			cooldowns[index] -= Time.deltaTime;
			InGameMenuEventSystem.ActionBarChanged(index);
			yield return null;
		}
		cooldowns[index] = 0;
	}

	public float GetCooldown(int index) {
		if (index >= 0 && index <= 9) {
			return cooldowns[index];
		}
		else {
			throw new System.ArgumentOutOfRangeException("The cooldowns array goes from 0 to " + (cooldowns.Length - 1));
		}
	}

	public float GetCooldown01(int index) {
		if (index >= 0 && index <= 9) {
			return cooldowns[index] / equipedSkills[index].cooldown;
		}
		else {
			throw new System.ArgumentOutOfRangeException("The cooldowns array goes from 0 to " + (cooldowns.Length - 1));
		}
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