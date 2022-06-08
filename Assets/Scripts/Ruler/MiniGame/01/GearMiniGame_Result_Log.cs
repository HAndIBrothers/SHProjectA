using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GearMiniGame_Result_Log : MonoBehaviour
{
    public Image oIMAGE_Emoticon;
    public Text oTEXT_Log;
    public void Open(Sprite _emoticon, string _text)
    {
        this.oIMAGE_Emoticon.sprite = _emoticon;
        this.oTEXT_Log.text = _text;
    }
}
