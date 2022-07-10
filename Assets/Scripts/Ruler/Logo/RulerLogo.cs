using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RulerLogo : SHRuler
{
    public override void Init()
    {
        // :: 룰러 셋
        App.oInstance.oManagerRuler.SetRuler_Logo(this);

        // :: UI / GO Init
        this.iUI = GameObject.FindObjectOfType<UILogo>();
        this.iUI.Init();
    }

    // :: UI Logo
    private UILogo iUI;
}
