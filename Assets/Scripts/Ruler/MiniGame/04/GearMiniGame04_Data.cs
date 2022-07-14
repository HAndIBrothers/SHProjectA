using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearMiniGame04_Data : MonoBehaviour
{
    [Header("Prefab")]
    [SerializeField]
    private GameObject iPREFAB_TargetObject;
    public GameObject oPREFAB_TargetObject { 
        get { return this.iPREFAB_TargetObject; } }
}
