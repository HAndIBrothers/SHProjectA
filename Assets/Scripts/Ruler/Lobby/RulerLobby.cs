using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RulerLobby : SHRuler
{
    public override void Init()
    {
        // :: 룰러 셋
        App.oInstance.oManagerRuler.SetRuler_Lobby(this);

        // :: UI / GO Init
        this.iUI = GameObject.FindObjectOfType<UILobby>();
        this.iUI.Init();

        this.iUI.Open();
    }

    // :: UI Logo
    private UILobby iUI;
    public UILobby oUI => this.iUI;
}
