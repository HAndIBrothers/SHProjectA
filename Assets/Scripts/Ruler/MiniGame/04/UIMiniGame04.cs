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

        // :: Init
        this.InitSection_Target();
        this.InitUI_Score();
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

    // >> Target
    private Transform iSection_Target;
    public Transform oSection_Target => this.iSection_Target;
    private void InitSection_Target()
    {
        this.iSection_Target = this.transform.Find("Section_Target");
    }

    // >> Score
    private Text iText_Score;
    private void InitUI_Score()
    {
        this.iText_Score = this.transform.Find("Section_Score")
            .Find("Text_Score").GetComponent<Text>();
    }
    public void UpdateScore()
    {
        this.iText_Score.text = this.iRuler.oScore.ToString();
    }
}
