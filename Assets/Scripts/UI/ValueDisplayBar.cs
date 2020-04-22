using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ValueDisplayBar : MonoBehaviour {

#pragma warning disable 0649
	[SerializeField]
	private Slider slider;
	[SerializeField]
	private TextMeshProUGUI text;
#pragma warning restore 0649

	//[Range(0, 100)]
	//public float clampedValue;
	[SerializeField]
	private string textPrestring;
	public string TextPrestring {
		get => textPrestring;
		set {
			textPrestring = value;
			UpdateUI();
		}
	}
	[SerializeField]
	private float maxValue = 100;
	public float MaxValue {
		get => maxValue;
		set {
			maxValue = value;
			UpdateUI();
		}
	}
	[SerializeField]
	private float currentValue = 100;
	public float CurrentValue {
		get => currentValue;
		set {
			currentValue = value;
			UpdateUI();
		}
	}

	public void UpdateUI() {
		slider.value = (100 / maxValue) * currentValue;
		text.text = textPrestring + Mathf.Round(currentValue).ToString() + "/" + Mathf.Round(maxValue).ToString();
	}

	private void OnValidate() {
		UpdateUI();
	}
}