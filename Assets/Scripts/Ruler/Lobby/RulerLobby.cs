using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RulerLobby : SHRuler
{
    public override void Init()
    {
        // :: �귯 ��
        App.oInstance.oManagerRuler.SetRuler_Lobby(this);

        // :: UI / GO Init
        this.oUI.Init();
    }

    // :: UI Logo
    public UILobby oUI;
}
