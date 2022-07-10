using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RulerInGame : SHRuler
{
    public override void Init()
    {
        // :: 룰러 셋
        App.oInstance.oManagerRuler.SetRuler_InGame(this);

        // :: UI / GO Init
        this.iUI = GameObject.FindObjectOfType<UIInGame>();
        this.iUI.Init();
    }

    // :: UI Logo
    private UIInGame iUI;
}
