using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIResult : MonoBehaviour
{
    public void Init()
    {
        this.AddButtonScenario_Retry();
        this.AddButtonScenario_Lobby();
    }

    [SerializeField]
    private Button BUTTON_Retry = null;
    private void AddButtonScenario_Retry()
    {
        this.BUTTON_Retry.onClick.AddListener(() =>
        {
            App.oInstance.oManagerScene.LoadScene(Enums.eScene.IN_GAME);
        });
    }
    [SerializeField]
    private Button BUTTON_Lobby = null;
    private void AddButtonScenario_Lobby()
    {
        this.BUTTON_Lobby.onClick.AddListener(() =>
        {
            App.oInstance.oManagerScene.LoadScene(Enums.eScene.LOBBY);
        });
    }
}