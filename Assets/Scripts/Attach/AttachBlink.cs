using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class AttachBlink : MonoBehaviour
{
    [SerializeField]
    private float iDuration = 0.5f;
    private void Start()
    {
        if(this.GetComponent<Text>() != null)
        {
            this.GetComponent<Text>().DOFade(0f, iDuration)
                .SetLoops(-1, LoopType.Yoyo);
        }
    }
}
