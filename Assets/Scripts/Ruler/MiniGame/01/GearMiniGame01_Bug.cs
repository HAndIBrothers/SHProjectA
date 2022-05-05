using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GearMiniGame01_Bug : MonoBehaviour
{
    public void Open(float _x, float _y, float _disappearSecond)
    {
        // :: 위치 지정
        float x = Random.Range(-_x, _x);
        float y = Random.Range(-_y, _y);
        this.transform.localPosition = new Vector2(x, y);

        // :: 좌표 지정 Close 지정
        //float disappearSecond = Random.Range(1f, _disappearSecond);
        this.StartCoroutine(this.IENClose(_disappearSecond));

        this.AddButtonScenario();
    }
    private void Close()
    {
        Object.Destroy(this.gameObject);
    }

    private void AddButtonScenario()
    {
        this.GetComponent<Button>().onClick.AddListener(() =>
        {
            App.oInstance.oManagerRuler.oMiniGame01.AddScore();
            this.Close();
        });
    }

    private IEnumerator IENClose(float _second)
    {
        yield return new WaitForSeconds(_second);
        this.Close();
    }
}
