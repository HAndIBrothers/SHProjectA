using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMiniGame04 : SHUI
{
    private RulerMiniGame04 iRuler;
    private GearMiniGame_Result iGear_Result;
    public override void Init(SHRuler _ruler)
    {
        // :: Ruler
        this.iRuler = (RulerMiniGame04)_ruler;

        // :: Start
        this.InitButton_Start();

        // :: Result
        this.iGear_Result = this.transform.Find("Gear_Result")
            .GetComponent<GearMiniGame_Result>();
        this.iGear_Result.Init();
    }
    private Button iButton_Start;
    private void InitButton_Start()
    {
        this.iButton_Start =
            this.transform.Find("Gear_Start").GetComponent<Button>();
        this.iButton_Start.onClick.AddListener(
            () => { this.iRuler.StartGame(); });
    }
    public void ShowButton_Start(bool _check)
    {
        this.iButton_Start.gameObject.SetActive(_check);
    }
}
