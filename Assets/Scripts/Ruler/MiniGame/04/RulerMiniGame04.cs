using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RulerMiniGame04 : SHRuler
{
    public override void Init()
    {
        App.oInstance.oManagerRuler.SetRuler_MiniGame04(this);

        // :: Init
        this.InitUI();
        this.InitData();

        // :: Open
        this.Open();
    }
    // >> Score
    private int iScore = 0;
    public int oScore => this.iScore;
    private void ResetScore() { 
        this.iScore = 0;
        this.oUI.UpdateScore();
    }
    public void AddScore(int _score)
    {
        this.iScore += _score;
        this.oUI.UpdateScore();
        Debug.LogWarning("Score : " + this.iScore);
    }
    public void Open()
    {
        this.iUI.ShowButton_Start(true);
        this.ResetScore();
    }
    
    // >> UI
    private UIMiniGame04 iUI;
    public UIMiniGame04 oUI => this.iUI;
    private void InitUI()
    {
        this.iUI = GameObject.FindObjectOfType<UIMiniGame04>();
        this.iUI.Init(this);
    }

    // >> Data
    private GearMiniGame04_Data iData;
    public GearMiniGame04_Data oData => this.iData;
    private void InitData()
    {
        this.iData = GameObject.FindObjectOfType<GearMiniGame04_Data>();
    }

    public void StartGame()
    {
        Debug.LogWarning(":: Start Mini Game 04");

        // :: UI 끄기 
        this.iUI.ShowButton_Start(false);

        // :: 타깃 제작
        this.MakeTarget();
    }
    private void MakeTarget()
    {
        this.StartCoroutine(this.IENMakeTarget());
    }
    private IEnumerator IENMakeTarget()
    {
        var rect = 
            this.oUI.oSection_Target.GetComponent<RectTransform>().rect;
        
        // :: 가로 세로 구하기
        int halfWidth = ((int)rect.width / 2) - 50;
        int halfHeight = ((int)rect.height / 2) + 50;
        while(true)
        {
            int randX = Random.Range(-halfWidth, halfWidth);
            int randY = 0;
            Enums.eDirection eDirection = Enums.eDirection.UP;
            if (Random.Range(0, 2) < 1)
            {
                randY = Random.Range(-halfHeight, -halfHeight - 200);
            } else
            {
                eDirection = Enums.eDirection.DOWN;
                randY = Random.Range(halfHeight, halfHeight + 200);
            }
            var go = Object.Instantiate<GameObject>(
                this.oData.oPREFAB_TargetObject, this.oUI.oSection_Target);
            go.transform.localPosition = new Vector3(randX, randY, 0);
            go.GetComponent<GearMiniGame04_Target>().Open(eDirection);

            yield return new WaitForSeconds(1);
        }
    }
}
