using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RulerLogo : Ruler
{
    public override void Init()
    {
        // :: �귯 ��
        App.oInstance.oManagerRuler.SetRuler_Logo(this);

        // :: UI / GO Init
        this.oUI.Init();
    }

    // :: UI Logo
    public UILogo oUI;

}
