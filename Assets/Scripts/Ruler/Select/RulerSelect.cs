using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RulerSelect : SHRuler
{
    public override void Init()
    {
        // :: 룰러 셋
        App.oInstance.oManagerRuler.SetRuler_Select(this);

        // :: UI / GO Init
        this.iUI = GameObject.FindObjectOfType<UISelect>();
        this.iUI.Init();
    }

    // :: UI Logo
    private UISelect iUI;

}
