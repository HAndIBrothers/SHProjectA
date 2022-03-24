using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISelect : MonoBehaviour
{
    public void Init()
    {
        this.AddButtonScenario_Dummy();
    }

    [SerializeField]
    private Button BUTTON_Dummy = null;
    private void AddButtonScenario_Dummy()
    {
        this.BUTTON_Dummy.onClick.AddListener(() =>
        {
            App.oInstance.oManagerScene.LoadScene(Enums.eScene.IN_GAME);
        });
    }
}
