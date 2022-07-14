using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GearMiniGame04_Target : MonoBehaviour
{
    private void Awake()
    {
        this.GetComponent<Button>().onClick.AddListener(() =>
        {
            App.oInstance.oManagerRuler.oMiniGame04.AddScore(10);
            this.Close();
        });
    }
    public void Open(Enums.eDirection eDirection)
    {
        this.StartCoroutine(this.IENMove(eDirection));
    }
    public void Close()
    {
        Object.Destroy(this.gameObject);
    }
    private IEnumerator IENMove(Enums.eDirection eDirection)
    {
        float elapsedTime = 0;
        while(true)
        {
            elapsedTime += Time.deltaTime;
            if (elapsedTime > 5) break;

            if(eDirection == Enums.eDirection.DOWN)
            {
                this.transform.localPosition -= new Vector3(0, 1, 0);
            } else if(eDirection == Enums.eDirection.UP)
            {
                this.transform.localPosition += new Vector3(0, 1, 0);
            }
            yield return null;
        }

        this.Close();
    }
}
