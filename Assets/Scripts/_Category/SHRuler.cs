using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SHRuler : SHBehaviour
{
    private void Awake()
    {
        App.CheckApp();
    }
}
