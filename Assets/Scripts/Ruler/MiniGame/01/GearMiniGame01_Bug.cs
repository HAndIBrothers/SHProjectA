using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearMiniGame01_Bug : MonoBehaviour
{
    public void Open(float _x, float _y, float _disappearSecond)
    {
        // :: 위치 지정
        float x = Random.Range(-_x, _x);
        float y = Random.Range(-_y, _y);
        this.transform.localPosition = new Vector2(x, y);

        // :: 좌표 지정 Close 지정
        float disappearSecond = Random.Range(1f, _disappearSecond);
        this.Close(disappearSecond);
    }
    private void Close(float _second)
    {
        this.StartCoroutine(this.IENClose(_second));
    }
    private IEnumerator IENClose(float _second)
    {
        yield return new WaitForSeconds(_second);
        Object.Destroy(this.gameObject);
    }
}
