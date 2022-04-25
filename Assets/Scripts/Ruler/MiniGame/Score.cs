using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private static Score iScore = null;
    public static Score oScore => iScore;
    void Awake()
    {
        iScore = this;

        this.UpdateScore();
    }

    private int iPoint = 0;
    public void UpdateScore()
    {
        this.GetComponent<Text>().text = iPoint.ToString();
    }
    public void PlusScore()
    {
        this.iPoint += 100;
        this.UpdateScore();
    }
}
