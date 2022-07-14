using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class Gear_UI_Logo : MonoBehaviour
{
    private Image iImage;
    private Vector3 iBaseScale;
    private Color iBaseColor;
    private Color iMoveColor;
    void Start()
    {
        // :: Set Status
        this.iImage = this.GetComponent<Image>();
        this.iBaseScale = this.transform.localScale;
        this.iBaseColor = new Color(
            this.iImage.color.r, this.iImage.color.g, this.iImage.color.b, 0);
        this.iImage.color = this.iBaseColor;

        this.iMoveColor = new Color(
            this.iBaseColor.r, this.iBaseColor.g, this.iBaseColor.b, 1);

        this.StartCoroutine(this.IENPlay());
    }
    [Header("1st")]
    [SerializeField]
    private float dFirstWaitTime = 0.5f;
    [Header("2nd")]
    [SerializeField]
    private float dReduceScale_To = 0.5f;
    [SerializeField]
    private float dReduceScale_Duration = 3f;
    [SerializeField]
    private Ease dReduceScale_Ease = Ease.OutElastic;
    [Header("3rd")]
    [SerializeField]
    private float dReduceScale_FinalTo = 0.51f;
    [SerializeField]
    private float dReduceScale_FinalDuration = 15f;
    [SerializeField]
    private Ease dReduceScale_FinalEase = Ease.Linear;
    private IEnumerator IENPlay()
    {
        // :: 1st
        yield return new WaitForSeconds(dFirstWaitTime);
        
        // :: 2nd
        Sequence seq = DOTween.Sequence();
        seq.Append(
            this.transform.DOScale(
                dReduceScale_To, dReduceScale_Duration)
            .SetEase(dReduceScale_Ease));
        seq.Join(
            this.iImage.DOColor(this.iMoveColor, dReduceScale_Duration));

        // :: 3rd
        seq.Append(this.transform.DOScale(
                dReduceScale_FinalTo, dReduceScale_FinalDuration)
            .SetEase(dReduceScale_FinalEase));
    }
}
