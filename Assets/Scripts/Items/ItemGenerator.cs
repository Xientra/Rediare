using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ItemGenerator : MonoBehaviour
{
	public static ItemGenerator singelton;

	/*

		public Vector2Int requirementsMinMax = new Vector2Int(0, 10);
	//public AnimationCurve requirementsDistribution;

		public Vector2Int modifiersAmountMinMax = new Vector2Int(0, 5);

		//public AnimationCurve modifiersValueDistribution;
		*/


	[MenuItem("Assets/Create/Items/Generate Weapon")]
	public static void CreateMyAsset()
	{
		Sword asset = ScriptableObject.CreateInstance<Sword>();

		GenerateValues(asset);

		string name = AssetDatabase.GenerateUniqueAssetPath("Assets/ScriptableObjects/Generated/GeneratedWeapon.asset");
		AssetDatabase.CreateAsset(asset, name);
		AssetDatabase.SaveAssets();

		EditorUtility.FocusProjectWindow();

		Selection.activeObject = asset;
	}

	private void Awake()
	{
		singelton = this;
	}

	private static void GenerateValues(Sword sword)
	{
		Vector2Int requirementsMinMax = new Vector2Int(0, 10);
		Vector2 modifiersValueMinMax = new Vector2(0, 25);
		Vector2Int modifiersAmountMinMax = new Vector2Int(3, 5);
		Vector2Int valueMinMax = new Vector2Int(0, 10000);
		Vector2Int damageMinMax = new Vector2Int(2, 50);


		sword.name = Random.Range(0, int.MaxValue).ToString();

		System.Random rng = new System.Random();

		sword.requirements = new EquippableItem.Requirements();
		sword.requirements.dexterity = Random.Range(requirementsMinMax.x, requirementsMinMax.y + 1);
		sword.requirements.strength = Random.Range(requirementsMinMax.x, requirementsMinMax.y + 1);
		sword.requirements.intelligence = Random.Range(requirementsMinMax.x, requirementsMinMax.y + 1);
		/*
		sword.requirements.dexterity = Mathf.RoundToInt(requirementsDistribution.Evaluate((float)rng.NextDouble()));
		sword.requirements.strength = Mathf.RoundToInt(requirementsDistribution.Evaluate((float)rng.NextDouble()));
		sword.requirements.intelligence = Mathf.RoundToInt(requirementsDistribution.Evaluate((float)rng.NextDouble()));
		*/

		// level req and value should be dependend on the other requirements
		sword.requirements.level = 0;
		sword.value = Random.Range(valueMinMax.x, valueMinMax.y + 1);
		sword.damage = Random.Range(damageMinMax.x, damageMinMax.y + 1);

		int modAmount = Random.Range(modifiersAmountMinMax.x, modifiersAmountMinMax.y + 1);

		ItemModifier[] modArr = new ItemModifier[modAmount];

		for (int i = 0; i < modAmount; i++)
		{
			modArr[i] = new ItemModifier(Random.Range(modifiersValueMinMax.x, modifiersValueMinMax.y));

			// gets the enum as an array
			ItemModifiers.Types[] types = (ItemModifiers.Types[])System.Enum.GetValues(typeof(ItemModifiers.Types));
			modArr[i].type = types[Random.Range(0, types.Length)];
		}

		sword.Modifiers = modArr;
	}
}
