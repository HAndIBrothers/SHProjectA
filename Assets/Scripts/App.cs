using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class App : MonoBehaviour
{
    private static App iInstance = null;
    public static App oInstance
    {
        get
        {
            return iInstance;
        }
    }

    // :: Check App
    public static void CheckApp()
    {
        if (GameObject.FindObjectOfType<App>() == null)
        {
            ManagerScene.LoadApp();
        }
    }

    private void Awake()
    {
        // :: EXIT : ������Ʈ �ߺ��� ���
        var go = GameObject.FindObjectOfType<App>().gameObject;
        if(go.GetHashCode() != this.gameObject.GetHashCode())
        {
            return;
        }

        // :: ������Ʈ �Է�
        iInstance = this;
        Object.DontDestroyOnLoad(this.gameObject);

        // :: �Ŵ��� ���
        this.SetManagers();

        // :: �� �ε�
        this.oManagerScene.LoadScene(Enums.eScene.LOGO);
    }

    [HideInInspector]
    public ManagerScene oManagerScene = null;
    [HideInInspector]
    public ManagerRuler oManagerRuler = null;
    [HideInInspector]
    public ManagerStatus oManagerStatus = null;
    private void SetManagers()
    {
        // :: �Ŵ���
        GameObject goManager = Object.Instantiate<GameObject>(
            new GameObject(), this.transform);
        goManager.name = "Managers";

        // :: Scene Manager
        this.oManagerScene = goManager.AddComponent<ManagerScene>();

        // :: Ruler Manager
        this.oManagerRuler = goManager.AddComponent<ManagerRuler>();

        // :: Status Manager
        this.oManagerStatus = goManager.AddComponent<ManagerStatus>();
        this.oManagerStatus.Init();
    }
}
