using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemInfoPanel : MonoBehaviour {

	public GameObject modifierExample;

	[Space(5)]

	public TextMeshProUGUI nameLabel;
	public TextMeshProUGUI valueLabel;
	private string valueText;

	public TextMeshProUGUI atkLabel;
	private string atkText;
	public TextMeshProUGUI defLabel;
	private string defText;

	public TextMeshProUGUI requirementsLabel;
	public GameObject requirementsParent;
	public TextMeshProUGUI strReqLabel;
	private string strReqText;
	public TextMeshProUGUI dexReqLabel;
	private string dexReqText;
	public TextMeshProUGUI intReqLabel;
	private string intReqText;

	public TextMeshProUGUI modifiersLabel;
	public GameObject modifiersParent;
	private List<GameObject> modifierObjects;


	public TextMeshProUGUI descriptionLabel;

	void Awake() {
		valueText = valueLabel.text;
		atkText = atkLabel.text;
		defText = defLabel.text;
		strReqText = strReqLabel.text;
		dexReqText = dexReqLabel.text;
		intReqText = intReqLabel.text;


		modifierExample.SetActive(false);

		atkLabel.gameObject.SetActive(false);
		defLabel.gameObject.SetActive(false);

		requirementsLabel.gameObject.SetActive(false);
		requirementsParent.SetActive(false);
		strReqLabel.gameObject.SetActive(false);
		dexReqLabel.gameObject.SetActive(false);
		intReqLabel.gameObject.SetActive(false);

		modifiersLabel.gameObject.SetActive(false);
		modifiersParent.SetActive(false);
		descriptionLabel.gameObject.SetActive(false);

		modifierObjects = new List<GameObject>();

		gameObject.SetActive(false);
	}

	public void Enable(Item item, Vector3 position) {

		this.GetComponent<RectTransform>().position = position;

		nameLabel.text = item.name;
		nameLabel.gameObject.SetActive(true);

		valueLabel.text = valueText + item.value;
		valueLabel.gameObject.SetActive(true);

		if (item.description != null || item.description != "") {
			descriptionLabel.text = item.description;
		}

		if (item is EquippableItem) {
			EquippableItem ei = (EquippableItem)item;

			strReqLabel.text = strReqText + ei.requiredStrength;
			strReqLabel.gameObject.SetActive(true);
			dexReqLabel.text = dexReqText + ei.requiredDexterity;
			dexReqLabel.gameObject.SetActive(true);
			intReqLabel.text = intReqText + ei.requiredIntelligence;
			intReqLabel.gameObject.SetActive(true);

			requirementsLabel.gameObject.SetActive(true);
			requirementsParent.SetActive(true);
		}

		if (item is Weapon) {
			Weapon w = (Weapon)item;

			atkLabel.text = atkText + w.damage.ToString();
			atkLabel.gameObject.SetActive(true);

			foreach (ItemModifier mod in w.Modifiers) {
				TextMeshProUGUI modLabel = Instantiate(modifierExample, modifiersParent.transform).GetComponent<TextMeshProUGUI>();
				modLabel.text = mod.type.ToString() + " " + ItemModifier.CalculationMethodToString(mod.calculationMethod) + mod.Value;
				modifierObjects.Add(modLabel.gameObject);
				modLabel.gameObject.SetActive(true);
			}
			modifiersLabel.gameObject.SetActive(true);
			modifiersParent.SetActive(true);
		}

		if (item is Armor) {
			Armor a = (Armor)item;

			defLabel.text = defText + a.defence.ToString();
			atkLabel.gameObject.SetActive(true);
		}

		gameObject.SetActive(true);
	}

	public void Disable() {
		atkLabel.gameObject.SetActive(false);
		defLabel.gameObject.SetActive(false);

		requirementsLabel.gameObject.SetActive(false);
		requirementsParent.SetActive(false);
		strReqLabel.gameObject.SetActive(false);
		dexReqLabel.gameObject.SetActive(false);
		intReqLabel.gameObject.SetActive(false);

		modifiersLabel.gameObject.SetActive(false);
		modifiersParent.SetActive(false);
		foreach (GameObject mod in modifierObjects) {
			Destroy(mod);
		}
		modifierObjects.Clear();

		descriptionLabel.gameObject.SetActive(false);

		gameObject.SetActive(false);
	}
}