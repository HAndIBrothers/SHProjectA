using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bug : MonoBehaviour
{
    public void Open()
    {
        int x = Random.Range(-640, 640);
        int y = Random.Range(-1060, 1060);

        int goalX = Random.Range(-540, 540);
        int goalY = Random.Range(-960, 960);
        this.transform.localPosition = new Vector2(x, y);

        this.StartCoroutine(this.IENOpen());
        this.StartCoroutine(this.IENMove(goalX, goalY));

    }
    public void PlusScore()
    {
        Score.oScore.PlusScore();
        Object.Destroy(this.gameObject);
    }
    private IEnumerator IENOpen()
    {
        yield return new WaitForSeconds(3);

        Object.Destroy(this.gameObject);
    }
    private IEnumerator IENMove(int _x, int _y)
    {
        int speed = Random.Range(1, 6);
        while(true)
        {
            this.transform.localPosition = 
                Vector2.MoveTowards(
                    this.transform.localPosition, new Vector2(_x, _y), speed);

            yield return null;
        }
    }
}
