using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[RequireComponent(typeof(PlayerAttackManager))]
public class Player : Entity {

	[Header("Player Stats:")]
	#region player stats with equipment combination

	[SerializeField]
	protected int strength;
	public int Strength { get => strength + equipmentStatBonuses.Strength; }

	[SerializeField]
	protected int dexterity;
	public int Dexterity { get => dexterity + equipmentStatBonuses.Dexterity; }

	[SerializeField]
	protected int intelligence;
	public int Intelligence { get => intelligence + equipmentStatBonuses.Intelligence; }

	[SerializeField]
	protected float healthRecovery;
	public float HealthRecovery { get => healthRecovery + equipmentStatBonuses.HealthRecovery; }

	[SerializeField]
	protected float magicRecovery;
	public float MagicRecovery { get => magicRecovery + equipmentStatBonuses.MagicRecovery; }

	[Header("Equipment Stats Bonuses:")]
	[Tooltip("These Stats are from the equipment and are added onto the ones above, when called from another script")]
	[SerializeField]
	private EquipmentStatBonuses equipmentStatBonuses;

	// override the getter from the parent class to add the equipment stats onto them
	public override float MaxHP { get => maxHP + equipmentStatBonuses.MaxHP; }
	public override float MaxMP { get => maxMP + equipmentStatBonuses.MaxMP; }

	public override float Attack { get => attack + equipmentStatBonuses.Attack; }
	public override float Defence { get => defence + equipmentStatBonuses.Defence; }
	public override float Evasion { get => evasion + equipmentStatBonuses.Evasion; }

	// <<<<------------------------------------------------------------------------------------------------------ for crit the equipment stats are multiplied
	public override float CriticalHitChance { get => criticalHitChance * equipmentStatBonuses.CriticalHitChance; }
	public override float CriticalHitMulipier { get => criticalHitMulipier * equipmentStatBonuses.CriticalHitMulipier; }

	#endregion

	public override void GainExp(float amount) {
		experience += amount;
		if (experience >= GlobalValues.GetRequireredExpForNextLevel(level)) {
			OnLevelUp(experience - GlobalValues.GetRequireredExpForNextLevel(level));
		}
	}

	[Header("Equipment:")]

	public PlayerEquipment equipment = new PlayerEquipment(10);

	[Header("Player Skills:")]
	public PlayerSkills skills;
	public PlayerAttackManager attackManager;
	

	[Header("Effects: ")]
	public PlayerEffects playerEffect;

	private void Awake() {

		// equipment is serialized, that means that it allready exists in the instector
		equipment.SetInventorySize(10); // <<<------------------------------------------------------------------------------- manage inventory size

		equipmentStatBonuses.SetBasedOnEquipment(equipment);
	}

	private void Start() {
		InGameMenuEventSystem.OnItemChanged += UpdateStats;
	}

	/// <summary>
	/// Is called by InventorySystemEvents whenever an Item in an ItemSlot changed to update itemStats and then fullStats
	/// </summary>
	private void UpdateStats(ItemSlot itemSlot) {

		// update equipment stats
		equipmentStatBonuses.SetBasedOnEquipment(equipment);

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

	public override void OnDeath(Entity killer) {
		throw new System.NotImplementedException();
	}

	public void OnLevelUp(float remainingExp) {
		level++;

		GameObject temp = Instantiate(playerEffect.LevelUp, transform);
		Destroy(temp, 3f);

		// increase stats and such

		experience = 0;
		GainExp(remainingExp);
	}
}

[System.Serializable]
public struct PlayerEffects {
	public GameObject LevelUp;
}