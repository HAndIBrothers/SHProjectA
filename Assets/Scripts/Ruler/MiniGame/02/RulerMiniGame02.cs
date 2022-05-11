using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RulerMiniGame02 : Ruler
{
    public override void Init()
    {
        // :: 룰러 설정
        App.oInstance.oManagerRuler.SetRuler_MiniGame02(this);

        // :: UI 설정
        this.oUIMiniGame02.Init();
    }

    // :: UI
    [Header("UI")]
    public UIMiniGame02 oUIMiniGame02;
}
