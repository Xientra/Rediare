using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameMenu : MonoBehaviour {

    public InGameMenu activeInstance;

    [Space(5)]

    public DragAndDropManager dragAndDropManager;

    private void Awake() {
        if (activeInstance == null) {
            activeInstance = this;
        }
        else {
            Destroy(this.gameObject);
            Debug.LogError("Destroyed " + gameObject.name + " because another instance of InGameMenu allready exists.");
        }
    }

    void Start() {

    }

    void Update() {

    }
}