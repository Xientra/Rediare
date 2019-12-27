using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Player))]
public class PlayerEditor : Editor {

    public override void OnInspectorGUI() {


		Player player = (Player)target;
		PlayerStats ps = player.playerStats;

		DrawDefaultInspector();

		GUILayout.Label("lvl: " + ps.LVL.ToString());
        GUILayout.Label("exp: " + ps.EXP.ToString());
        GUILayout.Label("hp: " + ps.HP.ToString());
        GUILayout.Label("max hp: " + ps.maxHP.ToString());
        GUILayout.Label("mp: " + ps.MP.ToString());
        GUILayout.Label("max mp: " + ps.maxMP.ToString());
        GUILayout.Label("str: " + ps.STR.ToString());
        GUILayout.Label("dex: " + ps.DEX.ToString());
        GUILayout.Label("int: " + ps.INT.ToString());
		
	}
}