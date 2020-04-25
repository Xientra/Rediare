using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class EquipmentStatBonuses {

	[SerializeField]
	protected float maxHP;
	public virtual float MaxHP { get => maxHP; }

	[SerializeField]
	protected float maxMP;
	public virtual float MaxMP { get => maxMP; }


	[SerializeField]
	protected int strength;
	public int Strength { get => strength; }

	[SerializeField]
	protected int dexterity;
	public int Dexterity { get => dexterity; }

	[SerializeField]
	protected int intelligence;
	public int Intelligence { get => intelligence; }


	[SerializeField]
	protected float attack;
	public float Attack { get => attack; }

	[SerializeField]
	protected float defence;
	public float Defence { get => defence; }

	[SerializeField]
	private float evasion = 10;
	public float Evasion { get => evasion; }


	[SerializeField]
	protected float healthRecovery;
	public float HealthRecovery { get => healthRecovery; }

	[SerializeField]
	protected float magicRecovery;
	public float MagicRecovery { get => magicRecovery; }


	[SerializeField]
	protected float criticalHitChance;
	public float CriticalHitChance { get => criticalHitChance; }

	[SerializeField]
	protected float criticalHitMulipier;
	public float CriticalHitMulipier { get => criticalHitMulipier; }

	public EquipmentStatBonuses() {
		Clear();
	}

	private void Clear() {
		maxHP = 0;
		maxMP = 0;

		strength = 0;
		dexterity = 0;
		intelligence = 0;

		attack = 0;
		defence = 0;

		healthRecovery = 0;
		magicRecovery = 0;
		criticalHitChance = 1; // -----------------------------------------------------------------------hmm where to do the correct calculation
		criticalHitMulipier = 1;
		//inventorySize = 0;
	}

	public void SetBasedOnEquipment(PlayerEquipment equipment) {

		Clear();

		// add armor defence
		if (equipment.HeadSlot.IsEmpty() == false) {
			HeadArmor ha = (HeadArmor)equipment.HeadSlot.Item;
			defence += ha.defence;
		}
		if (equipment.ChestSlot.IsEmpty() == false) {
			ChestArmor ca = (ChestArmor)equipment.ChestSlot.Item;
			defence += ca.defence;
		}
		if (equipment.LegsSlot.IsEmpty() == false) {
			LegArmor la = (LegArmor)equipment.LegsSlot.Item;
			defence += la.defence;
		}

		// add weapon(s) attack
		if (equipment.WeaponSlot.IsEmpty() == false) {
			Weapon w = (Weapon)equipment.WeaponSlot.Item;
			attack += w.damage;
		}

		// add other modifiers
		foreach (ItemModifier mod in equipment.GetAllModifiers()) {
			AddItemModifier(mod);
		}
	}

	/// <summary>
	/// Adds the value of the mod to the stat, which corresponds to the mod type using the mods calcuation method.
	/// </summary>
	private void AddItemModifier(ItemModifier mod) {
		switch (mod.type) {
			case ItemModifiers.Types.maxHP:
				maxHP = mod.Apply(maxHP);
				break;
			case ItemModifiers.Types.maxMP:
				maxMP = mod.Apply(maxMP);
				break;
			case ItemModifiers.Types.attack:
				attack = mod.Apply(attack);
				break;
			case ItemModifiers.Types.defence:
				defence = mod.Apply(defence);
				break;
			case ItemModifiers.Types.strength:
				strength = (int)mod.Apply(strength);
				break;
			case ItemModifiers.Types.dexterity:
				dexterity = (int)mod.Apply(dexterity);
				break;
			case ItemModifiers.Types.intelligence:
				intelligence = (int)mod.Apply(intelligence);
				break;
			case ItemModifiers.Types.criticalHitChance:
				criticalHitChance = mod.Apply(criticalHitChance);
				break;
			case ItemModifiers.Types.criticalHitMulipier:
				criticalHitMulipier = mod.Apply(criticalHitMulipier);
				break;
			case ItemModifiers.Types.healthRecovery:
				healthRecovery = mod.Apply(healthRecovery);
				break;
			case ItemModifiers.Types.magicRecovery:
				magicRecovery = mod.Apply(magicRecovery);
				break;
		}
	}

	/// <summary>
	/// Adds the value of the mod to the stat just by adding/assinging it.
	/// </summary>
	private void AddItemModifierRaw(ItemModifier mod) {
		switch (mod.type) {
			case ItemModifiers.Types.maxHP:
				maxHP = mod.Value;
				break;
			case ItemModifiers.Types.maxMP:
				maxMP = mod.Value;
				break;
			case ItemModifiers.Types.attack:
				attack = mod.Value;
				break;
			case ItemModifiers.Types.defence:
				defence = mod.Value;
				break;
			case ItemModifiers.Types.strength:
				strength = (int)mod.Value;
				break;
			case ItemModifiers.Types.dexterity:
				dexterity = (int)mod.Value;
				break;
			case ItemModifiers.Types.intelligence:
				intelligence = (int)mod.Value;
				break;
			case ItemModifiers.Types.criticalHitChance:
				criticalHitChance = mod.Value;
				break;
			case ItemModifiers.Types.criticalHitMulipier:
				criticalHitMulipier = mod.Value;
				break;
			case ItemModifiers.Types.healthRecovery:
				healthRecovery = mod.Value;
				break;
			case ItemModifiers.Types.magicRecovery:
				magicRecovery = mod.Value;
				break;
		}
	}

}