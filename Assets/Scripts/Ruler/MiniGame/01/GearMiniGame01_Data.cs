using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class GearMiniGame01_Data : SHData
{
    // :: ���� �÷��� �ð�(��)
    public int oGamePlaySeconds = 30;

    // :: ����� ����
    public bool oRandomRespawn = false;
    public float oRespawnTime = 1f;
    public float oRespawnTime_Min = 0.5f;
    public float oRespawnTime_Max = 2f;
    public float oDisappearTime = 2f;

    // :: Ŭ���� ����
    public int oAddScore = 100;
}
