using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMiniGame01 : SHUI
{
    private RulerMiniGame01 iRuler;
    public override void Init(SHRuler _ruler)
    {
        // :: 룰러 설정
        this.iRuler = (RulerMiniGame01)_ruler;

        this.AddButtonScenario_Start();

        // :: Init
        this.Init_SectionBug();
        this.oGEAR_Result.Init(); // : 결과 초기화

        // :: 결과창 숨기기
        this.CloseResult();
    }

    // :: 버그
    [Header("Section")]
    public GameObject oSECTION_Bug;
    private float iWidth_SectionBug;
    private float iHeight_SectionBug;
    private void Init_SectionBug()
    {
        Rect rect = this.oSECTION_Bug.GetComponent<RectTransform>().rect;
        this.iWidth_SectionBug = rect.width;
        this.iHeight_SectionBug = rect.height;
    }
    private Coroutine iCoroutine_SpawnBugs;
    public void Start_SpawnBugs()
    {
        this.iCoroutine_SpawnBugs = App.oInstance.oManagerRuler.oMiniGame01
            .StartCoroutine(this.IENSpawnBugs());
    }
    public void Stop_SpawnBugs()
    {
        App.oInstance.oManagerRuler.oMiniGame01
            .StopCoroutine(this.iCoroutine_SpawnBugs);
    }
    private IEnumerator IENSpawnBugs()
    {
        // :: 초기화
        while(this.oSECTION_Bug.transform.childCount > 0)
        {
            Object.Destroy(this.oSECTION_Bug.transform.GetChild(0).gameObject);
        }

        while(true)
        {
            // :: 기어 탐색
            GameObject goBug 
                = Object.Instantiate<GameObject>(
                    App.oInstance.oManagerRuler.oMiniGame01.oPREFAB_Bug, 
                    this.oSECTION_Bug.transform);
            GearMiniGame01_Bug gearBug
                = goBug.GetComponent<GearMiniGame01_Bug>();

            // :: 랜덤 이미지
            float randX = this.iWidth_SectionBug / 2f;
            float randY = this.iHeight_SectionBug / 2f;
            gearBug.Open(randX, randY, this.iRuler.oData.oDisappearTime);

            // :: 재생성 시간
            float respawnSeconds = this.iRuler.oData.oRespawnTime;
            if(this.iRuler.oData.oRandomRespawn)
            {
                respawnSeconds = Random.Range(this.iRuler.oData.oRespawnTime_Min,
                    this.iRuler.oData.oRespawnTime_Max);
            }
            yield return new WaitForSeconds(respawnSeconds);
        }
    }

    // :: 버튼
    [Header("Button")]
    public Button BUTTON_Start;
    public void ShowButton_Start()
    {
        this.BUTTON_Start.gameObject.SetActive(true);
    }
    public void HideButton_Start()
    {
        this.BUTTON_Start.gameObject.SetActive(false);
    }
    private void AddButtonScenario_Start()
    {
        this.BUTTON_Start.onClick.AddListener(() =>
        {
            App.oInstance.oManagerRuler.oMiniGame01.StartGame();
            this.BUTTON_Start.gameObject.SetActive(false);
        });
    }

    // :: Score
    [Header("Score")]
    public Text TEXT_Score;
    public void UpdateScore()
    {
        this.TEXT_Score.text
            = string.Format("{0:#,0}", 
            App.oInstance.oManagerRuler.oMiniGame01.oScore);
    }

    // :: Time
    [Header("Time")]
    public Text TEXT_RemainingTime;
    public void UpdateRemainingTime()
    {
        this.TEXT_RemainingTime.text
            = string.Format("{0}",
            App.oInstance.oManagerRuler.oMiniGame01.oRemainingTime);
    }

    // :: Result
    [Header("Result")]
    public GearMiniGame01_Result oGEAR_Result;
    public void OpenResult()
    {
        this.oGEAR_Result.Open();
    }
    public void CloseResult()
    {
        this.oGEAR_Result.Close();
    }
}
