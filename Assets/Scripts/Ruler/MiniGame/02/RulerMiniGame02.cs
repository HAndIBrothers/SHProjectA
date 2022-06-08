using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RulerMiniGame02 : SHRuler
{
    [Header("Heart")]
    [SerializeField]
    private GameObject PREFAB_Heart;
    public int oHeart { get; private set; } = 3;
    public void HitHeart() { 
        this.oHeart -= 1;
        if (this.oHeart < 0) this.oHeart = 0;
        this.oUI.ShowHeart_Current();
    }
    public override void Init()
    {
        // :: 룰러 설정
        App.oInstance.oManagerRuler.SetRuler_MiniGame02(this);
        // :: UI 설정
        this.oUI.Init(this);
    }

    // :: UI
    [Header("UI")]
    [SerializeField]
    private UIMiniGame02 oUI;
    public void StartGame()
    {
        this.oUI.ShowHeart_Current();
        this.oUI.Start_SpawnBugs();
    }

}
