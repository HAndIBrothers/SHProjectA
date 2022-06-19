using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RulerMiniGame03 : SHRuler
{
    public override void Init()
    {
        // :: Set Ruler
        App.oInstance.oManagerRuler.SetRuler_MiniGame03(this);

        // :: Set UI
        this.iUI.Init(this);
    }
    public void StartGame()
    {

    }
    public void ClickCard(int _id, int _value)
    {
        Debug.LogWarningFormat(">> ID : {0} >> {1}", _id, _value);
    }

    // :: UI
    [Header("UI")]
    [SerializeField]
    private UIMiniGame03 iUI;
}