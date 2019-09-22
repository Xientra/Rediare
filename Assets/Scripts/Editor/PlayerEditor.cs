using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Player))]
public class PlayerEditor : Editor {

    public override void OnInspectorGUI() {

        Player player = (Player)target;

        DrawDefaultInspector();

        GUILayout.Label("lvl: " + player.LVL.ToString());
        GUILayout.Label("exp: " + player.EXP.ToString());
        GUILayout.Label("hp: " + player.HP.ToString());
        GUILayout.Label("max hp: " + player.maxHP.ToString());
        GUILayout.Label("mp: " + player.MP.ToString());
        GUILayout.Label("max mp: " + player.maxMP.ToString());
        GUILayout.Label("str: " + player.STR.ToString());
        GUILayout.Label("dex: " + player.DEX.ToString());
        GUILayout.Label("int: " + player.INT.ToString());
    }
}