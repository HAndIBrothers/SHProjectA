using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearMiniGame02_Bug : MonoBehaviour
{
    private float iYPosition;
    public void Open(float _x, float _y)
    {
        // :: Y Position
        this.iYPosition = _y;

        this.transform.localPosition = new Vector2(_x, this.iYPosition);

        App.oInstance.oManagerRuler.oMiniGame02
            .StartCoroutine(this.IENMove());
    }
    public void Close()
    {
        Object.Destroy(this.gameObject);
    }

    private IEnumerator IENMove()
    {
        while(true)
        {
            this.transform.localPosition -= 
                new Vector3(0, Time.deltaTime * 1100, 0);

            if(this.transform.localPosition.y < -this.iYPosition)
            {
                break;
            }

            yield return null;
        }

        // :: Add Score
        App.oInstance.oManagerRuler.oMiniGame02.AddScore();
        this.Close();
    }
}
