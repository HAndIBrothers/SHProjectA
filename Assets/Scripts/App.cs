using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class App : SHBehaviour
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
        // :: EXIT : 오브젝트 중복일 경우
        var go = GameObject.FindObjectOfType<App>().gameObject;
        if(go.GetHashCode() != this.gameObject.GetHashCode())
        {
            return;
        }

        // :: 오브젝트 입력
        iInstance = this;
        Object.DontDestroyOnLoad(this.gameObject);

        // :: 매니저 등록
        this.SetManagers();

        // :: 씬 로드
        this.oManagerScene.LoadScene(Enums.eScene.LOGO);
    }

    public ManagerScene oManagerScene { get; private set; }
    public ManagerRuler oManagerRuler { get; private set; }
    public ManagerStatus oManagerStatus { get; private set; }
    public ManagerData oManagerData { get; private set; }
    private void SetManagers()
    {
        // :: Manager GO
        GameObject goManager = Object.Instantiate<GameObject>(
            new GameObject(), this.transform);
        goManager.name = "Managers";

        // :: Set Managers
        this.oManagerScene = this.SetManager<ManagerScene>(goManager);
        this.oManagerRuler = this.SetManager<ManagerRuler>(goManager);
        this.oManagerStatus = this.SetManager<ManagerStatus>(goManager);
        this.oManagerData = this.SetManager<ManagerData>(goManager);
    }
    private T SetManager<T>(GameObject goManager) where T: SHManager
    {
        var manager = goManager.AddComponent<T>();
        manager.Init();

        return manager;
    }
}
