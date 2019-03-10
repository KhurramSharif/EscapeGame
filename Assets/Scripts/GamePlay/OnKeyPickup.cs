using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnKeyPickup : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Globals.TotalKeyPickedUp++;
            Destroy(this.gameObject);
        }

    }
}
