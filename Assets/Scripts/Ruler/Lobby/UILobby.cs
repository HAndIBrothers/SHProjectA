using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UILobby : MonoBehaviour
{
    public void Init()
    {
        Debug.LogWarning(":: UILobby : Initialise");

        this.AddButtonScenario_Dummy();
    }

    [SerializeField]
    private Button BUTTON_GameStart = null;
    private void AddButtonScenario_Dummy()
    {
        this.BUTTON_GameStart.onClick.AddListener(() =>
        {
            App.oInstance.oManagerScene.LoadScene(Enums.eScene.SELECT);
        });
    }
}
