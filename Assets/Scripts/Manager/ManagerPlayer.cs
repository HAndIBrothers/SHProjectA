using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerPlayer : SHManager
{
    // >> Test Case
    private int iLevel = 3;
    public int oLevel => this.iLevel;
    private string iName = "가나다라마바사아";
    public string oName => this.iName;
    private int iPaidCoin = 2345;
    public int oPaidCoin => this.iPaidCoin;
    private int iFreeCoin = 4521;
    public int oFreeCoin => this.iFreeCoin;
    public Sprite oProfileImage { get
        {
            return Resources.Load<Sprite>("Profile/temp");
        } 
    }
}
