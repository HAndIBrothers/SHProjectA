using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RulerMiniGame01 : Ruler
{
    public override void Init()
    {
        // :: �귯 ����
        App.oInstance.oManagerRuler.SetRuler_MiniGame01(this);

        // :: UI ����
        this.oUIMiniGame01.Init();
    }

    // :: UI
    public UIMiniGame01 oUIMiniGame01;
}
