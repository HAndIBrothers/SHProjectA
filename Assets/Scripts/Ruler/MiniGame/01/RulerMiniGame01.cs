using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RulerMiniGame01 : Ruler
{
    public override void Init()
    {
        // :: 룰러 설정
        App.oInstance.oManagerRuler.SetRuler_MiniGame01(this);

        // :: UI 설정
        this.oUIMiniGame01.Init();
    }

    // :: UI
    public UIMiniGame01 oUIMiniGame01;
}
