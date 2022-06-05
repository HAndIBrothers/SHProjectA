using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearMiniGame02_Player : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.LogWarning("Trigger On");
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.LogWarning("Trigger 3D On");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.LogWarning("Collision On");
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.LogWarning("Collision 3D On");
    }
}
