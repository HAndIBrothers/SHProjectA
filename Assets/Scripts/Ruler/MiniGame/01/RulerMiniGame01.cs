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
        this.oUI.Init(this);

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

        this.oUI.CloseResult();
        this.oUI.ShowButton_Start();
    }

    private Coroutine iCoroutine_StartTime = null;
    public void StartGame()
    {
        this.oUI.Start_SpawnBugs();

        if(this.iCoroutine_StartTime != null)
        {
            this.StopCoroutine(this.iCoroutine_StartTime);
            this.iCoroutine_StartTime = null;
        }
        this.iCoroutine_StartTime =
            this.StartCoroutine(this.IENStartTime(() => {
                this.oUI.OpenResult(); // : 결과 표시
                this.oUI.Stop_SpawnBugs(); 
                // : 더 이상 버그 생성하지 않음
            }));
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
            this.oUI.UpdateRemainingTime();
            yield return null;
        }

        // :: 0으로 설정
        this.iRemainingTime = 0;
        this.oUI.UpdateRemainingTime();

        // :: 다음 액션 실행
        _afterAction?.Invoke();
    }

    // :: UI
    [Header("UI")]
    public UIMiniGame01 oUI;

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
        this.oUI.UpdateScore();
    }
    public void AddScore()
    {
        this.iScore += this.oData.oAddScore;
        this.oUI.UpdateScore();
    }
}
