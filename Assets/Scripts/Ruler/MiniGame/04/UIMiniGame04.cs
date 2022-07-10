using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMiniGame04 : SHUI
{
    private RulerMiniGame04 iRuler;
    public override void Init(SHRuler _ruler)
    {
        this.iRuler = (RulerMiniGame04)_ruler;
    }
}
