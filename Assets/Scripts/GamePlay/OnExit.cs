using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnExit : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            
            GamePlayController.Instance().OnExitReached();
        }

    }
}
