using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RulerMiniGame04 : SHRuler
{
    public override void Init()
    {
        this.iUI = GameObject.FindObjectOfType<UIMiniGame04>();
        this.iUI.Init(this);
    }
    private UIMiniGame04 iUI;
}
