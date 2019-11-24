using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ValueDisplayBar : MonoBehaviour {

    public Slider slider;
    public TextMeshProUGUI text;
    //[Range(0, 100)]
    //public float clampedValue;
    public string textPrestring;

    public float maxValue = 100;
    public float currentValue = 100;


    void Start() {

    }


    public void ChangeValue(float value) {
        currentValue = value;
        UpdateUIElements();
    }

    public void UpdateUIElements() {
        slider.value = (100 / maxValue) * currentValue;
        text.text = textPrestring + Mathf.Round(currentValue).ToString() + "/" + Mathf.Round(maxValue).ToString();
    }

    void OnValidate() {
        UpdateUIElements();
    }
}