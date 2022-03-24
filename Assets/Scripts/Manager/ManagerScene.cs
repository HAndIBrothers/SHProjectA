using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerScene : MonoBehaviour
{
    // :: Load App
    public static void LoadApp()
    {
        SceneManager.LoadScene((int)Enums.eScene.APP);
    }

    // :: Load Scene
    public void LoadScene(Enums.eScene _eScene)
    {
        AsyncOperation async = SceneManager.LoadSceneAsync((int)_eScene);
        async.completed += (_ele) =>
        {
            // :: is Done
            if(_ele.isDone)
            {
                // :: Init Ruler
                GameObject.FindObjectOfType<Ruler>().Init();
            }
        };
    }
}
