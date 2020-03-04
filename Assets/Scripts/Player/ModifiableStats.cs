using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ModifiableStats {

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
	protected float attack;
	public float Attack { get => attack; }

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
	protected int inventorySize;
	public int InventorySize { get => inventorySize; }


	protected ModifiableStats() {
		maxHP = 0;
		maxMP = 0;

		attack = 0;
		defence = 0;
		hpRecovery = 0;
		criticalHitChance = 0;
		criticalHitMulipier = 0;
		inventorySize = 0;
	}

	private ModifiableStats(float maxHP, float maxMP, float attack, float defence, float hpRecovery, float criticalHitChance, float criticalHitMulipier, int inventorySize) {
		this.maxHP = maxHP;
		this.maxMP = maxMP;
		this.attack = attack;
		this.defence = defence;
		this.hpRecovery = hpRecovery;
		this.criticalHitChance = criticalHitChance;
		this.criticalHitMulipier = criticalHitMulipier;
		this.inventorySize = inventorySize;
	}

	/// <summary>
	/// Returns a new ModifiableStats object with all values set to 0.
	/// </summary>
	public static ModifiableStats Zero {
		get {
			return new ModifiableStats();
		}
	}

	public void SetBasedOnEquipment() { 
	
	}
}
