using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class RulerMiniGame03 : SHRuler
{
    public override void Init()
    {
        // :: Set Ruler
        App.oInstance.oManagerRuler.SetRuler_MiniGame03(this);

        // :: Set UI
        this.iUI.Init(this);

        // :: 게임 시작
        this.StartGame();
    }
    public void StartGame()
    {
        this.iUI.OpenAll();
        this.iUI.ShowResult(false);
    }
    private (int, int) iCurCard = (-1, -1);
    private bool iInput = false;
    public void ClickCard(int _id, int _value)
    {
        // :: EXIT : 이미 타이핑 중이면
        if (this.iInput) return;

        this.iInput = true;

        if (this.iCurCard.Item1 == -1)
        {
            this.iCurCard = (_id, _value);
            this.iUI.GetCardGear(_id)
                .SetStatus(Enums.MiniGame03.Card.eStatus.SELECT);

            // :: End Input
            this.iInput = false;
        } else if(this.iCurCard.Item2 == _value)
        {
            this.iUI.GetCardGear(_id)
                .SetStatus(Enums.MiniGame03.Card.eStatus.CLOSE);
            this.iUI.GetCardGear(this.iCurCard.Item1)
                .SetStatus(Enums.MiniGame03.Card.eStatus.CLOSE);
            this.iCurCard = (-1, -1);

            // :: If all closed
            if (this.iUI.oIsAllClose)
            {
                this.iUI.ShowResult(true);
                this.iUI.OpenAll();
            }

            // :: End Input
            this.iInput = false;
        } else if(this.iCurCard.Item2 != _value)
        {
            this.StartCoroutine(this.IENClickCard_Wrong(_id));
        }
    }
    private IEnumerator IENClickCard_Wrong(int _id)
    {
        this.iUI.GetCardGear(_id)
            .SetStatus(Enums.MiniGame03.Card.eStatus.SELECT);

        yield return new WaitForSeconds(0.5f);

        this.iUI.GetCardGear(_id)
            .SetStatus(Enums.MiniGame03.Card.eStatus.OPEN);
        this.iUI.GetCardGear(this.iCurCard.Item1)
            .SetStatus(Enums.MiniGame03.Card.eStatus.OPEN);
        this.iCurCard = (-1, -1);
        
        // :: End Input
        this.iInput = false;
    }
    // :: UI
    [Header("UI")]
    [SerializeField]
    private UIMiniGame03 iUI;

    // >> Retry
    public void Retry()
    {
        this.iUI.ShowResult(false);
    }
}