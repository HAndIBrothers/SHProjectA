using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GearMiniGame02_Controller : MonoBehaviour,
    IPointerDownHandler, IPointerUpHandler
{
    private System.Action iDownAction = null;
    private System.Action iUpAction = null;
    public void Init(System.Action _downAction, System.Action _upAction)
    {
        this.iDownAction = _downAction;
        this.iUpAction = _upAction;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        this.iDownAction?.Invoke();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        this.iUpAction?.Invoke();
    }
}