using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[RequireComponent(typeof(PlayerAttackManager))]
public class Player : Entity {

	[Header("Stats:")]

	public PlayerStats baseStats;
	public ModifiableStats itemStats;
	public PlayerStats fullStats;

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