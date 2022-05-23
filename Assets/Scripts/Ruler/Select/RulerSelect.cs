using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RulerSelect : SHRuler
{
    public override void Init()
    {
        // :: ·ê·¯ ¼Â
        App.oInstance.oManagerRuler.SetRuler_Select(this);

        // :: UI / GO Init
        this.oUI.Init();
    }

    // :: UI Logo
    public UISelect oUI;

}
