using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RulerInGame : SHRuler
{
    public override void Init()
    {
        // :: �귯 ��
        App.oInstance.oManagerRuler.SetRuler_InGame(this);

        // :: UI / GO Init
        this.oUI.Init();
    }

    // :: UI Logo
    public UIInGame oUI;
}
