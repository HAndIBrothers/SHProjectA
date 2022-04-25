using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerRuler : MonoBehaviour
{
    // :: 로고
    public RulerLogo oLogo = null;
    public void SetRuler_Logo(RulerLogo _ruler)
    {
        this.oLogo = _ruler;
    }

    // :: 로비
    public RulerLobby oLobby = null;
    public void SetRuler_Lobby(RulerLobby _ruler)
    {
        this.oLobby = _ruler;
    }

    // :: 셀렉트
    public RulerSelect oSelect = null;
    public void SetRuler_Select(RulerSelect _ruler)
    {
        this.oSelect = _ruler;
    }

    // :: 인게임
    public RulerInGame oInGame = null;
    public void SetRuler_InGame(RulerInGame _ruler)
    {
        this.oInGame = _ruler;
    }

    // :: 리설트
    public RulerResult oResult = null;
    public void SetRuler_Result(RulerResult _ruler)
    {
        this.oResult = _ruler;
    }

    // :: 미니 게임
    public RulerMiniGame01 oMiniGame01 = null;
    public void SetRuler_MiniGame01(RulerMiniGame01 _ruler)
    {
        this.oMiniGame01 = _ruler;
    }
}
