using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[RequireComponent(typeof(PlayerAttackManager))]
public class Player : Entity {

	[Header("Player Stats:")]

	[SerializeField]
	protected int strength;
	public int Strength { get => strength + equipmentStats.Strength; }

	[SerializeField]
	protected int dexterity;
	public int Dexterity { get => dexterity + equipmentStats.Dexterity; }

	[SerializeField]
	protected int intelligence;
	public int Intelligence { get => intelligence + equipmentStats.Intelligence; }

	[SerializeField]
	protected float healthRecovery;
	public float HealthRecovery { get => healthRecovery + equipmentStats.HealthRecovery; }

	[SerializeField]
	protected float magicRecovery;
	public float MagicRecovery { get => magicRecovery + equipmentStats.MagicRecovery; }

	[Tooltip("These Stats are from the equipment and are added onto the ones above, when called from another script")]
	private EquipmentStatBonuses equipmentStats;

	// override the getter from the parent class to add the equipment stats onto them
	public override float MaxHP { get => maxHP + equipmentStats.MaxHP; }
	public override float MaxMP { get => maxMP + equipmentStats.MaxMP; }

	public override float Attack { get => attack + equipmentStats.Attack; }
	public override float Defence { get => defence + equipmentStats.Defence; }
	public override float Evasion { get => evasion + equipmentStats.Evasion; }
	
	// <<<<------------------------------------------------------------------------------------------------------ for crit the equipment stats are multiplied
	public override float CriticalHitChance { get => criticalHitChance * equipmentStats.CriticalHitChance; }
	public override float CriticalHitMulipier { get => criticalHitMulipier * equipmentStats.CriticalHitMulipier; }



	[Header("Old Stats:")]

	public PlayerStats baseStats;
	public ModifiableStats itemStats;
	public PlayerStats fullStats;

	[Header("Equipment:")]

	public PlayerEquipment equipment = new PlayerEquipment(10);

	public PlayerSkills skills;
	public PlayerAttackManager attackManager;

	private void Awake() {

		baseStats = PlayerStats.Default;
		itemStats = ModifiableStats.Zero;
		itemStats.SetBasedOnEquipment(equipment);
		fullStats = PlayerStats.CalculateFullStats(baseStats, itemStats);

		// equipment is serialized, that means that it allready exists in the instector
		equipment.SetInventorySize(fullStats.InventorySize);
	}

	private void Start() {
		InGameMenuEventSystem.OnItemChanged += UpdateStats;
	}

	/// <summary>
	/// Is called by InventorySystemEvents whenever an Item in an ItemSlot changed to update itemStats and then fullStats
	/// </summary>
	private void UpdateStats(ItemSlot itemSlot) {
		// update stats
		itemStats.SetBasedOnEquipment(equipment);
		fullStats.UpdateFullStats(baseStats, itemStats);
		// update skills
		//skills.equipmentSkills = equipment.GetAllSkills();

		InGameMenuEventSystem.StatsChanged();
	}

	private void Update() {

	}

	public void PickupItem(Item item) {
		equipment.AddToInventory(item);
	}

	private void OnValidate() {
		InGameMenuEventSystem.ItemChanged(null);
		InGameMenuEventSystem.StatsChanged();
	}
}