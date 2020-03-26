using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EquippableItem : Item {

	[Header("Requirements:")]
	public Requirements requirements;
	[System.Serializable]
	public class Requirements {
		public float level = 0;
		public float strength = 0;
		public float dexterity = 0;
		public float intelligence = 0;
	}

	[Header("Skills:")]
	[SerializeField]
	private PlayerSkills[] skills = new PlayerSkills[0];
	/// <summary>
	/// Returns a copy of the skills Array. (modifying the copy will not change the acual skills Array fo this item)
	/// </summary>
	public PlayerSkills[] Skills { get => (PlayerSkills[])skills.Clone(); }

	[Header("Modifiers:")]
	[SerializeField]
	private ItemModifier[] modifiers = new ItemModifier[0];
	/// <summary>
	/// Returns a copy of the modifiers Array. (modifying the copy will not change the acual values of this Item)
	/// </summary>
	public ItemModifier[] Modifiers { get => (ItemModifier[])modifiers.Clone(); }

}