using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gear_Tool_Blink : MonoBehaviour
{
    private Color iBaseColor;
    private Color iZeroColor;
    private Text iText = null;

    // >> Duration
    [SerializeField]
    private float dFirstWaitTime = 1.5f;
    [SerializeField]
    private float dDuration = 1.5f;

    private void Awake()
    {
        this.iText = this.GetComponent<Text>();
        if(iText != null)
        {
            this.iBaseColor = this.iText.color;
            this.iZeroColor = 
                new Color(this.iBaseColor.r, this.iBaseColor.g, this.iBaseColor.b, 0);
            this.iText.color = this.iZeroColor;

            // :: Fade 시작
            Sequence seq = DOTween.Sequence();
            seq.Insert(this.dFirstWaitTime, this.iText.DOFade(1f, dDuration));
            seq.SetLoops(-1, LoopType.Yoyo);
        }
    }
}
