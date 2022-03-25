using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RulerResult : Ruler
{
    public override void Init()
    {
        // :: ·ê·¯ ¼Â
        App.oInstance.oManagerRuler.SetRuler_Result(this);

        // :: UI / GO Init
        this.oUI.Init();
    }

    // :: UI Logo
    public UIResult oUI;

}
