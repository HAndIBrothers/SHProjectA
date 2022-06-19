using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RulerMiniGame02 : SHRuler
{
    public int oHeart { get; private set; } = 0;
    private void ResetHeart()
    {
        this.oHeart = this.oData.oHeart;
    }
    public void HitHeart() {
        // :: EXIT : Already Dead
        if (this.oHeart <= 0) return;

        this.oHeart -= 1;

        // :: Show Result
        if (this.oHeart <= 0)
        {
            this.oHeart = 0;
            this.iUI.Stop_SpawnBugs();
            this.ShowResult();
        }
        this.iUI.ShowHeart_Current();
    }
    [Header("Data")]
    [SerializeField]
    private GearMiniGame02_Data iData = null;
    public GearMiniGame02_Data oData => this.iData;
    public int oScore { get; private set; } = 0;
    private void ResetScore() { 
        this.oScore = 0;
        this.iUI.ShowScore();
    }
    public void AddScore()
    {
        // :: EXIT : If you don't have hearts
        if (this.oHeart <= 0) return;

        this.oScore += this.oData.oAddScore;
        this.iUI.ShowScore();
    }
    private void ShowResult()
    {
        // :: Log : 축하
        this.iUI.oGEAR_Result.OpenLog(null, "개발자는 멋지게 버그를 잡았습니다.");
        // :: Log : 축하
        this.iUI.oGEAR_Result.OpenLog(null,
            string.Format("총 {0} 점의 점수를 얻었습니다.",
            this.oScore));
        // :: Log : 기본금
        int addMoney = Mathf.FloorToInt(
            this.oScore * this.oData.oAddScore);
        this.iUI.oGEAR_Result.OpenLog(null,
            string.Format("월급으로 {0} 원이 입금되었습니다.",
            addMoney));
        // :: Log : 추가금 : 공식 현재 없음
        int extraMoney = Mathf.FloorToInt(this.oScore / 500) * 100;
        this.iUI.oGEAR_Result.OpenLog(null,
            string.Format("추가 수당 {0} 원이 더 들어왔습니다.",
            extraMoney));
        // :: Log : 총 금액
        int allMoney = addMoney + extraMoney;
        this.iUI.oGEAR_Result.OpenLog(null,
            string.Format("통장에 총 {0} 원이 입금되었군요.",
            allMoney));
        App.oInstance.oManagerStatus.AddMoney(allMoney); // : 실제 추가
        // :: Log : 마지막 문구
        this.iUI.oGEAR_Result.OpenLog(null, "개발자는 정말로 행복해졌습니다!");

        this.iUI.oGEAR_Result.Open();
    }
    public override void Init()
    {
        // :: 룰러 설정
        App.oInstance.oManagerRuler.SetRuler_MiniGame02(this);
        // :: UI 설정
        this.iUI.Init(this);

        // :: 초기화
        this.ResetScore();
        this.ResetHeart();
    }

    // :: UI
    [Header("UI")]
    [SerializeField]
    private UIMiniGame02 iUI;
    public void StartGame()
    {
        this.iUI.ShowHeart_Current();
        this.iUI.Start_SpawnBugs();
    }

    public void Retry()
    {
        // :: 모든 코루틴 정지
        this.StopAllCoroutines();

        // :: Reset Status
        this.ResetHeart();
        this.ResetScore();

        // :: UI 초기화
        this.iUI.oGEAR_Result.Close();
        this.iUI.ShowButton_Start(true);
    }
}
