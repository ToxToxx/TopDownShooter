using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowZone : MonoBehaviour
{
    private readonly float _slowMultiplier = 0.6f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerMovement>())
        {

            PlayerMovement.Instance.MultiplySpeed(_slowMultiplier);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<PlayerMovement>())
        {
            PlayerMovement.Instance.MultiplySpeed(1/ _slowMultiplier);
        }
    }
}
