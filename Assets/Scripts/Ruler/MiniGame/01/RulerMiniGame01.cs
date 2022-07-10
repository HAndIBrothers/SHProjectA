using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RulerMiniGame01 : SHRuler
{
    public override void Init()
    {
        // :: 룰러 설정
        App.oInstance.oManagerRuler.SetRuler_MiniGame01(this);

        // :: UI 설정
        this.iUI = GameObject.FindObjectOfType<UIMiniGame01>();
        this.iUI.Init(this);

        // :: 수치 초기화
        this.ResetStatus();
    }

    private void ResetStatus()
    {
        this.ResetScore();
        this.ResetRemainingTime();
    }

    // :: Retry
    public void Retry()
    {
        this.ResetStatus();

        this.iUI.oGEAR_Result.Close();
        this.iUI.ShowButton_Start();
    }

    private Coroutine iCoroutine_StartTime = null;
    public void StartGame()
    {
        this.iUI.Start_SpawnBugs();

        if(this.iCoroutine_StartTime != null)
        {
            this.StopCoroutine(this.iCoroutine_StartTime);
            this.iCoroutine_StartTime = null;
        }
        this.iCoroutine_StartTime =
            this.StartCoroutine(this.IENStartTime(() => {
                this.ShowResult(); // : 결과 표시
                this.iUI.Stop_SpawnBugs(); 
                // : 더 이상 버그 생성하지 않음
            }));
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
    [Header("Time")]
    private float iRemainingTime;
    public int oRemainingTime {
        get
        {
            return Mathf.FloorToInt(this.iRemainingTime);
        }
    }
    private void ResetRemainingTime()
    {
        this.iRemainingTime = this.oData.oGamePlaySeconds + 1;
    }
    private IEnumerator IENStartTime(System.Action _afterAction = null)
    {
        while(this.iRemainingTime > 0)
        {
            // :: 시간 누적
            this.iRemainingTime -= Time.deltaTime;

            // :: 남은 시간
            this.iUI.UpdateRemainingTime();
            yield return null;
        }

        // :: 0으로 설정
        this.iRemainingTime = 0;
        this.iUI.UpdateRemainingTime();

        // :: 다음 액션 실행
        _afterAction?.Invoke();
    }

    // :: UI
    [Header("UI")]
    private UIMiniGame01 iUI;

    [Header("Data")]
    public GearMiniGame01_Data oData;

    // :: Prefab
    [Header("Prefab")]
    public GameObject oPREFAB_Bug;

    // :: Score
    private int iScore;
    public int oScore => this.iScore;
    public void ResetScore()
    {
        this.iScore = 0;
        this.iUI.UpdateScore();
    }
    public void AddScore()
    {
        this.iScore += this.oData.oAddScore;
        this.iUI.UpdateScore();
    }
}
