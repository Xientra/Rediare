using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stats {

	[SerializeField]
	protected float maxHP;
	public float MaxHP { get => maxHP; }
	public virtual void UpdateMaxHP(int newMaxHp) {
		maxHP = newMaxHp;
	}

	[SerializeField]
	protected float maxMP;
	public float MaxMP { get => maxMP; }
	public virtual void UpdateMaxMP(int newMaxMp) {
		maxMP = newMaxMp;
	}

	[SerializeField]
	protected int attack;
	public int Attack { get => attack; }

	[SerializeField]
	protected float defence;
	public float Defence { get => defence; }


	[SerializeField]
	protected float hpRecovery;
	public float HPRecovery { get => hpRecovery; }


	[SerializeField]
	protected float criticalHitChance;
	public float CriticalHitChance { get => criticalHitChance; }

	[SerializeField]
	protected float criticalHitMulipier;
	public float CriticalHitMulipier { get => criticalHitMulipier; }


	[SerializeField]
	protected float inventorySize;
	public float InventorySize { get => inventorySize; }


	public Stats() {
		maxHP = 0;
		maxMP = 0;

		attack = 0;
		defence = 0;
		hpRecovery = 0;
		criticalHitChance = 0;
		criticalHitMulipier = 0;
		inventorySize = 0;
	}
}
