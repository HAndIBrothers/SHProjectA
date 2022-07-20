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

        // :: 해상도 고정
        this.SetResolution();

        // :: 오브젝트 입력
        iInstance = this;
        Object.DontDestroyOnLoad(this.gameObject);

        // :: 매니저 등록
        this.SetManagers();

        // :: Dim 등록
        this.InitDim();

        // :: 씬 로드
        this.oManagerScene.LoadScene(Enums.eScene.LOGO);
    }
    // >> Dim 등록
    private UIDim iDim;
    public UIDim oDim => this.iDim;
    private void InitDim()
    {
        this.iDim = GameObject.FindObjectOfType<UIDim>();
        this.iDim.Init();
    }

    // >> 해상도 고정
    private void SetResolution()
    {
        Screen.SetResolution(1440, 2560, false);
    }

    public ManagerScene oManagerScene { get; private set; }
    public ManagerRuler oManagerRuler { get; private set; }
    public ManagerStatus oManagerStatus { get; private set; }
    public ManagerData oManagerData { get; private set; }
    public ManagerPlayer oManagerPlayer { get; private set; }
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
        this.oManagerPlayer = this.SetManager<ManagerPlayer>(goManager);
    }
    private T SetManager<T>(GameObject goManager) where T: SHManager
    {
        var manager = goManager.AddComponent<T>();
        manager.Init();

        return manager;
    }
}
