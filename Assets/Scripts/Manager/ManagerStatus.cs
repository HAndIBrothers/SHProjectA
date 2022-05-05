using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerStatus : MonoBehaviour
{
    public void Init()
    {
        this.ResetMoney();
    }

    // :: Money
    private int iMoney = 0;
    public int oMoney => this.iMoney;
    private string iKeyMoney = "key_int_money";
    private void ResetMoney()
    {
        this.iMoney = PlayerPrefs.GetInt(this.iKeyMoney, 0);
    }
    public void AddMoney(int _addValue)
    {
        this.iMoney += _addValue;
        PlayerPrefs.SetInt(this.iKeyMoney, this.iMoney);
    }
}
