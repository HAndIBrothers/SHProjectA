using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIDim : MonoBehaviour
{
    private Image iDim;
    public void Init()
    {
        this.iDim = this.transform.Find("Dim").GetComponent<Image>();
        this.ShowDim(false, 0);
    }
    public void ShowDim(bool _check, float _duration, 
        System.Action _afterAction = null)
    {
        if (_duration <= 0)
        {
            this.iDim.gameObject.SetActive(_check); 
            return;
        }

        Color firstColor = new Color(0, 0, 0, 1);
        float moveToFade = 0f;
        if (_check)
        {
            firstColor = new Color(0, 0, 0, 0);
            moveToFade = 1;
        }

        this.iDim.color = firstColor;
        this.iDim.gameObject.SetActive(true);
        this.iDim.DOFade(moveToFade, _duration)
            .onComplete = () => { 
                _afterAction?.Invoke();
                if (!_check) this.iDim.gameObject.SetActive(false);
            };
    }
}
