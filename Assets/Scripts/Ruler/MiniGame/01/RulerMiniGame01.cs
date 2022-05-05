using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RulerMiniGame01 : Ruler
{
    public override void Init()
    {
        // :: 룰러 설정
        App.oInstance.oManagerRuler.SetRuler_MiniGame01(this);

        // :: UI 설정
        this.oUIMiniGame01.Init();

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

        this.oUIMiniGame01.CloseResult();
        this.oUIMiniGame01.ShowButton_Start();
    }

    private Coroutine iCoroutine_StartTime = null;
    public void StartGame()
    {
        this.oUIMiniGame01.Start_SpawnBugs();

        if(this.iCoroutine_StartTime != null)
        {
            this.StopCoroutine(this.iCoroutine_StartTime);
            this.iCoroutine_StartTime = null;
        }
        this.iCoroutine_StartTime =
            this.StartCoroutine(this.IENStartTime(() => {
                this.oUIMiniGame01.OpenResult(); // : 결과 표시
                this.oUIMiniGame01.Stop_SpawnBugs(); 
                // : 더 이상 버그 생성하지 않음
            }));
    }
    [Header("Time")]
    [Range(1, 120)]
    public int oInputRemainingTime = 30;
    private float iRemainingTime;
    public int oRemainingTime {
        get
        {
            return Mathf.FloorToInt(this.iRemainingTime);
        }
    }
    private void ResetRemainingTime()
    {
        this.iRemainingTime = this.oInputRemainingTime + 1;
    }
    private IEnumerator IENStartTime(System.Action _afterAction = null)
    {
        while(this.iRemainingTime > 0)
        {
            // :: 시간 누적
            this.iRemainingTime -= Time.deltaTime;

            // :: 남은 시간
            this.oUIMiniGame01.UpdateRemainingTime();
            yield return null;
        }

        // :: 0으로 설정
        this.iRemainingTime = 0;
        this.oUIMiniGame01.UpdateRemainingTime();

        // :: 다음 액션 실행
        _afterAction?.Invoke();
    }

    // :: UI
    [Header("UI")]
    public UIMiniGame01 oUIMiniGame01;

    // :: Score
    private int iScore;
    public int oScore => this.iScore;
    [Header("Score")]
    [Range(1, 1000)]
    public int oAddScore = 1;
    [Range(1, 10)]
    public float oMultiplyMoneyAndScore = 1;
    public void ResetScore()
    {
        this.iScore = 0;
        this.oUIMiniGame01.UpdateScore();
    }
    public void AddScore()
    {
        this.iScore += this.oAddScore;
        this.oUIMiniGame01.UpdateScore();
    }
}
