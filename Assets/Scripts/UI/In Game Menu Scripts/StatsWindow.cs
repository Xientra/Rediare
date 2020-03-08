using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StatsWindow : MonoBehaviour {

	[SerializeField]
	private UITexts texts;
	[System.Serializable]
	private class UITexts {

		public TextMeshProUGUI healthPointsText;
		[HideInInspector]
		public string healthPointsString;
		public TextMeshProUGUI magicPointsText;
		[HideInInspector]
		public string magicPointsString;
		public TextMeshProUGUI strengthText;
		[HideInInspector]
		public string strengthString;
		public TextMeshProUGUI dexterityText;
		[HideInInspector]
		public string dexterityString;
		public TextMeshProUGUI intelligenceText;
		[HideInInspector]
		public string intelligenceString;
		public TextMeshProUGUI attackText;
		[HideInInspector]
		public string attackString;
		public TextMeshProUGUI defenceText;
		[HideInInspector]
		public string defenceString;
		public TextMeshProUGUI criticalHitChanceText;
		[HideInInspector]
		public string riticalHitChanceString;
		public TextMeshProUGUI criticalHitMulipierText;
		[HideInInspector]
		public string criticalHitMulipierString;
		public TextMeshProUGUI hpRecoveryText;
		[HideInInspector]
		public string hpRecoveryString;
	}




	void Start() {
		texts.healthPointsString = texts.healthPointsText.text;
		//aaaaaaaaaaaaaaaa
	}

	void Update() {

	}

	public void UpdateUI() { 
		
	}

}