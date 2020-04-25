using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Obsolete]
[System.Serializable]
public class ModifiableStats {

	[SerializeField]
	protected float maxHP;
	public virtual float MaxHP { get => maxHP; }//set => maxHP = value; }

	[SerializeField]
	protected float maxMP;
	public virtual float MaxMP { get => maxMP; }//set => maxMP = value; }


	[SerializeField]
	protected int strength;
	public int Strength { get => strength; }//set => strength = value; }

	[SerializeField]
	protected int dexterity;
	public int Dexterity { get => dexterity; }//set => dexterity = value; }

	[SerializeField]
	protected int intelligence;
	public int Intelligence { get => intelligence; }//set => intelligence = value; }


	[SerializeField]
	protected float attack;
	public float Attack { get => attack; }//set => attack = value; }

	[SerializeField]
	protected float defence;
	public float Defence { get => defence; }//set => defence = value; }


	[SerializeField]
	protected float hpRecovery;
	public float HPRecovery { get => hpRecovery; }//set => hpRecovery = value; }


	[SerializeField]
	protected float criticalHitChance;
	public float CriticalHitChance { get => criticalHitChance; }//set => criticalHitChance = value; }

	[SerializeField]
	protected float criticalHitMulipier;
	public float CriticalHitMulipier { get => criticalHitMulipier; }//set => criticalHitMulipier = value; }


	[SerializeField]
	protected int inventorySize;
	public int InventorySize {
		get => inventorySize;
		//set => throw new NotImplementedException("Set is not yet implemented!
		// \nIt has to update the inventory size and warn the player if they lose a slot");
	}


	protected ModifiableStats() {
		Clear();
	}

	private ModifiableStats(float maxHP, float maxMP, int strength, int dexterity, int intelligence, float attack, float defence, float hpRecovery, float criticalHitChance, float criticalHitMulipier, int inventorySize) {
		this.maxHP = maxHP;
		this.maxMP = maxMP;

		this.strength = strength;
		this.dexterity = dexterity;
		this.intelligence = intelligence;

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

	private void Clear() {
		maxHP = 0;
		maxMP = 0;

		strength = 0;
		dexterity = 0;
		intelligence = 0;

		attack = 0;
		defence = 0;

		hpRecovery = 0;
		criticalHitChance = 1; // -----------------------------------------------------------------------hmm where to do the correct calculation
		criticalHitMulipier = 1;
		inventorySize = 0;
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
				hpRecovery = mod.Apply(hpRecovery);
				break;
			case ItemModifiers.Types.inventorySize:
				inventorySize = (int)mod.Apply(inventorySize);
				break;
		}
	}
}