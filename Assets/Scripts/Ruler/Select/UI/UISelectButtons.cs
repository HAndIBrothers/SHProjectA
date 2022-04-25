using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISelectButtons : MonoBehaviour
{
    public void Init()
    {
        ButtonMBTI[] buttons = this.GetComponentsInChildren<ButtonMBTI>();
        for(int index = 0; index < buttons.Length; index++)
        {
            buttons[index].Init();
        }
    }
}
