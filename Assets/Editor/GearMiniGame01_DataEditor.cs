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
            = EditorGUILayout.IntField("게임 플레이 시간(초)", 
            this.iData.oGamePlaySeconds);

        this.iData.oAddScore
            = EditorGUILayout.IntField("클릭 당 점수", this.iData.oAddScore);

        this.iData.oRandomRespawn
            = EditorGUILayout.Toggle("랜덤 재생성", this.iData.oRandomRespawn);
        if(this.iData.oRandomRespawn)
        {
            this.iData.oRespawnTime_Min
                = EditorGUILayout.FloatField("재생성 랜덤 시간: 최소",
                this.iData.oRespawnTime_Min);
            this.iData.oRespawnTime_Max
                = EditorGUILayout.FloatField("재생성 랜덤 시간: 최대",
                this.iData.oRespawnTime_Max);
        } else
        {
            this.iData.oRespawnTime
                = EditorGUILayout.FloatField("재생성 시간", 
                this.iData.oRespawnTime);
        }
        this.iData.oDisappearTime
            = EditorGUILayout.FloatField("사라지는 시간",
            this.iData.oDisappearTime);
    }
}
