using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ruler : MonoBehaviour
{
    private void Awake()
    {
        App.CheckApp();
    }

    public abstract void Init();
}
