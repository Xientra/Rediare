using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Obsolete]
[Serializable]
public class EntityStats {

	[SerializeField]
	private float level = 1;
	public float Level { get => level; set => level = value; }
	public void LevelUp() {
		level++;
	}

	[SerializeField]
	private float health = 100;
	public float Health { get => health; }
	public void DealDamage(float amount) {
		health -= amount;
	}
	public void Heal(float amount) {
		health += amount;
	}

	[SerializeField]
	private float magicPoints;
	public float MagicPoints { get => magicPoints; }
	public void UseMP(float amount) {
		magicPoints -= amount;
	}
	public void RestoreMP(float amount) {
		magicPoints += amount;
	}
}