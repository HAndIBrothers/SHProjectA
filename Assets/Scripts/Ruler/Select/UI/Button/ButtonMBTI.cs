using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonMBTI : MonoBehaviour
{
    [Header("MBTI")]
    public Enums.eScene oScene;
    public void Init()
    {
        this.GetComponent<Button>().onClick.AddListener(() =>
        {
            App.oInstance.oManagerScene.LoadScene(this.oScene);
        });
    }
}
