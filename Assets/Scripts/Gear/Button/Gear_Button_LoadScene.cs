using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gear_Button_LoadScene : MonoBehaviour
{
    [SerializeField]
    private Enums.eScene dScene = Enums.eScene.LOBBY;
    [SerializeField]
    private float dFadeDuration = 1f;
    private void Awake()
    {
        this.GetComponent<Button>().onClick.AddListener(() =>
        {
            App.oInstance.oDim.ShowDim(true, dFadeDuration, () =>
            {
                App.oInstance.oManagerScene.LoadScene(dScene);
            });
        });
    }
}
