using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RulerMiniGame04 : SHRuler
{
    public override void Init()
    {
        this.iUI = GameObject.FindObjectOfType<UIMiniGame04>();
        this.iUI.Init(this);

        // :: Open
        this.Open();
    }
    public void Open()
    {
        this.iUI.ShowButton_Start(true);
    }
    private UIMiniGame04 iUI;
    public void StartGame()
    {
        this.iUI.ShowButton_Start(false);
        Debug.LogWarning(":: Start Mini Game 04");
    }
}
