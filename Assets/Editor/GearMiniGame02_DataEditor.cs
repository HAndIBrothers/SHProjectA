using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(GearMiniGame02_Data))]

public class GearMiniGame02_DataEditor : Editor
{
    private GearMiniGame02_Data iData;

    private void OnEnable()
    {
        this.iData = target as GearMiniGame02_Data;
    }

    public override void OnInspectorGUI()
    {
        this.iData.oAddScore
            = EditorGUILayout.IntField("클릭 당 점수", this.iData.oAddScore);

        this.iData.oHeart
            = EditorGUILayout.IntField("기본 하트 개수", this.iData.oHeart);
    }
}
