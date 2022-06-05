using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class GearMiniGame01_Data : SHData
{
    // :: 게임 플레이 시간(초)
    public int oGamePlaySeconds = 30;

    // :: 재생성 관련
    public bool oRandomRespawn = false;
    public float oRespawnTime = 1f;
    public float oRespawnTime_Min = 0.5f;
    public float oRespawnTime_Max = 2f;
    public float oDisappearTime = 2f;

    // :: 클릭당 점수
    public int oAddScore = 100;
}
