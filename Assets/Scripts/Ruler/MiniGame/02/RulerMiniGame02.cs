using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RulerMiniGame02 : SHRuler
{
    public override void Init()
    {
        // :: 룰러 설정
        App.oInstance.oManagerRuler.SetRuler_MiniGame02(this);

        // :: UI 설정
        this.oUI.Init();
    }

    public void StartGame()
    {
        this.oUI.Start_SpawnBugs();
    }

    // :: UI
    [Header("UI")]
    public UIMiniGame02 oUI;
}
