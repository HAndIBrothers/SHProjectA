using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RulerMiniGame02 : Ruler
{
    public override void Init()
    {
        // :: �귯 ����
        App.oInstance.oManagerRuler.SetRuler_MiniGame02(this);

        // :: UI ����
        this.oUIMiniGame02.Init();
    }

    // :: UI
    [Header("UI")]
    public UIMiniGame02 oUIMiniGame02;
}
