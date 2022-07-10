using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISelect : MonoBehaviour
{
    private UISelectButtons iUISelectButtons_Programmer;
    private UISelectButtons iUISelectButtons_Planners;
    private UISelectButtons iUISelectButtons_Artists;
    public void Init()
    {
        // :: Init Select Buttons
        this.InitSelectButtons();
    }
    private void InitSelectButtons()
    {
        Transform transformDivision
            = this.transform.Find("Section_Division");
        this.iUISelectButtons_Programmer =
            transformDivision.Find("Section_Programmers")
            .GetComponent<UISelectButtons>();
        this.iUISelectButtons_Programmer.Init();
        this.iUISelectButtons_Planners =
            transformDivision.Find("Section_Planners")
            .GetComponent<UISelectButtons>();
        this.iUISelectButtons_Planners.Init();
        this.iUISelectButtons_Artists =
            transformDivision.Find("Section_Artists")
            .GetComponent<UISelectButtons>();
        this.iUISelectButtons_Artists.Init();
    }
}
