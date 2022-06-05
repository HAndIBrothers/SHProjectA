using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(GearMiniGame01_Data))]

public class GearMiniGame01_DataEditor : Editor
{
    GearMiniGame01_Data iData;

    private void OnEnable()
    {
        this.iData = target as GearMiniGame01_Data;
    }

    public override void OnInspectorGUI()
    {
        this.iData.oGamePlaySeconds 
            = EditorGUILayout.IntField("���� �÷��� �ð�(��)", 
            this.iData.oGamePlaySeconds);

        this.iData.oAddScore
            = EditorGUILayout.IntField("Ŭ�� �� ����", this.iData.oAddScore);

        this.iData.oRandomRespawn
            = EditorGUILayout.Toggle("���� �����", this.iData.oRandomRespawn);
        if(this.iData.oRandomRespawn)
        {
            this.iData.oRespawnTime_Min
                = EditorGUILayout.FloatField("����� ���� �ð�: �ּ�",
                this.iData.oRespawnTime_Min);
            this.iData.oRespawnTime_Max
                = EditorGUILayout.FloatField("����� ���� �ð�: �ִ�",
                this.iData.oRespawnTime_Max);
        } else
        {
            this.iData.oRespawnTime
                = EditorGUILayout.FloatField("����� �ð�", 
                this.iData.oRespawnTime);
        }
        this.iData.oDisappearTime
            = EditorGUILayout.FloatField("������� �ð�",
            this.iData.oDisappearTime);
    }
}
