using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RulerMiniGame02 : SHRuler
{
    public override void Init()
    {
        // :: �귯 ����
        App.oInstance.oManagerRuler.SetRuler_MiniGame02(this);

        // :: UI ����
        this.oUIMiniGame02.Init();
    }

    public void StartGame()
    {
        this.oUIMiniGame02.Start_SpawnBugs();
    }

    // :: UI
    [Header("UI")]
    public UIMiniGame02 oUIMiniGame02;
}
