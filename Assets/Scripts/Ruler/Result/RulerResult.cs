using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RulerResult : Ruler
{
    public override void Init()
    {
        // :: �귯 ��
        App.oInstance.oManagerRuler.SetRuler_Result(this);

        // :: UI / GO Init
        this.oUI.Init();
    }

    // :: UI Logo
    public UIResult oUI;

}
