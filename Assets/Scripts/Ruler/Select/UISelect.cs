using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISelect : MonoBehaviour
{
    [SerializeField]
    private UISelectButtons UISelectButtons_Programer;
    public void Init()
    {
        this.UISelectButtons_Programer.Init();
    }
}
