using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class ManagerScene : SHManager
{
    // :: Load App
    public static void LoadApp()
    {
        SceneManager.LoadScene((int)Enums.eScene.APP);
    }

    // :: Load Scene
    public void LoadScene(Enums.eScene _eScene)
    {
        // :: DOTween 삭제
        DOTween.KillAll();

        AsyncOperation async = SceneManager.LoadSceneAsync((int)_eScene);
        async.completed += (_ele) =>
        {
            // :: is Done
            if(_ele.isDone)
            {
                // :: Init Ruler
                GameObject.FindObjectOfType<SHRuler>().Init();
                App.oInstance.oDim.ShowDim(false, 1);
            }
        };
    }
}
