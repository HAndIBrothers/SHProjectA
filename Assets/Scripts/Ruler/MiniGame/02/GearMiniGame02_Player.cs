using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearMiniGame02_Player : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        App.oInstance.oManagerRuler.oMiniGame02.HitHeart();
    }
}
