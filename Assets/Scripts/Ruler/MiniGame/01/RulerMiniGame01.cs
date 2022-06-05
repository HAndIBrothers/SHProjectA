using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RulerMiniGame01 : SHRuler
{
    public override void Init()
    {
        // :: �귯 ����
        App.oInstance.oManagerRuler.SetRuler_MiniGame01(this);

        // :: UI ����
        this.oUI.Init();

        // :: ��ġ �ʱ�ȭ
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
                this.oUI.OpenResult(); // : ��� ǥ��
                this.oUI.Stop_SpawnBugs(); 
                // : �� �̻� ���� �������� ����
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
            // :: �ð� ����
            this.iRemainingTime -= Time.deltaTime;

            // :: ���� �ð�
            this.oUI.UpdateRemainingTime();
            yield return null;
        }

        // :: 0���� ����
        this.iRemainingTime = 0;
        this.oUI.UpdateRemainingTime();

        // :: ���� �׼� ����
        _afterAction?.Invoke();
    }

    // :: UI
    [Header("UI")]
    public UIMiniGame01 oUI;

    // :: Prefab
    [Header("Prefab")]
    public GameObject oPREFAB_Bug;

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
        this.oUI.UpdateScore();
    }
    public void AddScore()
    {
        this.iScore += this.oAddScore;
        this.oUI.UpdateScore();
    }
}
